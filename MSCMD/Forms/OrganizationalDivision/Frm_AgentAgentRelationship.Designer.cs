namespace MSCMD.Forms.OrganizationalDivision
{
	partial class Frm_AgentAgentRelationship
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
			lbl_Name = new Label();
			lbl_Code = new Label();
			lbl_Funcao = new Label();
			btn_Save = new Button();
			dg_Agent = new DataGridView();
			agentIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			codeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			agentBindingSource = new BindingSource(components);
			label1 = new Label();
			btn_Close = new Button();
			label3 = new Label();
			btn_Clean = new Button();
			btn_Search = new Button();
			txt_Search = new TextBox();
			((System.ComponentModel.ISupportInitialize)dg_Agent).BeginInit();
			((System.ComponentModel.ISupportInitialize)agentBindingSource).BeginInit();
			SuspendLayout();
			// 
			// lbl_Name
			// 
			lbl_Name.AutoSize = true;
			lbl_Name.Location = new Point(32, 81);
			lbl_Name.Name = "lbl_Name";
			lbl_Name.Size = new Size(120, 20);
			lbl_Name.TabIndex = 15;
			lbl_Name.Text = "Nome da função";
			// 
			// lbl_Code
			// 
			lbl_Code.AutoSize = true;
			lbl_Code.Location = new Point(30, 53);
			lbl_Code.Name = "lbl_Code";
			lbl_Code.Size = new Size(56, 20);
			lbl_Code.TabIndex = 14;
			lbl_Code.Text = "codigo";
			// 
			// lbl_Funcao
			// 
			lbl_Funcao.AutoSize = true;
			lbl_Funcao.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_Funcao.Location = new Point(26, 17);
			lbl_Funcao.Name = "lbl_Funcao";
			lbl_Funcao.Size = new Size(91, 32);
			lbl_Funcao.TabIndex = 13;
			lbl_Funcao.Text = "Função";
			// 
			// btn_Save
			// 
			btn_Save.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_Save.Location = new Point(651, 557);
			btn_Save.Name = "btn_Save";
			btn_Save.Size = new Size(131, 29);
			btn_Save.TabIndex = 17;
			btn_Save.Text = "Vincular";
			btn_Save.UseVisualStyleBackColor = true;
			btn_Save.Click += btn_Save_Click;
			// 
			// dg_Agent
			// 
			dg_Agent.AllowUserToAddRows = false;
			dg_Agent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dg_Agent.AutoGenerateColumns = false;
			dg_Agent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_Agent.Columns.AddRange(new DataGridViewColumn[] { agentIdDataGridViewTextBoxColumn, codeDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn });
			dg_Agent.DataSource = agentBindingSource;
			dg_Agent.Location = new Point(30, 157);
			dg_Agent.Name = "dg_Agent";
			dg_Agent.ReadOnly = true;
			dg_Agent.RowHeadersVisible = false;
			dg_Agent.RowHeadersWidth = 51;
			dg_Agent.RowTemplate.Height = 29;
			dg_Agent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_Agent.Size = new Size(859, 395);
			dg_Agent.TabIndex = 16;
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
			codeDataGridViewTextBoxColumn.Width = 125;
			// 
			// nameDataGridViewTextBoxColumn
			// 
			nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
			nameDataGridViewTextBoxColumn.HeaderText = "Nome";
			nameDataGridViewTextBoxColumn.MinimumWidth = 6;
			nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			nameDataGridViewTextBoxColumn.ReadOnly = true;
			nameDataGridViewTextBoxColumn.Width = 250;
			// 
			// descriptionDataGridViewTextBoxColumn
			// 
			descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
			descriptionDataGridViewTextBoxColumn.HeaderText = "Descrição";
			descriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
			descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
			descriptionDataGridViewTextBoxColumn.ReadOnly = true;
			descriptionDataGridViewTextBoxColumn.Width = 470;
			// 
			// agentBindingSource
			// 
			agentBindingSource.DataSource = typeof(Model.Agent);
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(32, 135);
			label1.Name = "label1";
			label1.Size = new Size(859, 20);
			label1.TabIndex = 18;
			label1.Text = "Subordinada à:  (use CTRL para selecionar mais de uma linha, use SHIFT e clique em duas linhas para selecionar todas entre elas)";
			// 
			// btn_Close
			// 
			btn_Close.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_Close.Location = new Point(789, 557);
			btn_Close.Name = "btn_Close";
			btn_Close.Size = new Size(101, 29);
			btn_Close.TabIndex = 36;
			btn_Close.Text = "Fechar";
			btn_Close.UseVisualStyleBackColor = true;
			btn_Close.Click += btn_Close_Click;
			// 
			// label3
			// 
			label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			label3.AutoSize = true;
			label3.Location = new Point(483, 54);
			label3.Name = "label3";
			label3.Size = new Size(196, 20);
			label3.TabIndex = 52;
			label3.Text = "Buscar por código ou nome:";
			// 
			// btn_Clean
			// 
			btn_Clean.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btn_Clean.Location = new Point(799, 78);
			btn_Clean.Margin = new Padding(3, 4, 3, 4);
			btn_Clean.Name = "btn_Clean";
			btn_Clean.Size = new Size(86, 31);
			btn_Clean.TabIndex = 51;
			btn_Clean.Text = "Limpar";
			btn_Clean.UseVisualStyleBackColor = true;
			btn_Clean.Click += btn_Clean_Click;
			// 
			// btn_Search
			// 
			btn_Search.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btn_Search.Location = new Point(719, 78);
			btn_Search.Margin = new Padding(3, 4, 3, 4);
			btn_Search.Name = "btn_Search";
			btn_Search.Size = new Size(73, 31);
			btn_Search.TabIndex = 50;
			btn_Search.Text = "Buscar";
			btn_Search.UseVisualStyleBackColor = true;
			btn_Search.Click += btn_Search_Click;
			// 
			// txt_Search
			// 
			txt_Search.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			txt_Search.BorderStyle = BorderStyle.FixedSingle;
			txt_Search.Location = new Point(483, 81);
			txt_Search.Margin = new Padding(3, 4, 3, 4);
			txt_Search.Name = "txt_Search";
			txt_Search.Size = new Size(229, 27);
			txt_Search.TabIndex = 49;
			txt_Search.KeyUp += txt_Search_KeyUp;
			// 
			// Frm_AgentAgentRelationship
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(914, 600);
			Controls.Add(label3);
			Controls.Add(btn_Clean);
			Controls.Add(btn_Search);
			Controls.Add(txt_Search);
			Controls.Add(btn_Close);
			Controls.Add(label1);
			Controls.Add(btn_Save);
			Controls.Add(dg_Agent);
			Controls.Add(lbl_Name);
			Controls.Add(lbl_Code);
			Controls.Add(lbl_Funcao);
			Name = "Frm_AgentAgentRelationship";
			Text = "Vincular Função";
			Load += Frm_AgentAgentRelationship_Load;
			((System.ComponentModel.ISupportInitialize)dg_Agent).EndInit();
			((System.ComponentModel.ISupportInitialize)agentBindingSource).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lbl_Name;
		private Label lbl_Code;
		private Label lbl_Funcao;
		private Button btn_Save;
		private DataGridView dg_Agent;
		private BindingSource agentBindingSource;
		private Label label1;
		private DataGridViewTextBoxColumn functionalCapacityIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn functionalCapacityDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn functionalSubordinationIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn functionalSubordinationDataGridViewTextBoxColumn;
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