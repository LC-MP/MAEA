using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Model
{
	public enum PersonType
	{
		Fisica,
		Juridica
	}
	public class HumanResource
	{
		public int PersonId { get; set; }

		public string? Code { get; set; }

		public string Name { get; set; } = null!;

		public string? Competences { get; set; }

		public PersonType? Type { get; set; }

		public string? Contact { get; set; }

		public string? Registry { get; set; }

	}
}
