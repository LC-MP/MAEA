namespace MSCMD.Forms.OrganizationalDivision
{
	partial class Frm_AgentActivityRelationship
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
			lbl_Txt_Pessoa = new Label();
			lbl_NomeFunc = new Label();
			lbl_FuncaoCod = new Label();
			lbl_Funcao = new Label();
			btn_Salvar = new Button();
			dg_Activity = new DataGridView();
			activityIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			activityCodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			activityNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			activityDescriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			requiredCompetenceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			periodicity1DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			periodicity2DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			durationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			activityBindingSource = new BindingSource(components);
			btn_Close = new Button();
			label3 = new Label();
			btn_Clean = new Button();
			btn_Search = new Button();
			txt_Search = new TextBox();
			((System.ComponentModel.ISupportInitialize)dg_Activity).BeginInit();
			((System.ComponentModel.ISupportInitialize)activityBindingSource).BeginInit();
			SuspendLayout();
			// 
			// lbl_Txt_Pessoa
			// 
			lbl_Txt_Pessoa.Location = new Point(23, 117);
			lbl_Txt_Pessoa.Name = "lbl_Txt_Pessoa";
			lbl_Txt_Pessoa.Size = new Size(914, 32);
			lbl_Txt_Pessoa.TabIndex = 15;
			lbl_Txt_Pessoa.Text = "Selecione a atividade: (use CTRL para selecionar mais de uma linha, use SHIFT e clique em duas linhas para selecionar todas entre elas)";
			// 
			// lbl_NomeFunc
			// 
			lbl_NomeFunc.AutoSize = true;
			lbl_NomeFunc.Location = new Point(29, 71);
			lbl_NomeFunc.Name = "lbl_NomeFunc";
			lbl_NomeFunc.Size = new Size(120, 20);
			lbl_NomeFunc.TabIndex = 12;
			lbl_NomeFunc.Text = "Nome da função";
			// 
			// lbl_FuncaoCod
			// 
			lbl_FuncaoCod.AutoSize = true;
			lbl_FuncaoCod.Location = new Point(29, 51);
			lbl_FuncaoCod.Name = "lbl_FuncaoCod";
			lbl_FuncaoCod.Size = new Size(56, 20);
			lbl_FuncaoCod.TabIndex = 11;
			lbl_FuncaoCod.Text = "codigo";
			// 
			// lbl_Funcao
			// 
			lbl_Funcao.AutoSize = true;
			lbl_Funcao.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_Funcao.Location = new Point(23, 20);
			lbl_Funcao.Name = "lbl_Funcao";
			lbl_Funcao.Size = new Size(91, 32);
			lbl_Funcao.TabIndex = 10;
			lbl_Funcao.Text = "Função";
			// 
			// btn_Salvar
			// 
			btn_Salvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_Salvar.Location = new Point(699, 556);
			btn_Salvar.Name = "btn_Salvar";
			btn_Salvar.Size = new Size(128, 29);
			btn_Salvar.TabIndex = 9;
			btn_Salvar.Text = "Vincular";
			btn_Salvar.UseVisualStyleBackColor = true;
			btn_Salvar.Click += btn_Salvar_Click;
			// 
			// dg_Activity
			// 
			dg_Activity.AllowUserToAddRows = false;
			dg_Activity.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dg_Activity.AutoGenerateColumns = false;
			dg_Activity.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_Activity.Columns.AddRange(new DataGridViewColumn[] { activityIdDataGridViewTextBoxColumn, activityCodeDataGridViewTextBoxColumn, activityNameDataGridViewTextBoxColumn, activityDescriptionDataGridViewTextBoxColumn, requiredCompetenceDataGridViewTextBoxColumn, periodicity1DataGridViewTextBoxColumn, periodicity2DataGridViewTextBoxColumn, durationDataGridViewTextBoxColumn });
			dg_Activity.DataSource = activityBindingSource;
			dg_Activity.Location = new Point(29, 153);
			dg_Activity.Name = "dg_Activity";
			dg_Activity.RowHeadersVisible = false;
			dg_Activity.RowHeadersWidth = 51;
			dg_Activity.RowTemplate.Height = 29;
			dg_Activity.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_Activity.Size = new Size(907, 397);
			dg_Activity.TabIndex = 8;
			// 
			// activityIdDataGridViewTextBoxColumn
			// 
			activityIdDataGridViewTextBoxColumn.DataPropertyName = "ActivityId";
			activityIdDataGridViewTextBoxColumn.HeaderText = "Id";
			activityIdDataGridViewTextBoxColumn.MinimumWidth = 6;
			activityIdDataGridViewTextBoxColumn.Name = "activityIdDataGridViewTextBoxColumn";
			activityIdDataGridViewTextBoxColumn.Width = 50;
			// 
			// activityCodeDataGridViewTextBoxColumn
			// 
			activityCodeDataGridViewTextBoxColumn.DataPropertyName = "ActivityCode";
			activityCodeDataGridViewTextBoxColumn.HeaderText = "Código";
			activityCodeDataGridViewTextBoxColumn.MinimumWidth = 6;
			activityCodeDataGridViewTextBoxColumn.Name = "activityCodeDataGridViewTextBoxColumn";
			activityCodeDataGridViewTextBoxColumn.Width = 125;
			// 
			// activityNameDataGridViewTextBoxColumn
			// 
			activityNameDataGridViewTextBoxColumn.DataPropertyName = "ActivityName";
			activityNameDataGridViewTextBoxColumn.HeaderText = "Nome da Atividade";
			activityNameDataGridViewTextBoxColumn.MinimumWidth = 6;
			activityNameDataGridViewTextBoxColumn.Name = "activityNameDataGridViewTextBoxColumn";
			activityNameDataGridViewTextBoxColumn.Width = 125;
			// 
			// activityDescriptionDataGridViewTextBoxColumn
			// 
			activityDescriptionDataGridViewTextBoxColumn.DataPropertyName = "ActivityDescription";
			activityDescriptionDataGridViewTextBoxColumn.HeaderText = "Descrição";
			activityDescriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
			activityDescriptionDataGridViewTextBoxColumn.Name = "activityDescriptionDataGridViewTextBoxColumn";
			activityDescriptionDataGridViewTextBoxColumn.Width = 125;
			// 
			// requiredCompetenceDataGridViewTextBoxColumn
			// 
			requiredCompetenceDataGridViewTextBoxColumn.DataPropertyName = "RequiredCompetence";
			requiredCompetenceDataGridViewTextBoxColumn.HeaderText = "Competências requeridas";
			requiredCompetenceDataGridViewTextBoxColumn.MinimumWidth = 6;
			requiredCompetenceDataGridViewTextBoxColumn.Name = "requiredCompetenceDataGridViewTextBoxColumn";
			requiredCompetenceDataGridViewTextBoxColumn.Width = 125;
			// 
			// periodicity1DataGridViewTextBoxColumn
			// 
			periodicity1DataGridViewTextBoxColumn.DataPropertyName = "Periodicity1";
			periodicity1DataGridViewTextBoxColumn.HeaderText = "Periodicidade";
			periodicity1DataGridViewTextBoxColumn.MinimumWidth = 6;
			periodicity1DataGridViewTextBoxColumn.Name = "periodicity1DataGridViewTextBoxColumn";
			periodicity1DataGridViewTextBoxColumn.Width = 125;
			// 
			// periodicity2DataGridViewTextBoxColumn
			// 
			periodicity2DataGridViewTextBoxColumn.DataPropertyName = "Periodicity2";
			periodicity2DataGridViewTextBoxColumn.HeaderText = "Periodicidade";
			periodicity2DataGridViewTextBoxColumn.MinimumWidth = 6;
			periodicity2DataGridViewTextBoxColumn.Name = "periodicity2DataGridViewTextBoxColumn";
			periodicity2DataGridViewTextBoxColumn.Width = 125;
			// 
			// durationDataGridViewTextBoxColumn
			// 
			durationDataGridViewTextBoxColumn.DataPropertyName = "Duration";
			durationDataGridViewTextBoxColumn.HeaderText = "Duração";
			durationDataGridViewTextBoxColumn.MinimumWidth = 6;
			durationDataGridViewTextBoxColumn.Name = "durationDataGridViewTextBoxColumn";
			durationDataGridViewTextBoxColumn.Width = 125;
			// 
			// activityBindingSource
			// 
			activityBindingSource.DataSource = typeof(Model.Activity);
			// 
			// btn_Close
			// 
			btn_Close.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_Close.Location = new Point(837, 556);
			btn_Close.Name = "btn_Close";
			btn_Close.Size = new Size(101, 29);
			btn_Close.TabIndex = 37;
			btn_Close.Text = "Fechar";
			btn_Close.UseVisualStyleBackColor = true;
			btn_Close.Click += btn_Close_Click;
			// 
			// label3
			// 
			label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			label3.AutoSize = true;
			label3.Location = new Point(531, 42);
			label3.Name = "label3";
			label3.Size = new Size(196, 20);
			label3.TabIndex = 48;
			label3.Text = "Buscar por código ou nome:";
			// 
			// btn_Clean
			// 
			btn_Clean.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btn_Clean.Location = new Point(847, 66);
			btn_Clean.Margin = new Padding(3, 4, 3, 4);
			btn_Clean.Name = "btn_Clean";
			btn_Clean.Size = new Size(86, 31);
			btn_Clean.TabIndex = 47;
			btn_Clean.Text = "Limpar";
			btn_Clean.UseVisualStyleBackColor = true;
			btn_Clean.Click += btn_Clean_Click;
			// 
			// btn_Search
			// 
			btn_Search.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btn_Search.Location = new Point(767, 66);
			btn_Search.Margin = new Padding(3, 4, 3, 4);
			btn_Search.Name = "btn_Search";
			btn_Search.Size = new Size(73, 31);
			btn_Search.TabIndex = 46;
			btn_Search.Text = "Buscar";
			btn_Search.UseVisualStyleBackColor = true;
			btn_Search.Click += btn_Search_Click;
			// 
			// txt_Search
			// 
			txt_Search.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			txt_Search.BorderStyle = BorderStyle.FixedSingle;
			txt_Search.Location = new Point(531, 69);
			txt_Search.Margin = new Padding(3, 4, 3, 4);
			txt_Search.Name = "txt_Search";
			txt_Search.Size = new Size(229, 27);
			txt_Search.TabIndex = 45;
			txt_Search.KeyUp += txt_Search_KeyUp;
			// 
			// Frm_AgentActivityRelationship
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(955, 600);
			Controls.Add(label3);
			Controls.Add(btn_Clean);
			Controls.Add(btn_Search);
			Controls.Add(txt_Search);
			Controls.Add(btn_Close);
			Controls.Add(lbl_Txt_Pessoa);
			Controls.Add(lbl_NomeFunc);
			Controls.Add(lbl_FuncaoCod);
			Controls.Add(lbl_Funcao);
			Controls.Add(btn_Salvar);
			Controls.Add(dg_Activity);
			MinimumSize = new Size(800, 0);
			Name = "Frm_AgentActivityRelationship";
			Text = "Vincular Atividade";
			Load += Frm_AgentActivityRelationship_Load;
			((System.ComponentModel.ISupportInitialize)dg_Activity).EndInit();
			((System.ComponentModel.ISupportInitialize)activityBindingSource).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lbl_Txt_Pessoa;
		private Label lbl_NomeFunc;
		private Label lbl_FuncaoCod;
		private Label lbl_Funcao;
		private Button btn_Salvar;
		private DataGridView dg_Activity;
		private BindingSource activityBindingSource;
		private Button btn_Close;
		private DataGridViewTextBoxColumn activityIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn activityCodeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn activityNameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn activityDescriptionDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn requiredCompetenceDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn periodicity1DataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn periodicity2DataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
		private Label label3;
		private Button btn_Clean;
		private Button btn_Search;
		private TextBox txt_Search;
	}
}