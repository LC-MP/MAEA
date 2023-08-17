namespace MSCMD.Forms
{
	partial class Frm_ActivityActivityRelationship
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
			dg_Activity = new DataGridView();
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
			lbl_Funcao = new Label();
			cb_Relation = new ComboBox();
			label2 = new Label();
			btn_Close = new Button();
			txt_Search = new TextBox();
			btn_Search = new Button();
			btn_Clean = new Button();
			label3 = new Label();
			((System.ComponentModel.ISupportInitialize)dg_Activity).BeginInit();
			((System.ComponentModel.ISupportInitialize)activityBindingSource).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(31, 113);
			label1.Name = "label1";
			label1.Size = new Size(65, 20);
			label1.TabIndex = 24;
			label1.Text = "Relação:";
			// 
			// btn_Save
			// 
			btn_Save.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_Save.Location = new Point(779, 557);
			btn_Save.Name = "btn_Save";
			btn_Save.Size = new Size(131, 29);
			btn_Save.TabIndex = 23;
			btn_Save.Text = "Vincular";
			btn_Save.UseVisualStyleBackColor = true;
			btn_Save.Click += btn_Save_Click;
			// 
			// dg_Activity
			// 
			dg_Activity.AllowUserToAddRows = false;
			dg_Activity.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dg_Activity.AutoGenerateColumns = false;
			dg_Activity.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_Activity.Columns.AddRange(new DataGridViewColumn[] { activityIdDataGridViewTextBoxColumn, activityCodeDataGridViewTextBoxColumn, activityNameDataGridViewTextBoxColumn, activityDescriptionDataGridViewTextBoxColumn, periodicity1DataGridViewTextBoxColumn, periodicity2DataGridViewTextBoxColumn, durationDataGridViewTextBoxColumn, requiredCompetenceDataGridViewTextBoxColumn });
			dg_Activity.DataSource = activityBindingSource;
			dg_Activity.Location = new Point(31, 215);
			dg_Activity.Name = "dg_Activity";
			dg_Activity.ReadOnly = true;
			dg_Activity.RowHeadersVisible = false;
			dg_Activity.RowHeadersWidth = 51;
			dg_Activity.RowTemplate.Height = 29;
			dg_Activity.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_Activity.Size = new Size(985, 336);
			dg_Activity.TabIndex = 22;
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
			activityNameDataGridViewTextBoxColumn.Width = 430;
			// 
			// activityDescriptionDataGridViewTextBoxColumn
			// 
			activityDescriptionDataGridViewTextBoxColumn.DataPropertyName = "ActivityDescription";
			activityDescriptionDataGridViewTextBoxColumn.HeaderText = "Descrição";
			activityDescriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
			activityDescriptionDataGridViewTextBoxColumn.Name = "activityDescriptionDataGridViewTextBoxColumn";
			activityDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
			activityDescriptionDataGridViewTextBoxColumn.Width = 300;
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
			lbl_Name.TabIndex = 21;
			lbl_Name.Text = "Nome da atividade";
			// 
			// lbl_Code
			// 
			lbl_Code.AutoSize = true;
			lbl_Code.Location = new Point(29, 51);
			lbl_Code.Name = "lbl_Code";
			lbl_Code.Size = new Size(56, 20);
			lbl_Code.TabIndex = 20;
			lbl_Code.Text = "codigo";
			// 
			// lbl_Funcao
			// 
			lbl_Funcao.AutoSize = true;
			lbl_Funcao.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_Funcao.Location = new Point(25, 15);
			lbl_Funcao.Name = "lbl_Funcao";
			lbl_Funcao.Size = new Size(114, 32);
			lbl_Funcao.TabIndex = 19;
			lbl_Funcao.Text = "Atividade";
			// 
			// cb_Relation
			// 
			cb_Relation.DropDownStyle = ComboBoxStyle.DropDownList;
			cb_Relation.FormattingEnabled = true;
			cb_Relation.Location = new Point(31, 135);
			cb_Relation.Name = "cb_Relation";
			cb_Relation.Size = new Size(287, 28);
			cb_Relation.TabIndex = 25;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(29, 192);
			label2.Name = "label2";
			label2.Size = new Size(982, 20);
			label2.TabIndex = 26;
			label2.Text = "Selecione a atividade relacionada: (use CTRL para selecionar mais de uma linha, use SHIFT e clique em duas linhas para selecionar todas entre elas)";
			// 
			// btn_Close
			// 
			btn_Close.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_Close.Location = new Point(915, 557);
			btn_Close.Name = "btn_Close";
			btn_Close.Size = new Size(101, 29);
			btn_Close.TabIndex = 32;
			btn_Close.Text = "Fechar";
			btn_Close.UseVisualStyleBackColor = true;
			btn_Close.Click += btn_Close_Click;
			// 
			// txt_Search
			// 
			txt_Search.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			txt_Search.BorderStyle = BorderStyle.FixedSingle;
			txt_Search.Location = new Point(614, 138);
			txt_Search.Margin = new Padding(3, 4, 3, 4);
			txt_Search.Name = "txt_Search";
			txt_Search.Size = new Size(229, 27);
			txt_Search.TabIndex = 33;
			txt_Search.KeyUp += txt_Search_KeyUp;
			// 
			// btn_Search
			// 
			btn_Search.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btn_Search.Location = new Point(850, 135);
			btn_Search.Margin = new Padding(3, 4, 3, 4);
			btn_Search.Name = "btn_Search";
			btn_Search.Size = new Size(73, 31);
			btn_Search.TabIndex = 34;
			btn_Search.Text = "Buscar";
			btn_Search.UseVisualStyleBackColor = true;
			btn_Search.Click += btn_Search_Click;
			// 
			// btn_Clean
			// 
			btn_Clean.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btn_Clean.Location = new Point(930, 135);
			btn_Clean.Margin = new Padding(3, 4, 3, 4);
			btn_Clean.Name = "btn_Clean";
			btn_Clean.Size = new Size(86, 31);
			btn_Clean.TabIndex = 35;
			btn_Clean.Text = "Limpar";
			btn_Clean.UseVisualStyleBackColor = true;
			btn_Clean.Click += btn_Clean_Click;
			// 
			// label3
			// 
			label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			label3.AutoSize = true;
			label3.Location = new Point(614, 111);
			label3.Name = "label3";
			label3.Size = new Size(196, 20);
			label3.TabIndex = 36;
			label3.Text = "Buscar por código ou nome:";
			// 
			// Frm_ActivityActivityRelationship
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1041, 600);
			Controls.Add(label3);
			Controls.Add(btn_Clean);
			Controls.Add(btn_Search);
			Controls.Add(txt_Search);
			Controls.Add(btn_Close);
			Controls.Add(label2);
			Controls.Add(cb_Relation);
			Controls.Add(label1);
			Controls.Add(btn_Save);
			Controls.Add(dg_Activity);
			Controls.Add(lbl_Name);
			Controls.Add(lbl_Code);
			Controls.Add(lbl_Funcao);
			MinimumSize = new Size(800, 0);
			Name = "Frm_ActivityActivityRelationship";
			Text = "Vincular Atividade";
			Load += Frm_ActivityActivityRelationship_Load;
			((System.ComponentModel.ISupportInitialize)dg_Activity).EndInit();
			((System.ComponentModel.ISupportInitialize)activityBindingSource).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Button btn_Save;
		private DataGridView dg_Activity;
		private Label lbl_Name;
		private Label lbl_Code;
		private Label lbl_Funcao;
		private ComboBox cb_Relation;
		private Label label2;
		private BindingSource activityBindingSource;
		private Button btn_Close;
		private DataGridViewTextBoxColumn activityIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn activityCodeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn activityNameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn activityDescriptionDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn periodicity1DataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn periodicity2DataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn requiredCompetenceDataGridViewTextBoxColumn;
		private TextBox txt_Search;
		private Button btn_Search;
		private Button btn_Clean;
		private Label label3;
	}
}