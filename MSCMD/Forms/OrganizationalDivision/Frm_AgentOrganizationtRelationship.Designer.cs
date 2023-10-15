namespace MSCMD.Forms.OrganizationalDivision
{
	partial class Frm_AgentOrganizationtRelationship
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
			btn_Salvar = new Button();
			dg_Sector = new DataGridView();
			sectorIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			codeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			sectorNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			superiorInstanceIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			superiorInstanceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			organizationBindingSource = new BindingSource(components);
			lbl_Name = new Label();
			lbl_Code = new Label();
			lbl_Funcao = new Label();
			label1 = new Label();
			btn_Close = new Button();
			((System.ComponentModel.ISupportInitialize)dg_Sector).BeginInit();
			((System.ComponentModel.ISupportInitialize)organizationBindingSource).BeginInit();
			SuspendLayout();
			// 
			// btn_Salvar
			// 
			btn_Salvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_Salvar.Location = new Point(571, 416);
			btn_Salvar.Margin = new Padding(3, 2, 3, 2);
			btn_Salvar.Name = "btn_Salvar";
			btn_Salvar.Size = new Size(112, 22);
			btn_Salvar.TabIndex = 22;
			btn_Salvar.Text = "Vincular";
			btn_Salvar.UseVisualStyleBackColor = true;
			btn_Salvar.Click += btn_Salvar_Click;
			// 
			// dg_Sector
			// 
			dg_Sector.AllowUserToAddRows = false;
			dg_Sector.AllowUserToDeleteRows = false;
			dg_Sector.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dg_Sector.AutoGenerateColumns = false;
			dg_Sector.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_Sector.Columns.AddRange(new DataGridViewColumn[] { sectorIdDataGridViewTextBoxColumn, codeDataGridViewTextBoxColumn, sectorNameDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn, superiorInstanceIdDataGridViewTextBoxColumn, superiorInstanceDataGridViewTextBoxColumn });
			dg_Sector.DataSource = organizationBindingSource;
			dg_Sector.Location = new Point(24, 107);
			dg_Sector.Margin = new Padding(3, 2, 3, 2);
			dg_Sector.Name = "dg_Sector";
			dg_Sector.ReadOnly = true;
			dg_Sector.RowHeadersVisible = false;
			dg_Sector.RowHeadersWidth = 51;
			dg_Sector.RowTemplate.Height = 29;
			dg_Sector.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_Sector.Size = new Size(753, 304);
			dg_Sector.TabIndex = 21;
			// 
			// sectorIdDataGridViewTextBoxColumn
			// 
			sectorIdDataGridViewTextBoxColumn.DataPropertyName = "SectorId";
			sectorIdDataGridViewTextBoxColumn.HeaderText = "SectorId";
			sectorIdDataGridViewTextBoxColumn.MinimumWidth = 6;
			sectorIdDataGridViewTextBoxColumn.Name = "sectorIdDataGridViewTextBoxColumn";
			sectorIdDataGridViewTextBoxColumn.ReadOnly = true;
			sectorIdDataGridViewTextBoxColumn.Visible = false;
			sectorIdDataGridViewTextBoxColumn.Width = 125;
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
			// sectorNameDataGridViewTextBoxColumn
			// 
			sectorNameDataGridViewTextBoxColumn.DataPropertyName = "SectorName";
			sectorNameDataGridViewTextBoxColumn.HeaderText = "Nome do Setor";
			sectorNameDataGridViewTextBoxColumn.MinimumWidth = 6;
			sectorNameDataGridViewTextBoxColumn.Name = "sectorNameDataGridViewTextBoxColumn";
			sectorNameDataGridViewTextBoxColumn.ReadOnly = true;
			sectorNameDataGridViewTextBoxColumn.Width = 250;
			// 
			// descriptionDataGridViewTextBoxColumn
			// 
			descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
			descriptionDataGridViewTextBoxColumn.HeaderText = "Descrição";
			descriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
			descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
			descriptionDataGridViewTextBoxColumn.ReadOnly = true;
			descriptionDataGridViewTextBoxColumn.Width = 480;
			// 
			// superiorInstanceIdDataGridViewTextBoxColumn
			// 
			superiorInstanceIdDataGridViewTextBoxColumn.DataPropertyName = "SuperiorInstanceId";
			superiorInstanceIdDataGridViewTextBoxColumn.HeaderText = "SuperiorInstanceId";
			superiorInstanceIdDataGridViewTextBoxColumn.MinimumWidth = 6;
			superiorInstanceIdDataGridViewTextBoxColumn.Name = "superiorInstanceIdDataGridViewTextBoxColumn";
			superiorInstanceIdDataGridViewTextBoxColumn.ReadOnly = true;
			superiorInstanceIdDataGridViewTextBoxColumn.Visible = false;
			superiorInstanceIdDataGridViewTextBoxColumn.Width = 125;
			// 
			// superiorInstanceDataGridViewTextBoxColumn
			// 
			superiorInstanceDataGridViewTextBoxColumn.DataPropertyName = "SuperiorInstance";
			superiorInstanceDataGridViewTextBoxColumn.HeaderText = "SuperiorInstance";
			superiorInstanceDataGridViewTextBoxColumn.MinimumWidth = 6;
			superiorInstanceDataGridViewTextBoxColumn.Name = "superiorInstanceDataGridViewTextBoxColumn";
			superiorInstanceDataGridViewTextBoxColumn.ReadOnly = true;
			superiorInstanceDataGridViewTextBoxColumn.Visible = false;
			superiorInstanceDataGridViewTextBoxColumn.Width = 125;
			// 
			// organizationBindingSource
			// 
			organizationBindingSource.DataSource = typeof(Model.Organization);
			// 
			// lbl_Name
			// 
			lbl_Name.AutoSize = true;
			lbl_Name.Location = new Point(26, 58);
			lbl_Name.Name = "lbl_Name";
			lbl_Name.Size = new Size(96, 15);
			lbl_Name.TabIndex = 20;
			lbl_Name.Text = "Nome da função";
			// 
			// lbl_Code
			// 
			lbl_Code.AutoSize = true;
			lbl_Code.Location = new Point(26, 38);
			lbl_Code.Name = "lbl_Code";
			lbl_Code.Size = new Size(44, 15);
			lbl_Code.TabIndex = 19;
			lbl_Code.Text = "codigo";
			// 
			// lbl_Funcao
			// 
			lbl_Funcao.AutoSize = true;
			lbl_Funcao.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_Funcao.Location = new Point(24, 12);
			lbl_Funcao.Name = "lbl_Funcao";
			lbl_Funcao.Size = new Size(73, 25);
			lbl_Funcao.TabIndex = 18;
			lbl_Funcao.Text = "Função";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(26, 90);
			label1.Name = "label1";
			label1.Size = new Size(701, 15);
			label1.TabIndex = 23;
			label1.Text = "Lotação Funcional:  (use CTRL para selecionar mais de uma linha, use SHIFT e clique em duas linhas para selecionar todas entre elas)";
			// 
			// btn_Close
			// 
			btn_Close.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_Close.Location = new Point(689, 416);
			btn_Close.Margin = new Padding(3, 2, 3, 2);
			btn_Close.Name = "btn_Close";
			btn_Close.Size = new Size(88, 22);
			btn_Close.TabIndex = 37;
			btn_Close.Text = "Fechar";
			btn_Close.UseVisualStyleBackColor = true;
			btn_Close.Click += btn_Close_Click;
			// 
			// Frm_AgentOrganizationtRelationship
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(btn_Close);
			Controls.Add(label1);
			Controls.Add(btn_Salvar);
			Controls.Add(dg_Sector);
			Controls.Add(lbl_Name);
			Controls.Add(lbl_Code);
			Controls.Add(lbl_Funcao);
			Margin = new Padding(3, 2, 3, 2);
			Name = "Frm_AgentOrganizationtRelationship";
			Text = "Vincular Setor";
			Load += Frm_AgentOrganizationtRelationship_Load;
			((System.ComponentModel.ISupportInitialize)dg_Sector).EndInit();
			((System.ComponentModel.ISupportInitialize)organizationBindingSource).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btn_Salvar;
		private DataGridView dg_Sector;
		private Label lbl_Name;
		private Label lbl_Code;
		private Label lbl_Funcao;
		private BindingSource organizationBindingSource;
		private Label label1;
		private DataGridViewTextBoxColumn sectorIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn sectorNameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn agentIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn responsibleAgentDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn superiorInstanceIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn superiorInstanceDataGridViewTextBoxColumn;
		private Button btn_Close;
	}
}