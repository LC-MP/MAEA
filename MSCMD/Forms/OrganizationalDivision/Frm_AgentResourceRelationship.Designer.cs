namespace MSCMD.Forms
{
	partial class Frm_AgentResourceRelationship
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
			dataGridView1 = new DataGridView();
			personIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			codeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			competencesDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			typeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			contactDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			registryDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			humanResourceBindingSource = new BindingSource(components);
			btn_Salvar = new Button();
			lbl_Funcao = new Label();
			lbl_FuncaoCod = new Label();
			lbl_NomeFunc = new Label();
			cbox_Relacao = new ComboBox();
			label1 = new Label();
			lbl_Txt_Pessoa = new Label();
			btn_Close = new Button();
			label3 = new Label();
			btn_Clean = new Button();
			btn_Search = new Button();
			txt_Search = new TextBox();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			((System.ComponentModel.ISupportInitialize)humanResourceBindingSource).BeginInit();
			SuspendLayout();
			// 
			// dataGridView1
			// 
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dataGridView1.AutoGenerateColumns = false;
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Columns.AddRange(new DataGridViewColumn[] { personIdDataGridViewTextBoxColumn, codeDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, competencesDataGridViewTextBoxColumn, typeDataGridViewTextBoxColumn, contactDataGridViewTextBoxColumn, registryDataGridViewTextBoxColumn });
			dataGridView1.DataSource = humanResourceBindingSource;
			dataGridView1.Location = new Point(27, 216);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.ReadOnly = true;
			dataGridView1.RowHeadersVisible = false;
			dataGridView1.RowHeadersWidth = 51;
			dataGridView1.RowTemplate.Height = 29;
			dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView1.Size = new Size(927, 333);
			dataGridView1.TabIndex = 0;
			// 
			// personIdDataGridViewTextBoxColumn
			// 
			personIdDataGridViewTextBoxColumn.DataPropertyName = "PersonId";
			personIdDataGridViewTextBoxColumn.HeaderText = "Id";
			personIdDataGridViewTextBoxColumn.MinimumWidth = 6;
			personIdDataGridViewTextBoxColumn.Name = "personIdDataGridViewTextBoxColumn";
			personIdDataGridViewTextBoxColumn.ReadOnly = true;
			personIdDataGridViewTextBoxColumn.Visible = false;
			personIdDataGridViewTextBoxColumn.Width = 50;
			// 
			// codeDataGridViewTextBoxColumn
			// 
			codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
			codeDataGridViewTextBoxColumn.HeaderText = "Código";
			codeDataGridViewTextBoxColumn.MinimumWidth = 6;
			codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
			codeDataGridViewTextBoxColumn.ReadOnly = true;
			codeDataGridViewTextBoxColumn.Width = 125;
			// 
			// nameDataGridViewTextBoxColumn
			// 
			nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
			nameDataGridViewTextBoxColumn.HeaderText = "Nome";
			nameDataGridViewTextBoxColumn.MinimumWidth = 6;
			nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			nameDataGridViewTextBoxColumn.ReadOnly = true;
			nameDataGridViewTextBoxColumn.Width = 400;
			// 
			// competencesDataGridViewTextBoxColumn
			// 
			competencesDataGridViewTextBoxColumn.DataPropertyName = "Competences";
			competencesDataGridViewTextBoxColumn.HeaderText = "Competências";
			competencesDataGridViewTextBoxColumn.MinimumWidth = 6;
			competencesDataGridViewTextBoxColumn.Name = "competencesDataGridViewTextBoxColumn";
			competencesDataGridViewTextBoxColumn.ReadOnly = true;
			competencesDataGridViewTextBoxColumn.Width = 300;
			// 
			// typeDataGridViewTextBoxColumn
			// 
			typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
			typeDataGridViewTextBoxColumn.HeaderText = "Tipo";
			typeDataGridViewTextBoxColumn.MinimumWidth = 6;
			typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
			typeDataGridViewTextBoxColumn.ReadOnly = true;
			typeDataGridViewTextBoxColumn.Width = 125;
			// 
			// contactDataGridViewTextBoxColumn
			// 
			contactDataGridViewTextBoxColumn.DataPropertyName = "Contact";
			contactDataGridViewTextBoxColumn.HeaderText = "Contato";
			contactDataGridViewTextBoxColumn.MinimumWidth = 6;
			contactDataGridViewTextBoxColumn.Name = "contactDataGridViewTextBoxColumn";
			contactDataGridViewTextBoxColumn.ReadOnly = true;
			contactDataGridViewTextBoxColumn.Width = 125;
			// 
			// registryDataGridViewTextBoxColumn
			// 
			registryDataGridViewTextBoxColumn.DataPropertyName = "Registry";
			registryDataGridViewTextBoxColumn.HeaderText = "Registro";
			registryDataGridViewTextBoxColumn.MinimumWidth = 6;
			registryDataGridViewTextBoxColumn.Name = "registryDataGridViewTextBoxColumn";
			registryDataGridViewTextBoxColumn.ReadOnly = true;
			registryDataGridViewTextBoxColumn.Width = 125;
			// 
			// humanResourceBindingSource
			// 
			humanResourceBindingSource.DataSource = typeof(Model.HumanResource);
			// 
			// btn_Salvar
			// 
			btn_Salvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_Salvar.Location = new Point(711, 555);
			btn_Salvar.Name = "btn_Salvar";
			btn_Salvar.Size = new Size(134, 29);
			btn_Salvar.TabIndex = 1;
			btn_Salvar.Text = "Vincular";
			btn_Salvar.UseVisualStyleBackColor = true;
			btn_Salvar.Click += btn_Salvar_Click;
			// 
			// lbl_Funcao
			// 
			lbl_Funcao.AutoSize = true;
			lbl_Funcao.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_Funcao.Location = new Point(27, 16);
			lbl_Funcao.Name = "lbl_Funcao";
			lbl_Funcao.Size = new Size(91, 32);
			lbl_Funcao.TabIndex = 2;
			lbl_Funcao.Text = "Função";
			// 
			// lbl_FuncaoCod
			// 
			lbl_FuncaoCod.AutoSize = true;
			lbl_FuncaoCod.Location = new Point(30, 51);
			lbl_FuncaoCod.Name = "lbl_FuncaoCod";
			lbl_FuncaoCod.Size = new Size(56, 20);
			lbl_FuncaoCod.TabIndex = 3;
			lbl_FuncaoCod.Text = "codigo";
			// 
			// lbl_NomeFunc
			// 
			lbl_NomeFunc.AutoSize = true;
			lbl_NomeFunc.Location = new Point(30, 77);
			lbl_NomeFunc.Name = "lbl_NomeFunc";
			lbl_NomeFunc.Size = new Size(120, 20);
			lbl_NomeFunc.TabIndex = 4;
			lbl_NomeFunc.Text = "Nome da função";
			// 
			// cbox_Relacao
			// 
			cbox_Relacao.FormattingEnabled = true;
			cbox_Relacao.Location = new Point(30, 143);
			cbox_Relacao.Name = "cbox_Relacao";
			cbox_Relacao.Size = new Size(225, 28);
			cbox_Relacao.TabIndex = 5;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(30, 120);
			label1.Name = "label1";
			label1.Size = new Size(113, 20);
			label1.TabIndex = 6;
			label1.Text = "Tipo da relação";
			// 
			// lbl_Txt_Pessoa
			// 
			lbl_Txt_Pessoa.AutoSize = true;
			lbl_Txt_Pessoa.Location = new Point(30, 193);
			lbl_Txt_Pessoa.Name = "lbl_Txt_Pessoa";
			lbl_Txt_Pessoa.Size = new Size(899, 20);
			lbl_Txt_Pessoa.TabIndex = 7;
			lbl_Txt_Pessoa.Text = "Selecione os recursos: (use CTRL para selecionar mais de uma linha, use SHIFT e clique em duas linhas para selecionar todas entre elas)";
			// 
			// btn_Close
			// 
			btn_Close.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_Close.Location = new Point(851, 555);
			btn_Close.Name = "btn_Close";
			btn_Close.Size = new Size(101, 29);
			btn_Close.TabIndex = 38;
			btn_Close.Text = "Fechar";
			btn_Close.UseVisualStyleBackColor = true;
			btn_Close.Click += btn_Close_Click;
			// 
			// label3
			// 
			label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			label3.AutoSize = true;
			label3.Location = new Point(549, 116);
			label3.Name = "label3";
			label3.Size = new Size(196, 20);
			label3.TabIndex = 56;
			label3.Text = "Buscar por código ou nome:";
			// 
			// btn_Clean
			// 
			btn_Clean.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btn_Clean.Location = new Point(865, 140);
			btn_Clean.Margin = new Padding(3, 4, 3, 4);
			btn_Clean.Name = "btn_Clean";
			btn_Clean.Size = new Size(86, 31);
			btn_Clean.TabIndex = 55;
			btn_Clean.Text = "Limpar";
			btn_Clean.UseVisualStyleBackColor = true;
			btn_Clean.Click += btn_Clean_Click;
			// 
			// btn_Search
			// 
			btn_Search.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btn_Search.Location = new Point(785, 140);
			btn_Search.Margin = new Padding(3, 4, 3, 4);
			btn_Search.Name = "btn_Search";
			btn_Search.Size = new Size(73, 31);
			btn_Search.TabIndex = 54;
			btn_Search.Text = "Buscar";
			btn_Search.UseVisualStyleBackColor = true;
			btn_Search.Click += btn_Search_Click;
			// 
			// txt_Search
			// 
			txt_Search.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			txt_Search.BorderStyle = BorderStyle.FixedSingle;
			txt_Search.Location = new Point(549, 143);
			txt_Search.Margin = new Padding(3, 4, 3, 4);
			txt_Search.Name = "txt_Search";
			txt_Search.Size = new Size(229, 27);
			txt_Search.TabIndex = 53;
			txt_Search.KeyUp += txt_Search_KeyUp;
			// 
			// Frm_AgentResourceRelationship
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(980, 600);
			Controls.Add(label3);
			Controls.Add(btn_Clean);
			Controls.Add(btn_Search);
			Controls.Add(txt_Search);
			Controls.Add(btn_Close);
			Controls.Add(lbl_Txt_Pessoa);
			Controls.Add(label1);
			Controls.Add(cbox_Relacao);
			Controls.Add(lbl_NomeFunc);
			Controls.Add(lbl_FuncaoCod);
			Controls.Add(lbl_Funcao);
			Controls.Add(btn_Salvar);
			Controls.Add(dataGridView1);
			MinimumSize = new Size(800, 0);
			Name = "Frm_AgentResourceRelationship";
			Text = "Vincular Pessoa";
			Load += Frm_VinculoPessoaFuncao_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			((System.ComponentModel.ISupportInitialize)humanResourceBindingSource).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView dataGridView1;
		private DataGridViewTextBoxColumn idPessoaDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn codPessoaDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn nomePessoaDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn competenciasDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn tipoPessoaDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn contatoDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn registroDataGridViewTextBoxColumn;
		private Button btn_Salvar;
		private Label lbl_Funcao;
		private Label lbl_FuncaoCod;
		private Label lbl_NomeFunc;
		private ComboBox cbox_Relacao;
		private Label label1;
		private Label lbl_Txt_Pessoa;
		private BindingSource humanResourceBindingSource;
		private DataGridViewTextBoxColumn personIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn competencesDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn contactDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn registryDataGridViewTextBoxColumn;
		private Button btn_Close;
		private Label label3;
		private Button btn_Clean;
		private Button btn_Search;
		private TextBox txt_Search;
	}
}