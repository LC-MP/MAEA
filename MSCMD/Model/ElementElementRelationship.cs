using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Model
{

	public enum ElementRelationEnum
	{
		[Description("se conecta a")]
		seconecta,
		[Description("delimita")]
		delimita,
		[Description("controla acesso")]
		controlaacesso,
		[Description("pavimenta")]
		pavimenta,
		[Description("aciona")]
		aciona,
		[Description("contém")]
		contem
		
	}
	public class ElementElementRelationship
	{
		public int RelationshipId { get; set; }

		public int ReferredComponentId { get; set; }
		[ForeignKey(nameof(ReferredComponentId))]
		public virtual Element? ReferredComponent { get; set; }

		public int ReferenceComponentId { get; set; }
		[ForeignKey(nameof(ReferenceComponentId))]
		public virtual Element? ReferenceComponent { get; set; }

		public ElementRelationEnum? Relation { get; set; }
	}
}
