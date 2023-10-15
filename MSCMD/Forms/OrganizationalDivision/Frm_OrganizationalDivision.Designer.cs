namespace MSCMD.Forms.OrganizationalDivision
{
	partial class Frm_OrganizationalDivision
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
			btn_DeleteOrganization = new Button();
			btn_DeleteElement = new Button();
			lbl_SectorName = new Label();
			btn_Save = new Button();
			lbl_Separator_Vertical = new Label();
			btn_AddElement = new Button();
			dg_Agents = new DataGridView();
			agentBindingSource = new BindingSource(components);
			label2 = new Label();
			label1 = new Label();
			dg_Organization = new DataGridView();
			organizationBindingSource = new BindingSource(components);
			sectorIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			codeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			sectorNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			responsibleAgentIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			superiorInstanceIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			superiorInstanceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			agentIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			codeDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			descriptionDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)dg_Agents).BeginInit();
			((System.ComponentModel.ISupportInitialize)agentBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)dg_Organization).BeginInit();
			((System.ComponentModel.ISupportInitialize)organizationBindingSource).BeginInit();
			SuspendLayout();
			// 
			// btn_DeleteOrganization
			// 
			btn_DeleteOrganization.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_DeleteOrganization.Location = new Point(348, 422);
			btn_DeleteOrganization.Margin = new Padding(3, 2, 3, 2);
			btn_DeleteOrganization.Name = "btn_DeleteOrganization";
			btn_DeleteOrganization.Size = new Size(140, 22);
			btn_DeleteOrganization.TabIndex = 58;
			btn_DeleteOrganization.Text = "Deletar seleção";
			btn_DeleteOrganization.UseVisualStyleBackColor = true;
			btn_DeleteOrganization.Click += btn_DeleteOrganization_Click;
			// 
			// btn_DeleteElement
			// 
			btn_DeleteElement.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_DeleteElement.Location = new Point(945, 420);
			btn_DeleteElement.Margin = new Padding(3, 2, 3, 2);
			btn_DeleteElement.Name = "btn_DeleteElement";
			btn_DeleteElement.Size = new Size(132, 22);
			btn_DeleteElement.TabIndex = 57;
			btn_DeleteElement.Text = "Desvincular seleção";
			btn_DeleteElement.UseVisualStyleBackColor = true;
			btn_DeleteElement.Click += btn_DeleteElement_Click;
			// 
			// lbl_SectorName
			// 
			lbl_SectorName.AutoSize = true;
			lbl_SectorName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_SectorName.Location = new Point(573, 33);
			lbl_SectorName.Name = "lbl_SectorName";
			lbl_SectorName.Size = new Size(52, 21);
			lbl_SectorName.TabIndex = 56;
			lbl_SectorName.Text = "label3";
			// 
			// btn_Save
			// 
			btn_Save.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btn_Save.Location = new Point(967, 8);
			btn_Save.Margin = new Padding(3, 2, 3, 2);
			btn_Save.Name = "btn_Save";
			btn_Save.Size = new Size(131, 22);
			btn_Save.TabIndex = 55;
			btn_Save.Text = "Salvar alterações";
			btn_Save.UseVisualStyleBackColor = true;
			btn_Save.Click += btn_Save_Click;
			// 
			// lbl_Separator_Vertical
			// 
			lbl_Separator_Vertical.BorderStyle = BorderStyle.Fixed3D;
			lbl_Separator_Vertical.Location = new Point(553, 32);
			lbl_Separator_Vertical.Name = "lbl_Separator_Vertical";
			lbl_Separator_Vertical.Size = new Size(2, 412);
			lbl_Separator_Vertical.TabIndex = 54;
			// 
			// btn_AddElement
			// 
			btn_AddElement.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_AddElement.Location = new Point(802, 420);
			btn_AddElement.Margin = new Padding(3, 2, 3, 2);
			btn_AddElement.Name = "btn_AddElement";
			btn_AddElement.Size = new Size(140, 22);
			btn_AddElement.TabIndex = 53;
			btn_AddElement.Text = "Selecionar vínculos...";
			btn_AddElement.UseVisualStyleBackColor = true;
			btn_AddElement.Click += btn_AddElement_Click;
			// 
			// dg_Agents
			// 
			dg_Agents.AllowUserToAddRows = false;
			dg_Agents.AllowUserToDeleteRows = false;
			dg_Agents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dg_Agents.AutoGenerateColumns = false;
			dg_Agents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_Agents.Columns.AddRange(new DataGridViewColumn[] { agentIdDataGridViewTextBoxColumn, codeDataGridViewTextBoxColumn1, nameDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn1 });
			dg_Agents.DataSource = agentBindingSource;
			dg_Agents.Location = new Point(573, 78);
			dg_Agents.Margin = new Padding(3, 2, 3, 2);
			dg_Agents.Name = "dg_Agents";
			dg_Agents.ReadOnly = true;
			dg_Agents.RowHeadersVisible = false;
			dg_Agents.RowHeadersWidth = 51;
			dg_Agents.RowTemplate.Height = 29;
			dg_Agents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_Agents.Size = new Size(504, 338);
			dg_Agents.TabIndex = 52;
			// 
			// agentBindingSource
			// 
			agentBindingSource.DataSource = typeof(Model.Agent);
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
			label2.Location = new Point(573, 58);
			label2.Name = "label2";
			label2.Size = new Size(190, 15);
			label2.TabIndex = 51;
			label2.Text = "Funções da Divisão Organizacional";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(16, 32);
			label1.Name = "label1";
			label1.Size = new Size(206, 25);
			label1.TabIndex = 50;
			label1.Text = "Divisão Organizacional";
			// 
			// dg_Organization
			// 
			dg_Organization.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			dg_Organization.AutoGenerateColumns = false;
			dg_Organization.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_Organization.Columns.AddRange(new DataGridViewColumn[] { sectorIdDataGridViewTextBoxColumn, codeDataGridViewTextBoxColumn, sectorNameDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn, responsibleAgentIdDataGridViewTextBoxColumn, superiorInstanceIdDataGridViewTextBoxColumn, superiorInstanceDataGridViewTextBoxColumn });
			dg_Organization.DataSource = organizationBindingSource;
			dg_Organization.Location = new Point(16, 66);
			dg_Organization.Margin = new Padding(3, 2, 3, 2);
			dg_Organization.Name = "dg_Organization";
			dg_Organization.RowHeadersVisible = false;
			dg_Organization.RowHeadersWidth = 51;
			dg_Organization.RowTemplate.Height = 29;
			dg_Organization.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_Organization.Size = new Size(472, 350);
			dg_Organization.TabIndex = 49;
			dg_Organization.CellClick += dg_Organization_CellClick;
			dg_Organization.CellEndEdit += dg_Organization_CellEndEdit;
			// 
			// organizationBindingSource
			// 
			organizationBindingSource.DataSource = typeof(Model.Organization);
			// 
			// sectorIdDataGridViewTextBoxColumn
			// 
			sectorIdDataGridViewTextBoxColumn.DataPropertyName = "SectorId";
			sectorIdDataGridViewTextBoxColumn.HeaderText = "SectorId";
			sectorIdDataGridViewTextBoxColumn.MinimumWidth = 6;
			sectorIdDataGridViewTextBoxColumn.Name = "sectorIdDataGridViewTextBoxColumn";
			sectorIdDataGridViewTextBoxColumn.Visible = false;
			sectorIdDataGridViewTextBoxColumn.Width = 125;
			// 
			// codeDataGridViewTextBoxColumn
			// 
			codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
			codeDataGridViewTextBoxColumn.HeaderText = "Código";
			codeDataGridViewTextBoxColumn.MinimumWidth = 6;
			codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
			codeDataGridViewTextBoxColumn.Width = 80;
			// 
			// sectorNameDataGridViewTextBoxColumn
			// 
			sectorNameDataGridViewTextBoxColumn.DataPropertyName = "SectorName";
			sectorNameDataGridViewTextBoxColumn.HeaderText = "Nome*";
			sectorNameDataGridViewTextBoxColumn.MinimumWidth = 6;
			sectorNameDataGridViewTextBoxColumn.Name = "sectorNameDataGridViewTextBoxColumn";
			sectorNameDataGridViewTextBoxColumn.Width = 400;
			// 
			// descriptionDataGridViewTextBoxColumn
			// 
			descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
			descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
			descriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
			descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
			descriptionDataGridViewTextBoxColumn.Visible = false;
			descriptionDataGridViewTextBoxColumn.Width = 125;
			// 
			// responsibleAgentIdDataGridViewTextBoxColumn
			// 
			responsibleAgentIdDataGridViewTextBoxColumn.DataPropertyName = "ResponsibleAgentId";
			responsibleAgentIdDataGridViewTextBoxColumn.HeaderText = "ResponsibleAgentId";
			responsibleAgentIdDataGridViewTextBoxColumn.MinimumWidth = 6;
			responsibleAgentIdDataGridViewTextBoxColumn.Name = "responsibleAgentIdDataGridViewTextBoxColumn";
			responsibleAgentIdDataGridViewTextBoxColumn.Visible = false;
			responsibleAgentIdDataGridViewTextBoxColumn.Width = 125;
			// 
			// superiorInstanceIdDataGridViewTextBoxColumn
			// 
			superiorInstanceIdDataGridViewTextBoxColumn.DataPropertyName = "SuperiorInstanceId";
			superiorInstanceIdDataGridViewTextBoxColumn.HeaderText = "SuperiorInstanceId";
			superiorInstanceIdDataGridViewTextBoxColumn.MinimumWidth = 6;
			superiorInstanceIdDataGridViewTextBoxColumn.Name = "superiorInstanceIdDataGridViewTextBoxColumn";
			superiorInstanceIdDataGridViewTextBoxColumn.Visible = false;
			superiorInstanceIdDataGridViewTextBoxColumn.Width = 125;
			// 
			// superiorInstanceDataGridViewTextBoxColumn
			// 
			superiorInstanceDataGridViewTextBoxColumn.DataPropertyName = "SuperiorInstance";
			superiorInstanceDataGridViewTextBoxColumn.HeaderText = "SuperiorInstance";
			superiorInstanceDataGridViewTextBoxColumn.MinimumWidth = 6;
			superiorInstanceDataGridViewTextBoxColumn.Name = "superiorInstanceDataGridViewTextBoxColumn";
			superiorInstanceDataGridViewTextBoxColumn.Visible = false;
			superiorInstanceDataGridViewTextBoxColumn.Width = 125;
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
			// codeDataGridViewTextBoxColumn1
			// 
			codeDataGridViewTextBoxColumn1.DataPropertyName = "Code";
			codeDataGridViewTextBoxColumn1.HeaderText = "Código";
			codeDataGridViewTextBoxColumn1.MinimumWidth = 6;
			codeDataGridViewTextBoxColumn1.Name = "codeDataGridViewTextBoxColumn1";
			codeDataGridViewTextBoxColumn1.ReadOnly = true;
			codeDataGridViewTextBoxColumn1.Width = 80;
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
			// descriptionDataGridViewTextBoxColumn1
			// 
			descriptionDataGridViewTextBoxColumn1.DataPropertyName = "Description";
			descriptionDataGridViewTextBoxColumn1.HeaderText = "Description";
			descriptionDataGridViewTextBoxColumn1.MinimumWidth = 6;
			descriptionDataGridViewTextBoxColumn1.Name = "descriptionDataGridViewTextBoxColumn1";
			descriptionDataGridViewTextBoxColumn1.ReadOnly = true;
			descriptionDataGridViewTextBoxColumn1.Visible = false;
			descriptionDataGridViewTextBoxColumn1.Width = 125;
			// 
			// Frm_OrganizationalDivision
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1115, 452);
			Controls.Add(btn_DeleteOrganization);
			Controls.Add(btn_DeleteElement);
			Controls.Add(lbl_SectorName);
			Controls.Add(btn_Save);
			Controls.Add(lbl_Separator_Vertical);
			Controls.Add(btn_AddElement);
			Controls.Add(dg_Agents);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(dg_Organization);
			Name = "Frm_OrganizationalDivision";
			Text = "Divisão Organizacional";
			Load += Frm_OrganizationalDivision_Load;
			((System.ComponentModel.ISupportInitialize)dg_Agents).EndInit();
			((System.ComponentModel.ISupportInitialize)agentBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)dg_Organization).EndInit();
			((System.ComponentModel.ISupportInitialize)organizationBindingSource).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btn_DeleteOrganization;
		private Button btn_DeleteElement;
		private Label lbl_SectorName;
		private Button btn_Save;
		private Label lbl_Separator_Vertical;
		private Button btn_AddElement;
		private DataGridView dg_Agents;
		private Label label2;
		private Label label1;
		private DataGridView dg_Organization;
		private BindingSource organizationBindingSource;
		private BindingSource agentBindingSource;
		private DataGridViewTextBoxColumn sectorIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn sectorNameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn responsibleAgentIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn superiorInstanceIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn superiorInstanceDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn agentIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn1;
	}
}