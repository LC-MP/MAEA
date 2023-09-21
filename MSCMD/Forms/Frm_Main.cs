// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

// MIT License
//
// Copyright (c) 2023 Jean Amaro <jean.amaro@outlook.com.br>
// Copyright (c) 2023 Lucas Melchiori Pereira <lc.melchiori@gmail.com>
// Copyright (c) 2023 Daniela Cariolin Mazzi <daniela.cmazzi@gmail.com>
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

// We thank FAPESP (Fundação de Amparo à Pesquisa do Estado de São Paulo) for
// funding this research project.
// FAPESP process number: 2020/15909-8

using HarfBuzzSharp;
using MSCMD.Forms.DataVisualization;
using MSCMD.Model;
using MSCMD.Repository;
using MSCMD.Service;
using MSCMD.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSCMD.Forms
{
	public partial class Frm_Main : Form
	{

		private static MscmdContext context = new MscmdContext();
		private ProjectRepository _projetoRepository = new ProjectRepository(context);
		private Project projeto = new Project();

		private float relation = 0;
		private MscmdService mscmdService;
		private List<List<float>> activitiesDependenciesMatrix;
		private List<List<float>> componentsInterfacesMatrix;
		private List<List<float>> comparativeActivityMatrix;
		private List<List<float>> comparativeComponentMatrix;
		private List<List<float>> comparativeActivityMatrixWithRedundancy;
		private List<List<float>> comparativeComponentMatrixWithRedundancy;
		private List<List<float>> affiliationMatrix;
		private SortedDictionary<string, ulong>? agentsInChargeForComponentsList;
		private List<PriorityViewModel> activitiesPriorities;
		private List<SortedSet<string>> parallelizationList;
		private PictureBox pictureBox1 = new PictureBox();

		string dir;
		string fileNameComparativeComponentMatrixWithRedundancy = "Congruencia_Elementos_com_Redundancia.csv";
		string fileNameComparativeActivityMatrix = "Congruencia_Atividades.csv";
		string fileNameComparativeActivityMatrixWithRedundancy = "Congruencia_Atividades_com_Redundancia.csv";
		string fileNameComparativeComponentMatrix = "Congruencia_Elementos.csv";

		string labelActivity = "Atividade";
		string labelElement = "Elemento";

		public Frm_Main()
		{
			InitializeComponent();
		}


		private void Frm_Geral_Load(object sender, EventArgs e)
		{


			context.Database.EnsureCreated();
			List<Project> projs = _projetoRepository.ListarTodos().ToList();

			projeto = _projetoRepository.GetProject() ?? new Project();

			if (projeto != null)
			{
				rtxtb_NomeProjeto.Text = projeto.Name;
				rtxtb_DescProjeto.Text = projeto.Description ?? "";
			}
			lbl_processStatus.Text = "";
			DisableButtons();
			HideCheckLabels();

			mscmdService = new MscmdService();


			pictureBox1.Dock = DockStyle.Fill;
			pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);

			// Add the PictureBox control to the Form.
			this.Controls.Add(pictureBox1);

			dir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

		}

		private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			int btnOrgY = btn_Organization.Location.Y + 10;
			int btnOrgX = btn_Organization.Location.X;
			int btnActY = btn_Process.Location.Y + 10;
			int btnActX = btn_Process.Location.X;
			int btnEnvY = btn_Environment.Location.Y + 10;
			int btnEnvX = btn_Environment.Location.X;
			int btnResY = btn_Resources.Location.Y + 10;
			int btnResX = btn_Resources.Location.X;

			int btnProcessY = btn_ProcessData.Location.Y + 10;
			int btnProcessX = btn_ProcessData.Location.X;

			int btnActMY = btn_ActivitiesDependenciesMatrix.Location.Y + 10;
			int btnActMX = btn_ActivitiesDependenciesMatrix.Location.X;
			int btnAffMY = btn_AffiliationMatrix.Location.Y + 10;
			int btnAffMX = btn_AffiliationMatrix.Location.X;
			int btnCompMY = btn_ComponentsInterfacesMatrix.Location.Y + 10;
			int btnCompMX = btn_ComponentsInterfacesMatrix.Location.X;

			int btnComparativeMX = btn_ComparativeMatrixWithoutRedundancies.Location.X;

			int size1 = 70;
			int size2 = size1 + 80;

			int size3 = 40;

			var penDashed = new Pen(Color.Black, 1);
			penDashed.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
			using (penDashed)
			{
				e.Graphics.DrawLine(penDashed, btnOrgX + size1, btnOrgY, btnOrgX + size2, btnOrgY);
				e.Graphics.DrawLine(penDashed, btnActX + size1, btnActY, btnActX + size2, btnActY);
				e.Graphics.DrawLine(penDashed, btnEnvX + size1, btnEnvY, btnEnvX + size2, btnEnvY);
				e.Graphics.DrawLine(penDashed, btnResX + size1, btnResY, btnResX + size2, btnResY);

				e.Graphics.DrawLine(penDashed, btnOrgX + size2, btnOrgY, btnOrgX + size2, btnResY);

				e.Graphics.DrawLine(penDashed, btnActMX - size3, btnActMY, btnActMX, btnActMY);
				e.Graphics.DrawLine(penDashed, btnAffMX - size3, btnAffMY, btnAffMX, btnAffMY);
				e.Graphics.DrawLine(penDashed, btnCompMX - size3, btnCompMY, btnCompMX, btnCompMY);

				e.Graphics.DrawLine(penDashed, btnActMX - size3, btnActMY, btnActMX - size3, btnCompMY);
				e.Graphics.DrawLine(penDashed, btnOrgX + size2, btnAffMY, btnActMX - size3, btnAffMY);

				e.Graphics.DrawLine(penDashed, btnActMX, btnActMY, btnComparativeMX - size3, btnActMY);
				e.Graphics.DrawLine(penDashed, btnComparativeMX - size3, btnOrgY, btnComparativeMX, btnOrgY);
				e.Graphics.DrawLine(penDashed, btnComparativeMX - size3, btnActY, btnComparativeMX, btnActY);

				e.Graphics.DrawLine(penDashed, btnComparativeMX - size3, btnOrgY, btnComparativeMX - size3, btnActY);


				e.Graphics.DrawLine(penDashed, btnCompMX, btnCompMY, btnComparativeMX - size3, btnCompMY);
				e.Graphics.DrawLine(penDashed, btnComparativeMX - size3, btnEnvY, btnComparativeMX, btnEnvY);
				e.Graphics.DrawLine(penDashed, btnComparativeMX - size3, btnResY, btnComparativeMX, btnResY);

				e.Graphics.DrawLine(penDashed, btnComparativeMX - size3, btnEnvY, btnComparativeMX - size3, btnResY);

			}

		}
		private void DisableButtons()
		{
			btn_errorLog.Enabled = false;

			btn_ActivitiesDependenciesMatrix.Enabled = false;
			btn_ComponentsInterfacesMatrix.Enabled = false;
			btn_DownloadActivivtyMatrix.Enabled = false;
			btn_DownloadActivityComparativeMatrix.Enabled = false;
			btn_DownloadElementMatrix.Enabled = false;
			btn_ComparativeMatrixWithoutRedundancies.Enabled = false;
			btn_ComparativeMatrixWithRedundancies.Enabled = false;
			btn_ComponentComparativeMatrixWithoutRedundancies.Enabled = false;
			btn_ComponentComparativeMatrixWithRedundancies.Enabled = false;
			btn_AffiliationMatrix.Enabled = false;
			btn_DownloadRelationshipMatrix.Enabled = false;
			btn_DownloadActivityComparativeMatrixWithRedundancy.Enabled = false;
			btn_DownloadComponentComparativeMatrix.Enabled = false;
			btn_DownloadComponentComparativeMatrixWithRedundancy.Enabled = false;
			btn_Priorities.Enabled = false;
			btn_Paralelism.Enabled = false;

		}

		private void HideCheckLabels()
		{
			lbl_checkActivity.Text = string.Empty;
			lbl_checkComponents.Text = string.Empty;
			lbl_checkAffiliation.Text = string.Empty;
			lbl_checkActivityWithoutRedundacy.Text = string.Empty;
			lbl_checkActivityWithRedundacy.Text = string.Empty;
			lbl_checkElementWithoutRedundacy.Text = string.Empty;
			lbl_checkElementWithRedundacy.Text = string.Empty;
			lbl_CheckPriorities.Text = string.Empty;
			lbl_CheckParalelism.Text = string.Empty;

		}

		private void btn_Salvar_Click(object sender, EventArgs e)
		{
			if (rtxtb_NomeProjeto.Text != "")
			{
				projeto.Name = rtxtb_NomeProjeto.Text;
				projeto.Description = rtxtb_DescProjeto.Text;

				_projetoRepository.Save(projeto);
				MessageBox.Show("Informações salvas com sucesso.", "Projeto", MessageBoxButtons.OK);

			}
			else
			{
				MessageBox.Show("Por favor, preencha o nome do projeto.", "Erro ao Salvar", MessageBoxButtons.OK);
			}

		}



		private async void btn_ProcessData_Click(object sender, EventArgs e)
		{

			lbl_processStatus.Text = "Aguarde enquanto os dados são processados...";
			DisableButtons();
			mscmdService.ClearProcess();
			ClearProcessCache();
			HideCheckLabels();
			mscmdService.loadData();
			btn_ProcessData.Enabled = false;


			await Task.Factory.StartNew(() =>
			{
				generateMatrixes();
			}).ContinueWith((result) =>
			{
				lbl_processStatus.Text = "Processamento: " + DateTime.Now.ToString(@"dd\/MM\/yyyy HH:mm");
				btn_ProcessData.Enabled = true;
				btn_errorLog.Enabled = true;

				CheckStatus(lbl_checkActivity, activitiesDependenciesMatrix != null && activitiesDependenciesMatrix.Count > 0, btn_ActivitiesDependenciesMatrix, btn_DownloadActivivtyMatrix);
				CheckStatus(lbl_checkComponents, componentsInterfacesMatrix != null && componentsInterfacesMatrix.Count > 0, btn_ComponentsInterfacesMatrix, btn_DownloadElementMatrix);
				CheckStatus(lbl_checkAffiliation, affiliationMatrix != null && affiliationMatrix.Count > 0, btn_AffiliationMatrix, btn_DownloadRelationshipMatrix);
				CheckStatus(lbl_checkActivityWithoutRedundacy, comparativeActivityMatrix != null && comparativeActivityMatrix.Count > 0, btn_ComparativeMatrixWithoutRedundancies, btn_DownloadActivityComparativeMatrix);
				CheckStatus(lbl_checkActivityWithRedundacy, comparativeActivityMatrixWithRedundancy != null && comparativeActivityMatrixWithRedundancy.Count > 0, btn_ComparativeMatrixWithRedundancies, btn_DownloadActivityComparativeMatrixWithRedundancy);
				CheckStatus(lbl_checkElementWithoutRedundacy, comparativeComponentMatrix != null && comparativeComponentMatrix.Count > 0, btn_ComponentComparativeMatrixWithoutRedundancies, btn_DownloadComponentComparativeMatrix);
				CheckStatus(lbl_checkElementWithRedundacy, comparativeComponentMatrixWithRedundancy != null && comparativeComponentMatrixWithRedundancy.Count > 0, btn_ComponentComparativeMatrixWithRedundancies, btn_DownloadComponentComparativeMatrixWithRedundancy);
				CheckStatus(lbl_CheckPriorities, activitiesPriorities != null && activitiesPriorities.Count > 0, btn_Priorities, btn_Priorities);
				CheckStatus(lbl_CheckParalelism, parallelizationList != null && parallelizationList.Count > 0, btn_Paralelism, btn_Paralelism);

			}, TaskScheduler.FromCurrentSynchronizationContext());

		}

		private void CheckStatus(Label label, bool config, Button matrixBtn, Button downloadBtn)
		{
			if (config)
			{
				label.Text = "✓";
				label.ForeColor = Color.Green;
				matrixBtn.Enabled = true;
				downloadBtn.Enabled = true;
			}
			else
			{
				label.Text = "x";
				label.ForeColor = Color.Red;
				matrixBtn.Enabled = false;
				downloadBtn.Enabled = false;

			}
		}

		private void ClearProcessCache()
		{
			activitiesDependenciesMatrix?.Clear();
			comparativeActivityMatrix?.Clear();
			comparativeComponentMatrix?.Clear();
			comparativeActivityMatrixWithRedundancy?.Clear();
			comparativeComponentMatrixWithRedundancy?.Clear();
			agentsInChargeForComponentsList?.Clear();
			activitiesPriorities?.Clear();
			parallelizationList?.Clear();
		}

		private void generateMatrixes()
		{

			//component comparative matrix
			bool alignComponents = mscmdService.CompareComponentsAndOrganization(relation);
			if (alignComponents)
			{
				comparativeComponentMatrix = mscmdService.ComparativeMatrixWithoutRedundancies();
				comparativeComponentMatrixWithRedundancy = mscmdService.ComparativeMatrixWithRedundancies();


				//download
				if (comparativeComponentMatrix != null && comparativeComponentMatrix.Count > 0)
				{
					string destFile = Path.Combine(dir, fileNameComparativeComponentMatrix);
					mscmdService.WriteComparativeMatrixWithoutRedundancies(destFile);

				}
				if (comparativeComponentMatrixWithRedundancy != null && comparativeComponentMatrixWithRedundancy.Count > 0)
				{
					string destFile = Path.Combine(dir, fileNameComparativeComponentMatrixWithRedundancy);
					mscmdService.WriteComparativeMatrixWithRedundancies(destFile);
				}

			}

			//activity comparative matrix
			bool alignActivity = mscmdService.CompareActivitiesAndOrganization();
			if (alignActivity)
			{
				comparativeActivityMatrix = mscmdService.ComparativeMatrixWithoutRedundancies();
				comparativeActivityMatrixWithRedundancy = mscmdService.ComparativeMatrixWithRedundancies();

				if (comparativeActivityMatrix != null && comparativeActivityMatrix.Count > 0)
				{
					string destFile = Path.Combine(dir, fileNameComparativeActivityMatrix);
					mscmdService.WriteComparativeMatrixWithoutRedundancies(destFile);

				}
				if (comparativeActivityMatrixWithRedundancy != null && comparativeActivityMatrixWithRedundancy.Count > 0)
				{

					string destFile = Path.Combine(dir, fileNameComparativeActivityMatrixWithRedundancy);
					mscmdService.WriteComparativeMatrixWithRedundancies(destFile);
				}
			}

			activitiesDependenciesMatrix = mscmdService.ActivitiesDependenciesMatrix();
			componentsInterfacesMatrix = mscmdService.ComponentsInterfacesMatrix();
			affiliationMatrix = mscmdService.TotalAffiliationsMatrix();

			mscmdService.MinimumRelationDegreeForAgentsInChargeOfComponents(relation);
			mscmdService.ActivitiesWithoutAgentsInCharge();
			mscmdService.ComponentsWithoutAgentsInCharge();

			SortedDictionary<string, ulong>? priotities = mscmdService.IdentifyPriority();
			LoadPriorities(priotities);
			parallelizationList = mscmdService.IdentifyParallelization();
		}

		private void LoadPriorities(SortedDictionary<string, ulong>? priotities)
		{
			if (priotities != null && priotities.Count > 0)
			{
				List<PriorityViewModel> priorities = new List<PriorityViewModel>();

				foreach (var priority in priotities)
				{
					PriorityViewModel p = new PriorityViewModel();
					p.ID = priority.Key;
					p.Priority = priority.Value;
					p.Name = mscmdService.ActivityName(priority.Key);

					priorities.Add(p);
				}

				activitiesPriorities = priorities;
			}
		}

		private void btn_ActivitiesDependenciesMatrix_Click(object sender, EventArgs e)
		{
			var matrix = activitiesDependenciesMatrix; //mscmdService.ActivitiesDependenciesMatrix();

			if (matrix != null)
			{
				var activities = mscmdService.GetActivities();
				List<string> activityList = activities.Select(x => x.ActivityId.ToString() + ":" + x.ActivityCode?.ToString()).ToList();
				List<string> activityTooltipList = activities.Select(x => x.ActivityId.ToString() + ":" + x.ActivityName?.ToString()).ToList();



				Frm_MatrixVisualization frm = new Frm_MatrixVisualization(matrix, activityList, activityList.OrderByDescending(x => x).ToList(), activityTooltipList, activityTooltipList.OrderByDescending(x => x).ToList(), btn_ActivitiesDependenciesMatrix.Text, labelActivity, labelActivity);
				frm.Show();
			}
			else
			{
				MessageBox.Show("A matriz não pode ser gerada, verifique os dados e tente novamente.");
			}
		}

		private void btn_ComponentsInterfacesMatrix_Click(object sender, EventArgs e)
		{
			var matrix = componentsInterfacesMatrix; // mscmdService.ComponentsInterfacesMatrix();

			if (matrix != null)
			{
				var element = mscmdService.GetElements();
				List<string> elementList = element.Select(x => x.ElementId.ToString() + ":" + x.Code?.ToString()).ToList();
				List<string> tooltipElementList = element.Select(x => x.ElementId.ToString() + ":" + x.Name?.ToString()).ToList();

				Frm_MatrixVisualization frm = new Frm_MatrixVisualization(matrix, elementList, elementList.OrderByDescending(x => x).ToList(), tooltipElementList, tooltipElementList.OrderByDescending(x => x).ToList(), btn_ComponentsInterfacesMatrix.Text, labelElement, labelElement);
				frm.Show();
			}
			else
			{
				MessageBox.Show("A matriz não pode ser gerada, verifique os dados e tente novamente.");
			}
		}

		private void btn_ComparativeMatrixWithoutRedundancies_Click(object sender, EventArgs e)
		{
			var matrix = comparativeActivityMatrix;

			if (matrix != null)
			{
				var activities = mscmdService.GetActivities();
				List<string> activityList = activities.Select(x => x.ActivityId.ToString() + ":" + x.ActivityCode?.ToString()).ToList();
				List<string> tooltipActivityList = activities.Select(x => x.ActivityId.ToString() + ":" + x.ActivityName?.ToString()).ToList();

				Frm_MatrixVisualization frm = new Frm_MatrixVisualization(matrix, activityList, activityList.OrderByDescending(x => x).ToList(), tooltipActivityList, tooltipActivityList.OrderByDescending(x => x).ToList(), btn_ComparativeMatrixWithoutRedundancies.Text, labelActivity, labelActivity);
				frm.Show();
			}
			else
			{
				MessageBox.Show("A matriz não pode ser gerada, verifique os dados e tente novamente.");
			}
		}

		private void btn_ComparativeMatrixWithRedundancies_Click(object sender, EventArgs e)
		{
			var matrix = comparativeActivityMatrixWithRedundancy;

			if (matrix != null)
			{
				var activities = mscmdService.GetActivities();
				List<string> activityList = activities.Select(x => x.ActivityId.ToString() + ":" + x.ActivityCode?.ToString()).ToList();
				List<string> tooltipActivityList = activities.Select(x => x.ActivityId.ToString() + ":" + x.ActivityName?.ToString()).ToList();

				Frm_MatrixVisualization frm = new Frm_MatrixVisualization(matrix, activityList, activityList.OrderByDescending(x => x).ToList(), tooltipActivityList, tooltipActivityList.OrderByDescending(x => x).ToList(), btn_ComparativeMatrixWithRedundancies.Text, labelActivity, labelActivity);
				frm.Show();
			}
			else
			{
				MessageBox.Show("A matriz não pode ser gerada, verifique os dados e tente novamente.");
			}
		}

		private void btn_ComponentComparativeMatrixWithoutRedundancies_Click(object sender, EventArgs e)
		{
			var matrix = comparativeComponentMatrix;

			if (matrix != null)
			{
				var element = mscmdService.GetElements();
				List<string> elementList = element.Select(x => x.ElementId.ToString() + ":" + x.Code?.ToString()).ToList();
				List<string> tooltipElementList = element.Select(x => x.ElementId.ToString() + ":" + x.Name?.ToString()).ToList();

				Frm_MatrixVisualization frm = new Frm_MatrixVisualization(matrix, elementList, elementList.OrderByDescending(x => x).ToList(), tooltipElementList, tooltipElementList.OrderByDescending(x => x).ToList(), btn_ComponentComparativeMatrixWithoutRedundancies.Text, labelElement, labelElement);
				frm.Show();
			}
			else
			{
				MessageBox.Show("A matriz não pode ser gerada, verifique os dados e tente novamente.");
			}
		}

		private void btn_ComponentComparativeMatrixWithRedundancies_Click(object sender, EventArgs e)
		{
			var matrix = comparativeComponentMatrixWithRedundancy;

			if (matrix != null)
			{
				var element = mscmdService.GetElements();
				List<string> elementList = element.Select(x => x.ElementId.ToString() + ":" + x.Code?.ToString()).ToList();
				List<string> tooltipElementList = element.Select(x => x.ElementId.ToString() + ":" + x.Name?.ToString()).ToList();

				Frm_MatrixVisualization frm = new Frm_MatrixVisualization(matrix, elementList, elementList.OrderByDescending(x => x).ToList(), tooltipElementList, tooltipElementList.OrderByDescending(x => x).ToList(), btn_ComponentComparativeMatrixWithRedundancies.Text, labelElement, labelElement);
				frm.Show();
			}
			else
			{
				MessageBox.Show("A matriz não pode ser gerada, verifique os dados e tente novamente.");
			}
		}

		private void btn_AffiliationMatrix_Click(object sender, EventArgs e)
		{
			var matrix = affiliationMatrix;

			if (matrix != null)
			{
				var element = mscmdService.GetElements();
				List<string> elementList = element.Select(x => x.ElementId.ToString() + ":" + x.Code?.ToString()).ToList();
				List<string> tooltipElementList = element.Select(x => x.ElementId.ToString() + ":" + x.Name?.ToString()).ToList();

				var activities = mscmdService.GetActivities();
				List<string> activityList = activities.Select(x => x.ActivityId.ToString() + ":" + x.ActivityCode?.ToString()).ToList();
				List<string> tooltipActivityList = activities.Select(x => x.ActivityId.ToString() + ":" + x.ActivityName?.ToString()).ToList();


				Frm_MatrixVisualization frm = new Frm_MatrixVisualization(matrix, elementList, activityList.OrderByDescending(x => x).ToList(), tooltipElementList, tooltipActivityList.OrderByDescending(x => x).ToList(), btn_AffiliationMatrix.Text, labelElement, labelActivity);
				frm.Show();
			}
			else
			{
				MessageBox.Show("A matriz não pode ser gerada, verifique os dados e tente novamente.");
			}
		}

		private void btn_DownloadActivivtyMatrix_Click(object sender, EventArgs e)
		{
			string fileName = "ActivityMatrix.csv";
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					try
					{
						string destFile = Path.Combine(fbd.SelectedPath, fileName);

						bool status = mscmdService.WriteActivityMatrix(destFile);

						if (status)
						{
							MessageBox.Show("Arquivo salvo na pasta: " + destFile, "Arquivo baixado com sucesso");
						}

					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Aviso");
					}
				}
			}

		}

		private void btn_DownloadElementMatrix_Click(object sender, EventArgs e)
		{
			string fileName = "ElementMatrix.csv";
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					try
					{
						string destFile = Path.Combine(fbd.SelectedPath, fileName);

						bool status = mscmdService.WriteComponentsMatrix(destFile);

						if (status)
						{
							MessageBox.Show("Arquivo salvo na pasta: " + destFile, "Arquivo baixado com sucesso");
						}

					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Aviso");
					}
				}
			}
		}




		private void btn_DownloadRelationshipMatrix_Click(object sender, EventArgs e)
		{
			string fileName = "Relationship.csv";
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					try
					{
						string destFile = Path.Combine(fbd.SelectedPath, fileName);

						bool status = mscmdService.WriteTotalAffiliationsMatrix(destFile);

						if (status)
						{
							MessageBox.Show("Arquivo salvo na pasta: " + destFile, "Arquivo baixado com sucesso");
						}

					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Aviso");
					}
				}
			}
		}

		private void btn_Organization_Click(object sender, EventArgs e)
		{
			Frm_Organization frm_Organizacao = new Frm_Organization();
			frm_Organizacao.ShowDialog();
		}

		private void btn_Process_Click(object sender, EventArgs e)
		{
			Frm_Activity frm_Atividades = new Frm_Activity();
			frm_Atividades.ShowDialog();
		}

		private void btn_Environment_Click(object sender, EventArgs e)
		{
			Frm_Element frm_Elementos = new Frm_Element();
			frm_Elementos.ShowDialog();
		}

		private void btn_Resources_Click(object sender, EventArgs e)
		{

			Frm_Resources frm_Pessoa = new Frm_Resources();
			frm_Pessoa.ShowDialog();
		}

		private void btn_errorLog_Click(object sender, EventArgs e)
		{

			string errorMessage = mscmdService.errorLog;

			if (errorMessage != "")
				MessageBox.Show(errorMessage, "Relatório");
			else
				MessageBox.Show("Nenhum erro encontrado durante o processamento.", "Relatório");
		}

		private void btn_DownloadComparativeMatrix_Click(object sender, EventArgs e)
		{

			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					try
					{
						string sourceFile = Path.Combine(dir, fileNameComparativeComponentMatrix);
						string destFile = Path.Combine(fbd.SelectedPath, fileNameComparativeComponentMatrix);

						File.Copy(sourceFile, destFile);

					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Aviso");
					}
				}
			}

		}

		private void btn_DownloadActivityComparativeMatrixWithRedundancy_Click(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					try
					{
						string sourceFile = Path.Combine(dir, fileNameComparativeActivityMatrixWithRedundancy);
						string destFile = Path.Combine(fbd.SelectedPath, fileNameComparativeActivityMatrixWithRedundancy);

						File.Copy(sourceFile, destFile);

					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Aviso");
					}
				}
			}
		}

		private void btn_DownloadComponentComparativeMatrix_Click(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					try
					{
						string sourceFile = Path.Combine(dir, fileNameComparativeComponentMatrix);
						string destFile = Path.Combine(fbd.SelectedPath, fileNameComparativeComponentMatrix);

						File.Copy(sourceFile, destFile);

					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Aviso");
					}
				}
			}
		}

		private void btn_DownloadComponentComparativeMatrixWithRedundancy_Click(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					try
					{
						string sourceFile = Path.Combine(dir, fileNameComparativeComponentMatrixWithRedundancy);
						string destFile = Path.Combine(fbd.SelectedPath, fileNameComparativeComponentMatrixWithRedundancy);

						File.Copy(sourceFile, destFile);

					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Aviso");
					}
				}
			}
		}

		private void btn_DeleteAll_Click(object sender, EventArgs e)
		{
			string dir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

			DialogResult dialogResult = MessageBox.Show("Todos os dados serão excluidos permanentemente. Tem certeza que deseja continuar? \n\nObs: Caso queira salvar um backup do banco de dados, você pode salvar uma cópia do arquivo mscmd.db encontrado na pasta: " + dir, "Tem certeza que deseja deletar todos os dados da aplicação?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop);
			if (dialogResult == DialogResult.Yes)
			{
				try
				{
					context.Database.EnsureDeleted();
					MessageBox.Show("Dados excluídos com sucesso.", "Limpar dados");
				}
				catch
				{
					MessageBox.Show("Erro ao deletar.");
				}
				context.Database.EnsureCreated();

			}

		}

		private void btn_ExportAll_Click(object sender, EventArgs e)
		{
			new ExportDataService().ExportAll();
		}

		private void btn_Priorities_Click(object sender, EventArgs e)
		{
			if (activitiesPriorities != null && activitiesPriorities.Count > 0)
			{
				Frm_Priorities frm = new Frm_Priorities(activitiesPriorities);
				frm.ShowDialog();
			}
			else
			{
				MessageBox.Show("Não há dados para serem exibidos.", "Aviso");
			}

		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (parallelizationList != null && parallelizationList.Count > 0)
			{
				Frm_Parallelism frm = new Frm_Parallelism(parallelizationList);
				frm.ShowDialog();
			}
		}
	}
}
