using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Model
{
	public class Organization
	{
		public int SectorId { get; set; }

		public string? Code { get; set; }

		public string SectorName { get; set; } = null!;

		public string? Description { get; set; }

		public int? ResponsibleAgentId { get; set; }

		public int? SuperiorInstanceId { get; set; }

		[ForeignKey(nameof(SuperiorInstanceId))]
		public virtual Organization? SuperiorInstance { get; set; }

		public List<Agent> Agents { get; } = new();

	}

}
