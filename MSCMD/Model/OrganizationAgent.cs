using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Model
{
	public class OrganizationAgent
	{
		public int OrganizationId { get; set; }
		public int AgentId { get; set; }

		[ForeignKey(nameof(OrganizationId))]
		public virtual Organization? Organization { get; set; }

		[ForeignKey(nameof(AgentId))]
		public virtual Agent? Agent { get; set; }
	}
}
