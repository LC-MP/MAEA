namespace MSCMD.Forms
{
	partial class Frm_Element
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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Element));
			lbl_Titulo = new Label();
			dg_Elementos = new DataGridView();
			elementIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			codeDataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
			nameDataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
			typeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			externalIdentifierDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			componentClassDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			organizationIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			ocupiedByDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			surfaceTypeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			elementBindingSource = new BindingSource(components);
			label2 = new Label();
			dg_RelacaoElemento = new DataGridView();
			dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			codeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			relationshipViewModelBindingSource = new BindingSource(components);
			dg_Organization = new DataGridView();
			dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
			codeDataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
			organizationBindingSource = new BindingSource(components);
			lbl_DetElemento = new Label();
			lbl_DetElementoDesc = new Label();
			lbl_RelElemento = new Label();
			lbl_RelAtividade = new Label();
			lbl_RelSetor = new Label();
			btn_ShowAllElements = new Button();
			btn_FilterElements = new Button();
			btn_ManageSubsystems = new Button();
			lbl_NomeElemento = new Label();
			btn_DesvincElemento = new Button();
			btn_VincElemento = new Button();
			btn_VincAtividade = new Button();
			btn_DesvincAtividade = new Button();
			btn_ImportElementos = new Button();
			rtbox_ExternalId = new RichTextBox();
			rtbox_Type = new RichTextBox();
			rtbox_objectClass = new RichTextBox();
			rtbox_SType = new RichTextBox();
			lbl_IdExterno = new Label();
			lbl_TipoElem = new Label();
			lbl_ClasseObj = new Label();
			label1 = new Label();
			btn_SalvarDetalhes = new Button();
			lbl_Separator_Vertical = new Label();
			dg_RelacaoAtividade = new DataGridView();
			dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
			codeDataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
			nameDataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
			relationshipViewModelBindingSource1 = new BindingSource(components);
			btn_DeleteElementoSelecao = new Button();
			btn_SetOrganization = new Button();
			dg_Group = new DataGridView();
			subsystemIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			codeDataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
			nameDataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
			subsystemBindingSource = new BindingSource(components);
			lbl_SectorFilter = new Label();
			btn_DelSubsystem = new Button();
			btn_ImportElementRelationship = new Button();
			btn_ImportElementActivityRelationship = new Button();
			lbl_ElementsTotal = new Label();
			btn_ImportSectors = new Button();
			btn_ExportSubsystem = new Button();
			btn_ExportElements = new Button();
			btn_ExportElementElement = new Button();
			btn_ExportElementActivity = new Button();
			label3 = new Label();
			subsystemBindingSource1 = new BindingSource(components);
			dataGridView1 = new DataGridView();
			subsystemIdDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			codeDataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
			nameDataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
			button1 = new Button();
			btn_DeleteRelSubsystem = new Button();
			btn_New = new Button();
			btn_NewGroup = new Button();
			btn_DeleteDivision = new Button();
			((System.ComponentModel.ISupportInitialize)dg_Elementos).BeginInit();
			((System.ComponentModel.ISupportInitialize)elementBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)dg_RelacaoElemento).BeginInit();
			((System.ComponentModel.ISupportInitialize)relationshipViewModelBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)dg_Organization).BeginInit();
			((System.ComponentModel.ISupportInitialize)organizationBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)dg_RelacaoAtividade).BeginInit();
			((System.ComponentModel.ISupportInitialize)relationshipViewModelBindingSource1).BeginInit();
			((System.ComponentModel.ISupportInitialize)dg_Group).BeginInit();
			((System.ComponentModel.ISupportInitialize)subsystemBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)subsystemBindingSource1).BeginInit();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// lbl_Titulo
			// 
			lbl_Titulo.AutoSize = true;
			lbl_Titulo.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_Titulo.Location = new Point(25, 28);
			lbl_Titulo.Name = "lbl_Titulo";
			lbl_Titulo.Size = new Size(247, 32);
			lbl_Titulo.TabIndex = 0;
			lbl_Titulo.Text = "Subsistemas / Setores";
			// 
			// dg_Elementos
			// 
			dg_Elementos.AllowUserToDeleteRows = false;
			dg_Elementos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			dg_Elementos.AutoGenerateColumns = false;
			dg_Elementos.BackgroundColor = SystemColors.ControlLight;
			dg_Elementos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_Elementos.Columns.AddRange(new DataGridViewColumn[] { elementIdDataGridViewTextBoxColumn, codeDataGridViewTextBoxColumn7, nameDataGridViewTextBoxColumn5, typeDataGridViewTextBoxColumn, externalIdentifierDataGridViewTextBoxColumn, componentClassDataGridViewTextBoxColumn, organizationIdDataGridViewTextBoxColumn, ocupiedByDataGridViewTextBoxColumn, surfaceTypeDataGridViewTextBoxColumn });
			dg_Elementos.DataSource = elementBindingSource;
			dg_Elementos.Location = new Point(25, 413);
			dg_Elementos.Name = "dg_Elementos";
			dg_Elementos.RowHeadersVisible = false;
			dg_Elementos.RowHeadersWidth = 51;
			dg_Elementos.RowTemplate.Height = 29;
			dg_Elementos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_Elementos.Size = new Size(534, 399);
			dg_Elementos.TabIndex = 11;
			dg_Elementos.CellClick += dg_Elementos_CellClick;
			dg_Elementos.CellEndEdit += dg_Elementos_CellEndEdit;
			dg_Elementos.CellEnter += dg_Elementos_CellEnter;
			dg_Elementos.CellFormatting += dg_Elementos_CellFormatting;
			dg_Elementos.ColumnHeaderMouseClick += dg_Elementos_ColumnHeaderMouseClick;
			// 
			// elementIdDataGridViewTextBoxColumn
			// 
			elementIdDataGridViewTextBoxColumn.DataPropertyName = "ElementId";
			elementIdDataGridViewTextBoxColumn.HeaderText = "Id";
			elementIdDataGridViewTextBoxColumn.MinimumWidth = 6;
			elementIdDataGridViewTextBoxColumn.Name = "elementIdDataGridViewTextBoxColumn";
			elementIdDataGridViewTextBoxColumn.ReadOnly = true;
			elementIdDataGridViewTextBoxColumn.Width = 55;
			// 
			// codeDataGridViewTextBoxColumn7
			// 
			codeDataGridViewTextBoxColumn7.DataPropertyName = "Code";
			codeDataGridViewTextBoxColumn7.HeaderText = "Código";
			codeDataGridViewTextBoxColumn7.MinimumWidth = 6;
			codeDataGridViewTextBoxColumn7.Name = "codeDataGridViewTextBoxColumn7";
			codeDataGridViewTextBoxColumn7.Width = 90;
			// 
			// nameDataGridViewTextBoxColumn5
			// 
			nameDataGridViewTextBoxColumn5.DataPropertyName = "Name";
			nameDataGridViewTextBoxColumn5.HeaderText = "Nome*";
			nameDataGridViewTextBoxColumn5.MinimumWidth = 6;
			nameDataGridViewTextBoxColumn5.Name = "nameDataGridViewTextBoxColumn5";
			nameDataGridViewTextBoxColumn5.Width = 320;
			// 
			// typeDataGridViewTextBoxColumn
			// 
			typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
			typeDataGridViewTextBoxColumn.HeaderText = "Type";
			typeDataGridViewTextBoxColumn.MinimumWidth = 6;
			typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
			typeDataGridViewTextBoxColumn.Visible = false;
			typeDataGridViewTextBoxColumn.Width = 125;
			// 
			// externalIdentifierDataGridViewTextBoxColumn
			// 
			externalIdentifierDataGridViewTextBoxColumn.DataPropertyName = "ExternalIdentifier";
			externalIdentifierDataGridViewTextBoxColumn.HeaderText = "ExternalIdentifier";
			externalIdentifierDataGridViewTextBoxColumn.MinimumWidth = 6;
			externalIdentifierDataGridViewTextBoxColumn.Name = "externalIdentifierDataGridViewTextBoxColumn";
			externalIdentifierDataGridViewTextBoxColumn.Visible = false;
			externalIdentifierDataGridViewTextBoxColumn.Width = 125;
			// 
			// componentClassDataGridViewTextBoxColumn
			// 
			componentClassDataGridViewTextBoxColumn.DataPropertyName = "ComponentClass";
			componentClassDataGridViewTextBoxColumn.HeaderText = "ComponentClass";
			componentClassDataGridViewTextBoxColumn.MinimumWidth = 6;
			componentClassDataGridViewTextBoxColumn.Name = "componentClassDataGridViewTextBoxColumn";
			componentClassDataGridViewTextBoxColumn.Visible = false;
			componentClassDataGridViewTextBoxColumn.Width = 125;
			// 
			// organizationIdDataGridViewTextBoxColumn
			// 
			organizationIdDataGridViewTextBoxColumn.DataPropertyName = "OrganizationId";
			organizationIdDataGridViewTextBoxColumn.HeaderText = "OrganizationId";
			organizationIdDataGridViewTextBoxColumn.MinimumWidth = 6;
			organizationIdDataGridViewTextBoxColumn.Name = "organizationIdDataGridViewTextBoxColumn";
			organizationIdDataGridViewTextBoxColumn.Visible = false;
			organizationIdDataGridViewTextBoxColumn.Width = 125;
			// 
			// ocupiedByDataGridViewTextBoxColumn
			// 
			ocupiedByDataGridViewTextBoxColumn.DataPropertyName = "OcupiedBy";
			ocupiedByDataGridViewTextBoxColumn.HeaderText = "OcupiedBy";
			ocupiedByDataGridViewTextBoxColumn.MinimumWidth = 6;
			ocupiedByDataGridViewTextBoxColumn.Name = "ocupiedByDataGridViewTextBoxColumn";
			ocupiedByDataGridViewTextBoxColumn.Visible = false;
			ocupiedByDataGridViewTextBoxColumn.Width = 125;
			// 
			// surfaceTypeDataGridViewTextBoxColumn
			// 
			surfaceTypeDataGridViewTextBoxColumn.DataPropertyName = "SurfaceType";
			surfaceTypeDataGridViewTextBoxColumn.HeaderText = "SurfaceType";
			surfaceTypeDataGridViewTextBoxColumn.MinimumWidth = 6;
			surfaceTypeDataGridViewTextBoxColumn.Name = "surfaceTypeDataGridViewTextBoxColumn";
			surfaceTypeDataGridViewTextBoxColumn.Visible = false;
			surfaceTypeDataGridViewTextBoxColumn.Width = 125;
			// 
			// elementBindingSource
			// 
			elementBindingSource.DataSource = typeof(Model.Element);
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			label2.Location = new Point(25, 373);
			label2.Name = "label2";
			label2.Size = new Size(130, 32);
			label2.TabIndex = 9;
			label2.Text = "Elementos:";
			// 
			// dg_RelacaoElemento
			// 
			dg_RelacaoElemento.AllowUserToDeleteRows = false;
			dg_RelacaoElemento.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			dg_RelacaoElemento.AutoGenerateColumns = false;
			dg_RelacaoElemento.BackgroundColor = SystemColors.ControlLight;
			dg_RelacaoElemento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_RelacaoElemento.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, codeDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn });
			dg_RelacaoElemento.DataSource = relationshipViewModelBindingSource;
			dg_RelacaoElemento.Location = new Point(617, 474);
			dg_RelacaoElemento.Margin = new Padding(3, 4, 3, 4);
			dg_RelacaoElemento.Name = "dg_RelacaoElemento";
			dg_RelacaoElemento.ReadOnly = true;
			dg_RelacaoElemento.RowHeadersVisible = false;
			dg_RelacaoElemento.RowHeadersWidth = 51;
			dg_RelacaoElemento.RowTemplate.Height = 25;
			dg_RelacaoElemento.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_RelacaoElemento.Size = new Size(512, 336);
			dg_RelacaoElemento.TabIndex = 34;
			// 
			// dataGridViewTextBoxColumn1
			// 
			dataGridViewTextBoxColumn1.DataPropertyName = "RelationshipId";
			dataGridViewTextBoxColumn1.HeaderText = "RelationshipId";
			dataGridViewTextBoxColumn1.MinimumWidth = 6;
			dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			dataGridViewTextBoxColumn1.ReadOnly = true;
			dataGridViewTextBoxColumn1.Visible = false;
			dataGridViewTextBoxColumn1.Width = 125;
			// 
			// dataGridViewTextBoxColumn2
			// 
			dataGridViewTextBoxColumn2.DataPropertyName = "Relationship";
			dataGridViewTextBoxColumn2.HeaderText = "Relação";
			dataGridViewTextBoxColumn2.MinimumWidth = 6;
			dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			dataGridViewTextBoxColumn2.ReadOnly = true;
			dataGridViewTextBoxColumn2.Width = 125;
			// 
			// codeDataGridViewTextBoxColumn
			// 
			codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
			codeDataGridViewTextBoxColumn.HeaderText = "Código";
			codeDataGridViewTextBoxColumn.MinimumWidth = 6;
			codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
			codeDataGridViewTextBoxColumn.ReadOnly = true;
			codeDataGridViewTextBoxColumn.Width = 80;
			// 
			// nameDataGridViewTextBoxColumn
			// 
			nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
			nameDataGridViewTextBoxColumn.HeaderText = "Nome";
			nameDataGridViewTextBoxColumn.MinimumWidth = 6;
			nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			nameDataGridViewTextBoxColumn.ReadOnly = true;
			nameDataGridViewTextBoxColumn.Width = 300;
			// 
			// relationshipViewModelBindingSource
			// 
			relationshipViewModelBindingSource.DataSource = typeof(ViewModel.RelationshipViewModel);
			// 
			// dg_Organization
			// 
			dg_Organization.AllowUserToAddRows = false;
			dg_Organization.AllowUserToDeleteRows = false;
			dg_Organization.AutoGenerateColumns = false;
			dg_Organization.BackgroundColor = SystemColors.ControlLight;
			dg_Organization.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_Organization.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn5, codeDataGridViewTextBoxColumn6, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn10, dataGridViewTextBoxColumn11 });
			dg_Organization.DataSource = organizationBindingSource;
			dg_Organization.Enabled = false;
			dg_Organization.Location = new Point(1147, 205);
			dg_Organization.Margin = new Padding(3, 4, 3, 4);
			dg_Organization.Name = "dg_Organization";
			dg_Organization.ReadOnly = true;
			dg_Organization.RowHeadersVisible = false;
			dg_Organization.RowHeadersWidth = 51;
			dg_Organization.RowTemplate.Height = 25;
			dg_Organization.Size = new Size(511, 187);
			dg_Organization.TabIndex = 31;
			// 
			// dataGridViewTextBoxColumn5
			// 
			dataGridViewTextBoxColumn5.DataPropertyName = "SectorId";
			dataGridViewTextBoxColumn5.HeaderText = "SectorId";
			dataGridViewTextBoxColumn5.MinimumWidth = 6;
			dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			dataGridViewTextBoxColumn5.ReadOnly = true;
			dataGridViewTextBoxColumn5.Visible = false;
			dataGridViewTextBoxColumn5.Width = 125;
			// 
			// codeDataGridViewTextBoxColumn6
			// 
			codeDataGridViewTextBoxColumn6.DataPropertyName = "Code";
			codeDataGridViewTextBoxColumn6.HeaderText = "Código";
			codeDataGridViewTextBoxColumn6.MinimumWidth = 6;
			codeDataGridViewTextBoxColumn6.Name = "codeDataGridViewTextBoxColumn6";
			codeDataGridViewTextBoxColumn6.ReadOnly = true;
			codeDataGridViewTextBoxColumn6.Width = 80;
			// 
			// dataGridViewTextBoxColumn6
			// 
			dataGridViewTextBoxColumn6.DataPropertyName = "SectorName";
			dataGridViewTextBoxColumn6.HeaderText = "Divisão Organizacional";
			dataGridViewTextBoxColumn6.MinimumWidth = 6;
			dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			dataGridViewTextBoxColumn6.ReadOnly = true;
			dataGridViewTextBoxColumn6.Width = 380;
			// 
			// dataGridViewTextBoxColumn7
			// 
			dataGridViewTextBoxColumn7.DataPropertyName = "Description";
			dataGridViewTextBoxColumn7.HeaderText = "Descrição";
			dataGridViewTextBoxColumn7.MinimumWidth = 6;
			dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			dataGridViewTextBoxColumn7.ReadOnly = true;
			dataGridViewTextBoxColumn7.Visible = false;
			dataGridViewTextBoxColumn7.Width = 125;
			// 
			// dataGridViewTextBoxColumn10
			// 
			dataGridViewTextBoxColumn10.DataPropertyName = "SuperiorInstanceId";
			dataGridViewTextBoxColumn10.HeaderText = "SuperiorInstanceId";
			dataGridViewTextBoxColumn10.MinimumWidth = 6;
			dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
			dataGridViewTextBoxColumn10.ReadOnly = true;
			dataGridViewTextBoxColumn10.Visible = false;
			dataGridViewTextBoxColumn10.Width = 125;
			// 
			// dataGridViewTextBoxColumn11
			// 
			dataGridViewTextBoxColumn11.DataPropertyName = "SuperiorInstance";
			dataGridViewTextBoxColumn11.HeaderText = "SuperiorInstance";
			dataGridViewTextBoxColumn11.MinimumWidth = 6;
			dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
			dataGridViewTextBoxColumn11.ReadOnly = true;
			dataGridViewTextBoxColumn11.Visible = false;
			dataGridViewTextBoxColumn11.Width = 125;
			// 
			// organizationBindingSource
			// 
			organizationBindingSource.DataSource = typeof(Model.Organization);
			// 
			// lbl_DetElemento
			// 
			lbl_DetElemento.AutoSize = true;
			lbl_DetElemento.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_DetElemento.Location = new Point(609, 41);
			lbl_DetElemento.Name = "lbl_DetElemento";
			lbl_DetElemento.Size = new Size(255, 32);
			lbl_DetElemento.TabIndex = 16;
			lbl_DetElemento.Text = "Detalhes do Elemento:";
			// 
			// lbl_DetElementoDesc
			// 
			lbl_DetElementoDesc.AutoSize = true;
			lbl_DetElementoDesc.Location = new Point(609, 17);
			lbl_DetElementoDesc.Name = "lbl_DetElementoDesc";
			lbl_DetElementoDesc.Size = new Size(382, 20);
			lbl_DetElementoDesc.TabIndex = 16;
			lbl_DetElementoDesc.Text = "Selecione um elemento na tabela ao lado para detalhar.";
			// 
			// lbl_RelElemento
			// 
			lbl_RelElemento.AutoSize = true;
			lbl_RelElemento.Location = new Point(619, 450);
			lbl_RelElemento.Margin = new Padding(0);
			lbl_RelElemento.Name = "lbl_RelElemento";
			lbl_RelElemento.Size = new Size(211, 20);
			lbl_RelElemento.TabIndex = 33;
			lbl_RelElemento.Text = "Relacionado a outro elemento";
			// 
			// lbl_RelAtividade
			// 
			lbl_RelAtividade.AutoSize = true;
			lbl_RelAtividade.Location = new Point(1147, 450);
			lbl_RelAtividade.Name = "lbl_RelAtividade";
			lbl_RelAtividade.Size = new Size(170, 20);
			lbl_RelAtividade.TabIndex = 39;
			lbl_RelAtividade.Text = "Relacionado a atividade";
			// 
			// lbl_RelSetor
			// 
			lbl_RelSetor.AutoSize = true;
			lbl_RelSetor.Location = new Point(1147, 181);
			lbl_RelSetor.Name = "lbl_RelSetor";
			lbl_RelSetor.Size = new Size(97, 20);
			lbl_RelSetor.TabIndex = 30;
			lbl_RelSetor.Text = "Ocupado por";
			// 
			// btn_ShowAllElements
			// 
			btn_ShowAllElements.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
			btn_ShowAllElements.Location = new Point(25, 335);
			btn_ShowAllElements.Margin = new Padding(3, 4, 3, 4);
			btn_ShowAllElements.Name = "btn_ShowAllElements";
			btn_ShowAllElements.Size = new Size(119, 31);
			btn_ShowAllElements.TabIndex = 6;
			btn_ShowAllElements.Text = "Mostrar todos";
			btn_ShowAllElements.UseVisualStyleBackColor = true;
			btn_ShowAllElements.Click += btn_ShowAllElements_Click;
			// 
			// btn_FilterElements
			// 
			btn_FilterElements.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
			btn_FilterElements.Location = new Point(147, 335);
			btn_FilterElements.Margin = new Padding(3, 4, 3, 4);
			btn_FilterElements.Name = "btn_FilterElements";
			btn_FilterElements.Size = new Size(245, 31);
			btn_FilterElements.TabIndex = 7;
			btn_FilterElements.Text = "Filtrar por subsistema selecionado";
			btn_FilterElements.UseVisualStyleBackColor = true;
			btn_FilterElements.Click += btn_FilterElements_Click;
			// 
			// btn_ManageSubsystems
			// 
			btn_ManageSubsystems.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
			btn_ManageSubsystems.Location = new Point(395, 335);
			btn_ManageSubsystems.Margin = new Padding(3, 4, 3, 4);
			btn_ManageSubsystems.Name = "btn_ManageSubsystems";
			btn_ManageSubsystems.Size = new Size(170, 31);
			btn_ManageSubsystems.TabIndex = 8;
			btn_ManageSubsystems.Text = "Gerenciar Subsistemas...";
			btn_ManageSubsystems.UseVisualStyleBackColor = true;
			btn_ManageSubsystems.Click += btn_ManageSubsystems_Click;
			// 
			// lbl_NomeElemento
			// 
			lbl_NomeElemento.AutoSize = true;
			lbl_NomeElemento.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
			lbl_NomeElemento.Location = new Point(867, 44);
			lbl_NomeElemento.MaximumSize = new Size(750, 60);
			lbl_NomeElemento.Name = "lbl_NomeElemento";
			lbl_NomeElemento.Size = new Size(101, 28);
			lbl_NomeElemento.TabIndex = 17;
			lbl_NomeElemento.Text = "Elemento";
			// 
			// btn_DesvincElemento
			// 
			btn_DesvincElemento.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_DesvincElemento.Location = new Point(974, 819);
			btn_DesvincElemento.Margin = new Padding(3, 4, 3, 4);
			btn_DesvincElemento.Name = "btn_DesvincElemento";
			btn_DesvincElemento.Size = new Size(155, 31);
			btn_DesvincElemento.TabIndex = 38;
			btn_DesvincElemento.Text = "Desvincular seleção";
			btn_DesvincElemento.UseVisualStyleBackColor = true;
			btn_DesvincElemento.Click += btn_DesvincElemento_Click;
			// 
			// btn_VincElemento
			// 
			btn_VincElemento.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_VincElemento.Location = new Point(800, 819);
			btn_VincElemento.Margin = new Padding(3, 4, 3, 4);
			btn_VincElemento.Name = "btn_VincElemento";
			btn_VincElemento.Size = new Size(168, 31);
			btn_VincElemento.TabIndex = 37;
			btn_VincElemento.Text = "Selecionar vínculos...";
			btn_VincElemento.UseVisualStyleBackColor = true;
			btn_VincElemento.Click += btn_VincElemento_Click;
			// 
			// btn_VincAtividade
			// 
			btn_VincAtividade.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_VincAtividade.Location = new Point(1343, 821);
			btn_VincAtividade.Margin = new Padding(3, 4, 3, 4);
			btn_VincAtividade.Name = "btn_VincAtividade";
			btn_VincAtividade.Size = new Size(155, 31);
			btn_VincAtividade.TabIndex = 43;
			btn_VincAtividade.Text = "Selecionar vínculos...";
			btn_VincAtividade.UseVisualStyleBackColor = true;
			btn_VincAtividade.Click += btn_VincAtividade_Click;
			// 
			// btn_DesvincAtividade
			// 
			btn_DesvincAtividade.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_DesvincAtividade.Location = new Point(1504, 821);
			btn_DesvincAtividade.Margin = new Padding(3, 4, 3, 4);
			btn_DesvincAtividade.Name = "btn_DesvincAtividade";
			btn_DesvincAtividade.Size = new Size(154, 31);
			btn_DesvincAtividade.TabIndex = 44;
			btn_DesvincAtividade.Text = "Desvincular seleção";
			btn_DesvincAtividade.UseVisualStyleBackColor = true;
			btn_DesvincAtividade.Click += btn_DesvincAtividade_Click;
			// 
			// btn_ImportElementos
			// 
			btn_ImportElementos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_ImportElementos.Location = new Point(278, 819);
			btn_ImportElementos.Name = "btn_ImportElementos";
			btn_ImportElementos.Size = new Size(117, 29);
			btn_ImportElementos.TabIndex = 14;
			btn_ImportElementos.Text = "Importar .csv";
			btn_ImportElementos.UseVisualStyleBackColor = true;
			btn_ImportElementos.Click += btn_ImportElementos_Click;
			// 
			// rtbox_ExternalId
			// 
			rtbox_ExternalId.Location = new Point(882, 109);
			rtbox_ExternalId.Margin = new Padding(3, 4, 3, 4);
			rtbox_ExternalId.Name = "rtbox_ExternalId";
			rtbox_ExternalId.Size = new Size(247, 59);
			rtbox_ExternalId.TabIndex = 21;
			rtbox_ExternalId.Text = "";
			rtbox_ExternalId.Leave += rtbox_ExternalId_Leave;
			// 
			// rtbox_Type
			// 
			rtbox_Type.Location = new Point(1411, 109);
			rtbox_Type.Margin = new Padding(3, 4, 3, 4);
			rtbox_Type.Name = "rtbox_Type";
			rtbox_Type.Size = new Size(247, 59);
			rtbox_Type.TabIndex = 25;
			rtbox_Type.Text = "";
			rtbox_Type.Leave += rtbox_Type_Leave;
			// 
			// rtbox_objectClass
			// 
			rtbox_objectClass.Location = new Point(617, 109);
			rtbox_objectClass.Margin = new Padding(3, 4, 3, 4);
			rtbox_objectClass.Name = "rtbox_objectClass";
			rtbox_objectClass.Size = new Size(247, 59);
			rtbox_objectClass.TabIndex = 19;
			rtbox_objectClass.Text = "";
			rtbox_objectClass.Leave += rtbox_objectClass_Leave;
			// 
			// rtbox_SType
			// 
			rtbox_SType.Location = new Point(1147, 109);
			rtbox_SType.Margin = new Padding(3, 4, 3, 4);
			rtbox_SType.Name = "rtbox_SType";
			rtbox_SType.Size = new Size(247, 59);
			rtbox_SType.TabIndex = 23;
			rtbox_SType.Text = "";
			rtbox_SType.Leave += rtbox_SType_Leave;
			// 
			// lbl_IdExterno
			// 
			lbl_IdExterno.AutoSize = true;
			lbl_IdExterno.Location = new Point(882, 85);
			lbl_IdExterno.Name = "lbl_IdExterno";
			lbl_IdExterno.Size = new Size(148, 20);
			lbl_IdExterno.TabIndex = 20;
			lbl_IdExterno.Text = "Identificador externo";
			// 
			// lbl_TipoElem
			// 
			lbl_TipoElem.AutoSize = true;
			lbl_TipoElem.Location = new Point(1411, 85);
			lbl_TipoElem.Name = "lbl_TipoElem";
			lbl_TipoElem.Size = new Size(128, 20);
			lbl_TipoElem.TabIndex = 24;
			lbl_TipoElem.Text = "Tipo do Elemento";
			// 
			// lbl_ClasseObj
			// 
			lbl_ClasseObj.AutoSize = true;
			lbl_ClasseObj.Location = new Point(617, 85);
			lbl_ClasseObj.Name = "lbl_ClasseObj";
			lbl_ClasseObj.Size = new Size(120, 20);
			lbl_ClasseObj.TabIndex = 18;
			lbl_ClasseObj.Text = "Classe do objeto";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(1147, 85);
			label1.Name = "label1";
			label1.Size = new Size(128, 20);
			label1.TabIndex = 22;
			label1.Text = "Tipo de superfície";
			// 
			// btn_SalvarDetalhes
			// 
			btn_SalvarDetalhes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btn_SalvarDetalhes.Location = new Point(1554, 5);
			btn_SalvarDetalhes.Margin = new Padding(3, 4, 3, 4);
			btn_SalvarDetalhes.Name = "btn_SalvarDetalhes";
			btn_SalvarDetalhes.Size = new Size(133, 35);
			btn_SalvarDetalhes.TabIndex = 45;
			btn_SalvarDetalhes.Text = "Salvar alterações";
			btn_SalvarDetalhes.UseVisualStyleBackColor = true;
			btn_SalvarDetalhes.Click += btn_SalvarDetalhes_Click;
			// 
			// lbl_Separator_Vertical
			// 
			lbl_Separator_Vertical.BorderStyle = BorderStyle.Fixed3D;
			lbl_Separator_Vertical.Location = new Point(587, 21);
			lbl_Separator_Vertical.Name = "lbl_Separator_Vertical";
			lbl_Separator_Vertical.Size = new Size(2, 840);
			lbl_Separator_Vertical.TabIndex = 36;
			// 
			// dg_RelacaoAtividade
			// 
			dg_RelacaoAtividade.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			dg_RelacaoAtividade.AutoGenerateColumns = false;
			dg_RelacaoAtividade.BackgroundColor = SystemColors.ControlLight;
			dg_RelacaoAtividade.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_RelacaoAtividade.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn3, codeDataGridViewTextBoxColumn5, nameDataGridViewTextBoxColumn4, dataGridViewTextBoxColumn4 });
			dg_RelacaoAtividade.DataSource = relationshipViewModelBindingSource1;
			dg_RelacaoAtividade.Location = new Point(1147, 474);
			dg_RelacaoAtividade.Margin = new Padding(3, 4, 3, 4);
			dg_RelacaoAtividade.Name = "dg_RelacaoAtividade";
			dg_RelacaoAtividade.ReadOnly = true;
			dg_RelacaoAtividade.RowHeadersVisible = false;
			dg_RelacaoAtividade.RowHeadersWidth = 51;
			dg_RelacaoAtividade.RowTemplate.Height = 25;
			dg_RelacaoAtividade.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_RelacaoAtividade.Size = new Size(511, 336);
			dg_RelacaoAtividade.TabIndex = 30;
			// 
			// dataGridViewTextBoxColumn3
			// 
			dataGridViewTextBoxColumn3.DataPropertyName = "RelationshipId";
			dataGridViewTextBoxColumn3.HeaderText = "RelationshipId";
			dataGridViewTextBoxColumn3.MinimumWidth = 6;
			dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			dataGridViewTextBoxColumn3.ReadOnly = true;
			dataGridViewTextBoxColumn3.Visible = false;
			dataGridViewTextBoxColumn3.Width = 125;
			// 
			// codeDataGridViewTextBoxColumn5
			// 
			codeDataGridViewTextBoxColumn5.DataPropertyName = "Code";
			codeDataGridViewTextBoxColumn5.HeaderText = "Código";
			codeDataGridViewTextBoxColumn5.MinimumWidth = 6;
			codeDataGridViewTextBoxColumn5.Name = "codeDataGridViewTextBoxColumn5";
			codeDataGridViewTextBoxColumn5.ReadOnly = true;
			codeDataGridViewTextBoxColumn5.Width = 80;
			// 
			// nameDataGridViewTextBoxColumn4
			// 
			nameDataGridViewTextBoxColumn4.DataPropertyName = "Name";
			nameDataGridViewTextBoxColumn4.HeaderText = "Nome";
			nameDataGridViewTextBoxColumn4.MinimumWidth = 6;
			nameDataGridViewTextBoxColumn4.Name = "nameDataGridViewTextBoxColumn4";
			nameDataGridViewTextBoxColumn4.ReadOnly = true;
			nameDataGridViewTextBoxColumn4.Width = 280;
			// 
			// dataGridViewTextBoxColumn4
			// 
			dataGridViewTextBoxColumn4.DataPropertyName = "Relationship";
			dataGridViewTextBoxColumn4.HeaderText = "Relação";
			dataGridViewTextBoxColumn4.MinimumWidth = 6;
			dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			dataGridViewTextBoxColumn4.ReadOnly = true;
			dataGridViewTextBoxColumn4.Width = 125;
			// 
			// relationshipViewModelBindingSource1
			// 
			relationshipViewModelBindingSource1.DataSource = typeof(ViewModel.RelationshipViewModel);
			// 
			// btn_DeleteElementoSelecao
			// 
			btn_DeleteElementoSelecao.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_DeleteElementoSelecao.Location = new Point(401, 819);
			btn_DeleteElementoSelecao.Margin = new Padding(3, 4, 3, 4);
			btn_DeleteElementoSelecao.Name = "btn_DeleteElementoSelecao";
			btn_DeleteElementoSelecao.Size = new Size(158, 31);
			btn_DeleteElementoSelecao.TabIndex = 15;
			btn_DeleteElementoSelecao.Text = "Deletar seleção";
			btn_DeleteElementoSelecao.UseVisualStyleBackColor = true;
			btn_DeleteElementoSelecao.Click += btn_DeleteElementoSelecao_Click;
			// 
			// btn_SetOrganization
			// 
			btn_SetOrganization.Location = new Point(1445, 394);
			btn_SetOrganization.Name = "btn_SetOrganization";
			btn_SetOrganization.Size = new Size(94, 32);
			btn_SetOrganization.TabIndex = 32;
			btn_SetOrganization.Text = "Editar";
			btn_SetOrganization.UseVisualStyleBackColor = true;
			btn_SetOrganization.Click += btn_SetOrganization_Click;
			// 
			// dg_Group
			// 
			dg_Group.AllowUserToDeleteRows = false;
			dg_Group.AutoGenerateColumns = false;
			dg_Group.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_Group.Columns.AddRange(new DataGridViewColumn[] { subsystemIdDataGridViewTextBoxColumn, codeDataGridViewTextBoxColumn8, nameDataGridViewTextBoxColumn6 });
			dg_Group.DataSource = subsystemBindingSource;
			dg_Group.Location = new Point(25, 64);
			dg_Group.Name = "dg_Group";
			dg_Group.RowHeadersVisible = false;
			dg_Group.RowHeadersWidth = 51;
			dg_Group.RowTemplate.Height = 29;
			dg_Group.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_Group.Size = new Size(534, 219);
			dg_Group.TabIndex = 2;
			dg_Group.CellEndEdit += dg_Group_CellEndEdit;
			dg_Group.CellFormatting += dg_Group_CellFormatting;
			dg_Group.ColumnHeaderMouseClick += dg_Group_ColumnHeaderMouseClick;
			// 
			// subsystemIdDataGridViewTextBoxColumn
			// 
			subsystemIdDataGridViewTextBoxColumn.DataPropertyName = "SubsystemId";
			subsystemIdDataGridViewTextBoxColumn.HeaderText = "Id";
			subsystemIdDataGridViewTextBoxColumn.MinimumWidth = 6;
			subsystemIdDataGridViewTextBoxColumn.Name = "subsystemIdDataGridViewTextBoxColumn";
			subsystemIdDataGridViewTextBoxColumn.ReadOnly = true;
			subsystemIdDataGridViewTextBoxColumn.Width = 55;
			// 
			// codeDataGridViewTextBoxColumn8
			// 
			codeDataGridViewTextBoxColumn8.DataPropertyName = "Code";
			codeDataGridViewTextBoxColumn8.HeaderText = "Código";
			codeDataGridViewTextBoxColumn8.MinimumWidth = 6;
			codeDataGridViewTextBoxColumn8.Name = "codeDataGridViewTextBoxColumn8";
			codeDataGridViewTextBoxColumn8.Width = 90;
			// 
			// nameDataGridViewTextBoxColumn6
			// 
			nameDataGridViewTextBoxColumn6.DataPropertyName = "Name";
			nameDataGridViewTextBoxColumn6.HeaderText = "Nome*";
			nameDataGridViewTextBoxColumn6.MinimumWidth = 6;
			nameDataGridViewTextBoxColumn6.Name = "nameDataGridViewTextBoxColumn6";
			nameDataGridViewTextBoxColumn6.Width = 360;
			// 
			// subsystemBindingSource
			// 
			subsystemBindingSource.DataSource = typeof(Model.Subsystem);
			// 
			// lbl_SectorFilter
			// 
			lbl_SectorFilter.AutoEllipsis = true;
			lbl_SectorFilter.AutoSize = true;
			lbl_SectorFilter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_SectorFilter.Location = new Point(153, 377);
			lbl_SectorFilter.MaximumSize = new Size(331, 29);
			lbl_SectorFilter.Name = "lbl_SectorFilter";
			lbl_SectorFilter.Size = new Size(76, 28);
			lbl_SectorFilter.TabIndex = 6;
			lbl_SectorFilter.Text = "TODOS";
			// 
			// btn_DelSubsystem
			// 
			btn_DelSubsystem.Location = new Point(408, 288);
			btn_DelSubsystem.Name = "btn_DelSubsystem";
			btn_DelSubsystem.Size = new Size(151, 29);
			btn_DelSubsystem.TabIndex = 5;
			btn_DelSubsystem.Text = "Deletar seleção";
			btn_DelSubsystem.UseVisualStyleBackColor = true;
			btn_DelSubsystem.Click += btn_DelSubsystem_Click;
			// 
			// btn_ImportElementRelationship
			// 
			btn_ImportElementRelationship.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_ImportElementRelationship.Location = new Point(704, 820);
			btn_ImportElementRelationship.Margin = new Padding(3, 4, 3, 4);
			btn_ImportElementRelationship.Name = "btn_ImportElementRelationship";
			btn_ImportElementRelationship.Size = new Size(90, 31);
			btn_ImportElementRelationship.TabIndex = 36;
			btn_ImportElementRelationship.Text = "Importar vínculos...";
			btn_ImportElementRelationship.UseVisualStyleBackColor = true;
			btn_ImportElementRelationship.Click += btn_ImportElementRelationship_Click;
			// 
			// btn_ImportElementActivityRelationship
			// 
			btn_ImportElementActivityRelationship.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_ImportElementActivityRelationship.Location = new Point(1251, 821);
			btn_ImportElementActivityRelationship.Margin = new Padding(3, 4, 3, 4);
			btn_ImportElementActivityRelationship.Name = "btn_ImportElementActivityRelationship";
			btn_ImportElementActivityRelationship.Size = new Size(86, 31);
			btn_ImportElementActivityRelationship.TabIndex = 42;
			btn_ImportElementActivityRelationship.Text = "Importar vínculos...";
			btn_ImportElementActivityRelationship.UseVisualStyleBackColor = true;
			btn_ImportElementActivityRelationship.Click += btn_ImportElementActivityRelationship_Click;
			// 
			// lbl_ElementsTotal
			// 
			lbl_ElementsTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			lbl_ElementsTotal.AutoSize = true;
			lbl_ElementsTotal.Location = new Point(23, 816);
			lbl_ElementsTotal.Name = "lbl_ElementsTotal";
			lbl_ElementsTotal.Size = new Size(45, 20);
			lbl_ElementsTotal.TabIndex = 12;
			lbl_ElementsTotal.Text = "Total:";
			// 
			// btn_ImportSectors
			// 
			btn_ImportSectors.Location = new Point(278, 288);
			btn_ImportSectors.Name = "btn_ImportSectors";
			btn_ImportSectors.Size = new Size(125, 29);
			btn_ImportSectors.TabIndex = 4;
			btn_ImportSectors.Text = "Importar .csv";
			btn_ImportSectors.UseVisualStyleBackColor = true;
			btn_ImportSectors.Click += btn_ImportSectors_Click;
			// 
			// btn_ExportSubsystem
			// 
			btn_ExportSubsystem.Location = new Point(153, 288);
			btn_ExportSubsystem.Name = "btn_ExportSubsystem";
			btn_ExportSubsystem.Size = new Size(119, 29);
			btn_ExportSubsystem.TabIndex = 3;
			btn_ExportSubsystem.Text = "Exportar .csv";
			btn_ExportSubsystem.UseVisualStyleBackColor = true;
			btn_ExportSubsystem.Click += btn_ExportSubsystem_Click;
			// 
			// btn_ExportElements
			// 
			btn_ExportElements.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_ExportElements.Location = new Point(153, 819);
			btn_ExportElements.Name = "btn_ExportElements";
			btn_ExportElements.Size = new Size(119, 29);
			btn_ExportElements.TabIndex = 13;
			btn_ExportElements.Text = "Exportar .csv";
			btn_ExportElements.UseVisualStyleBackColor = true;
			btn_ExportElements.Click += btn_ExportElements_Click;
			// 
			// btn_ExportElementElement
			// 
			btn_ExportElementElement.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_ExportElementElement.Location = new Point(617, 821);
			btn_ExportElementElement.Name = "btn_ExportElementElement";
			btn_ExportElementElement.Size = new Size(81, 29);
			btn_ExportElementElement.TabIndex = 35;
			btn_ExportElementElement.Text = "Exportar .csv";
			btn_ExportElementElement.UseVisualStyleBackColor = true;
			btn_ExportElementElement.Click += btn_ExportElementElement_Click;
			// 
			// btn_ExportElementActivity
			// 
			btn_ExportElementActivity.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_ExportElementActivity.Location = new Point(1151, 821);
			btn_ExportElementActivity.Name = "btn_ExportElementActivity";
			btn_ExportElementActivity.Size = new Size(94, 29);
			btn_ExportElementActivity.TabIndex = 41;
			btn_ExportElementActivity.Text = "Exportar .csv";
			btn_ExportElementActivity.UseVisualStyleBackColor = true;
			btn_ExportElementActivity.Click += btn_ExportElementActivity_Click;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(619, 181);
			label3.Margin = new Padding(0);
			label3.Name = "label3";
			label3.Size = new Size(133, 20);
			label3.TabIndex = 26;
			label3.Text = "Subsistema / Setor";
			// 
			// subsystemBindingSource1
			// 
			subsystemBindingSource1.DataSource = typeof(Model.Subsystem);
			// 
			// dataGridView1
			// 
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridView1.AutoGenerateColumns = false;
			dataGridView1.BackgroundColor = SystemColors.ControlLight;
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Columns.AddRange(new DataGridViewColumn[] { subsystemIdDataGridViewTextBoxColumn1, codeDataGridViewTextBoxColumn9, nameDataGridViewTextBoxColumn7 });
			dataGridView1.DataSource = subsystemBindingSource1;
			dataGridView1.Location = new Point(619, 205);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.ReadOnly = true;
			dataGridView1.RowHeadersVisible = false;
			dataGridView1.RowHeadersWidth = 51;
			dataGridView1.RowTemplate.Height = 29;
			dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView1.Size = new Size(501, 187);
			dataGridView1.TabIndex = 27;
			// 
			// subsystemIdDataGridViewTextBoxColumn1
			// 
			subsystemIdDataGridViewTextBoxColumn1.DataPropertyName = "SubsystemId";
			subsystemIdDataGridViewTextBoxColumn1.HeaderText = "SubsystemId";
			subsystemIdDataGridViewTextBoxColumn1.MinimumWidth = 6;
			subsystemIdDataGridViewTextBoxColumn1.Name = "subsystemIdDataGridViewTextBoxColumn1";
			subsystemIdDataGridViewTextBoxColumn1.ReadOnly = true;
			subsystemIdDataGridViewTextBoxColumn1.Visible = false;
			subsystemIdDataGridViewTextBoxColumn1.Width = 125;
			// 
			// codeDataGridViewTextBoxColumn9
			// 
			codeDataGridViewTextBoxColumn9.DataPropertyName = "Code";
			codeDataGridViewTextBoxColumn9.HeaderText = "Código";
			codeDataGridViewTextBoxColumn9.MinimumWidth = 6;
			codeDataGridViewTextBoxColumn9.Name = "codeDataGridViewTextBoxColumn9";
			codeDataGridViewTextBoxColumn9.ReadOnly = true;
			codeDataGridViewTextBoxColumn9.Width = 80;
			// 
			// nameDataGridViewTextBoxColumn7
			// 
			nameDataGridViewTextBoxColumn7.DataPropertyName = "Name";
			nameDataGridViewTextBoxColumn7.HeaderText = "Nome";
			nameDataGridViewTextBoxColumn7.MinimumWidth = 6;
			nameDataGridViewTextBoxColumn7.Name = "nameDataGridViewTextBoxColumn7";
			nameDataGridViewTextBoxColumn7.ReadOnly = true;
			nameDataGridViewTextBoxColumn7.Width = 380;
			// 
			// button1
			// 
			button1.Location = new Point(776, 395);
			button1.Margin = new Padding(3, 4, 3, 4);
			button1.Name = "button1";
			button1.Size = new Size(169, 31);
			button1.TabIndex = 28;
			button1.Text = "Selecionar vínculos...";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// btn_DeleteRelSubsystem
			// 
			btn_DeleteRelSubsystem.Location = new Point(947, 395);
			btn_DeleteRelSubsystem.Margin = new Padding(3, 4, 3, 4);
			btn_DeleteRelSubsystem.Name = "btn_DeleteRelSubsystem";
			btn_DeleteRelSubsystem.Size = new Size(173, 31);
			btn_DeleteRelSubsystem.TabIndex = 29;
			btn_DeleteRelSubsystem.Text = "Desvincular seleção";
			btn_DeleteRelSubsystem.UseVisualStyleBackColor = true;
			btn_DeleteRelSubsystem.Click += btn_DeleteRelSubsystem_Click;
			// 
			// btn_New
			// 
			btn_New.Location = new Point(495, 377);
			btn_New.Name = "btn_New";
			btn_New.Size = new Size(66, 29);
			btn_New.TabIndex = 10;
			btn_New.Text = "Novo";
			btn_New.UseVisualStyleBackColor = true;
			btn_New.Click += btn_New_Click;
			// 
			// btn_NewGroup
			// 
			btn_NewGroup.Location = new Point(495, 28);
			btn_NewGroup.Name = "btn_NewGroup";
			btn_NewGroup.Size = new Size(66, 29);
			btn_NewGroup.TabIndex = 1;
			btn_NewGroup.Text = "Novo";
			btn_NewGroup.UseVisualStyleBackColor = true;
			btn_NewGroup.Click += btn_NewGroup_Click;
			// 
			// btn_DeleteDivision
			// 
			btn_DeleteDivision.Location = new Point(1544, 395);
			btn_DeleteDivision.Margin = new Padding(3, 4, 3, 4);
			btn_DeleteDivision.Name = "btn_DeleteDivision";
			btn_DeleteDivision.Size = new Size(114, 31);
			btn_DeleteDivision.TabIndex = 46;
			btn_DeleteDivision.Text = "Desvincular";
			btn_DeleteDivision.UseVisualStyleBackColor = true;
			btn_DeleteDivision.Click += btn_DeleteDivision_Click;
			// 
			// Frm_Element
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			AutoScroll = true;
			ClientSize = new Size(1696, 881);
			Controls.Add(btn_DeleteDivision);
			Controls.Add(btn_NewGroup);
			Controls.Add(btn_New);
			Controls.Add(button1);
			Controls.Add(btn_DeleteRelSubsystem);
			Controls.Add(dataGridView1);
			Controls.Add(label3);
			Controls.Add(btn_ExportElementActivity);
			Controls.Add(btn_ExportElementElement);
			Controls.Add(btn_ExportElements);
			Controls.Add(btn_ExportSubsystem);
			Controls.Add(btn_ImportSectors);
			Controls.Add(lbl_ElementsTotal);
			Controls.Add(btn_ImportElementActivityRelationship);
			Controls.Add(btn_ImportElementRelationship);
			Controls.Add(btn_DelSubsystem);
			Controls.Add(lbl_SectorFilter);
			Controls.Add(dg_Group);
			Controls.Add(btn_SetOrganization);
			Controls.Add(btn_DeleteElementoSelecao);
			Controls.Add(dg_RelacaoAtividade);
			Controls.Add(lbl_Separator_Vertical);
			Controls.Add(btn_SalvarDetalhes);
			Controls.Add(label1);
			Controls.Add(lbl_ClasseObj);
			Controls.Add(lbl_TipoElem);
			Controls.Add(lbl_IdExterno);
			Controls.Add(rtbox_SType);
			Controls.Add(rtbox_objectClass);
			Controls.Add(rtbox_Type);
			Controls.Add(rtbox_ExternalId);
			Controls.Add(btn_ImportElementos);
			Controls.Add(btn_VincAtividade);
			Controls.Add(btn_DesvincAtividade);
			Controls.Add(btn_VincElemento);
			Controls.Add(btn_DesvincElemento);
			Controls.Add(lbl_NomeElemento);
			Controls.Add(btn_ManageSubsystems);
			Controls.Add(btn_FilterElements);
			Controls.Add(btn_ShowAllElements);
			Controls.Add(lbl_RelSetor);
			Controls.Add(lbl_RelAtividade);
			Controls.Add(lbl_RelElemento);
			Controls.Add(lbl_DetElementoDesc);
			Controls.Add(lbl_DetElemento);
			Controls.Add(dg_Organization);
			Controls.Add(dg_RelacaoElemento);
			Controls.Add(label2);
			Controls.Add(dg_Elementos);
			Controls.Add(lbl_Titulo);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "Frm_Element";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "MAEA - Ambiente";
			Load += Frm_Element_Load;
			((System.ComponentModel.ISupportInitialize)dg_Elementos).EndInit();
			((System.ComponentModel.ISupportInitialize)elementBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)dg_RelacaoElemento).EndInit();
			((System.ComponentModel.ISupportInitialize)relationshipViewModelBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)dg_Organization).EndInit();
			((System.ComponentModel.ISupportInitialize)organizationBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)dg_RelacaoAtividade).EndInit();
			((System.ComponentModel.ISupportInitialize)relationshipViewModelBindingSource1).EndInit();
			((System.ComponentModel.ISupportInitialize)dg_Group).EndInit();
			((System.ComponentModel.ISupportInitialize)subsystemBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)subsystemBindingSource1).EndInit();
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lbl_Titulo;
		private Label label2;
		private DataGridView dg_RelacaoElemento;
		private DataGridViewTextBoxColumn periodicidadeDataGridViewTextBoxColumn;
		private DataGridView dg_Organization;
		private Label lbl_DetElemento;
		private Label lbl_DetElementoDesc;
		private Label lbl_RelElemento;
		private Label lbl_RelAtividade;
		private Label lbl_RelSetor;
		private Button btn_ShowAllElements;
		private Button btn_FilterElements;
		private Button btn_ManageSubsystems;
		private Label lbl_NomeElemento;
		private Button btn_DesvincElemento;
		private Button btn_VincElemento;
		private Button btn_VincAtividade;
		private Button btn_DesvincAtividade;
		private Button btn_ImportElementos;
		private RichTextBox rtbox_ExternalId;
		private RichTextBox rtbox_Type;
		private RichTextBox rtbox_objectClass;
		private RichTextBox rtbox_SType;
		private Label lbl_IdExterno;
		private Label lbl_TipoElem;
		private Label lbl_ClasseObj;
		private Label label1;
		private Button btn_SalvarDetalhes;
		private Label lbl_Separator_Vertical;
		private DataGridView dg_RelacaoAtividade;
		private Button btn_DeleteElementoSelecao;
		private DataGridViewTextBoxColumn idRelacaoDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn relacaoDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn idRelacaoDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn relacaoDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn relationshipIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn relationshipDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn relationshipIdDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn2;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn2;
		private DataGridViewTextBoxColumn relationshipDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn sectorIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn sectorNameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn3;
		private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn agentIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn responsibleAgentDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn superiorInstanceIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn superiorInstanceDataGridViewTextBoxColumn;
		private Button btn_SetOrganization;
		private DataGridView dg_Elementos;
		private DataGridViewTextBoxColumn elementIdDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn4;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn3;
		private DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn externalIdentifierDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn componentClassDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn organizationIdDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn ocupiedByDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn surfaceTypeDataGridViewTextBoxColumn1;
		private DataGridView dg_Group;
		private BindingSource elementBindingSource;
		private BindingSource relationshipViewModelBindingSource;
		private BindingSource organizationBindingSource;
		private BindingSource relationshipViewModelBindingSource1;
		private BindingSource subsystemBindingSource;
		private Label lbl_SectorFilter;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn5;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn4;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private Button btn_DelSubsystem;
		private Button btn_ImportElementRelationship;
		private Button btn_ImportElementActivityRelationship;
		private Label lbl_ElementsTotal;
		private Button btn_ImportSectors;
		private Button btn_ExportSubsystem;
		private Button btn_ExportElements;
		private Button btn_ExportElementElement;
		private Button btn_ExportElementActivity;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn6;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
		private Label label3;
		private BindingSource subsystemBindingSource1;
		private DataGridView dataGridView1;
		private DataGridViewTextBoxColumn subsystemIdDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn9;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn7;
		private Button button1;
		private Button btn_DeleteRelSubsystem;
		private Button btn_New;
		private Button btn_NewGroup;
		private DataGridViewTextBoxColumn elementIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn7;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn5;
		private DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn externalIdentifierDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn componentClassDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn organizationIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn ocupiedByDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn surfaceTypeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn subsystemIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn8;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn6;
		private Button btn_DeleteDivision;
	}
}