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

namespace MSCMD.Forms
{
	public partial class Frm_ElementElementRelationship : Form
	{

		private Form _origemForm;
		private static MscmdContext _context = new MscmdContext();
		private ElementRepository _elementoRepository = new ElementRepository(_context);
		private ElementElementRelationshipRepository _relacaoElementoRepository = new ElementElementRelationshipRepository(_context);
		Model.Element element;

		public Frm_ElementElementRelationship(Model.Element elem, Form origem)
		{
			InitializeComponent();
			element = elem;
			_origemForm = origem;
		}

		private void Frm_VinculoElementoElemento_Load(object sender, EventArgs e)
		{
			lbl_Codigo.Text = element.Code?.ToString();
			lbl_NomeElemento.Text = element.Name.ToString();

			loadDataSources();
		}

		private void loadDataSources()
		{
			loadElements();

			cb_Relacao.DisplayMember = "Value";
			cb_Relacao.ValueMember = "Key";
			cb_Relacao.DataSource = Utility.EnumOf<ElementRelationEnum>();
		}

		private void loadElements(string searchString = null)
		{
			try
			{
				List<Model.Element> relacaoElemento = _relacaoElementoRepository.GetByReferenceComponentId(element.ElementId).Select(r => r.ReferredComponent).ToList();

				List<Model.Element> elements = new List<Element>();

				if (searchString != null && searchString != "")
				{
					elements = _elementoRepository.ListAll().Except(relacaoElemento).Where(x => (x.Code != null ? x.Code.ToLower().Contains(searchString.ToLower()) : false) || x.Name.ToLower().Contains(searchString.ToLower())).ToList();
				}
				else
				{
					elements = _elementoRepository.ListAll().Except(relacaoElemento).ToList();
				}

				elements = elements.Where(el => el.ElementId != element.ElementId).ToList();
				this.elementBindingSource.DataSource = elements;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void btn_Vincular_Click(object sender, EventArgs e)
		{

			var relEnum = (KeyValuePair<ElementRelationEnum, string>)cb_Relacao.SelectedItem;
			ElementRelationEnum relation = (ElementRelationEnum)relEnum.Key;

			try
			{

				foreach (DataGridViewRow row in dg_Elementos.SelectedRows)
				{
					var rowVal = row.Cells[0].Value;
					if (rowVal != null)
					{
						int idElemento = (int)rowVal;

						ElementElementRelationship rel = new ElementElementRelationship();
						rel.ReferenceComponentId = element.ElementId;
						rel.ReferredComponentId = idElemento;
						rel.Relation = relation;

						_relacaoElementoRepository.AddNew(rel);

						if (relation == ElementRelationEnum.seconecta)
						{
							ElementElementRelationship rel2 = new ElementElementRelationship();
							rel2.ReferenceComponentId = idElemento;
							rel2.ReferredComponentId = element.ElementId;
							rel2.Relation = relation;

							_relacaoElementoRepository.AddNew(rel2);
						}
					}
				}

				Frm_Element frm = (Frm_Element)_origemForm;
				frm.refresh_Elements();
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

		private void txt_Search_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				loadElements(txt_Search.Text);
			}
		}

		private void btn_Search_Click(object sender, EventArgs e)
		{
			loadElements(txt_Search.Text);
		}

		private void btn_Clean_Click(object sender, EventArgs e)
		{
			loadElements();
		}

		private void txt_Search_TextChanged(object sender, EventArgs e)
		{

		}

		private void label3_Click(object sender, EventArgs e)
		{
		}
	}
}
