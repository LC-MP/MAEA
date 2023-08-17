namespace MSCMD.Forms
{
	partial class Frm_ElementActivityRelationship
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
			btn_Vincular = new Button();
			dg_Atividades = new DataGridView();
			activityIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			activityCodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			activityNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			activityDescriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			periodicity1DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			periodicity2DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			durationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			requiredCompetenceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			activityBindingSource = new BindingSource(components);
			lbl_Relacao = new Label();
			cb_Relacao = new ComboBox();
			lbl_NomeElemento = new Label();
			lbl_Codigo = new Label();
			label1 = new Label();
			label2 = new Label();
			btn_Close = new Button();
			label3 = new Label();
			btn_Clean = new Button();
			btn_Search = new Button();
			txt_Search = new TextBox();
			((System.ComponentModel.ISupportInitialize)dg_Atividades).BeginInit();
			((System.ComponentModel.ISupportInitialize)activityBindingSource).BeginInit();
			SuspendLayout();
			// 
			// btn_Vincular
			// 
			btn_Vincular.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_Vincular.Location = new Point(723, 556);
			btn_Vincular.Margin = new Padding(3, 4, 3, 4);
			btn_Vincular.Name = "btn_Vincular";
			btn_Vincular.Size = new Size(127, 31);
			btn_Vincular.TabIndex = 13;
			btn_Vincular.Text = "Vincular";
			btn_Vincular.UseVisualStyleBackColor = true;
			btn_Vincular.Click += btn_Vincular_Click;
			// 
			// dg_Atividades
			// 
			dg_Atividades.AllowUserToAddRows = false;
			dg_Atividades.AllowUserToDeleteRows = false;
			dg_Atividades.AllowUserToResizeRows = false;
			dg_Atividades.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dg_Atividades.AutoGenerateColumns = false;
			dg_Atividades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_Atividades.Columns.AddRange(new DataGridViewColumn[] { activityIdDataGridViewTextBoxColumn, activityCodeDataGridViewTextBoxColumn, activityNameDataGridViewTextBoxColumn, activityDescriptionDataGridViewTextBoxColumn, periodicity1DataGridViewTextBoxColumn, periodicity2DataGridViewTextBoxColumn, durationDataGridViewTextBoxColumn, requiredCompetenceDataGridViewTextBoxColumn });
			dg_Atividades.DataSource = activityBindingSource;
			dg_Atividades.Location = new Point(29, 205);
			dg_Atividades.Margin = new Padding(3, 4, 3, 4);
			dg_Atividades.Name = "dg_Atividades";
			dg_Atividades.ReadOnly = true;
			dg_Atividades.RowHeadersVisible = false;
			dg_Atividades.RowHeadersWidth = 51;
			dg_Atividades.RowTemplate.Height = 25;
			dg_Atividades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_Atividades.Size = new Size(927, 343);
			dg_Atividades.TabIndex = 12;
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
			activityNameDataGridViewTextBoxColumn.HeaderText = "Nome da atividade";
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
			activityDescriptionDataGridViewTextBoxColumn.Width = 300;
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
			// lbl_Relacao
			// 
			lbl_Relacao.AutoSize = true;
			lbl_Relacao.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_Relacao.Location = new Point(27, 99);
			lbl_Relacao.Name = "lbl_Relacao";
			lbl_Relacao.Size = new Size(160, 23);
			lbl_Relacao.TabIndex = 11;
			lbl_Relacao.Text = "Selecione a relação:";
			// 
			// cb_Relacao
			// 
			cb_Relacao.DropDownStyle = ComboBoxStyle.DropDownList;
			cb_Relacao.FormattingEnabled = true;
			cb_Relacao.Location = new Point(29, 125);
			cb_Relacao.Margin = new Padding(3, 4, 3, 4);
			cb_Relacao.Name = "cb_Relacao";
			cb_Relacao.Size = new Size(221, 28);
			cb_Relacao.TabIndex = 10;
			cb_Relacao.SelectedIndexChanged += cb_Relacao_SelectedIndexChanged;
			// 
			// lbl_NomeElemento
			// 
			lbl_NomeElemento.AutoSize = true;
			lbl_NomeElemento.Location = new Point(29, 71);
			lbl_NomeElemento.Name = "lbl_NomeElemento";
			lbl_NomeElemento.Size = new Size(139, 20);
			lbl_NomeElemento.TabIndex = 9;
			lbl_NomeElemento.Text = "Nome do Elemento";
			// 
			// lbl_Codigo
			// 
			lbl_Codigo.AutoSize = true;
			lbl_Codigo.Location = new Point(29, 51);
			lbl_Codigo.Name = "lbl_Codigo";
			lbl_Codigo.Size = new Size(61, 20);
			lbl_Codigo.TabIndex = 8;
			lbl_Codigo.Text = "Código:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(23, 20);
			label1.Name = "label1";
			label1.Size = new Size(98, 28);
			label1.TabIndex = 7;
			label1.Text = "Elemento:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
			label2.Location = new Point(29, 181);
			label2.Name = "label2";
			label2.Size = new Size(912, 20);
			label2.TabIndex = 14;
			label2.Text = "Selecione as atividades: (use CTRL para selecionar mais de uma linha, use SHIFT e clique em duas linhas para selecionar todas entre elas)";
			// 
			// btn_Close
			// 
			btn_Close.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_Close.Location = new Point(855, 556);
			btn_Close.Name = "btn_Close";
			btn_Close.Size = new Size(101, 29);
			btn_Close.TabIndex = 35;
			btn_Close.Text = "Fechar";
			btn_Close.UseVisualStyleBackColor = true;
			btn_Close.Click += btn_Close_Click;
			// 
			// label3
			// 
			label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			label3.AutoSize = true;
			label3.Location = new Point(552, 98);
			label3.Name = "label3";
			label3.Size = new Size(196, 20);
			label3.TabIndex = 44;
			label3.Text = "Buscar por código ou nome:";
			// 
			// btn_Clean
			// 
			btn_Clean.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btn_Clean.Location = new Point(868, 122);
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
			btn_Search.Location = new Point(788, 122);
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
			txt_Search.Location = new Point(552, 125);
			txt_Search.Margin = new Padding(3, 4, 3, 4);
			txt_Search.Name = "txt_Search";
			txt_Search.Size = new Size(229, 27);
			txt_Search.TabIndex = 41;
			txt_Search.KeyUp += txt_Search_KeyUp;
			// 
			// Frm_ElementActivityRelationship
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(975, 600);
			Controls.Add(label3);
			Controls.Add(btn_Clean);
			Controls.Add(btn_Search);
			Controls.Add(txt_Search);
			Controls.Add(btn_Close);
			Controls.Add(label2);
			Controls.Add(btn_Vincular);
			Controls.Add(dg_Atividades);
			Controls.Add(lbl_Relacao);
			Controls.Add(cb_Relacao);
			Controls.Add(lbl_NomeElemento);
			Controls.Add(lbl_Codigo);
			Controls.Add(label1);
			Margin = new Padding(3, 4, 3, 4);
			MinimumSize = new Size(800, 0);
			Name = "Frm_ElementActivityRelationship";
			Text = "Vincular Atividade";
			Load += Frm_VinculoElementoAtividade_Load;
			((System.ComponentModel.ISupportInitialize)dg_Atividades).EndInit();
			((System.ComponentModel.ISupportInitialize)activityBindingSource).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btn_Vincular;
		private DataGridView dg_Atividades;
		private Label lbl_Relacao;
		private ComboBox cb_Relacao;
		private Label lbl_NomeElemento;
		private Label lbl_Codigo;
		private Label label1;
		private DataGridViewTextBoxColumn idAtividadeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn codAtividadeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn nomeDaAtividadeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn descricaoDaAtividadeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn periodicidade1DataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn periodicidade2DataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn duracaoDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn competenciaExigidaDataGridViewTextBoxColumn;
		private BindingSource activityBindingSource;
		private Label label2;
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