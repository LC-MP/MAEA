using MSCMD.Model;
using MSCMD.Repository;
using MSCMD.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace MSCMD.Forms
{
	public partial class Frm_AgentResourceRelationship : Form
	{
		private Form _origemForm;
		private static MscmdContext context = new MscmdContext();
		private HumanResourceRepository pessoaRepository = new HumanResourceRepository(context);
		private AgentResourceRelationshipRepository relacaoRepository = new AgentResourceRelationshipRepository(context);
		Agent funcao;
		public Frm_AgentResourceRelationship(Agent func, Form origem)
		{
			InitializeComponent();
			funcao = func;
			_origemForm = origem;
		}

		private void Frm_VinculoPessoaFuncao_Load(object sender, EventArgs e)
		{
			lbl_FuncaoCod.Text = funcao.Code?.ToString();
			lbl_NomeFunc.Text = funcao.Name.ToString();

			loadDataSources();
		}

		private void loadDataSources()
		{
			loadResources();

			cbox_Relacao.DisplayMember = "Value";
			cbox_Relacao.ValueMember = "Key";
			cbox_Relacao.DataSource = Utility.EnumOf<RelationEnum>();

		}

		private void loadResources(string searchString = null)
		{
			var relacaoPessoaFuncao = relacaoRepository.GetByAgent(funcao.AgentId).Select(r => r.Resource);
		
			List<HumanResource> resources = new List<HumanResource>();
			try
			{

				if (searchString != null && searchString != "")
				{
					resources = pessoaRepository.ListAll().Except(relacaoPessoaFuncao).Where(x => (x.Code != null ? x.Code.ToLower().Contains(searchString.ToLower()) : false) || x.Name.ToLower().Contains(searchString.ToLower())).ToList();
				}
				else
				{
					resources = pessoaRepository.ListAll().Except(relacaoPessoaFuncao).ToList();
				}

				this.humanResourceBindingSource.DataSource = resources;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}

		}


		private void btn_Salvar_Click(object sender, EventArgs e)
		{
			var relEnum = (KeyValuePair<RelationEnum, string>)cbox_Relacao.SelectedItem;
			RelationEnum relation = (RelationEnum)relEnum.Key;

			try
			{

				foreach (DataGridViewRow row in dataGridView1.SelectedRows)
				{
					int idPessoa = (int)row.Cells[0].Value;
					HumanResource pessoa = pessoaRepository.FindBy(idPessoa);

					AgentResourceRelationship rel = new AgentResourceRelationship();
					rel.ResourceId = pessoa.PersonId;
					rel.AgentId = funcao.AgentId;
					rel.Relation = relation;

					relacaoRepository.AddNew(rel);
				}

				Frm_Organization frm = (Frm_Organization)_origemForm;
				frm.refresh_Vinculo(funcao.AgentId);
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
			loadResources(txt_Search.Text);
		}

		private void btn_Clean_Click(object sender, EventArgs e)
		{
			loadResources();
		}

		private void txt_Search_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				loadResources(txt_Search.Text);
			}
		}
	}
}
