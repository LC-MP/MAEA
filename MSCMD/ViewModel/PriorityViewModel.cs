using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MSCMD.ViewModel
{
	public class PriorityViewModel
	{
		public string? ID { get; set; }
		public string? Name { get; set; }
		public ulong? Priority { get; set; }


		public override string ToString()
		{
			return $"{Name} - {Priority}";
		}

	}
}
