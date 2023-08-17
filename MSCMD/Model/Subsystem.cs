using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Model
{
	public class Subsystem
	{
		public int SubsystemId { get; set; }

		
		public string Name { get; set; }

		[StringLength(45)]
		public string? Code { get; set; }

		public List<Element> Elements { get; } = new();
	}
}
