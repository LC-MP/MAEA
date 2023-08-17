using MSCMD.Model;
using MSCMD.Utils;
using MSCMD.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Utils
{
	public static class WriteCustomCSV
	{

		public static void ToCSV(this DataTable dtDataTable, string strFilePath)
		{
			StreamWriter sw = new StreamWriter(strFilePath, false);
			//headers    
			for (int i = 0; i < dtDataTable.Columns.Count; i++)
			{
				sw.Write(dtDataTable.Columns[i]);
				if (i < dtDataTable.Columns.Count - 1)
				{
					sw.Write(",");
				}
			}
			sw.Write(sw.NewLine);
			foreach (DataRow dr in dtDataTable.Rows)
			{
				for (int i = 0; i < dtDataTable.Columns.Count; i++)
				{
					if (!Convert.IsDBNull(dr[i]))
					{
						string value = dr[i].ToString();
						if (value.Contains(','))
						{
							value = String.Format("\"{0}\"", value);
							sw.Write(value);
						}
						else
						{
							sw.Write(dr[i].ToString());
						}
					}
					if (i < dtDataTable.Columns.Count - 1)
					{
						sw.Write(",");
					}
				}
				sw.Write(sw.NewLine);
			}
			sw.Close();
		}

		public static void AgentsToCSV(List<Agent> list, string strFilePath)
		{
			StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);
			//header  
			sw.Write("codigo;nome_funcao;descricao_funcao;divisao");
			sw.Write(sw.NewLine);
			foreach (var agent in list)
			{
				sw.Write(agent.Code + ";" + agent.Name + ";" + agent.Description);

				if(agent.Organizations.Count > 0)
				{
					sw.Write(";");
					foreach (var org in agent.Organizations)
					{
						if (org.Code != null) { 
						sw.Write(org.Code);
							if (org != agent.Organizations.Last())
							{
								sw.Write(",");
							}
						}
						
					}
				}

				sw.Write(sw.NewLine);
			}
			sw.Close();
		}
		public static void ActivitiesToCSV(List<Activity> list, string strFilePath)
		{
			StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);

			sw.Write("codigo;nome_atividade;descricao;competencia;periodicidade1;periodicidade2;subprocesso");
			sw.Write(sw.NewLine);
			foreach (var item in list)
			{
				sw.Write(item.ActivityCode + ";" + item.ActivityName + ";" + item.ActivityDescription + ";" + item.RequiredCompetence
					+ ";" + (item.Periodicity1 != null ? Utility.GetEnumDescription(item.Periodicity1) : "") + ";" + (item.Periodicity2 != null ? Utility.GetEnumDescription(item.Periodicity2) : ""));
			
				if (item.Subprocesses.Count > 0)
				{
					sw.Write(";");
					foreach (var sub in item.Subprocesses)
					{
						if (sub.Code != null)
						{
							sw.Write(sub.Code);
							if (sub != item.Subprocesses.Last())
							{
								sw.Write(",");
							}
						}

					}
				}
				sw.Write(sw.NewLine);
			}
			sw.Close();
		}
		
		public static void ElementsToCSV(List<Element> list, string strFilePath)
		{
			StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);

			sw.Write("codigo;nome_elemento;tipo_elemento;identificador_externo;classe;tipo_superficie;subsistema");
			sw.Write(sw.NewLine);
			foreach (var item in list)
			{
				sw.Write(item.Code + ";" + item.Name + ";" + item.Type + ";" + item.ExternalIdentifier
					+ ";" + item.ComponentClass + ";" + item.SurfaceType);
			

				if (item.Subsystems.Count > 0)
				{
					sw.Write(";");
					foreach (var sub in item.Subsystems)
					{
						if (sub.Code != null)
						{
							sw.Write(sub.Code);
							if (sub != item.Subsystems.Last())
							{
								sw.Write(",");
							}
						}

					}
				}
				sw.Write(sw.NewLine);
			}
			sw.Close();
		}
		public static void OrganizationToCSV(List<Organization> list, string strFilePath)
		{
			StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);

			sw.Write("codigo;nome_setor;descricao_setor");
			sw.Write(sw.NewLine);
			foreach (var item in list)
			{
				sw.Write(item.Code + ";" + item.SectorName + ";" + item.Description);
				sw.Write(sw.NewLine);
			}
			sw.Close();
		}
		public static void SubprocessToCSV(List<Subprocess> list, string strFilePath)
		{
			StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);

			sw.Write("codigo;nome_processo");
			sw.Write(sw.NewLine);
			foreach (var item in list)
			{
				sw.Write(item.Code + ";" + item.Name);
				sw.Write(sw.NewLine);
			}
			sw.Close();
		}
		public static void ResourceToCSV(List<HumanResource> list, string strFilePath)
		{
			StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);

			sw.Write("codigo;nome;competencias;contato;registro;tipo_pessoa");
			sw.Write(sw.NewLine);
			foreach (var item in list)
			{
				sw.Write(item.Code + ";" + item.Name + ";" + item.Competences + ";" + item.Contact + ";" + item.Registry + ";" + item.Type);
				sw.Write(sw.NewLine);
			}
			sw.Close();
		}

		public static void SubsystemToCSV(List<Subsystem> list, string strFilePath)
		{
			StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);

			sw.Write("codigo;nome_sistema");
			sw.Write(sw.NewLine);
			foreach (var item in list)
			{
				sw.Write(item.Code + ";" + item.Name);
				sw.Write(sw.NewLine);
			}
			sw.Close();
		}

		public static void RelActivityxActivityToCSV(List<ActivityActivityRelationship> list, string strFilePath)
		{
			StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);

			sw.Write("COD_A;nome;relação;COD_A_R;nome_R");
			sw.Write(sw.NewLine);
			foreach (var item in list)
			{
				sw.Write(item.ReferenceActivity?.ActivityCode + ";" + item.ReferenceActivity?.ActivityName + ";" + item.Relation + ";" + item.ReferredActivity?.ActivityCode
					+ ";" + item.ReferredActivity?.ActivityName);
				sw.Write(sw.NewLine);
			}
			sw.Close();
		}
		public static void RelActivityxElementToCSV(List<ActivityElementRelationship> list, string strFilePath)
		{
			StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);

			sw.Write("COD_A;nome;COD_E;nome_E;relação");
			sw.Write(sw.NewLine);
			foreach (var item in list)
			{
				sw.Write(item.Activity?.ActivityCode + ";" + item.Activity?.ActivityName + ";" + item.Component?.Code + ";" + item.Component?.Name
					+ ";" + item.Relation);
				sw.Write(sw.NewLine);
			}
			sw.Close();
		}
		public static void RelActivityxFunctionToCSV(List<AgentActivityRelationship> list, string strFilePath)
		{
			StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);

			sw.Write("COD_A;nome_atividade;COD_F;nome_funcao");
			sw.Write(sw.NewLine);
			foreach (var item in list)
			{
				sw.Write(item.Activity?.ActivityCode + ";" + item.Activity?.ActivityName + ";" + item.ResponsibleAgent?.Code + ";" + item.ResponsibleAgent?.Name);
				sw.Write(sw.NewLine);
			}
			sw.Close();
		}
		public static void RelElementxElementToCSV(List<ElementElementRelationship> list, string strFilePath)
		{
			StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);

			sw.Write("COD_E;Nome;relação;COD_E_R;Nome_R");
			sw.Write(sw.NewLine);
			foreach (var item in list)
			{
				sw.Write(item.ReferenceComponent?.Code + ";" + item.ReferenceComponent?.Name + ";" + item.Relation + ";" + item.ReferredComponent?.Code + ";" + item.ReferredComponent?.Name);
				sw.Write(sw.NewLine);
			}
			sw.Close();
		}

		public static void RelAgentxResourceToCSV(List<AgentResourceRelationship> list, string strFilePath)
		{
			StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);

			sw.Write("COD_F;Nome;relação;COD_R;Nome_R");
			sw.Write(sw.NewLine);
			foreach (var item in list)
			{
				sw.Write(item.Agent?.Code + ";" + item.Agent?.Name + ";" + item.Relation + ";" + item.Resource?.Code + ";" + item.Resource?.Name);
				sw.Write(sw.NewLine);
			}
			sw.Close();
		}

	}
}
