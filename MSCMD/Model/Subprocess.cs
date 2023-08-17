using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Model
{
	public class Subprocess
	{
		public int SubprocessId { get; set; }
		public string? Code { get; set; }
		public string Name { get; set; }

		public List<Activity> Activities { get; } = new();
	}
}
