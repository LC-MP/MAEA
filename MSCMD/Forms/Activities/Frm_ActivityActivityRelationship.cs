using MSCMD.Model;
using MSCMD.Repository;
using MSCMD.Utils;
using OpenTK.Graphics.OpenGL;
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

namespace MSCMD.Forms
{
	public partial class Frm_ActivityActivityRelationship : Form
	{

		private Form _originForm;
		Model.Activity activity;
		private static MscmdContext _context;
		private ActivityRepository _activityRepository;
		private ActivityActivityRelationshipRepository _relationActivityRepository;

		public Frm_ActivityActivityRelationship(Activity act, Form origin)
		{
			Configure();
			InitializeComponent();
			activity = act;
			_originForm = origin;
		}
		private void Configure()
		{
			_context = new MscmdContext();
			_activityRepository = new ActivityRepository(_context);
			_relationActivityRepository = new ActivityActivityRelationshipRepository(_context);

		}

		private void Frm_ActivityActivityRelationship_Load(object sender, EventArgs e)
		{
			lbl_Code.Text = activity.ActivityCode?.ToString();
			lbl_Name.Text = activity.ActivityName.ToString();
			loadDataSources();
		}

		private void loadDataSources()
		{
			loadactivities();

			cb_Relation.DisplayMember = "Value";
			cb_Relation.ValueMember = "Key";
			cb_Relation.DataSource = Utility.EnumOf<ActivityRelationEnum>();
		}

		private void loadactivities(string searchString = null)
		{

			List<Model.Activity> relationActivity = _relationActivityRepository.GetByReferenceActivity(activity.ActivityId).Select(r => r.ReferredActivity).ToList();
			List<Model.Activity> activities = new List<Model.Activity>();
			try
			{

				if (searchString != null && searchString != "")
				{
					activities = _activityRepository.ListAll().Except(relationActivity).Where(x => (x.ActivityCode != null ? x.ActivityCode.ToLower().Contains(searchString.ToLower()) : false) || x.ActivityName.ToLower().Contains(searchString.ToLower())).ToList();
				}
				else
				{
					activities = _activityRepository.ListAll().Except(relationActivity).ToList();
				}

				activities = activities.Where(a => a.ActivityId != activity.ActivityId).ToList();

				this.activityBindingSource.DataSource = activities;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void btn_Save_Click(object sender, EventArgs e)
		{
			var relEnum = (KeyValuePair<ActivityRelationEnum, string>)cb_Relation.SelectedItem;
			ActivityRelationEnum relation = (ActivityRelationEnum)relEnum.Key;
			try
			{

				foreach (DataGridViewRow row in dg_Activity.SelectedRows)
				{
					var rowVal = row.Cells[0].Value;
					if (rowVal != null)
					{
						int id = (int)rowVal;

						ActivityActivityRelationship rel = new ActivityActivityRelationship();
						rel.ReferenceActivityId = activity.ActivityId;
						rel.ReferredActivityId = id;
						rel.Relation = relation;

						_relationActivityRepository.AddNew(rel);
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
			loadactivities(txt_Search.Text);
		}

		private void btn_Clean_Click(object sender, EventArgs e)
		{
			loadactivities();
		}


		private void txt_Search_Enter(object sender, EventArgs e)
		{
			loadactivities(txt_Search.Text);
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
