namespace MSCMD.Forms.Activities
{
	partial class Frm_Subprocess
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
			dg_Subprocesses = new DataGridView();
			subprocessIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			codeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			subprocessBindingSource = new BindingSource(components);
			label1 = new Label();
			label2 = new Label();
			dg_Activities = new DataGridView();
			activityBindingSource = new BindingSource(components);
			btn_AddActivity = new Button();
			lbl_Separator_Vertical = new Label();
			btn_SaveSubprocesses = new Button();
			lbl_SubprocessName = new Label();
			btn_DeleteSubprocess = new Button();
			btn_DeleteActivity = new Button();
			activityIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			activityCodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			activityNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			activityDescriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			periodicity1DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			periodicity2DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			durationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			requiredCompetenceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)dg_Subprocesses).BeginInit();
			((System.ComponentModel.ISupportInitialize)subprocessBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)dg_Activities).BeginInit();
			((System.ComponentModel.ISupportInitialize)activityBindingSource).BeginInit();
			SuspendLayout();
			// 
			// dg_Subprocesses
			// 
			dg_Subprocesses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			dg_Subprocesses.AutoGenerateColumns = false;
			dg_Subprocesses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_Subprocesses.Columns.AddRange(new DataGridViewColumn[] { subprocessIdDataGridViewTextBoxColumn, codeDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn });
			dg_Subprocesses.DataSource = subprocessBindingSource;
			dg_Subprocesses.Location = new Point(33, 74);
			dg_Subprocesses.Margin = new Padding(3, 2, 3, 2);
			dg_Subprocesses.MultiSelect = false;
			dg_Subprocesses.Name = "dg_Subprocesses";
			dg_Subprocesses.RowHeadersVisible = false;
			dg_Subprocesses.RowHeadersWidth = 51;
			dg_Subprocesses.RowTemplate.Height = 29;
			dg_Subprocesses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_Subprocesses.Size = new Size(464, 340);
			dg_Subprocesses.TabIndex = 0;
			dg_Subprocesses.CellClick += dg_Subprocesses_CellClick;
			dg_Subprocesses.CellEndEdit += dg_Subprocesses_CellEndEdit;
			// 
			// subprocessIdDataGridViewTextBoxColumn
			// 
			subprocessIdDataGridViewTextBoxColumn.DataPropertyName = "SubprocessId";
			subprocessIdDataGridViewTextBoxColumn.HeaderText = "Id";
			subprocessIdDataGridViewTextBoxColumn.MinimumWidth = 6;
			subprocessIdDataGridViewTextBoxColumn.Name = "subprocessIdDataGridViewTextBoxColumn";
			subprocessIdDataGridViewTextBoxColumn.Visible = false;
			subprocessIdDataGridViewTextBoxColumn.Width = 50;
			// 
			// codeDataGridViewTextBoxColumn
			// 
			codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
			codeDataGridViewTextBoxColumn.HeaderText = "Código";
			codeDataGridViewTextBoxColumn.MinimumWidth = 6;
			codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
			codeDataGridViewTextBoxColumn.Width = 80;
			// 
			// nameDataGridViewTextBoxColumn
			// 
			nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
			nameDataGridViewTextBoxColumn.HeaderText = "Nome*";
			nameDataGridViewTextBoxColumn.MinimumWidth = 6;
			nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			nameDataGridViewTextBoxColumn.Width = 420;
			// 
			// subprocessBindingSource
			// 
			subprocessBindingSource.DataSource = typeof(Model.Subprocess);
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(33, 30);
			label1.Name = "label1";
			label1.Size = new Size(127, 25);
			label1.TabIndex = 1;
			label1.Text = "Subprocessos";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
			label2.Location = new Point(570, 56);
			label2.Name = "label2";
			label2.Size = new Size(152, 15);
			label2.TabIndex = 2;
			label2.Text = "Atividades do Subprocesso:";
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
			dg_Activities.Location = new Point(570, 74);
			dg_Activities.Margin = new Padding(3, 2, 3, 2);
			dg_Activities.Name = "dg_Activities";
			dg_Activities.ReadOnly = true;
			dg_Activities.RowHeadersVisible = false;
			dg_Activities.RowHeadersWidth = 51;
			dg_Activities.RowTemplate.Height = 29;
			dg_Activities.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_Activities.Size = new Size(524, 340);
			dg_Activities.TabIndex = 3;
			// 
			// activityBindingSource
			// 
			activityBindingSource.DataSource = typeof(Model.Activity);
			// 
			// btn_AddActivity
			// 
			btn_AddActivity.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_AddActivity.Location = new Point(782, 418);
			btn_AddActivity.Margin = new Padding(3, 2, 3, 2);
			btn_AddActivity.Name = "btn_AddActivity";
			btn_AddActivity.Size = new Size(149, 22);
			btn_AddActivity.TabIndex = 4;
			btn_AddActivity.Text = "Selecionar vínculos...";
			btn_AddActivity.UseVisualStyleBackColor = true;
			btn_AddActivity.Click += btn_AddActivity_Click;
			// 
			// lbl_Separator_Vertical
			// 
			lbl_Separator_Vertical.BorderStyle = BorderStyle.Fixed3D;
			lbl_Separator_Vertical.Location = new Point(535, 18);
			lbl_Separator_Vertical.Name = "lbl_Separator_Vertical";
			lbl_Separator_Vertical.Size = new Size(2, 428);
			lbl_Separator_Vertical.TabIndex = 36;
			// 
			// btn_SaveSubprocesses
			// 
			btn_SaveSubprocesses.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_SaveSubprocesses.Location = new Point(975, 6);
			btn_SaveSubprocesses.Margin = new Padding(3, 2, 3, 2);
			btn_SaveSubprocesses.Name = "btn_SaveSubprocesses";
			btn_SaveSubprocesses.Size = new Size(131, 22);
			btn_SaveSubprocesses.TabIndex = 37;
			btn_SaveSubprocesses.Text = "Salvar alterações";
			btn_SaveSubprocesses.UseVisualStyleBackColor = true;
			btn_SaveSubprocesses.Click += btn_SaveSubprocesses_Click;
			// 
			// lbl_SubprocessName
			// 
			lbl_SubprocessName.AutoSize = true;
			lbl_SubprocessName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_SubprocessName.Location = new Point(570, 31);
			lbl_SubprocessName.Name = "lbl_SubprocessName";
			lbl_SubprocessName.Size = new Size(52, 21);
			lbl_SubprocessName.TabIndex = 38;
			lbl_SubprocessName.Text = "label3";
			// 
			// btn_DeleteSubprocess
			// 
			btn_DeleteSubprocess.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_DeleteSubprocess.Location = new Point(367, 418);
			btn_DeleteSubprocess.Margin = new Padding(3, 2, 3, 2);
			btn_DeleteSubprocess.Name = "btn_DeleteSubprocess";
			btn_DeleteSubprocess.Size = new Size(130, 22);
			btn_DeleteSubprocess.TabIndex = 39;
			btn_DeleteSubprocess.Text = "Deletar seleção";
			btn_DeleteSubprocess.UseVisualStyleBackColor = true;
			btn_DeleteSubprocess.Click += btn_DeleteSubprocess_Click;
			// 
			// btn_DeleteActivity
			// 
			btn_DeleteActivity.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_DeleteActivity.Location = new Point(936, 418);
			btn_DeleteActivity.Margin = new Padding(3, 2, 3, 2);
			btn_DeleteActivity.Name = "btn_DeleteActivity";
			btn_DeleteActivity.Size = new Size(158, 22);
			btn_DeleteActivity.TabIndex = 40;
			btn_DeleteActivity.Text = "Desvincular seleção";
			btn_DeleteActivity.UseVisualStyleBackColor = true;
			btn_DeleteActivity.Click += btn_DeleteActivity_Click;
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
			activityCodeDataGridViewTextBoxColumn.Width = 80;
			// 
			// activityNameDataGridViewTextBoxColumn
			// 
			activityNameDataGridViewTextBoxColumn.DataPropertyName = "ActivityName";
			activityNameDataGridViewTextBoxColumn.HeaderText = "Nome da Atividade";
			activityNameDataGridViewTextBoxColumn.MinimumWidth = 6;
			activityNameDataGridViewTextBoxColumn.Name = "activityNameDataGridViewTextBoxColumn";
			activityNameDataGridViewTextBoxColumn.ReadOnly = true;
			activityNameDataGridViewTextBoxColumn.Width = 350;
			// 
			// activityDescriptionDataGridViewTextBoxColumn
			// 
			activityDescriptionDataGridViewTextBoxColumn.DataPropertyName = "ActivityDescription";
			activityDescriptionDataGridViewTextBoxColumn.HeaderText = "ActivityDescription";
			activityDescriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
			activityDescriptionDataGridViewTextBoxColumn.Name = "activityDescriptionDataGridViewTextBoxColumn";
			activityDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
			activityDescriptionDataGridViewTextBoxColumn.Visible = false;
			activityDescriptionDataGridViewTextBoxColumn.Width = 125;
			// 
			// periodicity1DataGridViewTextBoxColumn
			// 
			periodicity1DataGridViewTextBoxColumn.DataPropertyName = "Periodicity1";
			periodicity1DataGridViewTextBoxColumn.HeaderText = "Periodicity1";
			periodicity1DataGridViewTextBoxColumn.MinimumWidth = 6;
			periodicity1DataGridViewTextBoxColumn.Name = "periodicity1DataGridViewTextBoxColumn";
			periodicity1DataGridViewTextBoxColumn.ReadOnly = true;
			periodicity1DataGridViewTextBoxColumn.Visible = false;
			periodicity1DataGridViewTextBoxColumn.Width = 125;
			// 
			// periodicity2DataGridViewTextBoxColumn
			// 
			periodicity2DataGridViewTextBoxColumn.DataPropertyName = "Periodicity2";
			periodicity2DataGridViewTextBoxColumn.HeaderText = "Periodicity2";
			periodicity2DataGridViewTextBoxColumn.MinimumWidth = 6;
			periodicity2DataGridViewTextBoxColumn.Name = "periodicity2DataGridViewTextBoxColumn";
			periodicity2DataGridViewTextBoxColumn.ReadOnly = true;
			periodicity2DataGridViewTextBoxColumn.Visible = false;
			periodicity2DataGridViewTextBoxColumn.Width = 125;
			// 
			// durationDataGridViewTextBoxColumn
			// 
			durationDataGridViewTextBoxColumn.DataPropertyName = "Duration";
			durationDataGridViewTextBoxColumn.HeaderText = "Duration";
			durationDataGridViewTextBoxColumn.MinimumWidth = 6;
			durationDataGridViewTextBoxColumn.Name = "durationDataGridViewTextBoxColumn";
			durationDataGridViewTextBoxColumn.ReadOnly = true;
			durationDataGridViewTextBoxColumn.Visible = false;
			durationDataGridViewTextBoxColumn.Width = 125;
			// 
			// requiredCompetenceDataGridViewTextBoxColumn
			// 
			requiredCompetenceDataGridViewTextBoxColumn.DataPropertyName = "RequiredCompetence";
			requiredCompetenceDataGridViewTextBoxColumn.HeaderText = "RequiredCompetence";
			requiredCompetenceDataGridViewTextBoxColumn.MinimumWidth = 6;
			requiredCompetenceDataGridViewTextBoxColumn.Name = "requiredCompetenceDataGridViewTextBoxColumn";
			requiredCompetenceDataGridViewTextBoxColumn.ReadOnly = true;
			requiredCompetenceDataGridViewTextBoxColumn.Visible = false;
			requiredCompetenceDataGridViewTextBoxColumn.Width = 125;
			// 
			// Frm_Subprocess
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1115, 452);
			Controls.Add(btn_DeleteActivity);
			Controls.Add(btn_DeleteSubprocess);
			Controls.Add(lbl_SubprocessName);
			Controls.Add(btn_SaveSubprocesses);
			Controls.Add(lbl_Separator_Vertical);
			Controls.Add(btn_AddActivity);
			Controls.Add(dg_Activities);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(dg_Subprocesses);
			Margin = new Padding(3, 2, 3, 2);
			Name = "Frm_Subprocess";
			Text = "Subprocessos";
			Load += Frm_Subprocess_Load;
			((System.ComponentModel.ISupportInitialize)dg_Subprocesses).EndInit();
			((System.ComponentModel.ISupportInitialize)subprocessBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)dg_Activities).EndInit();
			((System.ComponentModel.ISupportInitialize)activityBindingSource).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView dg_Subprocesses;
		private BindingSource subprocessBindingSource;
		private Label label1;
		private Label label2;
		private DataGridView dg_Activities;
		private BindingSource activityBindingSource;
		private Button btn_AddActivity;
		private Label lbl_Separator_Vertical;
		private Button btn_SaveSubprocesses;
		private Label lbl_SubprocessName;
		private Button btn_DeleteSubprocess;
		private Button btn_DeleteActivity;
		private DataGridViewTextBoxColumn subprocessIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn activityIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn activityCodeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn activityNameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn activityDescriptionDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn periodicity1DataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn periodicity2DataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn requiredCompetenceDataGridViewTextBoxColumn;
	}
}