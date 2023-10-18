namespace MSCMD.Forms.DataVisualization
{
	partial class Frm_MatrixVisualization
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_MatrixVisualization));
			cartesianChart1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
			SuspendLayout();
			// 
			// cartesianChart1
			// 
			cartesianChart1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			cartesianChart1.Location = new Point(14, 16);
			cartesianChart1.Margin = new Padding(3, 4, 3, 4);
			cartesianChart1.Name = "cartesianChart1";
			cartesianChart1.Size = new Size(983, 871);
			cartesianChart1.TabIndex = 0;
			cartesianChart1.Load += cartesianChart1_Load;
			// 
			// Frm_MatrixVisualization
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1010, 903);
			Controls.Add(cartesianChart1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(3, 4, 3, 4);
			Name = "Frm_MatrixVisualization";
			Text = "MAEA";
			Load += Frm__ActivitiesDependenciesMatrix_Load;
			ResumeLayout(false);
		}

		#endregion

		private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;
	}
}