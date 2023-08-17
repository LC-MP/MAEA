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

namespace MSCMD.Forms.Elements
{
	public partial class Frm_ElementOrganizationRelationship : Form
	{

		private Form _origemForm;
		Element element;
		private static MscmdContext _context = new MscmdContext();
		private OrganizationRepository _sectorRepository = new OrganizationRepository(_context);
		private ElementRepository _elementRepository = new ElementRepository(_context);
		public Frm_ElementOrganizationRelationship(Element elem, Form origem)
		{
			InitializeComponent();
			element = elem;
			_origemForm = origem;
		}

		private void Frm_ElementOrganizationRelationship_Load(object sender, EventArgs e)
		{
			lbl_Codigo.Text = element.Code?.ToString();
			lbl_NomeElemento.Text = element.Name.ToString();
			loadDataSource();
		}

		private void loadDataSource(string searchString = null)
		{
			
			try
			{List<Model.Organization> sectorList = new List<Organization>();

				if (searchString != null && searchString != "")
				{
					sectorList = _sectorRepository.ListAll().Where(x => (x.Code != null ? x.Code.ToLower().Contains(searchString.ToLower()) : false) || x.SectorName.ToLower().Contains(searchString.ToLower())).ToList();
				}
				else
				{
					sectorList = _sectorRepository.ListAll().ToList();
				}

				this.organizationBindingSource.DataSource = sectorList;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void btn_Vincular_Click(object sender, EventArgs e)
		{
			try
			{
				if (dg_Sectors.SelectedRows.Count == 1)
				{


					int idSector = (int)dg_Sectors.SelectedRows[0].Cells[0].Value;

					element.OrganizationId = idSector;
					_elementRepository.Save(element);

					Frm_Element frm = (Frm_Element)_origemForm;
					frm.refresh_Elements();

					MessageBox.Show("Setor vinculado com sucesso.");
					this.Close();

				}
				else
				{
					MessageBox.Show("Selecione um setor para vincular ao Elemento.");
				}

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
