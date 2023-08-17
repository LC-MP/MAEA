using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Model
{
	public class AgentSubordination
	{
		public int AgentSubordinationId { get; set; }

		public int AgentId { get; set; }

		public int FunctionalSubordinationId { get; set; }

		[ForeignKey(nameof(AgentId))]
		public virtual Agent Agent { get; set; }

		[ForeignKey(nameof(FunctionalSubordinationId))]
		public virtual Agent FunctionalSubordination { get; set; }
	}
}
