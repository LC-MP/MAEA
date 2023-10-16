using Microsoft.Extensions.Logging;
using MSCMD.Forms;
using MSCMD.Forms.Elements;
using MSCMD.Forms.OrganizationalDivision;
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
using System.Formats.Tar;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace MSCMD
{
	public partial class Frm_Organization : Form
	{
		private static MscmdContext context;
		private AgentRepository _agentsRepository;
		private OrganizationRepository _sectorsRepository;
		private AgentResourceRelationshipRepository _resourceRelRepository;
		private AgentActivityRelationshipRepository _activityRelRepository;
		private OrganizationAgentRepository _organizationAgentRepository;
		private AgentSubordinationRepository _subordinationAgentRepository;
		private int filterSectorId = 0;

		private string sortColumnAgents = "";
		private SortOrder? agentSortOrder;
		private DataGridViewColumnHeaderCell sortColumn;

		private string sortColumGroup = "";
		private SortOrder? groupSortOrder;
		private DataGridViewColumnHeaderCell sortColumnGroupHeader;

		public List<Agent> lstAgents = new List<Agent>();
		public Frm_Organization()
		{
			Configure();
			InitializeComponent();
		}

		private void Configure()
		{
			context = new MscmdContext();
			_agentsRepository = new AgentRepository(context);
			_sectorsRepository = new OrganizationRepository(context);
			_resourceRelRepository = new AgentResourceRelationshipRepository(context);
			_activityRelRepository = new AgentActivityRelationshipRepository(context);
			_organizationAgentRepository = new OrganizationAgentRepository();
			_subordinationAgentRepository = new AgentSubordinationRepository(context);
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);
			context?.Dispose();
		}

		private void Frm_Organization_Load(object sender, EventArgs e)
		{
			context.Database.EnsureCreated();
			refresh_Agents();
			load_Sectors();
		}


		private void btn_Import_Click(object sender, EventArgs e)
		{
			if (filterSectorId != 0)
			{
				Organization org = GetSectorSelected();
				Frm_ImportCsv form = new Frm_ImportCsv(Model.ScreenEnum.Agent, this, org);
				form.ShowDialog();
			}
			else
			{

				Frm_ImportCsv form = new Frm_ImportCsv(Model.ScreenEnum.Agent, this);
				form.ShowDialog();
			}

		}

		private void dataGridViewFuncoes_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			refresh_AgentDetails();
		}

		#region EditAgents
		private void btn_SaveAgents_Click(object sender, EventArgs e)
		{
			//if (dg_Agents.DataSource != null)
			//{
			//	var wms = dg_Agents.DataSource;
			//	BindingSource bs = dg_Agents.DataSource as BindingSource;
			//	if (bs.DataSource != null)
			//	{
			//		List<Agent> agents = bs.DataSource as List<Agent>;
			//		if (agents.Where(a => a.Name == "" || a.Name == null).Any())
			//		{
			//			MessageBox.Show("O nome da função não pode ser vazio.", "Salvar Funções", MessageBoxButtons.OK);
			//		}
			//		else
			//		{
			//			_agentsRepository.SalveList(agents);
			//			refresh_AgentDetails();
			//			MessageBox.Show("Alterações salvas com sucesso.", "Salvar Funções", MessageBoxButtons.OK);
			//		}
			//	}
			//	else
			//	{
			//		MessageBox.Show("Não há itens a serem salvos.", "Salvar Funções", MessageBoxButtons.OK);
			//	}
			//}
			//else
			//{
			//	MessageBox.Show("Não há itens a serem salvos.", "Salvar Funções", MessageBoxButtons.OK);
			//}
		}
		private void btn_DeleteAgent_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			if (dg_Agents.SelectedRows.Count > 0)
			{
				DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja deletar as funções selecionadas? Total: " + dg_Agents.SelectedRows.Count + ". Esta operação não poderá ser desfeita", "Deletar Funções", MessageBoxButtons.YesNoCancel);
				if (dialogResult == DialogResult.Yes)
				{
					foreach (DataGridViewRow row in dg_Agents.SelectedRows)
					{
						var id = row.Cells[0].Value;
						if (id != null && (int)id != 0)
						{
							try
							{
								Agent agent = _agentsRepository.FindBy((int)id);
								_agentsRepository.Delete(agent);
							}
							catch
							{
								MessageBox.Show("Erro ao deletar item.");
							}

						}
					}
					refresh_Agents();
				}
			}
			else
			{
				MessageBox.Show("Nenhuma função selecionada.");
			}
			Cursor.Current = Cursors.Default;
		}
		private void btn_DeleteSector_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (dg_Sectors.SelectedRows.Count > 0)
			{
				DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja deletar as divisões orgnizacionais selecionadas? Total: " + dg_Sectors.SelectedRows.Count + ". Esta operação não poderá ser desfeita. Obs: As funções da divisão não serão deletadas, apenas desvinculadas.", "Deletar Divisão Organizacional", MessageBoxButtons.YesNoCancel);
				if (dialogResult == DialogResult.Yes)
				{
					try
					{
						foreach (DataGridViewRow row in dg_Sectors.SelectedRows)
						{
							var id = row.Cells[0].Value;
							if (id != null && (int)id != 0)
							{

								Organization organization = _sectorsRepository.FindBy((int)id);
								_sectorsRepository.Delete(organization);

								if (filterSectorId == (int)id)
								{
									filterSectorId = 0;
									lbl_SectorFilter.Text = "TODAS";
								}
							}
						}
					}
					catch
					{
						MessageBox.Show("Erro ao deletar.");
					}

					load_Sectors();
					refresh_Agents();
				}
			}
			else
			{
				MessageBox.Show("Nenhuma Divisão Organizacional selecionada.");
			}
			Cursor.Current = Cursors.Default;

			//Cursor.Current = Cursors.WaitCursor;
			//Organization sector = GetSectorSelected();
			//if (sector != null)
			//{
			//	DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja deletar o setor " + sector.SectorName + "?", "Deletar Divisão Organizacional", MessageBoxButtons.YesNo);

			//	if (dialogResult == DialogResult.Yes)
			//	{
			//		int sectorId = sector.SectorId;

			//		_sectorsRepository.Delete(sector);
			//		MessageBox.Show("Setor deletado com sucesso.");
			//		load_Sectors();
			//		if (filterSectorId == sectorId)
			//		{
			//			filterSectorId = 0;
			//			refresh_Agents();
			//			lbl_SectorFilter.Text = "TODAS";
			//		}
			//	}
			//}
			//else
			//{
			//	MessageBox.Show("Nenhum setor selecionado.");
			//}
			//Cursor.Current = Cursors.Default;
		}
		private void dg_Agents_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			var rowVal = e.RowIndex;
			var row = dg_Agents.Rows[rowVal];
			var ind = row.Cells[0].Value;


			if (ind != null)
			{
				int index = (int)ind;
				Agent agent = new Agent();

				if (index != 0)
				{
					agent = _agentsRepository.FindBy(index);
				}

				var name = row.Cells[2].Value;
				if (name != null)
				{
					string agentName = (string)name;
					if (agentName != "")
					{
						agent.Name = agentName;
						agent.Code = (string)row.Cells[1].Value;

						_agentsRepository.Save(agent);

						if (filterSectorId != 0)
						{
							OrganizationAgent rel = new OrganizationAgent
							{
								AgentId = agent.AgentId,
								OrganizationId = filterSectorId
							};
							_organizationAgentRepository.AddNew(rel);
						}

						refresh_Agents(false);
					}
					else if ((string)dg_Agents.Columns[e.ColumnIndex].DataPropertyName == "Name")
					{
						MessageBox.Show("Nome da função não pode ser vazio.");
					}
				}
				else if ((string)dg_Agents.Columns[e.ColumnIndex].DataPropertyName == "Name")
				{
					MessageBox.Show("Nome da função não pode ser vazio.");
				}

			}

		}

		#endregion

		#region Relationships

		private void btn_NewResource_Click(object sender, EventArgs e)
		{
			if (dg_Agents.SelectedRows.Count > 0)
			{
				Agent agent = GetAgentSelected();

				if (agent != null)
				{
					Frm_AgentResourceRelationship formV = new Frm_AgentResourceRelationship(agent, this);
					formV.ShowDialog();
				}
				else
				{
					MessageBox.Show("Selecione uma função para então vincular a uma pessoa.");
				}
			}
			else
			{
				MessageBox.Show("Selecione uma função para então vincular a uma pessoa.");
			}
		}
		private void btn_NewActivity_Click(object sender, EventArgs e)
		{
			if (dg_Agents.SelectedRows.Count > 0)
			{
				Agent agent = GetAgentSelected();

				if (agent != null)
				{
					Frm_AgentActivityRelationship formV = new Frm_AgentActivityRelationship(agent, this);
					formV.ShowDialog();
				}
				else
				{
					MessageBox.Show("Selecione uma função para então vincular a uma pessoa.");
				}
			}
			else
			{
				MessageBox.Show("Selecione uma função para então vincular a uma pessoa.");
			}
		}
		private void btn_Del_Resource_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (dg_ResourceRelationship.SelectedRows.Count > 0)
			{
				DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja deletar as relações selecionadas? Total: " + dg_ResourceRelationship.SelectedRows.Count + ". Esta operação não poderá ser desfeita", "Deletar", MessageBoxButtons.YesNoCancel);
				if (dialogResult == DialogResult.Yes)
				{
					foreach (DataGridViewRow row in dg_ResourceRelationship.SelectedRows)
					{
						int id = (int)row.Cells[0].Value;
						if (id != 0)
						{
							try
							{
								_resourceRelRepository.DeleteById(id);

							}
							catch
							{
								MessageBox.Show("Erro ao deletar item.");
							}

						}
					}
					GetResourcesRelated(GetAgentSelected().AgentId);
				}
			}
			Cursor.Current = Cursors.Default;
		}
		private void btn_Del_Activity_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (dg_ActivityRelationship.SelectedRows.Count > 0)
			{
				DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja deletar as relações selecionadas? Total: " + dg_ActivityRelationship.SelectedRows.Count + ". Esta operação não poderá ser desfeita", "Deletar", MessageBoxButtons.YesNoCancel);
				if (dialogResult == DialogResult.Yes)
				{
					foreach (DataGridViewRow row in dg_ActivityRelationship.SelectedRows)
					{
						int id = (int)row.Cells[0].Value;
						if (id != 0)
						{
							try
							{
								_activityRelRepository.DeleteById(id);

							}
							catch
							{
								MessageBox.Show("Erro ao deletar item.");
							}

						}
					}
					GetActivitiesRelated(GetAgentSelected().AgentId);
				}
			}
			Cursor.Current = Cursors.Default;
		}

		#endregion

		#region LoadFunctions

		private Agent GetAgentSelected()
		{
			context.ChangeTracker.DetectChanges();
			if (dg_Agents.SelectedRows.Count > 0)
			{
				DataGridViewRow row = dg_Agents.SelectedRows[0];
				var rowValue = row.Cells[0].Value;
				if (rowValue != null && (int)rowValue != 0)
				{
					int idAgent = (int)rowValue;

					if (idAgent == 0)
					{
						string cod = (string)row.Cells[1].Value;
						string nome = (string)row.Cells[2].Value;

						if (!string.IsNullOrEmpty(nome))
						{
							Agent agent = new Agent()
							{
								Code = cod,
								Name = nome
							};

							_agentsRepository.AddNew(agent);

							Agent ag = _agentsRepository.FindBy(agent.AgentId);
							refresh_Agents();
							return ag;
						}
						else
						{
							return null;
						}

					}
					else
					{
						Agent ag = _agentsRepository.FindBy(idAgent);
						return ag;
					}
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
		private Organization GetSectorSelected()
		{
			if (dg_Sectors.SelectedRows.Count > 0)
			{
				DataGridViewRow row = dg_Sectors.SelectedRows[0];
				var rowValue = row.Cells[0].Value;
				if (rowValue != null)
				{
					int idSector = (int)rowValue;

					if (idSector == 0)
					{
						string cod = (string)row.Cells[2].Value;
						string nome = (string)row.Cells[1].Value;

						if (!string.IsNullOrEmpty(nome))
						{
							Organization sector = new Organization()
							{
								Code = cod,
								SectorName = nome
							};
							_sectorsRepository.AddNew(sector);

							Organization sec = _sectorsRepository.FindBy(sector.SectorId);
							load_Sectors();
							return sec;
						}
						else
						{
							return null;
						}

					}
					else
					{
						Organization sec = _sectorsRepository.FindBy(idSector);
						return sec;
					}
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

		private void GetResourcesRelated(int AgentId)
		{
			try
			{

				List<AgentResourceRelationship> relations = _resourceRelRepository.GetByAgent(AgentId).ToList();

				List<RelationshipViewModel> rel = relations.Select(r => new RelationshipViewModel
				{
					RelationshipId = r.RelationshipId,
					Code = r.Resource.Code ?? "",
					Name = r.Resource.Name
				}).ToList();

				dg_ResourceRelationship.DataSource = rel;
			}
			catch
			{
				MessageBox.Show("Erro ao acessar pessoas vinculadas a função.");
			}
		}

		private void GetActivitiesRelated(int AgentId)
		{
			try
			{

				List<AgentActivityRelationship> relations = _activityRelRepository.GetByAgentId(AgentId).ToList();

				List<RelationshipViewModel> rel = relations.Select(r => new RelationshipViewModel
				{
					RelationshipId = r.RelationshipId,
					Code = r.Activity.ActivityCode ?? "",
					Name = r.Activity.ActivityName
				}).ToList();

				dg_ActivityRelationship.DataSource = rel;
			}
			catch
			{
				MessageBox.Show("Erro ao acessar atividades vinculadas à função.");
			}
		}

		public void load_Sectors()
		{
			context.ChangeTracker.DetectChanges();

			var sectorList = _sectorsRepository.ListAll().ToList();
			this.organizationBindingSource.DataSource = sectorList;

			if (sortColumGroup != "")
			{
				SortOrder order = (SortOrder)(groupSortOrder != null ? groupSortOrder : SortOrder.Ascending);
				SortSectors(sortColumGroup, order);
				sortColumnGroupHeader.SortGlyphDirection = order;
			}
		}
		public void refresh_Agents(bool refreshDetails = true)
		{
			context.ChangeTracker.DetectChanges();

			if (filterSectorId != 0)
			{
				List<Agent> list = _organizationAgentRepository.GetByOrganization(filterSectorId).Select(r => r.Agent).ToList();
				agentBindingSource.DataSource = list;
				lbl_AgentsTotal.Text = "Total: " + list.Count.ToString();
			}
			else
			{
				var funcoesList = _agentsRepository.ListAll().ToList();

				this.agentBindingSource.DataSource = funcoesList;
				lbl_AgentsTotal.Text = "Total: " + funcoesList.Count.ToString();
			}

			if (sortColumnAgents != "")
			{
				SortOrder order = (SortOrder)(agentSortOrder != null ? agentSortOrder : SortOrder.Ascending);
				SortAgent(sortColumnAgents, order);
				sortColumn.SortGlyphDirection = order;
			}

			if (refreshDetails == true)
				refresh_AgentDetails();
		}

		public void refresh_AgentDetails()
		{
			try
			{
				Agent agent = GetAgentSelected();

				if (agent != null)
				{

					lbl_nomeFuncao.Text = agent.Name;

					GetResourcesRelated(agent.AgentId);
					GetActivitiesRelated(agent.AgentId);
					LoadSectorRelated(agent);
					LoadAgentRelated(agent);
					LoadAgentSelectedDescription(agent);
					EnableDetailsButtons();

					dg_ActivityRelationship.ClearSelection();
					dg_ActivityRelationship.CurrentCell = null;
					dg_ResourceRelationship.ClearSelection();
					dg_ResourceRelationship.CurrentCell = null;
					dataGridView2.ClearSelection();
					dataGridView2.CurrentCell = null;
					dataGridView3.ClearSelection();
					dataGridView3.CurrentCell = null;
				}
				else
				{
					lbl_nomeFuncao.Text = null;
					rtBox_Description.Text = null;
					agentBindingSource1.DataSource = null;
					humanResourceBindingSource.DataSource = null;
					organizationBindingSource1.DataSource = null;
					dg_ActivityRelationship.DataSource = null;
					dg_ResourceRelationship.DataSource = null;

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
			rtBox_Description.Enabled = false;
			btn_Del_Activity.Enabled = false;
			btn_Del_Resource.Enabled = false;
			btn_Del_Subordination.Enabled = false;
			btn_Del_OrgRelationship.Enabled = false;
			btn_NewActivity.Enabled = false;
			btn_nova_pessoa.Enabled = false;
			btn_SubordinationRelEdit.Enabled = false;
			btn_OrganizationRelEdit.Enabled = false;
		}

		private void EnableDetailsButtons()
		{
			rtBox_Description.Enabled = true;
			btn_Del_Activity.Enabled = true;
			btn_Del_Resource.Enabled = true;
			btn_Del_Subordination.Enabled = true;
			btn_Del_OrgRelationship.Enabled = true;
			btn_NewActivity.Enabled = true;
			btn_nova_pessoa.Enabled = true;
			btn_SubordinationRelEdit.Enabled = true;
			btn_OrganizationRelEdit.Enabled = true;
		}

		public void LoadSectorRelated(Agent agent)
		{
			try
			{
				List<OrganizationAgent> relList = _organizationAgentRepository.GetByAgent(agent.AgentId).ToList();
				if (relList != null && relList.Count > 0)
				{
					organizationBindingSource1.DataSource = relList.Select(r => r.Organization).ToList();
				}
				else
				{
					organizationBindingSource1.DataSource = null;
				}

			}
			catch
			{
				MessageBox.Show("Erro ao acessar setor vinculado à função.");
			}
		}

		public void LoadAgentRelated(Agent agent)
		{
			try
			{
				List<AgentSubordination> list = _subordinationAgentRepository.GetByAgent(agent.AgentId).ToList();

				if (list != null && list.Count > 0)
				{

					agentBindingSource1.DataSource = list.Select(r => r.FunctionalSubordination).OrderBy(x => x.Code);
				}
				else
				{
					agentBindingSource1.DataSource = null;
				}


			}
			catch
			{
				MessageBox.Show("Erro ao acessar a subordinação funcional.");
			}
		}

		private void LoadAgentSelectedDescription(Agent agent)
		{
			if (agent != null)
			{
				rtBox_Description.Text = agent.Description;
			}
		}

		public void refresh_Vinculo(int idAgent)
		{
			GetResourcesRelated(idAgent);
		}
		#endregion


		#region Details Section Actions
		private void btn_OrganizationRelEdit_Click(object sender, EventArgs e)
		{
			Agent agent = GetAgentSelected();

			if (agent != null)
			{
				Frm_AgentOrganizationtRelationship frm = new Frm_AgentOrganizationtRelationship(agent, this);
				frm.ShowDialog();
			}
			else
			{
				MessageBox.Show("Nenhuma função selecionada.");
			}
		}

		private void btn_SubordinationRelEdit_Click(object sender, EventArgs e)
		{
			Agent agent = GetAgentSelected();

			if (agent != null)
			{

				Frm_AgentAgentRelationship frm = new Frm_AgentAgentRelationship(agent, this);
				frm.ShowDialog();
			}
			else
			{
				MessageBox.Show("Nenhuma função selecionada.");
			}
		}

		private void btn_SaveDescription_Click(object sender, EventArgs e)
		{
			saveAgentDescription();
		}

		#endregion

		private void lbl_Titulo_Funcao_Click(object sender, EventArgs e)
		{

		}

		#region Sector Section Actions



		private void dg_Sectors_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			var rowVal = e.RowIndex;
			var row = dg_Sectors.Rows[rowVal];
			var ind = row.Cells[0].Value;


			if (ind != null)
			{
				int index = (int)ind;
				Organization org = new Organization();

				if (index != 0)
				{
					org = _sectorsRepository.FindBy(index);
				}
				org.Code = (string)row.Cells[1].Value;
				var name = row.Cells[2].Value;
				if (name != null)
				{
					string orgName = (string)name;
					if (orgName != "")
					{
						org.SectorName = orgName;

						_sectorsRepository.Save(org);
						load_Sectors();
					}
					else if ((string)dg_Sectors.Columns[e.ColumnIndex].DataPropertyName == "SectorName")
					{
						MessageBox.Show("O nome do setor não pode ser vazio.", "Salvar Divisão Organizacional", MessageBoxButtons.OK);
					}
				}
				else if ((string)dg_Agents.Columns[e.ColumnIndex].DataPropertyName == "SectorName")
				{
					MessageBox.Show("O nome do setor não pode ser vazio.", "Salvar Divisão Organizacional", MessageBoxButtons.OK);
				}
			}
		}
		private void btn_ImportSectors_Click(object sender, EventArgs e)
		{
			Frm_ImportCsv form = new Frm_ImportCsv(Model.ScreenEnum.Organization, this);
			form.ShowDialog();
		}

		private void btn_ShowAllAgents_Click(object sender, EventArgs e)
		{
			filterSectorId = 0;
			refresh_Agents();
			lbl_SectorFilter.Text = "TODAS";

		}

		private void btn_FilterAgents_Click(object sender, EventArgs e)
		{
			Organization org = GetSectorSelected();
			if (org != null)
			{

				List<Agent> list = _organizationAgentRepository.GetByOrganization(org.SectorId).Select(r => r.Agent).ToList();
				agentBindingSource.DataSource = list;
				lbl_AgentsTotal.Text = "Total: " + list.Count.ToString();
				refresh_AgentDetails();

				lbl_SectorFilter.Text = org.SectorName;
				filterSectorId = org.SectorId;

			}
			else
			{
				MessageBox.Show("Nenhum setor selecionado.");
			}

		}

		#endregion
		private void lbl_Det2_Click(object sender, EventArgs e)
		{

		}


		private void rtBox_Description_Leave(object sender, EventArgs e)
		{
			saveAgentDescription();
		}

		private void saveAgentDescription()
		{
			Agent agent = GetAgentSelected();
			if (agent != null)
			{
				agent.Description = rtBox_Description.Text;

				_agentsRepository.Save(agent);

				refresh_AgentDetails();
			}
		}

		private void dg_Agents_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{

			DataGridView grid = (DataGridView)sender;
			if (agentSortOrder == null || agentSortOrder == SortOrder.Descending)
			{
				SortAgent(grid.Columns[e.ColumnIndex].DataPropertyName, SortOrder.Ascending);
				grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
				agentSortOrder = SortOrder.Ascending;
			}
			else
			{
				SortAgent(grid.Columns[e.ColumnIndex].DataPropertyName, SortOrder.Descending);
				grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
				agentSortOrder = SortOrder.Descending;
			}
			sortColumnAgents = grid.Columns[e.ColumnIndex].DataPropertyName;
			sortColumn = grid.Columns[e.ColumnIndex].HeaderCell;
		}

		private void dg_Sectors_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{


			DataGridView grid = (DataGridView)sender;
			if (groupSortOrder == null || groupSortOrder == SortOrder.Descending)
			{
				SortSectors(grid.Columns[e.ColumnIndex].DataPropertyName, SortOrder.Ascending);
				grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
				groupSortOrder = SortOrder.Ascending;
			}
			else
			{
				SortSectors(grid.Columns[e.ColumnIndex].DataPropertyName, SortOrder.Descending);
				grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
				groupSortOrder = SortOrder.Descending;
			}
			sortColumGroup = grid.Columns[e.ColumnIndex].DataPropertyName;
			sortColumnGroupHeader = grid.Columns[e.ColumnIndex].HeaderCell;
		}
		private void SortAgent(string column, SortOrder sortOrder)
		{

			if (filterSectorId != 0)
			{
				lstAgents = _organizationAgentRepository.GetByOrganization(filterSectorId).Select(r => r.Agent).ToList();

			}
			else
			{
				lstAgents = _agentsRepository.ListAll().ToList();

			}

			switch (column)
			{
				case "Code":
					{
						if (sortOrder == SortOrder.Ascending)
						{
							agentBindingSource.DataSource = lstAgents.OrderBy(x => x.Code).ToList();
						}
						else
						{
							agentBindingSource.DataSource = lstAgents.OrderByDescending(x => x.Code).ToList();
						}
						break;
					}
				case "Name":
					{
						if (sortOrder == SortOrder.Ascending)
						{
							agentBindingSource.DataSource = lstAgents.OrderBy(x => x.Name).ToList();
						}
						else
						{
							agentBindingSource.DataSource = lstAgents.OrderByDescending(x => x.Name).ToList();
						}
						break;
					}
				case "AgentId":
					{
						if (sortOrder == SortOrder.Ascending)
						{
							agentBindingSource.DataSource = lstAgents.OrderBy(x => x.AgentId).ToList();
						}
						else
						{
							agentBindingSource.DataSource = lstAgents.OrderByDescending(x => x.AgentId).ToList();
						}
						break;
					}

			}
			refresh_AgentDetails();

		}
		private void SortSectors(string column, SortOrder sortOrder)
		{
			List<Organization> lstOrganization = _sectorsRepository.ListAll().ToList();

			switch (column)
			{
				case "Code":
					{
						if (sortOrder == SortOrder.Ascending)
						{
							organizationBindingSource.DataSource = lstOrganization.OrderBy(x => x.Code).ToList();
						}
						else
						{
							organizationBindingSource.DataSource = lstOrganization.OrderByDescending(x => x.Code).ToList();
						}
						break;
					}
				case "SectorName":
					{
						if (sortOrder == SortOrder.Ascending)
						{
							organizationBindingSource.DataSource = lstOrganization.OrderBy(x => x.SectorName).ToList();
						}
						else
						{
							organizationBindingSource.DataSource = lstOrganization.OrderByDescending(x => x.SectorName).ToList();
						}
						break;
					}

			}

		}

		private void btn_ManageSectors_Click(object sender, EventArgs e)
		{
			Frm_OrganizationalDivision frm = new Frm_OrganizationalDivision(this, context);
			frm.ShowDialog();
		}

		private void btn_Del_OrgRelationship_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (dataGridView3.SelectedRows.Count > 0)
			{
				DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja deletar as relações? Total: " + dataGridView3.SelectedRows.Count, "Deletar Relação", MessageBoxButtons.YesNo);

				if (dialogResult == DialogResult.Yes)
				{
					foreach (DataGridViewRow row in dataGridView3.SelectedRows)
					{
						var relationshipId = row.Cells[0].Value;

						if (relationshipId != null && (int)relationshipId != 0)
						{
							try
							{
								Agent ag = GetAgentSelected();
								OrganizationAgent rel = _organizationAgentRepository.GetByOrganizationAgent((int)relationshipId, ag.AgentId);

								if (rel != null && ag != null)
								{
									_organizationAgentRepository.Delete(rel);

								}
							}
							catch
							{
								MessageBox.Show("Erro ao deletar item.");
							}
						}
					}
					refresh_Agents();
				}
			}
			Cursor.Current = Cursors.Default;
		}

		private void btn_Del_Subordination_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (dataGridView2.SelectedRows.Count > 0)
			{
				DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja deletar os itens selecionados? Total: " + dataGridView2.SelectedRows.Count + ". Esta operação não poderá ser desfeita", "Deletar", MessageBoxButtons.YesNoCancel);
				if (dialogResult == DialogResult.Yes)
				{
					foreach (DataGridViewRow row in dataGridView2.SelectedRows)
					{
						var id = row.Cells[0].Value;
						if (id != null && (int)id != 0)
						{
							try
							{
								Agent ag = GetAgentSelected();
								AgentSubordination rel = _subordinationAgentRepository.GetByAgentSubordination(ag.AgentId, (int)id);

								if (rel != null && ag != null)
								{
									_subordinationAgentRepository.Delete(rel);

								}
							}
							catch
							{
								MessageBox.Show("Erro ao deletar item.");
							}

						}
					}
					refresh_Agents();
				}
			}
			Cursor.Current = Cursors.Default;
		}

		private void dg_Agents_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			refresh_AgentDetails();
		}

		private void btn_ImportAgentActivityRelationship_Click(object sender, EventArgs e)
		{

			Frm_ImportCsv form = new Frm_ImportCsv(Model.ScreenEnum.AgentActivityRelationship, this);
			form.ShowDialog();
		}

		private void dg_Agents_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.ColumnIndex == 0)
				if (dg_Agents[e.ColumnIndex, e.RowIndex].ReadOnly)
					e.CellStyle.BackColor = Color.LightGray;
		}

		private void btn_ExportAgentCSV_Click(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					try
					{
						List<Agent> list = (List<Agent>)agentBindingSource.DataSource;

						string fileName = "funcao";
						if (filterSectorId != 0)
						{
							fileName += "_D" + filterSectorId.ToString();
						}
						fileName += ".csv";

						string destFile = Path.Combine(fbd.SelectedPath, fileName);

						WriteCustomCSV.AgentsToCSV(list, destFile);

					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Aviso");
					}
				}
			}

		}

		private void btn_ExportDivision_Click(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					try
					{
						List<Organization> list = (List<Organization>)organizationBindingSource.DataSource;

						string fileName = "divisao_organizacional.csv";
						string destFile = Path.Combine(fbd.SelectedPath, fileName);

						WriteCustomCSV.OrganizationToCSV(list, destFile);

					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Aviso");
					}
				}
			}
		}

		private void btn_ExportActivityAgent_Click(object sender, EventArgs e)
		{
			Agent agent = GetAgentSelected();
			if (agent != null)
			{
				using (var fbd = new FolderBrowserDialog())
				{
					DialogResult result = fbd.ShowDialog();

					if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
					{
						try
						{
							List<AgentActivityRelationship> relations = _activityRelRepository.GetByAgentId(agent.AgentId).ToList();
							string fileName = "relacoes_AtividadexFuncao_F" + agent.AgentId + ".csv";
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
				MessageBox.Show("Nenhuma função selecionada.", "Aviso");
			}
		}

		private void btn_NewGroup_Click(object sender, EventArgs e)
		{
			this.BeginInvoke(new Action(() =>
			{
				dg_Sectors.CurrentCell = dg_Sectors.Rows[dg_Sectors.NewRowIndex].Cells[2];
				dg_Sectors.BeginEdit(true);
			}));
		}

		private void btn_New_Click(object sender, EventArgs e)
		{
			this.BeginInvoke(new Action(() =>
			{
				dg_Agents.CurrentCell = dg_Agents.Rows[dg_Agents.NewRowIndex].Cells[2];
				dg_Agents.BeginEdit(true);
			}));

		}

		private void btn_ImportAgentResouceRelationship_Click(object sender, EventArgs e)
		{
			Frm_ImportCsv form = new Frm_ImportCsv(Model.ScreenEnum.AgentResourceRelationship, this);
			form.ShowDialog();
		}

		private void btn_ExportAgentResouceRelationship_Click(object sender, EventArgs e)
		{
			Agent agent = GetAgentSelected();
			if (agent != null)
			{
				using (var fbd = new FolderBrowserDialog())
				{
					DialogResult result = fbd.ShowDialog();

					if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
					{
						try
						{
							List<AgentResourceRelationship> relations = _resourceRelRepository.GetByAgent(agent.AgentId).ToList();
							string fileName = "relacoes_FuncaoxRecurso_F" + agent.AgentId + ".csv";
							string destFile = Path.Combine(fbd.SelectedPath, fileName);

							WriteCustomCSV.RelAgentxResourceToCSV(relations, destFile);
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
	}
}
