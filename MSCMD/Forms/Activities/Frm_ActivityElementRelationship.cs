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
	public partial class Frm_ActivityElementRelationship : Form
	{
		private Form _originForm;
		Activity activity;
		private static MscmdContext _context;
		private ElementRepository _elementRepository;
		private ActivityElementRelationshipRepository _relationElementRepository;

		public Frm_ActivityElementRelationship(Activity act, Form origin)
		{
			Configure();
			InitializeComponent();
			activity = act;
			_originForm = origin;
		}

		private void Configure()
		{
			_context = new MscmdContext();
			_elementRepository = new ElementRepository(_context);
			_relationElementRepository = new ActivityElementRelationshipRepository(_context);

		}

		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);
			_context?.Dispose();
		}

		private void Frm_ActivityElementRelationship_Load(object sender, EventArgs e)
		{
			lbl_Code.Text = activity.ActivityCode?.ToString();
			lbl_Name.Text = activity.ActivityName.ToString();
			loadDataSources();
		}

		private void loadDataSources()
		{
			loadElements();

			cb_Relation.DisplayMember = "Value";
			cb_Relation.ValueMember = "Key";
			cb_Relation.DataSource = Utility.EnumOf<RelationActivityComponentEnum>();


			cb_AcessType.DisplayMember = "Value";
			cb_AcessType.ValueMember = "Key";
			cb_AcessType.DataSource = Utility.EnumOf<AccessTypeEnum>();

		}

		private void loadElements(string searchString = null)
		{
			List<Element> relationActivity = _relationElementRepository.GetByActivity(activity.ActivityId).Select(r => r.Component).ToList();

			List<Element> elements = new List<Element>();
			try
			{

				if (searchString != null && searchString != "")
				{
					elements = _elementRepository.ListAll().Except(relationActivity).Where(x => (x.Code != null ? x.Code.ToLower().Contains(searchString.ToLower()) : false) || x.Name.ToLower().Contains(searchString.ToLower())).ToList();
				}
				else
				{
					elements = _elementRepository.ListAll().Except(relationActivity).ToList();
				}

				this.elementBindingSource.DataSource = elements;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}
		private void btn_Save_Click(object sender, EventArgs e)
		{
			var relEnum = (KeyValuePair<RelationActivityComponentEnum, string>)cb_Relation.SelectedItem;
			RelationActivityComponentEnum relation = (RelationActivityComponentEnum)relEnum.Key;

			var relAccessEnum = (KeyValuePair<AccessTypeEnum, string>)cb_AcessType.SelectedItem;
			AccessTypeEnum accessType = (AccessTypeEnum)relAccessEnum.Key;

			try
			{

				foreach (DataGridViewRow row in dg_Element.SelectedRows)
				{
					var rowVal = row.Cells[0].Value;
					if (rowVal != null)
					{
						int id = (int)rowVal;

						ActivityElementRelationship rel = new ActivityElementRelationship();
						rel.ActivityId = activity.ActivityId;
						rel.ComponentId = id;
						rel.Relation = relation;
						rel.ComponentAccessType = accessType;

						_relationElementRepository.AddNew(rel);
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
			loadElements(txt_Search.Text);
		}

		private void btn_Clean_Click(object sender, EventArgs e)
		{
			loadElements();
		}

		private void txt_Search_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				loadElements(txt_Search.Text);
			}
		}
	}
}
