using MSCMD.Model;
using MSCMD.Repository;
using MSCMD.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSCMD.Forms.Activities
{
	public partial class Frm_ActivityAgentRelationship : Form
	{
		private Form _originForm;
		Activity activity;
		private static MscmdContext _context;
		private AgentRepository _agentRepository;
		private AgentActivityRelationshipRepository _relationAgentRepository;

		public Frm_ActivityAgentRelationship(Activity act, Form origin)
		{
			Configure();
			InitializeComponent();
			activity = act;
			_originForm = origin;
		}

		private void Configure()
		{
			_context = new MscmdContext();
			_agentRepository = new AgentRepository(_context);
			_relationAgentRepository = new AgentActivityRelationshipRepository(_context);

		}

		private void Frm_ActivityAgentRelationship_Load(object sender, EventArgs e)
		{
			lbl_Code.Text = activity.ActivityCode?.ToString();
			lbl_Name.Text = activity.ActivityName.ToString();
			loadDataSources();
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);
			_context?.Dispose();
		}

		private void loadDataSources(string searchString = null)
		{
			List<Agent> relationActivity = _relationAgentRepository.GetByActivityId(activity.ActivityId).Select(r => r.ResponsibleAgent).ToList();
			List<Agent> agents = new List<Agent>();


			try
			{

				if (searchString != null && searchString != "")
				{
					agents = _agentRepository.ListAll().Except(relationActivity).Where(x => (x.Code != null ? x.Code.ToLower().Contains(searchString.ToLower()) : false) || x.Name.ToLower().Contains(searchString.ToLower())).ToList();
				}
				else
				{
					agents = _agentRepository.ListAll().Except(relationActivity).ToList();
				}


				agentBindingSource.DataSource = agents;
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
						int id = (int)rowVal;

						AgentActivityRelationship rel = new AgentActivityRelationship();
						rel.ActivityId = activity.ActivityId;
						rel.AgentId = id;

						_relationAgentRepository.AddNew(rel);
					}
				}

				Frm_Activity frm = (Frm_Activity)_originForm;
				frm.refresh_Activities();
				loadDataSources();
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

		private void btn_Search_Click(object sender, EventArgs e)
		{
			loadDataSources(txt_Search.Text);
		}

		private void btn_Clean_Click(object sender, EventArgs e)
		{
			loadDataSources();
		}

		private void txt_Search_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				loadDataSources(txt_Search.Text);
			}
		}
	}
}
