using Microsoft.EntityFrameworkCore;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MSCMD.Forms
{
	public partial class Frm_Resources : Form
	{
		private static MscmdContext context;
		private HumanResourceRepository _humanResourceRepository;
		public Frm_Resources()
		{
			Configure();
			InitializeComponent();
		}

		private void Configure()
		{
			context = new MscmdContext();
			_humanResourceRepository = new HumanResourceRepository(context);
		}

		private void organizaçãoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Frm_Organization forg = new Frm_Organization();
			forg.Show();
			this.Close();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			context.Database.EnsureCreated();

			this.pessoaBindingSource.DataSource = _humanResourceRepository.getBindingList();

		}

		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);

			context?.Dispose();
			//context = null;
		}



		private void btn_Save_Click(object sender, EventArgs e)
		{
			try
			{
				_humanResourceRepository.saveContextChanges();
				this.dg_HumanResource.Refresh();
			}
			catch
			{
				MessageBox.Show("O nome deve ser preenchido.", "Erro ao salvar");
			}

		}

		private void btn_ImportPessoas_Click(object sender, EventArgs e)
		{
			Frm_ImportCsv form = new Frm_ImportCsv(Model.ScreenEnum.Resource, this);
			form.ShowDialog();
			refresh_Elementos();
		}


		public void refresh_Elementos()
		{
			this.pessoaBindingSource.DataSource = _humanResourceRepository.getBindingList();
		}

		private void btn_Delete_Click(object sender, EventArgs e)
		{
			HumanResource hr = GetHumanResourceSelected();
			if (hr != null)
			{
				DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja deletar " + hr.Name + "?", "Deletar Recurso", MessageBoxButtons.YesNo);

				if (dialogResult == DialogResult.Yes)
				{
					_humanResourceRepository.Delete(hr);
					MessageBox.Show("Item deletado com sucesso.");
					this.dg_HumanResource.Refresh();
				}
			}
			else
			{
				MessageBox.Show("Nenhum item selecionado.");
			}
		}

		private HumanResource GetHumanResourceSelected()
		{
			if (dg_HumanResource.SelectedRows.Count > 0)
			{
				DataGridViewRow row = new DataGridViewRow();
				row = dg_HumanResource.SelectedRows[0];
				int id = (int)row.Cells[0].Value;

				if (id != 0)
				{

					HumanResource hr = _humanResourceRepository.FindBy(id);
					return hr;
				}
				else
				{
					return null;
				}
			}
			else
			{
				return null;
			}
		}

		private void Frm_Resources_Load(object sender, EventArgs e)
		{
			//dg_HumanResource.Col

			//dg_HumanResource.Columns[e.ColumnIndex].DataPropertyName == "Name"
			var col1 = dg_HumanResource.Columns[4];

			DataGridViewComboBoxColumn col = (DataGridViewComboBoxColumn)dg_HumanResource.Columns[4];

			//DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
			col.DataSource = Enum.GetValues(typeof(PersonType));
			col.ValueType = typeof(PersonType);
		}

		private void dg_HumanResource_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{

			MessageBox.Show(e.Exception.Message);

		}

		private void btn_ExportCsv_Click(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					try
					{
						List<HumanResource> list = _humanResourceRepository.ListAll().ToList();

						string fileName = "recursos.csv";
						string destFile = Path.Combine(fbd.SelectedPath, fileName);

						WriteCustomCSV.ResourceToCSV(list, destFile);

					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Aviso");
					}
				}
			}
		}

		private void dg_HumanResource_Leave(object sender, EventArgs e)
		{
			try
			{
				_humanResourceRepository.saveContextChanges();
				this.dg_HumanResource.Refresh();
			}
			catch
			{
				MessageBox.Show("O nome deve ser preenchido.", "Erro ao salvar");
			}
		}
	}
}
