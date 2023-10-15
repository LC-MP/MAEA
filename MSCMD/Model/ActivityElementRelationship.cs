using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Model
{
	public enum RelationActivityComponentEnum
	{
		[Description("utiliza em atividade meio")]
		utilizameio,
		[Description("utiliza em atividade fim")]
		utilizafim,
		[Description("ocupa")]
		ocupa,
		[Description("aciona em atividade meio")]
		acionameio,
		[Description("aciona em atividade fim")]
		acionafim,
		[Description("circula por")]
		circulapor,
		
	}

	public enum AccessTypeEnum
	{
		livre, 
		preferencial, 
		restrito
	}

	public class ActivityElementRelationship
	{
		public int RelationshipId { get; set; }

		public int ActivityId { get; set; }

		[ForeignKey(nameof(ActivityId))]
		public virtual Activity? Activity { get; set; }

		public RelationActivityComponentEnum? Relation { get; set; }

		public int ComponentId { get; set; }

		[ForeignKey(nameof(ComponentId))]
		public virtual Element? Component { get; set; }

		public AccessTypeEnum? ComponentAccessType { get; set; }
	}
}
