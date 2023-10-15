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
	public partial class Frm_ElementActivityRelationship : Form
	{
		private Form _origemForm;
		private static MscmdContext _context = new MscmdContext();
		private ActivityRepository _atividadeRepository = new ActivityRepository(_context);
		private ActivityElementRelationshipRepository _relacaoAtividadeRepository = new ActivityElementRelationshipRepository(_context);
		Model.Element element;

		public Frm_ElementActivityRelationship(Model.Element elem, Form origem)
		{
			InitializeComponent();
			element = elem;
			_origemForm = origem;
		}



		private void Frm_VinculoElementoAtividade_Load(object sender, EventArgs e)
		{
			lbl_Codigo.Text = element.Code?.ToString();
			lbl_NomeElemento.Text = element.Name.ToString();
			loadDataSources();
		}

		private void loadDataSources()
		{
			loadactivities();

			cb_Relacao.DisplayMember = "Value";
			cb_Relacao.ValueMember = "Key";
			cb_Relacao.DataSource = Utility.EnumOf<RelationActivityComponentEnum>();

		}

		private void loadactivities(string searchString = null)
		{
			List<Activity> relacaoAtividade = _relacaoAtividadeRepository.GetByElement(element.ElementId).Select(r => r.Activity).ToList();

			List<Model.Activity> activities = new List<Model.Activity>();
			try
			{

				if (searchString != null && searchString != "")
				{
					activities = _atividadeRepository.ListAll().Except(relacaoAtividade).Where(x => (x.ActivityCode != null ? x.ActivityCode.ToLower().Contains(searchString.ToLower()) : false) || x.ActivityName.ToLower().Contains(searchString.ToLower())).ToList();
				}
				else
				{
					activities = _atividadeRepository.ListAll().Except(relacaoAtividade).ToList();
				}

				this.activityBindingSource.DataSource = activities;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}
		private void btn_Vincular_Click(object sender, EventArgs e)
		{
			var relEnum = (KeyValuePair<RelationActivityComponentEnum, string>)cb_Relacao.SelectedItem;
			RelationActivityComponentEnum relation = (RelationActivityComponentEnum)relEnum.Key;

			try
			{

				foreach (DataGridViewRow row in dg_Atividades.SelectedRows)
				{

					var rowVal = row.Cells[0].Value;
					if (rowVal != null)
					{
						int idAtividade = (int)rowVal;

						ActivityElementRelationship rel = new ActivityElementRelationship();
						rel.ActivityId = idAtividade;
						rel.ComponentId = element.ElementId;
						rel.Relation = relation;

						_relacaoAtividadeRepository.AddNew(rel);
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

		private void cb_Relacao_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void btn_Close_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void txt_Search_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				loadactivities(txt_Search.Text);
			}
		}

		private void btn_Search_Click(object sender, EventArgs e)
		{
			loadactivities(txt_Search.Text);
		}

		private void btn_Clean_Click(object sender, EventArgs e)
		{
			loadactivities();
		}
	}
}
