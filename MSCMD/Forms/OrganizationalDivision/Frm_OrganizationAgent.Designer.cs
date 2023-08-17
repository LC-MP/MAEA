namespace MSCMD.Forms.OrganizationalDivision
{
	partial class Frm_OrganizationAgent
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
			dg_Agents = new DataGridView();
			agentIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			codeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			agentBindingSource = new BindingSource(components);
			lbl_Name = new Label();
			lbl_Code = new Label();
			lbl_Subsystem = new Label();
			btn_Close = new Button();
			label3 = new Label();
			btn_Clean = new Button();
			btn_Search = new Button();
			txt_Search = new TextBox();
			((System.ComponentModel.ISupportInitialize)dg_Agents).BeginInit();
			((System.ComponentModel.ISupportInitialize)agentBindingSource).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(31, 133);
			label1.Name = "label1";
			label1.Size = new Size(895, 20);
			label1.TabIndex = 42;
			label1.Text = "Selecione as funções: (use CTRL para selecionar mais de uma linha, use SHIFT e clique em duas linhas para selecionar todas entre elas)";
			// 
			// btn_Save
			// 
			btn_Save.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_Save.Location = new Point(755, 557);
			btn_Save.Name = "btn_Save";
			btn_Save.Size = new Size(113, 29);
			btn_Save.TabIndex = 41;
			btn_Save.Text = "Vincular";
			btn_Save.UseVisualStyleBackColor = true;
			btn_Save.Click += btn_Save_Click;
			// 
			// dg_Agents
			// 
			dg_Agents.AllowUserToAddRows = false;
			dg_Agents.AllowUserToDeleteRows = false;
			dg_Agents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dg_Agents.AutoGenerateColumns = false;
			dg_Agents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_Agents.Columns.AddRange(new DataGridViewColumn[] { agentIdDataGridViewTextBoxColumn, codeDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn });
			dg_Agents.DataSource = agentBindingSource;
			dg_Agents.Location = new Point(29, 156);
			dg_Agents.Name = "dg_Agents";
			dg_Agents.ReadOnly = true;
			dg_Agents.RowHeadersVisible = false;
			dg_Agents.RowHeadersWidth = 51;
			dg_Agents.RowTemplate.Height = 29;
			dg_Agents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_Agents.Size = new Size(946, 395);
			dg_Agents.TabIndex = 40;
			// 
			// agentIdDataGridViewTextBoxColumn
			// 
			agentIdDataGridViewTextBoxColumn.DataPropertyName = "AgentId";
			agentIdDataGridViewTextBoxColumn.HeaderText = "Id";
			agentIdDataGridViewTextBoxColumn.MinimumWidth = 6;
			agentIdDataGridViewTextBoxColumn.Name = "agentIdDataGridViewTextBoxColumn";
			agentIdDataGridViewTextBoxColumn.ReadOnly = true;
			agentIdDataGridViewTextBoxColumn.Width = 50;
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
			nameDataGridViewTextBoxColumn.Width = 500;
			// 
			// descriptionDataGridViewTextBoxColumn
			// 
			descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
			descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
			descriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
			descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
			descriptionDataGridViewTextBoxColumn.ReadOnly = true;
			descriptionDataGridViewTextBoxColumn.Visible = false;
			descriptionDataGridViewTextBoxColumn.Width = 125;
			// 
			// agentBindingSource
			// 
			agentBindingSource.DataSource = typeof(Model.Agent);
			// 
			// lbl_Name
			// 
			lbl_Name.AutoSize = true;
			lbl_Name.Location = new Point(31, 79);
			lbl_Name.Name = "lbl_Name";
			lbl_Name.Size = new Size(120, 20);
			lbl_Name.TabIndex = 39;
			lbl_Name.Text = "Nome da função";
			// 
			// lbl_Code
			// 
			lbl_Code.AutoSize = true;
			lbl_Code.Location = new Point(29, 51);
			lbl_Code.Name = "lbl_Code";
			lbl_Code.Size = new Size(56, 20);
			lbl_Code.TabIndex = 38;
			lbl_Code.Text = "codigo";
			// 
			// lbl_Subsystem
			// 
			lbl_Subsystem.AutoSize = true;
			lbl_Subsystem.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_Subsystem.Location = new Point(25, 15);
			lbl_Subsystem.Name = "lbl_Subsystem";
			lbl_Subsystem.Size = new Size(256, 32);
			lbl_Subsystem.TabIndex = 37;
			lbl_Subsystem.Text = "Divisão Organizacional";
			// 
			// btn_Close
			// 
			btn_Close.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_Close.Location = new Point(874, 557);
			btn_Close.Name = "btn_Close";
			btn_Close.Size = new Size(101, 29);
			btn_Close.TabIndex = 43;
			btn_Close.Text = "Fechar";
			btn_Close.UseVisualStyleBackColor = true;
			btn_Close.Click += btn_Close_Click;
			// 
			// label3
			// 
			label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			label3.AutoSize = true;
			label3.Location = new Point(573, 62);
			label3.Name = "label3";
			label3.Size = new Size(196, 20);
			label3.TabIndex = 56;
			label3.Text = "Buscar por código ou nome:";
			// 
			// btn_Clean
			// 
			btn_Clean.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btn_Clean.Location = new Point(889, 86);
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
			btn_Search.Location = new Point(809, 86);
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
			txt_Search.Location = new Point(573, 89);
			txt_Search.Margin = new Padding(3, 4, 3, 4);
			txt_Search.Name = "txt_Search";
			txt_Search.Size = new Size(229, 27);
			txt_Search.TabIndex = 53;
			txt_Search.KeyUp += txt_Search_KeyUp;
			// 
			// Frm_OrganizationAgent
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1001, 600);
			Controls.Add(label3);
			Controls.Add(btn_Clean);
			Controls.Add(btn_Search);
			Controls.Add(txt_Search);
			Controls.Add(btn_Close);
			Controls.Add(label1);
			Controls.Add(btn_Save);
			Controls.Add(dg_Agents);
			Controls.Add(lbl_Name);
			Controls.Add(lbl_Code);
			Controls.Add(lbl_Subsystem);
			Margin = new Padding(3, 4, 3, 4);
			MinimumSize = new Size(800, 0);
			Name = "Frm_OrganizationAgent";
			Text = "Divisão Organizacional";
			Load += Frm_OrganizationAgent_Load;
			((System.ComponentModel.ISupportInitialize)dg_Agents).EndInit();
			((System.ComponentModel.ISupportInitialize)agentBindingSource).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Button btn_Save;
		private DataGridView dg_Agents;
		private Label lbl_Name;
		private Label lbl_Code;
		private Label lbl_Subsystem;
		private BindingSource agentBindingSource;
		private Button btn_Close;
		private DataGridViewTextBoxColumn agentIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
		private Label label3;
		private Button btn_Clean;
		private Button btn_Search;
		private TextBox txt_Search;
	}
}