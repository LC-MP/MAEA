namespace MSCMD.Forms
{
	partial class Frm_Activity
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Activity));
			lbl_TituloAtividade = new Label();
			btn_Importarcsv = new Button();
			dg_Activities = new DataGridView();
			activityIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			activityCodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			activityNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			activityDescriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			periodicity1DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			periodicity2DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			durationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			requiredCompetenceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			activityBindingSource = new BindingSource(components);
			dg_activityRelationship = new DataGridView();
			relationshipIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			relationshipDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			codeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			relationshipViewModelBindingSource = new BindingSource(components);
			dg_elementRelationship = new DataGridView();
			relationshipIdDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			relationshipDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			codeDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			nameDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			relationshipViewModelBindingSource1 = new BindingSource(components);
			lbl_ActivityRel = new Label();
			lbl_Agents = new Label();
			lbl_Elements = new Label();
			btn_AddActivRelation = new Button();
			btn_AddAgent = new Button();
			btn_AddElement = new Button();
			btn_DeleteActivRelation = new Button();
			btn_DeleteAgent = new Button();
			btn_DeleteElement = new Button();
			btn_DeleteActivity = new Button();
			dg_AgentRelationship = new DataGridView();
			relationshipIdDataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			codeDataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			nameDataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			relationshipDataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			relationshipViewModelBindingSource2 = new BindingSource(components);
			dg_Group = new DataGridView();
			subprocessIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			codeDataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
			nameDataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
			subprocessBindingSource = new BindingSource(components);
			lbl_DetAtividade = new Label();
			lbl_Title = new Label();
			lbl_DetAtividadeDesc = new Label();
			lbl_ActivityName = new Label();
			rtxtb_Description = new RichTextBox();
			rtxtb_Competences = new RichTextBox();
			cb_Periodicity1 = new ComboBox();
			cb_Duration = new ComboBox();
			lbl_Description = new Label();
			lbl_Competences = new Label();
			lbl_Periodicity = new Label();
			lbl_Duration = new Label();
			btn_SaveDetails = new Button();
			lbl_Separator_Vertical = new Label();
			btn_SubprocessScreen = new Button();
			btn_FilterActivities = new Button();
			btn_ShowAllActivities = new Button();
			btn_DeleteSubprocess = new Button();
			lbl_GroupFilter = new Label();
			btn_ImportActivityRel = new Button();
			btn_ImportActivityElementRel = new Button();
			btn_ImportActivityAgent = new Button();
			lbl_ActivitiesTotal = new Label();
			btn_ImportSectors = new Button();
			btn_ExportActivity = new Button();
			btn_ExportSubprocess = new Button();
			btn_ExportActivityActivity = new Button();
			btn_ExportActivityElement = new Button();
			btn_ExportActivityAgent = new Button();
			dataGridView1 = new DataGridView();
			subprocessIdDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			codeDataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
			nameDataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
			subprocessBindingSource1 = new BindingSource(components);
			button1 = new Button();
			button2 = new Button();
			cb_Periodity = new ComboBox();
			btn_New = new Button();
			btn_NewGroup = new Button();
			label3 = new Label();
			((System.ComponentModel.ISupportInitialize)dg_Activities).BeginInit();
			((System.ComponentModel.ISupportInitialize)activityBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)dg_activityRelationship).BeginInit();
			((System.ComponentModel.ISupportInitialize)relationshipViewModelBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)dg_elementRelationship).BeginInit();
			((System.ComponentModel.ISupportInitialize)relationshipViewModelBindingSource1).BeginInit();
			((System.ComponentModel.ISupportInitialize)dg_AgentRelationship).BeginInit();
			((System.ComponentModel.ISupportInitialize)relationshipViewModelBindingSource2).BeginInit();
			((System.ComponentModel.ISupportInitialize)dg_Group).BeginInit();
			((System.ComponentModel.ISupportInitialize)subprocessBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			((System.ComponentModel.ISupportInitialize)subprocessBindingSource1).BeginInit();
			SuspendLayout();
			// 
			// lbl_TituloAtividade
			// 
			lbl_TituloAtividade.AutoSize = true;
			lbl_TituloAtividade.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_TituloAtividade.Location = new Point(24, 387);
			lbl_TituloAtividade.Name = "lbl_TituloAtividade";
			lbl_TituloAtividade.Size = new Size(129, 32);
			lbl_TituloAtividade.TabIndex = 8;
			lbl_TituloAtividade.Text = "Atividades:";
			// 
			// btn_Importarcsv
			// 
			btn_Importarcsv.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_Importarcsv.Location = new Point(304, 827);
			btn_Importarcsv.Name = "btn_Importarcsv";
			btn_Importarcsv.Size = new Size(123, 29);
			btn_Importarcsv.TabIndex = 14;
			btn_Importarcsv.Text = "Importar .csv";
			btn_Importarcsv.UseVisualStyleBackColor = true;
			btn_Importarcsv.Click += btn_Importarcsv_Click;
			// 
			// dg_Activities
			// 
			dg_Activities.AllowUserToDeleteRows = false;
			dg_Activities.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			dg_Activities.AutoGenerateColumns = false;
			dg_Activities.BackgroundColor = SystemColors.ControlLight;
			dg_Activities.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_Activities.Columns.AddRange(new DataGridViewColumn[] { activityIdDataGridViewTextBoxColumn, activityCodeDataGridViewTextBoxColumn, activityNameDataGridViewTextBoxColumn, activityDescriptionDataGridViewTextBoxColumn, periodicity1DataGridViewTextBoxColumn, periodicity2DataGridViewTextBoxColumn, durationDataGridViewTextBoxColumn, requiredCompetenceDataGridViewTextBoxColumn });
			dg_Activities.DataSource = activityBindingSource;
			dg_Activities.Location = new Point(24, 424);
			dg_Activities.Name = "dg_Activities";
			dg_Activities.RowHeadersVisible = false;
			dg_Activities.RowHeadersWidth = 51;
			dg_Activities.RowTemplate.Height = 29;
			dg_Activities.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_Activities.Size = new Size(533, 396);
			dg_Activities.TabIndex = 11;
			dg_Activities.CellClick += dg_Activities_CellClick;
			dg_Activities.CellEndEdit += dg_Activities_CellEndEdit;
			dg_Activities.CellEnter += dg_Activities_CellEnter;
			dg_Activities.CellFormatting += dg_Activities_CellFormatting;
			dg_Activities.ColumnHeaderMouseClick += dg_Activities_ColumnHeaderMouseClick;
			// 
			// activityIdDataGridViewTextBoxColumn
			// 
			activityIdDataGridViewTextBoxColumn.DataPropertyName = "ActivityId";
			activityIdDataGridViewTextBoxColumn.HeaderText = "Id";
			activityIdDataGridViewTextBoxColumn.MinimumWidth = 6;
			activityIdDataGridViewTextBoxColumn.Name = "activityIdDataGridViewTextBoxColumn";
			activityIdDataGridViewTextBoxColumn.ReadOnly = true;
			activityIdDataGridViewTextBoxColumn.Width = 55;
			// 
			// activityCodeDataGridViewTextBoxColumn
			// 
			activityCodeDataGridViewTextBoxColumn.DataPropertyName = "ActivityCode";
			activityCodeDataGridViewTextBoxColumn.HeaderText = "Código";
			activityCodeDataGridViewTextBoxColumn.MinimumWidth = 6;
			activityCodeDataGridViewTextBoxColumn.Name = "activityCodeDataGridViewTextBoxColumn";
			activityCodeDataGridViewTextBoxColumn.Width = 90;
			// 
			// activityNameDataGridViewTextBoxColumn
			// 
			activityNameDataGridViewTextBoxColumn.DataPropertyName = "ActivityName";
			activityNameDataGridViewTextBoxColumn.HeaderText = "Nome";
			activityNameDataGridViewTextBoxColumn.MinimumWidth = 6;
			activityNameDataGridViewTextBoxColumn.Name = "activityNameDataGridViewTextBoxColumn";
			activityNameDataGridViewTextBoxColumn.Width = 320;
			// 
			// activityDescriptionDataGridViewTextBoxColumn
			// 
			activityDescriptionDataGridViewTextBoxColumn.DataPropertyName = "ActivityDescription";
			activityDescriptionDataGridViewTextBoxColumn.HeaderText = "Descrição";
			activityDescriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
			activityDescriptionDataGridViewTextBoxColumn.Name = "activityDescriptionDataGridViewTextBoxColumn";
			activityDescriptionDataGridViewTextBoxColumn.Visible = false;
			activityDescriptionDataGridViewTextBoxColumn.Width = 125;
			// 
			// periodicity1DataGridViewTextBoxColumn
			// 
			periodicity1DataGridViewTextBoxColumn.DataPropertyName = "Periodicity1";
			periodicity1DataGridViewTextBoxColumn.HeaderText = "Periodicity1";
			periodicity1DataGridViewTextBoxColumn.MinimumWidth = 6;
			periodicity1DataGridViewTextBoxColumn.Name = "periodicity1DataGridViewTextBoxColumn";
			periodicity1DataGridViewTextBoxColumn.Visible = false;
			periodicity1DataGridViewTextBoxColumn.Width = 125;
			// 
			// periodicity2DataGridViewTextBoxColumn
			// 
			periodicity2DataGridViewTextBoxColumn.DataPropertyName = "Periodicity2";
			periodicity2DataGridViewTextBoxColumn.HeaderText = "Periodicity2";
			periodicity2DataGridViewTextBoxColumn.MinimumWidth = 6;
			periodicity2DataGridViewTextBoxColumn.Name = "periodicity2DataGridViewTextBoxColumn";
			periodicity2DataGridViewTextBoxColumn.Visible = false;
			periodicity2DataGridViewTextBoxColumn.Width = 125;
			// 
			// durationDataGridViewTextBoxColumn
			// 
			durationDataGridViewTextBoxColumn.DataPropertyName = "Duration";
			durationDataGridViewTextBoxColumn.HeaderText = "Duration";
			durationDataGridViewTextBoxColumn.MinimumWidth = 6;
			durationDataGridViewTextBoxColumn.Name = "durationDataGridViewTextBoxColumn";
			durationDataGridViewTextBoxColumn.Visible = false;
			durationDataGridViewTextBoxColumn.Width = 125;
			// 
			// requiredCompetenceDataGridViewTextBoxColumn
			// 
			requiredCompetenceDataGridViewTextBoxColumn.DataPropertyName = "RequiredCompetence";
			requiredCompetenceDataGridViewTextBoxColumn.HeaderText = "RequiredCompetence";
			requiredCompetenceDataGridViewTextBoxColumn.MinimumWidth = 6;
			requiredCompetenceDataGridViewTextBoxColumn.Name = "requiredCompetenceDataGridViewTextBoxColumn";
			requiredCompetenceDataGridViewTextBoxColumn.Visible = false;
			requiredCompetenceDataGridViewTextBoxColumn.Width = 125;
			// 
			// activityBindingSource
			// 
			activityBindingSource.DataSource = typeof(Model.Activity);
			// 
			// dg_activityRelationship
			// 
			dg_activityRelationship.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			dg_activityRelationship.AutoGenerateColumns = false;
			dg_activityRelationship.BackgroundColor = SystemColors.ControlLight;
			dg_activityRelationship.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_activityRelationship.Columns.AddRange(new DataGridViewColumn[] { relationshipIdDataGridViewTextBoxColumn, relationshipDataGridViewTextBoxColumn, codeDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn });
			dg_activityRelationship.DataSource = relationshipViewModelBindingSource;
			dg_activityRelationship.Location = new Point(616, 544);
			dg_activityRelationship.Name = "dg_activityRelationship";
			dg_activityRelationship.ReadOnly = true;
			dg_activityRelationship.RowHeadersVisible = false;
			dg_activityRelationship.RowHeadersWidth = 51;
			dg_activityRelationship.RowTemplate.Height = 29;
			dg_activityRelationship.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_activityRelationship.Size = new Size(512, 276);
			dg_activityRelationship.TabIndex = 37;
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
			// relationshipDataGridViewTextBoxColumn
			// 
			relationshipDataGridViewTextBoxColumn.DataPropertyName = "Relationship";
			relationshipDataGridViewTextBoxColumn.HeaderText = "Relação";
			relationshipDataGridViewTextBoxColumn.MinimumWidth = 6;
			relationshipDataGridViewTextBoxColumn.Name = "relationshipDataGridViewTextBoxColumn";
			relationshipDataGridViewTextBoxColumn.ReadOnly = true;
			relationshipDataGridViewTextBoxColumn.Width = 125;
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
			nameDataGridViewTextBoxColumn.Width = 280;
			// 
			// relationshipViewModelBindingSource
			// 
			relationshipViewModelBindingSource.DataSource = typeof(ViewModel.RelationshipViewModel);
			// 
			// dg_elementRelationship
			// 
			dg_elementRelationship.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			dg_elementRelationship.AutoGenerateColumns = false;
			dg_elementRelationship.BackgroundColor = SystemColors.ControlLight;
			dg_elementRelationship.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_elementRelationship.Columns.AddRange(new DataGridViewColumn[] { relationshipIdDataGridViewTextBoxColumn1, relationshipDataGridViewTextBoxColumn1, codeDataGridViewTextBoxColumn1, nameDataGridViewTextBoxColumn1 });
			dg_elementRelationship.DataSource = relationshipViewModelBindingSource1;
			dg_elementRelationship.Location = new Point(1151, 545);
			dg_elementRelationship.Name = "dg_elementRelationship";
			dg_elementRelationship.ReadOnly = true;
			dg_elementRelationship.RowHeadersVisible = false;
			dg_elementRelationship.RowHeadersWidth = 51;
			dg_elementRelationship.RowTemplate.Height = 29;
			dg_elementRelationship.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_elementRelationship.Size = new Size(512, 276);
			dg_elementRelationship.TabIndex = 43;
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
			// relationshipDataGridViewTextBoxColumn1
			// 
			relationshipDataGridViewTextBoxColumn1.DataPropertyName = "Relationship";
			relationshipDataGridViewTextBoxColumn1.HeaderText = "Relação";
			relationshipDataGridViewTextBoxColumn1.MinimumWidth = 6;
			relationshipDataGridViewTextBoxColumn1.Name = "relationshipDataGridViewTextBoxColumn1";
			relationshipDataGridViewTextBoxColumn1.ReadOnly = true;
			relationshipDataGridViewTextBoxColumn1.Width = 125;
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
			nameDataGridViewTextBoxColumn1.Width = 280;
			// 
			// relationshipViewModelBindingSource1
			// 
			relationshipViewModelBindingSource1.DataSource = typeof(ViewModel.RelationshipViewModel);
			// 
			// lbl_ActivityRel
			// 
			lbl_ActivityRel.AutoSize = true;
			lbl_ActivityRel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_ActivityRel.Location = new Point(614, 521);
			lbl_ActivityRel.Name = "lbl_ActivityRel";
			lbl_ActivityRel.Size = new Size(208, 20);
			lbl_ActivityRel.TabIndex = 36;
			lbl_ActivityRel.Text = "Relacionada a outra atividade";
			// 
			// lbl_Agents
			// 
			lbl_Agents.AutoSize = true;
			lbl_Agents.Location = new Point(1151, 247);
			lbl_Agents.Name = "lbl_Agents";
			lbl_Agents.Size = new Size(138, 20);
			lbl_Agents.TabIndex = 30;
			lbl_Agents.Text = "Função responsável";
			// 
			// lbl_Elements
			// 
			lbl_Elements.AutoSize = true;
			lbl_Elements.Location = new Point(1151, 522);
			lbl_Elements.Name = "lbl_Elements";
			lbl_Elements.Size = new Size(179, 20);
			lbl_Elements.TabIndex = 42;
			lbl_Elements.Text = "Relacionada ao elemento";
			// 
			// btn_AddActivRelation
			// 
			btn_AddActivRelation.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_AddActivRelation.Location = new Point(807, 826);
			btn_AddActivRelation.Name = "btn_AddActivRelation";
			btn_AddActivRelation.Size = new Size(160, 29);
			btn_AddActivRelation.TabIndex = 40;
			btn_AddActivRelation.Text = "Selecionar vínculos...";
			btn_AddActivRelation.UseVisualStyleBackColor = true;
			btn_AddActivRelation.Click += btn_AddActivRelation_Click;
			// 
			// btn_AddAgent
			// 
			btn_AddAgent.Location = new Point(1348, 471);
			btn_AddAgent.Name = "btn_AddAgent";
			btn_AddAgent.Size = new Size(154, 29);
			btn_AddAgent.TabIndex = 34;
			btn_AddAgent.Text = "Selecionar vínculos...";
			btn_AddAgent.UseVisualStyleBackColor = true;
			btn_AddAgent.Click += btn_AddAgent_Click;
			// 
			// btn_AddElement
			// 
			btn_AddElement.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_AddElement.Location = new Point(1347, 827);
			btn_AddElement.Name = "btn_AddElement";
			btn_AddElement.Size = new Size(154, 29);
			btn_AddElement.TabIndex = 46;
			btn_AddElement.Text = "Selecionar vínculos...";
			btn_AddElement.UseVisualStyleBackColor = true;
			btn_AddElement.Click += btn_AddElement_Click;
			// 
			// btn_DeleteActivRelation
			// 
			btn_DeleteActivRelation.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_DeleteActivRelation.Location = new Point(971, 826);
			btn_DeleteActivRelation.Name = "btn_DeleteActivRelation";
			btn_DeleteActivRelation.Size = new Size(157, 29);
			btn_DeleteActivRelation.TabIndex = 41;
			btn_DeleteActivRelation.Text = "Desvincular seleção";
			btn_DeleteActivRelation.UseVisualStyleBackColor = true;
			btn_DeleteActivRelation.Click += btn_DeleteActivRelation_Click;
			// 
			// btn_DeleteAgent
			// 
			btn_DeleteAgent.Location = new Point(1508, 471);
			btn_DeleteAgent.Name = "btn_DeleteAgent";
			btn_DeleteAgent.Size = new Size(156, 29);
			btn_DeleteAgent.TabIndex = 35;
			btn_DeleteAgent.Text = "Desvincular seleção";
			btn_DeleteAgent.UseVisualStyleBackColor = true;
			btn_DeleteAgent.Click += btn_DeleteAgent_Click;
			// 
			// btn_DeleteElement
			// 
			btn_DeleteElement.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_DeleteElement.Location = new Point(1507, 827);
			btn_DeleteElement.Name = "btn_DeleteElement";
			btn_DeleteElement.Size = new Size(157, 29);
			btn_DeleteElement.TabIndex = 47;
			btn_DeleteElement.Text = "Desvincular seleção";
			btn_DeleteElement.UseVisualStyleBackColor = true;
			btn_DeleteElement.Click += btn_DeleteElement_Click;
			// 
			// btn_DeleteActivity
			// 
			btn_DeleteActivity.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_DeleteActivity.Location = new Point(433, 827);
			btn_DeleteActivity.Name = "btn_DeleteActivity";
			btn_DeleteActivity.Size = new Size(123, 29);
			btn_DeleteActivity.TabIndex = 15;
			btn_DeleteActivity.Text = "Deletar seleção";
			btn_DeleteActivity.UseVisualStyleBackColor = true;
			btn_DeleteActivity.Click += btn_DeleteActivity_Click;
			// 
			// dg_AgentRelationship
			// 
			dg_AgentRelationship.AutoGenerateColumns = false;
			dg_AgentRelationship.BackgroundColor = SystemColors.ControlLight;
			dg_AgentRelationship.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_AgentRelationship.Columns.AddRange(new DataGridViewColumn[] { relationshipIdDataGridViewTextBoxColumn2, codeDataGridViewTextBoxColumn2, nameDataGridViewTextBoxColumn2, relationshipDataGridViewTextBoxColumn2 });
			dg_AgentRelationship.DataSource = relationshipViewModelBindingSource2;
			dg_AgentRelationship.Location = new Point(1152, 271);
			dg_AgentRelationship.Margin = new Padding(3, 4, 3, 4);
			dg_AgentRelationship.Name = "dg_AgentRelationship";
			dg_AgentRelationship.ReadOnly = true;
			dg_AgentRelationship.RowHeadersVisible = false;
			dg_AgentRelationship.RowHeadersWidth = 51;
			dg_AgentRelationship.RowTemplate.Height = 25;
			dg_AgentRelationship.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_AgentRelationship.Size = new Size(512, 193);
			dg_AgentRelationship.TabIndex = 31;
			// 
			// relationshipIdDataGridViewTextBoxColumn2
			// 
			relationshipIdDataGridViewTextBoxColumn2.DataPropertyName = "RelationshipId";
			relationshipIdDataGridViewTextBoxColumn2.HeaderText = "RelationshipId";
			relationshipIdDataGridViewTextBoxColumn2.MinimumWidth = 6;
			relationshipIdDataGridViewTextBoxColumn2.Name = "relationshipIdDataGridViewTextBoxColumn2";
			relationshipIdDataGridViewTextBoxColumn2.ReadOnly = true;
			relationshipIdDataGridViewTextBoxColumn2.Visible = false;
			relationshipIdDataGridViewTextBoxColumn2.Width = 125;
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
			nameDataGridViewTextBoxColumn2.Width = 405;
			// 
			// relationshipDataGridViewTextBoxColumn2
			// 
			relationshipDataGridViewTextBoxColumn2.DataPropertyName = "Relationship";
			relationshipDataGridViewTextBoxColumn2.HeaderText = "Relationship";
			relationshipDataGridViewTextBoxColumn2.MinimumWidth = 6;
			relationshipDataGridViewTextBoxColumn2.Name = "relationshipDataGridViewTextBoxColumn2";
			relationshipDataGridViewTextBoxColumn2.ReadOnly = true;
			relationshipDataGridViewTextBoxColumn2.Visible = false;
			relationshipDataGridViewTextBoxColumn2.Width = 125;
			// 
			// relationshipViewModelBindingSource2
			// 
			relationshipViewModelBindingSource2.DataSource = typeof(ViewModel.RelationshipViewModel);
			// 
			// dg_Group
			// 
			dg_Group.AllowUserToDeleteRows = false;
			dg_Group.AutoGenerateColumns = false;
			dg_Group.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_Group.Columns.AddRange(new DataGridViewColumn[] { subprocessIdDataGridViewTextBoxColumn, codeDataGridViewTextBoxColumn3, nameDataGridViewTextBoxColumn3 });
			dg_Group.DataSource = subprocessBindingSource;
			dg_Group.Location = new Point(23, 55);
			dg_Group.Margin = new Padding(3, 4, 3, 4);
			dg_Group.Name = "dg_Group";
			dg_Group.RowHeadersVisible = false;
			dg_Group.RowHeadersWidth = 51;
			dg_Group.RowTemplate.Height = 25;
			dg_Group.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_Group.Size = new Size(534, 235);
			dg_Group.TabIndex = 1;
			dg_Group.CellEndEdit += dg_Group_CellEndEdit;
			dg_Group.CellFormatting += dg_Group_CellFormatting;
			dg_Group.ColumnHeaderMouseClick += dg_Group_ColumnHeaderMouseClick;
			// 
			// subprocessIdDataGridViewTextBoxColumn
			// 
			subprocessIdDataGridViewTextBoxColumn.DataPropertyName = "SubprocessId";
			subprocessIdDataGridViewTextBoxColumn.HeaderText = "Id";
			subprocessIdDataGridViewTextBoxColumn.MinimumWidth = 6;
			subprocessIdDataGridViewTextBoxColumn.Name = "subprocessIdDataGridViewTextBoxColumn";
			subprocessIdDataGridViewTextBoxColumn.ReadOnly = true;
			subprocessIdDataGridViewTextBoxColumn.Width = 50;
			// 
			// codeDataGridViewTextBoxColumn3
			// 
			codeDataGridViewTextBoxColumn3.DataPropertyName = "Code";
			codeDataGridViewTextBoxColumn3.HeaderText = "Código";
			codeDataGridViewTextBoxColumn3.MinimumWidth = 6;
			codeDataGridViewTextBoxColumn3.Name = "codeDataGridViewTextBoxColumn3";
			codeDataGridViewTextBoxColumn3.Width = 90;
			// 
			// nameDataGridViewTextBoxColumn3
			// 
			nameDataGridViewTextBoxColumn3.DataPropertyName = "Name";
			nameDataGridViewTextBoxColumn3.HeaderText = "Nome*";
			nameDataGridViewTextBoxColumn3.MinimumWidth = 6;
			nameDataGridViewTextBoxColumn3.Name = "nameDataGridViewTextBoxColumn3";
			nameDataGridViewTextBoxColumn3.Width = 360;
			// 
			// subprocessBindingSource
			// 
			subprocessBindingSource.DataSource = typeof(Model.Subprocess);
			// 
			// lbl_DetAtividade
			// 
			lbl_DetAtividade.AutoSize = true;
			lbl_DetAtividade.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_DetAtividade.Location = new Point(616, 36);
			lbl_DetAtividade.Name = "lbl_DetAtividade";
			lbl_DetAtividade.Size = new Size(262, 32);
			lbl_DetAtividade.TabIndex = 17;
			lbl_DetAtividade.Text = "Detalhes da Atividades:";
			// 
			// lbl_Title
			// 
			lbl_Title.AutoSize = true;
			lbl_Title.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_Title.Location = new Point(24, 19);
			lbl_Title.Name = "lbl_Title";
			lbl_Title.Size = new Size(159, 32);
			lbl_Title.TabIndex = 21;
			lbl_Title.Text = "Subprocessos";
			// 
			// lbl_DetAtividadeDesc
			// 
			lbl_DetAtividadeDesc.AutoSize = true;
			lbl_DetAtividadeDesc.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_DetAtividadeDesc.Location = new Point(616, 16);
			lbl_DetAtividadeDesc.Name = "lbl_DetAtividadeDesc";
			lbl_DetAtividadeDesc.Size = new Size(389, 20);
			lbl_DetAtividadeDesc.TabIndex = 16;
			lbl_DetAtividadeDesc.Text = "Selecione uma atividade na tabela ao lado para detalhar.";
			// 
			// lbl_ActivityName
			// 
			lbl_ActivityName.AutoEllipsis = true;
			lbl_ActivityName.AutoSize = true;
			lbl_ActivityName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
			lbl_ActivityName.Location = new Point(878, 39);
			lbl_ActivityName.MaximumSize = new Size(750, 60);
			lbl_ActivityName.Name = "lbl_ActivityName";
			lbl_ActivityName.Size = new Size(103, 28);
			lbl_ActivityName.TabIndex = 18;
			lbl_ActivityName.Text = "Atividade";
			// 
			// rtxtb_Description
			// 
			rtxtb_Description.Location = new Point(618, 103);
			rtxtb_Description.Margin = new Padding(3, 4, 3, 4);
			rtxtb_Description.Name = "rtxtb_Description";
			rtxtb_Description.Size = new Size(347, 115);
			rtxtb_Description.TabIndex = 19;
			rtxtb_Description.Text = "";
			rtxtb_Description.Leave += rtxtb_Description_Leave;
			// 
			// rtxtb_Competences
			// 
			rtxtb_Competences.Location = new Point(984, 103);
			rtxtb_Competences.Margin = new Padding(3, 4, 3, 4);
			rtxtb_Competences.Name = "rtxtb_Competences";
			rtxtb_Competences.Size = new Size(346, 115);
			rtxtb_Competences.TabIndex = 20;
			rtxtb_Competences.Text = "";
			rtxtb_Competences.Leave += rtxtb_Competences_Leave;
			// 
			// cb_Periodicity1
			// 
			cb_Periodicity1.FormattingEnabled = true;
			cb_Periodicity1.Location = new Point(1365, 103);
			cb_Periodicity1.Margin = new Padding(3, 4, 3, 4);
			cb_Periodicity1.Name = "cb_Periodicity1";
			cb_Periodicity1.Size = new Size(274, 28);
			cb_Periodicity1.TabIndex = 22;
			cb_Periodicity1.Leave += cb_Periodicity1_Leave;
			// 
			// cb_Duration
			// 
			cb_Duration.FormattingEnabled = true;
			cb_Duration.Location = new Point(1365, 194);
			cb_Duration.Margin = new Padding(3, 4, 3, 4);
			cb_Duration.Name = "cb_Duration";
			cb_Duration.Size = new Size(274, 28);
			cb_Duration.TabIndex = 25;
			cb_Duration.Leave += cb_Duration_Leave;
			// 
			// lbl_Description
			// 
			lbl_Description.AutoSize = true;
			lbl_Description.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_Description.Location = new Point(618, 79);
			lbl_Description.Name = "lbl_Description";
			lbl_Description.Size = new Size(164, 20);
			lbl_Description.TabIndex = 29;
			lbl_Description.Text = "Descrição da atividade:";
			// 
			// lbl_Competences
			// 
			lbl_Competences.AutoSize = true;
			lbl_Competences.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_Competences.Location = new Point(984, 81);
			lbl_Competences.Name = "lbl_Competences";
			lbl_Competences.Size = new Size(165, 20);
			lbl_Competences.TabIndex = 30;
			lbl_Competences.Text = "Competências exigidas:";
			// 
			// lbl_Periodicity
			// 
			lbl_Periodicity.AutoSize = true;
			lbl_Periodicity.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_Periodicity.Location = new Point(1365, 82);
			lbl_Periodicity.Name = "lbl_Periodicity";
			lbl_Periodicity.Size = new Size(103, 20);
			lbl_Periodicity.TabIndex = 21;
			lbl_Periodicity.Text = "Periodicidade:";
			// 
			// lbl_Duration
			// 
			lbl_Duration.AutoSize = true;
			lbl_Duration.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_Duration.Location = new Point(1365, 170);
			lbl_Duration.Name = "lbl_Duration";
			lbl_Duration.Size = new Size(68, 20);
			lbl_Duration.TabIndex = 24;
			lbl_Duration.Text = "Duração:";
			// 
			// btn_SaveDetails
			// 
			btn_SaveDetails.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btn_SaveDetails.Location = new Point(1543, 5);
			btn_SaveDetails.Margin = new Padding(3, 4, 3, 4);
			btn_SaveDetails.Name = "btn_SaveDetails";
			btn_SaveDetails.Size = new Size(145, 33);
			btn_SaveDetails.TabIndex = 48;
			btn_SaveDetails.Text = "Salvar alterações";
			btn_SaveDetails.UseVisualStyleBackColor = true;
			btn_SaveDetails.Click += btn_SaveDetails_Click;
			// 
			// lbl_Separator_Vertical
			// 
			lbl_Separator_Vertical.BorderStyle = BorderStyle.Fixed3D;
			lbl_Separator_Vertical.Location = new Point(583, 15);
			lbl_Separator_Vertical.Name = "lbl_Separator_Vertical";
			lbl_Separator_Vertical.Size = new Size(2, 840);
			lbl_Separator_Vertical.TabIndex = 35;
			// 
			// btn_SubprocessScreen
			// 
			btn_SubprocessScreen.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
			btn_SubprocessScreen.Location = new Point(386, 355);
			btn_SubprocessScreen.Name = "btn_SubprocessScreen";
			btn_SubprocessScreen.Size = new Size(176, 29);
			btn_SubprocessScreen.TabIndex = 7;
			btn_SubprocessScreen.Text = "Gerenciar Subprocessos...";
			btn_SubprocessScreen.UseVisualStyleBackColor = true;
			btn_SubprocessScreen.Click += btn_SubprocessScreen_Click;
			// 
			// btn_FilterActivities
			// 
			btn_FilterActivities.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
			btn_FilterActivities.Location = new Point(146, 355);
			btn_FilterActivities.Name = "btn_FilterActivities";
			btn_FilterActivities.Size = new Size(234, 29);
			btn_FilterActivities.TabIndex = 6;
			btn_FilterActivities.Text = "Filtrar por subprocesso selecionado";
			btn_FilterActivities.UseVisualStyleBackColor = true;
			btn_FilterActivities.Click += btn_FilterActivities_Click;
			// 
			// btn_ShowAllActivities
			// 
			btn_ShowAllActivities.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
			btn_ShowAllActivities.Location = new Point(25, 355);
			btn_ShowAllActivities.Name = "btn_ShowAllActivities";
			btn_ShowAllActivities.Size = new Size(115, 29);
			btn_ShowAllActivities.TabIndex = 5;
			btn_ShowAllActivities.Text = "Mostrar todas";
			btn_ShowAllActivities.UseVisualStyleBackColor = true;
			btn_ShowAllActivities.Click += btn_ShowAllActivities_Click;
			// 
			// btn_DeleteSubprocess
			// 
			btn_DeleteSubprocess.Location = new Point(413, 295);
			btn_DeleteSubprocess.Name = "btn_DeleteSubprocess";
			btn_DeleteSubprocess.Size = new Size(144, 29);
			btn_DeleteSubprocess.TabIndex = 4;
			btn_DeleteSubprocess.Text = "Deletar seleção";
			btn_DeleteSubprocess.UseVisualStyleBackColor = true;
			btn_DeleteSubprocess.Click += btn_DeleteSubprocess_Click;
			// 
			// lbl_GroupFilter
			// 
			lbl_GroupFilter.AutoEllipsis = true;
			lbl_GroupFilter.AutoSize = true;
			lbl_GroupFilter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_GroupFilter.Location = new Point(151, 389);
			lbl_GroupFilter.MaximumSize = new Size(343, 29);
			lbl_GroupFilter.Name = "lbl_GroupFilter";
			lbl_GroupFilter.Size = new Size(74, 28);
			lbl_GroupFilter.TabIndex = 9;
			lbl_GroupFilter.Text = "TODAS";
			// 
			// btn_ImportActivityRel
			// 
			btn_ImportActivityRel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_ImportActivityRel.Location = new Point(711, 826);
			btn_ImportActivityRel.Name = "btn_ImportActivityRel";
			btn_ImportActivityRel.Size = new Size(93, 29);
			btn_ImportActivityRel.TabIndex = 39;
			btn_ImportActivityRel.Text = "Importar vínculos...";
			btn_ImportActivityRel.UseVisualStyleBackColor = true;
			btn_ImportActivityRel.Click += btn_ImportActivityRel_Click;
			// 
			// btn_ImportActivityElementRel
			// 
			btn_ImportActivityElementRel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_ImportActivityElementRel.Location = new Point(1248, 827);
			btn_ImportActivityElementRel.Name = "btn_ImportActivityElementRel";
			btn_ImportActivityElementRel.Size = new Size(93, 29);
			btn_ImportActivityElementRel.TabIndex = 45;
			btn_ImportActivityElementRel.Text = "Importar vínculos...";
			btn_ImportActivityElementRel.UseVisualStyleBackColor = true;
			btn_ImportActivityElementRel.Click += btn_ImportActivityElementRel_Click;
			// 
			// btn_ImportActivityAgent
			// 
			btn_ImportActivityAgent.Location = new Point(1249, 471);
			btn_ImportActivityAgent.Name = "btn_ImportActivityAgent";
			btn_ImportActivityAgent.Size = new Size(93, 29);
			btn_ImportActivityAgent.TabIndex = 33;
			btn_ImportActivityAgent.Text = "Importar vínculos...";
			btn_ImportActivityAgent.UseVisualStyleBackColor = true;
			btn_ImportActivityAgent.Click += btn_ImportActivityAgent_Click;
			// 
			// lbl_ActivitiesTotal
			// 
			lbl_ActivitiesTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			lbl_ActivitiesTotal.AutoSize = true;
			lbl_ActivitiesTotal.Location = new Point(21, 824);
			lbl_ActivitiesTotal.Name = "lbl_ActivitiesTotal";
			lbl_ActivitiesTotal.Size = new Size(45, 20);
			lbl_ActivitiesTotal.TabIndex = 12;
			lbl_ActivitiesTotal.Text = "Total:";
			// 
			// btn_ImportSectors
			// 
			btn_ImportSectors.Location = new Point(281, 295);
			btn_ImportSectors.Name = "btn_ImportSectors";
			btn_ImportSectors.Size = new Size(126, 29);
			btn_ImportSectors.TabIndex = 3;
			btn_ImportSectors.Text = "Importar .csv";
			btn_ImportSectors.UseVisualStyleBackColor = true;
			btn_ImportSectors.Click += btn_ImportSectors_Click;
			// 
			// btn_ExportActivity
			// 
			btn_ExportActivity.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_ExportActivity.Location = new Point(179, 827);
			btn_ExportActivity.Name = "btn_ExportActivity";
			btn_ExportActivity.Size = new Size(119, 29);
			btn_ExportActivity.TabIndex = 13;
			btn_ExportActivity.Text = "Exportar .csv";
			btn_ExportActivity.UseVisualStyleBackColor = true;
			btn_ExportActivity.Click += btn_ExportActivity_Click;
			// 
			// btn_ExportSubprocess
			// 
			btn_ExportSubprocess.Location = new Point(155, 295);
			btn_ExportSubprocess.Name = "btn_ExportSubprocess";
			btn_ExportSubprocess.Size = new Size(119, 29);
			btn_ExportSubprocess.TabIndex = 2;
			btn_ExportSubprocess.Text = "Exportar .csv";
			btn_ExportSubprocess.UseVisualStyleBackColor = true;
			btn_ExportSubprocess.Click += btn_ExportSubprocess_Click;
			// 
			// btn_ExportActivityActivity
			// 
			btn_ExportActivityActivity.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_ExportActivityActivity.Location = new Point(616, 826);
			btn_ExportActivityActivity.Name = "btn_ExportActivityActivity";
			btn_ExportActivityActivity.Size = new Size(91, 29);
			btn_ExportActivityActivity.TabIndex = 38;
			btn_ExportActivityActivity.Text = "Exportar .csv";
			btn_ExportActivityActivity.UseVisualStyleBackColor = true;
			btn_ExportActivityActivity.Click += btn_ExportActivityActivity_Click;
			// 
			// btn_ExportActivityElement
			// 
			btn_ExportActivityElement.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_ExportActivityElement.Location = new Point(1151, 827);
			btn_ExportActivityElement.Name = "btn_ExportActivityElement";
			btn_ExportActivityElement.Size = new Size(91, 29);
			btn_ExportActivityElement.TabIndex = 44;
			btn_ExportActivityElement.Text = "Exportar .csv";
			btn_ExportActivityElement.UseVisualStyleBackColor = true;
			btn_ExportActivityElement.Click += btn_ExportActivityElement_Click;
			// 
			// btn_ExportActivityAgent
			// 
			btn_ExportActivityAgent.Location = new Point(1152, 471);
			btn_ExportActivityAgent.Name = "btn_ExportActivityAgent";
			btn_ExportActivityAgent.Size = new Size(91, 29);
			btn_ExportActivityAgent.TabIndex = 32;
			btn_ExportActivityAgent.Text = "Exportar .csv";
			btn_ExportActivityAgent.UseVisualStyleBackColor = true;
			btn_ExportActivityAgent.Click += btn_ExportActivityAgent_Click;
			// 
			// dataGridView1
			// 
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridView1.AutoGenerateColumns = false;
			dataGridView1.BackgroundColor = SystemColors.ControlLight;
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Columns.AddRange(new DataGridViewColumn[] { subprocessIdDataGridViewTextBoxColumn1, codeDataGridViewTextBoxColumn4, nameDataGridViewTextBoxColumn4 });
			dataGridView1.DataSource = subprocessBindingSource1;
			dataGridView1.Location = new Point(618, 271);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.ReadOnly = true;
			dataGridView1.RowHeadersVisible = false;
			dataGridView1.RowHeadersWidth = 51;
			dataGridView1.RowTemplate.Height = 29;
			dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView1.Size = new Size(510, 194);
			dataGridView1.TabIndex = 27;
			// 
			// subprocessIdDataGridViewTextBoxColumn1
			// 
			subprocessIdDataGridViewTextBoxColumn1.DataPropertyName = "SubprocessId";
			subprocessIdDataGridViewTextBoxColumn1.HeaderText = "SubprocessId";
			subprocessIdDataGridViewTextBoxColumn1.MinimumWidth = 6;
			subprocessIdDataGridViewTextBoxColumn1.Name = "subprocessIdDataGridViewTextBoxColumn1";
			subprocessIdDataGridViewTextBoxColumn1.ReadOnly = true;
			subprocessIdDataGridViewTextBoxColumn1.Visible = false;
			subprocessIdDataGridViewTextBoxColumn1.Width = 125;
			// 
			// codeDataGridViewTextBoxColumn4
			// 
			codeDataGridViewTextBoxColumn4.DataPropertyName = "Code";
			codeDataGridViewTextBoxColumn4.HeaderText = "Código";
			codeDataGridViewTextBoxColumn4.MinimumWidth = 6;
			codeDataGridViewTextBoxColumn4.Name = "codeDataGridViewTextBoxColumn4";
			codeDataGridViewTextBoxColumn4.ReadOnly = true;
			codeDataGridViewTextBoxColumn4.Width = 80;
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
			// subprocessBindingSource1
			// 
			subprocessBindingSource1.DataSource = typeof(Model.Subprocess);
			// 
			// button1
			// 
			button1.Location = new Point(741, 471);
			button1.Name = "button1";
			button1.Size = new Size(190, 29);
			button1.TabIndex = 28;
			button1.Text = "Selecionar vínculos...";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// button2
			// 
			button2.Location = new Point(937, 471);
			button2.Name = "button2";
			button2.Size = new Size(191, 29);
			button2.TabIndex = 29;
			button2.Text = "Desvincular seleção";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// cb_Periodity
			// 
			cb_Periodity.FormattingEnabled = true;
			cb_Periodity.Location = new Point(1365, 135);
			cb_Periodity.Margin = new Padding(3, 4, 3, 4);
			cb_Periodity.Name = "cb_Periodity";
			cb_Periodity.Size = new Size(274, 28);
			cb_Periodity.TabIndex = 23;
			cb_Periodity.Leave += cb_Periodity_Leave;
			// 
			// btn_New
			// 
			btn_New.Location = new Point(491, 391);
			btn_New.Name = "btn_New";
			btn_New.Size = new Size(66, 29);
			btn_New.TabIndex = 10;
			btn_New.Text = "Novo";
			btn_New.UseVisualStyleBackColor = true;
			btn_New.Click += btn_New_Click;
			// 
			// btn_NewGroup
			// 
			btn_NewGroup.Location = new Point(490, 20);
			btn_NewGroup.Name = "btn_NewGroup";
			btn_NewGroup.Size = new Size(66, 29);
			btn_NewGroup.TabIndex = 0;
			btn_NewGroup.Text = "Novo";
			btn_NewGroup.UseVisualStyleBackColor = true;
			btn_NewGroup.Click += btn_NewGroup_Click;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(616, 248);
			label3.Margin = new Padding(0);
			label3.Name = "label3";
			label3.Size = new Size(93, 20);
			label3.TabIndex = 26;
			label3.Text = "Subprocesso";
			// 
			// Frm_Activity
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			AutoScroll = true;
			ClientSize = new Size(1696, 881);
			Controls.Add(label3);
			Controls.Add(btn_NewGroup);
			Controls.Add(btn_New);
			Controls.Add(cb_Periodity);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(dataGridView1);
			Controls.Add(btn_ExportActivityAgent);
			Controls.Add(btn_ExportActivityElement);
			Controls.Add(btn_ExportActivityActivity);
			Controls.Add(btn_ExportSubprocess);
			Controls.Add(btn_ExportActivity);
			Controls.Add(btn_ImportSectors);
			Controls.Add(lbl_ActivitiesTotal);
			Controls.Add(btn_ImportActivityAgent);
			Controls.Add(btn_ImportActivityElementRel);
			Controls.Add(btn_ImportActivityRel);
			Controls.Add(lbl_GroupFilter);
			Controls.Add(btn_DeleteSubprocess);
			Controls.Add(btn_ShowAllActivities);
			Controls.Add(btn_FilterActivities);
			Controls.Add(btn_SubprocessScreen);
			Controls.Add(lbl_Separator_Vertical);
			Controls.Add(btn_SaveDetails);
			Controls.Add(lbl_Duration);
			Controls.Add(lbl_Periodicity);
			Controls.Add(lbl_Competences);
			Controls.Add(lbl_Description);
			Controls.Add(cb_Duration);
			Controls.Add(cb_Periodicity1);
			Controls.Add(rtxtb_Competences);
			Controls.Add(rtxtb_Description);
			Controls.Add(lbl_ActivityName);
			Controls.Add(lbl_DetAtividadeDesc);
			Controls.Add(lbl_Title);
			Controls.Add(lbl_DetAtividade);
			Controls.Add(dg_Group);
			Controls.Add(dg_AgentRelationship);
			Controls.Add(btn_DeleteActivity);
			Controls.Add(btn_DeleteElement);
			Controls.Add(btn_DeleteAgent);
			Controls.Add(btn_DeleteActivRelation);
			Controls.Add(btn_AddElement);
			Controls.Add(btn_AddAgent);
			Controls.Add(btn_AddActivRelation);
			Controls.Add(lbl_Elements);
			Controls.Add(lbl_Agents);
			Controls.Add(lbl_ActivityRel);
			Controls.Add(dg_elementRelationship);
			Controls.Add(dg_activityRelationship);
			Controls.Add(dg_Activities);
			Controls.Add(btn_Importarcsv);
			Controls.Add(lbl_TituloAtividade);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "Frm_Activity";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "MAEA - Processo";
			Load += Frm_Atividades_Load;
			((System.ComponentModel.ISupportInitialize)dg_Activities).EndInit();
			((System.ComponentModel.ISupportInitialize)activityBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)dg_activityRelationship).EndInit();
			((System.ComponentModel.ISupportInitialize)relationshipViewModelBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)dg_elementRelationship).EndInit();
			((System.ComponentModel.ISupportInitialize)relationshipViewModelBindingSource1).EndInit();
			((System.ComponentModel.ISupportInitialize)dg_AgentRelationship).EndInit();
			((System.ComponentModel.ISupportInitialize)relationshipViewModelBindingSource2).EndInit();
			((System.ComponentModel.ISupportInitialize)dg_Group).EndInit();
			((System.ComponentModel.ISupportInitialize)subprocessBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			((System.ComponentModel.ISupportInitialize)subprocessBindingSource1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lbl_TituloAtividade;
		private Button btn_Importarcsv;
		private DataGridView dg_Activities;
		private DataGridView dg_activityRelationship;
		private DataGridView dg_elementRelationship;
		private Label lbl_ActivityRel;
		private Label lbl_Agents;
		private Label lbl_Elements;
		private Button btn_AddActivRelation;
		private Button btn_AddAgent;
		private Button btn_AddElement;
		private Button btn_DeleteActivRelation;
		private Button btn_DeleteAgent;
		private Button btn_DeleteElement;
		private Button btn_DeleteActivity;
		private DataGridViewTextBoxColumn idAtividadeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn periodicidadeDataGridViewTextBoxColumn;
		private DataGridView dg_AgentRelationship;
		private DataGridView dg_Group;
		private Label lbl_DetAtividade;
		private Label lbl_Title;
		private Label lbl_DetAtividadeDesc;
		private Label lbl_ActivityName;
		private DataGridViewTextBoxColumn idAtividadeDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn periodicidadeDataGridViewTextBoxColumn1;
		private RichTextBox rtxtb_Description;
		private RichTextBox rtxtb_Competences;
		private ComboBox cb_Periodicity1;
		private ComboBox cb_Duration;
		private Label lbl_Description;
		private Label lbl_Competences;
		private Label lbl_Periodicity;
		private Label lbl_Duration;
		private Button btn_SaveDetails;
		private Label lbl_Separator_Vertical;
		private DataGridViewTextBoxColumn codAtividadeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn nomeDaAtividadeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn descricaoDaAtividadeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn periodicidade1DataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn periodicidade2DataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn duracaoDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn competenciaExigidaDataGridViewTextBoxColumn;
		private BindingSource activityBindingSource;
		private BindingSource relationshipViewModelBindingSource;
		private BindingSource relationshipViewModelBindingSource1;
		private BindingSource relationshipViewModelBindingSource2;
		private BindingSource subprocessBindingSource;
		private Button btn_SubprocessScreen;
		private Button btn_FilterActivities;
		private Button btn_ShowAllActivities;
		private Button btn_DeleteSubprocess;
		private Label lbl_GroupFilter;
		private Button btn_ImportActivityRel;
		private Button btn_ImportActivityElementRel;
		private Button btn_ImportActivityAgent;
		private Label lbl_ActivitiesTotal;
		private Button btn_ImportSectors;
		private Button btn_ExportActivity;
		private Button btn_ExportSubprocess;
		private Button btn_ExportActivityActivity;
		private Button btn_ExportActivityElement;
		private Button btn_ExportActivityAgent;
		private DataGridView dataGridView1;
		private DataGridViewTextBoxColumn subprocessIdDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn4;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn4;
		private BindingSource subprocessBindingSource1;
		private Button button1;
		private Button button2;
		private ComboBox cb_Periodity;
		private Button btn_New;
		private Button btn_NewGroup;
		private DataGridViewTextBoxColumn activityIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn activityCodeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn activityNameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn activityDescriptionDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn periodicity1DataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn periodicity2DataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn requiredCompetenceDataGridViewTextBoxColumn;
		private Label label3;
		private DataGridViewTextBoxColumn relationshipIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn relationshipDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn relationshipIdDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn relationshipDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn relationshipIdDataGridViewTextBoxColumn2;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn2;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn2;
		private DataGridViewTextBoxColumn relationshipDataGridViewTextBoxColumn2;
		private DataGridViewTextBoxColumn subprocessIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn3;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn3;
	}
}