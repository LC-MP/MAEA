using MSCMD.Forms.Elements;
using MSCMD.Model;
using MSCMD.Repository;
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

namespace MSCMD.Forms.OrganizationalDivision
{
	public partial class Frm_OrganizationAgent : Form
	{
		private Form _originForm;
		Organization sector;
		private static MscmdContext _context;
		private AgentRepository _agentRepository;
		private OrganizationAgentRepository _relationRepository;
		public Frm_OrganizationAgent(Organization org, Form origin, MscmdContext context)
		{
			InitializeComponent();
			sector = org;
			_originForm = origin;
			_context = context;
			_agentRepository = new AgentRepository(context);
			_relationRepository = new OrganizationAgentRepository();
		}


		private void Frm_OrganizationAgent_Load(object sender, EventArgs e)
		{
			lbl_Code.Text = sector.Code?.ToString();
			lbl_Name.Text = sector.SectorName.ToString();
			loadDataSources();
		}


		private void loadDataSources(string searchString = null)
		{
			var rel = _relationRepository.GetByOrganization(sector.SectorId);
			HashSet<int> excludedIDs = new HashSet<int>(rel.Select(p => p.AgentId));

			List<Agent> agentList = new List<Agent>();
			try
			{

				if (searchString != null && searchString != "")
				{
					agentList = _agentRepository.ListAll().Where(p => !excludedIDs.Contains(p.AgentId)).Where(x => (x.Code != null ? x.Code.ToLower().Contains(searchString.ToLower()) : false) || x.Name.ToLower().Contains(searchString.ToLower())).ToList();
				}
				else
				{
					agentList = _agentRepository.ListAll().Where(p => !excludedIDs.Contains(p.AgentId)).ToList();
				}

				agentBindingSource.DataSource = agentList;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}

		}

		private void btn_Save_Click(object sender, EventArgs e)
		{
			try
			{
				foreach (DataGridViewRow row in dg_Agents.SelectedRows)
				{
					int id = (int)row.Cells[0].Value;

					OrganizationAgent rel = new OrganizationAgent();
					rel.OrganizationId = sector.SectorId;
					rel.AgentId = id;

					_relationRepository.AddNew(rel);
				}

				Frm_OrganizationalDivision frm = (Frm_OrganizationalDivision)_originForm;
				frm.refresh_Sectors();
				loadDataSources();
				frm.refresh_Agents();
			}
			catch (Exception x)
			{
				MessageBox.Show(x.InnerException.Message);
			}
		}

		private void btn_Close_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void txt_Search_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				loadDataSources(txt_Search.Text);
			}
		}

		private void btn_Search_Click(object sender, EventArgs e)
		{
			loadDataSources(txt_Search.Text);
		}

		private void btn_Clean_Click(object sender, EventArgs e)
		{
			loadDataSources();
		}
	}
}
