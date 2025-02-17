using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using MSCMD.Utils;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveChartsCore.Drawing;

namespace MSCMD.Forms.DataVisualization
{
	public partial class Frm_MatrixVisualization : Form
	{

		public ObservableCollection<WeightedPoint> matrix;

		public Frm_MatrixVisualization(List<List<float>> _matrix, List<string> xLabels, List<string> yLabels, List<string> XTooltipLabels, List<string> yTooltipLabels, string formName, string XaxisName, string YaxisName)
		{
			InitializeComponent();
			this.Text = "MSCMD -" + formName;

			matrix = Utility.matrixToObservableCollection(_matrix);

			ISeries[] Series =
			{
				new HeatSeries<WeightedPoint>
				{
					HeatMap = new[]
					{
					SKColors.LightGray.AsLvcColor(), // the first element is the "coldest"
					SKColors.Red.AsLvcColor(),
					SKColors.Blue.AsLvcColor(),
					SKColors.Green.AsLvcColor() // the last element is the "hottest"
					 },
					Values = matrix,
					PointPadding = new LiveChartsCore.Drawing.Padding(0.2,0.2,0.2,0.2),

					TooltipLabelFormatter =
					(chartPoint) => $"{XTooltipLabels[(int)chartPoint.SecondaryValue]} x {yTooltipLabels[(int)chartPoint.PrimaryValue]}: {chartPoint.TertiaryValue}"
				}
			};

			Axis[] XAxes =
			{
			new Axis
			{
				Name = XaxisName,
				NameTextSize = 12,
				Labels = xLabels,
				Position = LiveChartsCore.Measure.AxisPosition.End,
				LabelsRotation = 90,
				TextSize = 15,
				Padding = new LiveChartsCore.Drawing.Padding(2)
			}
			};

			Axis[] YAxes =
			{
			new Axis
			{
				Name = YaxisName,
				NameTextSize = 12,
				Labels = yLabels,
				TextSize = 15,
				Padding = new LiveChartsCore.Drawing.Padding(2)
			}
			};



			cartesianChart1.Series = Series;
			cartesianChart1.XAxes = XAxes;
			cartesianChart1.YAxes = YAxes;
			cartesianChart1.ZoomMode = LiveChartsCore.Measure.ZoomAndPanMode.Both;

		}

		private void Frm__ActivitiesDependenciesMatrix_Load(object sender, EventArgs e)
		{

		}

		private void cartesianChart1_Load(object sender, EventArgs e)
		{

		}
	}
}
