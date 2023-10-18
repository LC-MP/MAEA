using MSCMD.Model;
using MSCMD.Repository;
using MSCMD.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Service
{
	public class ExportDataService
	{
		private static MscmdContext context;

		private AgentRepository agentRepository;
		private ActivityRepository activityRepository;
		private AgentActivityRelationshipRepository agentActivityRepository;
		private ActivityActivityRelationshipRepository activityDependencyRepository;
		private ElementRepository elementRepository;
		private ElementElementRelationshipRepository elementInterfaceRepository;
		private ActivityElementRelationshipRepository affiliationRepository;
		private OrganizationRepository organizationRepository;
		private SubsystemRepository subsystemRepository;
		private SubprocessRepository subprocessRepository;
		private HumanResourceRepository humanResourceRepository;
		private AgentResourceRelationshipRepository agentResourceRelationshipRepository;


		public ExportDataService()
		{
			context = new MscmdContext();
			agentRepository = new AgentRepository(context);
			activityRepository = new ActivityRepository(context);
			agentActivityRepository = new AgentActivityRelationshipRepository(context);
			activityDependencyRepository = new ActivityActivityRelationshipRepository(context);
			elementRepository = new ElementRepository(context);
			elementInterfaceRepository = new ElementElementRelationshipRepository(context);
			affiliationRepository = new ActivityElementRelationshipRepository(context);
			organizationRepository = new OrganizationRepository(context);
			subsystemRepository = new SubsystemRepository(context);
			subprocessRepository = new SubprocessRepository(context);
			humanResourceRepository = new HumanResourceRepository(context);
			agentResourceRelationshipRepository = new AgentResourceRelationshipRepository(context);
		}

		public void ExportAll()
		{
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					try
					{
						//Funções
						List<Agent> agents = agentRepository.ListAll().ToList();
						string fileName = "1.2_funcao.csv";
						string destFile = Path.Combine(fbd.SelectedPath, fileName);
						WriteCustomCSV.AgentsToCSV(agents, destFile);

						//Organizacao
						List<Organization> org = organizationRepository.ListAll().ToList();
						string fileName2 = "1.1_divisao_organizacional.csv";
						string destFile2 = Path.Combine(fbd.SelectedPath, fileName2);
						WriteCustomCSV.OrganizationToCSV(org, destFile2);

						//Atividades
						List<Activity> activities = activityRepository.ListAll().ToList();
						string fileName3 = "2.2_atividade.csv";
						string destFile3 = Path.Combine(fbd.SelectedPath, fileName3);
						WriteCustomCSV.ActivitiesToCSV(activities, destFile3);

						//Subprocessos
						List<Subprocess> subprocess = subprocessRepository.ListAll().ToList();
						string fileName4 = "2.1_subprocesso.csv";
						string destFile4 = Path.Combine(fbd.SelectedPath, fileName4);
						WriteCustomCSV.SubprocessToCSV(subprocess, destFile4);

						//Elementos
						List<Element> elements = elementRepository.ListAll().ToList();
						string fileName5 = "3.2_elemento.csv";
						string destFile5 = Path.Combine(fbd.SelectedPath, fileName5);
						WriteCustomCSV.ElementsToCSV(elements, destFile5);

						//Subsistemas
						List<Subsystem> subsystems = subsystemRepository.ListAll().ToList();
						string fileName6 = "3.1_subsistemas.csv";
						string destFile6 = Path.Combine(fbd.SelectedPath, fileName6);
						WriteCustomCSV.SubsystemToCSV(subsystems, destFile6);


						//Relacao Atividade x Funcao
						List<AgentActivityRelationship> relations = agentActivityRepository.ListAll().ToList();
						string fileName7 = "5.1_relacoes_AtividadexFuncao.csv";
						string destFile7 = Path.Combine(fbd.SelectedPath, fileName7);
						WriteCustomCSV.RelActivityxFunctionToCSV(relations, destFile7);

						//Relacao Atividade x Atividade
						List<ActivityActivityRelationship> relations2 = activityDependencyRepository.ListAll().ToList();
						string fileName8 = "5.2_relacoes_AtividadexAtividade.csv";
						string destFile8 = Path.Combine(fbd.SelectedPath, fileName8);
						WriteCustomCSV.RelActivityxActivityToCSV(relations2, destFile8);

						//Relacao Atividade x Elemento
						List<ActivityElementRelationship> relations3 = affiliationRepository.ListAll().ToList();
						string fileName9 = "5.3_relacoes_AtividadexElemento.csv";
						string destFile9 = Path.Combine(fbd.SelectedPath, fileName9);
						WriteCustomCSV.RelActivityxElementToCSV(relations3, destFile9);

						//Relacao Elemento x Elemento
						List<ElementElementRelationship> relations4 = elementInterfaceRepository.ListAll().ToList();
						string fileName10 = "5.4_relacoes_ElementoxElemento.csv";
						string destFile10 = Path.Combine(fbd.SelectedPath, fileName10);
						WriteCustomCSV.RelElementxElementToCSV(relations4, destFile10);

						//Recursos
						List<HumanResource> list = humanResourceRepository.ListAll().ToList();
						string fileName11 = "4.1_recursos.csv";
						string destFile11 = Path.Combine(fbd.SelectedPath, fileName11);
						WriteCustomCSV.ResourceToCSV(list, destFile11);

						//Relacao funcao x Recurso
						List<AgentResourceRelationship> relations12 = agentResourceRelationshipRepository.ListAll().ToList();
						string fileName12 = "5.5_relacoes_FuncaoxRecurso.csv";
						string destFile12 = Path.Combine(fbd.SelectedPath, fileName12);
						WriteCustomCSV.RelAgentxResourceToCSV(relations12, destFile12);


					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Aviso");
					}
				}
			}
		}
	}
}
