using MSCMD.Model;
using MSCMD.Repository;
using MSCMD.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Formats.Tar;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace MSCMD.Forms
{
	public partial class Frm_ImportCsv : Form
	{
		private ScreenEnum _screenEnum;
		private Form _frmOrigem;
		private static MscmdContext context;
		private ActivityRepository _activityRepository;
		private ElementRepository _elementRepository;
		private AgentRepository _agentRepository;
		private ActivityActivityRelationshipRepository _activityRelationRepository;
		private ActivityElementRelationshipRepository _activityElementRelationRepository;
		private AgentActivityRelationshipRepository _activityAgentRelationRepository;
		private AgentResourceRelationshipRepository _agentResourceRelationRepository;
		private ElementElementRelationshipRepository _elementRelationRepository;
		private OrganizationRepository _organizationRepository;
		private SubsystemRepository _subsystemRepository;
		private SubprocessRepository _subprocessRepository;
		private HumanResourceRepository _resourceRepository;
		private Object? filteredGroup = null;
		public Frm_ImportCsv(ScreenEnum screenEnum, Form frmOrigem, Object? group = null, MscmdContext? contextOrg = null)
		{
			context = contextOrg ?? new MscmdContext();
			context.ChangeTracker.DetectChanges();
			_screenEnum = screenEnum;
			_frmOrigem = frmOrigem;
			filteredGroup = group;

			_activityRepository = new ActivityRepository(context);
			_elementRepository = new ElementRepository(context);
			_agentRepository = new AgentRepository(context);
			_activityRelationRepository = new ActivityActivityRelationshipRepository(context);
			_activityElementRelationRepository = new ActivityElementRelationshipRepository(context);
			_activityAgentRelationRepository = new AgentActivityRelationshipRepository(context);
			_agentResourceRelationRepository = new AgentResourceRelationshipRepository(context);
			_elementRelationRepository = new ElementElementRelationshipRepository(context);
			_organizationRepository = new OrganizationRepository(context);
			_subsystemRepository = new SubsystemRepository(context);
			_subprocessRepository = new SubprocessRepository(context);
			_resourceRepository = new HumanResourceRepository(context);

			InitializeComponent();
		}

		private void Frm_ImportCsv_Load(object sender, EventArgs e)
		{
			Screen scr = Screen.FromPoint(this.Location);
			this.Location = new Point(scr.WorkingArea.Right - this.Width, scr.WorkingArea.Top);

			lbl_StatusMessage.Text = "";
			switch (_screenEnum)
			{
				case ScreenEnum.Agent:
					lbl_Titulo.Text = "Importar Funções";
					if (filteredGroup != null)
					{
						Organization group = (Organization)filteredGroup;
						lbl_Titulo.Text += ": " + group.SectorName;
					}
					break;
				case ScreenEnum.Resource:
					lbl_Titulo.Text = "Importar Recursos";
					break;
				case ScreenEnum.Element:
					lbl_Titulo.Text = "Importar Elementos";
					if (filteredGroup != null)
					{
						Subsystem group = (Subsystem)filteredGroup;
						lbl_Titulo.Text += ": " + group.Name;
					}
					break;
				case ScreenEnum.Activity:
					lbl_Titulo.Text = "Importar Atividades";
					if (filteredGroup != null)
					{
						Subprocess group = (Subprocess)filteredGroup;
						lbl_Titulo.Text += ": " + group.Name;
					}
					break;
				case ScreenEnum.Organization:
					lbl_Titulo.Text = "Importar Divisões Organizacionais";

					break;
				case ScreenEnum.Subsystem:
					lbl_Titulo.Text = "Importar Subsistemas";
					break;
				case ScreenEnum.Subprocess:
					lbl_Titulo.Text = "Importar Subprocessos";
					break;
				case ScreenEnum.ActivityRelationship:
					lbl_Titulo.Text = "Importar relações de atividades";
					break;
				case ScreenEnum.ElementRelationship:
					lbl_Titulo.Text = "Importar relações de elementos";
					break;
				case ScreenEnum.ActivityElementRelationship:
				case ScreenEnum.ElementActivityRelationship:
					lbl_Titulo.Text = "Importar relações de atividades e elementos";
					break;
				case ScreenEnum.ActivityAgentRelationship:
				case ScreenEnum.AgentActivityRelationship:
					lbl_Titulo.Text = "Importar relações de atividades e funções";
					break;
				case ScreenEnum.AgentResourceRelationship:
					lbl_Titulo.Text = "Importar relações de funções e recursos";
					break;
				default:
					lbl_Titulo.Text = "Importar CSV";
					break;
			}

		}

		private void btn_SelectFile_Click(object sender, EventArgs e)
		{
			try
			{

				OpenFileDialog dialog = new OpenFileDialog();
				dialog.ShowDialog();

				if (dialog.FileName != "")
				{
					if (dialog.FileName.EndsWith(".csv"))
					{

						string SourceURl = "";

						DataTable dtNew = new DataTable();
						dtNew = CsvReader.GetDataTabletFromCSVFile(dialog.FileName);

						lbl_txtFile.Text = dialog.SafeFileName;
						SourceURl = dialog.FileName;

						if (dtNew.Rows != null && dtNew.Rows.ToString() != String.Empty)
						{
							dgv_Itens.DataSource = dtNew;
						}
						if (dgv_Itens.Rows.Count == 0)
						{
							//btn_Save.Enabled = false;
							dgv_Itens.DataSource = new DataTable();
							lbl_txtFile.Text = "";
							MessageBox.Show("Não há dados no arquivo selecionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
						else
						{

							if (_screenEnum == ScreenEnum.ActivityRelationship || _screenEnum == ScreenEnum.ElementRelationship ||
								_screenEnum == ScreenEnum.ActivityElementRelationship || _screenEnum == ScreenEnum.ActivityAgentRelationship ||
								_screenEnum == ScreenEnum.ElementActivityRelationship || _screenEnum == ScreenEnum.AgentActivityRelationship ||
								_screenEnum == ScreenEnum.AgentResourceRelationship)
							{
								ReadRelationshipCSV(dtNew);
							}
							else
							{
								ReadModelCSV(dtNew);
							}
						}

					}
					else
					{
						dgv_Itens.DataSource = new DataTable();
						lbl_txtFile.Text = "";
						MessageBox.Show("Formato de arquivo inválido, por favor selecione um arquivo .csv.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro ao processar o arquivo. Verifique se o arquivo está no formato correto e se os dados foram preenchidos corretamente.", "Aviso");
				dgv_Itens.DataSource = new DataTable();
			}
		}

		private void ReadModelCSV(DataTable dtNew)
		{
			int ImportedRecord = 0, inValidItem = 0;

			foreach (DataGridViewRow row in dgv_Itens.Rows)
			{
				if (Convert.ToString(row.Cells["codigo"].Value) == "" || row.Cells["codigo"].Value == null)// || Convert.ToString(row.Cells["ItemName"].Value) == "" || row.Cells["ItemName"].Value == null)
				{
					row.DefaultCellStyle.BackColor = Color.LightSalmon;
					inValidItem += 1;
				}
				else
				{
					ImportedRecord += 1;
				}
			}
		}

		private void ReadRelationshipCSV(DataTable dtNew)
		{
			int ImportedRecord = 0, inValidItem = 0;

			foreach (DataGridViewRow row in dgv_Itens.Rows)
			{

				switch (_screenEnum)
				{
					case ScreenEnum.ActivityRelationship:
						if (Convert.ToString(row.Cells["COD_A"].Value) == "" || row.Cells["COD_A"].Value == null || row.Cells["relação"].Value == null ||
							Convert.ToString(row.Cells["relação"].Value) == "" || (Convert.ToString(row.Cells["relação"].Value) != "0" && (Convert.ToString(row.Cells["COD_A_R"].Value) == "" ||
							row.Cells["COD_A_R"].Value == null)))
						{
							row.DefaultCellStyle.BackColor = Color.LightSalmon;
							inValidItem += 1;
						}
						else
						{
							ImportedRecord += 1;
						}

						break;
					case ScreenEnum.ElementRelationship:
						if (Convert.ToString(row.Cells["COD_E"].Value) == "" || row.Cells["COD_E"].Value == null || row.Cells["relação"].Value == null ||
							Convert.ToString(row.Cells["relação"].Value) == "" || Convert.ToString(row.Cells["COD_E_R"].Value) == "" ||
							row.Cells["COD_E_R"].Value == null)
						{
							row.DefaultCellStyle.BackColor = Color.LightSalmon;
							inValidItem += 1;
						}
						else
						{
							ImportedRecord += 1;
						}
						break;
					case ScreenEnum.ActivityElementRelationship:
					case ScreenEnum.ElementActivityRelationship:
						if (Convert.ToString(row.Cells["COD_A"].Value) == "" || row.Cells["COD_A"].Value == null || row.Cells["relação"].Value == null ||
							Convert.ToString(row.Cells["relação"].Value) == "" || Convert.ToString(row.Cells["COD_E"].Value) == "" ||
							row.Cells["COD_E"].Value == null)
						{
							row.DefaultCellStyle.BackColor = Color.LightSalmon;
							inValidItem += 1;
						}
						else
						{
							ImportedRecord += 1;
						}
						break;
					case ScreenEnum.ActivityAgentRelationship:
					case ScreenEnum.AgentActivityRelationship:
						if (Convert.ToString(row.Cells["COD_A"].Value) == "" || row.Cells["COD_A"].Value == null ||
							Convert.ToString(row.Cells["COD_F"].Value) == "" || row.Cells["COD_F"].Value == null)
						{
							row.DefaultCellStyle.BackColor = Color.LightSalmon;
							inValidItem += 1;
						}
						else
						{
							ImportedRecord += 1;
						}
						break;
					case ScreenEnum.AgentResourceRelationship:
						if (Convert.ToString(row.Cells["COD_R"].Value) == "" || row.Cells["COD_R"].Value == null ||
							Convert.ToString(row.Cells["COD_F"].Value) == "" || row.Cells["COD_F"].Value == null)
						{
							row.DefaultCellStyle.BackColor = Color.LightSalmon;
							inValidItem += 1;
						}
						else
						{
							ImportedRecord += 1;
						}
						break;
					default:
						break;
				}


			}
		}

		public DataTable ReverseOrder(DataTable dataTable)
		{
			return dataTable.AsEnumerable().Reverse().CopyToDataTable();
		}

		private void btn_Save_Click(object sender, EventArgs e)
		{
			if (dgv_Itens.DataSource != null)
			{
				DataTable dtItem = (DataTable)(dgv_Itens.DataSource);
				if (dtItem.Rows.Count > 0)
				{

					SaveItens(dtItem);
				}
				else
				{
					MessageBox.Show("Nenhum item para importar.", "Importar CSV");
				}
			}
		}

		private void btn_Save_Selected_Click(object sender, EventArgs e)
		{
			if (dgv_Itens.DataSource != null)
			{
				var dtSource = (DataTable)(dgv_Itens.DataSource);

				if (dtSource.Rows.Count > 0)
				{
					var dt = dtSource.Clone();

					foreach (DataGridViewRow row in dgv_Itens.SelectedRows)
					{
						dt.ImportRow(dtSource.Rows[row.Index]);
					}

					SaveItens(ReverseOrder(dt));
				}
				else
				{
					MessageBox.Show("Nenhum item para importar.", "Importar CSV");
				}
			}
		}

		private void SaveItens(DataTable dtItem)
		{
			Cursor.Current = Cursors.WaitCursor;

			try
			{
				if (dgv_Itens.DataSource != null)
				{
					//DataTable dtItem = (DataTable)(dgv_Itens.DataSource);
					if (dtItem.Rows.Count > 0)
					{
						switch (_screenEnum)
						{

							case ScreenEnum.Agent:
								List<Agent> funcaoList = new List<Agent>();
								List<OrganizationAgent> groups = new List<OrganizationAgent>();
								OrganizationAgentRepository rep = new OrganizationAgentRepository();
								foreach (DataRow dr in dtItem.Rows)
								{
									Agent novaFuncao;

									if (dr["ID"] != null && (Convert.ToString(dr["ID"])) != "")
									{
										try
										{
											novaFuncao = _agentRepository.FindBy(Int32.Parse(Convert.ToString(dr["ID"])));
										}
										catch
										{
											novaFuncao = new Agent();
										}

									}
									else
									{
										novaFuncao = new Agent();
									}

									novaFuncao.Code = Convert.ToString(dr["codigo"]) ?? "";
									novaFuncao.Name = Convert.ToString(dr["nome_funcao"]) ?? "";
									novaFuncao.Description = Convert.ToString(dr["descricao_funcao"]) ?? "";


									if (dr["divisao"] != null && (Convert.ToString(dr["divisao"])) != "")
									{
										string division = Convert.ToString(dr["divisao"]);
										string[] words = division.Split(',');
										novaFuncao.Organizations.Clear();
										foreach (var word in words)
										{
											Organization org = _organizationRepository.FindByCode(word);
											if (org != null)
											{
												novaFuncao.Organizations.Add(org);

											}

										}

									}
									funcaoList.Add(novaFuncao);

								}

								if (funcaoList.Count > 0)
								{
									_agentRepository.ImportList(funcaoList);

									if (filteredGroup != null)
									{
										Organization group = (Organization)filteredGroup;

										foreach (var item in funcaoList)
										{
											OrganizationAgent newRel = new OrganizationAgent()
											{
												AgentId = item.AgentId,
												OrganizationId = group.SectorId
											};
											rep.AddNew(newRel);
										}
									}


									Frm_Organization frm = (Frm_Organization)_frmOrigem;
									frm.refresh_Agents();
									dgv_Itens.DataSource = new DataTable();
									lbl_StatusMessage.Text = "Funções importadas com sucesso, Total: " + funcaoList.Count;
									//MessageBox.Show("Funções importadas com sucesso, Total: " + funcaoList.Count, "Importar CSV", MessageBoxButtons.OK);

								}
								break;


							case ScreenEnum.Resource:
								List<HumanResource> personList = new List<HumanResource>();
								foreach (DataRow dr in dtItem.Rows)
								{
									HumanResource newPerson;

									if (dr["ID"] != null && (Convert.ToString(dr["ID"])) != "")
									{
										try
										{
											newPerson = _resourceRepository.FindBy(Int32.Parse(Convert.ToString(dr["ID"])));
										}
										catch
										{
											newPerson = new HumanResource();
										}

									}
									else
									{
										newPerson = new HumanResource();
									}

									newPerson.Code = Convert.ToString(dr["codigo"]) ?? "";
									newPerson.Name = Convert.ToString(dr["nome"]) ?? "";
									newPerson.Competences = Convert.ToString(dr["competencias"]);
									newPerson.Contact = Convert.ToString(dr["contato"]) ?? "";
									newPerson.Registry = Convert.ToString(dr["registro"]) ?? "";

									string tipoPessoa = Convert.ToString(dr["tipo_pessoa"]) ?? "";
									tipoPessoa = tipoPessoa.ToLower();
									if (tipoPessoa == "fisica" || tipoPessoa == "física")
									{
										newPerson.Type = PersonType.Fisica;
									}
									else if (tipoPessoa == "juridica" || tipoPessoa == "jurídica")
									{
										newPerson.Type = PersonType.Juridica;
									}

									personList.Add(newPerson);

								}
								if (personList.Count > 0)
								{

									HumanResourceRepository _rep = new HumanResourceRepository(context);
									_rep.ImportList(personList);

									Frm_Resources frm = (Frm_Resources)_frmOrigem;
									//frm.refresh_Pessoas();
									dgv_Itens.DataSource = new DataTable();
									lbl_StatusMessage.Text = "Recursos importados com sucesso, Total: " + personList.Count;
									//MessageBox.Show("Recursos importados com sucesso, Total: " + personList.Count, "Importar CSV", MessageBoxButtons.OK);

								}
								break;


							case ScreenEnum.Element:
								List<Model.Element> elementList = new List<Model.Element>();
								foreach (DataRow dr in dtItem.Rows)
								{

									Model.Element newElement;

									if (dr["ID"] != null && (Convert.ToString(dr["ID"])) != "")
									{
										try
										{
											newElement = _elementRepository.FindBy(Int32.Parse(Convert.ToString(dr["ID"])));
										}
										catch
										{
											newElement = new Element();
										}

									}
									else
									{
										newElement = new Element();
									}

									newElement.Code = Convert.ToString(dr["codigo"]) ?? "";
									newElement.Name = Convert.ToString(dr["nome_elemento"]) ?? "";
									newElement.Type = Convert.ToString(dr["tipo_elemento"]) ?? "";
									newElement.ExternalIdentifier = Convert.ToString(dr["identificador_externo"]) ?? "";
									newElement.ComponentClass = Convert.ToString(dr["classe"]) ?? "";
									newElement.SurfaceType = Convert.ToString(dr["tipo_superficie"]) ?? "";

									if (dr["subsistema"] != null && (Convert.ToString(dr["subsistema"])) != "")
									{
										string group = Convert.ToString(dr["subsistema"]);
										string[] words = group.Split(',');
										newElement.Subsystems.Clear();
										foreach (var word in words)
										{
											Subsystem system = _subsystemRepository.FindByCode(word);
											if (system != null)
											{
												newElement.Subsystems.Add(system);

											}


										}

									}
									elementList.Add(newElement);

								}
								if (elementList.Count > 0)
								{

									_elementRepository.ImportList(elementList);


									if (filteredGroup != null)
									{
										Subsystem group = (Subsystem)filteredGroup;
										ElementSubsystemRepository relRep = new ElementSubsystemRepository();
										foreach (var item in elementList)
										{
											ElementSubsystem newRel = new ElementSubsystem()
											{
												ElementId = item.ElementId,
												SubsystemId = group.SubsystemId
											};
											relRep.AddNew(newRel);
										}
									}

									Frm_Element frm = (Frm_Element)_frmOrigem;
									frm.refresh_Elements();
									dgv_Itens.DataSource = new DataTable();
									lbl_StatusMessage.Text = "Elementos importados com sucesso, Total: " + elementList.Count;
									//MessageBox.Show("Elementos importados com sucesso, Total: " + elementList.Count, "Importar CSV", MessageBoxButtons.OK);

								}
								break;


							case ScreenEnum.Activity:
								List<Activity> activityList = new List<Activity>();
								foreach (DataRow dr in dtItem.Rows)
								{
									Activity newActivity;

									if (dr["ID"] != null && (Convert.ToString(dr["ID"])) != "")
									{
										try
										{
											newActivity = _activityRepository.FindBy(Int32.Parse(Convert.ToString(dr["ID"])));
										}
										catch
										{
											newActivity = new Activity();
										}

									}
									else
									{
										newActivity = new Activity();
									}

									newActivity.ActivityCode = Convert.ToString(dr["codigo"]) ?? "";
									newActivity.ActivityName = Convert.ToString(dr["nome_atividade"]) ?? "";
									newActivity.ActivityDescription = Convert.ToString(dr["descricao"]) ?? "";
									newActivity.RequiredCompetence = Convert.ToString(dr["competencia"]) ?? "";
									//novaAtividade.TipoSuperficie = Convert.ToString(dr["Duracao"]) ?? "";

									string periodicity1 = Convert.ToString(dr["periodicidade1"]) ?? "";
									periodicity1 = Utility.RemoveAccents(periodicity1.ToLower());

									string periodicity2 = Convert.ToString(dr["periodicidade2"]) ?? "";
									periodicity2 = Utility.RemoveAccents(periodicity2.ToLower());

									switch (periodicity1)
									{
										case "manha":
											newActivity.Periodicity1 = Periodicity1Enum.Manha;
											break;
										case "tarde":
											newActivity.Periodicity1 = Periodicity1Enum.Tarde;
											break;
										case "noite":
											newActivity.Periodicity1 = Periodicity1Enum.Noite;
											break;
										case "madrugada":
											newActivity.Periodicity1 = Periodicity1Enum.Madrugada;
											break;
										case "integral":
											newActivity.Periodicity1 = Periodicity1Enum.Integral;
											break;
										default: break;
									}

									switch (periodicity2)
									{
										case "diario":
											newActivity.Periodicity2 = Periodicity2Enum.Diario;
											break;
										case "semanal":
											newActivity.Periodicity2 = Periodicity2Enum.Semanal;
											break;
										case "mensal":
											newActivity.Periodicity2 = Periodicity2Enum.Mensal;
											break;
										case "ocasional":
											newActivity.Periodicity2 = Periodicity2Enum.Ocasional;
											break;
										default: break;
									}

									if (dr["subprocesso"] != null && (Convert.ToString(dr["subprocesso"])) != "")
									{
										string group = Convert.ToString(dr["subprocesso"]);
										string[] words = group.Split(',');
										newActivity.Subprocesses.Clear();
										foreach (var word in words)
										{
											Subprocess system = _subprocessRepository.FindByCode(word);
											if (system != null)
											{
												newActivity.Subprocesses.Add(system);
											}
										}

									}
									activityList.Add(newActivity);

								}
								if (activityList.Count > 0)
								{
									_activityRepository.ImportList(activityList);


									if (filteredGroup != null)
									{
										Subprocess group = (Subprocess)filteredGroup;
										SubprocessActivityRepository relationRep = new SubprocessActivityRepository();
										foreach (var item in activityList)
										{
											SubprocessActivity newRel = new SubprocessActivity()
											{
												ActivityId = item.ActivityId,
												SubprocessId = group.SubprocessId
											};
											relationRep.AddNew(newRel);
										}
									}

									Frm_Activity frm = (Frm_Activity)_frmOrigem;
									frm.refresh_Activities();
									dgv_Itens.DataSource = new DataTable();
									lbl_StatusMessage.Text = "Elementos importados com sucesso, Total: " + activityList.Count;
									//MessageBox.Show("Elementos importados com sucesso, Total: " + activityList.Count, "Importar CSV", MessageBoxButtons.OK);

								}
								break;
							case ScreenEnum.Organization:
								List<Organization> sectorList = new List<Organization>();
								foreach (DataRow dr in dtItem.Rows)
								{

									Organization newElement;
									if (dr["ID"] != null && (Convert.ToString(dr["ID"])) != "")
									{
										try
										{
											newElement = _organizationRepository.FindBy(Int32.Parse(Convert.ToString(dr["ID"])));
										}
										catch
										{
											newElement = new Organization(); ;
										}

									}
									else
									{
										newElement = new Organization();
									}

									newElement.Code = Convert.ToString(dr["codigo"]) ?? "";
									newElement.SectorName = Convert.ToString(dr["nome_setor"]) ?? "";
									newElement.Description = Convert.ToString(dr["descricao_setor"]) ?? "";

									sectorList.Add(newElement);

								}
								if (sectorList.Count > 0)
								{

									_organizationRepository.ImportList(sectorList);

									Frm_Organization frm = (Frm_Organization)_frmOrigem;
									frm.load_Sectors();
									dgv_Itens.DataSource = new DataTable();
									lbl_StatusMessage.Text = "Setores importados com sucesso, Total: " + sectorList.Count;
									//MessageBox.Show("Setores importados com sucesso, Total: " + sectorList.Count, "Importar CSV", MessageBoxButtons.OK);

								}
								break;
							case ScreenEnum.Subsystem:
								List<Subsystem> subsystemList = new List<Subsystem>();
								foreach (DataRow dr in dtItem.Rows)
								{
									Subsystem newElement;

									if (dr["ID"] != null && (Convert.ToString(dr["ID"])) != "")
									{
										try
										{
											newElement = _subsystemRepository.FindBy(Int32.Parse(Convert.ToString(dr["ID"])));
										}
										catch
										{
											newElement = new Subsystem(); ;
										}

									}
									else
									{
										newElement = new Subsystem();
									}

									newElement.Code = Convert.ToString(dr["codigo"]) ?? "";
									newElement.Name = Convert.ToString(dr["nome_sistema"]) ?? "";

									subsystemList.Add(newElement);

								}
								if (subsystemList.Count > 0)
								{
									SubsystemRepository _rep = new SubsystemRepository(context);
									_rep.ImportList(subsystemList);

									Frm_Element frm = (Frm_Element)_frmOrigem;
									frm.loadSubsystem();
									dgv_Itens.DataSource = new DataTable();
									lbl_StatusMessage.Text = "Subsistemas importados com sucesso, Total: " + subsystemList.Count;
									//MessageBox.Show("Subsistemas importados com sucesso, Total: " + subsystemList.Count, "Importar CSV", MessageBoxButtons.OK);

								}
								break;
							case ScreenEnum.Subprocess:
								List<Subprocess> subprocessList = new List<Subprocess>();
								foreach (DataRow dr in dtItem.Rows)
								{
									Subprocess newElement;

									if (dr["ID"] != null && (Convert.ToString(dr["ID"])) != "")
									{
										try
										{
											newElement = _subprocessRepository.FindBy(Int32.Parse(Convert.ToString(dr["ID"])));
										}
										catch
										{
											newElement = new Subprocess(); ;
										}

									}
									else
									{
										newElement = new Subprocess();
									}

									newElement.Code = Convert.ToString(dr["codigo"]) ?? "";
									newElement.Name = Convert.ToString(dr["nome_processo"]) ?? "";
									subprocessList.Add(newElement);

								}
								if (subprocessList.Count > 0)
								{
									SubprocessRepository _rep = new SubprocessRepository(context);
									_rep.ImportList(subprocessList);

									Frm_Activity frm = (Frm_Activity)_frmOrigem;
									frm.loadSubprocess();
									dgv_Itens.DataSource = new DataTable();
									lbl_StatusMessage.Text = "Subprocessos importados com sucesso, Total: " + subprocessList.Count;
									//MessageBox.Show("Subprocessos importados com sucesso, Total: " + subprocessList.Count, "Importar CSV", MessageBoxButtons.OK);

								}
								break;

							case ScreenEnum.ActivityRelationship:
								SaveActivityRelationship(dtItem);
								break;
							case ScreenEnum.ElementRelationship:
								SaveElementRelationship(dtItem);
								break;
							case ScreenEnum.ActivityElementRelationship:
							case ScreenEnum.ElementActivityRelationship:
								SaveActivityElementRelationship(dtItem);
								break;
							case ScreenEnum.ActivityAgentRelationship:
							case ScreenEnum.AgentActivityRelationship:
								SaveActivityAgentRelationship(dtItem);
								break;
							case ScreenEnum.AgentResourceRelationship:
								SaveAgentResourceRelationship(dtItem);
								break;
							default:
								break;
						}
					}
					else
					{
						MessageBox.Show("Nenhum item para importar.", "Importar CSV");
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro ao processar entradas. Verifique se o arquivo está no formato correto.");
			}
			Cursor.Current = Cursors.Default;
		}

		private void SaveActivityRelationship(DataTable dt)
		{
			List<ActivityActivityRelationship> relList = new List<ActivityActivityRelationship>();
			List<string> notFoundCodes = new List<string>();
			foreach (DataRow dr in dt.Rows)
			{
				string code = Convert.ToString(dr["COD_A"]) ?? "";
				string codeRel = Convert.ToString(dr["COD_A_R"]) ?? "";
				if (code != "" && codeRel != "")
				{
					Activity? referenceActivity = getActivityByCode(code);

					if (referenceActivity != null)
					{
						Activity? referredActivity = getActivityByCode(codeRel);

						if (referredActivity != null)
						{
							//bool relationshipExist = _activityRelationRepository.RelationAlreadyExist(referenceActivity.ActivityId, referredActivity.ActivityId);

							bool relationshipExist = _activityRelationRepository.RelationAlreadyExist(code, codeRel);

							//continue if relationship doesnt exist
							if (!relationshipExist)
							{

								//int rel = Convert.ToInt32(dr["relação"]);
								//int rel = Convert.ToInt32(dr["relação"]);

								ActivityRelationEnum? relEnum;

								if (int.TryParse(dr["relação"].ToString(), out int result))
								{
									switch (result)
									{
										case 1:
											relEnum = ActivityRelationEnum.precedidapor;
											break;
										case 2:
											relEnum = ActivityRelationEnum.iniciadepoisde;
											break;
										case 3:
											relEnum = ActivityRelationEnum.terminaantesde;
											break;
										case 4:
											relEnum = ActivityRelationEnum.terminacom;
											break;
										case 5:
											relEnum = ActivityRelationEnum.iniciacom;
											break;
										case 6:
											relEnum = ActivityRelationEnum.ocorredurante;
											break;
										case 7:
											relEnum = ActivityRelationEnum.impede;
											break;
										case 8:
											relEnum = ActivityRelationEnum.permite;
											break;
										default:
											relEnum = null;
											break;
									}
								}
								else
								{
									relEnum = Enum.Parse<ActivityRelationEnum>(dr["relação"].ToString());

								}

								if (relEnum != null)
								{
									ActivityActivityRelationship newRel = new ActivityActivityRelationship();
									newRel.ReferenceActivityId = referenceActivity.ActivityId;
									newRel.Relation = relEnum;
									newRel.ReferredActivityId = referredActivity.ActivityId;

									relList.Add(newRel);
								}
							}
						}
						else
						{
							notFoundCodes.Add(codeRel);
						}
					}
					else
					{
						notFoundCodes.Add(code);
					}

				}

			}
			if (notFoundCodes.Count > 0)
			{

				string codes = notFoundCodes.Aggregate((i, j) => i + "," + j).ToString();

				DialogResult dialogResult = MessageBox.Show("Os códigos dos seguintes itens não estão cadastrados no sistema e não serão importados: " + codes + ". Gostaria de continuar a importação?", "Importar CSV", MessageBoxButtons.YesNoCancel);

				if (dialogResult == DialogResult.Yes)
				{
					ImportActivityRelatioship(relList);
				}

			}
			else
			{
				ImportActivityRelatioship(relList);
			}
		}
		private void SaveElementRelationship(DataTable dt)
		{
			List<ElementElementRelationship> relList = new List<ElementElementRelationship>();
			List<string> notFoundCodes = new List<string>();
			foreach (DataRow dr in dt.Rows)
			{
				string code = Convert.ToString(dr["COD_E"]) ?? "";
				string codeRel = Convert.ToString(dr["COD_E_R"]) ?? "";
				if (code != "" && codeRel != "")
				{
					Element? referenceElement = getElementByCode(code);

					if (referenceElement != null)
					{
						Element? referredElement = getElementByCode(codeRel);

						if (referredElement != null)
						{
							bool relationshipExist = _elementRelationRepository.RelationAlreadyExist(code, codeRel);

							//continue if relationship doesnt exist
							if (!relationshipExist)
							{

								ElementRelationEnum? relEnum;

								if (int.TryParse(dr["relação"].ToString(), out int result))
								{
									switch (result)
									{
										case 1:
											relEnum = ElementRelationEnum.seconecta;
											break;
										case 2:
											relEnum = ElementRelationEnum.delimita;
											break;
										case 3:
											relEnum = ElementRelationEnum.controlaacesso;
											break;
										case 4:
											relEnum = ElementRelationEnum.pavimenta;
											break;
										case 5:
											relEnum = ElementRelationEnum.aciona;
											break;
										case 6:
											relEnum = ElementRelationEnum.contem;
											break;
										default:
											relEnum = null;
											break;
									}
								}
								else
								{
									relEnum = Enum.Parse<ElementRelationEnum>(dr["relação"].ToString());

								}




								if (relEnum != null)
								{
									ElementElementRelationship newRel = new ElementElementRelationship();
									newRel.ReferenceComponentId = referenceElement.ElementId;
									newRel.Relation = relEnum;
									newRel.ReferredComponentId = referredElement.ElementId;

									relList.Add(newRel);
								}
							}
						}
						else
						{
							notFoundCodes.Add(codeRel);
						}
					}
					else
					{
						notFoundCodes.Add(code);
					}

				}

			}
			if (notFoundCodes.Count > 0)
			{

				string codes = notFoundCodes.Aggregate((i, j) => i + "," + j).ToString();

				DialogResult dialogResult = MessageBox.Show("Os códigos dos seguintes itens não estão cadastrados no sistema e não serão importados: " + codes + ". Gostaria de continuar a importação?", "Importar CSV", MessageBoxButtons.YesNoCancel);

				if (dialogResult == DialogResult.Yes)
				{
					ImportElementRelatioship(relList);
				}

			}
			else
			{
				ImportElementRelatioship(relList);
			}
		}

		private void ImportActivityRelatioship(List<ActivityActivityRelationship> relList)
		{
			if (relList.Count > 0)
			{
				_activityRelationRepository.ImportList(relList);

				Frm_Activity frm = (Frm_Activity)_frmOrigem;
				frm.refresh_Activities();
				dgv_Itens.DataSource = new DataTable();
				lbl_StatusMessage.Text = "Relações importadas com sucesso, Total: " + relList.Count;
				//MessageBox.Show("Relações importadas com sucesso, Total: " + relList.Count, "Importar CSV", MessageBoxButtons.OK);

			}
			else
			{
				MessageBox.Show("Nenhum item para importar. Verifique se todos os campos foram preenchidos corretamente ou se a relação já foi previamente cadastrada.", "Importar CSV", MessageBoxButtons.OK);
			}
		}
		private void ImportElementRelatioship(List<ElementElementRelationship> relList)
		{
			if (relList.Count > 0)
			{
				_elementRelationRepository.ImportList(relList);

				Frm_Element frm = (Frm_Element)_frmOrigem;
				frm.refresh_Elements();
				dgv_Itens.DataSource = new DataTable();
				lbl_StatusMessage.Text = "Relações importadas com sucesso, Total: " + relList.Count;
				//MessageBox.Show("Relações importadas com sucesso, Total: " + relList.Count, "Importar CSV", MessageBoxButtons.OK);

			}
			else
			{
				MessageBox.Show("Nenhum item para importar. Verifique se todos os campos foram preenchidos corretamente ou se a relação já foi previamente cadastrada.", "Importar CSV", MessageBoxButtons.OK);
			}
		}

		private void SaveActivityElementRelationship(DataTable dt)
		{
			List<ActivityElementRelationship> relList = new List<ActivityElementRelationship>();
			List<string> notFoundCodes = new List<string>();
			foreach (DataRow dr in dt.Rows)
			{
				string code = Convert.ToString(dr["COD_A"]) ?? "";
				string codeRel = Convert.ToString(dr["COD_E"]) ?? "";
				if (code != "" && codeRel != "")
				{
					Activity? referenceActivity = getActivityByCode(code);

					if (referenceActivity != null)
					{
						Element? element = getElementByCode(codeRel);

						if (element != null)
						{
							bool relationshipExist = _activityElementRelationRepository.RelationAlreadyExist(code, codeRel);

							//continue if relationship doesnt exist
							if (!relationshipExist)
							{
								RelationActivityComponentEnum? relEnum;
								if (int.TryParse(dr["relação"].ToString(), out int result))
								{
									switch (result)
									{
										case 1:
											relEnum = RelationActivityComponentEnum.circulapor;
											break;
										case 2:
											relEnum = RelationActivityComponentEnum.utilizameio;
											break;
										case 3:
											relEnum = RelationActivityComponentEnum.utilizafim;
											break;
										case 4:
											relEnum = RelationActivityComponentEnum.ocupa;
											break;
										case 5:
											relEnum = RelationActivityComponentEnum.acionameio;
											break;
										case 6:
											relEnum = RelationActivityComponentEnum.acionafim;
											break;
										default:
											relEnum = null;
											break;
									}
								}
								else
								{
									relEnum = Enum.Parse<RelationActivityComponentEnum>(dr["relação"].ToString());

								}



								if (relEnum != null)
								{
									ActivityElementRelationship newRel = new ActivityElementRelationship();
									newRel.ActivityId = referenceActivity.ActivityId;
									newRel.Relation = relEnum;
									newRel.ComponentId = element.ElementId;

									relList.Add(newRel);
								}
							}
						}
						else
						{
							notFoundCodes.Add(codeRel);
						}
					}
					else
					{
						notFoundCodes.Add(code);
					}
				}
			}
			if (notFoundCodes.Count > 0)
			{
				string codes = notFoundCodes.Aggregate((i, j) => i + "," + j).ToString();
				DialogResult dialogResult = MessageBox.Show("Os códigos dos seguintes itens não estão cadastrados no sistema e não serão importados: " + codes + ". Gostaria de continuar a importação?", "Importar CSV", MessageBoxButtons.YesNoCancel);

				if (dialogResult == DialogResult.Yes)
				{
					ImportActivityElementRelatioship(relList);
				}

			}
			else
			{
				ImportActivityElementRelatioship(relList);
			}
		}

		private void ImportActivityElementRelatioship(List<ActivityElementRelationship> relList)
		{
			if (relList.Count > 0)
			{
				_activityElementRelationRepository.ImportList(relList);

				if (_screenEnum == ScreenEnum.ActivityElementRelationship)
				{
					Frm_Activity frm = (Frm_Activity)_frmOrigem;
					frm.refresh_Activities();
				}
				else if (_screenEnum == ScreenEnum.ElementActivityRelationship)
				{
					Frm_Element frm = (Frm_Element)_frmOrigem;
					frm.refresh_Elements();
				}

				dgv_Itens.DataSource = new DataTable();
				lbl_StatusMessage.Text = "Relações importadas com sucesso, Total: " + relList.Count;
				//MessageBox.Show("Relações importadas com sucesso, Total: " + relList.Count, "Importar CSV", MessageBoxButtons.OK);

			}
			else
			{
				MessageBox.Show("Nenhum item para importar. Verifique se todos os campos foram preenchidos corretamente ou se a relação já foi previamente cadastrada.", "Importar CSV", MessageBoxButtons.OK);
			}
		}

		private void SaveActivityAgentRelationship(DataTable dt)
		{
			List<AgentActivityRelationship> relList = new List<AgentActivityRelationship>();
			List<string> notFoundCodes = new List<string>();
			foreach (DataRow dr in dt.Rows)
			{
				string code = Convert.ToString(dr["COD_A"]) ?? "";
				string codeRel = Convert.ToString(dr["COD_F"]) ?? "";
				if (code != "" && codeRel != "")
				{
					Activity? referenceActivity = getActivityByCode(code);

					if (referenceActivity != null)
					{
						Agent? agent = getAgentByCode(codeRel);

						if (agent != null)
						{
							bool relationshipExist = _activityAgentRelationRepository.RelationAlreadyExist(code, codeRel);

							//continue if relationship doesnt exist
							if (!relationshipExist)
							{
								AgentActivityRelationship newRel = new AgentActivityRelationship();
								newRel.ActivityId = referenceActivity.ActivityId;
								newRel.AgentId = agent.AgentId;
								relList.Add(newRel);

							}
						}
						else
						{
							notFoundCodes.Add(codeRel);
						}
					}
					else
					{
						notFoundCodes.Add(code);
					}

				}

			}
			if (notFoundCodes.Count > 0)
			{

				string codes = notFoundCodes.Aggregate((i, j) => i + "," + j).ToString();

				DialogResult dialogResult = MessageBox.Show("Os códigos dos seguintes itens não estão cadastrados no sistema e não serão importados: " + codes + ". Gostaria de continuar a importação?", "Importar CSV", MessageBoxButtons.YesNoCancel);

				if (dialogResult == DialogResult.Yes)
				{
					ImportAgentActivityRelatioship(relList);
				}

			}
			else
			{
				ImportAgentActivityRelatioship(relList);
			}
		}


		private void ImportAgentActivityRelatioship(List<AgentActivityRelationship> relList)
		{
			if (relList.Count > 0)
			{
				_activityAgentRelationRepository.ImportList(relList);

				if (_screenEnum == ScreenEnum.ActivityAgentRelationship)
				{
					Frm_Activity frm = (Frm_Activity)_frmOrigem;
					frm.refresh_Activities();
				}
				else if (_screenEnum == ScreenEnum.AgentActivityRelationship)
				{
					Frm_Organization frm = (Frm_Organization)_frmOrigem;
					frm.refresh_Agents();
				}

				dgv_Itens.DataSource = new DataTable();
				lbl_StatusMessage.Text = "Relações importadas com sucesso, Total: " + relList.Count;
				//MessageBox.Show("Relações importadas com sucesso, Total: " + relList.Count, "Importar CSV", MessageBoxButtons.OK);

			}
			else
			{
				MessageBox.Show("Nenhum item para importar. Verifique se todos os campos foram preenchidos corretamente ou se a relação já foi previamente cadastrada.", "Importar CSV", MessageBoxButtons.OK);
			}
		}

		private void SaveAgentResourceRelationship(DataTable dt)
		{
			List<AgentResourceRelationship> relList = new List<AgentResourceRelationship>();
			List<string> notFoundCodes = new List<string>();
			foreach (DataRow dr in dt.Rows)
			{
				string codeAgent = Convert.ToString(dr["COD_F"]) ?? "";
				string codeResource = Convert.ToString(dr["COD_R"]) ?? "";
				if (codeAgent != "" && codeResource != "")
				{
					Agent? agent = getAgentByCode(codeAgent);

					if (agent != null)
					{
						HumanResource? resource = getResourceByCode(codeResource);

						if (resource != null)
						{
							bool relationshipExist = _agentResourceRelationRepository.RelationAlreadyExist(codeAgent, codeResource);

							//continue if relationship doesnt exist
							if (!relationshipExist)
							{
								AgentResourceRelationship newRel = new AgentResourceRelationship();
								newRel.ResourceId = resource.PersonId;
								newRel.AgentId = agent.AgentId;
								newRel.Relation = RelationEnum.atribuida;
								relList.Add(newRel);

							}
						}
						else
						{
							notFoundCodes.Add(codeResource);
						}
					}
					else
					{
						notFoundCodes.Add(codeAgent);
					}

				}

			}
			if (notFoundCodes.Count > 0)
			{

				string codes = notFoundCodes.Aggregate((i, j) => i + "," + j).ToString();

				DialogResult dialogResult = MessageBox.Show("Os códigos dos seguintes itens não estão cadastrados no sistema e não serão importados: " + codes + ". Gostaria de continuar a importação?", "Importar CSV", MessageBoxButtons.YesNoCancel);

				if (dialogResult == DialogResult.Yes)
				{
					ImportAgentResourceRelatioship(relList);
				}

			}
			else
			{
				ImportAgentResourceRelatioship(relList);
			}
		}


		private void ImportAgentResourceRelatioship(List<AgentResourceRelationship> relList)
		{
			if (relList.Count > 0)
			{
				_agentResourceRelationRepository.ImportList(relList);

				Frm_Organization frm = (Frm_Organization)_frmOrigem;
				frm.refresh_Agents();

				dgv_Itens.DataSource = new DataTable();
				lbl_StatusMessage.Text = "Relações importadas com sucesso, Total: " + relList.Count;

			}
			else
			{
				MessageBox.Show("Nenhum item para importar. Verifique se todos os campos foram preenchidos corretamente ou se a relação já foi previamente cadastrada.", "Importar CSV", MessageBoxButtons.OK);
			}
		}

		private Activity? getActivityByCode(string code)
		{
			if (code != "")
			{
				Activity? activity = _activityRepository.FindByCode(code);
				if (activity != null)
				{
					return activity;
				}
				return null;
			}
			return null;
		}

		private Element? getElementByCode(string code)
		{
			if (code != "")
			{
				Element? element = _elementRepository.FindByCode(code);
				if (element != null)
				{
					return element;
				}
				return null;
			}
			return null;
		}
		private Agent? getAgentByCode(string code)
		{
			if (code != "")
			{
				Agent? agent = _agentRepository.FindByCode(code);
				if (agent != null)
				{
					return agent;
				}
				return null;
			}
			return null;
		}

		private HumanResource? getResourceByCode(string code)
		{
			if (code != "")
			{
				HumanResource? res = _resourceRepository.FindByCode(code);
				if (res != null)
				{
					return res;
				}
				return null;
			}
			return null;
		}
		private void Frm_ImportCsv_FormClosing(object sender, FormClosingEventArgs e)
		{

		}

		private void btn_DownloadTemplate_Click(object sender, EventArgs e)
		{

			string fileName = "";
			string copyFileName = "";

			switch (_screenEnum)
			{
				case ScreenEnum.Agent:
					fileName = "TemplatesCSV/1.2_funcao.csv";
					copyFileName = "1.2_funcao.csv";
					break;
				case ScreenEnum.Resource:
					fileName = "TemplatesCSV/4.1_recurso.csv";
					copyFileName = "4.1_recurso.csv";
					break;
				case ScreenEnum.Element:
					fileName = "TemplatesCSV/3.2_elemento.csv";
					copyFileName = "3.2_elemento.csv";
					break;
				case ScreenEnum.Activity:
					fileName = "TemplatesCSV/2.2_atividade.csv";
					copyFileName = "2.2_atividade.csv";
					break;
				case ScreenEnum.Organization:
					fileName = "TemplatesCSV/1.1_divisão.csv";
					copyFileName = "1.1_divisão.csv";
					break;
				case ScreenEnum.Subsystem:
					fileName = "TemplatesCSV/3.1_sistema.csv";
					copyFileName = "3.1_sistema.csv";
					break;
				case ScreenEnum.Subprocess:
					fileName = "TemplatesCSV/2.1_processo.csv";
					copyFileName = "2.1_processo.csv";
					break;
				case ScreenEnum.ActivityRelationship:
					fileName = "TemplatesCSV/5.2_relacoes_AtividadexAtividade.csv";
					copyFileName = "5.2_relacoes_AtividadexAtividade.csv";
					break;
				case ScreenEnum.ElementRelationship:
					fileName = "TemplatesCSV/5.4_relacoes_ElementoxElemento.csv";
					copyFileName = "5.4_relacoes_ElementoxElemento.csv";
					break;
				case ScreenEnum.ActivityElementRelationship:
				case ScreenEnum.ElementActivityRelationship:
					fileName = "TemplatesCSV/5.3_relacoes_AtividadexElemento.csv";
					copyFileName = "5.3_relacoes_AtividadexElemento.csv";
					break;
				case ScreenEnum.ActivityAgentRelationship:
				case ScreenEnum.AgentActivityRelationship:
					fileName = "TemplatesCSV/5.1_relacoes_AtividadexFunção.csv";
					copyFileName = "5.1_relacoes_AtividadexFunção.csv";
					break;
				case ScreenEnum.AgentResourceRelationship:
					fileName = "TemplatesCSV/5.5_relacoes_FuncaoxRecurso.csv";
					copyFileName = "5.5_relacoes_FuncaoxRecurso.csv";
					break;
			}

			if (fileName != "" && copyFileName != "")
			{
				using (var fbd = new FolderBrowserDialog())
				{
					DialogResult result = fbd.ShowDialog();

					if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
					{
						try
						{

							string dir = AppContext.BaseDirectory;
							string sourceFile = Path.Combine(dir, fileName);
							string destFile = Path.Combine(fbd.SelectedPath, copyFileName);

							File.Copy(sourceFile, destFile);

							MessageBox.Show("Arquivo salvo na pasta: " + destFile, "Arquivo baixado com sucesso");

						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message, "Aviso");
						}
					}
				}

			}
			else
			{
				MessageBox.Show("Nenhum arquivo para baixar.", "Baixar Modelo");

			}
		}

		private void btn_Close_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
