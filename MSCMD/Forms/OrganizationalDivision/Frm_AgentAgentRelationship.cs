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

namespace MSCMD.Forms.OrganizationalDivision
{
	public partial class Frm_AgentAgentRelationship : Form
	{
		private Form _originForm;
		Agent agent;
		private static MscmdContext _context;
		private AgentRepository _agentRepository;
		private AgentSubordinationRepository _relRepository;
		public Frm_AgentAgentRelationship(Agent ag, Form origin)
		{
			Configure();
			InitializeComponent();
			agent = ag;
			_originForm = origin;
		}

		private void Configure()
		{
			_context = new MscmdContext();
			_agentRepository = new AgentRepository(_context);
			_relRepository = new AgentSubordinationRepository(_context);
		}

		private void Frm_AgentAgentRelationship_Load(object sender, EventArgs e)
		{
			lbl_Code.Text = agent.Code?.ToString();
			lbl_Name.Text = agent.Name.ToString();
			loadDataSource();
		}

		private void loadDataSource(string searchString = null)
		{
			HashSet<int> excludedIDs = new HashSet<int>(agent.FunctionalSubordinations.Select(p => p.FunctionalSubordinationId));
			excludedIDs.Add(agent.AgentId);
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

				this.agentBindingSource.DataSource = agentList;
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
				foreach (DataGridViewRow row in dg_Agent.SelectedRows)
				{
					var rowVal = row.Cells[0].Value;
					if (rowVal != null)
					{
						int idAgent = (int)rowVal;
						AgentSubordination rel = new AgentSubordination()
						{
							AgentId = agent.AgentId,
							FunctionalSubordinationId = idAgent,
						};

						_relRepository.AddNew(rel);
					}
				}

				loadDataSource();
				Frm_Organization frm = (Frm_Organization)_originForm;
				frm.refresh_Agents();
			}
			catch (Exception x)
			{
				MessageBox.Show("Erro ao salvar a relação.");
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
				loadDataSource(txt_Search.Text);
			}
		}

		private void btn_Search_Click(object sender, EventArgs e)
		{
			loadDataSource(txt_Search.Text);
		}

		private void btn_Clean_Click(object sender, EventArgs e)
		{
			loadDataSource();
		}
	}
}
