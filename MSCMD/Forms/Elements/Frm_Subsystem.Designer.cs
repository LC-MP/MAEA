namespace MSCMD.Forms.Elements
{
	partial class Frm_Subsystem
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
			lbl_SubsystemName = new Label();
			btn_SaveSubsystems = new Button();
			lbl_Separator_Vertical = new Label();
			btn_AddElement = new Button();
			dg_Elements = new DataGridView();
			elementBindingSource = new BindingSource(components);
			label2 = new Label();
			label1 = new Label();
			dg_Subsystem = new DataGridView();
			subsystemIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			codeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			subsystemBindingSource = new BindingSource(components);
			btn_DeleteElement = new Button();
			btn_DeleteSubsystem = new Button();
			elementIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			codeDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			nameDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			typeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			externalIdentifierDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			componentClassDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			organizationIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			ocupiedByDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			surfaceTypeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)dg_Elements).BeginInit();
			((System.ComponentModel.ISupportInitialize)elementBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)dg_Subsystem).BeginInit();
			((System.ComponentModel.ISupportInitialize)subsystemBindingSource).BeginInit();
			SuspendLayout();
			// 
			// lbl_SubsystemName
			// 
			lbl_SubsystemName.AutoSize = true;
			lbl_SubsystemName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_SubsystemName.Location = new Point(584, 29);
			lbl_SubsystemName.Name = "lbl_SubsystemName";
			lbl_SubsystemName.Size = new Size(52, 21);
			lbl_SubsystemName.TabIndex = 46;
			lbl_SubsystemName.Text = "label3";
			// 
			// btn_SaveSubsystems
			// 
			btn_SaveSubsystems.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btn_SaveSubsystems.Location = new Point(978, 4);
			btn_SaveSubsystems.Margin = new Padding(3, 2, 3, 2);
			btn_SaveSubsystems.Name = "btn_SaveSubsystems";
			btn_SaveSubsystems.Size = new Size(131, 22);
			btn_SaveSubsystems.TabIndex = 45;
			btn_SaveSubsystems.Text = "Salvar alterações";
			btn_SaveSubsystems.UseVisualStyleBackColor = true;
			btn_SaveSubsystems.Click += btn_SaveSubsystems_Click;
			// 
			// lbl_Separator_Vertical
			// 
			lbl_Separator_Vertical.BorderStyle = BorderStyle.Fixed3D;
			lbl_Separator_Vertical.Location = new Point(564, 28);
			lbl_Separator_Vertical.Name = "lbl_Separator_Vertical";
			lbl_Separator_Vertical.Size = new Size(2, 412);
			lbl_Separator_Vertical.TabIndex = 44;
			// 
			// btn_AddElement
			// 
			btn_AddElement.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_AddElement.Location = new Point(797, 417);
			btn_AddElement.Margin = new Padding(3, 2, 3, 2);
			btn_AddElement.Name = "btn_AddElement";
			btn_AddElement.Size = new Size(153, 22);
			btn_AddElement.TabIndex = 43;
			btn_AddElement.Text = "Selecionar vínculos...";
			btn_AddElement.UseVisualStyleBackColor = true;
			btn_AddElement.Click += btn_AddElement_Click;
			// 
			// dg_Elements
			// 
			dg_Elements.AllowUserToAddRows = false;
			dg_Elements.AllowUserToDeleteRows = false;
			dg_Elements.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dg_Elements.AutoGenerateColumns = false;
			dg_Elements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_Elements.Columns.AddRange(new DataGridViewColumn[] { elementIdDataGridViewTextBoxColumn, codeDataGridViewTextBoxColumn1, nameDataGridViewTextBoxColumn1, typeDataGridViewTextBoxColumn, externalIdentifierDataGridViewTextBoxColumn, componentClassDataGridViewTextBoxColumn, organizationIdDataGridViewTextBoxColumn, ocupiedByDataGridViewTextBoxColumn, surfaceTypeDataGridViewTextBoxColumn });
			dg_Elements.DataSource = elementBindingSource;
			dg_Elements.Location = new Point(584, 74);
			dg_Elements.Margin = new Padding(3, 2, 3, 2);
			dg_Elements.Name = "dg_Elements";
			dg_Elements.ReadOnly = true;
			dg_Elements.RowHeadersVisible = false;
			dg_Elements.RowHeadersWidth = 51;
			dg_Elements.RowTemplate.Height = 29;
			dg_Elements.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_Elements.Size = new Size(504, 338);
			dg_Elements.TabIndex = 42;
			// 
			// elementBindingSource
			// 
			elementBindingSource.DataSource = typeof(Model.Element);
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
			label2.Location = new Point(584, 54);
			label2.Name = "label2";
			label2.Size = new Size(141, 15);
			label2.TabIndex = 41;
			label2.Text = "Elementos do subsistema";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(27, 28);
			label1.Name = "label1";
			label1.Size = new Size(194, 25);
			label1.TabIndex = 40;
			label1.Text = "Subsistemas / Setores";
			// 
			// dg_Subsystem
			// 
			dg_Subsystem.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			dg_Subsystem.AutoGenerateColumns = false;
			dg_Subsystem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_Subsystem.Columns.AddRange(new DataGridViewColumn[] { subsystemIdDataGridViewTextBoxColumn, codeDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn });
			dg_Subsystem.DataSource = subsystemBindingSource;
			dg_Subsystem.Location = new Point(27, 62);
			dg_Subsystem.Margin = new Padding(3, 2, 3, 2);
			dg_Subsystem.Name = "dg_Subsystem";
			dg_Subsystem.RowHeadersVisible = false;
			dg_Subsystem.RowHeadersWidth = 51;
			dg_Subsystem.RowTemplate.Height = 29;
			dg_Subsystem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_Subsystem.Size = new Size(472, 350);
			dg_Subsystem.TabIndex = 39;
			dg_Subsystem.CellClick += dg_Subprocesses_CellClick;
			dg_Subsystem.CellEndEdit += dg_Subsystem_CellEndEdit;
			// 
			// subsystemIdDataGridViewTextBoxColumn
			// 
			subsystemIdDataGridViewTextBoxColumn.DataPropertyName = "SubsystemId";
			subsystemIdDataGridViewTextBoxColumn.HeaderText = "Id";
			subsystemIdDataGridViewTextBoxColumn.MinimumWidth = 6;
			subsystemIdDataGridViewTextBoxColumn.Name = "subsystemIdDataGridViewTextBoxColumn";
			subsystemIdDataGridViewTextBoxColumn.Visible = false;
			subsystemIdDataGridViewTextBoxColumn.Width = 50;
			// 
			// codeDataGridViewTextBoxColumn
			// 
			codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
			codeDataGridViewTextBoxColumn.HeaderText = "Código";
			codeDataGridViewTextBoxColumn.MinimumWidth = 6;
			codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
			codeDataGridViewTextBoxColumn.Width = 80;
			// 
			// nameDataGridViewTextBoxColumn
			// 
			nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
			nameDataGridViewTextBoxColumn.HeaderText = "Nome*";
			nameDataGridViewTextBoxColumn.MinimumWidth = 6;
			nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			nameDataGridViewTextBoxColumn.Width = 430;
			// 
			// subsystemBindingSource
			// 
			subsystemBindingSource.DataSource = typeof(Model.Subsystem);
			// 
			// btn_DeleteElement
			// 
			btn_DeleteElement.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_DeleteElement.Location = new Point(956, 417);
			btn_DeleteElement.Margin = new Padding(3, 2, 3, 2);
			btn_DeleteElement.Name = "btn_DeleteElement";
			btn_DeleteElement.Size = new Size(132, 22);
			btn_DeleteElement.TabIndex = 47;
			btn_DeleteElement.Text = "Desvincular seleção";
			btn_DeleteElement.UseVisualStyleBackColor = true;
			btn_DeleteElement.Click += btn_DeleteElement_Click;
			// 
			// btn_DeleteSubsystem
			// 
			btn_DeleteSubsystem.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btn_DeleteSubsystem.Location = new Point(359, 418);
			btn_DeleteSubsystem.Margin = new Padding(3, 2, 3, 2);
			btn_DeleteSubsystem.Name = "btn_DeleteSubsystem";
			btn_DeleteSubsystem.Size = new Size(140, 22);
			btn_DeleteSubsystem.TabIndex = 48;
			btn_DeleteSubsystem.Text = "Deletar seleção";
			btn_DeleteSubsystem.UseVisualStyleBackColor = true;
			btn_DeleteSubsystem.Click += btn_DeleteSubsystem_Click;
			// 
			// elementIdDataGridViewTextBoxColumn
			// 
			elementIdDataGridViewTextBoxColumn.DataPropertyName = "ElementId";
			elementIdDataGridViewTextBoxColumn.HeaderText = "Id";
			elementIdDataGridViewTextBoxColumn.MinimumWidth = 6;
			elementIdDataGridViewTextBoxColumn.Name = "elementIdDataGridViewTextBoxColumn";
			elementIdDataGridViewTextBoxColumn.ReadOnly = true;
			elementIdDataGridViewTextBoxColumn.Width = 50;
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
			// nameDataGridViewTextBoxColumn1
			// 
			nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
			nameDataGridViewTextBoxColumn1.HeaderText = "Nome do Elemento";
			nameDataGridViewTextBoxColumn1.MinimumWidth = 6;
			nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
			nameDataGridViewTextBoxColumn1.ReadOnly = true;
			nameDataGridViewTextBoxColumn1.Width = 400;
			// 
			// typeDataGridViewTextBoxColumn
			// 
			typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
			typeDataGridViewTextBoxColumn.HeaderText = "Type";
			typeDataGridViewTextBoxColumn.MinimumWidth = 6;
			typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
			typeDataGridViewTextBoxColumn.ReadOnly = true;
			typeDataGridViewTextBoxColumn.Visible = false;
			typeDataGridViewTextBoxColumn.Width = 125;
			// 
			// externalIdentifierDataGridViewTextBoxColumn
			// 
			externalIdentifierDataGridViewTextBoxColumn.DataPropertyName = "ExternalIdentifier";
			externalIdentifierDataGridViewTextBoxColumn.HeaderText = "ExternalIdentifier";
			externalIdentifierDataGridViewTextBoxColumn.MinimumWidth = 6;
			externalIdentifierDataGridViewTextBoxColumn.Name = "externalIdentifierDataGridViewTextBoxColumn";
			externalIdentifierDataGridViewTextBoxColumn.ReadOnly = true;
			externalIdentifierDataGridViewTextBoxColumn.Visible = false;
			externalIdentifierDataGridViewTextBoxColumn.Width = 125;
			// 
			// componentClassDataGridViewTextBoxColumn
			// 
			componentClassDataGridViewTextBoxColumn.DataPropertyName = "ComponentClass";
			componentClassDataGridViewTextBoxColumn.HeaderText = "ComponentClass";
			componentClassDataGridViewTextBoxColumn.MinimumWidth = 6;
			componentClassDataGridViewTextBoxColumn.Name = "componentClassDataGridViewTextBoxColumn";
			componentClassDataGridViewTextBoxColumn.ReadOnly = true;
			componentClassDataGridViewTextBoxColumn.Visible = false;
			componentClassDataGridViewTextBoxColumn.Width = 125;
			// 
			// organizationIdDataGridViewTextBoxColumn
			// 
			organizationIdDataGridViewTextBoxColumn.DataPropertyName = "OrganizationId";
			organizationIdDataGridViewTextBoxColumn.HeaderText = "OrganizationId";
			organizationIdDataGridViewTextBoxColumn.MinimumWidth = 6;
			organizationIdDataGridViewTextBoxColumn.Name = "organizationIdDataGridViewTextBoxColumn";
			organizationIdDataGridViewTextBoxColumn.ReadOnly = true;
			organizationIdDataGridViewTextBoxColumn.Visible = false;
			organizationIdDataGridViewTextBoxColumn.Width = 125;
			// 
			// ocupiedByDataGridViewTextBoxColumn
			// 
			ocupiedByDataGridViewTextBoxColumn.DataPropertyName = "OcupiedBy";
			ocupiedByDataGridViewTextBoxColumn.HeaderText = "OcupiedBy";
			ocupiedByDataGridViewTextBoxColumn.MinimumWidth = 6;
			ocupiedByDataGridViewTextBoxColumn.Name = "ocupiedByDataGridViewTextBoxColumn";
			ocupiedByDataGridViewTextBoxColumn.ReadOnly = true;
			ocupiedByDataGridViewTextBoxColumn.Visible = false;
			ocupiedByDataGridViewTextBoxColumn.Width = 125;
			// 
			// surfaceTypeDataGridViewTextBoxColumn
			// 
			surfaceTypeDataGridViewTextBoxColumn.DataPropertyName = "SurfaceType";
			surfaceTypeDataGridViewTextBoxColumn.HeaderText = "SurfaceType";
			surfaceTypeDataGridViewTextBoxColumn.MinimumWidth = 6;
			surfaceTypeDataGridViewTextBoxColumn.Name = "surfaceTypeDataGridViewTextBoxColumn";
			surfaceTypeDataGridViewTextBoxColumn.ReadOnly = true;
			surfaceTypeDataGridViewTextBoxColumn.Visible = false;
			surfaceTypeDataGridViewTextBoxColumn.Width = 125;
			// 
			// Frm_Subsystem
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1115, 452);
			Controls.Add(btn_DeleteSubsystem);
			Controls.Add(btn_DeleteElement);
			Controls.Add(lbl_SubsystemName);
			Controls.Add(btn_SaveSubsystems);
			Controls.Add(lbl_Separator_Vertical);
			Controls.Add(btn_AddElement);
			Controls.Add(dg_Elements);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(dg_Subsystem);
			Margin = new Padding(3, 2, 3, 2);
			Name = "Frm_Subsystem";
			Text = "Subsistemas";
			Load += Frm_Subsystem_Load;
			((System.ComponentModel.ISupportInitialize)dg_Elements).EndInit();
			((System.ComponentModel.ISupportInitialize)elementBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)dg_Subsystem).EndInit();
			((System.ComponentModel.ISupportInitialize)subsystemBindingSource).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lbl_SubsystemName;
		private Button btn_SaveSubsystems;
		private Label lbl_Separator_Vertical;
		private Button btn_AddElement;
		private DataGridView dg_Elements;
		private BindingSource elementBindingSource;
		private Label label2;
		private Label label1;
		private DataGridView dg_Subsystem;
		private BindingSource subsystemBindingSource;
		private Button btn_DeleteElement;
		private Button btn_DeleteSubsystem;
		private DataGridViewTextBoxColumn subsystemIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn elementIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn externalIdentifierDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn componentClassDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn organizationIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn ocupiedByDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn surfaceTypeDataGridViewTextBoxColumn;
	}
}