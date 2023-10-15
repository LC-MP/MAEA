using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Utils
{
	public class CsvReader
	{
		public static DataTable GetDataTabletFromCSVFile(string csv_file_path)
		{
			DataTable csvData = new DataTable();
			try
			{
				if (csv_file_path.EndsWith(".csv"))
				{
					using (Microsoft.VisualBasic.FileIO.TextFieldParser csvReader = new Microsoft.VisualBasic.FileIO.TextFieldParser(csv_file_path, Encoding.Latin1))
					{
						csvReader.SetDelimiters(new string[] {
					";"
				});
						csvReader.HasFieldsEnclosedInQuotes = true;
						//read column  
						string[] colFields = csvReader.ReadFields();
						foreach (string column in colFields)
						{
							DataColumn datecolumn = new DataColumn(column);
							datecolumn.AllowDBNull = true;
							csvData.Columns.Add(datecolumn);
						}
						while (!csvReader.EndOfData)
						{
							string[] fieldData = csvReader.ReadFields();
							for (int i = 0; i < fieldData.Length; i++)
							{
								if (fieldData[i] == "")
								{
									fieldData[i] = null;
								}
							}
							csvData.Rows.Add(fieldData);
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Exception " + ex);
			}
			return csvData;
		}

	
	}
}
