using MSCMD.Model;
using MSCMD.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSCMD.Forms.Activities
{
	public partial class Frm_Subprocess : Form
	{
		Form _originForm;
		private static MscmdContext _context;
		private SubprocessRepository _subprocessessRepository;
		private SubprocessActivityRepository _relRepository;

		private string saveSubprocessTitle = "Salvar Subprocesso";

		public Frm_Subprocess(Form originForm, MscmdContext context)
		{
			context.Database.EnsureCreated();
			_context = context;
			_originForm = originForm;
			_subprocessessRepository = new SubprocessRepository(context);
			_relRepository = new SubprocessActivityRepository();
			InitializeComponent();
		}

		private void Frm_Subprocess_Load(object sender, EventArgs e)
		{
			refresh_Subprocess();
		}

		public void refresh_Subprocess()
		{
			var list = _subprocessessRepository.ListAll().ToList();
			this.subprocessBindingSource.DataSource = list;

			Subprocess subprocess = GetSubprocessSelected();

			if (subprocess != null)
			{
				lbl_SubprocessName.Text = subprocess.Name;
				activityBindingSource.DataSource = subprocess.Activities;
			}
			else
			{
				lbl_SubprocessName.Text = "";
				activityBindingSource.DataSource = null;
			}
		}

		public void refresh_Activities()
		{
			Subprocess subprocess = GetSubprocessSelected();

			if (subprocess != null)
			{
				lbl_SubprocessName.Text = subprocess.Name;
				activityBindingSource.DataSource = null;

				var subprocessActivities = _relRepository.GetBySubprocess(subprocess.SubprocessId);
				if (subprocessActivities != null && subprocessActivities.ToList().Count > 0)
				{
					activityBindingSource.DataSource = subprocessActivities.Select(r => r.Activity).ToList();
				}
			}
			else
			{
				lbl_SubprocessName.Text = "";
				activityBindingSource.DataSource = null;
			}
		}

		private void btn_SaveSubprocesses_Click(object sender, EventArgs e)
		{
			if (dg_Subprocesses.DataSource != null)
			{
				var wms = dg_Subprocesses.DataSource;
				BindingSource bs = dg_Subprocesses.DataSource as BindingSource;
				if (bs.DataSource != null)
				{
					List<Subprocess> process = bs.DataSource as List<Subprocess>;
					if (process.Where(p => p.Name == "" || p.Name == null).Any())
					{
						MessageBox.Show("O nome do Subprocesso não pode ser vazio.", saveSubprocessTitle, MessageBoxButtons.OK);
					}
					else
					{
						_subprocessessRepository.SaveList(process);
						MessageBox.Show("Alterações salvas com sucesso.", saveSubprocessTitle, MessageBoxButtons.OK);

						Frm_Activity frm = (Frm_Activity)_originForm;
						frm.loadSubprocess();
					}
				}
				else
				{
					MessageBox.Show("Não há itens a serem salvos.", saveSubprocessTitle, MessageBoxButtons.OK);
				}



			}
			else
			{
				MessageBox.Show("Não há itens a serem salvos.", saveSubprocessTitle, MessageBoxButtons.OK);
			}
		}

		private void btn_AddActivity_Click(object sender, EventArgs e)
		{

			Subprocess subprocess = GetSubprocessSelected();

			if (subprocess != null)
			{
				Frm_SubprocessActivity frm = new Frm_SubprocessActivity(subprocess, this);
				frm.ShowDialog();
			}
			else
			{
				MessageBox.Show("Nenhum item selecionado.");
			}

		}

		private Subprocess GetSubprocessSelected()
		{
			if (dg_Subprocesses.SelectedRows.Count > 0)
			{
				DataGridViewRow row = new DataGridViewRow();
				row = dg_Subprocesses.SelectedRows[0];
				if (row.Cells[0].Value != null)
				{
					int id = (int)row.Cells[0].Value;

					if (id == 0)
					{
						string cod = (string)row.Cells[1].Value;
						string nome = (string)row.Cells[2].Value;

						if (!string.IsNullOrEmpty(nome))
						{
							Subprocess s = new Subprocess()
							{
								Code = cod,
								Name = nome
							};

							_subprocessessRepository.AddNew(s);

							refresh_Subprocess();
							return s;
						}
						else
						{
							return null;
						}

					}
					else
					{
						Subprocess subprocess = _subprocessessRepository.FindBy(id);
						return subprocess;
					}
				}
				else { return null; }
			}
			else
			{
				return null;
			}
		}

		private void dg_Subprocesses_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			refresh_Activities();
		}

		private void btn_DeleteSubprocess_Click(object sender, EventArgs e)
		{
			Subprocess s = GetSubprocessSelected();
			if (s != null)
			{
				DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja deletar o item " + s.Name + "?", "Deletar", MessageBoxButtons.YesNo);

				if (dialogResult == DialogResult.Yes)
				{
					_subprocessessRepository.Delete(s);
					MessageBox.Show("Item deletado com sucesso.");
					refresh_Subprocess();
					refreshOriginForm();
				}
			}
			else
			{
				MessageBox.Show("Nenhum item selecionado");
			}
		}

		private void btn_DeleteActivity_Click(object sender, EventArgs e)
		{
			try
			{
				if (dg_Activities.SelectedRows.Count > 0)
				{
					DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja deletar as relações? Total: " + dg_Activities.SelectedRows.Count, "Deletar Relações", MessageBoxButtons.YesNo);
					if (dialogResult == DialogResult.Yes)
					{
						foreach (DataGridViewRow row in dg_Activities.SelectedRows)
						{
							int id = (int)row.Cells[0].Value;
							if (id != 0)
							{
								try
								{
									Subprocess s = GetSubprocessSelected();
									SubprocessActivity rel = _relRepository.GetBySubprocessActivity(s.SubprocessId, id);

									if (rel != null && s != null)
									{
										_relRepository.Delete(rel);
									}
								}
								catch
								{
									MessageBox.Show("Erro ao desvincular item.");
								}


							}
						}
						refresh_Activities();
					}
				}

			}
			catch
			{
				MessageBox.Show("Erro ao desvincular, selecione as atividades e tente novamente.");
			}
		}

		private void dg_Subprocesses_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			var rowVal = e.RowIndex;
			var row = dg_Subprocesses.Rows[rowVal];
			var ind = row.Cells[0].Value;


			if (ind != null)
			{
				int index = (int)ind;
				Subprocess subprocess = new Subprocess();

				if (index != 0)
				{
					subprocess = _subprocessessRepository.FindBy(index);
				}

				var name = row.Cells[2].Value;
				if (name != null)
				{
					string sName = (string)name;
					if (sName != "")
					{
						subprocess.Name = sName;
						subprocess.Code = (string)row.Cells[1].Value;

						_subprocessessRepository.Save(subprocess);
						refresh_Subprocess();
						refreshOriginForm();


					}
					else if ((string)dg_Subprocesses.Columns[e.ColumnIndex].DataPropertyName == "Name")
					{
						MessageBox.Show("O nome não pode ser vazio.");
					}
				}
				else if ((string)dg_Subprocesses.Columns[e.ColumnIndex].DataPropertyName == "Name")
				{
					MessageBox.Show("O nome não pode ser vazio.");
				}

			}
		}

		private void refreshOriginForm()
		{
			Frm_Activity frm = (Frm_Activity)_originForm;
			frm.loadSubprocess();
		}
	}
}
