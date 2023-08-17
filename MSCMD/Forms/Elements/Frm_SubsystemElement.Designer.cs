namespace MSCMD.Forms.Elements
{
	partial class Frm_SubsystemElement
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
			dg_Elements = new DataGridView();
			elementIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			codeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			typeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			externalIdentifierDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			componentClassDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			organizationIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			ocupiedByDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			surfaceTypeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			elementBindingSource = new BindingSource(components);
			lbl_Name = new Label();
			lbl_Code = new Label();
			lbl_Subsystem = new Label();
			btn_CloseForm = new Button();
			label3 = new Label();
			btn_Clean = new Button();
			btn_Search = new Button();
			txt_Search = new TextBox();
			((System.ComponentModel.ISupportInitialize)dg_Elements).BeginInit();
			((System.ComponentModel.ISupportInitialize)elementBindingSource).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(31, 133);
			label1.Name = "label1";
			label1.Size = new Size(168, 20);
			label1.TabIndex = 36;
			label1.Text = "Selecione os elementos:";
			// 
			// btn_Save
			// 
			btn_Save.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_Save.Location = new Point(695, 557);
			btn_Save.Name = "btn_Save";
			btn_Save.Size = new Size(94, 29);
			btn_Save.TabIndex = 35;
			btn_Save.Text = "Vincular";
			btn_Save.UseVisualStyleBackColor = true;
			btn_Save.Click += btn_Save_Click;
			// 
			// dg_Elements
			// 
			dg_Elements.AllowUserToAddRows = false;
			dg_Elements.AllowUserToDeleteRows = false;
			dg_Elements.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dg_Elements.AutoGenerateColumns = false;
			dg_Elements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_Elements.Columns.AddRange(new DataGridViewColumn[] { elementIdDataGridViewTextBoxColumn, codeDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, typeDataGridViewTextBoxColumn, externalIdentifierDataGridViewTextBoxColumn, componentClassDataGridViewTextBoxColumn, organizationIdDataGridViewTextBoxColumn, ocupiedByDataGridViewTextBoxColumn, surfaceTypeDataGridViewTextBoxColumn });
			dg_Elements.DataSource = elementBindingSource;
			dg_Elements.Location = new Point(29, 156);
			dg_Elements.Name = "dg_Elements";
			dg_Elements.ReadOnly = true;
			dg_Elements.RowHeadersVisible = false;
			dg_Elements.RowHeadersWidth = 51;
			dg_Elements.RowTemplate.Height = 29;
			dg_Elements.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_Elements.Size = new Size(859, 395);
			dg_Elements.TabIndex = 34;
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
			nameDataGridViewTextBoxColumn.Width = 500;
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
			// elementBindingSource
			// 
			elementBindingSource.DataSource = typeof(Model.Element);
			// 
			// lbl_Name
			// 
			lbl_Name.AutoSize = true;
			lbl_Name.Location = new Point(31, 79);
			lbl_Name.Name = "lbl_Name";
			lbl_Name.Size = new Size(137, 20);
			lbl_Name.TabIndex = 33;
			lbl_Name.Text = "Nome da atividade";
			// 
			// lbl_Code
			// 
			lbl_Code.AutoSize = true;
			lbl_Code.Location = new Point(29, 51);
			lbl_Code.Name = "lbl_Code";
			lbl_Code.Size = new Size(56, 20);
			lbl_Code.TabIndex = 32;
			lbl_Code.Text = "codigo";
			// 
			// lbl_Subsystem
			// 
			lbl_Subsystem.AutoSize = true;
			lbl_Subsystem.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_Subsystem.Location = new Point(25, 15);
			lbl_Subsystem.Name = "lbl_Subsystem";
			lbl_Subsystem.Size = new Size(135, 32);
			lbl_Subsystem.TabIndex = 31;
			lbl_Subsystem.Text = "Subsistema";
			// 
			// btn_CloseForm
			// 
			btn_CloseForm.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_CloseForm.Location = new Point(795, 557);
			btn_CloseForm.Name = "btn_CloseForm";
			btn_CloseForm.Size = new Size(94, 29);
			btn_CloseForm.TabIndex = 37;
			btn_CloseForm.Text = "Fechar";
			btn_CloseForm.UseVisualStyleBackColor = true;
			btn_CloseForm.Click += btn_CloseForm_Click;
			// 
			// label3
			// 
			label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			label3.AutoSize = true;
			label3.Location = new Point(483, 74);
			label3.Name = "label3";
			label3.Size = new Size(196, 20);
			label3.TabIndex = 52;
			label3.Text = "Buscar por código ou nome:";
			// 
			// btn_Clean
			// 
			btn_Clean.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btn_Clean.Location = new Point(799, 98);
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
			btn_Search.Location = new Point(719, 98);
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
			txt_Search.Location = new Point(483, 101);
			txt_Search.Margin = new Padding(3, 4, 3, 4);
			txt_Search.Name = "txt_Search";
			txt_Search.Size = new Size(229, 27);
			txt_Search.TabIndex = 49;
			txt_Search.KeyUp += txt_Search_KeyUp;
			// 
			// Frm_SubsystemElement
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(914, 600);
			Controls.Add(label3);
			Controls.Add(btn_Clean);
			Controls.Add(btn_Search);
			Controls.Add(txt_Search);
			Controls.Add(btn_CloseForm);
			Controls.Add(label1);
			Controls.Add(btn_Save);
			Controls.Add(dg_Elements);
			Controls.Add(lbl_Name);
			Controls.Add(lbl_Code);
			Controls.Add(lbl_Subsystem);
			MinimumSize = new Size(800, 0);
			Name = "Frm_SubsystemElement";
			Text = "Vincular Conjunto de Elementos";
			Load += Frm_SubsystemElement_Load;
			((System.ComponentModel.ISupportInitialize)dg_Elements).EndInit();
			((System.ComponentModel.ISupportInitialize)elementBindingSource).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Button btn_Save;
		private DataGridView dg_Elements;
		private BindingSource elementBindingSource;
		private Label lbl_Name;
		private Label lbl_Code;
		private Label lbl_Subsystem;
		private Button btn_CloseForm;
		private DataGridViewTextBoxColumn elementIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn externalIdentifierDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn componentClassDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn organizationIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn ocupiedByDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn surfaceTypeDataGridViewTextBoxColumn;
		private Label label3;
		private Button btn_Clean;
		private Button btn_Search;
		private TextBox txt_Search;
	}
}