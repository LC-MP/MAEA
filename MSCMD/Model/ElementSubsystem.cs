using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Model
{
	public class ElementSubsystem
	{
		public int SubsystemId { get; set; }
		public int ElementId { get; set; }

		[ForeignKey(nameof(SubsystemId))]
		public virtual Subsystem? Subsystem { get; set; }

		[ForeignKey(nameof(ElementId))]
		public virtual Element? Element { get; set; }
	}
}
