namespace MSCMD.Forms.Activities
{
	partial class Frm_SubprocessActivity
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
			label1 = new Label();
			btn_Save = new Button();
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
			lbl_Name = new Label();
			lbl_Code = new Label();
			lbl_Subprocess = new Label();
			btn_Close = new Button();
			label3 = new Label();
			btn_Clean = new Button();
			btn_Search = new Button();
			txt_Search = new TextBox();
			((System.ComponentModel.ISupportInitialize)dg_Activities).BeginInit();
			((System.ComponentModel.ISupportInitialize)activityBindingSource).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(31, 125);
			label1.Name = "label1";
			label1.Size = new Size(912, 20);
			label1.TabIndex = 30;
			label1.Text = "Selecione as atividades: (use CTRL para selecionar mais de uma linha, use SHIFT e clique em duas linhas para selecionar todas entre elas)";
			// 
			// btn_Save
			// 
			btn_Save.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_Save.Location = new Point(775, 557);
			btn_Save.Name = "btn_Save";
			btn_Save.Size = new Size(119, 29);
			btn_Save.TabIndex = 29;
			btn_Save.Text = "Vincular";
			btn_Save.UseVisualStyleBackColor = true;
			btn_Save.Click += btn_Save_Click;
			// 
			// dg_Activities
			// 
			dg_Activities.AllowUserToAddRows = false;
			dg_Activities.AllowUserToDeleteRows = false;
			dg_Activities.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dg_Activities.AutoGenerateColumns = false;
			dg_Activities.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_Activities.Columns.AddRange(new DataGridViewColumn[] { activityIdDataGridViewTextBoxColumn, activityCodeDataGridViewTextBoxColumn, activityNameDataGridViewTextBoxColumn, activityDescriptionDataGridViewTextBoxColumn, periodicity1DataGridViewTextBoxColumn, periodicity2DataGridViewTextBoxColumn, durationDataGridViewTextBoxColumn, requiredCompetenceDataGridViewTextBoxColumn });
			dg_Activities.DataSource = activityBindingSource;
			dg_Activities.Location = new Point(29, 149);
			dg_Activities.Name = "dg_Activities";
			dg_Activities.ReadOnly = true;
			dg_Activities.RowHeadersVisible = false;
			dg_Activities.RowHeadersWidth = 51;
			dg_Activities.RowTemplate.Height = 29;
			dg_Activities.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_Activities.Size = new Size(971, 403);
			dg_Activities.TabIndex = 28;
			// 
			// activityIdDataGridViewTextBoxColumn
			// 
			activityIdDataGridViewTextBoxColumn.DataPropertyName = "ActivityId";
			activityIdDataGridViewTextBoxColumn.HeaderText = "Id";
			activityIdDataGridViewTextBoxColumn.MinimumWidth = 6;
			activityIdDataGridViewTextBoxColumn.Name = "activityIdDataGridViewTextBoxColumn";
			activityIdDataGridViewTextBoxColumn.ReadOnly = true;
			activityIdDataGridViewTextBoxColumn.Width = 50;
			// 
			// activityCodeDataGridViewTextBoxColumn
			// 
			activityCodeDataGridViewTextBoxColumn.DataPropertyName = "ActivityCode";
			activityCodeDataGridViewTextBoxColumn.HeaderText = "Código";
			activityCodeDataGridViewTextBoxColumn.MinimumWidth = 6;
			activityCodeDataGridViewTextBoxColumn.Name = "activityCodeDataGridViewTextBoxColumn";
			activityCodeDataGridViewTextBoxColumn.ReadOnly = true;
			activityCodeDataGridViewTextBoxColumn.Width = 125;
			// 
			// activityNameDataGridViewTextBoxColumn
			// 
			activityNameDataGridViewTextBoxColumn.DataPropertyName = "ActivityName";
			activityNameDataGridViewTextBoxColumn.HeaderText = "Nome";
			activityNameDataGridViewTextBoxColumn.MinimumWidth = 6;
			activityNameDataGridViewTextBoxColumn.Name = "activityNameDataGridViewTextBoxColumn";
			activityNameDataGridViewTextBoxColumn.ReadOnly = true;
			activityNameDataGridViewTextBoxColumn.Width = 300;
			// 
			// activityDescriptionDataGridViewTextBoxColumn
			// 
			activityDescriptionDataGridViewTextBoxColumn.DataPropertyName = "ActivityDescription";
			activityDescriptionDataGridViewTextBoxColumn.HeaderText = "Descrição";
			activityDescriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
			activityDescriptionDataGridViewTextBoxColumn.Name = "activityDescriptionDataGridViewTextBoxColumn";
			activityDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
			activityDescriptionDataGridViewTextBoxColumn.Width = 400;
			// 
			// periodicity1DataGridViewTextBoxColumn
			// 
			periodicity1DataGridViewTextBoxColumn.DataPropertyName = "Periodicity1";
			periodicity1DataGridViewTextBoxColumn.HeaderText = "Periodicidade";
			periodicity1DataGridViewTextBoxColumn.MinimumWidth = 6;
			periodicity1DataGridViewTextBoxColumn.Name = "periodicity1DataGridViewTextBoxColumn";
			periodicity1DataGridViewTextBoxColumn.ReadOnly = true;
			periodicity1DataGridViewTextBoxColumn.Width = 125;
			// 
			// periodicity2DataGridViewTextBoxColumn
			// 
			periodicity2DataGridViewTextBoxColumn.DataPropertyName = "Periodicity2";
			periodicity2DataGridViewTextBoxColumn.HeaderText = "Periodicidade 2";
			periodicity2DataGridViewTextBoxColumn.MinimumWidth = 6;
			periodicity2DataGridViewTextBoxColumn.Name = "periodicity2DataGridViewTextBoxColumn";
			periodicity2DataGridViewTextBoxColumn.ReadOnly = true;
			periodicity2DataGridViewTextBoxColumn.Width = 125;
			// 
			// durationDataGridViewTextBoxColumn
			// 
			durationDataGridViewTextBoxColumn.DataPropertyName = "Duration";
			durationDataGridViewTextBoxColumn.HeaderText = "Duração";
			durationDataGridViewTextBoxColumn.MinimumWidth = 6;
			durationDataGridViewTextBoxColumn.Name = "durationDataGridViewTextBoxColumn";
			durationDataGridViewTextBoxColumn.ReadOnly = true;
			durationDataGridViewTextBoxColumn.Width = 125;
			// 
			// requiredCompetenceDataGridViewTextBoxColumn
			// 
			requiredCompetenceDataGridViewTextBoxColumn.DataPropertyName = "RequiredCompetence";
			requiredCompetenceDataGridViewTextBoxColumn.HeaderText = "Competências";
			requiredCompetenceDataGridViewTextBoxColumn.MinimumWidth = 6;
			requiredCompetenceDataGridViewTextBoxColumn.Name = "requiredCompetenceDataGridViewTextBoxColumn";
			requiredCompetenceDataGridViewTextBoxColumn.ReadOnly = true;
			requiredCompetenceDataGridViewTextBoxColumn.Width = 300;
			// 
			// activityBindingSource
			// 
			activityBindingSource.DataSource = typeof(Model.Activity);
			// 
			// lbl_Name
			// 
			lbl_Name.AutoSize = true;
			lbl_Name.Location = new Point(31, 79);
			lbl_Name.Name = "lbl_Name";
			lbl_Name.Size = new Size(137, 20);
			lbl_Name.TabIndex = 27;
			lbl_Name.Text = "Nome da atividade";
			// 
			// lbl_Code
			// 
			lbl_Code.AutoSize = true;
			lbl_Code.Location = new Point(29, 51);
			lbl_Code.Name = "lbl_Code";
			lbl_Code.Size = new Size(56, 20);
			lbl_Code.TabIndex = 26;
			lbl_Code.Text = "codigo";
			// 
			// lbl_Subprocess
			// 
			lbl_Subprocess.AutoSize = true;
			lbl_Subprocess.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_Subprocess.Location = new Point(25, 15);
			lbl_Subprocess.Name = "lbl_Subprocess";
			lbl_Subprocess.Size = new Size(149, 32);
			lbl_Subprocess.TabIndex = 25;
			lbl_Subprocess.Text = "Subprocesso";
			// 
			// btn_Close
			// 
			btn_Close.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_Close.Location = new Point(901, 557);
			btn_Close.Name = "btn_Close";
			btn_Close.Size = new Size(101, 29);
			btn_Close.TabIndex = 31;
			btn_Close.Text = "Fechar";
			btn_Close.UseVisualStyleBackColor = true;
			btn_Close.Click += btn_Close_Click;
			// 
			// label3
			// 
			label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			label3.AutoSize = true;
			label3.Location = new Point(596, 67);
			label3.Name = "label3";
			label3.Size = new Size(196, 20);
			label3.TabIndex = 44;
			label3.Text = "Buscar por código ou nome:";
			// 
			// btn_Clean
			// 
			btn_Clean.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btn_Clean.Location = new Point(912, 91);
			btn_Clean.Margin = new Padding(3, 4, 3, 4);
			btn_Clean.Name = "btn_Clean";
			btn_Clean.Size = new Size(86, 31);
			btn_Clean.TabIndex = 43;
			btn_Clean.Text = "Limpar";
			btn_Clean.UseVisualStyleBackColor = true;
			btn_Clean.Click += btn_Clean_Click;
			// 
			// btn_Search
			// 
			btn_Search.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btn_Search.Location = new Point(832, 91);
			btn_Search.Margin = new Padding(3, 4, 3, 4);
			btn_Search.Name = "btn_Search";
			btn_Search.Size = new Size(73, 31);
			btn_Search.TabIndex = 42;
			btn_Search.Text = "Buscar";
			btn_Search.UseVisualStyleBackColor = true;
			btn_Search.Click += btn_Search_Click;
			// 
			// txt_Search
			// 
			txt_Search.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			txt_Search.BorderStyle = BorderStyle.FixedSingle;
			txt_Search.Location = new Point(596, 94);
			txt_Search.Margin = new Padding(3, 4, 3, 4);
			txt_Search.Name = "txt_Search";
			txt_Search.Size = new Size(229, 27);
			txt_Search.TabIndex = 41;
			txt_Search.KeyUp += txt_Search_KeyUp;
			// 
			// Frm_SubprocessActivity
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1026, 600);
			Controls.Add(label3);
			Controls.Add(btn_Clean);
			Controls.Add(btn_Search);
			Controls.Add(txt_Search);
			Controls.Add(btn_Close);
			Controls.Add(label1);
			Controls.Add(btn_Save);
			Controls.Add(dg_Activities);
			Controls.Add(lbl_Name);
			Controls.Add(lbl_Code);
			Controls.Add(lbl_Subprocess);
			MinimumSize = new Size(800, 0);
			Name = "Frm_SubprocessActivity";
			Text = "Vincular grupo de atividades";
			Load += Frm_SubprocessActivity_Load;
			((System.ComponentModel.ISupportInitialize)dg_Activities).EndInit();
			((System.ComponentModel.ISupportInitialize)activityBindingSource).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Button btn_Save;
		private DataGridView dg_Activities;
		private BindingSource activityBindingSource;
		private Label lbl_Name;
		private Label lbl_Code;
		private Label lbl_Subprocess;
		private Button btn_Close;
		private DataGridViewTextBoxColumn activityIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn activityCodeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn activityNameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn activityDescriptionDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn periodicity1DataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn periodicity2DataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn requiredCompetenceDataGridViewTextBoxColumn;
		private Label label3;
		private Button btn_Clean;
		private Button btn_Search;
		private TextBox txt_Search;
	}
}