namespace MSCMD.Forms
{
	partial class Frm_Main
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
			lbl_Titulo = new Label();
			rtxtb_DescProjeto = new RichTextBox();
			lbl_NomeProj = new Label();
			lbl_ObjProj = new Label();
			btn_Salvar = new Button();
			rtxtb_NomeProjeto = new RichTextBox();
			btn_ProcessData = new Button();
			lbl_processStatus = new Label();
			btn_ActivitiesDependenciesMatrix = new Button();
			btn_DownloadActivityComparativeMatrix = new Button();
			btn_DownloadElementMatrix = new Button();
			btn_DownloadActivivtyMatrix = new Button();
			btn_ComparativeMatrixWithRedundancies = new Button();
			btn_ComparativeMatrixWithoutRedundancies = new Button();
			btn_ComponentsInterfacesMatrix = new Button();
			btn_ComponentComparativeMatrixWithRedundancies = new Button();
			btn_ComponentComparativeMatrixWithoutRedundancies = new Button();
			btn_AffiliationMatrix = new Button();
			btn_DownloadRelationshipMatrix = new Button();
			lbl_checkActivity = new Label();
			lbl_checkComponents = new Label();
			lbl_Separator_Vertical = new Label();
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			btn_Organization = new Button();
			btn_Process = new Button();
			btn_Environment = new Button();
			btn_Resources = new Button();
			lbl_checkAffiliation = new Label();
			lbl_checkElementWithoutRedundacy = new Label();
			lbl_checkActivityWithRedundacy = new Label();
			lbl_checkActivityWithoutRedundacy = new Label();
			lbl_checkElementWithRedundacy = new Label();
			btn_errorLog = new Button();
			btn_DownloadComponentComparativeMatrix = new Button();
			btn_DownloadComponentComparativeMatrixWithRedundancy = new Button();
			btn_DownloadActivityComparativeMatrixWithRedundancy = new Button();
			btn_DeleteAll = new Button();
			btn_ExportAll = new Button();
			btn_ReadImage = new Button();
			btn_TracePaths = new Button();
			btn_DumpInstances = new Button();
			btn_Priorities = new Button();
			lbl_CheckPriorities = new Label();
			btn_Paralelism = new Button();
			lbl_CheckParalelism = new Label();
			btn_SaveTemplates = new Button();
			btn_ExportAllResults = new Button();
			label4 = new Label();
			label5 = new Label();
			label6 = new Label();
			btn_DownloadParalelism = new Button();
			btn_DownloadPriorities = new Button();
			SuspendLayout();
			// 
			// lbl_Titulo
			// 
			lbl_Titulo.AutoSize = true;
			lbl_Titulo.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_Titulo.Location = new Point(22, 53);
			lbl_Titulo.Name = "lbl_Titulo";
			lbl_Titulo.Size = new Size(333, 32);
			lbl_Titulo.TabIndex = 0;
			lbl_Titulo.Text = "Identificação do mapeamento";
			// 
			// rtxtb_DescProjeto
			// 
			rtxtb_DescProjeto.Location = new Point(22, 189);
			rtxtb_DescProjeto.Margin = new Padding(3, 4, 3, 4);
			rtxtb_DescProjeto.Name = "rtxtb_DescProjeto";
			rtxtb_DescProjeto.Size = new Size(413, 328);
			rtxtb_DescProjeto.TabIndex = 4;
			rtxtb_DescProjeto.Text = "";
			// 
			// lbl_NomeProj
			// 
			lbl_NomeProj.AutoSize = true;
			lbl_NomeProj.Location = new Point(23, 97);
			lbl_NomeProj.Name = "lbl_NomeProj";
			lbl_NomeProj.Size = new Size(125, 20);
			lbl_NomeProj.TabIndex = 1;
			lbl_NomeProj.Text = "Nome do projeto";
			// 
			// lbl_ObjProj
			// 
			lbl_ObjProj.AutoSize = true;
			lbl_ObjProj.Location = new Point(22, 165);
			lbl_ObjProj.Name = "lbl_ObjProj";
			lbl_ObjProj.Size = new Size(186, 20);
			lbl_ObjProj.TabIndex = 3;
			lbl_ObjProj.Text = "Anotações sobre o projeto";
			// 
			// btn_Salvar
			// 
			btn_Salvar.Location = new Point(283, 536);
			btn_Salvar.Margin = new Padding(3, 4, 3, 4);
			btn_Salvar.Name = "btn_Salvar";
			btn_Salvar.Size = new Size(151, 31);
			btn_Salvar.TabIndex = 5;
			btn_Salvar.Text = "Salvar";
			btn_Salvar.UseVisualStyleBackColor = true;
			btn_Salvar.Click += btn_Salvar_Click;
			// 
			// rtxtb_NomeProjeto
			// 
			rtxtb_NomeProjeto.Location = new Point(23, 121);
			rtxtb_NomeProjeto.Margin = new Padding(3, 4, 3, 4);
			rtxtb_NomeProjeto.Multiline = false;
			rtxtb_NomeProjeto.Name = "rtxtb_NomeProjeto";
			rtxtb_NomeProjeto.Size = new Size(412, 37);
			rtxtb_NomeProjeto.TabIndex = 2;
			rtxtb_NomeProjeto.Text = "";
			// 
			// btn_ProcessData
			// 
			btn_ProcessData.Location = new Point(699, 255);
			btn_ProcessData.Name = "btn_ProcessData";
			btn_ProcessData.Size = new Size(136, 43);
			btn_ProcessData.TabIndex = 11;
			btn_ProcessData.Text = "Processar ";
			btn_ProcessData.UseVisualStyleBackColor = true;
			btn_ProcessData.Click += btn_ProcessData_Click;
			// 
			// lbl_processStatus
			// 
			lbl_processStatus.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_processStatus.Location = new Point(699, 301);
			lbl_processStatus.Name = "lbl_processStatus";
			lbl_processStatus.Size = new Size(158, 66);
			lbl_processStatus.TabIndex = 12;
			lbl_processStatus.Text = "Processamento:";
			// 
			// btn_ActivitiesDependenciesMatrix
			// 
			btn_ActivitiesDependenciesMatrix.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
			btn_ActivitiesDependenciesMatrix.Location = new Point(917, 211);
			btn_ActivitiesDependenciesMatrix.Margin = new Padding(3, 4, 3, 4);
			btn_ActivitiesDependenciesMatrix.Name = "btn_ActivitiesDependenciesMatrix";
			btn_ActivitiesDependenciesMatrix.Size = new Size(249, 31);
			btn_ActivitiesDependenciesMatrix.TabIndex = 14;
			btn_ActivitiesDependenciesMatrix.Text = "Relação entre Atividades do Processo";
			btn_ActivitiesDependenciesMatrix.UseVisualStyleBackColor = true;
			btn_ActivitiesDependenciesMatrix.Click += btn_ActivitiesDependenciesMatrix_Click;
			// 
			// btn_DownloadActivityComparativeMatrix
			// 
			btn_DownloadActivityComparativeMatrix.BackgroundImage = Properties.Resources.download_icon_black;
			btn_DownloadActivityComparativeMatrix.BackgroundImageLayout = ImageLayout.Center;
			btn_DownloadActivityComparativeMatrix.Location = new Point(1569, 187);
			btn_DownloadActivityComparativeMatrix.Margin = new Padding(3, 4, 3, 4);
			btn_DownloadActivityComparativeMatrix.Name = "btn_DownloadActivityComparativeMatrix";
			btn_DownloadActivityComparativeMatrix.Size = new Size(34, 31);
			btn_DownloadActivityComparativeMatrix.TabIndex = 23;
			btn_DownloadActivityComparativeMatrix.UseVisualStyleBackColor = true;
			btn_DownloadActivityComparativeMatrix.Click += btn_DownloadComparativeMatrix_Click;
			// 
			// btn_DownloadElementMatrix
			// 
			btn_DownloadElementMatrix.BackgroundImage = Properties.Resources.download_icon_black;
			btn_DownloadElementMatrix.BackgroundImageLayout = ImageLayout.Center;
			btn_DownloadElementMatrix.Location = new Point(1168, 309);
			btn_DownloadElementMatrix.Margin = new Padding(3, 4, 3, 4);
			btn_DownloadElementMatrix.Name = "btn_DownloadElementMatrix";
			btn_DownloadElementMatrix.Size = new Size(35, 31);
			btn_DownloadElementMatrix.TabIndex = 19;
			btn_DownloadElementMatrix.Text = "\r\n";
			btn_DownloadElementMatrix.UseVisualStyleBackColor = true;
			btn_DownloadElementMatrix.Click += btn_DownloadElementMatrix_Click;
			// 
			// btn_DownloadActivivtyMatrix
			// 
			btn_DownloadActivivtyMatrix.BackgroundImage = Properties.Resources.download_icon_black;
			btn_DownloadActivivtyMatrix.BackgroundImageLayout = ImageLayout.Center;
			btn_DownloadActivivtyMatrix.Location = new Point(1168, 211);
			btn_DownloadActivivtyMatrix.Margin = new Padding(3, 4, 3, 4);
			btn_DownloadActivivtyMatrix.Name = "btn_DownloadActivivtyMatrix";
			btn_DownloadActivivtyMatrix.Size = new Size(35, 31);
			btn_DownloadActivivtyMatrix.TabIndex = 15;
			btn_DownloadActivivtyMatrix.UseVisualStyleBackColor = true;
			btn_DownloadActivivtyMatrix.Click += btn_DownloadActivivtyMatrix_Click;
			// 
			// btn_ComparativeMatrixWithRedundancies
			// 
			btn_ComparativeMatrixWithRedundancies.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
			btn_ComparativeMatrixWithRedundancies.Location = new Point(1262, 235);
			btn_ComparativeMatrixWithRedundancies.Margin = new Padding(3, 4, 3, 4);
			btn_ComparativeMatrixWithRedundancies.Name = "btn_ComparativeMatrixWithRedundancies";
			btn_ComparativeMatrixWithRedundancies.Size = new Size(301, 31);
			btn_ComparativeMatrixWithRedundancies.TabIndex = 24;
			btn_ComparativeMatrixWithRedundancies.Text = "Congruência do Processo - com redundância";
			btn_ComparativeMatrixWithRedundancies.UseVisualStyleBackColor = true;
			btn_ComparativeMatrixWithRedundancies.Click += btn_ComparativeMatrixWithRedundancies_Click;
			// 
			// btn_ComparativeMatrixWithoutRedundancies
			// 
			btn_ComparativeMatrixWithoutRedundancies.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
			btn_ComparativeMatrixWithoutRedundancies.Location = new Point(1262, 185);
			btn_ComparativeMatrixWithoutRedundancies.Margin = new Padding(3, 4, 3, 4);
			btn_ComparativeMatrixWithoutRedundancies.Name = "btn_ComparativeMatrixWithoutRedundancies";
			btn_ComparativeMatrixWithoutRedundancies.Size = new Size(301, 31);
			btn_ComparativeMatrixWithoutRedundancies.TabIndex = 22;
			btn_ComparativeMatrixWithoutRedundancies.Text = "Congruência do Processo - sem redundância";
			btn_ComparativeMatrixWithoutRedundancies.UseVisualStyleBackColor = true;
			btn_ComparativeMatrixWithoutRedundancies.Click += btn_ComparativeMatrixWithoutRedundancies_Click;
			// 
			// btn_ComponentsInterfacesMatrix
			// 
			btn_ComponentsInterfacesMatrix.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
			btn_ComponentsInterfacesMatrix.Location = new Point(919, 309);
			btn_ComponentsInterfacesMatrix.Margin = new Padding(3, 4, 3, 4);
			btn_ComponentsInterfacesMatrix.Name = "btn_ComponentsInterfacesMatrix";
			btn_ComponentsInterfacesMatrix.Size = new Size(249, 31);
			btn_ComponentsInterfacesMatrix.TabIndex = 18;
			btn_ComponentsInterfacesMatrix.Text = "Relação entre Elementos do Ambiente";
			btn_ComponentsInterfacesMatrix.UseVisualStyleBackColor = true;
			btn_ComponentsInterfacesMatrix.Click += btn_ComponentsInterfacesMatrix_Click;
			// 
			// btn_ComponentComparativeMatrixWithRedundancies
			// 
			btn_ComponentComparativeMatrixWithRedundancies.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
			btn_ComponentComparativeMatrixWithRedundancies.Location = new Point(1262, 335);
			btn_ComponentComparativeMatrixWithRedundancies.Margin = new Padding(3, 4, 3, 4);
			btn_ComponentComparativeMatrixWithRedundancies.Name = "btn_ComponentComparativeMatrixWithRedundancies";
			btn_ComponentComparativeMatrixWithRedundancies.Size = new Size(301, 31);
			btn_ComponentComparativeMatrixWithRedundancies.TabIndex = 28;
			btn_ComponentComparativeMatrixWithRedundancies.Text = "Congruência do Ambiente - com redundância";
			btn_ComponentComparativeMatrixWithRedundancies.UseVisualStyleBackColor = true;
			btn_ComponentComparativeMatrixWithRedundancies.Click += btn_ComponentComparativeMatrixWithRedundancies_Click;
			// 
			// btn_ComponentComparativeMatrixWithoutRedundancies
			// 
			btn_ComponentComparativeMatrixWithoutRedundancies.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
			btn_ComponentComparativeMatrixWithoutRedundancies.Location = new Point(1262, 285);
			btn_ComponentComparativeMatrixWithoutRedundancies.Margin = new Padding(3, 4, 3, 4);
			btn_ComponentComparativeMatrixWithoutRedundancies.Name = "btn_ComponentComparativeMatrixWithoutRedundancies";
			btn_ComponentComparativeMatrixWithoutRedundancies.Size = new Size(301, 31);
			btn_ComponentComparativeMatrixWithoutRedundancies.TabIndex = 26;
			btn_ComponentComparativeMatrixWithoutRedundancies.Text = "Congruência do Ambiente - sem redundância";
			btn_ComponentComparativeMatrixWithoutRedundancies.UseVisualStyleBackColor = true;
			btn_ComponentComparativeMatrixWithoutRedundancies.Click += btn_ComponentComparativeMatrixWithoutRedundancies_Click;
			// 
			// btn_AffiliationMatrix
			// 
			btn_AffiliationMatrix.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
			btn_AffiliationMatrix.Location = new Point(917, 260);
			btn_AffiliationMatrix.Margin = new Padding(3, 4, 3, 4);
			btn_AffiliationMatrix.Name = "btn_AffiliationMatrix";
			btn_AffiliationMatrix.Size = new Size(249, 31);
			btn_AffiliationMatrix.TabIndex = 16;
			btn_AffiliationMatrix.Text = "Relação entre Atividades e Elementos";
			btn_AffiliationMatrix.UseVisualStyleBackColor = true;
			btn_AffiliationMatrix.Click += btn_AffiliationMatrix_Click;
			// 
			// btn_DownloadRelationshipMatrix
			// 
			btn_DownloadRelationshipMatrix.BackgroundImage = Properties.Resources.download_icon_black;
			btn_DownloadRelationshipMatrix.BackgroundImageLayout = ImageLayout.Center;
			btn_DownloadRelationshipMatrix.Location = new Point(1168, 260);
			btn_DownloadRelationshipMatrix.Margin = new Padding(3, 4, 3, 4);
			btn_DownloadRelationshipMatrix.Name = "btn_DownloadRelationshipMatrix";
			btn_DownloadRelationshipMatrix.Size = new Size(35, 31);
			btn_DownloadRelationshipMatrix.TabIndex = 17;
			btn_DownloadRelationshipMatrix.UseVisualStyleBackColor = true;
			btn_DownloadRelationshipMatrix.Click += btn_DownloadRelationshipMatrix_Click;
			// 
			// lbl_checkActivity
			// 
			lbl_checkActivity.AutoSize = true;
			lbl_checkActivity.Location = new Point(897, 215);
			lbl_checkActivity.Name = "lbl_checkActivity";
			lbl_checkActivity.Size = new Size(16, 20);
			lbl_checkActivity.TabIndex = 21;
			lbl_checkActivity.Text = "x";
			// 
			// lbl_checkComponents
			// 
			lbl_checkComponents.AutoSize = true;
			lbl_checkComponents.Location = new Point(897, 315);
			lbl_checkComponents.Name = "lbl_checkComponents";
			lbl_checkComponents.Size = new Size(16, 20);
			lbl_checkComponents.TabIndex = 22;
			lbl_checkComponents.Text = "x";
			// 
			// lbl_Separator_Vertical
			// 
			lbl_Separator_Vertical.BorderStyle = BorderStyle.Fixed3D;
			lbl_Separator_Vertical.Location = new Point(471, 29);
			lbl_Separator_Vertical.Name = "lbl_Separator_Vertical";
			lbl_Separator_Vertical.Size = new Size(2, 640);
			lbl_Separator_Vertical.TabIndex = 37;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(509, 135);
			label1.Name = "label1";
			label1.Size = new Size(153, 23);
			label1.TabIndex = 38;
			label1.Text = "Inserção de dados:";
			label1.TextAlign = ContentAlignment.TopCenter;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			label2.Location = new Point(511, 53);
			label2.Name = "label2";
			label2.Size = new Size(296, 32);
			label2.TabIndex = 39;
			label2.Text = "Execução do mapeamento";
			label2.TextAlign = ContentAlignment.TopCenter;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
			label3.Location = new Point(897, 135);
			label3.Name = "label3";
			label3.Size = new Size(222, 23);
			label3.TabIndex = 40;
			label3.Text = "Visualização dos resultados:";
			label3.TextAlign = ContentAlignment.TopCenter;
			// 
			// btn_Organization
			// 
			btn_Organization.Location = new Point(511, 185);
			btn_Organization.Name = "btn_Organization";
			btn_Organization.Size = new Size(144, 31);
			btn_Organization.TabIndex = 6;
			btn_Organization.Text = "Organização";
			btn_Organization.UseVisualStyleBackColor = true;
			btn_Organization.Click += btn_Organization_Click;
			// 
			// btn_Process
			// 
			btn_Process.Location = new Point(511, 235);
			btn_Process.Name = "btn_Process";
			btn_Process.Size = new Size(144, 31);
			btn_Process.TabIndex = 7;
			btn_Process.Text = "Processo";
			btn_Process.UseVisualStyleBackColor = true;
			btn_Process.Click += btn_Process_Click;
			// 
			// btn_Environment
			// 
			btn_Environment.Location = new Point(511, 285);
			btn_Environment.Name = "btn_Environment";
			btn_Environment.Size = new Size(144, 31);
			btn_Environment.TabIndex = 8;
			btn_Environment.Text = "Ambiente";
			btn_Environment.UseVisualStyleBackColor = true;
			btn_Environment.Click += btn_Environment_Click;
			// 
			// btn_Resources
			// 
			btn_Resources.Location = new Point(511, 335);
			btn_Resources.Name = "btn_Resources";
			btn_Resources.Size = new Size(144, 31);
			btn_Resources.TabIndex = 9;
			btn_Resources.Text = "Recurso";
			btn_Resources.UseVisualStyleBackColor = true;
			btn_Resources.Click += btn_Resources_Click;
			// 
			// lbl_checkAffiliation
			// 
			lbl_checkAffiliation.AutoSize = true;
			lbl_checkAffiliation.Location = new Point(897, 265);
			lbl_checkAffiliation.Name = "lbl_checkAffiliation";
			lbl_checkAffiliation.Size = new Size(16, 20);
			lbl_checkAffiliation.TabIndex = 45;
			lbl_checkAffiliation.Text = "x";
			// 
			// lbl_checkElementWithoutRedundacy
			// 
			lbl_checkElementWithoutRedundacy.AutoSize = true;
			lbl_checkElementWithoutRedundacy.Location = new Point(1243, 291);
			lbl_checkElementWithoutRedundacy.Name = "lbl_checkElementWithoutRedundacy";
			lbl_checkElementWithoutRedundacy.Size = new Size(16, 20);
			lbl_checkElementWithoutRedundacy.TabIndex = 48;
			lbl_checkElementWithoutRedundacy.Text = "x";
			// 
			// lbl_checkActivityWithRedundacy
			// 
			lbl_checkActivityWithRedundacy.AutoSize = true;
			lbl_checkActivityWithRedundacy.Location = new Point(1243, 240);
			lbl_checkActivityWithRedundacy.Name = "lbl_checkActivityWithRedundacy";
			lbl_checkActivityWithRedundacy.Size = new Size(16, 20);
			lbl_checkActivityWithRedundacy.TabIndex = 47;
			lbl_checkActivityWithRedundacy.Text = "x";
			// 
			// lbl_checkActivityWithoutRedundacy
			// 
			lbl_checkActivityWithoutRedundacy.AutoSize = true;
			lbl_checkActivityWithoutRedundacy.Location = new Point(1243, 189);
			lbl_checkActivityWithoutRedundacy.Name = "lbl_checkActivityWithoutRedundacy";
			lbl_checkActivityWithoutRedundacy.Size = new Size(16, 20);
			lbl_checkActivityWithoutRedundacy.TabIndex = 46;
			lbl_checkActivityWithoutRedundacy.Text = "x";
			// 
			// lbl_checkElementWithRedundacy
			// 
			lbl_checkElementWithRedundacy.AutoSize = true;
			lbl_checkElementWithRedundacy.Location = new Point(1243, 340);
			lbl_checkElementWithRedundacy.Name = "lbl_checkElementWithRedundacy";
			lbl_checkElementWithRedundacy.Size = new Size(16, 20);
			lbl_checkElementWithRedundacy.TabIndex = 49;
			lbl_checkElementWithRedundacy.Text = "x";
			// 
			// btn_errorLog
			// 
			btn_errorLog.Location = new Point(699, 370);
			btn_errorLog.Name = "btn_errorLog";
			btn_errorLog.Size = new Size(138, 29);
			btn_errorLog.TabIndex = 13;
			btn_errorLog.Text = "Relatório de erro";
			btn_errorLog.UseVisualStyleBackColor = true;
			btn_errorLog.Click += btn_errorLog_Click;
			// 
			// btn_DownloadComponentComparativeMatrix
			// 
			btn_DownloadComponentComparativeMatrix.BackgroundImage = Properties.Resources.download_icon_black;
			btn_DownloadComponentComparativeMatrix.BackgroundImageLayout = ImageLayout.Center;
			btn_DownloadComponentComparativeMatrix.Location = new Point(1569, 285);
			btn_DownloadComponentComparativeMatrix.Margin = new Padding(3, 4, 3, 4);
			btn_DownloadComponentComparativeMatrix.Name = "btn_DownloadComponentComparativeMatrix";
			btn_DownloadComponentComparativeMatrix.Size = new Size(35, 31);
			btn_DownloadComponentComparativeMatrix.TabIndex = 27;
			btn_DownloadComponentComparativeMatrix.UseVisualStyleBackColor = true;
			btn_DownloadComponentComparativeMatrix.Click += btn_DownloadComponentComparativeMatrix_Click;
			// 
			// btn_DownloadComponentComparativeMatrixWithRedundancy
			// 
			btn_DownloadComponentComparativeMatrixWithRedundancy.BackgroundImage = Properties.Resources.download_icon_black;
			btn_DownloadComponentComparativeMatrixWithRedundancy.BackgroundImageLayout = ImageLayout.Center;
			btn_DownloadComponentComparativeMatrixWithRedundancy.Location = new Point(1569, 335);
			btn_DownloadComponentComparativeMatrixWithRedundancy.Margin = new Padding(3, 4, 3, 4);
			btn_DownloadComponentComparativeMatrixWithRedundancy.Name = "btn_DownloadComponentComparativeMatrixWithRedundancy";
			btn_DownloadComponentComparativeMatrixWithRedundancy.Size = new Size(35, 31);
			btn_DownloadComponentComparativeMatrixWithRedundancy.TabIndex = 29;
			btn_DownloadComponentComparativeMatrixWithRedundancy.Text = "\r\n";
			btn_DownloadComponentComparativeMatrixWithRedundancy.UseVisualStyleBackColor = true;
			btn_DownloadComponentComparativeMatrixWithRedundancy.Click += btn_DownloadComponentComparativeMatrixWithRedundancy_Click;
			// 
			// btn_DownloadActivityComparativeMatrixWithRedundancy
			// 
			btn_DownloadActivityComparativeMatrixWithRedundancy.BackgroundImage = Properties.Resources.download_icon_black;
			btn_DownloadActivityComparativeMatrixWithRedundancy.BackgroundImageLayout = ImageLayout.Center;
			btn_DownloadActivityComparativeMatrixWithRedundancy.Location = new Point(1569, 235);
			btn_DownloadActivityComparativeMatrixWithRedundancy.Margin = new Padding(3, 4, 3, 4);
			btn_DownloadActivityComparativeMatrixWithRedundancy.Name = "btn_DownloadActivityComparativeMatrixWithRedundancy";
			btn_DownloadActivityComparativeMatrixWithRedundancy.Size = new Size(35, 31);
			btn_DownloadActivityComparativeMatrixWithRedundancy.TabIndex = 25;
			btn_DownloadActivityComparativeMatrixWithRedundancy.UseVisualStyleBackColor = true;
			btn_DownloadActivityComparativeMatrixWithRedundancy.Click += btn_DownloadActivityComparativeMatrixWithRedundancy_Click;
			// 
			// btn_DeleteAll
			// 
			btn_DeleteAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_DeleteAll.Location = new Point(23, 707);
			btn_DeleteAll.Margin = new Padding(3, 4, 3, 4);
			btn_DeleteAll.Name = "btn_DeleteAll";
			btn_DeleteAll.Size = new Size(207, 31);
			btn_DeleteAll.TabIndex = 54;
			btn_DeleteAll.Text = "Limpar dados da aplicação";
			btn_DeleteAll.UseVisualStyleBackColor = true;
			btn_DeleteAll.Click += btn_DeleteAll_Click;
			// 
			// btn_ExportAll
			// 
			btn_ExportAll.Location = new Point(509, 502);
			btn_ExportAll.Name = "btn_ExportAll";
			btn_ExportAll.Size = new Size(144, 65);
			btn_ExportAll.TabIndex = 10;
			btn_ExportAll.Text = "Exportar .csv dos dados inseridos";
			btn_ExportAll.UseVisualStyleBackColor = true;
			btn_ExportAll.Click += btn_ExportAll_Click;
			// 
			// btn_ReadImage
			// 
			btn_ReadImage.Location = new Point(509, 573);
			btn_ReadImage.Name = "btn_ReadImage";
			btn_ReadImage.Size = new Size(144, 65);
			btn_ReadImage.TabIndex = 10;
			btn_ReadImage.Text = "Ler imagem de planta";
			btn_ReadImage.UseVisualStyleBackColor = true;
			btn_ReadImage.Click += btn_ReadImage_Click;
            // 
            // btn_TracePaths
            // 
            btn_TracePaths.Location = new Point(509, 644);
            btn_TracePaths.Name = "btn_TracePaths";
            btn_TracePaths.Size = new Size(144, 65);
            btn_TracePaths.TabIndex = 10;
            btn_TracePaths.Text = "Traçar caminho das atividades";
            btn_TracePaths.UseVisualStyleBackColor = true;
            btn_TracePaths.Click += btn_TracePaths_Click;
            // 
            // btn_DumpInstances
            // 
            btn_DumpInstances.Location = new Point(509, 715);
            btn_DumpInstances.Name = "btn_DumpInstances";
            btn_DumpInstances.Size = new Size(144, 65);
            btn_DumpInstances.TabIndex = 10;
            btn_DumpInstances.Text = "Salvar instâncias";
            btn_DumpInstances.UseVisualStyleBackColor = true;
            btn_DumpInstances.Click += btn_DumpInstances_Click;
            // 
            // btn_Priorities
            // 
            btn_Priorities.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
			btn_Priorities.Location = new Point(919, 385);
			btn_Priorities.Name = "btn_Priorities";
			btn_Priorities.Size = new Size(267, 29);
			btn_Priorities.TabIndex = 20;
			btn_Priorities.Text = "Relação de prioridade de atividades";
			btn_Priorities.UseVisualStyleBackColor = true;
			btn_Priorities.Click += btn_Priorities_Click;
			// 
			// lbl_CheckPriorities
			// 
			lbl_CheckPriorities.AutoSize = true;
			lbl_CheckPriorities.Location = new Point(897, 389);
			lbl_CheckPriorities.Name = "lbl_CheckPriorities";
			lbl_CheckPriorities.Size = new Size(16, 20);
			lbl_CheckPriorities.TabIndex = 57;
			lbl_CheckPriorities.Text = "x";
			// 
			// btn_Paralelism
			// 
			btn_Paralelism.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
			btn_Paralelism.Location = new Point(919, 429);
			btn_Paralelism.Name = "btn_Paralelism";
			btn_Paralelism.Size = new Size(267, 29);
			btn_Paralelism.TabIndex = 21;
			btn_Paralelism.Text = "Relação de paralelismo entre atividades";
			btn_Paralelism.UseVisualStyleBackColor = true;
			btn_Paralelism.Click += button1_Click;
			// 
			// lbl_CheckParalelism
			// 
			lbl_CheckParalelism.AutoSize = true;
			lbl_CheckParalelism.Location = new Point(897, 433);
			lbl_CheckParalelism.Name = "lbl_CheckParalelism";
			lbl_CheckParalelism.Size = new Size(16, 20);
			lbl_CheckParalelism.TabIndex = 59;
			lbl_CheckParalelism.Text = "x";
			// 
			// btn_SaveTemplates
			// 
			btn_SaveTemplates.Location = new Point(509, 424);
			btn_SaveTemplates.Name = "btn_SaveTemplates";
			btn_SaveTemplates.Size = new Size(144, 72);
			btn_SaveTemplates.TabIndex = 10;
			btn_SaveTemplates.Text = "Salvar templates .csv para importar dados";
			btn_SaveTemplates.UseVisualStyleBackColor = true;
			btn_SaveTemplates.Click += btn_SaveTemplates_Click;
			// 
			// btn_ExportAllResults
			// 
			btn_ExportAllResults.Location = new Point(1406, 414);
			btn_ExportAllResults.Name = "btn_ExportAllResults";
			btn_ExportAllResults.Size = new Size(197, 39);
			btn_ExportAllResults.TabIndex = 60;
			btn_ExportAllResults.Text = "Salvar todos os resultados";
			btn_ExportAllResults.UseVisualStyleBackColor = true;
			btn_ExportAllResults.Click += btn_ExportAllResults_Click;
			// 
			// label4
			// 
			label4.Location = new Point(1267, 527);
			label4.Name = "label4";
			label4.Size = new Size(345, 54);
			label4.TabIndex = 61;
			label4.Text = "- clicar no botão [↓] para salvar separadamente cada faceta.";
			// 
			// label5
			// 
			label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
			label5.Location = new Point(1267, 475);
			label5.Name = "label5";
			label5.Size = new Size(363, 46);
			label5.TabIndex = 62;
			label5.Text = "obs.: os resultados processados não ficam salvos. Para preservar os registros, é preciso: ";
			// 
			// label6
			// 
			label6.Location = new Point(1267, 581);
			label6.Name = "label6";
			label6.Size = new Size(345, 54);
			label6.TabIndex = 63;
			label6.Text = "- clicar em [salvar todos os resultados] ";
			// 
			// btn_DownloadParalelism
			// 
			btn_DownloadParalelism.BackgroundImage = Properties.Resources.download_icon_black;
			btn_DownloadParalelism.BackgroundImageLayout = ImageLayout.Center;
			btn_DownloadParalelism.Location = new Point(1188, 427);
			btn_DownloadParalelism.Margin = new Padding(3, 4, 3, 4);
			btn_DownloadParalelism.Name = "btn_DownloadParalelism";
			btn_DownloadParalelism.Size = new Size(35, 31);
			btn_DownloadParalelism.TabIndex = 64;
			btn_DownloadParalelism.Text = "\r\n";
			btn_DownloadParalelism.UseVisualStyleBackColor = true;
			btn_DownloadParalelism.Click += btn_DownloadParalelism_Click;
			// 
			// btn_DownloadPriorities
			// 
			btn_DownloadPriorities.BackgroundImage = Properties.Resources.download_icon_black;
			btn_DownloadPriorities.BackgroundImageLayout = ImageLayout.Center;
			btn_DownloadPriorities.Location = new Point(1188, 385);
			btn_DownloadPriorities.Margin = new Padding(3, 4, 3, 4);
			btn_DownloadPriorities.Name = "btn_DownloadPriorities";
			btn_DownloadPriorities.Size = new Size(35, 31);
			btn_DownloadPriorities.TabIndex = 65;
			btn_DownloadPriorities.Text = "\r\n";
			btn_DownloadPriorities.UseVisualStyleBackColor = true;
			btn_DownloadPriorities.Click += btn_DownloadPriorities_Click;
			// 
			// Frm_Main
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1685, 753);
			Controls.Add(btn_DownloadPriorities);
			Controls.Add(btn_DownloadParalelism);
			Controls.Add(label6);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(btn_ExportAllResults);
			Controls.Add(btn_SaveTemplates);
			Controls.Add(lbl_CheckParalelism);
			Controls.Add(btn_Paralelism);
			Controls.Add(lbl_CheckPriorities);
			Controls.Add(btn_Priorities);
			Controls.Add(btn_ExportAll);
			Controls.Add(btn_ReadImage);
			Controls.Add(btn_TracePaths);
			Controls.Add(btn_DumpInstances);
			Controls.Add(btn_DeleteAll);
			Controls.Add(btn_DownloadComponentComparativeMatrix);
			Controls.Add(btn_DownloadComponentComparativeMatrixWithRedundancy);
			Controls.Add(btn_DownloadActivityComparativeMatrixWithRedundancy);
			Controls.Add(btn_errorLog);
			Controls.Add(lbl_checkElementWithRedundacy);
			Controls.Add(lbl_checkElementWithoutRedundacy);
			Controls.Add(lbl_checkActivityWithRedundacy);
			Controls.Add(lbl_checkActivityWithoutRedundacy);
			Controls.Add(lbl_checkAffiliation);
			Controls.Add(btn_Resources);
			Controls.Add(btn_Environment);
			Controls.Add(btn_Process);
			Controls.Add(btn_Organization);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(lbl_Separator_Vertical);
			Controls.Add(lbl_checkComponents);
			Controls.Add(lbl_checkActivity);
			Controls.Add(btn_DownloadRelationshipMatrix);
			Controls.Add(btn_AffiliationMatrix);
			Controls.Add(btn_ComponentComparativeMatrixWithRedundancies);
			Controls.Add(btn_ComponentComparativeMatrixWithoutRedundancies);
			Controls.Add(btn_DownloadActivityComparativeMatrix);
			Controls.Add(btn_DownloadElementMatrix);
			Controls.Add(btn_DownloadActivivtyMatrix);
			Controls.Add(btn_ComparativeMatrixWithRedundancies);
			Controls.Add(btn_ComparativeMatrixWithoutRedundancies);
			Controls.Add(btn_ComponentsInterfacesMatrix);
			Controls.Add(btn_ActivitiesDependenciesMatrix);
			Controls.Add(lbl_processStatus);
			Controls.Add(btn_ProcessData);
			Controls.Add(rtxtb_NomeProjeto);
			Controls.Add(btn_Salvar);
			Controls.Add(lbl_ObjProj);
			Controls.Add(lbl_NomeProj);
			Controls.Add(rtxtb_DescProjeto);
			Controls.Add(lbl_Titulo);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "Frm_Main";
			Text = "MAEA - Geral";
			WindowState = FormWindowState.Maximized;
			Load += Frm_Geral_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Label lbl_Titulo;
		private RichTextBox rtxtb_DescProjeto;
		private Label lbl_NomeProj;
		private Label lbl_ObjProj;
		private Button btn_Salvar;
		private RichTextBox rtxtb_NomeProjeto;
		private Button btn_ProcessData;
		private Label lbl_processStatus;
		private Button btn_ActivitiesDependenciesMatrix;
		private Button btn_DownloadActivityComparativeMatrix;
		private Button btn_DownloadElementMatrix;
		private Button btn_DownloadActivivtyMatrix;
		private Button btn_ComparativeMatrixWithRedundancies;
		private Button btn_ComparativeMatrixWithoutRedundancies;
		private Button btn_ComponentsInterfacesMatrix;
		private Button btn_ComponentComparativeMatrixWithRedundancies;
		private Button btn_ComponentComparativeMatrixWithoutRedundancies;
		private Button btn_AffiliationMatrix;
		private Button btn_DownloadRelationshipMatrix;
		private Label lbl_checkActivity;
		private Label lbl_checkComponents;
		private Label lbl_Separator_Vertical;
		private Label label1;
		private Label label2;
		private Label label3;
		private Button btn_Organization;
		private Button btn_Process;
		private Button btn_Environment;
		private Button btn_Resources;
		private Label lbl_checkAffiliation;
		private Label lbl_checkElementWithoutRedundacy;
		private Label lbl_checkActivityWithRedundacy;
		private Label lbl_checkActivityWithoutRedundacy;
		private Label lbl_checkElementWithRedundacy;
		private Button btn_errorLog;
		private Button btn_DownloadComponentComparativeMatrix;
		private Button btn_DownloadComponentComparativeMatrixWithRedundancy;
		private Button btn_DownloadActivityComparativeMatrixWithRedundancy;
		private Button btn_DeleteAll;
		private Button btn_ExportAll;
		private Button btn_ReadImage;
		private Button btn_TracePaths;
		private Button btn_DumpInstances;
		private Button btn_Priorities;
		private Label lbl_CheckPriorities;
		private Button btn_Paralelism;
		private Label lbl_CheckParalelism;
		private Button btn_SaveTemplates;
		private Button btn_ExportAllResults;
		private Label label4;
		private Label label5;
		private Label label6;
		private Button btn_DownloadParalelism;
		private Button btn_DownloadPriorities;
	}
}