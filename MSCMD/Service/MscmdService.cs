using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MSCMD.Model;
using MSCMD.Repository;
using MSCMD.Utils;
using OrganizationalAnalysis;

namespace MSCMD.Service
{
	public class MscmdService
	{
		private static MscmdContext context;
		private Processor processor;

		private AgentRepository agentRepository;
		private ActivityRepository activityRepository;
		private AgentActivityRelationshipRepository agentActivityRepository;
		private ActivityActivityRelationshipRepository activityDependencyRepository;
		private ElementRepository elementRepository;
		private ElementElementRelationshipRepository elementInterfaceRepository;
		private ActivityElementRelationshipRepository affiliationRepository;

		private List<Element> elementsList;
		private List<Model.Activity> activityList;
		private char separator = ';';
		private char lister = ',';

		public string errorLog = "";

		public MscmdService() 
		{
			context = new MscmdContext();
			agentRepository = new AgentRepository(context);
			activityRepository = new ActivityRepository(context);
			agentActivityRepository = new AgentActivityRelationshipRepository(context);
			activityDependencyRepository = new ActivityActivityRelationshipRepository(context);
			elementRepository = new ElementRepository(context);
			elementInterfaceRepository = new ElementElementRelationshipRepository(context);
			affiliationRepository = new ActivityElementRelationshipRepository(context);
			processor = new Processor();
		}

		public void loadData()
		{
			
			IndirectlyRelatedDegree(1);
			RelatedDegree(2);
			DirectlyRelatedDegree(3);

			InsertAgents();
			InsertActivities();
			InsertAgentInChargeActivity();
			InsertActivityDependency();
			InsertComponents();
			InsertComponentsInterface();
			InsertAffiliation();
			
		}

		public void ClearProcess()
		{
			processor.Clear();
			errorLog = "";
		}

		public void IndirectlyRelatedDegree(float degree)
		{
			try
			{

				processor.IndirectlyRelatedDegree(degree);
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		public void RelatedDegree(float degree)
		{
			try
			{

				processor.RelatedDegree(degree);
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		public void DirectlyRelatedDegree(float degree)
		{
			try
			{

				processor.DirectlyRelatedDegree(degree);
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void InsertAgents()
		{
			try
			{
				var list = agentRepository.ListAll().OrderBy(x => x.AgentId.ToString());
				foreach (var agent in list)
				{
					//string group = "";
					//var groups = agent.Organizations;

					//if (groups.Count > 0)
					//	group = groups.First().SectorName;

					string agentName = "";
					if (agent.Code != null)
					{
						agentName = agent.Code + " - " + agent.Name;
					} else
					{
						agentName = agent.Name;
					}

					processor.InsertOrAssignAgent(agent.AgentId.ToString(), agentName);
					//processor.InsertOrAssignAgent(agent.AgentId.ToString(), group, agent.Name);
					//processor.Ins//ertOrAssignAgent(agent.Code.ToString(), group, agent.Name);
				}
			} 
			catch (Exception ex)
			{
				errorLog += "Inserir Funções: " + ex.Message + "\n";

				//MessageBox.Show(ex.Message);
			}

		}

		private void InsertActivities()
		{
			try
			{
				
				var list = activityRepository.ListAll().OrderBy(x => x.ActivityId.ToString());
				activityList = list.ToList();
				foreach (var activity in list)
				{
					//string group = "";
					//var activityGroup = activity.Subprocesses;

					//if (activityGroup.Count > 0)
					//	group = activityGroup.First().Name;


					string activityName = "";
					if (activity.ActivityCode != null)
					{
						activityName = activity.ActivityCode + " - " + activity.ActivityName;
					}
					else
					{
						activityName = activity.ActivityName;
					}

					processor.InsertOrEditActivity(activity.ActivityId.ToString(), activity.ActivityName);
					//processor.InsertOrEditActivity(activity.ActivityCode.ToString(), group, activity.ActivityName);
				}
			}
			catch (Exception ex)
			{
				errorLog += "Inserir Atividades: " + ex.Message + "\n";
			}

		}

		private void InsertAgentInChargeActivity()
		{
			try
			{
				var list = agentActivityRepository.ListAll();
				foreach (var rel in list)
				{

					processor.InsertAgentInChargeOfActivity(rel.AgentId.ToString(), rel.ActivityId.ToString());
					//processor.InsertAgentInChargeOfActivity(rel.ResponsibleAgent.Code.ToString(), rel.Activity.ActivityCode.ToString());
				}
			}
			catch (Exception ex)
			{
				errorLog += "Inserir Funções responsáveis por Atividades: " + ex.Message + "\n";
			}

		}

		public void MinimumRelationDegreeForAgentsInChargeOfComponents(float degree)
		{
			try
			{
				processor.MinimumRelationDegreeForAgentsInChargeOfComponents(degree);
			}
			catch (Exception ex)
			{
				errorLog += "Configurar grau de relação entre funções e elementos: " + ex.Message + "\n";
			}

		}

		private void InsertActivityDependency()
		{
			try
			{
				var list = activityDependencyRepository.ListAll();
				foreach (var rel in list)
				{
					processor.InsertActivityDependency(rel.ReferenceActivityId.ToString(), rel.ReferredActivityId.ToString());
					//processor.InsertActivityDependency(rel.ReferenceActivity.ActivityCode.ToString(), rel.ReferredActivity.ActivityCode.ToString());
				}
			}
			catch (Exception ex)
			{
				errorLog += "Inserir dependência de Atividades: " + ex.Message + "\n";
			}

		}

		private void InsertComponents()
		{
			try
			{
			
				var list = elementRepository.ListAll().OrderBy(x => x.ElementId.ToString());
				elementsList = list.ToList();
				foreach (var element in list)
				{
					//string group = "";
					//var activityGroup = element.Subsystems;

					//if (activityGroup.Count > 0)
					//	group = activityGroup.First().Name;

					string elementName = "";
					if (element.Code != null)
					{
						elementName = element.Code + " - " + element.Name;
					}
					else
					{
						elementName = element.Name;
					}

					processor.InsertOrEditComponent(element.ElementId.ToString(), elementName);
					//processor.InsertOrEditComponent(element.Code.ToString(), group, element.Name);
				}
			}
			catch (Exception ex)
			{
				errorLog += "Inserir Elementos: " + ex.Message + "\n";
			}

		}

		private void InsertComponentsInterface()
		{
			try
			{
				var list = elementInterfaceRepository.ListAll();
				foreach (var rel in list)
				{
					processor.InsertComponentInterface(rel.ReferenceComponentId.ToString(), rel.ReferredComponentId.ToString());
					//processor.InsertComponentInterface(rel.ReferenceComponent.Code.ToString(), rel.ReferredComponent.Code.ToString());
				}
			}
			catch (Exception ex)
			{
				errorLog += "Inserir relação entre Elementos: " + ex.Message + "\n";
			}
		}

		private void InsertAffiliation()
		{
			try
			{
				var list = affiliationRepository.ListAll();
				foreach (var rel in list)
				{
					//	3=for when the end activity i occurs in the environment j
					//	2=for when a means activity i occurs in the environment j
					//	1=for when it circulates in the environment j to perform the activity i
					float rating = 0;

					switch (rel.Relation)
					{
						case RelationActivityComponentEnum.circulapor:
							rating = 1;
							break;
						case RelationActivityComponentEnum.ocupa:
							rating = 3;
							break;
						case RelationActivityComponentEnum.acionameio:
							rating = 2;
							break;
						case RelationActivityComponentEnum.utilizameio:
							rating = 2;
							break;
						case RelationActivityComponentEnum.acionafim:
							rating = 3;
							break;
						case RelationActivityComponentEnum.utilizafim:
							rating = 3;
							break;
					}

					processor.InsertOrAssignAffiliation(rel.ActivityId.ToString(), rel.ComponentId.ToString(), rating);
					//processor.InsertOrAssignAffiliation(rel.Activity.ActivityCode.ToString(), rel.Component.Code.ToString(), rating);
				}
			}
			catch (Exception ex)
			{
				errorLog += "Inserir relação entre Atividades e Elementos: " + ex.Message + "\n";
			}
		}

		public List<SortedSet<string>>? IdentifyParallelization()
		{
			try
			{
				var response = processor.IdentifyParallelizations();
				return response;
				
			}
			catch (Exception ex)
			{
				//MessageBox.Show(ex.Message);
				errorLog += "Identificar paralelizações: " + ex.Message + "\n";
				return null;
			}
		}

		public SortedDictionary<string,ulong>? IdentifyPriority()
		{
			try
			{

				var response = processor.IdentifyPriorities();
				return response;

			}
			catch (Exception ex)
			{
				errorLog += "Identificar prioridades: " + ex.Message + "\n";
				return null;
			}
		}
		public List<string>? ComponentsWithoutAgentsInCharge()
		{
			try
			{

				List<string> response = processor.ComponentsWithoutAgentsInCharge();
				

				if (response != null && response.Count > 0)
				{
					string list = "";
					foreach (var item in response)
					{
						list += item + "; ";
					}

					errorLog += "\n\nElementos do ambiente sem função responsável: " + list;

				}
				return response;

			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public List<string>? ActivitiesWithoutAgentsInCharge()
		{
			try
			{

				List<string> response = processor.ActivitiesWithoutAgentsInCharge();

				if (response != null && response.Count > 0)
				{
					string list = "";
					foreach (var item in response)
					{
						list += item +"; ";
					}

					errorLog += "\nAtividades do processo sem função responsável: " + list;

				}

				return response;

			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public bool CompareActivitiesAndOrganization()
		{
			try
			{
				processor.CompareActivitiesAndOrganization();
				return true;
			}
			catch (Exception ex)
			{
				errorLog += "Comparar atividades e organizações: " + ex.Message + "\n";
				return false;
			}
		}

		public bool CompareComponentsAndOrganization(float minimumRelationDegree)
		{
			try
			{

				processor.CompareComponentsAndOrganization(minimumRelationDegree);
				return true;
			}
			catch (Exception ex)
			{
				errorLog += "Comparar elementos e organizações: " + ex.Message + "\n";
				return false;
			}
		}

		public List<List<float>> ActivitiesDependenciesMatrix()
		{
			try
			{
				List<List<float>> response = processor.ActivitiesDependenciesMatrix();

				return response;

			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public List<List<float>> ComponentsInterfacesMatrix()
		{
			try
			{
				List<List<float>> response = processor.ComponentsInterfacesMatrix();
				return response;

			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public List<List<float>> WeakAffiliationsMatrix()
		{
			try
			{
				List<List<float>> response = processor.WeakAffiliationsMatrix();
				return response;

			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public List<List<float>> StrongAffiliationsMatrix()
		{
			try
			{
				List<List<float>> response = processor.StrongAffiliationsMatrix();
				return response;

			}
			catch (Exception ex)
			{
				return null;
			}
		}
		public List<List<float>> TotalAffiliationsMatrix()
		{
			try
			{
				List<List<float>> response = processor.TotalAffiliationsMatrix();
				return response;

			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public List<List<float>> ComparativeMatrixWithoutRedundancies()
		{
			try
			{
				List<List<float>> response = processor.ComparativeMatrixWithoutRedundancies();
				return response;

			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public List<List<float>> ComparativeMatrixWithRedundancies()
		{
			try
			{
				List<List<float>> response = processor.ComparativeMatrixWithRedundancies();
				return response;

			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public bool WriteActivityMatrix(string filename)
		{
			try
			{
				processor.WriteActivities(filename, separator, lister);
				return true;

			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public bool WriteComponentsMatrix(string filename)
		{
			try
			{
				processor.WriteComponents(filename, separator, lister);
				return true;

			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public bool WriteTotalPotentialMatrix(string filename)
		{
			try
			{
				processor.WriteTotalPotentialMatrix(filename, separator, lister);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public bool WriteComparativeMatrixWithoutRedundancies(string filename)
		{
			try
			{
				processor.WriteComparativeMatrixWithoutRedundancies(filename, separator, lister);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public bool WriteComparativeMatrixWithRedundancies(string filename)
		{
			try
			{
				processor.WriteComparativeMatrixWithRedundancies(filename, separator, lister);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public bool WriteStrongAffiliationsMatrix(string filename)
		{
			try
			{
				processor.WriteStrongAffiliationsMatrix(filename, separator, lister);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public bool WriteTotalAffiliationsMatrix(string filename)
		{
			try
			{
				processor.WriteTotalAffiliationsMatrix(filename, separator, lister);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public bool WriteStrongPotentialMatrixWithoutRedundancies(string filename)
		{
			try
			{
				processor.WriteStrongPotentialMatrixWithoutRedundancies(filename, separator, lister);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		

		public bool WriteStrongPotentialMatrixWithRedundancies(string filename)
		{
			try
			{
				processor.WriteStrongPotentialMatrixWithRedundancies(filename, separator, lister);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public bool WriteWeakAffiliationsMatrix(string filename)
		{
			try
			{
				processor.WriteWeakAffiliationsMatrix(filename, separator, lister);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public List<Element> GetElements()
		{
			return elementsList;
		}

		public List<Model.Activity> GetActivities()
		{
			return activityList;
		}

		public string ActivityName(string id)
		{
			try
			{
				return processor.ActivityName(id);
			}
			catch (Exception ex)
			{
				return "";
			}
		}

		//public void CheckActivitiesWithoutComponents()
		//{
		//	List<Model.Activity> activitiesToIgnore = new List<Model.Activity>();
		//	List<Model.Element> componentsToIgnore = new List<Element>();

		//	var relationshipList = affiliationRepository.ListAll();

		//	var excludedActivitiesIDs = new HashSet<int>(relationshipList.Select(r => r.ActivityId));
		//	var excludedCompnentsIDs = new HashSet<int>(relationshipList.Select(r => r.ComponentId));

		//	var activities = activityRepository.ListAll().ToList();
		//	var components = elementRepository.ListAll().ToList();

		//	var activitiesWithoutElements = activities.Where(p => !excludedActivitiesIDs.Contains(p.ActivityId)).ToList();
		//	var componentsWithoutActivities = components.Where(p => !excludedCompnentsIDs.Contains(p.ElementId)).ToList();


		//	if (activitiesWithoutElements.Count > 0)
		//	{
		//		string actIDS = activitiesWithoutElements.Select(a=> a.ActivityId.ToString()).Aggregate((i, j) => i + "," + j).ToString();

		//		DialogResult dialogResult = MessageBox.Show("As atividades " + actIDS + " não possuem relação com nenhum elemento. Deseja ignorá-las durante a análise?", "Aviso", MessageBoxButtons.YesNoCancel);
		//		if (dialogResult == DialogResult.Yes)
		//		{
		//			activityList = activities.Except(activitiesWithoutElements).ToList();
		//		}
		//		else
		//		{
		//			activityList = activities;
		//		}
		//	} else
		//	{
		//		activityList = activities;
		//	}

		//	if (componentsWithoutActivities.Count > 0)
		//	{
		//		string eleIDS = componentsWithoutActivities.Select(a => a.ElementId.ToString()).Aggregate((i, j) => i + "," + j).ToString();

		//		DialogResult dialogResult = MessageBox.Show("Os elementos " + eleIDS + " não possuem relação com nenhuma atividade. Deseja ignorá-los durante a análise?", "Aviso", MessageBoxButtons.YesNoCancel);
		//		if (dialogResult == DialogResult.Yes)
		//		{
		//			elementsList = components.Except(componentsWithoutActivities).ToList();
		//		}
		//		else
		//		{
		//			elementsList = components;
		//		}
		//	} else
		//	{
		//		elementsList = components;
		//	}
		//}


	}
}

