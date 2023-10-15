namespace MSCMD.Forms
{
	partial class Frm_ImportCsv
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
			btn_SelectFile = new Button();
			lbl_txtFile = new Label();
			btn_Save = new Button();
			dgv_Itens = new DataGridView();
			lbl_Titulo = new Label();
			lbl_Descricao = new Label();
			btn_Save_Selected = new Button();
			label1 = new Label();
			btn_DownloadTemplate = new Button();
			btn_Close = new Button();
			lbl_StatusMessage = new Label();
			((System.ComponentModel.ISupportInitialize)dgv_Itens).BeginInit();
			SuspendLayout();
			// 
			// btn_SelectFile
			// 
			btn_SelectFile.Location = new Point(40, 111);
			btn_SelectFile.Name = "btn_SelectFile";
			btn_SelectFile.Size = new Size(157, 40);
			btn_SelectFile.TabIndex = 0;
			btn_SelectFile.Text = "Selecionar arquivo";
			btn_SelectFile.UseVisualStyleBackColor = true;
			btn_SelectFile.Click += btn_SelectFile_Click;
			// 
			// lbl_txtFile
			// 
			lbl_txtFile.AutoSize = true;
			lbl_txtFile.Location = new Point(216, 121);
			lbl_txtFile.Name = "lbl_txtFile";
			lbl_txtFile.Size = new Size(0, 20);
			lbl_txtFile.TabIndex = 1;
			// 
			// btn_Save
			// 
			btn_Save.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_Save.Location = new Point(852, 713);
			btn_Save.Name = "btn_Save";
			btn_Save.Size = new Size(158, 35);
			btn_Save.TabIndex = 2;
			btn_Save.Text = "Importar tudo";
			btn_Save.UseVisualStyleBackColor = true;
			btn_Save.Click += btn_Save_Click;
			// 
			// dgv_Itens
			// 
			dgv_Itens.AllowUserToAddRows = false;
			dgv_Itens.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dgv_Itens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv_Itens.Location = new Point(40, 205);
			dgv_Itens.Name = "dgv_Itens";
			dgv_Itens.RowHeadersWidth = 51;
			dgv_Itens.RowTemplate.Height = 29;
			dgv_Itens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgv_Itens.Size = new Size(1074, 499);
			dgv_Itens.TabIndex = 3;
			// 
			// lbl_Titulo
			// 
			lbl_Titulo.AutoSize = true;
			lbl_Titulo.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_Titulo.Location = new Point(40, 25);
			lbl_Titulo.Name = "lbl_Titulo";
			lbl_Titulo.Size = new Size(150, 32);
			lbl_Titulo.TabIndex = 4;
			lbl_Titulo.Text = "Importar .csv";
			// 
			// lbl_Descricao
			// 
			lbl_Descricao.AutoSize = true;
			lbl_Descricao.Location = new Point(40, 64);
			lbl_Descricao.Name = "lbl_Descricao";
			lbl_Descricao.Size = new Size(342, 20);
			lbl_Descricao.TabIndex = 5;
			lbl_Descricao.Text = "Selecione um arquivo .csv para importar os dados.";
			// 
			// btn_Save_Selected
			// 
			btn_Save_Selected.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_Save_Selected.Location = new Point(625, 713);
			btn_Save_Selected.Name = "btn_Save_Selected";
			btn_Save_Selected.Size = new Size(225, 35);
			btn_Save_Selected.TabIndex = 6;
			btn_Save_Selected.Text = "Importar linhas selecionadas";
			btn_Save_Selected.UseVisualStyleBackColor = true;
			btn_Save_Selected.Click += btn_Save_Selected_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(40, 181);
			label1.Name = "label1";
			label1.Size = new Size(766, 20);
			label1.TabIndex = 7;
			label1.Text = "Para selecionar mais de uma linha pressione o Ctrl ou utilize o Shift para seleciona todos os itens entre duas linhas.";
			// 
			// btn_DownloadTemplate
			// 
			btn_DownloadTemplate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btn_DownloadTemplate.Location = new Point(926, 37);
			btn_DownloadTemplate.Name = "btn_DownloadTemplate";
			btn_DownloadTemplate.Size = new Size(187, 45);
			btn_DownloadTemplate.TabIndex = 8;
			btn_DownloadTemplate.Text = "Baixar Template .csv";
			btn_DownloadTemplate.UseVisualStyleBackColor = true;
			btn_DownloadTemplate.Click += btn_DownloadTemplate_Click;
			// 
			// btn_Close
			// 
			btn_Close.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_Close.Location = new Point(1013, 713);
			btn_Close.Name = "btn_Close";
			btn_Close.Size = new Size(101, 35);
			btn_Close.TabIndex = 39;
			btn_Close.Text = "Fechar";
			btn_Close.UseVisualStyleBackColor = true;
			btn_Close.Click += btn_Close_Click;
			// 
			// lbl_StatusMessage
			// 
			lbl_StatusMessage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			lbl_StatusMessage.Location = new Point(40, 715);
			lbl_StatusMessage.Name = "lbl_StatusMessage";
			lbl_StatusMessage.Size = new Size(385, 49);
			lbl_StatusMessage.TabIndex = 40;
			lbl_StatusMessage.Text = "label2";
			// 
			// Frm_ImportCsv
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1159, 771);
			Controls.Add(lbl_StatusMessage);
			Controls.Add(btn_Close);
			Controls.Add(btn_DownloadTemplate);
			Controls.Add(label1);
			Controls.Add(btn_Save_Selected);
			Controls.Add(lbl_Descricao);
			Controls.Add(lbl_Titulo);
			Controls.Add(dgv_Itens);
			Controls.Add(btn_Save);
			Controls.Add(lbl_txtFile);
			Controls.Add(btn_SelectFile);
			MinimumSize = new Size(990, 500);
			Name = "Frm_ImportCsv";
			StartPosition = FormStartPosition.Manual;
			Text = "Importar .csv";
			Load += Frm_ImportCsv_Load;
			((System.ComponentModel.ISupportInitialize)dgv_Itens).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btn_SelectFile;
		private Label lbl_txtFile;
		private Button btn_Save;
		private DataGridView dgv_Itens;
		private Label lbl_Titulo;
		private Label lbl_Descricao;
		private Button btn_Save_Selected;
		private Label label1;
		private Button btn_DownloadTemplate;
		private Button btn_Close;
		private Label lbl_StatusMessage;
	}
}