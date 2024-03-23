using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MSCMD.Model;
using MSCMD.Repository;
using MSCMD.Utils;
using OrganizationalAnalysis;

namespace MSCMD.Service
{
	public class MscmdService
	{
		class Task
		{
			public string Activity { get; set; } = string.Empty;
			public string Identification { get; set; } = string.Empty;
			public string Name { get; set; } = string.Empty;
			public float Degree { get; set; } = 0;
			public uint X { get; set; } = 0;
			public uint Y { get; set; } = 0;
		}

		class DependencyType
		{
			public string Dependent { get; set; } = string.Empty;
			public string Dependency { get; set; } = string.Empty;

		}

		class TaskDependency
		{
			public string Activity { get; set; } = string.Empty;
			public List<DependencyType> Dependencies { get; set; } = new();
		}

		class ElementInstance
		{
			public string Identification { get; set; } = string.Empty;
			public ulong AbsolutePositionHash { get; set; } = 0;
			public ulong RelativePositionHash { get; set; } = 0;

			public ElementInstance() { }
			public ElementInstance(string identification, ulong absolutePositionHash, ulong relativePositionHash)
			{
				this.Identification = identification;
				this.AbsolutePositionHash = absolutePositionHash;
				this.RelativePositionHash = relativePositionHash;
			}
		}

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
					string agentName = "";
					if (agent.Code != null)
					{
						agentName = agent.Code + " - " + agent.Name;
					} else
					{
						agentName = agent.Name;
					}

					processor.InsertOrAssignAgent(agent.AgentId.ToString(), agentName);
				}
			} 
			catch (Exception ex)
			{
				errorLog += "Inserir Funções: " + ex.Message + "\n";
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
					string activityName = "";
					if (activity.ActivityCode != null)
					{
						activityName = activity.ActivityCode + " - " + activity.ActivityName;
					}
					else
					{
						activityName = activity.ActivityName;
					}

					processor.InsertOrEditActivity(activity.ActivityId.ToString(), activityName);;
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

		// TODO: Remove this method.
		public void ReadImage()
		{
			string base_path = "C:\\MSCMD\\";

			if (!Directory.Exists(base_path))
			{
				Directory.CreateDirectory(base_path);
			}

			StreamWriter log = new(base_path + "execution.log", true);

			processor.InsertBlueprintElement("door", Color.FromArgb(255, 0, 0), Traversability.Open);
			processor.InsertBlueprintElement("balcony", Color.FromArgb(124, 0, 165), Traversability.Border);
			processor.InsertBlueprintElement("window", Color.FromArgb(0, 165, 165), Traversability.Closed);
			processor.InsertBlueprintElement("environment_limit", Color.FromArgb(82, 165, 0), Traversability.Open);
			processor.InsertBlueprintElement("elevator", Color.FromArgb(240, 240, 0), Color.FromArgb(240, 240, 255), Traversability.Teleport);
			processor.InsertBlueprintElement("stair", Color.FromArgb(250, 180, 0), Color.FromArgb(250, 180, 255), Traversability.Teleport);

			List<Task> ?tasks = new();
			List<TaskDependency> ?tasks_dependencies = new();

			if (File.Exists(base_path + "tasks.json"))
			{
				string tasks_json = File.ReadAllText(base_path + "tasks.json");

				tasks = JsonSerializer.Deserialize<List<Task>>(tasks_json);

				if (tasks == null)
				{
					throw new Exception("Could not open \"tasks.json\" file.");
				}
			}

			if (File.Exists(base_path + "tasks_dependencies.json"))
			{
				string tasks_dependencies_json = File.ReadAllText(base_path + "tasks_dependencies.json");

				tasks_dependencies = JsonSerializer.Deserialize<List<TaskDependency>>(tasks_dependencies_json);

				if (tasks_dependencies == null)
				{
					throw new Exception("Could not open \"tasks_dependencies.json\" file.");
				}
			}

			string ?reference_string = File.OpenText(base_path + "reference_in_meters.txt").ReadLine();

			if (reference_string == null)
			{
				throw new Exception("Could not open \"reference_in_meters.json\" file.");
			}

			processor.ReadBlueprintAndDetectInstances(base_path + "blueprint.png", float.Parse(reference_string));

			foreach (var task in tasks)
			{
				processor.InsertTask(task.Activity, task.Identification, task.Name, task.Degree, task.X, task.Y);
			}

			foreach (var task_dependency in tasks_dependencies)
			{
				foreach (var dependency in task_dependency.Dependencies)
				{
					processor.InsertTaskDependency(task_dependency.Activity, dependency.Dependent, dependency.Dependency);
				}
			}

			List<ElementInstance>? element_instance_hashes;

			if (File.Exists(base_path + "element_instance_hashes.json"))
			{
				string element_instance_hashes_json = File.ReadAllText(base_path + "element_instance_hashes.json");

				element_instance_hashes = JsonSerializer.Deserialize<List<ElementInstance>>(element_instance_hashes_json);

				if (element_instance_hashes == null)
				{
					Exception exception = new("Could not parse \"element_instance_hashes.json\" file");

					log.Write(exception);

					throw exception;
				}

				foreach (var element_instance_hash in element_instance_hashes)
				{
					bool inserted = false;

					try
					{
						processor.RenameBlueprintElementInstanceHash(true, (nuint)element_instance_hash.AbsolutePositionHash, element_instance_hash.Identification);

						inserted = true;
					} catch (Exception ex) {
						log.WriteLine(ex);
						log.WriteLine("Abs: " + element_instance_hash.AbsolutePositionHash + "\n");
					}

					if (inserted)
					{
						continue;
					}

					try
					{
						processor.RenameBlueprintElementInstanceHash(false, (nuint)element_instance_hash.RelativePositionHash, element_instance_hash.Identification);
					}
					catch (Exception ex)
					{
						log.WriteLine(ex);
						log.WriteLine("Rel: " + element_instance_hash.RelativePositionHash + "\n");
					}
				}
			}

			var element_instance_identifications = processor.ElementInstanceIdentifications();
			element_instance_hashes = new();

			foreach (var element_instance_identification in element_instance_identifications)
			{
				var hashes = processor.BlueprintElementInstanceHash(element_instance_identification);

				element_instance_hashes.Add(new ElementInstance(element_instance_identification, hashes.Item1, hashes.Item2));
			}

			string hashes_json = JsonSerializer.Serialize(element_instance_hashes);

			File.WriteAllText(base_path + "element_instance_hashes.json", hashes_json);

			log.Close();
		}

		// TODO: Remove this method.
		public void TracePaths()
		{
			string base_path = "C:\\MSCMD\\";

			var list = activityRepository.ListAll();

			foreach (var activity in list)
			{
				try
				{
					var result = processor.TracePathOnBlueprint(activity.ActivityId.ToString());

					StreamWriter tasks_log = new StreamWriter(base_path + "path_" + activity.ActivityId + "_tasks.txt", false);
					StreamWriter instances_log = new StreamWriter(base_path + "path_" + activity.ActivityId + "_instances.txt", false);
					StreamWriter coordinates_log = new StreamWriter(base_path + "path_" + activity.ActivityId + "_coordinates.txt", false);
					StreamWriter distance_log = new StreamWriter(base_path + "path_" + activity.ActivityId + "_distance.txt", false);

					foreach (var task in result.Item1)
					{
						tasks_log.WriteLine(task);
					}

					foreach (var instance in result.Item2)
					{
						instances_log.WriteLine(instance);
					}

					foreach (var coordinate in result.Item3)
					{
						coordinates_log.Write("(");
						coordinates_log.Write(coordinate.Item1);
						coordinates_log.Write(", ");
						coordinates_log.Write(coordinate.Item2);
						coordinates_log.WriteLine(")");
					}

					distance_log.WriteLine(result.Item4);

					tasks_log.Close();
					instances_log.Close();
					coordinates_log.Close();
					distance_log.Close();
				} catch (Exception ex) {
					StreamWriter error_log = new StreamWriter(base_path + "path_" + activity.ActivityId + "_error.txt", false);

					error_log.WriteLine(ex);
				}
			}
		}

		// TODO: Remove this method.
		public void DumpInstances()
		{
			string base_path = "C:\\MSCMD\\";

			processor.WriteBlueprintContours(base_path + "contours.png");
			processor.WriteBlueprintElementInstances(base_path + "data\\", 3);
			processor.WriteBlueprintElementInstances(base_path + "data\\", 6);
			processor.WriteElementInstances(base_path + "instances\\", ';', ',');
			processor.WriteElementInstanceNeighborhood(base_path + "neighborhood\\", ';', ',');
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

