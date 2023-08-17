using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Model
{
	public enum RelationEnum
	{
		[Description("atribuida à")]
		atribuida
	}

	public class AgentResourceRelationship
	{
		public int RelationshipId { get; set; }

		public int ResourceId { get; set; }

		[ForeignKey(nameof(ResourceId))]
		public virtual HumanResource? Resource { get; set; }

		public int AgentId { get; set; }

		[ForeignKey(nameof(AgentId))]
		public virtual Agent? Agent { get; set; }

		public RelationEnum? Relation { get; set; }
	}
}
