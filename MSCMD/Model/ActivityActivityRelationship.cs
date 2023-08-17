using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Model
{

	public enum ActivityRelationEnum
	{
		[Description("é precedida por")]
		precedidapor = 0,
		//[Description("independente")]
		//independente = 1,
		[Description("inicia depois do fim de")]
		iniciadepoisde = 2,
		[Description("termina antes do inicio de")]
		terminaantesde,
		[Description("termina com")]
		terminacom,
		[Description("inicia com")]
		iniciacom,
		[Description("ocorre durante")]
		ocorredurante,
		[Description("impede a")]
		impede,
		[Description("permite a")]
		permite
	}
	public class ActivityActivityRelationship
	{
		public int RelationshipId { get; set; }

		public int ReferredActivityId { get; set; }

		[ForeignKey(nameof(ReferredActivityId))]
		public virtual Activity? ReferredActivity { get; set; }

		public int ReferenceActivityId { get; set; }

		[ForeignKey(nameof(ReferenceActivityId))]
		public virtual Activity? ReferenceActivity { get; set; }

		public ActivityRelationEnum? Relation { get; set; }
	}
}
