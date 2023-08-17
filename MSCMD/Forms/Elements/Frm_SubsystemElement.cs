using MSCMD.Forms.Activities;
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

namespace MSCMD.Forms.Elements
{
	public partial class Frm_SubsystemElement : Form
	{
		private Form _originForm;
		Subsystem subsystem;
		private static MscmdContext _context = new MscmdContext();
		private ElementRepository _elementRepository = new ElementRepository(_context);
		private ElementSubsystemRepository _relationRepository = new ElementSubsystemRepository();
		public Frm_SubsystemElement(Subsystem sub, Form origin)
		{
			InitializeComponent();
			subsystem = sub;
			_originForm = origin;
		}


		private void Frm_SubsystemElement_Load(object sender, EventArgs e)
		{
			lbl_Code.Text = subsystem.Code?.ToString();
			lbl_Name.Text = subsystem.Name.ToString();
			loadDataSources();
		}

		private void loadDataSources(string searchString = null)
		{
			try
			{
				var rel = _relationRepository.GetBySubsystem(subsystem.SubsystemId);

				HashSet<int> excludedIDs = new HashSet<int>(rel.Select(p => p.ElementId));
				List<Model.Element> elements = new List<Element>();

				if (searchString != null && searchString != "")
				{
					elements = _elementRepository.ListAll().Where(p => !excludedIDs.Contains(p.ElementId)).Where(x => (x.Code != null ? x.Code.ToLower().Contains(searchString.ToLower()) : false) || x.Name.ToLower().Contains(searchString.ToLower())).ToList();
				}
				else
				{
					elements = _elementRepository.ListAll().Where(p => !excludedIDs.Contains(p.ElementId)).ToList();
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
			try
			{
				foreach (DataGridViewRow row in dg_Elements.SelectedRows)
				{
					int id = (int)row.Cells[0].Value;

					ElementSubsystem rel = new ElementSubsystem();
					rel.ElementId = id;
					rel.SubsystemId = subsystem.SubsystemId;

					_relationRepository.AddNew(rel);
				}

				Frm_Subsystem frm = (Frm_Subsystem)_originForm;
				frm.refresh_Subsystem();
				loadDataSources();
				frm.refresh_Elements();
			}
			catch (Exception x)
			{
				MessageBox.Show(x.InnerException.Message);
			}
		}

		private void btn_CloseForm_Click(object sender, EventArgs e)
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
