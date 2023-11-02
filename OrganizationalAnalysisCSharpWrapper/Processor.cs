using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OrganizationalAnalysis
{
    public enum Traversability
    {
        Closed,
        Open,
        Border,
        Teleport
    };

    public class Processor
    {
        readonly private nuint processorObjectAddress;

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint indirectly_related_degree(
            nuint processorObjectAddress,
            [MarshalAs(UnmanagedType.R4)] float degree);

        public void IndirectlyRelatedDegree(float degree)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.indirectly_related_degree(this.processorObjectAddress, degree));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint related_degree(
            nuint processorObjectAddress,
            [MarshalAs(UnmanagedType.R4)] float degree);

        public void RelatedDegree(float degree)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.related_degree(this.processorObjectAddress, degree));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint directly_related_degree(
            nuint processorObjectAddress,
            [MarshalAs(UnmanagedType.R4)] float degree);

        public void DirectlyRelatedDegree(float degree)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.directly_related_degree(this.processorObjectAddress, degree));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint insert_or_assign_agent(
            nuint processorObjectAddress,
            [MarshalAs(UnmanagedType.LPStr)] string agent,
            [MarshalAs(UnmanagedType.LPStr)] string role);

        public void InsertOrAssignAgent(string agent, string role)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.insert_or_assign_agent(this.processorObjectAddress, agent, role));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint erase_agent(
            nuint processorObjectAddress,
            [MarshalAs(UnmanagedType.LPStr)] string agent);

        public void EraseAgent(string agent)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.erase_agent(this.processorObjectAddress, agent));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint insert_agent_group(
            nuint processorObjectAddress,
            [MarshalAs(UnmanagedType.LPStr)] string agent,
            [MarshalAs(UnmanagedType.LPStr)] string group);

        public void InsertAgentGroup(string agent, string group)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.insert_agent_group(this.processorObjectAddress, agent, group));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint erase_agent_group(
            nuint processorObjectAddress,
            [MarshalAs(UnmanagedType.LPStr)] string agent,
            [MarshalAs(UnmanagedType.LPStr)] string group);

        public void EraseAgentGroup(string agent, string group)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.erase_agent_group(this.processorObjectAddress, agent, group));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint insert_or_edit_activity(
            nuint processorObjectAddress,
            [MarshalAs(UnmanagedType.LPStr)] string activity,
            [MarshalAs(UnmanagedType.LPStr)] string name);

        public void InsertOrEditActivity(string activity, string name)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.insert_or_edit_activity(this.processorObjectAddress, activity, name));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint erase_activity(
            nuint processorObjectAddress,
            [MarshalAs(UnmanagedType.LPStr)] string activity);

        public void EraseActivity(string activity)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.erase_activity(this.processorObjectAddress, activity));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint insert_activity_group(
            nuint processorObjectAddress,
            [MarshalAs(UnmanagedType.LPStr)] string activity,
            [MarshalAs(UnmanagedType.LPStr)] string group);

        public void InsertActivityGroup(string activity, string group)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.insert_activity_group(this.processorObjectAddress, activity, group));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint erase_activity_group(
            nuint processorObjectAddress,
            [MarshalAs(UnmanagedType.LPStr)] string activity,
            [MarshalAs(UnmanagedType.LPStr)] string group);

        public void EraseActivityGroup(string activity, string group)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.erase_activity_group(this.processorObjectAddress, activity, group));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint insert_task(
            nuint processorObjectAddress,
            [MarshalAs(UnmanagedType.LPStr)] string activity,
            [MarshalAs(UnmanagedType.LPStr)] string task_identification,
            [MarshalAs(UnmanagedType.LPStr)] string task_name,
            nuint x,
            nuint y);

        public void InsertTask(string activity, string task_identification, string task_name, nuint x, nuint y)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.insert_task(
                        this.processorObjectAddress,
                        activity,
                        task_identification,
                        task_name,
                        x,
                        y));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint insert_task_dependency(
            nuint processorObjectAddress,
            [MarshalAs(UnmanagedType.LPStr)] string activity,
            [MarshalAs(UnmanagedType.LPStr)] string task_dependent,
            [MarshalAs(UnmanagedType.LPStr)] string task_dependency);

        public void InsertTaskDependency(string activity, string task_dependent, string task_dependency)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.insert_task_dependency(
                        this.processorObjectAddress,
                        activity,
                        task_dependent,
                        task_dependency));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint erase_task(
            nuint processorObjectAddress,
            [MarshalAs(UnmanagedType.LPStr)] string activity,
            [MarshalAs(UnmanagedType.LPStr)] string task);

        public void EraseTask(string activity, string task)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.erase_task(
                        this.processorObjectAddress,
                        activity,
                        task));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint erase_task_dependency(
            nuint processorObjectAddress,
            [MarshalAs(UnmanagedType.LPStr)] string activity,
            [MarshalAs(UnmanagedType.LPStr)] string task_dependent,
            [MarshalAs(UnmanagedType.LPStr)] string task_dependency);

        public void EraseTaskDependency(string activity, string task_dependent, string task_dependency)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.erase_task_dependency(
                        this.processorObjectAddress,
                        activity,
                        task_dependent,
                        task_dependency));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint insert_agent_in_charge_of_activity(
            nuint processorObjectAddress,
            [MarshalAs(UnmanagedType.LPStr)] string agent,
            [MarshalAs(UnmanagedType.LPStr)] string activity);

        public void InsertAgentInChargeOfActivity(string agent, string activity)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.insert_agent_in_charge_of_activity(this.processorObjectAddress, agent, activity));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint erase_agent_in_charge_of_activity(
            nuint processorObjectAddress,
            [MarshalAs(UnmanagedType.LPStr)] string agent,
            [MarshalAs(UnmanagedType.LPStr)] string activity);

        public void EraseAgentInChargeOfActivity(string agent, string activity)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.erase_agent_in_charge_of_activity(this.processorObjectAddress, agent, activity));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint insert_activity_dependency(
            nuint processorObjectAddress,
            [MarshalAs(UnmanagedType.LPStr)] string dependent,
            [MarshalAs(UnmanagedType.LPStr)] string dependency);

        public void InsertActivityDependency(string dependent, string dependency)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.insert_activity_dependency(this.processorObjectAddress, dependent, dependency));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint erase_activity_dependency(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string dependent,
           [MarshalAs(UnmanagedType.LPStr)] string dependency);

        public void EraseActivityDependency(string dependent, string dependency)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.erase_activity_dependency(this.processorObjectAddress, dependent, dependency));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint insert_or_edit_component(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string component,
           [MarshalAs(UnmanagedType.LPStr)] string name);

        public void InsertOrEditComponent(string component, string name)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.insert_or_edit_component(this.processorObjectAddress, component, name));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint erase_component(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string component);

        public void EraseComponent(string component)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.erase_component(this.processorObjectAddress, component));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint insert_component_group(
            nuint processorObjectAddress,
            [MarshalAs(UnmanagedType.LPStr)] string component,
            [MarshalAs(UnmanagedType.LPStr)] string group);

        public void InsertComponentGroup(string component, string group)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.insert_component_group(this.processorObjectAddress, component, group));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint erase_component_group(
            nuint processorObjectAddress,
            [MarshalAs(UnmanagedType.LPStr)] string component,
            [MarshalAs(UnmanagedType.LPStr)] string group);

        public void EraseComponentGroup(string component, string group)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.erase_component_group(this.processorObjectAddress, component, group));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint insert_component_interface(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string component1,
           [MarshalAs(UnmanagedType.LPStr)] string component2);

        public void InsertComponentInterface(string component1, string component2)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.insert_component_interface(this.processorObjectAddress, component1, component2));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint erase_component_interface(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string component1,
           [MarshalAs(UnmanagedType.LPStr)] string component2);

        public void EraseComponentInterface(string component1, string component2)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.erase_component_interface(this.processorObjectAddress, component1, component2));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint insert_or_assign_affiliation(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string activity,
           [MarshalAs(UnmanagedType.LPStr)] string component,
           [MarshalAs(UnmanagedType.R4)] float rating);

        public void InsertOrAssignAffiliation(string activity, string component, float rating)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.insert_or_assign_affiliation(this.processorObjectAddress, activity, component, rating));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint erase_affiliation(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string activity,
           [MarshalAs(UnmanagedType.LPStr)] string component);

        public void EraseAffiliation(string activity, string component)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.erase_affiliation(this.processorObjectAddress, activity, component));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern void clear(nuint processorObjectAddress);

        public void Clear()
        {
            Processor.clear(this.processorObjectAddress);
        }

        private delegate void ResizeVector(nuint size);

        private delegate void InsertStringIntoPosition1(
            [MarshalAs(UnmanagedType.LPStr)] string activity,
            nuint position);

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint identify_parallelizations(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.FunctionPtr)] ResizeVector resizer,
           [MarshalAs(UnmanagedType.FunctionPtr)] InsertStringIntoPosition1 inserter);

        public List<SortedSet<string>> IdentifyParallelizations()
        {
            var parallelizations = new List<SortedSet<string>>();

            ResizeVector resizer =
                (nuint size) =>
                {
                    for (nuint i = 0; i < size; i++)
                    {
                        parallelizations.Add(new SortedSet < string > ());
                    }
                };

            InsertStringIntoPosition1 inserter =
                ([MarshalAs(UnmanagedType.LPStr)] string activity, nuint position) =>
                {
                    parallelizations[(int)position].Add(new string(activity));
                };

            string? message = Marshal.PtrToStringAnsi(Processor.identify_parallelizations(this.processorObjectAddress, resizer, inserter));

            if (message != null)
            {
                throw new Exception(message);
            }

            return parallelizations;
        }

        private delegate void InsertPairOfStringAndSizeT(
            [MarshalAs(UnmanagedType.LPStr)] string activity,
            nuint position);

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint identify_priorities(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.FunctionPtr)] InsertPairOfStringAndSizeT inserter);

        public SortedDictionary<string, ulong> IdentifyPriorities()
        {
            var priorities = new SortedDictionary<string, ulong>();

            InsertPairOfStringAndSizeT inserter =
                ([MarshalAs(UnmanagedType.LPStr)] string activity, nuint priority) =>
                {
                    priorities.Add(new string(activity), priority);
                };

            string? message = Marshal.PtrToStringAnsi(Processor.identify_priorities(this.processorObjectAddress, inserter));

            if (message != null)
            {
                throw new Exception(message);
            }

            return priorities;
        }

        private delegate void InsertStringInContainer(
            [MarshalAs(UnmanagedType.LPStr)] string elementWithoutAgentsInCharge);

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint components_without_agents_in_charge(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.FunctionPtr)] InsertStringInContainer inserter);

        public List<string> ComponentsWithoutAgentsInCharge()
        {
            var componentsWithoutAgents = new List<string>();

            InsertStringInContainer inserter =
                ([MarshalAs(UnmanagedType.LPStr)] string elementWithoutAgentsInCharge) =>
                {
                    componentsWithoutAgents.Add(new string(elementWithoutAgentsInCharge));
                };

            string? message = Marshal.PtrToStringAnsi(Processor.components_without_agents_in_charge(this.processorObjectAddress, inserter));

            if (message != null)
            {
                throw new Exception(message);
            }

            return componentsWithoutAgents;
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint activities_without_agents_in_charge(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.FunctionPtr)] InsertStringInContainer inserter);

        public List<string> ActivitiesWithoutAgentsInCharge()
        {
            var activitiesWithoutAgents = new List<string>();

            InsertStringInContainer inserter =
                ([MarshalAs(UnmanagedType.LPStr)] string elementWithoutAgentsInCharge) =>
                {
                    activitiesWithoutAgents.Add(new string(elementWithoutAgentsInCharge));
                };

            string? message = Marshal.PtrToStringAnsi(Processor.activities_without_agents_in_charge(this.processorObjectAddress, inserter));

            if (message != null)
            {
                throw new Exception(message);
            }

            return activitiesWithoutAgents;
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint minimum_relation_degree_for_agents_in_charge_of_components(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.R4)] float degree);

        public void MinimumRelationDegreeForAgentsInChargeOfComponents(float degree)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.minimum_relation_degree_for_agents_in_charge_of_components(this.processorObjectAddress, degree));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        private delegate void CopyString(
            [MarshalAs(UnmanagedType.LPStr)] string nativeString);

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint agent_role(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string agent,
           [MarshalAs(UnmanagedType.FunctionPtr)] CopyString copier);

        public string AgentRole(string agent)
        {
            string managedString = "";

            CopyString copier =
                ([MarshalAs(UnmanagedType.LPStr)] string nativeString) =>
                {
                    managedString = new string(nativeString);
                };

            string? message = Marshal.PtrToStringAnsi(Processor.agent_role(this.processorObjectAddress, agent, copier));

            if (message != null)
            {
                throw new Exception(message);
            }

            return managedString;
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint activity_name(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string activity,
           [MarshalAs(UnmanagedType.FunctionPtr)] CopyString copier);

        public string ActivityName(string activity)
        {
            string managedString = "";

            CopyString copier =
                ([MarshalAs(UnmanagedType.LPStr)] string nativeString) =>
                {
                    managedString = new string(nativeString);
                };

            string? message = Marshal.PtrToStringAnsi(Processor.activity_name(this.processorObjectAddress, activity, copier));

            if (message != null)
            {
                throw new Exception(message);
            }

            return managedString;
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint component_name(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string component,
           [MarshalAs(UnmanagedType.FunctionPtr)] CopyString copier);

        public string ComponentName(string component)
        {
            string managedString = "";

            CopyString copier =
                ([MarshalAs(UnmanagedType.LPStr)] string nativeString) =>
                {
                    managedString = new string(nativeString);
                };

            string? message = Marshal.PtrToStringAnsi(Processor.component_name(this.processorObjectAddress, component, copier));

            if (message != null)
            {
                throw new Exception(message);
            }

            return managedString;
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint compare_activities_and_organization(
           nuint processorObjectAddress);

        public void CompareActivitiesAndOrganization()
        {
            string? message = Marshal.PtrToStringAnsi(Processor.compare_activities_and_organization(this.processorObjectAddress));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint compare_components_and_organization(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.R4)] float minimumRelationDegreeForAgentsInChargeOfComponents);

        public void CompareComponentsAndOrganization(float minimumRelationDegreeForAgentsInChargeOfComponents)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.compare_components_and_organization(
                        this.processorObjectAddress,
                        minimumRelationDegreeForAgentsInChargeOfComponents));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        private delegate void ResizeMatrix(nuint rows, nuint columns);

        private delegate void InsertFloatIntoPosition2(
            [MarshalAs(UnmanagedType.R4)] float value,
            nuint row,
            nuint column);

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint activities_dependencies_matrix(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.FunctionPtr)] ResizeMatrix resizer,
           [MarshalAs(UnmanagedType.FunctionPtr)] InsertFloatIntoPosition2 inserter);

        public List<List<float>> ActivitiesDependenciesMatrix()
        {
            List<List<float>> matrix = new List<List<float>>();

            ResizeMatrix resizer =
                (nuint rows, nuint columns) =>
                {
                    matrix = new List<List<float>>((int)rows);

                    for (ulong i = 0; i < rows; i++)
                    {
                        matrix.Add(new List<float>((int)columns));

                        for (ulong j = 0; j < columns; j++)
                        {
                            matrix[(int)i].Add(new float());
                        }
                    }
                };

            InsertFloatIntoPosition2 inserter =
                ([MarshalAs(UnmanagedType.R4)] float value, nuint row, nuint column) =>
                {
                    matrix[(int)row][(int)column] = value;
                };

            string? message = Marshal.PtrToStringAnsi(Processor.activities_dependencies_matrix(this.processorObjectAddress, resizer, inserter));

            if (message != null)
            {
                throw new Exception(message);
            }

            return matrix;
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint components_interfaces_matrix(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.FunctionPtr)] ResizeMatrix resizer,
           [MarshalAs(UnmanagedType.FunctionPtr)] InsertFloatIntoPosition2 inserter);

        public List<List<float>> ComponentsInterfacesMatrix()
        {
            List<List<float>> matrix = new List<List<float>>();

            ResizeMatrix resizer =
                (nuint rows, nuint columns) =>
                {
                    matrix = new List<List<float>>((int)rows);

                    for (ulong i = 0; i < rows; i++)
                    {
                        matrix.Add(new List<float>((int)columns));

                        for (ulong j = 0; j < columns; j++)
                        {
                            matrix[(int)i].Add(new float());
                        }
                    }
                };

            InsertFloatIntoPosition2 inserter =
                ([MarshalAs(UnmanagedType.R4)] float value, nuint row, nuint column) =>
                {
                    matrix[(int)row][(int)column] = value;
                };

            string? message = Marshal.PtrToStringAnsi(Processor.components_interfaces_matrix(this.processorObjectAddress, resizer, inserter));

            if (message != null)
            {
                throw new Exception(message);
            }

            return matrix;
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint weak_affiliations_matrix(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.FunctionPtr)] ResizeMatrix resizer,
           [MarshalAs(UnmanagedType.FunctionPtr)] InsertFloatIntoPosition2 inserter);

        public List<List<float>> WeakAffiliationsMatrix()
        {
            List<List<float>> matrix = new List<List<float>>();

            ResizeMatrix resizer =
                (nuint rows, nuint columns) =>
                {
                    matrix = new List<List<float>>((int)rows);

                    for (ulong i = 0; i < rows; i++)
                    {
                        matrix.Add(new List<float>((int)columns));

                        for (ulong j = 0; j < columns; j++)
                        {
                            matrix[(int)i].Add(new float());
                        }
                    }
                };

            InsertFloatIntoPosition2 inserter =
                ([MarshalAs(UnmanagedType.R4)] float value, nuint row, nuint column) =>
                {
                    matrix[(int)row][(int)column] = value;
                };

            string? message = Marshal.PtrToStringAnsi(Processor.weak_affiliations_matrix(this.processorObjectAddress, resizer, inserter));

            if (message != null)
            {
                throw new Exception(message);
            }

            return matrix;
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint strong_affiliations_matrix(
          nuint processorObjectAddress,
          [MarshalAs(UnmanagedType.FunctionPtr)] ResizeMatrix resizer,
          [MarshalAs(UnmanagedType.FunctionPtr)] InsertFloatIntoPosition2 inserter);

        public List<List<float>> StrongAffiliationsMatrix()
        {
            List<List<float>> matrix = new List<List<float>>();

            ResizeMatrix resizer =
                (nuint rows, nuint columns) =>
                {
                    matrix = new List<List<float>>((int)rows);

                    for (ulong i = 0; i < rows; i++)
                    {
                        matrix.Add(new List<float>((int)columns));

                        for (ulong j = 0; j < columns; j++)
                        {
                            matrix[(int)i].Add(new float());
                        }
                    }
                };

            InsertFloatIntoPosition2 inserter =
                ([MarshalAs(UnmanagedType.R4)] float value, nuint row, nuint column) =>
                {
                    matrix[(int)row][(int)column] = value;
                };

            string? message = Marshal.PtrToStringAnsi(Processor.strong_affiliations_matrix(this.processorObjectAddress, resizer, inserter));

            if (message != null)
            {
                throw new Exception(message);
            }

            return matrix;
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint total_affiliations_matrix(
          nuint processorObjectAddress,
          [MarshalAs(UnmanagedType.FunctionPtr)] ResizeMatrix resizer,
          [MarshalAs(UnmanagedType.FunctionPtr)] InsertFloatIntoPosition2 inserter);

        public List<List<float>> TotalAffiliationsMatrix()
        {
            List<List<float>> matrix = new List<List<float>>();

            ResizeMatrix resizer =
                (nuint rows, nuint columns) =>
                {
                    matrix = new List<List<float>>((int)rows);

                    for (ulong i = 0; i < rows; i++)
                    {
                        matrix.Add(new List<float>((int)columns));

                        for (ulong j = 0; j < columns; j++)
                        {
                            matrix[(int)i].Add(new float());
                        }
                    }
                };

            InsertFloatIntoPosition2 inserter =
                ([MarshalAs(UnmanagedType.R4)] float value, nuint row, nuint column) =>
                {
                    matrix[(int)row][(int)column] = value;
                };

            string? message = Marshal.PtrToStringAnsi(Processor.total_affiliations_matrix(this.processorObjectAddress, resizer, inserter));

            if (message != null)
            {
                throw new Exception(message);
            }

            return matrix;
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint comparative_matrix_without_redundancies(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.FunctionPtr)] ResizeMatrix resizer,
           [MarshalAs(UnmanagedType.FunctionPtr)] InsertFloatIntoPosition2 inserter);

        public List<List<float>> ComparativeMatrixWithoutRedundancies()
        {
            List<List<float>> matrix = new List<List<float>>();

            ResizeMatrix resizer =
                (nuint rows, nuint columns) =>
                {
                    matrix = new List<List<float>>((int)rows);

                    for (ulong i = 0; i < rows; i++)
                    {
                        matrix.Add(new List<float>((int)columns));

                        for (ulong j = 0; j < columns; j++)
                        {
                            matrix[(int)i].Add(new float());
                        }
                    }
                };

            InsertFloatIntoPosition2 inserter =
                ([MarshalAs(UnmanagedType.R4)] float value, nuint row, nuint column) =>
                {
                    matrix[(int)row][(int)column] = value;
                };

            string? message = Marshal.PtrToStringAnsi(Processor.comparative_matrix_without_redundancies(this.processorObjectAddress, resizer, inserter));

            if (message != null)
            {
                throw new Exception(message);
            }

            return matrix;
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint comparative_matrix_with_redundancies(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.FunctionPtr)] ResizeMatrix resizer,
           [MarshalAs(UnmanagedType.FunctionPtr)] InsertFloatIntoPosition2 inserter);

        public List<List<float>> ComparativeMatrixWithRedundancies()
        {
            List<List<float>> matrix = new List<List<float>>();

            ResizeMatrix resizer =
                (nuint rows, nuint columns) =>
                {
                    matrix = new List<List<float>>((int)rows);

                    for (ulong i = 0; i < rows; i++)
                    {
                        matrix.Add(new List<float>((int)columns));

                        for (ulong j = 0; j < columns; j++)
                        {
                            matrix[(int)i].Add(new float());
                        }
                    }
                };

            InsertFloatIntoPosition2 inserter =
                ([MarshalAs(UnmanagedType.R4)] float value, nuint row, nuint column) =>
                {
                    matrix[(int)row][(int)column] = value;
                };

            string? message = Marshal.PtrToStringAnsi(Processor.comparative_matrix_with_redundancies(this.processorObjectAddress, resizer, inserter));

            if (message != null)
            {
                throw new Exception(message);
            }

            return matrix;
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint insert_blueprint_element_single_color(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string identification,
           byte red,
           byte green,
           byte blue,
           [MarshalAs(UnmanagedType.I4)] Traversability state);

        public void InsertBlueprintElement(string identification, System.Drawing.Color color, Traversability state)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.insert_blueprint_element_single_color(
                        this.processorObjectAddress,
                        identification,
                        color.R,
                        color.G,
                        color.B,
                        state));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint insert_blueprint_element_color_range(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string identification,
           byte minRed,
           byte minGreen,
           byte minBlue,
           byte maxRed,
           byte maxGreen,
           byte maxBlue,
           [MarshalAs(UnmanagedType.I4)] Traversability state);

        public void InsertBlueprintElement(
            string identification,
            System.Drawing.Color min,
            System.Drawing.Color max,
            Traversability state)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.insert_blueprint_element_color_range(
                        this.processorObjectAddress,
                        identification,
                        min.R,
                        min.G,
                        min.B,
                        max.R,
                        max.G,
                        max.B,
                        state));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint rename_blueprint_element_instance(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string oldIdentification,
           [MarshalAs(UnmanagedType.LPStr)] string newIdentification);

        public void RenameBlueprintElementInstance(
            string oldIdentification,
            string newIdentification)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.rename_blueprint_element_instance(
                        this.processorObjectAddress,
                        oldIdentification,
                        newIdentification));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint rename_blueprint_element_instance_hash(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.Bool)] bool absolute,
           nuint hash,
           [MarshalAs(UnmanagedType.LPStr)] string newIdentification);

        public void RenameBlueprintElementInstanceHash(
            bool absolute,
            nuint hash,
            string newIdentification)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.rename_blueprint_element_instance_hash(
                        this.processorObjectAddress,
                        absolute,
                        hash,
                        newIdentification));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint blueprint_element_instance_hash(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string identification,
           out nuint absolutePositionHash,
           out nuint relativePositionHash);

        public void BlueprintElementInstanceHash(
            string identification,
            out nuint absolutePositionHash,
            out nuint relativePositionHash)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.blueprint_element_instance_hash(
                        this.processorObjectAddress,
                        identification,
                        out absolutePositionHash,
                        out relativePositionHash));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint set_blueprint_element_traversability(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string identification,
           [MarshalAs(UnmanagedType.I4)] Traversability state);

        public void BlueprintElementTraversability(
            string identification,
            Traversability state)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.set_blueprint_element_traversability(
                        this.processorObjectAddress,
                        identification,
                        state));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint set_blueprint_element_instance_traversability(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string identification,
           [MarshalAs(UnmanagedType.I4)] Traversability state);

        public void BlueprintElementInstanceTraversability(
            string identification,
            Traversability state)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.set_blueprint_element_instance_traversability(
                        this.processorObjectAddress,
                        identification,
                        state));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint erase_blueprint_element(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string identification);

        public void EraseBlueprintElement(string identification)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.erase_blueprint_element(
                        this.processorObjectAddress,
                        identification));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint read_blueprint_and_detect_instances(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string identification,
           [MarshalAs(UnmanagedType.R4)] float referenceInMeters);

        public void ReadBlueprintAndDetectInstances(string identification, float referenceInMeters)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.read_blueprint_and_detect_instances(
                        this.processorObjectAddress,
                        identification,
                        referenceInMeters));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint detect_blueprint_instances(
           nuint processorObjectAddress);

        public void DetectBlueprintInstances()
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.detect_blueprint_instances(
                        this.processorObjectAddress));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint update_blueprint_space(
           nuint processorObjectAddress);

        public void UpdateBlueprintSpace()
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.update_blueprint_space(
                        this.processorObjectAddress));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        private delegate void InsertMappedPairOfSizeTAndCoordinates(
            [MarshalAs(UnmanagedType.LPStr)] string key1,
            [MarshalAs(UnmanagedType.LPStr)] string key2,
            nuint x,
            nuint y);

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint blueprint_element_instance_neighborhood(
           nuint processorObjectAddress,
           InsertMappedPairOfSizeTAndCoordinates inserter);

        public SortedDictionary<Tuple<string, string>, SortedSet<Tuple<nuint, nuint>>> BlueprintElementInstanceNeighborhood()
        {
            SortedDictionary<Tuple<string, string>, SortedSet<Tuple<nuint, nuint>>> neighborhood = new();

            InsertMappedPairOfSizeTAndCoordinates inserter =
                (string key1, string key2, nuint x, nuint y) =>
                {
                    Tuple<string, string> key = new(key1, key2);

                    if (neighborhood.TryGetValue(key, out SortedSet<Tuple<nuint, nuint>>? value))
                    {
                        value.Add(new Tuple<nuint, nuint>(x, y));
                    }

                    else
                    {
                        value = new SortedSet<Tuple<nuint, nuint>>();

                        neighborhood.Add(key, value);
                    }
                };

            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.blueprint_element_instance_neighborhood(
                        this.processorObjectAddress,
                        inserter));

            if (message != null)
            {
                throw new Exception(message);
            }

            return neighborhood;
        }

        private delegate void InsertPairOfSizeTInContainer(
            nuint value1,
            nuint value2);

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint trace_path_on_blueprint(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string activity,
           [MarshalAs(UnmanagedType.FunctionPtr)] InsertStringInContainer taskInserter,
           [MarshalAs(UnmanagedType.FunctionPtr)] InsertStringInContainer instanceInserter,
           [MarshalAs(UnmanagedType.FunctionPtr)] InsertPairOfSizeTInContainer coordinateInserter,
           [MarshalAs(UnmanagedType.R4)] out float distance);

        public Tuple<List<string>, List<string>, List<Tuple<nuint, nuint>>, float> TracePathOnBlueprint(string activity)
        {
            List<string> taskIdentifications = new();
            List<string> instanceIdentifications = new();
            List<Tuple<nuint, nuint>> path = new();
            float distance = 0;

            InsertStringInContainer taskInserter =
                ([MarshalAs(UnmanagedType.LPStr)] string key) =>
                {
                    taskIdentifications.Add(key);
                };

            InsertStringInContainer instanceInserter =
                ([MarshalAs(UnmanagedType.LPStr)] string key) =>
                {
                    instanceIdentifications.Add(key);
                };

            InsertPairOfSizeTInContainer coordinateInserter =
                (nuint value1, nuint value2) =>
                {
                    path.Add(new Tuple<nuint, nuint>(value1, value2));
                };

            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.trace_path_on_blueprint(
                        this.processorObjectAddress,
                        activity,
                        taskInserter,
                        instanceInserter,
                        coordinateInserter,
                        out distance));

            if (message != null)
            {
                throw new Exception(message);
            }

            return new(taskIdentifications, instanceIdentifications, path, distance);
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint element_instance_identifications(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.FunctionPtr)] InsertStringInContainer inserter);

        public List<string> ElementInstanceIdentifications()
        {
            List<string> elementInstanceIdentifications = new();

            InsertStringInContainer inserter =
                ([MarshalAs(UnmanagedType.LPStr)] string identification) =>
                {
                    elementInstanceIdentifications.Add(identification);
                };

            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.element_instance_identifications(
                        this.processorObjectAddress,
                        inserter));

            if (message != null)
            {
                throw new Exception(message);
            }

            return elementInstanceIdentifications;
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint write_blueprint(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string path);

        public void WriteBlueprint(string path)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.write_blueprint(
                        this.processorObjectAddress,
                        path));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint write_blueprint_contours(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string path);

        public void WriteBlueprintContours(string path)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.write_blueprint_contours(
                        this.processorObjectAddress,
                        path));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint write_blueprint_element_instance(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string directory,
           [MarshalAs(UnmanagedType.LPStr)] string identification,
           int cameraDistanceLevel);

        public void WriteBlueprintElementInstance(
            string directory,
            string identification,
            int cameraDistanceLevel)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.write_blueprint_element_instance(
                        this.processorObjectAddress,
                        directory,
                        identification,
                        cameraDistanceLevel));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [return: MarshalAs(UnmanagedType.LPStr)]
        private delegate string StringFromVector(nuint i);

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint write_blueprint_element_instances(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string directory,
           int cameraDistanceLevel,
           [MarshalAs(UnmanagedType.FunctionPtr)] StringFromVector getter,
           nuint vectorSize);

        public void WriteBlueprintElementInstances(
            string directory,
            int cameraDistanceLevel,
            List<string> ?inclusion = null)
        {
            nuint vectorSize = inclusion != null ? (nuint)inclusion.Count : 0;

            StringFromVector getter =
                (nuint i) =>
                {
                    if (inclusion != null)
                    {
                        return inclusion[(int)i];
                    }

                    return "";
                };

            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.write_blueprint_element_instances(
                        this.processorObjectAddress,
                        directory,
                        cameraDistanceLevel,
                        getter,
                        vectorSize));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint blueprint_element_domain(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string identification,
           out byte minRed,
           out byte minGreen,
           out byte minBlue,
           out byte maxRed,
           out byte maxGreen,
           out byte maxBlue);

        public Tuple<System.Drawing.Color, System.Drawing.Color> BlueprintElementDomain(string identification)
        {
            byte minRed;
            byte minGreen;
            byte minBlue;
            byte maxRed;
            byte maxGreen;
            byte maxBlue;

            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.blueprint_element_domain(
                        this.processorObjectAddress,
                        identification,
                        out minRed,
                        out minGreen,
                        out minBlue,
                        out maxRed,
                        out maxGreen,
                        out maxBlue));

            if (message != null)
            {
                throw new Exception(message);
            }


            return
                new Tuple<
                    System.Drawing.Color,
                    System.Drawing.Color>(
                        System.Drawing.Color.FromArgb(minRed, minGreen, minBlue),
                        System.Drawing.Color.FromArgb(maxRed, maxGreen, maxBlue));
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint get_blueprint_element_traversability(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string identification,
           out Traversability state);

        public Traversability BlueprintElementTraversability(string identification)
        {
            Traversability state;

            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.get_blueprint_element_traversability(
                        this.processorObjectAddress,
                        identification,
                        out state));

            if (message != null)
            {
                throw new Exception(message);
            }

            return state;
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint get_blueprint_element_instance_traversability(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string identification,
           out Traversability state);

        public Traversability BlueprintElementInstanceTraversability(string identification)
        {
            Traversability state;

            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.get_blueprint_element_instance_traversability(
                        this.processorObjectAddress,
                        identification,
                        out state));

            if (message != null)
            {
                throw new Exception(message);
            }

            return state;
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint meters_per_pixel_on_blueprint(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.R4)] out float metersPerPixel);

        public float MetersPerPixelOnBlueprint()
        {
            float meterPerPixel;

            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.meters_per_pixel_on_blueprint(
                        this.processorObjectAddress,
                        out meterPerPixel));

            if (message != null)
            {
                throw new Exception(message);
            }

            return meterPerPixel;
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint write_agents(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string filename,
           sbyte separator,
           sbyte lister);

        public void WriteAgents(string filename, char separator, char lister)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.write_agents(
                        this.processorObjectAddress,
                        filename,
                        Convert.ToSByte(separator),
                        Convert.ToSByte(lister)));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint write_activities(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string filename,
           sbyte separator,
           sbyte lister);

        public void WriteActivities(string filename, char separator, char lister)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.write_activities(
                        this.processorObjectAddress,
                        filename,
                        Convert.ToSByte(separator),
                        Convert.ToSByte(lister)));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint write_components(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string filename,
           sbyte separator,
           sbyte lister);

        public void WriteComponents(string filename, char separator, char lister)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.write_components(
                        this.processorObjectAddress,
                        filename,
                        Convert.ToSByte(separator),
                        Convert.ToSByte(lister)));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint write_affiliations(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string filename,
           sbyte separator,
           sbyte lister);

        public void WriteAffiliations(string filename, char separator, char lister)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.write_affiliations(
                        this.processorObjectAddress,
                        filename,
                        Convert.ToSByte(separator),
                        Convert.ToSByte(lister)));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint write_weak_affiliations_matrix(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string filename,
           sbyte separator,
           sbyte lister);

        public void WriteWeakAffiliationsMatrix(string filename, char separator, char lister)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.write_weak_affiliations_matrix(
                        this.processorObjectAddress,
                        filename,
                        Convert.ToSByte(separator),
                        Convert.ToSByte(lister)));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint write_strong_affiliations_matrix(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string filename,
           sbyte separator,
           sbyte lister);

        public void WriteStrongAffiliationsMatrix(string filename, char separator, char lister)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.write_strong_affiliations_matrix(
                        this.processorObjectAddress,
                        filename,
                        Convert.ToSByte(separator),
                        Convert.ToSByte(lister)));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint write_total_affiliations_matrix(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string filename,
           sbyte separator,
           sbyte lister);

        public void WriteTotalAffiliationsMatrix(string filename, char separator, char lister)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.write_total_affiliations_matrix(
                        this.processorObjectAddress,
                        filename,
                        Convert.ToSByte(separator),
                        Convert.ToSByte(lister)));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint write_total_potential_matrix(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string filename,
           sbyte separator,
           sbyte lister);

        public void WriteTotalPotentialMatrix(string filename, char separator, char lister)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.write_total_potential_matrix(
                        this.processorObjectAddress,
                        filename,
                        Convert.ToSByte(separator),
                        Convert.ToSByte(lister)));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint write_strong_potential_matrix_without_redundancies(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string filename,
           sbyte separator,
           sbyte lister);

        public void WriteStrongPotentialMatrixWithoutRedundancies(string filename, char separator, char lister)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.write_strong_potential_matrix_without_redundancies(
                        this.processorObjectAddress,
                        filename,
                        Convert.ToSByte(separator),
                        Convert.ToSByte(lister)));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint write_strong_potential_matrix_with_redundancies(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string filename,
           sbyte separator,
           sbyte lister);

        public void WriteStrongPotentialMatrixWithRedundancies(string filename, char separator, char lister)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.write_strong_potential_matrix_with_redundancies(
                        this.processorObjectAddress,
                        filename,
                        Convert.ToSByte(separator),
                        Convert.ToSByte(lister)));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint write_comparative_matrix_without_redundancies(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string filename,
           sbyte separator,
           sbyte lister);

        public void WriteComparativeMatrixWithoutRedundancies(string filename, char separator, char lister)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.write_comparative_matrix_without_redundancies(
                        this.processorObjectAddress,
                        filename,
                        Convert.ToSByte(separator),
                        Convert.ToSByte(lister)));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint write_comparative_matrix_with_redundancies(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string filename,
           sbyte separator,
           sbyte lister);

        public void WriteComparativeMatrixWithRedundancies(string filename, char separator, char lister)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.write_comparative_matrix_with_redundancies(
                        this.processorObjectAddress,
                        filename,
                        Convert.ToSByte(separator),
                        Convert.ToSByte(lister)));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint write_element_instances(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string directory,
           sbyte separator,
           sbyte lister);

        public void WriteElementInstances(string directory, char separator, char lister)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.write_element_instances(
                        this.processorObjectAddress,
                        directory,
                        Convert.ToSByte(separator),
                        Convert.ToSByte(lister)));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nint write_element_instance_neighborhood(
           nuint processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string directory,
           sbyte separator,
           sbyte lister);

        public void WriteElementInstanceNeighborhood(string directory, char separator, char lister)
        {
            string? message =
                Marshal.PtrToStringAnsi(
                    Processor.write_element_instance_neighborhood(
                        this.processorObjectAddress,
                        directory,
                        Convert.ToSByte(separator),
                        Convert.ToSByte(lister)));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern nuint construct();

        public Processor()
        {
            this.processorObjectAddress = Processor.construct();
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern void destroy(nuint processorObjectAddress);

        ~Processor()
        {
            Processor.destroy(this.processorObjectAddress);
        }
    }
}