using MSCMD.Forms.Activities;
using MSCMD.Forms.Elements;
using MSCMD.Model;
using MSCMD.Repository;
using MSCMD.Utils;
using MSCMD.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MSCMD.Forms
{
	public partial class Frm_Element : Form
	{

		private static MscmdContext context;
		private ElementRepository _elementsRepository;
		private ElementElementRelationshipRepository _relElementsRepository;
		private ActivityElementRelationshipRepository _relActivitiesRepository;
		private SubsystemRepository _subsystemsRepository;
		private ElementSubsystemRepository _elementsubsystemRepository;
		private int filterGroupId = 0;
		private string sortColumnElement = "";
		private SortOrder? elementSortOrder;
		private DataGridViewColumnHeaderCell sortColumn;

		private string sortColumGroup = "";
		private SortOrder? groupSortOrder;
		private DataGridViewColumnHeaderCell sortColumnGroupHeader;

		private string errorMessageCellClick = "Erro ao acessar detalhes vinculados ao elemento selecionado.";
		private string saveElementTitle = "Salvar Elementos";
		private string errorMessageNotSelected = "Nenhum elemento selecionado.";
		public Frm_Element()
		{
			Configure();
			InitializeComponent();
		}

		private void Configure()
		{
			context = new MscmdContext();
			_elementsRepository = new ElementRepository(context);
			_relElementsRepository = new ElementElementRelationshipRepository(context);
			_relActivitiesRepository = new ActivityElementRelationshipRepository(context);
			_subsystemsRepository = new SubsystemRepository(context);
			_elementsubsystemRepository = new ElementSubsystemRepository();
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);
			context?.Dispose();
		}
		private void Frm_Element_Load(object sender, EventArgs e)
		{
			loadSubsystem();
			refresh_Elements();
		}

		public void loadSubsystem()
		{
			var list = _subsystemsRepository.ListAll().ToList();
			this.subsystemBindingSource.DataSource = list;

			if (sortColumGroup != "")
			{
				SortOrder order = (SortOrder)(groupSortOrder != null ? groupSortOrder : SortOrder.Ascending);
				SortSubsystem(sortColumGroup, order);
				sortColumnGroupHeader.SortGlyphDirection = order;
			}
		}

		public void LoadSubsystemsRelated(int elementId)
		{
			try
			{
				List<ElementSubsystem> relList = _elementsubsystemRepository.GetByElement(elementId).ToList();
				if (relList != null && relList.Count > 0)
				{
					subsystemBindingSource1.DataSource = relList.Select(r => r.Subsystem).ToList();
				}
				else
				{
					subsystemBindingSource1.DataSource = null;
				}

			}
			catch
			{
				MessageBox.Show("Erro ao acessar subsistema vinculado ao elemento.");
			}
		}

		private void btn_ImportElementos_Click(object sender, EventArgs e)
		{
			if (filterGroupId != 0)
			{
				Subsystem group = GetSubsystemSelected();

				Frm_ImportCsv form = new Frm_ImportCsv(ScreenEnum.Element, this, group, context);
				form.ShowDialog();
			}
			else
			{


				Frm_ImportCsv form = new Frm_ImportCsv(ScreenEnum.Element, this, null, context);
				form.ShowDialog();
			}

		}


		private void dg_Elementos_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				refresh_ElementDetails();

			}
			catch
			{
				MessageBox.Show(errorMessageCellClick);
			}
		}

		private void btn_SalvarElementos_Click(object sender, EventArgs e)
		{
			if (dg_Elementos.DataSource != null)
			{
				var wms = dg_Elementos.DataSource;
				BindingSource bs = dg_Elementos.DataSource as BindingSource;
				if (bs.DataSource != null)
				{
					List<Model.Element> elems = bs.DataSource as List<Model.Element>;
					if (elems.Where(el => el.Name == "" || el.Name == null).Any())
					{
						MessageBox.Show("O nome do elemento não pode ser vazio.", saveElementTitle, MessageBoxButtons.OK);
					}
					else
					{
						_elementsRepository.SaveList(elems);
						refresh_ElementDetails();
						MessageBox.Show("Alterações salvas com sucesso.", saveElementTitle, MessageBoxButtons.OK);
					}
				}
				else
				{
					MessageBox.Show("Não há itens a serem salvos.", saveElementTitle, MessageBoxButtons.OK);
				}



			}
			else
			{
				MessageBox.Show("Não há itens a serem salvos.", saveElementTitle, MessageBoxButtons.OK);
			}
		}



		private void btn_VincElemento_Click(object sender, EventArgs e)
		{

			Model.Element ele = GetElementoSelected();

			if (ele != null)
			{
				Frm_ElementElementRelationship frm = new Frm_ElementElementRelationship(ele, this);
				frm.ShowDialog();
			}
			else
			{
				MessageBox.Show(errorMessageNotSelected);
			}

		}

		private void btn_DesvincElemento_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (dg_RelacaoElemento.SelectedRows.Count > 0)
			{
				DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja deletar as relações? Total: " + dg_RelacaoElemento.SelectedRows.Count, "Deletar Relação Atividade Atividade", MessageBoxButtons.YesNo);

				if (dialogResult == DialogResult.Yes)
				{
					foreach (DataGridViewRow row in dg_RelacaoElemento.SelectedRows)
					{
						int relationshipId = (int)row.Cells[0].Value;

						if (relationshipId != 0)
						{
							try
							{
								ElementElementRelationship rel = _relElementsRepository.GetById(relationshipId);

								if (rel.Relation == ElementRelationEnum.seconecta)
								{
									ElementElementRelationship rel2 = _relElementsRepository.GetByReferenceIdAndReferredId(rel.ReferredComponentId, rel.ReferenceComponentId);
									if (rel2 != null)
									{
										_relElementsRepository.DeleteById(rel2.RelationshipId);
									}
								}
								_relElementsRepository.DeleteById(rel.RelationshipId);
							}
							catch
							{
								MessageBox.Show("Erro ao deletar item.");
							}
						}
					}
					GetElementsRelated(GetElementoSelected().ElementId);
				}
			}
			Cursor.Current = Cursors.Default;
		}

		private void btn_VincAtividade_Click(object sender, EventArgs e)
		{
			Model.Element ele = GetElementoSelected();

			if (ele != null)
			{
				Frm_ElementActivityRelationship frm = new Frm_ElementActivityRelationship(ele, this);
				frm.ShowDialog();
			}
			else
			{
				MessageBox.Show(errorMessageNotSelected);
			}
		}

		private void btn_DesvincAtividade_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (dg_RelacaoAtividade.SelectedRows.Count > 0)
			{
				DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja deletar as relações? Total: " + dg_RelacaoAtividade.SelectedRows.Count, "Deletar Relação Elemento x Atividade", MessageBoxButtons.YesNo);

				if (dialogResult == DialogResult.Yes)
				{
					foreach (DataGridViewRow row in dg_RelacaoAtividade.SelectedRows)
					{
						int relationshipId = (int)row.Cells[0].Value;

						if (relationshipId != 0)
						{
							try
							{
								_relActivitiesRepository.DeleteById(relationshipId);

							}
							catch
							{
								MessageBox.Show("Erro ao deletar item.");
							}
						}
					}
					GetActivitiesRelated(GetElementoSelected().ElementId);
				}
			}
			Cursor.Current = Cursors.Default;
		}


		private void btn_SalvarDetalhes_Click(object sender, EventArgs e)
		{
			SaveDescription();

		}


		private void SaveDescription()
		{
			Element ele = GetElementoSelected();
			if (ele != null)
			{
				ele.ComponentClass = rtbox_objectClass.Text;
				ele.ExternalIdentifier = rtbox_ExternalId.Text;
				ele.Type = rtbox_Type.Text;
				ele.SurfaceType = rtbox_SType.Text;

				_elementsRepository.Save(ele);

				refresh_ElementDetails();
			}
		}

		private void btn_DeleteElementoSelecao_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (dg_Elementos.SelectedRows.Count > 0)
			{
				DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja deletar os elementos selecionados? Total: " + dg_Elementos.SelectedRows.Count + ". Esta operação não poderá ser desfeita", "Deletar Elementos", MessageBoxButtons.YesNoCancel);
				if (dialogResult == DialogResult.Yes)
				{
					foreach (DataGridViewRow row in dg_Elementos.SelectedRows)
					{
						var id = row.Cells[0].Value;
						if (id != null && (int)id != 0)
						{
							try
							{
								Element elem = _elementsRepository.FindBy((int)id);
								_elementsRepository.Delete(elem);
							}
							catch
							{
								MessageBox.Show("Erro ao deletar item.");
							}

						}
					}
					refresh_Elements();
				}
			}
			else
			{
				MessageBox.Show(errorMessageNotSelected);
			}
			Cursor.Current = Cursors.Default;
		}

		private Element GetElementoSelected()
		{
			context.ChangeTracker.DetectChanges();
			if (dg_Elementos.SelectedRows.Count > 0)
			{
				DataGridViewRow row = dg_Elementos.SelectedRows[0];
				var rowValue = row.Cells[0].Value;

				if (rowValue != null && (int)rowValue != 0)
				{
					int idElemento = (int)rowValue;

					Model.Element element = _elementsRepository.FindBy(idElemento);
					return element;


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

		private void LoadElementSelectedData()
		{
			Model.Element ele = GetElementoSelected();
			if (ele != null)
			{
				rtbox_objectClass.Text = ele.ComponentClass;
				rtbox_ExternalId.Text = ele.ExternalIdentifier;
				rtbox_Type.Text = ele.Type;
				rtbox_SType.Text = ele.SurfaceType;

			}
		}

		private void GetElementsRelated(int idElemento)
		{
			try
			{
				List<ElementElementRelationship> relacoes = _relElementsRepository.GetByReferenceComponentId(idElemento).ToList();

				List<RelationshipViewModel> rel = relacoes.Select(r => new RelationshipViewModel
				{
					RelationshipId = r.RelationshipId,
					Relationship = Utility.GetEnumDescription(r.Relation),
					Code = r.ReferredComponent.Code ?? "",
					Name = r.ReferredComponent.Name
				}).ToList();

				dg_RelacaoElemento.DataSource = rel;

			}
			catch
			{
				MessageBox.Show("Erro ao acessar elementos vinculados ao elemento.");
			}
		}

		private void GetActivitiesRelated(int idElemento)
		{
			try
			{

				List<ActivityElementRelationship> relacoes = _relActivitiesRepository.GetByElement(idElemento).ToList();

				List<RelationshipViewModel> rel = relacoes.Select(r => new RelationshipViewModel
				{
					RelationshipId = r.RelationshipId,
					Relationship = Utility.GetEnumDescription(r.Relation),
					Code = r.Activity.ActivityCode ?? "",
					Name = r.Activity.ActivityName
				}).ToList();

				dg_RelacaoAtividade.DataSource = rel;
			}
			catch
			{
				MessageBox.Show("Erro ao acessar atividades vinculadas ao elemento.");
			}
		}

		private void LoadSectorRelated(int idElement)
		{
			try
			{
				Element element = GetElementoSelected();

				if (element != null)
				{
					if (element.OcupiedBy != null)
					{
						List<Organization> list = new List<Organization>
						{
							element.OcupiedBy
						};
						organizationBindingSource.DataSource = list;
					}
					else
					{
						organizationBindingSource.DataSource = null;

					}
				}
				else
				{
					organizationBindingSource.DataSource = null;

				}


			}
			catch
			{
				MessageBox.Show("Erro ao acessar atividades vinculadas ao elemento.");
			}
		}

		private Subsystem GetSubsystemSelected()
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
						Subsystem subsystems = _subsystemsRepository.FindBy(id);
						return subsystems;
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

		public void refresh_Elements(bool refreshDetails = true)
		{
			context.ChangeTracker.DetectChanges();

			if (filterGroupId != 0)
			{
				var subsystemEl = _elementsubsystemRepository.GetBySubsystem(filterGroupId).Select(x => x.Element);
				if (subsystemEl != null)
				{
					List<Element> list = subsystemEl.ToList();
					elementBindingSource.DataSource = list;
					lbl_ElementsTotal.Text = "Total:" + list.Count.ToString();
				}
			}
			else
			{
				List<Element> list = _elementsRepository.ListAll().ToList();
				elementBindingSource.DataSource = list;
				lbl_ElementsTotal.Text = "Total:" + list.Count.ToString();
			}

			if (sortColumnElement != "")
			{
				SortOrder order = (SortOrder)(elementSortOrder != null ? elementSortOrder : SortOrder.Ascending);
				SortElement(sortColumnElement, order);
				sortColumn.SortGlyphDirection = order;
			}


			if (refreshDetails)
				refresh_ElementDetails();

		}

		public void refresh_ElementDetails()
		{
			try
			{
				Element element = GetElementoSelected();

				if (element != null)
				{
					int elementId = element.ElementId;
					lbl_NomeElemento.Text = element.Name;

					LoadSectorRelated(elementId);
					GetElementsRelated(elementId);
					GetActivitiesRelated(elementId);
					LoadSubsystemsRelated(elementId);
					LoadElementSelectedData();
					EnableDetailsButtons();

					dg_Organization.ClearSelection();
					dg_Organization.CurrentCell = null;
					dg_RelacaoAtividade.ClearSelection();
					dg_RelacaoAtividade.CurrentCell = null;
					dg_RelacaoElemento.ClearSelection();
					dg_RelacaoElemento.CurrentCell = null;
					dataGridView1.ClearSelection();
					dataGridView1.CurrentCell = null;
				}
				else
				{
					lbl_NomeElemento.Text = null;
					rtbox_objectClass.Text = null;
					rtbox_ExternalId.Text = null;
					rtbox_Type.Text = null;
					rtbox_SType.Text = null;
					organizationBindingSource.DataSource = null;
					dg_RelacaoAtividade.DataSource = null;
					dg_RelacaoElemento.DataSource = null;

					DisableDetailsButtons();

				}
			}
			catch
			{
				MessageBox.Show("Erro ao acessar detalhes vinculados à função selecionada.");
			}
		}

		private void DisableDetailsButtons()
		{
			rtbox_objectClass.Enabled = false;
			rtbox_ExternalId.Enabled = false;
			rtbox_Type.Enabled = false;
			rtbox_SType.Enabled = false;
			btn_DesvincAtividade.Enabled = false;
			btn_DesvincElemento.Enabled = false;
			btn_SetOrganization.Enabled = false;
			btn_VincAtividade.Enabled = false;
			btn_VincElemento.Enabled = false;
		}

		private void EnableDetailsButtons()
		{
			rtbox_objectClass.Enabled = true;
			rtbox_ExternalId.Enabled = true;
			rtbox_Type.Enabled = true;
			rtbox_SType.Enabled = true;
			btn_DesvincAtividade.Enabled = true;
			btn_DesvincElemento.Enabled = true;
			btn_SetOrganization.Enabled = true;
			btn_VincAtividade.Enabled = true;
			btn_VincElemento.Enabled = true;
		}


		private void btn_SetOrganization_Click(object sender, EventArgs e)
		{
			Model.Element ele = GetElementoSelected();

			if (ele != null)
			{
				Frm_ElementOrganizationRelationship frm = new Frm_ElementOrganizationRelationship(ele, this);
				frm.ShowDialog();
			}
			else
			{
				MessageBox.Show(errorMessageNotSelected);
			}
		}

		private void btn_ShowAllElements_Click(object sender, EventArgs e)
		{
			lbl_SectorFilter.Text = "Todos";
			filterGroupId = 0;
			refresh_Elements();

		}

		private void btn_FilterElements_Click(object sender, EventArgs e)
		{
			Subsystem subsystem = GetSubsystemSelected();
			if (subsystem != null)
			{

				List<Element> list = _elementsubsystemRepository.GetBySubsystem(subsystem.SubsystemId).Select(x => x.Element).ToList();
				elementBindingSource.DataSource = list;
				lbl_ElementsTotal.Text = "Total:" + list.Count.ToString();
				refresh_ElementDetails();

				lbl_SectorFilter.Text = subsystem.Name;
				filterGroupId = subsystem.SubsystemId;

			}
			else
			{
				MessageBox.Show("Nenhum subsistema selecinado.");
			}
		}

		private void btn_ManageSubsystems_Click(object sender, EventArgs e)
		{
			Frm_Subsystem frm = new Frm_Subsystem(this, context);
			frm.ShowDialog();
		}

		private void dg_Elementos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			var rowVal = e.RowIndex;
			var row = dg_Elementos.Rows[rowVal];
			var ind = row.Cells[0].Value;


			if (ind != null)
			{
				int index = (int)ind;
				Element el = new Element();

				if (index != 0)
				{
					el = _elementsRepository.FindBy(index);
				}

				var name = row.Cells[2].Value;
				if (name != null)
				{
					string agentName = (string)name;
					if (agentName != "")
					{
						el.Name = agentName;
						el.Code = (string)row.Cells[1].Value;

						_elementsRepository.Save(el);

						if (filterGroupId != 0)
						{
							ElementSubsystem rel = new ElementSubsystem
							{
								ElementId = el.ElementId,
								SubsystemId = filterGroupId
							};
							_elementsubsystemRepository.AddNew(rel);

						}
						refresh_Elements(false);
					}
					else if ((string)dg_Elementos.Columns[e.ColumnIndex].DataPropertyName == "Name")
					{
						MessageBox.Show("Nome do elemento não pode ser vazio.");
					}
				}
				else if ((string)dg_Elementos.Columns[e.ColumnIndex].DataPropertyName == "Name")
				{
					MessageBox.Show("Nome do elemento não pode ser vazio.");
				}

			}
		}

		#region Sort 

		private void dg_Elementos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			DataGridView grid = (DataGridView)sender;
			if (elementSortOrder == null || elementSortOrder == SortOrder.Descending)
			{

				SortElement(grid.Columns[e.ColumnIndex].DataPropertyName, SortOrder.Ascending);
				grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
				elementSortOrder = SortOrder.Ascending;
			}
			else
			{
				SortElement(grid.Columns[e.ColumnIndex].DataPropertyName, SortOrder.Descending);
				grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
				elementSortOrder = SortOrder.Descending;
			}
			sortColumnElement = grid.Columns[e.ColumnIndex].DataPropertyName;
			sortColumn = grid.Columns[e.ColumnIndex].HeaderCell;
		}

		private void dg_Group_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			//DataGridView grid = (DataGridView)sender;
			//SortSubsystem(grid.Columns[e.ColumnIndex].DataPropertyName, SortOrder.Ascending);
			//grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;

			DataGridView grid = (DataGridView)sender;
			if (groupSortOrder == null || groupSortOrder == SortOrder.Descending)
			{

				SortSubsystem(grid.Columns[e.ColumnIndex].DataPropertyName, SortOrder.Ascending);
				grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
				groupSortOrder = SortOrder.Ascending;
			}
			else
			{
				SortSubsystem(grid.Columns[e.ColumnIndex].DataPropertyName, SortOrder.Descending);
				grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
				groupSortOrder = SortOrder.Descending;
			}
			sortColumGroup = grid.Columns[e.ColumnIndex].DataPropertyName;
			sortColumnGroupHeader = grid.Columns[e.ColumnIndex].HeaderCell;

		}
		private void SortElement(string column, SortOrder sortOrder)
		{
			List<Element> list = new List<Element>();


			if (filterGroupId != 0)
			{
				list = _elementsubsystemRepository.GetBySubsystem(filterGroupId).Select(r => r.Element).ToList();

			}
			else
			{
				list = _elementsRepository.ListAll().ToList();

			}

			switch (column)
			{
				case "Code":
					{
						if (sortOrder == SortOrder.Ascending)
						{
							elementBindingSource.DataSource = list.OrderBy(x => x.Code).ToList();
						}
						else
						{
							elementBindingSource.DataSource = list.OrderByDescending(x => x.Code).ToList();
						}
						break;
					}
				case "Name":
					{
						if (sortOrder == SortOrder.Ascending)
						{
							elementBindingSource.DataSource = list.OrderBy(x => x.Name).ToList();
						}
						else
						{
							elementBindingSource.DataSource = list.OrderByDescending(x => x.Name).ToList();
						}
						break;
					}
				case "ElementId":
					{
						if (sortOrder == SortOrder.Ascending)
						{
							elementBindingSource.DataSource = list.OrderBy(x => x.ElementId).ToList();
						}
						else
						{
							elementBindingSource.DataSource = list.OrderByDescending(x => x.ElementId).ToList();
						}
						break;
					}

			}
			refresh_ElementDetails();

		}

		private void SortSubsystem(string column, SortOrder sortOrder)
		{
			List<Subsystem> list = _subsystemsRepository.ListAll().ToList();

			switch (column)
			{
				case "Code":
					{
						if (sortOrder == SortOrder.Ascending)
						{
							subsystemBindingSource.DataSource = list.OrderBy(x => x.Code).ToList();
						}
						else
						{
							subsystemBindingSource.DataSource = list.OrderByDescending(x => x.Code).ToList();
						}
						break;
					}
				case "Name":
					{
						if (sortOrder == SortOrder.Ascending)
						{
							subsystemBindingSource.DataSource = list.OrderBy(x => x.Name).ToList();
						}
						else
						{
							subsystemBindingSource.DataSource = list.OrderByDescending(x => x.Name).ToList();
						}
						break;
					}
				case "SubsystemId":
					{
						if (sortOrder == SortOrder.Ascending)
						{
							subsystemBindingSource.DataSource = list.OrderBy(x => x.SubsystemId).ToList();
						}
						else
						{
							subsystemBindingSource.DataSource = list.OrderByDescending(x => x.SubsystemId).ToList();
						}
						break;
					}

			}

		}

		#endregion

		private void rtbox_objectClass_Leave(object sender, EventArgs e)
		{
			SaveDescription();
		}

		private void rtbox_ExternalId_Leave(object sender, EventArgs e)
		{
			SaveDescription();
		}

		private void rtbox_SType_Leave(object sender, EventArgs e)
		{
			SaveDescription();
		}

		private void rtbox_Type_Leave(object sender, EventArgs e)
		{
			SaveDescription();
		}

		private void dg_Group_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			var rowVal = e.RowIndex;
			var row = dg_Group.Rows[rowVal];
			var ind = row.Cells[0].Value;


			if (ind != null)
			{
				int index = (int)ind;
				Subsystem subsystem = new Subsystem();

				if (index != 0)
				{
					subsystem = _subsystemsRepository.FindBy(index);
				}

				var name = row.Cells[2].Value;
				if (name != null)
				{
					string sName = (string)name;
					if (sName != "")
					{
						subsystem.Name = sName;
						subsystem.Code = (string)row.Cells[1].Value;

						_subsystemsRepository.Save(subsystem);

						loadSubsystem();
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

		private void btn_DelSubsystem_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (dg_Group.SelectedRows.Count > 0)
			{
				DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja deletar os subsistemas selecionados? Total: " + dg_Group.SelectedRows.Count + ". Esta operação não poderá ser desfeita. Obs: Os elementos do subsistema não serão deletados, apenas desvinculados.", "Deletar Subsistema", MessageBoxButtons.YesNoCancel);
				if (dialogResult == DialogResult.Yes)
				{
					try
					{
						foreach (DataGridViewRow row in dg_Group.SelectedRows)
						{
							var id = row.Cells[0].Value;
							if (id != null && (int)id != 0)
							{

								Subsystem subsystem = _subsystemsRepository.FindBy((int)id);
								_subsystemsRepository.Delete(subsystem);

								if (filterGroupId == (int)id)
								{
									filterGroupId = 0;
									lbl_SectorFilter.Text = "TODOS";
								}
							}
						}
					}
					catch
					{
						MessageBox.Show("Erro ao deletar.");
					}

					loadSubsystem();
					refresh_Elements();
				}
			}
			else
			{
				MessageBox.Show("Nenhum subsistema selecionado.");
			}
			Cursor.Current = Cursors.Default;

		}

		private void dg_Elementos_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			refresh_ElementDetails();
		}

		private void btn_ImportElementRelationship_Click(object sender, EventArgs e)
		{
			Frm_ImportCsv form = new Frm_ImportCsv(Model.ScreenEnum.ElementRelationship, this);
			form.ShowDialog();
		}

		private void btn_ImportElementActivityRelationship_Click(object sender, EventArgs e)
		{
			Frm_ImportCsv form = new Frm_ImportCsv(Model.ScreenEnum.ElementActivityRelationship, this);
			form.ShowDialog();
		}

		private void dg_Elementos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.ColumnIndex == 0)
				if (dg_Elementos[e.ColumnIndex, e.RowIndex].ReadOnly)
					e.CellStyle.BackColor = Color.LightGray;
		}

		private void btn_ImportSectors_Click(object sender, EventArgs e)
		{
			Frm_ImportCsv form = new Frm_ImportCsv(ScreenEnum.Subsystem, this, null, context);
			form.ShowDialog();
		}

		private void btn_ExportSubsystem_Click(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					try
					{
						List<Subsystem> list = (List<Subsystem>)subsystemBindingSource.DataSource;

						string fileName = "subsistema.csv";
						string destFile = Path.Combine(fbd.SelectedPath, fileName);

						WriteCustomCSV.SubsystemToCSV(list, destFile);

					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Aviso");
					}
				}
			}
		}

		private void btn_ExportElements_Click(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					try
					{
						List<Element> list = (List<Element>)elementBindingSource.DataSource;

						string fileName = "elemento";
						if (filterGroupId != 0)
						{
							fileName += "_S" + filterGroupId.ToString();
						}
						fileName += ".csv";

						string destFile = Path.Combine(fbd.SelectedPath, fileName);

						WriteCustomCSV.ElementsToCSV(list, destFile);

					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Aviso");
					}
				}
			}
		}

		private void btn_ExportElementElement_Click(object sender, EventArgs e)
		{
			Element element = GetElementoSelected();
			if (element != null)
			{
				using (var fbd = new FolderBrowserDialog())
				{
					DialogResult result = fbd.ShowDialog();

					if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
					{
						try
						{
							List<ElementElementRelationship> relations = _relElementsRepository.GetByReferenceComponentId(element.ElementId).ToList();
							string fileName = "relacoes_ElementoxElemento_E" + element.ElementId + ".csv";
							string destFile = Path.Combine(fbd.SelectedPath, fileName);
							WriteCustomCSV.RelElementxElementToCSV(relations, destFile);

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
				MessageBox.Show("Nenhum elemento selecionado.", "Aviso");
			}
		}

		private void btn_ExportElementActivity_Click(object sender, EventArgs e)
		{
			Element element = GetElementoSelected();
			if (element != null)
			{
				using (var fbd = new FolderBrowserDialog())
				{
					DialogResult result = fbd.ShowDialog();

					if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
					{
						try
						{
							List<ActivityElementRelationship> relations = _relActivitiesRepository.GetByElement(element.ElementId).ToList();
							string fileName = "relacoes_AtividadexElemento_E" + element.ElementId + ".csv";
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
				MessageBox.Show("Nenhum elemento selecionado.", "Aviso");
			}
		}

		private void btn_DeleteRelSubsystem_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (dataGridView1.SelectedRows.Count > 0)
			{
				DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja deletar as relações? Total: " + dataGridView1.SelectedRows.Count, "Desvincular Subsistemas", MessageBoxButtons.YesNo);

				if (dialogResult == DialogResult.Yes)
				{
					foreach (DataGridViewRow row in dataGridView1.SelectedRows)
					{
						var relationshipId = row.Cells[0].Value;

						if (relationshipId != null && (int)relationshipId != 0)
						{
							try
							{
								Element el = GetElementoSelected();

								ElementSubsystem rel = _elementsubsystemRepository.GetByElementSubsystem((int)relationshipId, el.ElementId);

								if (rel != null && el != null)
								{
									_elementsubsystemRepository.Delete(rel);

								}
							}
							catch
							{
								MessageBox.Show("Erro ao deletar item.");
							}
						}
					}
					refresh_Elements();
				}
			}
			Cursor.Current = Cursors.Default;
		}

		private void button1_Click(object sender, EventArgs e)
		{

			Model.Element ele = GetElementoSelected();

			if (ele != null)
			{
				Frm_ElementSubsystemRelationship frm = new Frm_ElementSubsystemRelationship(ele, this);
				frm.ShowDialog();
			}
			else
			{
				MessageBox.Show(errorMessageNotSelected);
			}
		}

		private void btn_New_Click(object sender, EventArgs e)
		{
			this.BeginInvoke(new Action(() =>
			{
				dg_Elementos.CurrentCell = dg_Elementos.Rows[dg_Elementos.NewRowIndex].Cells[2];
				dg_Elementos.BeginEdit(true);
			}));
		}

		private void btn_NewGroup_Click(object sender, EventArgs e)
		{
			this.BeginInvoke(new Action(() =>
			{
				dg_Group.CurrentCell = dg_Group.Rows[dg_Group.NewRowIndex].Cells[2];
				dg_Group.BeginEdit(true);
			}));
		}

		private void dg_Group_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.ColumnIndex == 0)
				if (dg_Group[e.ColumnIndex, e.RowIndex].ReadOnly)
					e.CellStyle.BackColor = Color.LightGray;
		}
	}
}
