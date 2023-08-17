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
using System.Xml.Linq;

namespace MSCMD.Forms.OrganizationalDivision
{

	public partial class Frm_AgentActivityRelationship : Form
	{
		private Form _origemForm;
		private static MscmdContext context;
		private ActivityRepository _activityRepository;
		private AgentActivityRelationshipRepository _activityRelRepository;
		Agent agent;
		public Frm_AgentActivityRelationship(Agent func, Form origem)
		{
			Configure();
			InitializeComponent();
			agent = func;
			_origemForm = origem;
		}

		private void Configure()
		{
			context = new MscmdContext();
			_activityRepository = new ActivityRepository(context);
			_activityRelRepository = new AgentActivityRelationshipRepository(context);
		}

		private void Frm_AgentActivityRelationship_Load(object sender, EventArgs e)
		{
			lbl_FuncaoCod.Text = agent.Code?.ToString();
			lbl_NomeFunc.Text = agent.Name.ToString();

			loadDataSources();
		}

		private void loadDataSources()
		{
			loadactivities();

		}

		private void loadactivities(string searchString = null)
		{

			var activityRelationship = _activityRelRepository.GetByAgentId(agent.AgentId).Select(r => r.Activity);

			List<Model.Activity> activities = new List<Model.Activity>();
			try
			{

				if (searchString != null && searchString != "")
				{
					activities = _activityRepository.ListAll().Except(activityRelationship).Where(x => (x.ActivityCode != null ? x.ActivityCode.ToLower().Contains(searchString.ToLower()) : false) || x.ActivityName.ToLower().Contains(searchString.ToLower())).ToList();
				}
				else
				{
					activities = _activityRepository.ListAll().Except(activityRelationship).ToList();
				}

				this.activityBindingSource.DataSource = activities;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void btn_Salvar_Click(object sender, EventArgs e)
		{

			try
			{

				foreach (DataGridViewRow row in dg_Activity.SelectedRows)
				{
					var rowVal = row.Cells[0].Value;
					if (rowVal != null)
					{
						int activityId = (int)rowVal;
						Activity activity = _activityRepository.FindBy(activityId);

						AgentActivityRelationship rel = new AgentActivityRelationship();
						rel.ActivityId = activity.ActivityId;
						rel.AgentId = agent.AgentId;

						_activityRelRepository.AddNew(rel);
					}
				}

				Frm_Organization frm = (Frm_Organization)_origemForm;
				frm.refresh_Agents();
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
			loadactivities(txt_Search.Text);
		}

		private void btn_Clean_Click(object sender, EventArgs e)
		{
			loadactivities();
		}

		private void txt_Search_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				loadactivities(txt_Search.Text);
			}
		}
	}
}
