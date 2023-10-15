using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSCMD.Forms.DataVisualization
{
	public partial class Frm_Parallelism : Form
	{
		List<SortedSet<string>> list;
		public Frm_Parallelism(List<SortedSet<string>> text)
		{
			InitializeComponent();
			list = text;
		}

		private void Frm_Parallelism_Load(object sender, EventArgs e)
		{
			string parallelizations = "";
			foreach (var item in list)
			{

				foreach (var item2 in item)
				{
					parallelizations += item2.ToString() + ", ";

				}
				parallelizations += "\r\n\r\n";
			}

			textBox1.Text = parallelizations;
		}
	}
}
