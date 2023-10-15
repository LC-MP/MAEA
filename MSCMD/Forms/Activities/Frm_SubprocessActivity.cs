using MSCMD.Model;
using MSCMD.Repository;
using MSCMD.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSCMD.Forms.Activities
{
	public partial class Frm_SubprocessActivity : Form
	{
		private Form _originForm;
		Subprocess subprocess;
		private static MscmdContext _context = new MscmdContext();
		private ActivityRepository _activityRepository = new ActivityRepository(_context);
		private SubprocessActivityRepository _relationRepository = new SubprocessActivityRepository();

		public Frm_SubprocessActivity(Subprocess sub, Form origin)
		{
			InitializeComponent();
			subprocess = sub;
			_originForm = origin;
		}
		private void Frm_SubprocessActivity_Load(object sender, EventArgs e)
		{
			lbl_Code.Text = subprocess.Code?.ToString();
			lbl_Name.Text = subprocess.Name.ToString();
			loadDataSources();
		}

		private void loadDataSources(string searchString = null)
		{
			var rel = _relationRepository.GetBySubprocess(subprocess.SubprocessId);
			HashSet<int> excludedIDs = new HashSet<int>(rel.Select(p => p.ActivityId));
			List<Model.Activity> activities = new List<Model.Activity>(); 
			
			try
			{
				if (searchString != null && searchString != "")
				{
					activities = _activityRepository.ListAll().Where(p => !excludedIDs.Contains(p.ActivityId)).Where(x => (x.ActivityCode != null ? x.ActivityCode.ToLower().Contains(searchString.ToLower()) : false) || x.ActivityName.ToLower().Contains(searchString.ToLower())).ToList();
				}
				else
				{
					activities = _activityRepository.ListAll().Where(p => !excludedIDs.Contains(p.ActivityId)).ToList();
				}

				this.activityBindingSource.DataSource = activities;
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
				foreach (DataGridViewRow row in dg_Activities.SelectedRows)
				{
					var rowValue = row.Cells[0].Value;

					if (rowValue != null)
					{
						int id = (int)rowValue;

						SubprocessActivity rel = new SubprocessActivity();
						rel.ActivityId = id;
						rel.SubprocessId = subprocess.SubprocessId;

						_relationRepository.AddNew(rel);
					}
					else
					{
						MessageBox.Show("Nenhum item seleiconado");
					}
				}

				Frm_Subprocess frm = (Frm_Subprocess)_originForm;
				frm.refresh_Subprocess();
				loadDataSources();
				frm.refresh_Activities();
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
