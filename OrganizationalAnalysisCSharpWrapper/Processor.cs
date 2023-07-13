﻿using System.Runtime.InteropServices;

namespace OrganizationalAnalysis
{
    public class Processor
    {
        readonly private ulong processorObjectAddress;

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern IntPtr insert_or_assign_agent(
            [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
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
        private static extern IntPtr erase_agent(
            [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
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
        private static extern IntPtr insert_agent_group(
            [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
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
        private static extern IntPtr erase_agent_group(
            [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
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
        private static extern IntPtr insert_or_edit_activity(
            [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
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
        private static extern IntPtr erase_activity(
            [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
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
        private static extern IntPtr insert_activity_group(
            [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
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
        private static extern IntPtr erase_activity_group(
            [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
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
        private static extern IntPtr insert_agent_in_charge_of_activity(
            [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
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
        private static extern IntPtr erase_agent_in_charge_of_activity(
            [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
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
        private static extern IntPtr insert_activity_dependency(
            [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
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
        private static extern IntPtr erase_activity_dependency(
           [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
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
        private static extern IntPtr insert_or_edit_component(
           [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
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
        private static extern IntPtr erase_component(
           [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
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
        private static extern IntPtr insert_component_group(
            [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
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
        private static extern IntPtr erase_component_group(
            [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
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
        private static extern IntPtr insert_component_interface(
           [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
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
        private static extern IntPtr erase_component_interface(
           [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
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
        private static extern IntPtr insert_or_assign_affiliation(
           [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
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
        private static extern IntPtr erase_affiliation(
           [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
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
        private static extern void clear(
           [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress);

        public void Clear()
        {
            Processor.clear(this.processorObjectAddress);
        }

        private delegate void ResizeVector(
            [MarshalAs(UnmanagedType.U8)] ulong size);

        private delegate void InsertStringIntoPosition1(
            [MarshalAs(UnmanagedType.LPStr)] string activity,
            [MarshalAs(UnmanagedType.U8)] ulong position);

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern IntPtr identify_parallelizations(
           [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
           [MarshalAs(UnmanagedType.FunctionPtr)] ResizeVector resizer,
           [MarshalAs(UnmanagedType.FunctionPtr)] InsertStringIntoPosition1 inserter);

        public List<SortedSet<string>> IdentifyParallelizations()
        {
            var parallelizations = new List<SortedSet<string>>();

            ResizeVector resizer =
                ([MarshalAs(UnmanagedType.U8)] ulong size) =>
                {
                    for (ulong i = 0; i < size; i++)
                    {
                        parallelizations.Add(new SortedSet < string > ());
                    }
                };

            InsertStringIntoPosition1 inserter =
                ([MarshalAs(UnmanagedType.LPStr)] string activity, [MarshalAs(UnmanagedType.U8)] ulong position) =>
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
            [MarshalAs(UnmanagedType.U8)] ulong position);

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern IntPtr identify_priorities(
           [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
           [MarshalAs(UnmanagedType.FunctionPtr)] InsertPairOfStringAndSizeT inserter);

        public SortedDictionary<string, ulong> IdentifyPriorities()
        {
            var priorities = new SortedDictionary<string, ulong>();

            InsertPairOfStringAndSizeT inserter =
                ([MarshalAs(UnmanagedType.LPStr)] string activity, [MarshalAs(UnmanagedType.U8)] ulong priority) =>
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

        private delegate void InsertString(
            [MarshalAs(UnmanagedType.LPStr)] string componentWithoutAgents);

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern IntPtr validate_agents_in_charge_for_components(
           [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
           [MarshalAs(UnmanagedType.FunctionPtr)] InsertString inserter);

        public List<string> ValidateAgentsInChargeForComponents()
        {
            var componentsWithoutAgents = new List<string>();

            InsertString inserter =
                ([MarshalAs(UnmanagedType.LPStr)] string componentWithoutAgents) =>
                {
                    componentsWithoutAgents.Add(new string(componentWithoutAgents));
                };

            string? message = Marshal.PtrToStringAnsi(Processor.validate_agents_in_charge_for_components(this.processorObjectAddress, inserter));

            if (message != null)
            {
                throw new Exception(message);
            }

            return componentsWithoutAgents;
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern IntPtr attribute_agents_in_charge_for_components(
           [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
           [MarshalAs(UnmanagedType.R4)] float minimumRelationDegree);

        public void AttributeAgentsInChargeForComponents(float minimumRelationDegree)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.attribute_agents_in_charge_for_components(this.processorObjectAddress, minimumRelationDegree));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern IntPtr align_architecture_process_between_components_and_organization(
           [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
           [MarshalAs(UnmanagedType.R4)] float minimumRelationDegree);

        public void AlignArchitectureProcessBetweenComponentsAndOrganization(float minimumRelationDegree)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.align_architecture_process_between_components_and_organization(this.processorObjectAddress, minimumRelationDegree));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern IntPtr align_architecture_process_between_activities_and_organization(
           [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
           [MarshalAs(UnmanagedType.R4)] float minimumRelationDegree);

        public void AlignArchitectureProcessBetweenActivitiesAndOrganization(float minimumRelationDegree)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.align_architecture_process_between_activities_and_organization(this.processorObjectAddress, minimumRelationDegree));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        private delegate void ResizeMatrix(
            [MarshalAs(UnmanagedType.U8)] ulong rows,
            [MarshalAs(UnmanagedType.U8)] ulong columns);

        private delegate void InsertFloatIntoPosition2(
            [MarshalAs(UnmanagedType.R4)] float value,
            [MarshalAs(UnmanagedType.U8)] ulong row,
            [MarshalAs(UnmanagedType.U8)] ulong column);

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern IntPtr activities_dependencies_matrix(
           [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
           [MarshalAs(UnmanagedType.FunctionPtr)] ResizeMatrix resizer,
           [MarshalAs(UnmanagedType.FunctionPtr)] InsertFloatIntoPosition2 inserter);

        public List<List<float>> ActivitiesDependenciesMatrix()
        {
            List<List<float>> matrix = new List<List<float>>();

            ResizeMatrix resizer =
                ([MarshalAs(UnmanagedType.U8)] ulong rows, [MarshalAs(UnmanagedType.U8)] ulong columns) =>
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
                ([MarshalAs(UnmanagedType.R4)] float value, [MarshalAs(UnmanagedType.U8)] ulong row, [MarshalAs(UnmanagedType.U8)] ulong column) =>
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
        private static extern IntPtr components_interfaces_matrix(
           [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
           [MarshalAs(UnmanagedType.FunctionPtr)] ResizeMatrix resizer,
           [MarshalAs(UnmanagedType.FunctionPtr)] InsertFloatIntoPosition2 inserter);

        public List<List<float>> ComponentsInterfacesMatrix()
        {
            List<List<float>> matrix = new List<List<float>>();

            ResizeMatrix resizer =
                ([MarshalAs(UnmanagedType.U8)] ulong rows, [MarshalAs(UnmanagedType.U8)] ulong columns) =>
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
                ([MarshalAs(UnmanagedType.R4)] float value, [MarshalAs(UnmanagedType.U8)] ulong row, [MarshalAs(UnmanagedType.U8)] ulong column) =>
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
        private static extern IntPtr weak_affiliations_matrix(
           [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
           [MarshalAs(UnmanagedType.FunctionPtr)] ResizeMatrix resizer,
           [MarshalAs(UnmanagedType.FunctionPtr)] InsertFloatIntoPosition2 inserter);

        public List<List<float>> WeakAffiliationsMatrix()
        {
            List<List<float>> matrix = new List<List<float>>();

            ResizeMatrix resizer =
                ([MarshalAs(UnmanagedType.U8)] ulong rows, [MarshalAs(UnmanagedType.U8)] ulong columns) =>
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
                ([MarshalAs(UnmanagedType.R4)] float value, [MarshalAs(UnmanagedType.U8)] ulong row, [MarshalAs(UnmanagedType.U8)] ulong column) =>
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
        private static extern IntPtr strong_affiliations_matrix(
          [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
          [MarshalAs(UnmanagedType.FunctionPtr)] ResizeMatrix resizer,
          [MarshalAs(UnmanagedType.FunctionPtr)] InsertFloatIntoPosition2 inserter);

        public List<List<float>> StrongAffiliationsMatrix()
        {
            List<List<float>> matrix = new List<List<float>>();

            ResizeMatrix resizer =
                ([MarshalAs(UnmanagedType.U8)] ulong rows, [MarshalAs(UnmanagedType.U8)] ulong columns) =>
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
                ([MarshalAs(UnmanagedType.R4)] float value, [MarshalAs(UnmanagedType.U8)] ulong row, [MarshalAs(UnmanagedType.U8)] ulong column) =>
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
        private static extern IntPtr comparative_matrix_without_redundancies(
           [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
           [MarshalAs(UnmanagedType.FunctionPtr)] ResizeMatrix resizer,
           [MarshalAs(UnmanagedType.FunctionPtr)] InsertFloatIntoPosition2 inserter);

        public List<List<float>> ComparativeMatrixWithoutRedundancies()
        {
            List<List<float>> matrix = new List<List<float>>();

            ResizeMatrix resizer =
                ([MarshalAs(UnmanagedType.U8)] ulong rows, [MarshalAs(UnmanagedType.U8)] ulong columns) =>
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
                ([MarshalAs(UnmanagedType.R4)] float value, [MarshalAs(UnmanagedType.U8)] ulong row, [MarshalAs(UnmanagedType.U8)] ulong column) =>
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
        private static extern IntPtr comparative_matrix_with_redundancies(
           [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
           [MarshalAs(UnmanagedType.FunctionPtr)] ResizeMatrix resizer,
           [MarshalAs(UnmanagedType.FunctionPtr)] InsertFloatIntoPosition2 inserter);

        public List<List<float>> ComparativeMatrixWithRedundancies()
        {
            List<List<float>> matrix = new List<List<float>>();

            ResizeMatrix resizer =
                ([MarshalAs(UnmanagedType.U8)] ulong rows, [MarshalAs(UnmanagedType.U8)] ulong columns) =>
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
                ([MarshalAs(UnmanagedType.R4)] float value, [MarshalAs(UnmanagedType.U8)] ulong row, [MarshalAs(UnmanagedType.U8)] ulong column) =>
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
        private static extern IntPtr write_activities_matrix(
           [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string filename,
           [MarshalAs(UnmanagedType.I1)] sbyte separator);

        public void WriteActivitiesMatrix(string filename, char separator)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.write_activities_matrix(this.processorObjectAddress, filename, Convert.ToSByte(separator)));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern IntPtr write_weak_affiliations_matrix(
           [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string filename,
           [MarshalAs(UnmanagedType.I1)] sbyte separator);

        public void WriteWeakAffiliationsMatrix(string filename, char separator)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.write_weak_affiliations_matrix(this.processorObjectAddress, filename, Convert.ToSByte(separator)));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern IntPtr write_strong_affiliations_matrix(
           [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string filename,
           [MarshalAs(UnmanagedType.I1)] sbyte separator);

        public void WriteStrongAffiliationsMatrix(string filename, char separator)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.write_strong_affiliations_matrix(this.processorObjectAddress, filename, Convert.ToSByte(separator)));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern IntPtr write_components_matrix(
           [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string filename,
           [MarshalAs(UnmanagedType.I1)] sbyte separator);

        public void WriteComponentsMatrix(string filename, char separator)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.write_components_matrix(this.processorObjectAddress, filename, Convert.ToSByte(separator)));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern IntPtr write_total_potential_matrix(
           [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string filename,
           [MarshalAs(UnmanagedType.I1)] sbyte separator);

        public void WriteTotalPotentialMatrix(string filename, char separator)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.write_total_potential_matrix(this.processorObjectAddress, filename, Convert.ToSByte(separator)));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern IntPtr write_strong_potential_matrix_without_redundancies(
           [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string filename,
           [MarshalAs(UnmanagedType.I1)] sbyte separator);

        public void WriteStrongPotentialMatrixWithoutRedundancies(string filename, char separator)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.write_strong_potential_matrix_without_redundancies(this.processorObjectAddress, filename, Convert.ToSByte(separator)));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern IntPtr write_strong_potential_matrix_with_redundancies(
           [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string filename,
           [MarshalAs(UnmanagedType.I1)] sbyte separator);

        public void WriteStrongPotentialMatrixWithRedundancies(string filename, char separator)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.write_strong_potential_matrix_with_redundancies(this.processorObjectAddress, filename, Convert.ToSByte(separator)));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern IntPtr write_comparative_matrix_without_redundancies(
           [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string filename,
           [MarshalAs(UnmanagedType.I1)] sbyte separator);

        public void WriteComparativeMatrixWithoutRedundancies(string filename, char separator)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.write_comparative_matrix_without_redundancies(this.processorObjectAddress, filename, Convert.ToSByte(separator)));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern IntPtr write_comparative_matrix_with_redundancies(
           [MarshalAs(UnmanagedType.U8)] ulong processorObjectAddress,
           [MarshalAs(UnmanagedType.LPStr)] string filename,
           [MarshalAs(UnmanagedType.I1)] sbyte separator);

        public void WriteComparativeMatrixWithRedundancies(string filename, char separator)
        {
            string? message = Marshal.PtrToStringAnsi(Processor.write_comparative_matrix_with_redundancies(this.processorObjectAddress, filename, Convert.ToSByte(separator)));

            if (message != null)
            {
                throw new Exception(message);
            }
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern ulong construct();

        public Processor()
        {
            this.processorObjectAddress = Processor.construct();
        }

        [DllImport("OrganizationalAnalysisLibrary.dll")]
        private static extern void destroy(ulong processorObjectAddress);

        ~Processor()
        {
            Processor.destroy(this.processorObjectAddress);
        }
    }
}