using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LiveChartsCore.Defaults;
using System.Collections.ObjectModel;

namespace MSCMD.Utils
{
	public static class Utility
	{
		public static IList<T> EnumToList<T>()
		{
			if (!typeof(T).IsEnum)
				throw new Exception("T isn't an enumerated type");

			IList<T> list = new List<T>();
			Type type = typeof(T);
			if (type != null)
			{
				Array enumValues = Enum.GetValues(type);
				foreach (T value in enumValues)
				{
					list.Add(value);
				}
			}
			return list;
		}

		public static IEnumerable<KeyValuePair<T, string>> EnumOf<T>()
		{
			return Enum.GetValues(typeof(T))
				.Cast<T>()
				.Select(p => new KeyValuePair<T, string>(
					p,
					(p.GetType().GetField(p.ToString())
					.GetCustomAttributes(typeof(DescriptionAttribute), false)
					.FirstOrDefault() as DescriptionAttribute)?.Description ?? p.ToString()
					))
					.ToList();
		}

		public static string GetEnumDescription(Enum value)
		{
			FieldInfo fi = value.GetType().GetField(value.ToString());

			DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

			if (attributes != null && attributes.Any())
			{
				return attributes.First().Description;
			}

			return value.ToString();
		}

		public static string RemoveAccents(this string text)
		{
			StringBuilder sbReturn = new StringBuilder();
			var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
			foreach (char letter in arrayText)
			{
				if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
					sbReturn.Append(letter);
			}
			return sbReturn.ToString();
		}

		public static ObservableCollection<WeightedPoint> matrixToObservableCollection(List<List<float>> matrix)
		{
			var values = new ObservableCollection<WeightedPoint>();

			int indexy = 0;

			for (int y = matrix.Count - 1; y >= 0; y--) //for (int i = 0; i < matrix.Count; i++)
			{
				for (int x = 0; x < matrix[0].Count; x++)
				{
					values.Add(new(x, indexy, matrix[y][x]));

				}
				indexy++;
			}
			return values;
		}

		
	}
}
