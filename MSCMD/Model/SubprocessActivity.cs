using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Model
{
	public class SubprocessActivity
	{
		public int SubprocessId { get; set; }
		public int ActivityId { get; set; }

		[ForeignKey(nameof(SubprocessId))]
		public virtual Subprocess? Subprocess { get; set; }

		[ForeignKey(nameof(ActivityId))]
		public virtual Activity? Activity { get; set; }
	}
}
