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

namespace MSCMD.Forms.Elements
{
	public partial class Frm_ElementSubsystemRelationship : Form
	{

		private Form _origemForm;
		Element element;
		private static MscmdContext _context;
		private SubsystemRepository _subsystemRepository;
		private ElementSubsystemRepository _relationRepository;

		public Frm_ElementSubsystemRelationship(Element elem, Form origem)
		{
			InitializeComponent();
			element = elem;
			_origemForm = origem;

			_context = new MscmdContext();
			_subsystemRepository = new SubsystemRepository(_context);
			_relationRepository = new ElementSubsystemRepository();
		}

		private void Frm_ElementSubsystemRelationship_Load(object sender, EventArgs e)
		{
			lbl_Codigo.Text = element.Code?.ToString();
			lbl_NomeElemento.Text = element.Name.ToString();
			loadSubsystems();
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

						ElementSubsystem rel = new ElementSubsystem();
						rel.SubsystemId = id;
						rel.ElementId = element.ElementId;

						_relationRepository.AddNew(rel);
					}
				}
				Frm_Element frm = (Frm_Element)_origemForm;
				frm.refresh_Elements();
				loadSubsystems();
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


		private void loadSubsystems(string searchString = null)
		{

			
			var relacao = _relationRepository.GetByElement(element.ElementId).Select(r => r.Subsystem);
			HashSet<int> excludedIDs = new HashSet<int>(relacao.Select(p => p.SubsystemId));

			List<Model.Subsystem> subsystems = new List<Model.Subsystem>();
			try
			{

				if (searchString != null && searchString != "")
				{
					subsystems = _subsystemRepository.ListAll().Where(p => !excludedIDs.Contains(p.SubsystemId)).Where(x => (x.Code != null ? x.Code.ToLower().Contains(searchString.ToLower()) : false) || x.Name.ToLower().Contains(searchString.ToLower())).ToList();
				}
				else
				{
					subsystems = _subsystemRepository.ListAll().Where(p => !excludedIDs.Contains(p.SubsystemId)).ToList();
				}

				this.subsystemBindingSource.DataSource = subsystems;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void btn_Search_Click(object sender, EventArgs e)
		{
			loadSubsystems(txt_Search.Text);
		}

		private void btn_Clean_Click(object sender, EventArgs e)
		{
			loadSubsystems();
		}

		private void txt_Search_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				loadSubsystems(txt_Search.Text);
			}
		}
	}
}
