using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Model
{
	public class Element
	{
		public int ElementId { get; set; }

		[StringLength(45)]
		public string? Code { get; set; }

		[StringLength(120)]
		public string Name { get; set; } = null!;

		[StringLength(45)]
		public string? Type { get; set; }

		[StringLength(45)]
		public string? ExternalIdentifier { get; set; }

		[StringLength(45)]
		public string? ComponentClass { get; set; }

		public int? OrganizationId { get; set; }

		[ForeignKey(nameof(OrganizationId))]
		public Organization? OcupiedBy { get; set; }

		[StringLength(45)]
		public string? SurfaceType { get; set; }


		public List<Subsystem> Subsystems { get; } = new();

	}
}
