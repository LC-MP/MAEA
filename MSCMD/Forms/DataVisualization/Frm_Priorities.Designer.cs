namespace MSCMD.Forms.DataVisualization
{
	partial class Frm_Priorities
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
			dataGridView1 = new DataGridView();
			priorityViewModelBindingSource = new BindingSource(components);
			relationshipViewModelBindingSource = new BindingSource(components);
			label1 = new Label();
			iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			priorityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			((System.ComponentModel.ISupportInitialize)priorityViewModelBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)relationshipViewModelBindingSource).BeginInit();
			SuspendLayout();
			// 
			// dataGridView1
			// 
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dataGridView1.AutoGenerateColumns = false;
			dataGridView1.BackgroundColor = SystemColors.ControlLight;
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Columns.AddRange(new DataGridViewColumn[] { iDDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, priorityDataGridViewTextBoxColumn });
			dataGridView1.DataSource = priorityViewModelBindingSource;
			dataGridView1.Location = new Point(26, 55);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.ReadOnly = true;
			dataGridView1.RowHeadersWidth = 51;
			dataGridView1.RowTemplate.Height = 29;
			dataGridView1.Size = new Size(760, 605);
			dataGridView1.TabIndex = 0;
			// 
			// priorityViewModelBindingSource
			// 
			priorityViewModelBindingSource.DataSource = typeof(ViewModel.PriorityViewModel);
			// 
			// relationshipViewModelBindingSource
			// 
			relationshipViewModelBindingSource.DataSource = typeof(ViewModel.RelationshipViewModel);
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(26, 20);
			label1.Name = "label1";
			label1.Size = new Size(288, 23);
			label1.TabIndex = 1;
			label1.Text = "Relação de prioridade das atividades";
			// 
			// iDDataGridViewTextBoxColumn
			// 
			iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
			iDDataGridViewTextBoxColumn.HeaderText = "ID";
			iDDataGridViewTextBoxColumn.MinimumWidth = 6;
			iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
			iDDataGridViewTextBoxColumn.ReadOnly = true;
			iDDataGridViewTextBoxColumn.Width = 80;
			// 
			// nameDataGridViewTextBoxColumn
			// 
			nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
			nameDataGridViewTextBoxColumn.HeaderText = "Nome da Atividade";
			nameDataGridViewTextBoxColumn.MinimumWidth = 6;
			nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			nameDataGridViewTextBoxColumn.ReadOnly = true;
			nameDataGridViewTextBoxColumn.Width = 380;
			// 
			// priorityDataGridViewTextBoxColumn
			// 
			priorityDataGridViewTextBoxColumn.DataPropertyName = "Priority";
			priorityDataGridViewTextBoxColumn.HeaderText = "Prioridade";
			priorityDataGridViewTextBoxColumn.MinimumWidth = 6;
			priorityDataGridViewTextBoxColumn.Name = "priorityDataGridViewTextBoxColumn";
			priorityDataGridViewTextBoxColumn.ReadOnly = true;
			priorityDataGridViewTextBoxColumn.Width = 125;
			// 
			// Frm_Priorities
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(819, 692);
			Controls.Add(label1);
			Controls.Add(dataGridView1);
			Name = "Frm_Priorities";
			Text = "MSCMD - Prioridades";
			Load += Frm_Priorities_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			((System.ComponentModel.ISupportInitialize)priorityViewModelBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)relationshipViewModelBindingSource).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView dataGridView1;
		private BindingSource relationshipViewModelBindingSource;
		private BindingSource priorityViewModelBindingSource;
		private Label label1;
		private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn priorityDataGridViewTextBoxColumn;
	}
}