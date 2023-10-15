using MSCMD.Forms.Elements;
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

namespace MSCMD.Forms.OrganizationalDivision
{
	public partial class Frm_OrganizationalDivision : Form
	{
		Form _originForm;
		private static MscmdContext _context;
		private OrganizationRepository _sectorRepository;
		private OrganizationAgentRepository _relRepository;

		public Frm_OrganizationalDivision(Form originForm, MscmdContext context)
		{
			context.Database.EnsureCreated();
			_originForm = originForm;
			_sectorRepository = new OrganizationRepository(context);
			_relRepository = new OrganizationAgentRepository();
			_context = context;
			InitializeComponent();
		}

		private void Frm_OrganizationalDivision_Load(object sender, EventArgs e)
		{

			refresh_Sectors();
		}

		public void refresh_Sectors()
		{
			var list = _sectorRepository.ListAll().ToList();
			this.organizationBindingSource.DataSource = list;

			refresh_Agents();
		}

		public void refresh_Agents()
		{
			Organization sector = GetSectorSelected();

			if (sector != null)
			{
				lbl_SectorName.Text = sector.SectorName;
				agentBindingSource.DataSource = null;

				var agentOrg = _relRepository.GetByOrganization(sector.SectorId);
				if (agentOrg != null && agentOrg.ToList().Count > 0)
				{
					agentBindingSource.DataSource = agentOrg.Select(r => r.Agent).ToList();
				}
			}
			else
			{
				lbl_SectorName.Text = "";
				agentBindingSource.DataSource = null;
			}
		}

		private Organization GetSectorSelected()
		{
			if (dg_Organization.SelectedRows.Count > 0)
			{
				DataGridViewRow row = new DataGridViewRow();
				row = dg_Organization.SelectedRows[0];
				if (row.Cells[0].Value != null)
				{
					int id = (int)row.Cells[0].Value;

					if (id != 0)
					{
						Organization org = _sectorRepository.FindBy(id);
						return org;
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

		private void refreshOriginForm()
		{
			Frm_Organization frm = (Frm_Organization)_originForm;
			frm.load_Sectors();
		}


		private void dg_Organization_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			var rowVal = e.RowIndex;
			var row = dg_Organization.Rows[rowVal];
			var ind = row.Cells[0].Value;


			if (ind != null)
			{
				int index = (int)ind;
				Organization org = new Organization();

				if (index != 0)
				{
					org = _sectorRepository.FindBy(index);
				}

				var name = row.Cells[2].Value;
				if (name != null)
				{
					string sName = (string)name;
					if (sName != "")
					{
						org.SectorName = sName;
						org.Code = (string)row.Cells[1].Value;

						_sectorRepository.Save(org);
						refresh_Sectors();
						refreshOriginForm();


					}
					else if ((string)dg_Organization.Columns[e.ColumnIndex].DataPropertyName == "SectorName")
					{
						MessageBox.Show("O nome não pode ser vazio.");
					}
				}
				else if ((string)dg_Organization.Columns[e.ColumnIndex].DataPropertyName == "SectorName")
				{
					MessageBox.Show("O nome não pode ser vazio.");
				}

			}
		}

		private void btn_DeleteElement_Click(object sender, EventArgs e)
		{
			try
			{
				if (dg_Agents.SelectedRows.Count > 0)
				{
					DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja deletar as relações? Total: " + dg_Agents.SelectedRows.Count, "Deletar Relações", MessageBoxButtons.YesNo);
					if (dialogResult == DialogResult.Yes)
					{
						foreach (DataGridViewRow row in dg_Agents.SelectedRows)
						{
							int id = (int)row.Cells[0].Value;
							if (id != 0)
							{
								try
								{
									Organization org = GetSectorSelected();
									OrganizationAgent rel = _relRepository.GetByOrganizationAgent(org.SectorId, id);

									if (rel != null && org != null)
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
						refresh_Agents();
					}
				}

			}
			catch
			{
				MessageBox.Show("Erro ao desvincular, selecione as funções e tente novamente.");
			}


		}

		private void btn_AddElement_Click(object sender, EventArgs e)
		{
			Organization org = GetSectorSelected();

			if (org != null)
			{
				Frm_OrganizationAgent frm = new Frm_OrganizationAgent(org, this, _context);
				frm.ShowDialog();
			}
			else
			{
				MessageBox.Show("Nenhum item selecionado.");
			}
		}

		private void btn_DeleteOrganization_Click(object sender, EventArgs e)
		{
			Organization org = GetSectorSelected();
			if (org != null)
			{
				DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja deletar o item " + org.SectorName + "?", "Deletar", MessageBoxButtons.YesNo);

				if (dialogResult == DialogResult.Yes)
				{
					_sectorRepository.Delete(org);
					MessageBox.Show("Item deletado com sucesso.");
					refresh_Sectors();
					refreshOriginForm();
				}
			}
			else
			{
				MessageBox.Show("Nenhum item selecionado");
			}
		}

		private void btn_Save_Click(object sender, EventArgs e)
		{

		}

		private void dg_Organization_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			refresh_Agents();
		}
	}
}
