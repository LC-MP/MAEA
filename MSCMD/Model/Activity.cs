using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Model
{
	public enum Periodicity1Enum
	{
		[Description("Manhã")]
		Manha,
		[Description("Tarde")]
		Tarde,
		[Description("Noite")]
		Noite,
		[Description("Madrugada")]
		Madrugada,
		[Description("Integral")]
		Integral
	}

	public enum Periodicity2Enum
	{
		[Description("Diário")]
		Diario,
		[Description("Semanal")]
		Semanal,
		[Description("Mensal")]
		Mensal,
		[Description("Ocasional")]
		Ocasional
	}

	public enum DurationEnum
	{
		[Description("1h")]
		_1h,
		[Description("2h")]
		_2h,
		[Description("3h")]
		_3h,
		[Description("4h")]
		_4h,
		[Description("5h")]
		_5h,
		[Description("6h")]
		_6h,
		[Description("7h")]
		_7h,
		[Description("8h")]
		_8h,
		[Description("12h")]
		_12h,
		[Description("18h")]
		_18h,
		[Description("24h")]
		_24h,
		[Description("36h")]
		_36h
	}
	public class Activity
	{
		public int ActivityId { get; set; }

		public string? ActivityCode { get; set; }

		[StringLength(120)]
		public string ActivityName { get; set; } = null!;

		public string? ActivityDescription { get; set; }

		public Periodicity1Enum? Periodicity1 { get; set; }

		public Periodicity2Enum? Periodicity2 { get; set; }

		public DurationEnum? Duration { get; set; }

		public string? RequiredCompetence { get; set; }

		public List<Subprocess> Subprocesses { get; } = new();

	}

}
