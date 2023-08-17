using MSCMD.Forms.Activities;
using MSCMD.Model;
using MSCMD.Repository;
using MSCMD.Utils;
using MSCMD.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSCMD.Forms
{
	public partial class Frm_Activity : Form
	{
		private static MscmdContext context;
		private ActivityRepository _activitiesRepository;
		private ActivityElementRelationshipRepository _relElementRepository;
		private ActivityActivityRelationshipRepository _relActivityRepository;
		private AgentActivityRelationshipRepository _relAgentRepository;
		private SubprocessRepository _subprocessessRepository;
		private SubprocessActivityRepository _subprocessessActivityRepository;
		private int filterGroupId = 0;

		private string saveActivitiesTitle = "Salvar atividades";
		public Frm_Activity()
		{
			Configure();
			InitializeComponent();
		}

		private void Configure()
		{
			context = new MscmdContext();
			_activitiesRepository = new ActivityRepository(context);
			_relElementRepository = new ActivityElementRelationshipRepository(context);
			_relActivityRepository = new ActivityActivityRelationshipRepository(context);
			_relAgentRepository = new AgentActivityRelationshipRepository(context);
			_subprocessessRepository = new SubprocessRepository(context);
			_subprocessessActivityRepository = new SubprocessActivityRepository();
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);
			context?.Dispose();
		}

		private void Frm_Atividades_Load(object sender, EventArgs e)
		{
			context.Database.EnsureCreated();
			context.ChangeTracker.DetectChanges();

			loadDataSources();
			loadSubprocess();
			refresh_Activities();
		}

		private void loadDataSources()
		{
			cb_Periodity.DisplayMember = "Value";
			cb_Periodity.ValueMember = "Key";
			cb_Periodity.DataSource = Utility.EnumOf<Periodicity2Enum>();

			//cb_Periodicity1.DataSource = Utility.EnumToList<Periodicity1Enum>();
			//cb_Periodicity2.DataSource = Utility.EnumToList<Periodicity2Enum>();
			cb_Duration.DisplayMember = "Value";
			cb_Duration.ValueMember = "Key";
			cb_Duration.DataSource = Utility.EnumOf<DurationEnum>();
			//cb_Duration.DataSource = Utility.EnumToList<DurationEnum>();

			cb_Periodicity1.DisplayMember = "Value";
			cb_Periodicity1.ValueMember = "Key";
			cb_Periodicity1.DataSource = Utility.EnumOf<Periodicity1Enum>();


		}
		public void loadSubprocess()
		{
			var list = _subprocessessRepository.ListAll().ToList();
			this.subprocessBindingSource.DataSource = list;
		}

		public void LoadSubprocessRelated(int activityId)
		{
			try
			{
				List<SubprocessActivity> relList = _subprocessessActivityRepository.GetByActivity(activityId).ToList();
				if (relList != null && relList.Count > 0)
				{
					subprocessBindingSource1.DataSource = relList.Select(r => r.Subprocess).ToList();
				}
				else
				{
					subprocessBindingSource1.DataSource = null;
				}

			}
			catch
			{
				MessageBox.Show("Erro ao acessar subprocesso vinculado à atividade.");
			}
		}

		private void btn_Importarcsv_Click(object sender, EventArgs e)
		{
			if (filterGroupId != 0)
			{
				Subprocess group = GetSubprocessSelected();
				Frm_ImportCsv form = new Frm_ImportCsv(Model.ScreenEnum.Activity, this, group);
				form.ShowDialog();
			}
			else
			{
				Frm_ImportCsv form = new Frm_ImportCsv(Model.ScreenEnum.Activity, this);
				form.ShowDialog();
			}


		}

		private void btn_DeleteActivity_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (dg_Activities.SelectedRows.Count > 0)
			{
				DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja deletar as atividades selecionadas? Total: " + dg_Activities.SelectedRows.Count + ". Esta operação não poderá ser desfeita", "Deletar Atividade", MessageBoxButtons.YesNoCancel);
				if (dialogResult == DialogResult.Yes)
				{
					try
					{
						foreach (DataGridViewRow row in dg_Activities.SelectedRows)
						{
							var id = row.Cells[0].Value;
							if (id != null && (int)id != 0)
							{

								Activity activity = _activitiesRepository.FindBy((int)id);
								_activitiesRepository.Delete(activity);

							}
						}
					}
					catch
					{
						MessageBox.Show("Erro ao deletar.");
					}

					refresh_Activities();
				}
			}
			else
			{
				MessageBox.Show("Nenhuma atividade selecionada.");
			}
			Cursor.Current = Cursors.Default;

		}

		private void btn_SaveActivities_Click(object sender, EventArgs e)
		{
			if (dg_Activities.DataSource != null)
			{
				var wms = dg_Activities.DataSource;
				BindingSource bs = dg_Activities.DataSource as BindingSource;
				if (bs.DataSource != null)
				{
					List<Activity> list = bs.DataSource as List<Activity>;
					if (list.Where(el => el.ActivityName == "" || el.ActivityName == null).Any())
					{
						MessageBox.Show("O nome da atividade não pode ser vazio.", saveActivitiesTitle, MessageBoxButtons.OK);
					}
					else
					{
						_activitiesRepository.SaveList(list);
						refresh_ActivityDetails();
						MessageBox.Show("Alterações salvas com sucesso.", saveActivitiesTitle, MessageBoxButtons.OK);
					}
				}
				else
				{
					MessageBox.Show("Não há itens a serem salvos.", saveActivitiesTitle, MessageBoxButtons.OK);
				}



			}
			else
			{
				MessageBox.Show("Não há itens a serem salvos.", saveActivitiesTitle, MessageBoxButtons.OK);
			}
		}

		private void btn_SaveDetails_Click(object sender, EventArgs e)
		{
			SaveDetails();

		}

		private void SaveDetails()
		{
			try
			{
				Activity activity = GetActivitySelected();
				if (activity != null)
				{
					activity.ActivityDescription = rtxtb_Description.Text;
					activity.RequiredCompetence = rtxtb_Competences.Text;

					if (cb_Periodicity1.SelectedItem != null)
					{
						KeyValuePair<Periodicity1Enum, string> relEnum = (KeyValuePair<Periodicity1Enum, string>)cb_Periodicity1.SelectedItem;
						Periodicity1Enum p1 = (Periodicity1Enum)relEnum.Key;
						activity.Periodicity1 = p1;
					}
					//activity.Periodicity1 = (Periodicity1Enum)cb_Periodicity1.SelectedItem;
					if (cb_Periodity.SelectedItem != null)
					{
						KeyValuePair<Periodicity2Enum, string> relEnum = (KeyValuePair<Periodicity2Enum, string>)cb_Periodity.SelectedItem;
						Periodicity2Enum p2 = (Periodicity2Enum)relEnum.Key;
						activity.Periodicity2 = p2;
					}
					if (cb_Duration.SelectedItem != null)
					{
						KeyValuePair<DurationEnum, string> relEnum = (KeyValuePair<DurationEnum, string>)cb_Duration.SelectedItem;
						DurationEnum d = (DurationEnum)relEnum.Key;
						activity.Duration = d;
					}
					//activity.Duration = (DurationEnum)cb_Duration.SelectedItem;


					_activitiesRepository.Save(activity);

					refresh_ActivityDetails();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btn_AddActivRelation_Click(object sender, EventArgs e)
		{
			Activity activ = GetActivitySelected();

			if (activ != null)
			{
				Frm_ActivityActivityRelationship frm = new Frm_ActivityActivityRelationship(activ, this);
				frm.ShowDialog();
			}
			else
			{
				MessageBox.Show("Nenhuma atividade selecionada.");
			}

		}

		private void btn_DeleteActivRelation_Click_old(object sender, EventArgs e)
		{
			if (dg_activityRelationship.SelectedRows.Count > 0)
			{
				DataGridViewRow row = new DataGridViewRow();
				row = dg_activityRelationship.SelectedRows[0];
				int relationshipId = (int)row.Cells[0].Value;

				if (relationshipId != 0)
				{
					if (relationshipId != 0)
					{
						DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja deletar a relação?", "Deletar Relação Atividade Atividade", MessageBoxButtons.YesNo);

						if (dialogResult == DialogResult.Yes)
						{
							try
							{
								_relActivityRepository.DeleteById(relationshipId);
								refresh_Activities();
							}
							catch
							{
								MessageBox.Show("Erro ao deletar item.");
							}
						}
					}
				}
			}
		}
		private void btn_DeleteActivRelation_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (dg_activityRelationship.SelectedRows.Count > 0)
			{
				DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja deletar as relações? Total: " + dg_activityRelationship.SelectedRows.Count, "Deletar Relação Atividade Atividade", MessageBoxButtons.YesNo);

				if (dialogResult == DialogResult.Yes)
				{
					foreach (DataGridViewRow row in dg_activityRelationship.SelectedRows)
					{
						int relationshipId = (int)row.Cells[0].Value;

						if (relationshipId != 0)
						{

							try
							{
								_relActivityRepository.DeleteById(relationshipId);

							}
							catch
							{
								MessageBox.Show("Erro ao deletar item.");
							}

						}
					}
					refresh_Activities();
				}
			}
			Cursor.Current = Cursors.Default;
		}

		private void btn_AddElement_Click(object sender, EventArgs e)
		{
			Activity activ = GetActivitySelected();

			if (activ != null)
			{
				Frm_ActivityElementRelationship frm = new Frm_ActivityElementRelationship(activ, this);
				frm.ShowDialog();
			}
			else
			{
				MessageBox.Show("Nenhuma atividade selecionada.");
			}
		}

		private void btn_DeleteElement_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (dg_elementRelationship.SelectedRows.Count > 0)
			{
				DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja deletar as relações? Total: " + dg_elementRelationship.SelectedRows.Count, "Deletar Relação Atividade x Elemento", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					foreach (DataGridViewRow row in dg_elementRelationship.SelectedRows)
					{
						int relationshipId = (int)row.Cells[0].Value;
						if (relationshipId != 0)
						{
							try
							{
								_relElementRepository.DeleteById(relationshipId);

							}
							catch
							{
								MessageBox.Show("Erro ao deletar item.");
							}

						}
					}
					refresh_Activities();
				}
			}
			Cursor.Current = Cursors.Default;
		}

		private void btn_AddAgent_Click(object sender, EventArgs e)
		{
			Activity activ = GetActivitySelected();

			if (activ != null)
			{
				Frm_ActivityAgentRelationship frm = new Frm_ActivityAgentRelationship(activ, this);
				frm.ShowDialog();
			}
			else
			{
				MessageBox.Show("Nenhuma atividade selecionada.");
			}
		}

		private void btn_DeleteAgent_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (dg_AgentRelationship.SelectedRows.Count > 0)
			{
				DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja deletar as relações? Total: " + dg_AgentRelationship.SelectedRows.Count, "Deletar Relação Atividade x Função", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					foreach (DataGridViewRow row in dg_AgentRelationship.SelectedRows)
					{
						int relationshipId = (int)row.Cells[0].Value;
						if (relationshipId != 0)
						{
							try
							{
								_relAgentRepository.DeleteById(relationshipId);
							}
							catch
							{
								MessageBox.Show("Erro ao deletar item.");
							}

						}
					}
					refresh_Activities();
				}
			}
			Cursor.Current = Cursors.Default;
		}

		private Activity GetActivitySelected()
		{
			if (dg_Activities.SelectedRows.Count > 0)
			{
				DataGridViewRow dataRow = dg_Activities.SelectedRows[0];
				var row = dataRow.Cells[0].Value;

				if (row != null && (int)row != 0)
				{
					int activityId = (int)row;

					//if (activityId == 0)
					//{
					//	string cod = (string)dataRow.Cells[1].Value;
					//	string nome = (string)dataRow.Cells[2].Value;

					//	if (!string.IsNullOrEmpty(nome))
					//	{
					//		Activity act = new Model.Activity()
					//		{
					//			ActivityCode = cod,
					//			ActivityName = nome
					//		};

					//		_activitiesRepository.AddNew(act);

					//		Activity activity = _activitiesRepository.FindBy(act.ActivityId);
					//		refresh_Activities();
					//		return activity;
					//	}
					//	else
					//	{
					//		return null;
					//	}

					//}
					//else
					//{
					Activity activity = _activitiesRepository.FindBy(activityId);
					return activity;
					//}
				}
				else
				{
					return null;
				}
			}
			else
			{
				return null;
			}
		}

		private void LoadActivitySelectedData()
		{
			Activity activity = GetActivitySelected();
			if (activity != null)
			{
				rtxtb_Description.Text = activity.ActivityDescription;
				rtxtb_Competences.Text = activity.RequiredCompetence;

				cb_Periodicity1.Text = activity.Periodicity1 != null ? Utility.GetEnumDescription(activity.Periodicity1) : "";
				cb_Periodity.Text = activity.Periodicity2 != null ? Utility.GetEnumDescription(activity.Periodicity2) : "";
				cb_Duration.Text = activity.Duration != null ? Utility.GetEnumDescription(activity.Duration) : "";
			}
		}

		private void GetElementsRelationships(int activityId)
		{
			try
			{
				List<ActivityElementRelationship> relationships = _relElementRepository.GetByActivity(activityId).ToList();

				List<RelationshipViewModel> rel = relationships.Select(r => new RelationshipViewModel
				{
					RelationshipId = r.RelationshipId,
					Relationship = Utility.GetEnumDescription(r.Relation),
					Code = r.Component.Code ?? "",
					Name = r.Component.Name
				}).ToList();

				dg_elementRelationship.DataSource = rel;

			}
			catch
			{
				MessageBox.Show("Erro ao acessar elementos vinculados à atividade.");
			}
		}

		private void GetActivitiesRelationships(int activityId)
		{
			try
			{
				List<ActivityActivityRelationship> relationships = _relActivityRepository.GetByReferenceActivity(activityId).ToList();

				List<RelationshipViewModel> rel = relationships.Select(r => new RelationshipViewModel
				{
					RelationshipId = r.RelationshipId,
					Relationship = Utility.GetEnumDescription(r.Relation),
					Code = r.ReferredActivity.ActivityCode ?? "",
					Name = r.ReferredActivity.ActivityName
				}).ToList();

				dg_activityRelationship.DataSource = rel;
			}
			catch
			{
				MessageBox.Show("Erro ao acessar atividades vinculadas à atividade.");
			}
		}

		private void GetAgentsRelationships(int activityId)
		{
			try
			{

				List<AgentActivityRelationship> relationships = _relAgentRepository.GetByActivityId(activityId).ToList();

				List<RelationshipViewModel> rel = relationships.Select(r => new RelationshipViewModel
				{
					RelationshipId = r.RelationshipId,
					Code = r.ResponsibleAgent.Code ?? "",
					Name = r.ResponsibleAgent.Name
				}).ToList();

				dg_AgentRelationship.DataSource = rel;
			}
			catch
			{
				MessageBox.Show("Erro ao acessar funções vinculadas à atividade.");
			}
		}

		private Subprocess GetSubprocessSelected()
		{
			if (dg_Group.SelectedRows.Count > 0)
			{
				DataGridViewRow row = new DataGridViewRow();
				row = dg_Group.SelectedRows[0];
				if (row.Cells[0].Value != null)
				{
					int id = (int)row.Cells[0].Value;

					if (id != 0)
					{
						Subprocess subprocess = _subprocessessRepository.FindBy(id);
						return subprocess;
					}
					else
					{
						return null;
					}
				}
				else { return null; }
			}
			else
			{
				return null;
			}
		}

		public void refresh_Activities(bool refreshDetails = true)
		{
			context.ChangeTracker.DetectChanges();

			if (filterGroupId != 0)
			{
				var subprocessActivity = _subprocessessActivityRepository.GetBySubprocess(filterGroupId).Select(x => x.Activity);
				if (subprocessActivity != null)
				{
					List<Activity> list = subprocessActivity.ToList();
					activityBindingSource.DataSource = list;
					lbl_ActivitiesTotal.Text = "Total: " + list.Count.ToString();
				}

			}
			else
			{
				var activitiesList = _activitiesRepository.ListAll().ToList();
				activityBindingSource.DataSource = activitiesList;
				lbl_ActivitiesTotal.Text = "Total: " + activitiesList.Count.ToString();
			}


			if (refreshDetails)
				refresh_ActivityDetails();
		}

		public void refresh_ActivityDetails()
		{
			try
			{
				Activity activity = GetActivitySelected();

				if (activity != null)
				{
					int activityId = activity.ActivityId;

					lbl_ActivityName.Text = activity.ActivityName;

					GetElementsRelationships(activityId);
					GetActivitiesRelationships(activityId);
					GetAgentsRelationships(activityId);
					LoadSubprocessRelated(activityId);

					LoadActivitySelectedData();
					EnableDetailsButtons();
				}
				else
				{
					lbl_ActivityName.Text = null;
					rtxtb_Description.Text = null;
					rtxtb_Competences.Text = null;
					cb_Duration.Text = null;
					cb_Periodicity1.Text = null;
					cb_Periodity.DataSource = null;
					dg_activityRelationship.DataSource = null;
					dg_AgentRelationship.DataSource = null;
					dg_elementRelationship.DataSource = null;


					DisableDetailsButtons();

				}
			}
			catch
			{
				MessageBox.Show("Erro ao acessar detalhes vinculados à atividade selecionada.");
			}
		}

		private void DisableDetailsButtons()
		{
			rtxtb_Description.Enabled = false;
			rtxtb_Competences.Enabled = false;
			cb_Duration.Enabled = false;
			cb_Periodicity1.Enabled = false;
			cb_Periodity.Enabled = false;

			btn_AddActivRelation.Enabled = false;
			btn_DeleteActivRelation.Enabled = false;
			btn_AddElement.Enabled = false;
			btn_DeleteElement.Enabled = false;
			btn_AddAgent.Enabled = false;
			btn_DeleteAgent.Enabled = false;
		}

		private void EnableDetailsButtons()
		{
			rtxtb_Description.Enabled = true;
			rtxtb_Competences.Enabled = true;
			cb_Duration.Enabled = true;
			cb_Periodicity1.Enabled = true;
			cb_Periodity.Enabled = true;

			btn_AddActivRelation.Enabled = true;
			btn_DeleteActivRelation.Enabled = true;
			btn_AddElement.Enabled = true;
			btn_DeleteElement.Enabled = true;
			btn_AddAgent.Enabled = true;
			btn_DeleteAgent.Enabled = true;
		}

		private void dg_Activities_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			refresh_ActivityDetails();
		}

		private void btn_SubprocessScreen_Click(object sender, EventArgs e)
		{
			Frm_Subprocess frm = new Frm_Subprocess(this, context);
			frm.ShowDialog();
		}

		private void btn_FilterActivities_Click(object sender, EventArgs e)
		{
			Subprocess subprocess = GetSubprocessSelected();
			if (subprocess != null)
			{

				List<Activity> activitiesList = _subprocessessActivityRepository.GetBySubprocess(subprocess.SubprocessId).Select(r => r.Activity).ToList();
				activityBindingSource.DataSource = activitiesList;
				lbl_ActivitiesTotal.Text = "Total: " + activitiesList.Count.ToString();

				refresh_ActivityDetails();

				lbl_GroupFilter.Text = subprocess.Name;
				filterGroupId = subprocess.SubprocessId;

			}
			else
			{
				MessageBox.Show("Nenhum subprocesso selecionado.");
			}

		}

		private void btn_ShowAllActivities_Click(object sender, EventArgs e)
		{
			lbl_GroupFilter.Text = "TODAS";
			filterGroupId = 0;
			refresh_Activities();
		}


		#region Sort 

		private void dg_Group_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			DataGridView grid = (DataGridView)sender;
			SortSubproccess(grid.Columns[e.ColumnIndex].DataPropertyName, SortOrder.Ascending);
			grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
		}

		private void dg_Activities_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			DataGridView grid = (DataGridView)sender;
			SortActivity(grid.Columns[e.ColumnIndex].DataPropertyName, SortOrder.Ascending);
			grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
		}
		private void SortActivity(string column, SortOrder sortOrder)
		{
			List<Activity> list = new List<Activity>();


			if (filterGroupId != 0)
			{
				list = _subprocessessActivityRepository.GetBySubprocess(filterGroupId).Select(r => r.Activity).ToList();

			}
			else
			{
				list = _activitiesRepository.ListAll().ToList();

			}

			switch (column)
			{
				case "ActivityCode":
					{
						if (sortOrder == SortOrder.Ascending)
						{
							activityBindingSource.DataSource = list.OrderBy(x => x.ActivityCode).ToList();
						}
						else
						{
							activityBindingSource.DataSource = list.OrderByDescending(x => x.ActivityCode).ToList();
						}
						break;
					}
				case "ActivityName":
					{
						if (sortOrder == SortOrder.Ascending)
						{
							activityBindingSource.DataSource = list.OrderBy(x => x.ActivityName).ToList();
						}
						else
						{
							activityBindingSource.DataSource = list.OrderByDescending(x => x.ActivityName).ToList();
						}
						break;
					}

			}
			refresh_ActivityDetails();

		}

		private void SortSubproccess(string column, SortOrder sortOrder)
		{
			List<Subprocess> list = _subprocessessRepository.ListAll().ToList();

			switch (column)
			{
				case "Code":
					{
						if (sortOrder == SortOrder.Ascending)
						{
							subprocessBindingSource.DataSource = list.OrderBy(x => x.Code).ToList();
						}
						else
						{
							subprocessBindingSource.DataSource = list.OrderByDescending(x => x.Code).ToList();
						}
						break;
					}
				case "Name":
					{
						if (sortOrder == SortOrder.Ascending)
						{
							subprocessBindingSource.DataSource = list.OrderBy(x => x.Name).ToList();
						}
						else
						{
							subprocessBindingSource.DataSource = list.OrderByDescending(x => x.Name).ToList();
						}
						break;
					}

			}

		}
		#endregion


		private void btn_DeleteSubprocess_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (dg_Group.SelectedRows.Count > 0)
			{
				DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja deletar os subprocessos selecionados? Total: " + dg_Group.SelectedRows.Count + ". Esta operação não poderá ser desfeita. Obs: As atividades do subprocesso não serão deletadas, apenas desvinculadas.", "Deletar Subprocesso", MessageBoxButtons.YesNoCancel);
				if (dialogResult == DialogResult.Yes)
				{
					try
					{
						foreach (DataGridViewRow row in dg_Group.SelectedRows)
						{
							var id = row.Cells[0].Value;
							if (id != null && (int)id != 0)
							{

								Subprocess subprocess = _subprocessessRepository.FindBy((int)id);
								_subprocessessRepository.Delete(subprocess);

								if (filterGroupId == (int)id)
								{
									filterGroupId = 0;
									lbl_GroupFilter.Text = "TODAS";
								}
							}
						}
					}
					catch
					{
						MessageBox.Show("Erro ao deletar.");
					}

					loadSubprocess();
					refresh_Activities();
				}
			}
			else
			{
				MessageBox.Show("Nenhum subprocesso selecionado.");
			}
			Cursor.Current = Cursors.Default;


		}

		private void rtxtb_Description_Leave(object sender, EventArgs e)
		{
			SaveDetails();
		}

		private void rtxtb_Competences_Leave(object sender, EventArgs e)
		{
			SaveDetails();
		}

		private void cb_Periodicity1_Leave(object sender, EventArgs e)
		{
			SaveDetails();
		}

		private void cb_Periodicity2_Leave(object sender, EventArgs e)
		{
			SaveDetails();
		}

		private void cb_Duration_Leave(object sender, EventArgs e)
		{
			SaveDetails();
		}

		private void dg_Group_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			var rowVal = e.RowIndex;
			var row = dg_Group.Rows[rowVal];
			var ind = row.Cells[0].Value;


			if (ind != null)
			{
				int index = (int)ind;
				Subprocess subprocess = new Subprocess();

				if (index != 0)
				{
					subprocess = _subprocessessRepository.FindBy(index);
				}

				var name = row.Cells[2].Value;
				if (name != null)
				{
					string sName = (string)name;
					if (sName != "")
					{
						subprocess.Name = sName;
						subprocess.Code = (string)row.Cells[1].Value;

						_subprocessessRepository.Save(subprocess);

						loadSubprocess();
					}
					else if ((string)dg_Group.Columns[e.ColumnIndex].DataPropertyName == "Name")
					{
						MessageBox.Show("O nome não pode ser vazio.");
					}
				}
				else if ((string)dg_Group.Columns[e.ColumnIndex].DataPropertyName == "Name")
				{
					MessageBox.Show("O nome não pode ser vazio.");
				}

			}
		}

		private void dg_Activities_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			var rowVal = e.RowIndex;
			var row = dg_Activities.Rows[rowVal];
			var ind = row.Cells[0].Value;


			if (ind != null)
			{
				int index = (int)ind;
				Activity activity = new Activity();

				if (index != 0)
				{
					activity = _activitiesRepository.FindBy(index);
				}

				var name = row.Cells[2].Value;
				if (name != null)
				{
					string agentName = (string)name;
					if (agentName != "")
					{
						activity.ActivityName = agentName;
						activity.ActivityCode = (string)row.Cells[1].Value;

						_activitiesRepository.Save(activity);

						if (filterGroupId != 0)
						{
							SubprocessActivity rel = new SubprocessActivity
							{
								ActivityId = activity.ActivityId,
								SubprocessId = filterGroupId
							};
							_subprocessessActivityRepository.AddNew(rel);

						}
						refresh_Activities();
					}
					else if ((string)dg_Activities.Columns[e.ColumnIndex].DataPropertyName == "ActivityName")
					{
						MessageBox.Show("Nome da atividade não pode ser vazio.");
					}
				}
				else if ((string)dg_Activities.Columns[e.ColumnIndex].DataPropertyName == "ActivityName")
				{
					MessageBox.Show("Nome da atividade não pode ser vazio.");
				}

			}


		}

		private void dg_Activities_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			refresh_ActivityDetails();
		}

		private void btn_ImportActivityRel_Click(object sender, EventArgs e)
		{
			Frm_ImportCsv form = new Frm_ImportCsv(Model.ScreenEnum.ActivityRelationship, this);
			form.ShowDialog();
		}

		private void btn_ImportActivityElementRel_Click(object sender, EventArgs e)
		{
			Frm_ImportCsv form = new Frm_ImportCsv(Model.ScreenEnum.ActivityElementRelationship, this);
			form.ShowDialog();
		}

		private void btn_ImportActivityAgent_Click(object sender, EventArgs e)
		{
			Frm_ImportCsv form = new Frm_ImportCsv(Model.ScreenEnum.ActivityAgentRelationship, this);
			form.ShowDialog();
		}

		private void dg_Activities_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.ColumnIndex == 0)
				if (dg_Activities[e.ColumnIndex, e.RowIndex].ReadOnly)
					e.CellStyle.BackColor = Color.LightGray;
		}

		private void btn_ImportSectors_Click(object sender, EventArgs e)
		{

			Frm_ImportCsv form = new Frm_ImportCsv(ScreenEnum.Subprocess, this);
			form.ShowDialog();

		}

		private void btn_ExportActivity_Click(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					try
					{
						List<Activity> list = (List<Activity>)activityBindingSource.DataSource;

						string fileName = "atividade";
						if (filterGroupId != 0)
						{
							fileName += "_S" + filterGroupId.ToString();
						}
						fileName += ".csv";

						string destFile = Path.Combine(fbd.SelectedPath, fileName);

						WriteCustomCSV.ActivitiesToCSV(list, destFile);

					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Aviso");
					}
				}
			}
		}

		private void btn_ExportSubprocess_Click(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					try
					{
						List<Subprocess> list = (List<Subprocess>)subprocessBindingSource.DataSource;

						string fileName = "subprocesso.csv";
						string destFile = Path.Combine(fbd.SelectedPath, fileName);

						WriteCustomCSV.SubprocessToCSV(list, destFile);

					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Aviso");
					}
				}
			}
		}

		private void btn_ExportActivityActivity_Click(object sender, EventArgs e)
		{
			Activity activity = GetActivitySelected();
			if (activity != null)
			{
				using (var fbd = new FolderBrowserDialog())
				{
					DialogResult result = fbd.ShowDialog();

					if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
					{
						try
						{
							List<ActivityActivityRelationship> relations = _relActivityRepository.GetByReferenceActivity(activity.ActivityId).ToList();
							string fileName = "relacoes_AtividadexAtividade_A" + activity.ActivityId + ".csv";
							string destFile = Path.Combine(fbd.SelectedPath, fileName);
							WriteCustomCSV.RelActivityxActivityToCSV(relations, destFile);

						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message, "Aviso");
						}
					}
				}
			}
			else
			{
				MessageBox.Show("Nenhuma função selecionada.", "Aviso");
			}
		}

		private void btn_ExportActivityElement_Click(object sender, EventArgs e)
		{
			Activity activity = GetActivitySelected();
			if (activity != null)
			{
				using (var fbd = new FolderBrowserDialog())
				{
					DialogResult result = fbd.ShowDialog();

					if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
					{
						try
						{
							List<ActivityElementRelationship> relations = _relElementRepository.GetByActivity(activity.ActivityId).ToList();
							string fileName = "relacoes_AtividadexElemento_A" + activity.ActivityId + ".csv";
							string destFile = Path.Combine(fbd.SelectedPath, fileName);
							WriteCustomCSV.RelActivityxElementToCSV(relations, destFile);

						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message, "Aviso");
						}
					}
				}
			}
			else
			{
				MessageBox.Show("Nenhuma atividade selecionada.", "Aviso");
			}
		}

		private void btn_ExportActivityAgent_Click(object sender, EventArgs e)
		{
			Activity activity = GetActivitySelected();
			if (activity != null)
			{
				using (var fbd = new FolderBrowserDialog())
				{
					DialogResult result = fbd.ShowDialog();

					if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
					{
						try
						{

							List<AgentActivityRelationship> relations = _relAgentRepository.GetByActivityId(activity.ActivityId).ToList();
							string fileName = "relacoes_AtividadexFuncao_A" + activity.ActivityId + ".csv";
							string destFile = Path.Combine(fbd.SelectedPath, fileName);

							WriteCustomCSV.RelActivityxFunctionToCSV(relations, destFile);

						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message, "Aviso");
						}
					}
				}
			}
			else
			{
				MessageBox.Show("Nenhuma atividade selecionada.", "Aviso");
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (dataGridView1.SelectedRows.Count > 0)
			{
				DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja deletar as relações? Total: " + dataGridView1.SelectedRows.Count, "Desvincular Subprocessos", MessageBoxButtons.YesNo);

				if (dialogResult == DialogResult.Yes)
				{
					foreach (DataGridViewRow row in dataGridView1.SelectedRows)
					{
						var relationshipId = row.Cells[0].Value;

						if (relationshipId != null && (int)relationshipId != 0)
						{
							try
							{
								Activity ac = GetActivitySelected();

								SubprocessActivity rel = _subprocessessActivityRepository.GetBySubprocessActivity((int)relationshipId, ac.ActivityId);

								if (rel != null && ac != null)
								{
									_subprocessessActivityRepository.Delete(rel);

								}
							}
							catch
							{
								MessageBox.Show("Erro ao deletar item.");
							}
						}
					}
					refresh_Activities();
				}
			}
			Cursor.Current = Cursors.Default;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Activity activ = GetActivitySelected();

			if (activ != null)
			{
				Frm_ActivitySubprocessRelationship frm = new Frm_ActivitySubprocessRelationship(activ, this);
				frm.ShowDialog();
			}
			else
			{
				MessageBox.Show("Nenhuma atividade selecionada.");
			}
		}
	}
}
