using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Model
{
	public class Agent
	{
		
		public int AgentId { get; set; }

		public string? Code { get; set; }

		public string Name { get; set; } = null!;

		public string? Description { get; set; }

		//public int? FunctionalCapacityId { get; set; }

		//[NotMapped]
		//[ForeignKey(nameof(FunctionalCapacityId))]
		//public virtual Organization? FunctionalCapacity { get; set; }
 
		//public int? FunctionalSubordinationId { get; set; }

		//[ForeignKey(nameof(FunctionalSubordinationId))]
		//public virtual Agent? FunctionalSubordination { get; set; }

		public virtual List<Organization> Organizations { get; } = new();

		public virtual List<AgentSubordination> FunctionalSubordinations { get; } = new();
		public virtual List<AgentSubordination> FunctionalSubordinationsOf { get; } = new();

	}
}
