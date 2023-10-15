using MSCMD.ViewModel;
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
	public partial class Frm_Priorities : Form
	{
		List<PriorityViewModel> priorityList;
		public Frm_Priorities(List<PriorityViewModel> priorities)
		{
			InitializeComponent();
			priorityList = priorities;
		}

		private void Frm_Priorities_Load(object sender, EventArgs e)
		{
			this.priorityViewModelBindingSource.DataSource = priorityList.OrderBy(p => p.Priority);
		}
	}
}
