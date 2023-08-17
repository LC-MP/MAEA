using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Model
{
	public class AgentActivityRelationship
	{
		public int RelationshipId { get; set; }

		public int AgentId { get; set; }
		[ForeignKey(nameof(AgentId))]
		public virtual Agent? ResponsibleAgent { get; set; }

		public int ActivityId { get; set; }

		[ForeignKey(nameof(ActivityId))]
		public virtual Activity? Activity { get; set; }
	}
}
