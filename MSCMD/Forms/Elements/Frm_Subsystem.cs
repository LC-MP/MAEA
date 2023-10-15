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

namespace MSCMD.Forms.Elements
{
	public partial class Frm_Subsystem : Form
	{
		Form _originForm;
		private static MscmdContext context;
		private SubsystemRepository _subsystemsRepository;
		private ElementSubsystemRepository _relRepository;

		private string saveSubsystemTitle = "Salvar Subsistema";
		public Frm_Subsystem(Form originForm, MscmdContext context)
		{
			context.Database.EnsureCreated();
			_originForm = originForm;
			_subsystemsRepository = new SubsystemRepository(context);
			_relRepository = new ElementSubsystemRepository();
			InitializeComponent();
		}

		private void Frm_Subsystem_Load(object sender, EventArgs e)
		{
			refresh_Subsystem();
		}


		public void refresh_Subsystem()
		{
			var list = _subsystemsRepository.ListAll().ToList();
			this.subsystemBindingSource.DataSource = list;

			refresh_Elements();
		}

		public void refresh_Elements()
		{
			Subsystem subsystem = GetSubsystemSelected();

			if (subsystem != null)
			{
				lbl_SubsystemName.Text = subsystem.Name;

				elementBindingSource.DataSource = null;

				var subsystemElement = _relRepository.GetBySubsystem(subsystem.SubsystemId);
				if (subsystemElement != null && subsystemElement.ToList().Count > 0)
				{
					elementBindingSource.DataSource = subsystemElement.Select(r => r.Element).ToList();
				}

			}
			else
			{
				lbl_SubsystemName.Text = "";
				elementBindingSource.DataSource = null;
			}
		}

		private Subsystem GetSubsystemSelected()
		{
			if (dg_Subsystem.SelectedRows.Count > 0)
			{
				DataGridViewRow row = new DataGridViewRow();
				row = dg_Subsystem.SelectedRows[0];
				if (row.Cells[0].Value != null)
				{
					int id = (int)row.Cells[0].Value;

					if (id != 0)
					{
						Subsystem subsystems = _subsystemsRepository.FindBy(id);
						return subsystems;
					}
					else
					{
						return null;
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
			refresh_Elements();
		}

		private void btn_SaveSubsystems_Click(object sender, EventArgs e)
		{
			if (dg_Subsystem.DataSource != null)
			{
				var wms = dg_Subsystem.DataSource;
				BindingSource bs = dg_Subsystem.DataSource as BindingSource;
				if (bs.DataSource != null)
				{
					List<Subsystem> subsystem = bs.DataSource as List<Subsystem>;
					if (subsystem.Where(p => p.Name == "" || p.Name == null).Any())
					{
						MessageBox.Show("O nome do Subsistema não pode ser vazio.", saveSubsystemTitle, MessageBoxButtons.OK);
					}
					else
					{
						_subsystemsRepository.SaveList(subsystem);
						MessageBox.Show("Alterações salvas com sucesso.", saveSubsystemTitle, MessageBoxButtons.OK);

						Frm_Element frm = (Frm_Element)_originForm;
						frm.loadSubsystem();
					}
				}
				else
				{
					MessageBox.Show("Não há itens a serem salvos.", saveSubsystemTitle, MessageBoxButtons.OK);
				}



			}
			else
			{
				MessageBox.Show("Não há itens a serem salvos.", saveSubsystemTitle, MessageBoxButtons.OK);
			}
		}

		private void btn_AddElement_Click(object sender, EventArgs e)
		{
			Subsystem subsystem = GetSubsystemSelected();

			if (subsystem != null)
			{
				Frm_SubsystemElement frm = new Frm_SubsystemElement(subsystem, this);
				frm.ShowDialog();
			}
			else
			{
				MessageBox.Show("Nenhum item selecionado.");
			}
		}

		private void btn_DeleteSubsystem_Click(object sender, EventArgs e)
		{
			Subsystem s = GetSubsystemSelected();
			if (s != null)
			{
				DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja deletar o item " + s.Name + "?", "Deletar", MessageBoxButtons.YesNo);

				if (dialogResult == DialogResult.Yes)
				{
					_subsystemsRepository.Delete(s);
					MessageBox.Show("Item deletado com sucesso.");
					refresh_Subsystem();
					refreshOriginForm();
				}
			}
			else
			{
				MessageBox.Show("Nenhum item selecionado");
			}
		}

		private void btn_DeleteElement_Click(object sender, EventArgs e)
		{
			try
			{
				if (dg_Elements.SelectedRows.Count > 0)
				{
					DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja deletar as relações? Total: " + dg_Elements.SelectedRows.Count, "Deletar Relações", MessageBoxButtons.YesNo);
					if (dialogResult == DialogResult.Yes)
					{
						foreach (DataGridViewRow row in dg_Elements.SelectedRows)
						{
							int id = (int)row.Cells[0].Value;
							if (id != 0)
							{
								try
								{
									Subsystem s = GetSubsystemSelected();
									ElementSubsystem rel = _relRepository.GetByElementSubsystem(s.SubsystemId, id);

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
						refresh_Elements();
					}
				}

			}
			catch
			{
				MessageBox.Show("Erro ao desvincular, selecione os elementos e tente novamente.");
			}

			//if (dg_Elements.SelectedRows.Count > 0)
			//{
			//	DataGridViewRow row = new DataGridViewRow();
			//	row = dg_Elements.SelectedRows[0];
			//	int id = (int)row.Cells[0].Value;

			//	if (id != 0)
			//	{

			//		DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja deletar a relação?", "Deletar Relação", MessageBoxButtons.YesNo);

			//		if (dialogResult == DialogResult.Yes)
			//		{
			//			try
			//			{
			//				Subsystem s = GetSubsystemSelected();
			//				ElementSubsystem rel = _relRepository.GetByElementSubsystem(s.SubsystemId, id);

			//				if (rel != null && s != null)
			//				{
			//					_relRepository.Delete(rel);
			//					refresh_Elements();

			//				}
			//			}
			//			catch
			//			{
			//				MessageBox.Show("Erro ao deletar item.");
			//			}
			//		}

			//	}
			//}
		}

		private void dg_Subsystem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			var rowVal = e.RowIndex;
			var row = dg_Subsystem.Rows[rowVal];
			var ind = row.Cells[0].Value;


			if (ind != null)
			{
				int index = (int)ind;
				Subsystem subsystem = new Subsystem();

				if (index != 0)
				{
					subsystem = _subsystemsRepository.FindBy(index);
				}

				var name = row.Cells[2].Value;
				if (name != null)
				{
					string sName = (string)name;
					if (sName != "")
					{
						subsystem.Name = sName;
						subsystem.Code = (string)row.Cells[1].Value;

						_subsystemsRepository.Save(subsystem);
						refresh_Subsystem();
						refreshOriginForm();


					}
					else if ((string)dg_Subsystem.Columns[e.ColumnIndex].DataPropertyName == "Name")
					{
						MessageBox.Show("O nome não pode ser vazio.");
					}
				}
				else if ((string)dg_Subsystem.Columns[e.ColumnIndex].DataPropertyName == "Name")
				{
					MessageBox.Show("O nome não pode ser vazio.");
				}

			}
		}

		private void refreshOriginForm()
		{
			Frm_Element frm = (Frm_Element)_originForm;
			frm.loadSubsystem();
		}
	}
}
