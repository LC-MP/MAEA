namespace MSCMD
{
	partial class Frm_Organization
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Organization));
			lbl_Title = new Label();
			dg_Agents = new DataGridView();
			agentIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			codeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			lotacaoFuncional = new DataGridViewTextBoxColumn();
			agentBindingSource = new BindingSource(components);
			btn_DeleteAgent = new Button();
			dg_ResourceRelationship = new DataGridView();
			relationshipIdDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			codeDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			nameDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			relationshipDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			relationshipViewModelBindingSource1 = new BindingSource(components);
			humanResourceBindingSource = new BindingSource(components);
			lbl_Pessoas = new Label();
			btn_nova_pessoa = new Button();
			btn_Import = new Button();
			lbl_Titulo_Funcao = new Label();
			lbl_detalhe = new Label();
			dg_Sectors = new DataGridView();
			sectorIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			codeDataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
			sectorNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			descriptionDataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			superiorInstanceIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			superiorInstanceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			organizationBindingSource = new BindingSource(components);
			organizationBindingSource1 = new BindingSource(components);
			dg_ActivityRelationship = new DataGridView();
			relationshipIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			codeDataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			nameDataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			relationshipDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			relationshipViewModelBindingSource = new BindingSource(components);
			lbl_Titulo_Atividade = new Label();
			btn_FilterAgents = new Button();
			btn_ShowAllAgents = new Button();
			lbl_detalhe_desc = new Label();
			lbl_nomeFuncao = new Label();
			btn_Del_Resource = new Button();
			btn_Del_Activity = new Button();
			lbl_Separator_Vertical = new Label();
			btn_NewActivity = new Button();
			rtBox_Description = new RichTextBox();
			lbl_Description = new Label();
			lbl_Det1 = new Label();
			lbl_Det2 = new Label();
			dataGridView2 = new DataGridView();
			agentIdDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			codeDataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
			nameDataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
			descriptionDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			agentBindingSource1 = new BindingSource(components);
			dataGridView3 = new DataGridView();
			sectorIdDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			codeDataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
			sectorNameDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			descriptionDataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
			superiorInstanceIdDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			superiorInstanceDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			btn_DeleteSector = new Button();
			btn_ImportSectors = new Button();
			btn_SubordinationRelEdit = new Button();
			btn_OrganizationRelEdit = new Button();
			btn_SaveDescription = new Button();
			lbl_SectorFilter = new Label();
			btn_ManageSectors = new Button();
			btn_Del_OrgRelationship = new Button();
			btn_Del_Subordination = new Button();
			btn_ImportAgentActivityRelationship = new Button();
			lbl_AgentsTotal = new Label();
			btn_ExportAgentCSV = new Button();
			btn_ExportDivision = new Button();
			btn_ExportActivityAgent = new Button();
			btn_NewGroup = new Button();
			btn_New = new Button();
			btn_ExportAgentResouceRelationship = new Button();
			btn_ImportAgentResouceRelationship = new Button();
			((System.ComponentModel.ISupportInitialize)dg_Agents).BeginInit();
			((System.ComponentModel.ISupportInitialize)agentBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)dg_ResourceRelationship).BeginInit();
			((System.ComponentModel.ISupportInitialize)relationshipViewModelBindingSource1).BeginInit();
			((System.ComponentModel.ISupportInitialize)humanResourceBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)dg_Sectors).BeginInit();
			((System.ComponentModel.ISupportInitialize)organizationBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)organizationBindingSource1).BeginInit();
			((System.ComponentModel.ISupportInitialize)dg_ActivityRelationship).BeginInit();
			((System.ComponentModel.ISupportInitialize)relationshipViewModelBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
			((System.ComponentModel.ISupportInitialize)agentBindingSource1).BeginInit();
			((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
			SuspendLayout();
			// 
			// lbl_Title
			// 
			lbl_Title.AutoSize = true;
			lbl_Title.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_Title.Location = new Point(32, 39);
			lbl_Title.Name = "lbl_Title";
			lbl_Title.Size = new Size(256, 32);
			lbl_Title.TabIndex = 1;
			lbl_Title.Text = "Divisão Organizacional";
			// 
			// dg_Agents
			// 
			dg_Agents.AllowUserToDeleteRows = false;
			dg_Agents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			dg_Agents.AutoGenerateColumns = false;
			dg_Agents.BackgroundColor = SystemColors.ControlLight;
			dg_Agents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_Agents.Columns.AddRange(new DataGridViewColumn[] { agentIdDataGridViewTextBoxColumn, codeDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn, lotacaoFuncional });
			dg_Agents.DataSource = agentBindingSource;
			dg_Agents.Location = new Point(32, 433);
			dg_Agents.Name = "dg_Agents";
			dg_Agents.RowHeadersVisible = false;
			dg_Agents.RowHeadersWidth = 51;
			dg_Agents.RowTemplate.Height = 29;
			dg_Agents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_Agents.Size = new Size(533, 397);
			dg_Agents.TabIndex = 13;
			dg_Agents.CellClick += dataGridViewFuncoes_CellClick;
			dg_Agents.CellEndEdit += dg_Agents_CellEndEdit;
			dg_Agents.CellEnter += dg_Agents_CellEnter;
			dg_Agents.CellFormatting += dg_Agents_CellFormatting;
			dg_Agents.ColumnHeaderMouseClick += dg_Agents_ColumnHeaderMouseClick;
			// 
			// agentIdDataGridViewTextBoxColumn
			// 
			agentIdDataGridViewTextBoxColumn.DataPropertyName = "AgentId";
			agentIdDataGridViewTextBoxColumn.HeaderText = "Id";
			agentIdDataGridViewTextBoxColumn.MinimumWidth = 6;
			agentIdDataGridViewTextBoxColumn.Name = "agentIdDataGridViewTextBoxColumn";
			agentIdDataGridViewTextBoxColumn.ReadOnly = true;
			agentIdDataGridViewTextBoxColumn.Width = 55;
			// 
			// codeDataGridViewTextBoxColumn
			// 
			codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
			codeDataGridViewTextBoxColumn.HeaderText = "Código";
			codeDataGridViewTextBoxColumn.MinimumWidth = 6;
			codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
			codeDataGridViewTextBoxColumn.Width = 90;
			// 
			// nameDataGridViewTextBoxColumn
			// 
			nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
			nameDataGridViewTextBoxColumn.FillWeight = 300F;
			nameDataGridViewTextBoxColumn.HeaderText = "Nome*";
			nameDataGridViewTextBoxColumn.MinimumWidth = 6;
			nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			nameDataGridViewTextBoxColumn.Width = 320;
			// 
			// descriptionDataGridViewTextBoxColumn
			// 
			descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
			descriptionDataGridViewTextBoxColumn.HeaderText = "Descrição";
			descriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
			descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
			descriptionDataGridViewTextBoxColumn.Visible = false;
			descriptionDataGridViewTextBoxColumn.Width = 125;
			// 
			// lotacaoFuncional
			// 
			lotacaoFuncional.HeaderText = "Lotação Funcional (Código Organização)";
			lotacaoFuncional.MinimumWidth = 6;
			lotacaoFuncional.Name = "lotacaoFuncional";
			lotacaoFuncional.Visible = false;
			lotacaoFuncional.Width = 125;
			// 
			// agentBindingSource
			// 
			agentBindingSource.DataSource = typeof(Model.Agent);
			// 
			// btn_DeleteAgent
			// 
			btn_DeleteAgent.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_DeleteAgent.Location = new Point(430, 836);
			btn_DeleteAgent.Name = "btn_DeleteAgent";
			btn_DeleteAgent.Size = new Size(135, 29);
			btn_DeleteAgent.TabIndex = 17;
			btn_DeleteAgent.Text = "Deletar seleção";
			btn_DeleteAgent.UseVisualStyleBackColor = true;
			btn_DeleteAgent.Click += btn_DeleteAgent_Click;
			// 
			// dg_ResourceRelationship
			// 
			dg_ResourceRelationship.AllowUserToAddRows = false;
			dg_ResourceRelationship.AllowUserToDeleteRows = false;
			dg_ResourceRelationship.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			dg_ResourceRelationship.AutoGenerateColumns = false;
			dg_ResourceRelationship.BackgroundColor = SystemColors.ControlLight;
			dg_ResourceRelationship.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_ResourceRelationship.Columns.AddRange(new DataGridViewColumn[] { relationshipIdDataGridViewTextBoxColumn1, codeDataGridViewTextBoxColumn1, nameDataGridViewTextBoxColumn1, relationshipDataGridViewTextBoxColumn1 });
			dg_ResourceRelationship.DataSource = relationshipViewModelBindingSource1;
			dg_ResourceRelationship.Location = new Point(638, 475);
			dg_ResourceRelationship.Name = "dg_ResourceRelationship";
			dg_ResourceRelationship.ReadOnly = true;
			dg_ResourceRelationship.RowHeadersVisible = false;
			dg_ResourceRelationship.RowHeadersWidth = 51;
			dg_ResourceRelationship.RowTemplate.Height = 29;
			dg_ResourceRelationship.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_ResourceRelationship.Size = new Size(502, 349);
			dg_ResourceRelationship.TabIndex = 32;
			// 
			// relationshipIdDataGridViewTextBoxColumn1
			// 
			relationshipIdDataGridViewTextBoxColumn1.DataPropertyName = "RelationshipId";
			relationshipIdDataGridViewTextBoxColumn1.HeaderText = "RelationshipId";
			relationshipIdDataGridViewTextBoxColumn1.MinimumWidth = 6;
			relationshipIdDataGridViewTextBoxColumn1.Name = "relationshipIdDataGridViewTextBoxColumn1";
			relationshipIdDataGridViewTextBoxColumn1.ReadOnly = true;
			relationshipIdDataGridViewTextBoxColumn1.Visible = false;
			relationshipIdDataGridViewTextBoxColumn1.Width = 125;
			// 
			// codeDataGridViewTextBoxColumn1
			// 
			codeDataGridViewTextBoxColumn1.DataPropertyName = "Code";
			codeDataGridViewTextBoxColumn1.HeaderText = "Código";
			codeDataGridViewTextBoxColumn1.MinimumWidth = 6;
			codeDataGridViewTextBoxColumn1.Name = "codeDataGridViewTextBoxColumn1";
			codeDataGridViewTextBoxColumn1.ReadOnly = true;
			codeDataGridViewTextBoxColumn1.Width = 80;
			// 
			// nameDataGridViewTextBoxColumn1
			// 
			nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
			nameDataGridViewTextBoxColumn1.HeaderText = "Nome";
			nameDataGridViewTextBoxColumn1.MinimumWidth = 6;
			nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
			nameDataGridViewTextBoxColumn1.ReadOnly = true;
			nameDataGridViewTextBoxColumn1.Width = 360;
			// 
			// relationshipDataGridViewTextBoxColumn1
			// 
			relationshipDataGridViewTextBoxColumn1.DataPropertyName = "Relationship";
			relationshipDataGridViewTextBoxColumn1.HeaderText = "Relationship";
			relationshipDataGridViewTextBoxColumn1.MinimumWidth = 6;
			relationshipDataGridViewTextBoxColumn1.Name = "relationshipDataGridViewTextBoxColumn1";
			relationshipDataGridViewTextBoxColumn1.ReadOnly = true;
			relationshipDataGridViewTextBoxColumn1.Visible = false;
			relationshipDataGridViewTextBoxColumn1.Width = 125;
			// 
			// relationshipViewModelBindingSource1
			// 
			relationshipViewModelBindingSource1.DataSource = typeof(ViewModel.RelationshipViewModel);
			// 
			// humanResourceBindingSource
			// 
			humanResourceBindingSource.DataSource = typeof(Model.HumanResource);
			// 
			// lbl_Pessoas
			// 
			lbl_Pessoas.AutoSize = true;
			lbl_Pessoas.Location = new Point(638, 451);
			lbl_Pessoas.Name = "lbl_Pessoas";
			lbl_Pessoas.Size = new Size(140, 20);
			lbl_Pessoas.TabIndex = 31;
			lbl_Pessoas.Text = "Pessoa encarregada";
			// 
			// btn_nova_pessoa
			// 
			btn_nova_pessoa.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_nova_pessoa.Location = new Point(830, 831);
			btn_nova_pessoa.Name = "btn_nova_pessoa";
			btn_nova_pessoa.Size = new Size(155, 29);
			btn_nova_pessoa.TabIndex = 35;
			btn_nova_pessoa.Text = "Selecionar vínculos...";
			btn_nova_pessoa.UseVisualStyleBackColor = true;
			btn_nova_pessoa.Click += btn_NewResource_Click;
			// 
			// btn_Import
			// 
			btn_Import.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_Import.Location = new Point(311, 835);
			btn_Import.Name = "btn_Import";
			btn_Import.Size = new Size(113, 29);
			btn_Import.TabIndex = 16;
			btn_Import.Text = "Importar .csv";
			btn_Import.UseVisualStyleBackColor = true;
			btn_Import.Click += btn_Import_Click;
			// 
			// lbl_Titulo_Funcao
			// 
			lbl_Titulo_Funcao.AutoSize = true;
			lbl_Titulo_Funcao.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_Titulo_Funcao.Location = new Point(32, 395);
			lbl_Titulo_Funcao.Name = "lbl_Titulo_Funcao";
			lbl_Titulo_Funcao.Size = new Size(107, 32);
			lbl_Titulo_Funcao.TabIndex = 10;
			lbl_Titulo_Funcao.Text = "Funções:";
			lbl_Titulo_Funcao.Click += lbl_Titulo_Funcao_Click;
			// 
			// lbl_detalhe
			// 
			lbl_detalhe.AutoSize = true;
			lbl_detalhe.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_detalhe.Location = new Point(638, 47);
			lbl_detalhe.Name = "lbl_detalhe";
			lbl_detalhe.Size = new Size(229, 32);
			lbl_detalhe.TabIndex = 19;
			lbl_detalhe.Text = "Detalhes da Função:";
			// 
			// dg_Sectors
			// 
			dg_Sectors.AllowUserToDeleteRows = false;
			dg_Sectors.AutoGenerateColumns = false;
			dg_Sectors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_Sectors.Columns.AddRange(new DataGridViewColumn[] { sectorIdDataGridViewTextBoxColumn, codeDataGridViewTextBoxColumn4, sectorNameDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn2, superiorInstanceIdDataGridViewTextBoxColumn, superiorInstanceDataGridViewTextBoxColumn });
			dg_Sectors.DataSource = organizationBindingSource;
			dg_Sectors.Location = new Point(32, 80);
			dg_Sectors.Margin = new Padding(3, 4, 3, 4);
			dg_Sectors.Name = "dg_Sectors";
			dg_Sectors.RowHeadersVisible = false;
			dg_Sectors.RowHeadersWidth = 51;
			dg_Sectors.RowTemplate.Height = 25;
			dg_Sectors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_Sectors.Size = new Size(533, 201);
			dg_Sectors.TabIndex = 3;
			dg_Sectors.CellEndEdit += dg_Sectors_CellEndEdit;
			dg_Sectors.CellFormatting += dg_Sectors_CellFormatting;
			dg_Sectors.ColumnHeaderMouseClick += dg_Sectors_ColumnHeaderMouseClick;
			// 
			// sectorIdDataGridViewTextBoxColumn
			// 
			sectorIdDataGridViewTextBoxColumn.DataPropertyName = "SectorId";
			sectorIdDataGridViewTextBoxColumn.HeaderText = "Id";
			sectorIdDataGridViewTextBoxColumn.MinimumWidth = 6;
			sectorIdDataGridViewTextBoxColumn.Name = "sectorIdDataGridViewTextBoxColumn";
			sectorIdDataGridViewTextBoxColumn.ReadOnly = true;
			sectorIdDataGridViewTextBoxColumn.Width = 55;
			// 
			// codeDataGridViewTextBoxColumn4
			// 
			codeDataGridViewTextBoxColumn4.DataPropertyName = "Code";
			codeDataGridViewTextBoxColumn4.HeaderText = "Código";
			codeDataGridViewTextBoxColumn4.MinimumWidth = 6;
			codeDataGridViewTextBoxColumn4.Name = "codeDataGridViewTextBoxColumn4";
			codeDataGridViewTextBoxColumn4.Width = 90;
			// 
			// sectorNameDataGridViewTextBoxColumn
			// 
			sectorNameDataGridViewTextBoxColumn.DataPropertyName = "SectorName";
			sectorNameDataGridViewTextBoxColumn.HeaderText = "Nome*";
			sectorNameDataGridViewTextBoxColumn.MinimumWidth = 6;
			sectorNameDataGridViewTextBoxColumn.Name = "sectorNameDataGridViewTextBoxColumn";
			sectorNameDataGridViewTextBoxColumn.Width = 360;
			// 
			// descriptionDataGridViewTextBoxColumn2
			// 
			descriptionDataGridViewTextBoxColumn2.DataPropertyName = "Description";
			descriptionDataGridViewTextBoxColumn2.HeaderText = "Description";
			descriptionDataGridViewTextBoxColumn2.MinimumWidth = 6;
			descriptionDataGridViewTextBoxColumn2.Name = "descriptionDataGridViewTextBoxColumn2";
			descriptionDataGridViewTextBoxColumn2.Visible = false;
			descriptionDataGridViewTextBoxColumn2.Width = 125;
			// 
			// superiorInstanceIdDataGridViewTextBoxColumn
			// 
			superiorInstanceIdDataGridViewTextBoxColumn.DataPropertyName = "SuperiorInstanceId";
			superiorInstanceIdDataGridViewTextBoxColumn.HeaderText = "SuperiorInstanceId";
			superiorInstanceIdDataGridViewTextBoxColumn.MinimumWidth = 6;
			superiorInstanceIdDataGridViewTextBoxColumn.Name = "superiorInstanceIdDataGridViewTextBoxColumn";
			superiorInstanceIdDataGridViewTextBoxColumn.Visible = false;
			superiorInstanceIdDataGridViewTextBoxColumn.Width = 125;
			// 
			// superiorInstanceDataGridViewTextBoxColumn
			// 
			superiorInstanceDataGridViewTextBoxColumn.DataPropertyName = "SuperiorInstance";
			superiorInstanceDataGridViewTextBoxColumn.HeaderText = "SuperiorInstance";
			superiorInstanceDataGridViewTextBoxColumn.MinimumWidth = 6;
			superiorInstanceDataGridViewTextBoxColumn.Name = "superiorInstanceDataGridViewTextBoxColumn";
			superiorInstanceDataGridViewTextBoxColumn.Visible = false;
			superiorInstanceDataGridViewTextBoxColumn.Width = 125;
			// 
			// organizationBindingSource
			// 
			organizationBindingSource.DataSource = typeof(Model.Organization);
			// 
			// organizationBindingSource1
			// 
			organizationBindingSource1.DataSource = typeof(Model.Organization);
			// 
			// dg_ActivityRelationship
			// 
			dg_ActivityRelationship.AllowUserToAddRows = false;
			dg_ActivityRelationship.AllowUserToDeleteRows = false;
			dg_ActivityRelationship.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			dg_ActivityRelationship.AutoGenerateColumns = false;
			dg_ActivityRelationship.BackgroundColor = SystemColors.ControlLight;
			dg_ActivityRelationship.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_ActivityRelationship.Columns.AddRange(new DataGridViewColumn[] { relationshipIdDataGridViewTextBoxColumn, codeDataGridViewTextBoxColumn2, nameDataGridViewTextBoxColumn2, relationshipDataGridViewTextBoxColumn });
			dg_ActivityRelationship.DataSource = relationshipViewModelBindingSource;
			dg_ActivityRelationship.Location = new Point(1166, 475);
			dg_ActivityRelationship.Name = "dg_ActivityRelationship";
			dg_ActivityRelationship.ReadOnly = true;
			dg_ActivityRelationship.RowHeadersVisible = false;
			dg_ActivityRelationship.RowHeadersWidth = 51;
			dg_ActivityRelationship.RowTemplate.Height = 29;
			dg_ActivityRelationship.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_ActivityRelationship.Size = new Size(500, 349);
			dg_ActivityRelationship.TabIndex = 38;
			// 
			// relationshipIdDataGridViewTextBoxColumn
			// 
			relationshipIdDataGridViewTextBoxColumn.DataPropertyName = "RelationshipId";
			relationshipIdDataGridViewTextBoxColumn.HeaderText = "RelationshipId";
			relationshipIdDataGridViewTextBoxColumn.MinimumWidth = 6;
			relationshipIdDataGridViewTextBoxColumn.Name = "relationshipIdDataGridViewTextBoxColumn";
			relationshipIdDataGridViewTextBoxColumn.ReadOnly = true;
			relationshipIdDataGridViewTextBoxColumn.Visible = false;
			relationshipIdDataGridViewTextBoxColumn.Width = 125;
			// 
			// codeDataGridViewTextBoxColumn2
			// 
			codeDataGridViewTextBoxColumn2.DataPropertyName = "Code";
			codeDataGridViewTextBoxColumn2.HeaderText = "Código";
			codeDataGridViewTextBoxColumn2.MinimumWidth = 6;
			codeDataGridViewTextBoxColumn2.Name = "codeDataGridViewTextBoxColumn2";
			codeDataGridViewTextBoxColumn2.ReadOnly = true;
			codeDataGridViewTextBoxColumn2.Width = 80;
			// 
			// nameDataGridViewTextBoxColumn2
			// 
			nameDataGridViewTextBoxColumn2.DataPropertyName = "Name";
			nameDataGridViewTextBoxColumn2.HeaderText = "Nome";
			nameDataGridViewTextBoxColumn2.MinimumWidth = 6;
			nameDataGridViewTextBoxColumn2.Name = "nameDataGridViewTextBoxColumn2";
			nameDataGridViewTextBoxColumn2.ReadOnly = true;
			nameDataGridViewTextBoxColumn2.Width = 360;
			// 
			// relationshipDataGridViewTextBoxColumn
			// 
			relationshipDataGridViewTextBoxColumn.DataPropertyName = "Relationship";
			relationshipDataGridViewTextBoxColumn.HeaderText = "Relação";
			relationshipDataGridViewTextBoxColumn.MinimumWidth = 6;
			relationshipDataGridViewTextBoxColumn.Name = "relationshipDataGridViewTextBoxColumn";
			relationshipDataGridViewTextBoxColumn.ReadOnly = true;
			relationshipDataGridViewTextBoxColumn.Visible = false;
			relationshipDataGridViewTextBoxColumn.Width = 140;
			// 
			// relationshipViewModelBindingSource
			// 
			relationshipViewModelBindingSource.DataSource = typeof(ViewModel.RelationshipViewModel);
			// 
			// lbl_Titulo_Atividade
			// 
			lbl_Titulo_Atividade.AutoSize = true;
			lbl_Titulo_Atividade.Location = new Point(1166, 451);
			lbl_Titulo_Atividade.Name = "lbl_Titulo_Atividade";
			lbl_Titulo_Atividade.Size = new Size(138, 20);
			lbl_Titulo_Atividade.TabIndex = 37;
			lbl_Titulo_Atividade.Text = "Atividade encubida";
			// 
			// btn_FilterAgents
			// 
			btn_FilterAgents.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
			btn_FilterAgents.Location = new Point(152, 359);
			btn_FilterAgents.Margin = new Padding(3, 4, 3, 4);
			btn_FilterAgents.Name = "btn_FilterAgents";
			btn_FilterAgents.Size = new Size(230, 31);
			btn_FilterAgents.TabIndex = 8;
			btn_FilterAgents.Text = "Filtrar por divisão selecionada";
			btn_FilterAgents.UseVisualStyleBackColor = true;
			btn_FilterAgents.Click += btn_FilterAgents_Click;
			// 
			// btn_ShowAllAgents
			// 
			btn_ShowAllAgents.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
			btn_ShowAllAgents.Location = new Point(33, 359);
			btn_ShowAllAgents.Margin = new Padding(3, 4, 3, 4);
			btn_ShowAllAgents.Name = "btn_ShowAllAgents";
			btn_ShowAllAgents.Size = new Size(113, 31);
			btn_ShowAllAgents.TabIndex = 7;
			btn_ShowAllAgents.Text = "Mostrar todas funções";
			btn_ShowAllAgents.UseVisualStyleBackColor = true;
			btn_ShowAllAgents.Click += btn_ShowAllAgents_Click;
			// 
			// lbl_detalhe_desc
			// 
			lbl_detalhe_desc.AutoSize = true;
			lbl_detalhe_desc.Location = new Point(638, 23);
			lbl_detalhe_desc.Name = "lbl_detalhe_desc";
			lbl_detalhe_desc.Size = new Size(372, 20);
			lbl_detalhe_desc.TabIndex = 18;
			lbl_detalhe_desc.Text = "Selecione uma função na tabela ao lado para detalhar.";
			// 
			// lbl_nomeFuncao
			// 
			lbl_nomeFuncao.AutoSize = true;
			lbl_nomeFuncao.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
			lbl_nomeFuncao.Location = new Point(864, 49);
			lbl_nomeFuncao.MaximumSize = new Size(750, 60);
			lbl_nomeFuncao.Name = "lbl_nomeFuncao";
			lbl_nomeFuncao.Size = new Size(79, 28);
			lbl_nomeFuncao.TabIndex = 19;
			lbl_nomeFuncao.Text = "Função";
			// 
			// btn_Del_Resource
			// 
			btn_Del_Resource.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_Del_Resource.Location = new Point(989, 831);
			btn_Del_Resource.Name = "btn_Del_Resource";
			btn_Del_Resource.Size = new Size(151, 29);
			btn_Del_Resource.TabIndex = 36;
			btn_Del_Resource.Text = "Deletar seleção";
			btn_Del_Resource.UseVisualStyleBackColor = true;
			btn_Del_Resource.Click += btn_Del_Resource_Click;
			// 
			// btn_Del_Activity
			// 
			btn_Del_Activity.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_Del_Activity.Location = new Point(1531, 830);
			btn_Del_Activity.Name = "btn_Del_Activity";
			btn_Del_Activity.Size = new Size(135, 29);
			btn_Del_Activity.TabIndex = 42;
			btn_Del_Activity.Text = "Deletar seleção";
			btn_Del_Activity.UseVisualStyleBackColor = true;
			btn_Del_Activity.Click += btn_Del_Activity_Click;
			// 
			// lbl_Separator_Vertical
			// 
			lbl_Separator_Vertical.BorderStyle = BorderStyle.Fixed3D;
			lbl_Separator_Vertical.Location = new Point(594, 21);
			lbl_Separator_Vertical.Name = "lbl_Separator_Vertical";
			lbl_Separator_Vertical.Size = new Size(2, 840);
			lbl_Separator_Vertical.TabIndex = 37;
			// 
			// btn_NewActivity
			// 
			btn_NewActivity.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_NewActivity.Location = new Point(1365, 830);
			btn_NewActivity.Name = "btn_NewActivity";
			btn_NewActivity.Size = new Size(160, 29);
			btn_NewActivity.TabIndex = 41;
			btn_NewActivity.Text = "Selecionar vínculos...";
			btn_NewActivity.UseVisualStyleBackColor = true;
			btn_NewActivity.Click += btn_NewActivity_Click;
			// 
			// rtBox_Description
			// 
			rtBox_Description.Location = new Point(638, 115);
			rtBox_Description.Name = "rtBox_Description";
			rtBox_Description.Size = new Size(766, 49);
			rtBox_Description.TabIndex = 22;
			rtBox_Description.Text = "";
			rtBox_Description.Leave += rtBox_Description_Leave;
			// 
			// lbl_Description
			// 
			lbl_Description.AutoSize = true;
			lbl_Description.Location = new Point(638, 92);
			lbl_Description.Name = "lbl_Description";
			lbl_Description.Size = new Size(147, 20);
			lbl_Description.TabIndex = 21;
			lbl_Description.Text = "Descrição da função:";
			// 
			// lbl_Det1
			// 
			lbl_Det1.AutoSize = true;
			lbl_Det1.Location = new Point(1166, 180);
			lbl_Det1.Name = "lbl_Det1";
			lbl_Det1.Size = new Size(169, 20);
			lbl_Det1.TabIndex = 27;
			lbl_Det1.Text = "Subordinação funcional:";
			// 
			// lbl_Det2
			// 
			lbl_Det2.AutoSize = true;
			lbl_Det2.Location = new Point(638, 180);
			lbl_Det2.Name = "lbl_Det2";
			lbl_Det2.Size = new Size(167, 20);
			lbl_Det2.TabIndex = 23;
			lbl_Det2.Text = "Lotação organizacional:";
			lbl_Det2.Click += lbl_Det2_Click;
			// 
			// dataGridView2
			// 
			dataGridView2.AllowUserToAddRows = false;
			dataGridView2.AllowUserToDeleteRows = false;
			dataGridView2.AutoGenerateColumns = false;
			dataGridView2.BackgroundColor = SystemColors.ControlLight;
			dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView2.Columns.AddRange(new DataGridViewColumn[] { agentIdDataGridViewTextBoxColumn1, codeDataGridViewTextBoxColumn3, nameDataGridViewTextBoxColumn4, descriptionDataGridViewTextBoxColumn1 });
			dataGridView2.DataSource = agentBindingSource1;
			dataGridView2.Location = new Point(1166, 203);
			dataGridView2.Name = "dataGridView2";
			dataGridView2.ReadOnly = true;
			dataGridView2.RowHeadersVisible = false;
			dataGridView2.RowHeadersWidth = 51;
			dataGridView2.RowTemplate.Height = 29;
			dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView2.Size = new Size(500, 204);
			dataGridView2.TabIndex = 28;
			// 
			// agentIdDataGridViewTextBoxColumn1
			// 
			agentIdDataGridViewTextBoxColumn1.DataPropertyName = "AgentId";
			agentIdDataGridViewTextBoxColumn1.HeaderText = "AgentId";
			agentIdDataGridViewTextBoxColumn1.MinimumWidth = 6;
			agentIdDataGridViewTextBoxColumn1.Name = "agentIdDataGridViewTextBoxColumn1";
			agentIdDataGridViewTextBoxColumn1.ReadOnly = true;
			agentIdDataGridViewTextBoxColumn1.Visible = false;
			agentIdDataGridViewTextBoxColumn1.Width = 125;
			// 
			// codeDataGridViewTextBoxColumn3
			// 
			codeDataGridViewTextBoxColumn3.DataPropertyName = "Code";
			codeDataGridViewTextBoxColumn3.HeaderText = "Código";
			codeDataGridViewTextBoxColumn3.MinimumWidth = 6;
			codeDataGridViewTextBoxColumn3.Name = "codeDataGridViewTextBoxColumn3";
			codeDataGridViewTextBoxColumn3.ReadOnly = true;
			codeDataGridViewTextBoxColumn3.Width = 80;
			// 
			// nameDataGridViewTextBoxColumn4
			// 
			nameDataGridViewTextBoxColumn4.DataPropertyName = "Name";
			nameDataGridViewTextBoxColumn4.HeaderText = "Name";
			nameDataGridViewTextBoxColumn4.MinimumWidth = 6;
			nameDataGridViewTextBoxColumn4.Name = "nameDataGridViewTextBoxColumn4";
			nameDataGridViewTextBoxColumn4.ReadOnly = true;
			nameDataGridViewTextBoxColumn4.Width = 360;
			// 
			// descriptionDataGridViewTextBoxColumn1
			// 
			descriptionDataGridViewTextBoxColumn1.DataPropertyName = "Description";
			descriptionDataGridViewTextBoxColumn1.HeaderText = "Description";
			descriptionDataGridViewTextBoxColumn1.MinimumWidth = 6;
			descriptionDataGridViewTextBoxColumn1.Name = "descriptionDataGridViewTextBoxColumn1";
			descriptionDataGridViewTextBoxColumn1.ReadOnly = true;
			descriptionDataGridViewTextBoxColumn1.Visible = false;
			descriptionDataGridViewTextBoxColumn1.Width = 125;
			// 
			// agentBindingSource1
			// 
			agentBindingSource1.DataSource = typeof(Model.Agent);
			// 
			// dataGridView3
			// 
			dataGridView3.AllowUserToAddRows = false;
			dataGridView3.AllowUserToDeleteRows = false;
			dataGridView3.AutoGenerateColumns = false;
			dataGridView3.BackgroundColor = SystemColors.ControlLight;
			dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView3.Columns.AddRange(new DataGridViewColumn[] { sectorIdDataGridViewTextBoxColumn1, codeDataGridViewTextBoxColumn5, sectorNameDataGridViewTextBoxColumn1, descriptionDataGridViewTextBoxColumn3, superiorInstanceIdDataGridViewTextBoxColumn1, superiorInstanceDataGridViewTextBoxColumn1 });
			dataGridView3.DataSource = organizationBindingSource1;
			dataGridView3.Location = new Point(638, 203);
			dataGridView3.Name = "dataGridView3";
			dataGridView3.ReadOnly = true;
			dataGridView3.RowHeadersVisible = false;
			dataGridView3.RowHeadersWidth = 51;
			dataGridView3.RowTemplate.Height = 29;
			dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView3.Size = new Size(502, 204);
			dataGridView3.TabIndex = 24;
			// 
			// sectorIdDataGridViewTextBoxColumn1
			// 
			sectorIdDataGridViewTextBoxColumn1.DataPropertyName = "SectorId";
			sectorIdDataGridViewTextBoxColumn1.HeaderText = "SectorId";
			sectorIdDataGridViewTextBoxColumn1.MinimumWidth = 6;
			sectorIdDataGridViewTextBoxColumn1.Name = "sectorIdDataGridViewTextBoxColumn1";
			sectorIdDataGridViewTextBoxColumn1.ReadOnly = true;
			sectorIdDataGridViewTextBoxColumn1.Visible = false;
			sectorIdDataGridViewTextBoxColumn1.Width = 125;
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
			// sectorNameDataGridViewTextBoxColumn1
			// 
			sectorNameDataGridViewTextBoxColumn1.DataPropertyName = "SectorName";
			sectorNameDataGridViewTextBoxColumn1.HeaderText = "Nome do Setor";
			sectorNameDataGridViewTextBoxColumn1.MinimumWidth = 6;
			sectorNameDataGridViewTextBoxColumn1.Name = "sectorNameDataGridViewTextBoxColumn1";
			sectorNameDataGridViewTextBoxColumn1.ReadOnly = true;
			sectorNameDataGridViewTextBoxColumn1.Width = 360;
			// 
			// descriptionDataGridViewTextBoxColumn3
			// 
			descriptionDataGridViewTextBoxColumn3.DataPropertyName = "Description";
			descriptionDataGridViewTextBoxColumn3.HeaderText = "Description";
			descriptionDataGridViewTextBoxColumn3.MinimumWidth = 6;
			descriptionDataGridViewTextBoxColumn3.Name = "descriptionDataGridViewTextBoxColumn3";
			descriptionDataGridViewTextBoxColumn3.ReadOnly = true;
			descriptionDataGridViewTextBoxColumn3.Visible = false;
			descriptionDataGridViewTextBoxColumn3.Width = 125;
			// 
			// superiorInstanceIdDataGridViewTextBoxColumn1
			// 
			superiorInstanceIdDataGridViewTextBoxColumn1.DataPropertyName = "SuperiorInstanceId";
			superiorInstanceIdDataGridViewTextBoxColumn1.HeaderText = "SuperiorInstanceId";
			superiorInstanceIdDataGridViewTextBoxColumn1.MinimumWidth = 6;
			superiorInstanceIdDataGridViewTextBoxColumn1.Name = "superiorInstanceIdDataGridViewTextBoxColumn1";
			superiorInstanceIdDataGridViewTextBoxColumn1.ReadOnly = true;
			superiorInstanceIdDataGridViewTextBoxColumn1.Visible = false;
			superiorInstanceIdDataGridViewTextBoxColumn1.Width = 125;
			// 
			// superiorInstanceDataGridViewTextBoxColumn1
			// 
			superiorInstanceDataGridViewTextBoxColumn1.DataPropertyName = "SuperiorInstance";
			superiorInstanceDataGridViewTextBoxColumn1.HeaderText = "SuperiorInstance";
			superiorInstanceDataGridViewTextBoxColumn1.MinimumWidth = 6;
			superiorInstanceDataGridViewTextBoxColumn1.Name = "superiorInstanceDataGridViewTextBoxColumn1";
			superiorInstanceDataGridViewTextBoxColumn1.ReadOnly = true;
			superiorInstanceDataGridViewTextBoxColumn1.Visible = false;
			superiorInstanceDataGridViewTextBoxColumn1.Width = 125;
			// 
			// btn_DeleteSector
			// 
			btn_DeleteSector.Location = new Point(430, 291);
			btn_DeleteSector.Margin = new Padding(3, 4, 3, 4);
			btn_DeleteSector.Name = "btn_DeleteSector";
			btn_DeleteSector.Size = new Size(135, 31);
			btn_DeleteSector.TabIndex = 6;
			btn_DeleteSector.Text = "Deletar seleção";
			btn_DeleteSector.UseVisualStyleBackColor = true;
			btn_DeleteSector.Click += btn_DeleteSector_Click;
			// 
			// btn_ImportSectors
			// 
			btn_ImportSectors.Location = new Point(266, 293);
			btn_ImportSectors.Name = "btn_ImportSectors";
			btn_ImportSectors.Size = new Size(158, 29);
			btn_ImportSectors.TabIndex = 5;
			btn_ImportSectors.Text = "Importar .csv";
			btn_ImportSectors.UseVisualStyleBackColor = true;
			btn_ImportSectors.Click += btn_ImportSectors_Click;
			// 
			// btn_SubordinationRelEdit
			// 
			btn_SubordinationRelEdit.Location = new Point(1365, 413);
			btn_SubordinationRelEdit.Name = "btn_SubordinationRelEdit";
			btn_SubordinationRelEdit.Size = new Size(155, 29);
			btn_SubordinationRelEdit.TabIndex = 29;
			btn_SubordinationRelEdit.Text = "Selecionar vínculos...";
			btn_SubordinationRelEdit.UseVisualStyleBackColor = true;
			btn_SubordinationRelEdit.Click += btn_SubordinationRelEdit_Click;
			// 
			// btn_OrganizationRelEdit
			// 
			btn_OrganizationRelEdit.Location = new Point(824, 413);
			btn_OrganizationRelEdit.Name = "btn_OrganizationRelEdit";
			btn_OrganizationRelEdit.Size = new Size(170, 29);
			btn_OrganizationRelEdit.TabIndex = 25;
			btn_OrganizationRelEdit.Text = "Selecionar vínculos...";
			btn_OrganizationRelEdit.UseVisualStyleBackColor = true;
			btn_OrganizationRelEdit.Click += btn_OrganizationRelEdit_Click;
			// 
			// btn_SaveDescription
			// 
			btn_SaveDescription.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btn_SaveDescription.Location = new Point(1551, 12);
			btn_SaveDescription.Name = "btn_SaveDescription";
			btn_SaveDescription.Size = new Size(133, 31);
			btn_SaveDescription.TabIndex = 43;
			btn_SaveDescription.Text = "Salvar alterações";
			btn_SaveDescription.UseVisualStyleBackColor = true;
			btn_SaveDescription.Click += btn_SaveDescription_Click;
			// 
			// lbl_SectorFilter
			// 
			lbl_SectorFilter.AutoEllipsis = true;
			lbl_SectorFilter.AutoSize = true;
			lbl_SectorFilter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_SectorFilter.Location = new Point(135, 397);
			lbl_SectorFilter.MaximumSize = new Size(354, 29);
			lbl_SectorFilter.Name = "lbl_SectorFilter";
			lbl_SectorFilter.Size = new Size(62, 28);
			lbl_SectorFilter.TabIndex = 11;
			lbl_SectorFilter.Text = "Todas";
			// 
			// btn_ManageSectors
			// 
			btn_ManageSectors.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
			btn_ManageSectors.Location = new Point(389, 359);
			btn_ManageSectors.Margin = new Padding(3, 4, 3, 4);
			btn_ManageSectors.Name = "btn_ManageSectors";
			btn_ManageSectors.Size = new Size(177, 31);
			btn_ManageSectors.TabIndex = 9;
			btn_ManageSectors.Text = "Gerenciar Divisões...";
			btn_ManageSectors.UseVisualStyleBackColor = true;
			btn_ManageSectors.Click += btn_ManageSectors_Click;
			// 
			// btn_Del_OrgRelationship
			// 
			btn_Del_OrgRelationship.Location = new Point(1001, 413);
			btn_Del_OrgRelationship.Name = "btn_Del_OrgRelationship";
			btn_Del_OrgRelationship.Size = new Size(139, 29);
			btn_Del_OrgRelationship.TabIndex = 26;
			btn_Del_OrgRelationship.Text = "Deletar seleção";
			btn_Del_OrgRelationship.UseVisualStyleBackColor = true;
			btn_Del_OrgRelationship.Click += btn_Del_OrgRelationship_Click;
			// 
			// btn_Del_Subordination
			// 
			btn_Del_Subordination.Location = new Point(1527, 413);
			btn_Del_Subordination.Name = "btn_Del_Subordination";
			btn_Del_Subordination.Size = new Size(139, 29);
			btn_Del_Subordination.TabIndex = 30;
			btn_Del_Subordination.Text = "Deletar seleção";
			btn_Del_Subordination.UseVisualStyleBackColor = true;
			btn_Del_Subordination.Click += btn_Del_Subordination_Click;
			// 
			// btn_ImportAgentActivityRelationship
			// 
			btn_ImportAgentActivityRelationship.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_ImportAgentActivityRelationship.Location = new Point(1273, 830);
			btn_ImportAgentActivityRelationship.Name = "btn_ImportAgentActivityRelationship";
			btn_ImportAgentActivityRelationship.Size = new Size(87, 29);
			btn_ImportAgentActivityRelationship.TabIndex = 40;
			btn_ImportAgentActivityRelationship.Text = "Importar";
			btn_ImportAgentActivityRelationship.UseVisualStyleBackColor = true;
			btn_ImportAgentActivityRelationship.Click += btn_ImportAgentActivityRelationship_Click;
			// 
			// lbl_AgentsTotal
			// 
			lbl_AgentsTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			lbl_AgentsTotal.AutoSize = true;
			lbl_AgentsTotal.Location = new Point(30, 835);
			lbl_AgentsTotal.Name = "lbl_AgentsTotal";
			lbl_AgentsTotal.Size = new Size(45, 20);
			lbl_AgentsTotal.TabIndex = 14;
			lbl_AgentsTotal.Text = "Total:";
			// 
			// btn_ExportAgentCSV
			// 
			btn_ExportAgentCSV.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_ExportAgentCSV.Location = new Point(186, 835);
			btn_ExportAgentCSV.Name = "btn_ExportAgentCSV";
			btn_ExportAgentCSV.Size = new Size(119, 29);
			btn_ExportAgentCSV.TabIndex = 15;
			btn_ExportAgentCSV.Text = "Exportar .csv";
			btn_ExportAgentCSV.UseVisualStyleBackColor = true;
			btn_ExportAgentCSV.Click += btn_ExportAgentCSV_Click;
			// 
			// btn_ExportDivision
			// 
			btn_ExportDivision.Location = new Point(142, 293);
			btn_ExportDivision.Name = "btn_ExportDivision";
			btn_ExportDivision.Size = new Size(119, 29);
			btn_ExportDivision.TabIndex = 4;
			btn_ExportDivision.Text = "Exportar .csv";
			btn_ExportDivision.UseVisualStyleBackColor = true;
			btn_ExportDivision.Click += btn_ExportDivision_Click;
			// 
			// btn_ExportActivityAgent
			// 
			btn_ExportActivityAgent.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_ExportActivityAgent.Location = new Point(1166, 830);
			btn_ExportActivityAgent.Name = "btn_ExportActivityAgent";
			btn_ExportActivityAgent.Size = new Size(100, 29);
			btn_ExportActivityAgent.TabIndex = 39;
			btn_ExportActivityAgent.Text = "Exportar";
			btn_ExportActivityAgent.UseVisualStyleBackColor = true;
			btn_ExportActivityAgent.Click += btn_ExportActivityAgent_Click;
			// 
			// btn_NewGroup
			// 
			btn_NewGroup.Location = new Point(498, 44);
			btn_NewGroup.Name = "btn_NewGroup";
			btn_NewGroup.Size = new Size(66, 29);
			btn_NewGroup.TabIndex = 2;
			btn_NewGroup.Text = "Novo";
			btn_NewGroup.UseVisualStyleBackColor = true;
			btn_NewGroup.Click += btn_NewGroup_Click;
			// 
			// btn_New
			// 
			btn_New.Location = new Point(498, 400);
			btn_New.Name = "btn_New";
			btn_New.Size = new Size(66, 29);
			btn_New.TabIndex = 12;
			btn_New.Text = "Novo";
			btn_New.UseVisualStyleBackColor = true;
			btn_New.Click += btn_New_Click;
			// 
			// btn_ExportAgentResouceRelationship
			// 
			btn_ExportAgentResouceRelationship.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_ExportAgentResouceRelationship.Location = new Point(638, 831);
			btn_ExportAgentResouceRelationship.Name = "btn_ExportAgentResouceRelationship";
			btn_ExportAgentResouceRelationship.Size = new Size(95, 29);
			btn_ExportAgentResouceRelationship.TabIndex = 33;
			btn_ExportAgentResouceRelationship.Text = "Exportar";
			btn_ExportAgentResouceRelationship.UseVisualStyleBackColor = true;
			btn_ExportAgentResouceRelationship.Click += btn_ExportAgentResouceRelationship_Click;
			// 
			// btn_ImportAgentResouceRelationship
			// 
			btn_ImportAgentResouceRelationship.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_ImportAgentResouceRelationship.Location = new Point(738, 831);
			btn_ImportAgentResouceRelationship.Name = "btn_ImportAgentResouceRelationship";
			btn_ImportAgentResouceRelationship.Size = new Size(87, 29);
			btn_ImportAgentResouceRelationship.TabIndex = 34;
			btn_ImportAgentResouceRelationship.Text = "Importar";
			btn_ImportAgentResouceRelationship.UseVisualStyleBackColor = true;
			btn_ImportAgentResouceRelationship.Click += btn_ImportAgentResouceRelationship_Click;
			// 
			// Frm_Organization
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			AutoScroll = true;
			ClientSize = new Size(1696, 881);
			Controls.Add(btn_ExportAgentResouceRelationship);
			Controls.Add(btn_ImportAgentResouceRelationship);
			Controls.Add(btn_NewGroup);
			Controls.Add(btn_New);
			Controls.Add(btn_ExportActivityAgent);
			Controls.Add(btn_ExportDivision);
			Controls.Add(btn_ExportAgentCSV);
			Controls.Add(lbl_AgentsTotal);
			Controls.Add(btn_ImportAgentActivityRelationship);
			Controls.Add(btn_Del_Subordination);
			Controls.Add(btn_Del_OrgRelationship);
			Controls.Add(btn_ManageSectors);
			Controls.Add(lbl_SectorFilter);
			Controls.Add(btn_SaveDescription);
			Controls.Add(btn_OrganizationRelEdit);
			Controls.Add(btn_SubordinationRelEdit);
			Controls.Add(btn_ImportSectors);
			Controls.Add(btn_DeleteSector);
			Controls.Add(dataGridView3);
			Controls.Add(dataGridView2);
			Controls.Add(lbl_Det2);
			Controls.Add(lbl_Det1);
			Controls.Add(lbl_Description);
			Controls.Add(rtBox_Description);
			Controls.Add(btn_NewActivity);
			Controls.Add(lbl_Separator_Vertical);
			Controls.Add(btn_Del_Activity);
			Controls.Add(btn_Del_Resource);
			Controls.Add(lbl_detalhe_desc);
			Controls.Add(btn_ShowAllAgents);
			Controls.Add(btn_FilterAgents);
			Controls.Add(lbl_nomeFuncao);
			Controls.Add(lbl_Titulo_Atividade);
			Controls.Add(dg_ActivityRelationship);
			Controls.Add(dg_Sectors);
			Controls.Add(lbl_detalhe);
			Controls.Add(lbl_Titulo_Funcao);
			Controls.Add(btn_Import);
			Controls.Add(btn_nova_pessoa);
			Controls.Add(lbl_Pessoas);
			Controls.Add(dg_ResourceRelationship);
			Controls.Add(btn_DeleteAgent);
			Controls.Add(dg_Agents);
			Controls.Add(lbl_Title);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "Frm_Organization";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "MAEA - Organização";
			Load += Frm_Organization_Load;
			((System.ComponentModel.ISupportInitialize)dg_Agents).EndInit();
			((System.ComponentModel.ISupportInitialize)agentBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)dg_ResourceRelationship).EndInit();
			((System.ComponentModel.ISupportInitialize)relationshipViewModelBindingSource1).EndInit();
			((System.ComponentModel.ISupportInitialize)humanResourceBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)dg_Sectors).EndInit();
			((System.ComponentModel.ISupportInitialize)organizationBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)organizationBindingSource1).EndInit();
			((System.ComponentModel.ISupportInitialize)dg_ActivityRelationship).EndInit();
			((System.ComponentModel.ISupportInitialize)relationshipViewModelBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
			((System.ComponentModel.ISupportInitialize)agentBindingSource1).EndInit();
			((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private MenuStrip Menu_Principal;
		private ToolStripMenuItem geralToolStripMenuItem;
		private ToolStripMenuItem organizaçãoToolStripMenuItem;
		private ToolStripMenuItem atividadesToolStripMenuItem;
		private ToolStripMenuItem elementosToolStripMenuItem;
		private ToolStripMenuItem pessoasToolStripMenuItem;
		private ToolStripMenuItem listaToolStripMenuItem;
		private Label lbl_Title;
		private Button Btn_Nova_Funcao;
		private DataGridView dg_Agents;
		private Button btn_editar;
		private Button btn_DeleteAgent;
		private DataGridView dg_ResourceRelationship;
		private DataGridViewTextBoxColumn idPessoaDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn codPessoaDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn nomePessoaDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn competenciasDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn tipoPessoaDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn contatoDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn registroDataGridViewTextBoxColumn;
		private Label lbl_Pessoas;
		private Button btn_nova_pessoa;
		private Button btn_Import;
		private DataGridViewTextBoxColumn idFuncaoDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn codFuncaoDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn nomeFuncaoDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn descricaoFuncaoDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn subordinacaoFuncionalIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn subordinacaoFuncionalDataGridViewTextBoxColumn;
		private Label lbl_Titulo_Funcao;
		private Label lbl_detalhe;
		private DataGridView dg_Sectors;
		private DataGridView dg_ActivityRelationship;
		private DataGridViewTextBoxColumn idSetorDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn codSetorDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn nomeDoSetorDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn funcaoIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn descricaoSetorDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn instanciaSuperiorDataGridViewTextBoxColumn;
		private Label lbl_Titulo_Atividade;
		private Button btn_FilterAgents;
		private Button btn_ShowAllAgents;
		private Label lbl_detalhe_desc;
		private Label lbl_nomeFuncao;
		private Button btn_Del_Resource;
		private Button btn_Del_Activity;
		private DataGridViewTextBoxColumn idAtividadeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn codAtividadeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn nomeDaAtividadeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn descricaoDaAtividadeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn periodicidadeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn duracaoDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn competenciaExigidaDataGridViewTextBoxColumn;
		private Label lbl_Separator_Vertical;
		private BindingSource humanResourceBindingSource;
		private Button btn_NewActivity;
		private BindingSource agentBindingSource;
		private BindingSource relationshipViewModelBindingSource;
		private BindingSource relationshipViewModelBindingSource1;
		private RichTextBox rtBox_Description;
		private Label lbl_Description;
		private Label lbl_Det1;
		private Label lbl_Det2;
		private DataGridView dataGridView2;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn3;
		private BindingSource agentBindingSource1;
		private DataGridView dataGridView3;
		private BindingSource organizationBindingSource;
		private BindingSource organizationBindingSource1;
		private Button btn_DeleteSector;
		private Button btn_ImportSectors;
		private Button btn_SubordinationRelEdit;
		private Button btn_OrganizationRelEdit;
		private Button btn_SaveDescription;
		private DataGridViewTextBoxColumn functionalCapacityIdDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn functionalCapacityDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn functionalSubordinationIdDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn functionalSubordinationDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn agentIdDataGridViewTextBoxColumn3;
		private DataGridViewTextBoxColumn responsibleAgentDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn agentIdDataGridViewTextBoxColumn2;
		private DataGridViewTextBoxColumn responsibleAgentDataGridViewTextBoxColumn;
		private Label lbl_SectorFilter;
		private DataGridViewTextBoxColumn functionalCapacityIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn functionalCapacityDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn functionalSubordinationIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn functionalSubordinationDataGridViewTextBoxColumn;
		private Button btn_ManageSectors;
		private Button btn_Del_OrgRelationship;
		private Button btn_Del_Subordination;
		private DataGridViewTextBoxColumn relationshipIdDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn relationshipDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn relationshipIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn2;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn2;
		private DataGridViewTextBoxColumn relationshipDataGridViewTextBoxColumn;
		private Button btn_ImportAgentActivityRelationship;
		private DataGridViewTextBoxColumn agentIdDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn3;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn4;
		private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn sectorIdDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn5;
		private DataGridViewTextBoxColumn sectorNameDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn3;
		private DataGridViewTextBoxColumn superiorInstanceIdDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn superiorInstanceDataGridViewTextBoxColumn1;
		private Label lbl_AgentsTotal;
		private Button btn_ExportAgentCSV;
		private Button btn_ExportDivision;
		private Button btn_ExportActivityAgent;
		private Button btn_NewGroup;
		private Button btn_New;
		private DataGridViewTextBoxColumn agentIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn lotacaoFuncional;
		private Button btn_ExportAgentResouceRelationship;
		private Button btn_ImportAgentResouceRelationship;
		private DataGridViewTextBoxColumn sectorIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn4;
		private DataGridViewTextBoxColumn sectorNameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn2;
		private DataGridViewTextBoxColumn superiorInstanceIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn superiorInstanceDataGridViewTextBoxColumn;
	}
}