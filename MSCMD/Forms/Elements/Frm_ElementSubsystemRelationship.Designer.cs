namespace MSCMD.Forms.Elements
{
	partial class Frm_ElementSubsystemRelationship
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
			label3 = new Label();
			btn_Clean = new Button();
			btn_Search = new Button();
			txt_Search = new TextBox();
			btn_Close = new Button();
			label2 = new Label();
			btn_Vincular = new Button();
			dg_Sectors = new DataGridView();
			subsystemBindingSource = new BindingSource(components);
			lbl_NomeElemento = new Label();
			lbl_Codigo = new Label();
			label1 = new Label();
			subsystemIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			codeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)dg_Sectors).BeginInit();
			((System.ComponentModel.ISupportInitialize)subsystemBindingSource).BeginInit();
			SuspendLayout();
			// 
			// label3
			// 
			label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			label3.AutoSize = true;
			label3.Location = new Point(489, 53);
			label3.Name = "label3";
			label3.Size = new Size(196, 20);
			label3.TabIndex = 63;
			label3.Text = "Buscar por código ou nome:";
			// 
			// btn_Clean
			// 
			btn_Clean.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btn_Clean.Location = new Point(805, 77);
			btn_Clean.Margin = new Padding(3, 4, 3, 4);
			btn_Clean.Name = "btn_Clean";
			btn_Clean.Size = new Size(86, 31);
			btn_Clean.TabIndex = 62;
			btn_Clean.Text = "Limpar";
			btn_Clean.UseVisualStyleBackColor = true;
			btn_Clean.Click += btn_Clean_Click;
			// 
			// btn_Search
			// 
			btn_Search.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btn_Search.Location = new Point(725, 77);
			btn_Search.Margin = new Padding(3, 4, 3, 4);
			btn_Search.Name = "btn_Search";
			btn_Search.Size = new Size(73, 31);
			btn_Search.TabIndex = 61;
			btn_Search.Text = "Buscar";
			btn_Search.UseVisualStyleBackColor = true;
			btn_Search.Click += btn_Search_Click;
			// 
			// txt_Search
			// 
			txt_Search.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			txt_Search.BorderStyle = BorderStyle.FixedSingle;
			txt_Search.Location = new Point(489, 80);
			txt_Search.Margin = new Padding(3, 4, 3, 4);
			txt_Search.Name = "txt_Search";
			txt_Search.Size = new Size(229, 27);
			txt_Search.TabIndex = 60;
			txt_Search.KeyUp += txt_Search_KeyUp;
			// 
			// btn_Close
			// 
			btn_Close.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_Close.Location = new Point(792, 553);
			btn_Close.Name = "btn_Close";
			btn_Close.Size = new Size(101, 29);
			btn_Close.TabIndex = 59;
			btn_Close.Text = "Fechar";
			btn_Close.UseVisualStyleBackColor = true;
			btn_Close.Click += btn_Close_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(21, 104);
			label2.Name = "label2";
			label2.Size = new Size(136, 20);
			label2.TabIndex = 58;
			label2.Text = "Subsistema / Setor:";
			// 
			// btn_Vincular
			// 
			btn_Vincular.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btn_Vincular.Location = new Point(659, 553);
			btn_Vincular.Margin = new Padding(3, 4, 3, 4);
			btn_Vincular.Name = "btn_Vincular";
			btn_Vincular.Size = new Size(127, 31);
			btn_Vincular.TabIndex = 57;
			btn_Vincular.Text = "Vincular ";
			btn_Vincular.UseVisualStyleBackColor = true;
			btn_Vincular.Click += btn_Vincular_Click;
			// 
			// dg_Sectors
			// 
			dg_Sectors.AllowUserToAddRows = false;
			dg_Sectors.AllowUserToDeleteRows = false;
			dg_Sectors.AllowUserToResizeRows = false;
			dg_Sectors.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dg_Sectors.AutoGenerateColumns = false;
			dg_Sectors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dg_Sectors.Columns.AddRange(new DataGridViewColumn[] { subsystemIdDataGridViewTextBoxColumn, codeDataGridViewTextBoxColumn, dataGridViewTextBoxColumn1 });
			dg_Sectors.DataSource = subsystemBindingSource;
			dg_Sectors.Location = new Point(27, 128);
			dg_Sectors.Margin = new Padding(3, 4, 3, 4);
			dg_Sectors.MultiSelect = false;
			dg_Sectors.Name = "dg_Sectors";
			dg_Sectors.ReadOnly = true;
			dg_Sectors.RowHeadersVisible = false;
			dg_Sectors.RowHeadersWidth = 51;
			dg_Sectors.RowTemplate.Height = 25;
			dg_Sectors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dg_Sectors.Size = new Size(866, 419);
			dg_Sectors.TabIndex = 56;
			// 
			// subsystemBindingSource
			// 
			subsystemBindingSource.DataSource = typeof(Model.Subsystem);
			// 
			// lbl_NomeElemento
			// 
			lbl_NomeElemento.AutoSize = true;
			lbl_NomeElemento.Location = new Point(27, 68);
			lbl_NomeElemento.Name = "lbl_NomeElemento";
			lbl_NomeElemento.Size = new Size(139, 20);
			lbl_NomeElemento.TabIndex = 55;
			lbl_NomeElemento.Text = "Nome do Elemento";
			// 
			// lbl_Codigo
			// 
			lbl_Codigo.AutoSize = true;
			lbl_Codigo.Location = new Point(27, 48);
			lbl_Codigo.Name = "lbl_Codigo";
			lbl_Codigo.Size = new Size(61, 20);
			lbl_Codigo.TabIndex = 54;
			lbl_Codigo.Text = "Código:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(21, 17);
			label1.Name = "label1";
			label1.Size = new Size(98, 28);
			label1.TabIndex = 53;
			label1.Text = "Elemento:";
			// 
			// subsystemIdDataGridViewTextBoxColumn
			// 
			subsystemIdDataGridViewTextBoxColumn.DataPropertyName = "SubsystemId";
			subsystemIdDataGridViewTextBoxColumn.HeaderText = "SubsystemId";
			subsystemIdDataGridViewTextBoxColumn.MinimumWidth = 6;
			subsystemIdDataGridViewTextBoxColumn.Name = "subsystemIdDataGridViewTextBoxColumn";
			subsystemIdDataGridViewTextBoxColumn.ReadOnly = true;
			subsystemIdDataGridViewTextBoxColumn.Visible = false;
			subsystemIdDataGridViewTextBoxColumn.Width = 125;
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
			// dataGridViewTextBoxColumn1
			// 
			dataGridViewTextBoxColumn1.DataPropertyName = "Name";
			dataGridViewTextBoxColumn1.HeaderText = "Nome";
			dataGridViewTextBoxColumn1.MinimumWidth = 6;
			dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			dataGridViewTextBoxColumn1.ReadOnly = true;
			dataGridViewTextBoxColumn1.Width = 600;
			// 
			// Frm_ElementSubsystemRelationship
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(914, 600);
			Controls.Add(label3);
			Controls.Add(btn_Clean);
			Controls.Add(btn_Search);
			Controls.Add(txt_Search);
			Controls.Add(btn_Close);
			Controls.Add(label2);
			Controls.Add(btn_Vincular);
			Controls.Add(dg_Sectors);
			Controls.Add(lbl_NomeElemento);
			Controls.Add(lbl_Codigo);
			Controls.Add(label1);
			Name = "Frm_ElementSubsystemRelationship";
			Text = "Vincular Subsistema";
			Load += Frm_ElementSubsystemRelationship_Load;
			((System.ComponentModel.ISupportInitialize)dg_Sectors).EndInit();
			((System.ComponentModel.ISupportInitialize)subsystemBindingSource).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label3;
		private Button btn_Clean;
		private Button btn_Search;
		private TextBox txt_Search;
		private Button btn_Close;
		private Label label2;
		private Button btn_Vincular;
		private DataGridView dg_Sectors;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private BindingSource subsystemBindingSource;
		private Label lbl_NomeElemento;
		private Label lbl_Codigo;
		private Label label1;
		private DataGridViewTextBoxColumn subsystemIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
	}
}