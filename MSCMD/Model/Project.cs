using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Model
{
	public class Project
	{
		public int projectId { get; set; }

		public string? Code { get; set; }

		public string Name { get; set; } = null!;

		public string? Description { get; set; }

		public DateTime? Start { get; set; }

		public DateTime? End { get; set; }

		public int? AgentId { get; set; }

		[ForeignKey(nameof(AgentId))]
		public Agent? ResponsibleAgent { get; set; }

		public int? OrganizationId { get; set; }

		[ForeignKey(nameof(OrganizationId))]
		public Organization? PromoterSector { get; set; }

		public string? Team { get; set; }
	}
}
