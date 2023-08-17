namespace MSCMD.Forms
{
	partial class Frm_Resources
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
			lbl_Title = new Label();
			dg_HumanResource = new DataGridView();
			personIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			codeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			competencesDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			DataGridViewComboBoxColumn = new DataGridViewComboBoxColumn();
			contactDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			registryDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			pessoaBindingSource = new BindingSource(components);
			btn_Delete = new Button();
			btn_Save = new Button();
			btn_ImportPessoas = new Button();
			btn_ExportCsv = new Button();
			((System.ComponentModel.ISupportInitialize)dg_HumanResource).BeginInit();
			((System.ComponentModel.ISupportInitialize)pessoaBindingSource).BeginInit();
			SuspendLayout();
			// 
			// lbl_Title
			// 
			lbl_Title.AutoSize = true;
			lbl_Title.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_Title.Location = new Point(24, 19);
			lbl_Title.Name = "lbl_Title";
			lbl_Title.Size = new Size(216, 32);
			lbl_Title.TabIndex = 1;
			lbl_Title.Text = "Recursos Humanos";
			// 
			// dg_HumanResource
			// 
			dg_HumanResource.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dg_HumanResource.AutoGenerateColumns = false;
			dg_HumanResource.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_HumanResource.Columns.AddRange(new DataGridViewColumn[] { personIdDataGridViewTextBoxColumn, codeDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, competencesDataGridViewTextBoxColumn, DataGridViewComboBoxColumn, contactDataGridViewTextBoxColumn, registryDataGridViewTextBoxColumn });
			dg_HumanResource.DataSource = pessoaBindingSource;
			dg_HumanResource.Location = new Point(24, 65);
			dg_HumanResource.MultiSelect = false;
			dg_HumanResource.Name = "dg_HumanResource";
			dg_HumanResource.RowHeadersVisible = false;
			dg_HumanResource.RowHeadersWidth = 51;
			dg_HumanResource.RowTemplate.Height = 29;
			dg_HumanResource.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_HumanResource.Size = new Size(1625, 758);
			dg_HumanResource.TabIndex = 2;
			dg_HumanResource.DataError += dg_HumanResource_DataError;
			dg_HumanResource.Leave += dg_HumanResource_Leave;
			// 
			// personIdDataGridViewTextBoxColumn
			// 
			personIdDataGridViewTextBoxColumn.DataPropertyName = "PersonId";
			personIdDataGridViewTextBoxColumn.HeaderText = "PersonId";
			personIdDataGridViewTextBoxColumn.MinimumWidth = 6;
			personIdDataGridViewTextBoxColumn.Name = "personIdDataGridViewTextBoxColumn";
			personIdDataGridViewTextBoxColumn.Visible = false;
			personIdDataGridViewTextBoxColumn.Width = 125;
			// 
			// codeDataGridViewTextBoxColumn
			// 
			codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
			codeDataGridViewTextBoxColumn.HeaderText = "Código";
			codeDataGridViewTextBoxColumn.MinimumWidth = 6;
			codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
			codeDataGridViewTextBoxColumn.Width = 125;
			// 
			// nameDataGridViewTextBoxColumn
			// 
			nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
			nameDataGridViewTextBoxColumn.HeaderText = "Nome";
			nameDataGridViewTextBoxColumn.MinimumWidth = 6;
			nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			nameDataGridViewTextBoxColumn.Width = 400;
			// 
			// competencesDataGridViewTextBoxColumn
			// 
			competencesDataGridViewTextBoxColumn.DataPropertyName = "Competences";
			competencesDataGridViewTextBoxColumn.HeaderText = "Competências";
			competencesDataGridViewTextBoxColumn.MinimumWidth = 6;
			competencesDataGridViewTextBoxColumn.Name = "competencesDataGridViewTextBoxColumn";
			competencesDataGridViewTextBoxColumn.Width = 400;
			// 
			// DataGridViewComboBoxColumn
			// 
			DataGridViewComboBoxColumn.DataPropertyName = "Type";
			DataGridViewComboBoxColumn.HeaderText = "Tipo (Física, Jurídica)";
			DataGridViewComboBoxColumn.MinimumWidth = 6;
			DataGridViewComboBoxColumn.Name = "DataGridViewComboBoxColumn";
			DataGridViewComboBoxColumn.Resizable = DataGridViewTriState.True;
			DataGridViewComboBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic;
			DataGridViewComboBoxColumn.Width = 125;
			// 
			// contactDataGridViewTextBoxColumn
			// 
			contactDataGridViewTextBoxColumn.DataPropertyName = "Contact";
			contactDataGridViewTextBoxColumn.HeaderText = "Contato";
			contactDataGridViewTextBoxColumn.MinimumWidth = 6;
			contactDataGridViewTextBoxColumn.Name = "contactDataGridViewTextBoxColumn";
			contactDataGridViewTextBoxColumn.Width = 125;
			// 
			// registryDataGridViewTextBoxColumn
			// 
			registryDataGridViewTextBoxColumn.DataPropertyName = "Registry";
			registryDataGridViewTextBoxColumn.HeaderText = "Registro";
			registryDataGridViewTextBoxColumn.MinimumWidth = 6;
			registryDataGridViewTextBoxColumn.Name = "registryDataGridViewTextBoxColumn";
			registryDataGridViewTextBoxColumn.Width = 125;
			// 
			// pessoaBindingSource
			// 
			pessoaBindingSource.DataSource = typeof(Model.HumanResource);
			// 
			// btn_Delete
			// 
			btn_Delete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_Delete.Location = new Point(1457, 830);
			btn_Delete.Name = "btn_Delete";
			btn_Delete.Size = new Size(192, 29);
			btn_Delete.TabIndex = 5;
			btn_Delete.Text = "Deletar itens selecionados";
			btn_Delete.UseVisualStyleBackColor = true;
			btn_Delete.Click += btn_Delete_Click;
			// 
			// btn_Save
			// 
			btn_Save.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btn_Save.Location = new Point(1518, 12);
			btn_Save.Name = "btn_Save";
			btn_Save.Size = new Size(166, 29);
			btn_Save.TabIndex = 6;
			btn_Save.Text = "Salvar alterações";
			btn_Save.UseVisualStyleBackColor = true;
			btn_Save.Click += btn_Save_Click;
			// 
			// btn_ImportPessoas
			// 
			btn_ImportPessoas.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_ImportPessoas.Location = new Point(1304, 830);
			btn_ImportPessoas.Margin = new Padding(3, 4, 3, 4);
			btn_ImportPessoas.Name = "btn_ImportPessoas";
			btn_ImportPessoas.Size = new Size(147, 31);
			btn_ImportPessoas.TabIndex = 7;
			btn_ImportPessoas.Text = "Importar .csv";
			btn_ImportPessoas.UseVisualStyleBackColor = true;
			btn_ImportPessoas.Click += btn_ImportPessoas_Click;
			// 
			// btn_ExportCsv
			// 
			btn_ExportCsv.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_ExportCsv.Location = new Point(1151, 830);
			btn_ExportCsv.Margin = new Padding(3, 4, 3, 4);
			btn_ExportCsv.Name = "btn_ExportCsv";
			btn_ExportCsv.Size = new Size(147, 31);
			btn_ExportCsv.TabIndex = 8;
			btn_ExportCsv.Text = "Exportar .csv";
			btn_ExportCsv.UseVisualStyleBackColor = true;
			btn_ExportCsv.Click += btn_ExportCsv_Click;
			// 
			// Frm_Resources
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1696, 881);
			Controls.Add(btn_ExportCsv);
			Controls.Add(btn_ImportPessoas);
			Controls.Add(btn_Save);
			Controls.Add(btn_Delete);
			Controls.Add(dg_HumanResource);
			Controls.Add(lbl_Title);
			Name = "Frm_Resources";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "MScMD - Recursos";
			Load += Frm_Resources_Load;
			((System.ComponentModel.ISupportInitialize)dg_HumanResource).EndInit();
			((System.ComponentModel.ISupportInitialize)pessoaBindingSource).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private MenuStrip menuStrip1;
		private ToolStripMenuItem geralToolStripMenuItem;
		private ToolStripMenuItem organizaçãoToolStripMenuItem;
		private ToolStripMenuItem atividadeToolStripMenuItem;
		private ToolStripMenuItem elementoToolStripMenuItem;
		private ToolStripMenuItem pessoaToolStripMenuItem;
		private Label lbl_Title;
		private DataGridView dg_HumanResource;
		private BindingSource pessoaBindingSource;
		private Button btn_Delete;
		private Button btn_Save;
		private Button btn_ImportPessoas;
		private DataGridViewTextBoxColumn idPessoaDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn codPessoaDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn nomePessoaDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn competenciasDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn tipoPessoaDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn contatoDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn registroDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn personIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn competencesDataGridViewTextBoxColumn;
		private DataGridViewComboBoxColumn DataGridViewComboBoxColumn;
		private DataGridViewTextBoxColumn contactDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn registryDataGridViewTextBoxColumn;
		private Button btn_ExportCsv;
	}
}