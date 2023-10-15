namespace MSCMD.Forms
{
	partial class Frm_ElementElementRelationship
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
			lbl_Codigo = new Label();
			lbl_NomeElemento = new Label();
			cb_Relacao = new ComboBox();
			lbl_Relacao = new Label();
			dg_Elementos = new DataGridView();
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
			btn_Vincular = new Button();
			label2 = new Label();
			btn_Close = new Button();
			label3 = new Label();
			btn_Clean = new Button();
			btn_Search = new Button();
			txt_Search = new TextBox();
			((System.ComponentModel.ISupportInitialize)dg_Elementos).BeginInit();
			((System.ComponentModel.ISupportInitialize)elementBindingSource).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(23, 20);
			label1.Name = "label1";
			label1.Size = new Size(98, 28);
			label1.TabIndex = 0;
			label1.Text = "Elemento:";
			// 
			// lbl_Codigo
			// 
			lbl_Codigo.AutoSize = true;
			lbl_Codigo.Location = new Point(29, 51);
			lbl_Codigo.Name = "lbl_Codigo";
			lbl_Codigo.Size = new Size(61, 20);
			lbl_Codigo.TabIndex = 1;
			lbl_Codigo.Text = "Código:";
			// 
			// lbl_NomeElemento
			// 
			lbl_NomeElemento.AutoSize = true;
			lbl_NomeElemento.Location = new Point(29, 71);
			lbl_NomeElemento.Name = "lbl_NomeElemento";
			lbl_NomeElemento.Size = new Size(139, 20);
			lbl_NomeElemento.TabIndex = 2;
			lbl_NomeElemento.Text = "Nome do Elemento";
			// 
			// cb_Relacao
			// 
			cb_Relacao.DropDownStyle = ComboBoxStyle.DropDownList;
			cb_Relacao.FormattingEnabled = true;
			cb_Relacao.Location = new Point(29, 133);
			cb_Relacao.Margin = new Padding(3, 4, 3, 4);
			cb_Relacao.Name = "cb_Relacao";
			cb_Relacao.Size = new Size(221, 28);
			cb_Relacao.TabIndex = 3;
			// 
			// lbl_Relacao
			// 
			lbl_Relacao.AutoSize = true;
			lbl_Relacao.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_Relacao.Location = new Point(26, 107);
			lbl_Relacao.Name = "lbl_Relacao";
			lbl_Relacao.Size = new Size(160, 23);
			lbl_Relacao.TabIndex = 4;
			lbl_Relacao.Text = "Selecione a relação:";
			// 
			// dg_Elementos
			// 
			dg_Elementos.AllowUserToAddRows = false;
			dg_Elementos.AllowUserToDeleteRows = false;
			dg_Elementos.AllowUserToResizeRows = false;
			dg_Elementos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dg_Elementos.AutoGenerateColumns = false;
			dg_Elementos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_Elementos.Columns.AddRange(new DataGridViewColumn[] { elementIdDataGridViewTextBoxColumn, codeDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, typeDataGridViewTextBoxColumn, externalIdentifierDataGridViewTextBoxColumn, componentClassDataGridViewTextBoxColumn, organizationIdDataGridViewTextBoxColumn, ocupiedByDataGridViewTextBoxColumn, surfaceTypeDataGridViewTextBoxColumn });
			dg_Elementos.DataSource = elementBindingSource;
			dg_Elementos.Location = new Point(29, 200);
			dg_Elementos.Margin = new Padding(3, 4, 3, 4);
			dg_Elementos.Name = "dg_Elementos";
			dg_Elementos.ReadOnly = true;
			dg_Elementos.RowHeadersVisible = false;
			dg_Elementos.RowHeadersWidth = 51;
			dg_Elementos.RowTemplate.Height = 25;
			dg_Elementos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_Elementos.Size = new Size(923, 348);
			dg_Elementos.TabIndex = 5;
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
			nameDataGridViewTextBoxColumn.Width = 300;
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
			// externalIdentifierDataGridViewTextBoxColumn
			// 
			externalIdentifierDataGridViewTextBoxColumn.DataPropertyName = "ExternalIdentifier";
			externalIdentifierDataGridViewTextBoxColumn.HeaderText = "Identificador externo";
			externalIdentifierDataGridViewTextBoxColumn.MinimumWidth = 6;
			externalIdentifierDataGridViewTextBoxColumn.Name = "externalIdentifierDataGridViewTextBoxColumn";
			externalIdentifierDataGridViewTextBoxColumn.ReadOnly = true;
			externalIdentifierDataGridViewTextBoxColumn.Width = 125;
			// 
			// componentClassDataGridViewTextBoxColumn
			// 
			componentClassDataGridViewTextBoxColumn.DataPropertyName = "ComponentClass";
			componentClassDataGridViewTextBoxColumn.HeaderText = "Classe";
			componentClassDataGridViewTextBoxColumn.MinimumWidth = 6;
			componentClassDataGridViewTextBoxColumn.Name = "componentClassDataGridViewTextBoxColumn";
			componentClassDataGridViewTextBoxColumn.ReadOnly = true;
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
			surfaceTypeDataGridViewTextBoxColumn.HeaderText = "Tipo de superfície";
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
			// btn_Vincular
			// 
			btn_Vincular.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_Vincular.Location = new Point(711, 556);
			btn_Vincular.Margin = new Padding(3, 4, 3, 4);
			btn_Vincular.Name = "btn_Vincular";
			btn_Vincular.Size = new Size(134, 31);
			btn_Vincular.TabIndex = 6;
			btn_Vincular.Text = "Vincular";
			btn_Vincular.UseVisualStyleBackColor = true;
			btn_Vincular.Click += btn_Vincular_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
			label2.Location = new Point(29, 176);
			label2.Name = "label2";
			label2.Size = new Size(914, 20);
			label2.TabIndex = 7;
			label2.Text = "Selecione os elementos: (use CTRL para selecionar mais de uma linha, use SHIFT e clique em duas linhas para selecionar todas entre elas)";
			// 
			// btn_Close
			// 
			btn_Close.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_Close.Location = new Point(851, 556);
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
			label3.Location = new Point(550, 106);
			label3.Name = "label3";
			label3.Size = new Size(196, 20);
			label3.TabIndex = 48;
			label3.Text = "Buscar por código ou nome:";
			label3.Click += label3_Click;
			// 
			// btn_Clean
			// 
			btn_Clean.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btn_Clean.Location = new Point(866, 130);
			btn_Clean.Margin = new Padding(3, 4, 3, 4);
			btn_Clean.Name = "btn_Clean";
			btn_Clean.Size = new Size(86, 31);
			btn_Clean.TabIndex = 47;
			btn_Clean.Text = "Limpar";
			btn_Clean.UseVisualStyleBackColor = true;
			btn_Clean.Click += btn_Clean_Click;
			// 
			// btn_Search
			// 
			btn_Search.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btn_Search.Location = new Point(786, 130);
			btn_Search.Margin = new Padding(3, 4, 3, 4);
			btn_Search.Name = "btn_Search";
			btn_Search.Size = new Size(73, 31);
			btn_Search.TabIndex = 46;
			btn_Search.Text = "Buscar";
			btn_Search.UseVisualStyleBackColor = true;
			btn_Search.Click += btn_Search_Click;
			// 
			// txt_Search
			// 
			txt_Search.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			txt_Search.BorderStyle = BorderStyle.FixedSingle;
			txt_Search.Location = new Point(550, 133);
			txt_Search.Margin = new Padding(3, 4, 3, 4);
			txt_Search.Name = "txt_Search";
			txt_Search.Size = new Size(229, 27);
			txt_Search.TabIndex = 45;
			txt_Search.TextChanged += txt_Search_TextChanged;
			txt_Search.KeyUp += txt_Search_KeyUp;
			// 
			// Frm_ElementElementRelationship
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(974, 600);
			Controls.Add(label3);
			Controls.Add(btn_Clean);
			Controls.Add(btn_Search);
			Controls.Add(txt_Search);
			Controls.Add(btn_Close);
			Controls.Add(label2);
			Controls.Add(btn_Vincular);
			Controls.Add(dg_Elementos);
			Controls.Add(lbl_Relacao);
			Controls.Add(cb_Relacao);
			Controls.Add(lbl_NomeElemento);
			Controls.Add(lbl_Codigo);
			Controls.Add(label1);
			Margin = new Padding(3, 4, 3, 4);
			Name = "Frm_ElementElementRelationship";
			Text = "Vincular Elemento";
			Load += Frm_VinculoElementoElemento_Load;
			((System.ComponentModel.ISupportInitialize)dg_Elementos).EndInit();
			((System.ComponentModel.ISupportInitialize)elementBindingSource).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label lbl_Codigo;
		private Label lbl_NomeElemento;
		private ComboBox cb_Relacao;
		private Label lbl_Relacao;
		private DataGridView dg_Elementos;
		private DataGridViewTextBoxColumn idElementoDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn codElementoDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn nomeDoElementoDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn tipoDeElementoDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn identificadorExternoElementoDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn classeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn organizacaoIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn ocupadoPorDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn tipoSuperficieDataGridViewTextBoxColumn;
		private Button btn_Vincular;
		private BindingSource elementBindingSource;
		private Label label2;
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
		private Label label3;
		private Button btn_Clean;
		private Button btn_Search;
		private TextBox txt_Search;
	}
}