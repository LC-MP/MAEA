namespace MSCMD.Forms.Activities
{
	partial class Frm_ActivityElementRelationship
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
			dg_Element = new DataGridView();
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
			lbl_Funcao = new Label();
			cb_Relation = new ComboBox();
			cb_AcessType = new ComboBox();
			label2 = new Label();
			label3 = new Label();
			btn_Close = new Button();
			label4 = new Label();
			btn_Clean = new Button();
			btn_Search = new Button();
			txt_Search = new TextBox();
			((System.ComponentModel.ISupportInitialize)dg_Element).BeginInit();
			((System.ComponentModel.ISupportInitialize)elementBindingSource).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(29, 175);
			label1.Name = "label1";
			label1.Size = new Size(904, 20);
			label1.TabIndex = 24;
			label1.Text = "Elemento relacionado: (use CTRL para selecionar mais de uma linha, use SHIFT e clique em duas linhas para selecionar todas entre elas)";
			// 
			// btn_Save
			// 
			btn_Save.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_Save.Location = new Point(730, 556);
			btn_Save.Name = "btn_Save";
			btn_Save.Size = new Size(125, 29);
			btn_Save.TabIndex = 23;
			btn_Save.Text = "Vincular";
			btn_Save.UseVisualStyleBackColor = true;
			btn_Save.Click += btn_Save_Click;
			// 
			// dg_Element
			// 
			dg_Element.AllowUserToAddRows = false;
			dg_Element.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dg_Element.AutoGenerateColumns = false;
			dg_Element.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_Element.Columns.AddRange(new DataGridViewColumn[] { elementIdDataGridViewTextBoxColumn, codeDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, typeDataGridViewTextBoxColumn, externalIdentifierDataGridViewTextBoxColumn, componentClassDataGridViewTextBoxColumn, organizationIdDataGridViewTextBoxColumn, ocupiedByDataGridViewTextBoxColumn, surfaceTypeDataGridViewTextBoxColumn });
			dg_Element.DataSource = elementBindingSource;
			dg_Element.Location = new Point(29, 197);
			dg_Element.Name = "dg_Element";
			dg_Element.ReadOnly = true;
			dg_Element.RowHeadersVisible = false;
			dg_Element.RowHeadersWidth = 51;
			dg_Element.RowTemplate.Height = 29;
			dg_Element.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_Element.Size = new Size(931, 352);
			dg_Element.TabIndex = 22;
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
			nameDataGridViewTextBoxColumn.Width = 450;
			// 
			// typeDataGridViewTextBoxColumn
			// 
			typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
			typeDataGridViewTextBoxColumn.HeaderText = "Tipo";
			typeDataGridViewTextBoxColumn.MinimumWidth = 6;
			typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
			typeDataGridViewTextBoxColumn.ReadOnly = true;
			typeDataGridViewTextBoxColumn.Width = 300;
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
			lbl_Name.TabIndex = 21;
			lbl_Name.Text = "Nome da atividade";
			// 
			// lbl_Code
			// 
			lbl_Code.AutoSize = true;
			lbl_Code.Location = new Point(29, 51);
			lbl_Code.Name = "lbl_Code";
			lbl_Code.Size = new Size(56, 20);
			lbl_Code.TabIndex = 20;
			lbl_Code.Text = "codigo";
			// 
			// lbl_Funcao
			// 
			lbl_Funcao.AutoSize = true;
			lbl_Funcao.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_Funcao.Location = new Point(25, 15);
			lbl_Funcao.Name = "lbl_Funcao";
			lbl_Funcao.Size = new Size(114, 32);
			lbl_Funcao.TabIndex = 19;
			lbl_Funcao.Text = "Atividade";
			// 
			// cb_Relation
			// 
			cb_Relation.DropDownStyle = ComboBoxStyle.DropDownList;
			cb_Relation.FormattingEnabled = true;
			cb_Relation.Location = new Point(30, 131);
			cb_Relation.Name = "cb_Relation";
			cb_Relation.Size = new Size(229, 28);
			cb_Relation.TabIndex = 25;
			// 
			// cb_AcessType
			// 
			cb_AcessType.DropDownStyle = ComboBoxStyle.DropDownList;
			cb_AcessType.FormattingEnabled = true;
			cb_AcessType.Location = new Point(275, 132);
			cb_AcessType.Name = "cb_AcessType";
			cb_AcessType.Size = new Size(230, 28);
			cb_AcessType.TabIndex = 26;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(30, 107);
			label2.Name = "label2";
			label2.Size = new Size(65, 20);
			label2.TabIndex = 27;
			label2.Text = "Relação:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(275, 107);
			label3.Name = "label3";
			label3.Size = new Size(199, 20);
			label3.TabIndex = 28;
			label3.Text = "Tipo de acesso ao elemento:";
			// 
			// btn_Close
			// 
			btn_Close.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_Close.Location = new Point(859, 556);
			btn_Close.Name = "btn_Close";
			btn_Close.Size = new Size(101, 29);
			btn_Close.TabIndex = 34;
			btn_Close.Text = "Fechar";
			btn_Close.UseVisualStyleBackColor = true;
			btn_Close.Click += btn_Close_Click;
			// 
			// label4
			// 
			label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			label4.AutoSize = true;
			label4.Location = new Point(584, 106);
			label4.Name = "label4";
			label4.Size = new Size(196, 20);
			label4.TabIndex = 44;
			label4.Text = "Buscar por código ou nome:";
			// 
			// btn_Clean
			// 
			btn_Clean.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btn_Clean.Location = new Point(894, 130);
			btn_Clean.Margin = new Padding(3, 4, 3, 4);
			btn_Clean.Name = "btn_Clean";
			btn_Clean.Size = new Size(64, 31);
			btn_Clean.TabIndex = 43;
			btn_Clean.Text = "Limpar";
			btn_Clean.UseVisualStyleBackColor = true;
			btn_Clean.Click += btn_Clean_Click;
			// 
			// btn_Search
			// 
			btn_Search.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btn_Search.Location = new Point(820, 130);
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
			txt_Search.Location = new Point(586, 133);
			txt_Search.Margin = new Padding(3, 4, 3, 4);
			txt_Search.Name = "txt_Search";
			txt_Search.Size = new Size(229, 27);
			txt_Search.TabIndex = 41;
			txt_Search.KeyUp += txt_Search_KeyUp;
			// 
			// Frm_ActivityElementRelationship
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(986, 600);
			Controls.Add(label4);
			Controls.Add(btn_Clean);
			Controls.Add(btn_Search);
			Controls.Add(txt_Search);
			Controls.Add(btn_Close);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(cb_AcessType);
			Controls.Add(cb_Relation);
			Controls.Add(label1);
			Controls.Add(btn_Save);
			Controls.Add(dg_Element);
			Controls.Add(lbl_Name);
			Controls.Add(lbl_Code);
			Controls.Add(lbl_Funcao);
			MinimumSize = new Size(950, 0);
			Name = "Frm_ActivityElementRelationship";
			Text = "Vincular Elemento";
			Load += Frm_ActivityElementRelationship_Load;
			((System.ComponentModel.ISupportInitialize)dg_Element).EndInit();
			((System.ComponentModel.ISupportInitialize)elementBindingSource).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Button btn_Save;
		private DataGridView dg_Element;
		private Label lbl_Name;
		private Label lbl_Code;
		private Label lbl_Funcao;
		private BindingSource elementBindingSource;
		private ComboBox cb_Relation;
		private ComboBox cb_AcessType;
		private Label label2;
		private Label label3;
		private Button btn_Close;
		private DataGridViewTextBoxColumn elementIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn externalIdentifierDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn componentClassDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn organizationIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn ocupiedByDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn surfaceTypeDataGridViewTextBoxColumn;
		private Label label4;
		private Button btn_Clean;
		private Button btn_Search;
		private TextBox txt_Search;
	}
}