using MSCMD.Model;
using MSCMD.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MSCMD.Forms.OrganizationalDivision
{
	public partial class Frm_AgentOrganizationtRelationship : Form
	{
		private Form _originForm;
		Agent agent;
		private static MscmdContext _context = new MscmdContext();
		private OrganizationRepository _sectorRepository = new OrganizationRepository(_context);
		private AgentRepository _agentRepository = new AgentRepository(_context);
		private OrganizationAgentRepository _organizationAgentRepository = new OrganizationAgentRepository();
		public Frm_AgentOrganizationtRelationship(Agent ag, Form origin)
		{
			InitializeComponent();
			agent = ag;
			_originForm = origin;
		}

		private void Frm_AgentOrganizationtRelationship_Load(object sender, EventArgs e)
		{
			lbl_Code.Text = agent.Code?.ToString();
			lbl_Name.Text = agent.Name.ToString();
			loadDataSource();
		}

		private void loadDataSource()
		{
			var orgs = _organizationAgentRepository.GetByAgent(agent.AgentId);

			HashSet<int> excludedIDs = new HashSet<int>(orgs.Select(p => p.OrganizationId));
			List<Organization> sectorList = _sectorRepository.ListAll().Where(p => !excludedIDs.Contains(p.SectorId)).ToList();

			this.organizationBindingSource.DataSource = sectorList;
		}

		private void btn_Salvar_Click(object sender, EventArgs e)
		{
			try
			{
				foreach (DataGridViewRow row in dg_Sector.SelectedRows)
				{
					var rowVal = row.Cells[0].Value;
					if (rowVal != null)
					{
						int id = (int)rowVal;

						OrganizationAgent rel = new OrganizationAgent();
						rel.OrganizationId = id;
						rel.AgentId = agent.AgentId;


						_organizationAgentRepository.AddNew(rel);
					}
				}

				Frm_Organization frm = (Frm_Organization)_originForm;
				loadDataSource();
				frm.refresh_Agents();
			}
			catch (Exception x)
			{
				MessageBox.Show("Erro ao salvar a relação.");
			}

			//try
			//{
			//	if (dg_Sector.SelectedRows.Count == 1)
			//	{


			//		int idSector = (int)dg_Sector.SelectedRows[0].Cells[0].Value;

			//		//agent.FunctionalCapacityId = idSector;
			//		_agentRepository.Save(agent);

			//		Frm_Organization frm = (Frm_Organization)_originForm;
			//		frm.refresh_Agents();

			//		MessageBox.Show("Setor vinculado com sucesso.");
			//		this.Close();

			//	}
			//	else
			//	{
			//		MessageBox.Show("Selecione um setor para vincular à Função.");
			//	}

			//}
			//catch (Exception x)
			//{
			//	MessageBox.Show("Erro ao salvar a relação.");
			//}
		}

		private void btn_Close_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
