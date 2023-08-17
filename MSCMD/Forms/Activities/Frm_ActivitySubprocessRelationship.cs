using MSCMD.Repository;
using MSCMD.Model;
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

namespace MSCMD.Forms.Activities
{
	public partial class Frm_ActivitySubprocessRelationship : Form
	{
		private Form _originForm;
		Activity activity;
		private static MscmdContext _context;
		private SubprocessRepository _subprocessRepository;
		private SubprocessActivityRepository _relationRepository;
		public Frm_ActivitySubprocessRelationship(Activity act, Form origin)
		{
			Configure();
			InitializeComponent();
			activity = act;
			_originForm = origin;
		}

		private void Configure()
		{
			_context = new MscmdContext();
			_subprocessRepository = new SubprocessRepository(_context);
			_relationRepository = new SubprocessActivityRepository();

		}

		private void Frm_ActivitySubprocessRelationship_Load(object sender, EventArgs e)
		{
			lbl_Codigo.Text = activity.ActivityCode?.ToString();
			lbl_NomeElemento.Text = activity.ActivityName.ToString();
			loadSubprocesses();
		}


		private void loadSubprocesses(string searchString = null)
		{
			var relacao = _relationRepository.GetByActivity(activity.ActivityId).Select(r => r.Subprocess);
			HashSet<int> excludedIDs = new HashSet<int>(relacao.Select(p => p.SubprocessId));

			List<Model.Subprocess> subprocesses = new List<Model.Subprocess>();
			try
			{

				if (searchString != null && searchString != "")
				{
					subprocesses = _subprocessRepository.ListAll().Where(p => !excludedIDs.Contains(p.SubprocessId)).Where(x => (x.Code != null ? x.Code.ToLower().Contains(searchString.ToLower()) : false) || x.Name.ToLower().Contains(searchString.ToLower())).ToList();
				}
				else
				{
					subprocesses = _subprocessRepository.ListAll().Where(p => !excludedIDs.Contains(p.SubprocessId)).ToList();
				}

				this.subprocessBindingSource.DataSource = subprocesses;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);
			_context?.Dispose();
		}

		
		private void btn_Vincular_Click(object sender, EventArgs e)
		{
			try
			{

				foreach (DataGridViewRow row in dg_Sectors.SelectedRows)
				{
					var rowVal = row.Cells[0].Value;
					if (rowVal != null)
					{
						int id = (int)rowVal;

						SubprocessActivity rel = new SubprocessActivity();
						rel.SubprocessId = id;
						rel.ActivityId = activity.ActivityId;

						_relationRepository.AddNew(rel);
					}
				}
				Frm_Activity frm = (Frm_Activity)_originForm;
				frm.refresh_Activities();
				loadSubprocesses();
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
				loadSubprocesses(txt_Search.Text);
			}
		}

		private void btn_Search_Click(object sender, EventArgs e)
		{
			loadSubprocesses(txt_Search.Text);
		}

		private void btn_Clean_Click(object sender, EventArgs e)
		{
			loadSubprocesses();
		}
	}
}
