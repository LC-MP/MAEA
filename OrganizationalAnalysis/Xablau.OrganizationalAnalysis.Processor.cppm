// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

// MIT License
//
// Copyright (c) 2023 Jean Amaro <jean.amaro@outlook.com.br>,
//                    Lucas Melchiori Pereira <lc.melchiori@gmail.com>
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

// We thank FAPESP (Fundação de Amparo à Pesquisa do Estado de São Paulo) for
// funding this research project.
// FAPESP process number: 2020/15909-8

export module xablau.organizational_analysis:processor;
export import :blueprint;
export import :fundamental_definitions;
export import :reader;
export import :writer;

export import <charconv>;
export import <iostream>;
export import <numeric>;
export import <random>;
export import <regex>;
export import <stdexcept>;

export import xablau.algebra;
export import xablau.graph;
export import xablau.io;

export namespace xablau::organizational_analysis
{
	template < bool ComponentsInterfacesAreReciprocal >
	class processor final
	{
	private:
		using node_type = xablau::graph::node < std::string >;

		enum class comparison_mode
		{
			component_and_organization,
			activity_and_organization,
			invalid
		};

		using matrix_type =
			xablau::algebra::tensor_dense_dynamic <
				float,
				xablau::algebra::tensor_rank < 2 >,
				xablau::algebra::tensor_contiguity < false > >;

		using blueprint_type = xablau::organizational_analysis::blueprint;
		using task_type = xablau::organizational_analysis::activity::task;

		[[nodiscard]] matrix_type create_activities_matrix(
			const std::map < std::string, size_t > &activityKeyToIndexMap) const
		{
			matrix_type activitiesMatrix(
				this->_activities.size(),
				this->_activities.size());

			for (const auto &activity1 : this->_activities)
			{
				const auto edges = this->_activity_dependencies.edges(activity1.identification);

				if (!edges.has_value())
				{
					throw std::runtime_error("Could not find node " + activity1.identification + ".");
				}

				for (const auto &activity2 : this->_activities)
				{
					if (this->_activity_dependencies.contains(activity1.identification, activity2.identification))
					{
						activitiesMatrix(
							activityKeyToIndexMap.at(activity1.identification),
							activityKeyToIndexMap.at(activity2.identification)) =
								edges.value().get().at(activity2.identification).weight();
					}
				}
			}

			return activitiesMatrix;
		}

		[[nodiscard]] matrix_type create_components_matrix(
			const std::map < std::string, size_t > &componentKeyToIndexMap) const
		{
			matrix_type componentsMatrix(
				this->_components.size(),
				this->_components.size());

			for (const auto &component1 : this->_components)
			{
				for (const auto &component2 : this->_components)
				{
					if (this->_component_interactions.contains(component1.identification, component2.identification))
					{
						componentsMatrix(
							componentKeyToIndexMap.at(component1.identification),
							componentKeyToIndexMap.at(component2.identification)) = float{1};
					}
				}
			}

			return componentsMatrix;
		}

		[[nodiscard]] std::array < matrix_type, 3 > create_affiliations_matrices(
			const std::map < std::string, size_t > &activityKeyToIndexMap,
			const std::map < std::string, size_t > &componentKeyToIndexMap) const
		{
			std::array < matrix_type, 3 > affiliationsMatrices;

			affiliationsMatrices[0].resize(
				this->_activities.size(),
				this->_components.size(),
				float{});

			affiliationsMatrices[1].resize(
				this->_activities.size(),
				this->_components.size(),
				float{});

			affiliationsMatrices[2].resize(
				this->_activities.size(),
				this->_components.size(),
				float{});

			for (const auto &activity : this->_activities)
			{
				const auto iterator1 = this->_affiliations.find(activity.identification);

				if (iterator1 == this->_affiliations.cend())
				{
					throw std::runtime_error("Could not find the responsability of the activity " + activity.identification + ".");
				}

				for (const auto &component : this->_components)
				{
					const auto iterator2 = iterator1->second.find(component.identification);
				
					if (iterator2 != iterator1->second.cend())
					{
						if (iterator2->second >= this->_indirectly_related_degree)
						{
							affiliationsMatrices[0](
								activityKeyToIndexMap.at(activity.identification),
								componentKeyToIndexMap.at(component.identification)) = float{1};
						}

						if (iterator2->second >= this->_directly_related_degree)
						{
							affiliationsMatrices[1](
								activityKeyToIndexMap.at(activity.identification),
								componentKeyToIndexMap.at(component.identification)) = float{1};
						}

						affiliationsMatrices[2](
							activityKeyToIndexMap.at(activity.identification),
							componentKeyToIndexMap.at(component.identification)) = iterator2->second;
					}
				}
			}

			return affiliationsMatrices;
		}

		void create_comparative_matrix_step_1(
			matrix_type &comparativeMatrix,
			const matrix_type &strongPotentialMatrix,
			const matrix_type &baseMatrix)
		{
			for (size_t i = 0; i < comparativeMatrix.dimensionalities()[0]; i++)
			{
				for (size_t j = 0; j < comparativeMatrix.dimensionalities()[1]; j++)
				{
					if (i == j)
					{
						continue;
					}

					auto &finalComparativeMatrixCell = comparativeMatrix(i, j);
					const auto strongPotentialMatrixCell = strongPotentialMatrix(i, j);
					const auto baseMatrixCell = baseMatrix(i, j);

					if (strongPotentialMatrixCell > float{} && baseMatrixCell == float{})
					{
						finalComparativeMatrixCell = this->_indirectly_related_degree;
					}
				}
			}
		}

		void create_comparative_matrix_step_2(
			matrix_type &finalComparativeMatrix,
			const matrix_type &totalPotentialMatrix,
			const matrix_type &baseMatrix)
		{
			for (size_t i = 0; i < finalComparativeMatrix.dimensionalities()[0]; i++)
			{
				for (size_t j = 0; j < finalComparativeMatrix.dimensionalities()[1]; j++)
				{
					if (i == j)
					{
						continue;
					}

					auto &finalComparativeMatrixCell = finalComparativeMatrix(i, j);
					const auto totalPotentialMatrixCell = totalPotentialMatrix(i, j);
					const auto baseMatrixCell = baseMatrix(i, j);

					if (baseMatrixCell != float{})
					{
						if (totalPotentialMatrixCell != float{})
						{
							finalComparativeMatrixCell = this->_related_degree;
						}

						else
						{
							finalComparativeMatrixCell = this->_directly_related_degree;
						}
					}
				}
			}
		}

		template < typename BaseType >
		[[nodiscard]] matrix_type erase_redundancies(
			const matrix_type &strongPotentialMatrixWithRedundancies,
			const std::map < size_t, std::string > &baseIndexToKeyMap,
			const BaseType &base) const
		{
			auto copyStrongPotentialMatrixWithRedundancies = strongPotentialMatrixWithRedundancies;

			for (size_t i = 0; i < copyStrongPotentialMatrixWithRedundancies.dimensionalities()[0]; i++)
			{
				for (size_t j = 0; j < copyStrongPotentialMatrixWithRedundancies.dimensionalities()[1]; j++)
				{
					auto &cell = copyStrongPotentialMatrixWithRedundancies(i, j);

					if (cell != float{})
					{
						const auto &key1 = baseIndexToKeyMap.at(i);
						const auto &key2 = baseIndexToKeyMap.at(j);
						const auto &agentsInCharge1 = base.find(key1)->agents_in_charge;
						const auto &agentsInCharge2 = base.find(key2)->agents_in_charge;

						bool thereAreRedundancies = false;

						for (const auto agentInCharge1 : agentsInCharge1)
						{
							for (const auto agentInCharge2 : agentsInCharge2)
							{
								if (agentInCharge1 == agentInCharge2)
								{
									thereAreRedundancies = true;

									break;
								}
							}

							if (thereAreRedundancies)
							{
								break;
							}
						}

						if (thereAreRedundancies)
						{
							cell = float{};
						}
					}
				}
			}

			return copyStrongPotentialMatrixWithRedundancies;
		}

		template < typename DigraphType >
		[[nodiscard]] static std::vector < std::set < std::string > > identify_parallelizations(
			const DigraphType &activitiesSequence)
		{
			using node_type = xablau::graph::node < std::string >;

			size_t index{};
			const auto stronglyConnectedComponents = activitiesSequence.Tarjan_strongly_connected_components();
			std::map < node_type, size_t > individualNodeToStronglyConnectedComponentMap;
			std::map < size_t, std::set < node_type > > stronglyConnectedComponentToIndividualNodeMap;
			std::random_device randomDevice{};
			std::default_random_engine engine(randomDevice());
			std::uniform_int_distribution < size_t > distribution(0, std::numeric_limits < size_t > ::max());

			for (const auto &[
					stronglyConnectedComponentNodeIdentification,
					stronglyConnectedComponentElements] : stronglyConnectedComponents)
			{
				if (!individualNodeToStronglyConnectedComponentMap.contains(stronglyConnectedComponentNodeIdentification))
				{
					for (const auto &node : stronglyConnectedComponentElements)
					{
						individualNodeToStronglyConnectedComponentMap.insert(std::make_pair(node, index));
					}

					stronglyConnectedComponentToIndividualNodeMap.insert(std::make_pair(index, stronglyConnectedComponentElements));
					index++;
				}
			}

			xablau::graph::digraph <
				xablau::graph::node < size_t >,
				xablau::graph::graph_container_type < xablau::graph::graph_container_type_value::ordered >,
				xablau::graph::edge < float > > mappedActivitiesSequence{};

			for (const auto &[node, edges] : activitiesSequence.container())
			{
				const auto node1 = individualNodeToStronglyConnectedComponentMap.at(node);

				mappedActivitiesSequence.insert(node1);

				for (const auto &[connectedNode, edge] : edges)
				{
					const auto node2 = individualNodeToStronglyConnectedComponentMap.at(connectedNode);

					if (node1 != node2)
					{
						mappedActivitiesSequence.insert(node1, node2);
					}
				}
			}

			std::vector < std::set < std::string > > finalActivitiesSequence;

			while (!mappedActivitiesSequence.empty())
			{
				const auto sourceNodes = mappedActivitiesSequence.source_nodes();

				finalActivitiesSequence.emplace_back();

				for (const auto sourceNode : sourceNodes)
				{
					for (const auto &individualNode : stronglyConnectedComponentToIndividualNodeMap.at(sourceNode.value))
					{
						finalActivitiesSequence.back().insert(individualNode.value);
					}
				}

				for (const auto sourceNode : sourceNodes)
				{
					mappedActivitiesSequence.erase(sourceNode);
				}
			}

			return finalActivitiesSequence;
		}

		template < comparison_mode ComparisonMode >
		void align_architecture_process(
			std::map < size_t, std::string > &baseIndexToKeyMap)
		{
			size_t index{};
			std::map < std::string, size_t > activityKeyToIndexMap;
			std::map < std::string, size_t > componentKeyToIndexMap;

			if (this->_activities.size() == 0)
			{
				throw std::runtime_error("There are no registered activities.");
			}

			if (this->_components.size() == 0)
			{
				throw std::runtime_error("There are no registered components.");
			}

			if constexpr (ComparisonMode == comparison_mode::component_and_organization)
			{
				if (this->components_without_agents_in_charge().size() != 0)
				{
					throw std::runtime_error("There are components without agents in charge.");
				}
			}

			else if constexpr (ComparisonMode == comparison_mode::activity_and_organization)
			{
				if (this->activities_without_agents_in_charge().size() != 0)
				{
					throw std::runtime_error("There are activities without agents in charge.");
				}
			}

			for (const auto &activity : this->_activities)
			{
				activityKeyToIndexMap.emplace(activity.identification, index);

				if constexpr (ComparisonMode == comparison_mode::activity_and_organization)
				{
					baseIndexToKeyMap.emplace(index, activity.identification);
				}

				index++;
			}

			index = 0;

			for (const auto &component : this->_components)
			{
				componentKeyToIndexMap.emplace(component.identification, index);

				if constexpr (ComparisonMode == comparison_mode::component_and_organization)
				{
					baseIndexToKeyMap.emplace(index, component.identification);
				}

				index++;
			}

			this->_activities_dependencies_matrix = this->create_activities_matrix(activityKeyToIndexMap);
			this->_components_interfaces_matrix = this->create_components_matrix(componentKeyToIndexMap);
			this->_affiliations_matrices = this->create_affiliations_matrices(activityKeyToIndexMap, componentKeyToIndexMap);

			std::reference_wrapper < matrix_type > baseMatrix = this->_activities_dependencies_matrix;

			if constexpr (ComparisonMode == comparison_mode::activity_and_organization)
			{
				this->_potential_matrices[0] =
					this->_affiliations_matrices[0] * this->_components_interfaces_matrix * this->_affiliations_matrices[0].transpose();

				this->_potential_matrices[1] =
					this->_affiliations_matrices[1] * this->_components_interfaces_matrix * this->_affiliations_matrices[1].transpose();

				this->_strong_potential_matrix_without_redundancies =
					this->erase_redundancies(
						this->_potential_matrices[1],
						baseIndexToKeyMap,
						this->_activities);
			}

			else if constexpr (ComparisonMode == comparison_mode::component_and_organization)
			{
				this->_potential_matrices[0] =
					this->_affiliations_matrices[0].transpose() * this->_activities_dependencies_matrix * this->_affiliations_matrices[0];

				this->_potential_matrices[1] =
					this->_affiliations_matrices[1].transpose() * this->_activities_dependencies_matrix * this->_affiliations_matrices[1];

				this->_strong_potential_matrix_without_redundancies =
					this->erase_redundancies(
						this->_potential_matrices[1],
						baseIndexToKeyMap,
						this->_components);

				baseMatrix = this->_components_interfaces_matrix;
			}

			else
			{
				throw std::runtime_error("Unknown alignment.");
			}

			if constexpr (ComparisonMode == comparison_mode::activity_and_organization)
			{
				this->_comparative_matrix_without_redundancies_step_1.resize(this->_activities_dependencies_matrix.dimensionalities());
			}

			else
			{
				this->_comparative_matrix_without_redundancies_step_1.resize(this->_components_interfaces_matrix.dimensionalities());
			}

			this->_comparative_matrix_without_redundancies_step_1.fill(float{});

			this->create_comparative_matrix_step_1(
				this->_comparative_matrix_without_redundancies_step_1,
				this->_strong_potential_matrix_without_redundancies,
				baseMatrix.get());

			this->_comparative_matrix_without_redundancies_step_2 = this->_comparative_matrix_without_redundancies_step_1;

			this->create_comparative_matrix_step_2(
				this->_comparative_matrix_without_redundancies_step_2,
				this->_potential_matrices[0],
				baseMatrix.get());

			if constexpr (ComparisonMode == comparison_mode::activity_and_organization)
			{
				this->_comparative_matrix_with_redundancies_step_1.resize(this->_activities_dependencies_matrix.dimensionalities());
			}

			else
			{
				this->_comparative_matrix_with_redundancies_step_1.resize(this->_components_interfaces_matrix.dimensionalities());
			}

			this->_comparative_matrix_with_redundancies_step_1.fill(float{});

			this->create_comparative_matrix_step_1(
				this->_comparative_matrix_with_redundancies_step_1,
				this->_potential_matrices[1],
				baseMatrix.get());

			this->_comparative_matrix_with_redundancies_step_2 = this->_comparative_matrix_with_redundancies_step_1;

			this->create_comparative_matrix_step_2(
				this->_comparative_matrix_with_redundancies_step_2,
				this->_potential_matrices[0],
				baseMatrix.get());

			this->_up_to_date = true;
			this->_last_comparison_mode = ComparisonMode;
		}

		agents_type _agents{};
		activities_type _activities{};
		activity_dependencies_type _activity_dependencies{};
		components_type _components{};
		component_interactions_type < ComponentsInterfacesAreReciprocal > _component_interactions{};
		affiliations_type _affiliations{};
		blueprint_type _blueprint{};

		bool _up_to_date = false;
		comparison_mode _last_comparison_mode = comparison_mode::invalid;

		float _indirectly_related_degree{};
		float _related_degree{};
		float _directly_related_degree{};
		matrix_type _components_interfaces_matrix{};
		matrix_type _activities_dependencies_matrix{};
		std::array < matrix_type, 3 > _affiliations_matrices{};
		std::array < matrix_type, 2 > _potential_matrices{};
		matrix_type _strong_potential_matrix_without_redundancies{};
		matrix_type _comparative_matrix_without_redundancies_step_1{};
		matrix_type _comparative_matrix_without_redundancies_step_2{};
		matrix_type _comparative_matrix_with_redundancies_step_1{};
		matrix_type _comparative_matrix_with_redundancies_step_2{};

	public:
		void indirectly_related_degree(const float degree) noexcept
		{
			this->_indirectly_related_degree = degree;
		}

		void related_degree(const float degree) noexcept
		{
			this->_related_degree = degree;
		}

		void directly_related_degree(const float degree) noexcept
		{
			this->_directly_related_degree = degree;
		}

		void insert_or_assign_agent(
			const std::string &agent,
			const std::string &role)
		{
			auto node = this->_agents.extract(agent);

			if (node.empty())
			{
				this->_agents.emplace(agent, role);
			}

			else
			{
				node.value().role = role;

				this->_agents.insert(std::move(node));
			}
		}

		void erase_agent(const std::string &agent)
		{
			if (const auto iterator = this->_agents.find(agent);
				iterator != this->_agents.end())
			{
				this->_agents.erase(iterator);
			}

			else
			{
				throw std::runtime_error(std::format("Agent \"{}\" does not exist.", agent));
			}

			for (auto iterator1 = this->_activities.begin(); iterator1 != this->_activities.end(); ++iterator1)
			{
				if (const auto iterator2 = iterator1->agents_in_charge.find(agent);
					iterator2 != iterator1->agents_in_charge.end())
				{
					auto node = this->_activities.extract(iterator1);

					node.value().agents_in_charge.erase(iterator2);

					iterator1 = this->_activities.insert(std::move(node)).position;
				}
			}

			for (auto iterator1 = this->_components.begin(); iterator1 != this->_components.end(); ++iterator1)
			{
				if (const auto iterator2 = iterator1->agents_in_charge.find(agent);
					iterator2 != iterator1->agents_in_charge.end())
				{
					auto node = this->_components.extract(iterator1);

					node.value().agents_in_charge.erase(iterator2);

					iterator1 = this->_components.insert(std::move(node)).position;
				}
			}
		}

		void insert_agent_group(const std::string &agent, const std::string &group)
		{
			auto node = this->_agents.extract(agent);

			if (node.empty())
			{
				throw std::runtime_error(std::format("Agent \"{}\" does not exist.", agent));
			}

			node.value().groups.insert(group);

			this->_agents.insert(std::move(node));
		}

		void erase_agent_group(const std::string &agent, const std::string &group)
		{
			auto node = this->_agents.extract(agent);

			if (node.empty())
			{
				throw std::runtime_error(std::format("Agent \"{}\" does not exist.", agent));
			}

			node.value().groups.erase(group);

			this->_agents.insert(std::move(node));
		}

		void insert_or_edit_activity(
			const std::string &activity,
			const std::string &name)
		{
			auto node = this->_activities.extract(activity);

			if (node.empty())
			{
				this->_activities.emplace(activity, name);
				this->_activity_dependencies.insert(activity);
			}

			else
			{
				node.value().name = name;

				this->_activities.insert(std::move(node));
			}
		}

		void erase_activity(const std::string &activity)
		{
			const auto iterator = this->_activities.find(activity);

			if (iterator == this->_activities.end())
			{
				throw std::runtime_error(std::format("Activity \"{}\" does not exist.", activity));
			}

			this->_activities.erase(iterator);
			this->_activity_dependencies.erase(activity);
			this->_affiliations.erase(activity);
		}

		void insert_activity_group(const std::string &activity, const std::string &group)
		{
			auto node = this->_activities.extract(activity);

			if (node.empty())
			{
				throw std::runtime_error(std::format("Activity \"{}\" does not exist.", activity));
			}

			node.value().groups.insert(group);

			this->_activities.insert(std::move(node));
		}

		void erase_activity_group(const std::string &activity, const std::string &group)
		{
			auto node = this->_activities.extract(activity);

			if (node.empty())
			{
				throw std::runtime_error(std::format("Activity \"{}\" does not exist.", activity));
			}

			node.value().groups.erase(group);

			this->_activities.insert(std::move(node));
		}

		void insert_task(
			const std::string &activity,
			const std::string &task_identification,
			const std::string &task_name,
			const float degree,
			const std::array < size_t, 2 > &task_coordinates)
		{
			auto node = this->_activities.extract(activity);

			if (node.empty())
			{
				throw std::runtime_error(std::format("Activity \"{}\" does not exist.", activity));
			}

			node.value().tasks.insert(task_type(task_identification, task_name, degree, task_coordinates));

			this->_activities.insert(std::move(node));
		}

		void insert_task_dependency(
			const std::string &activity,
			const std::string &task_dependent,
			const std::string &task_dependency)
		{
			const auto _task_dependent = task_type(task_dependent);
			const auto _task_dependency = task_type(task_dependency);
			auto node = this->_activities.extract(activity);

			if (node.empty())
			{
				throw std::runtime_error(std::format("Activity \"{}\" does not exist.", activity));
			}

			if (const bool dependentExists = node.value().tasks.contains(_task_dependent),
				dependencyExists = node.value().tasks.contains(_task_dependency);
				!dependentExists || !dependencyExists)
			{
				this->_activities.insert(std::move(node));

				if (!dependentExists)
				{
					throw std::runtime_error(std::format("Task \"{}\" does not exist.", task_dependent));
				}

				throw std::runtime_error(std::format("Task \"{}\" does not exist.", task_dependency));
			}

			node.value().tasks.insert(_task_dependent, _task_dependency);

			this->_activities.insert(std::move(node));
		}

		void erase_task(
			const std::string &activity,
			const std::string &task)
		{
			const auto _task = task_type(task);
			auto node = this->_activities.extract(activity);

			if (node.empty())
			{
				throw std::runtime_error(std::format("Activity \"{}\" does not exist.", activity));
			}

			if (!node.value().tasks.contains(_task))
			{
				this->_activities.insert(std::move(node));

				throw std::runtime_error(std::format("Task \"{}\" does not exist.", task));
			}

			node.value().tasks.erase(_task);

			this->_activities.insert(std::move(node));
		}

		void erase_task_dependency(
			const std::string &activity,
			const std::string &task_dependent,
			const std::string &task_dependency)
		{
			const auto _task_dependent = task_type(task_dependent);
			const auto _task_dependency = task_type(task_dependency);
			auto node = this->_activities.extract(activity);

			if (node.empty())
			{
				throw std::runtime_error(std::format("Activity \"{}\" does not exist.", activity));
			}

			if (const bool dependentExists = node.value().tasks.contains(_task_dependent),
				dependencyExists = node.value().tasks.contains(_task_dependency);
				!dependentExists || !dependencyExists)
			{
				this->_activities.insert(std::move(node));

				if (!dependentExists)
				{
					throw std::runtime_error(std::format("Task \"{}\" does not exist.", task_dependent));
				}

				throw std::runtime_error(std::format("Task \"{}\" does not exist.", task_dependency));
			}

			node.value().tasks.erase(_task_dependent, _task_dependency);

			this->_activities.insert(std::move(node));
		}

		void insert_agent_in_charge_of_activity(
			const std::string &agent,
			const std::string &activity)
		{
			if (!this->_agents.contains(agent))
			{
				throw std::runtime_error(std::format("Agent \"{}\" does not exist.", agent));
			}

			auto node = this->_activities.extract(activity);

			if (node.empty())
			{
				throw std::runtime_error(std::format("Activity \"{}\" does not exist.", activity));
			}

			node.value().agents_in_charge.insert(agent);

			this->_activities.insert(std::move(node));
		}

		void erase_agent_in_charge_of_activity(
			const std::string &agent,
			const std::string &activity)
		{
			if (!this->_agents.contains(agent))
			{
				throw std::runtime_error(std::format("Agent \"{}\" does not exist.", agent));
			}

			auto node = this->_activities.extract(activity);

			if (node.empty())
			{
				throw std::runtime_error(std::format("Activity \"{}\" does not exist.", activity));
			}

			node.value().agents_in_charge.erase(agent);

			this->_activities.insert(std::move(node));
		}

		void insert_activity_dependency(
			const std::string &dependent,
			const std::string &dependency)
		{
			if (!this->_activities.contains(dependent))
			{
				throw std::runtime_error(std::format("Activity \"{}\" does not exist.", dependent));
			}

			if (!this->_activities.contains(dependency))
			{
				throw std::runtime_error(std::format("Activity \"{}\" does not exist.", dependency));
			}

			this->_activity_dependencies.insert(dependent, dependency);
		}

		void erase_activity_dependency(
			const std::string &dependent,
			const std::string &dependency)
		{
			if (!this->_activities.contains(dependent))
			{
				throw std::runtime_error(std::format("Activity \"{}\" does not exist.", dependent));
			}

			if (!this->_activities.contains(dependency))
			{
				throw std::runtime_error(std::format("Activity \"{}\" does not exist.", dependency));
			}

			this->_activity_dependencies.erase(dependent, dependency);
		}

		void insert_or_edit_component(
			const std::string &component,
			const std::string &name)
		{
			auto node = this->_components.extract(component);

			if (node.empty())
			{
				this->_components.emplace(component, name);
				this->_component_interactions.insert(component);
			}

			else
			{
				node.value().name = name;

				this->_components.insert(std::move(node));
			}
		}

		void erase_component(const std::string &component)
		{
			if (const auto iterator = this->_components.find(component); 
				iterator != this->_components.end())
			{
				this->_components.erase(iterator);
			}

			else
			{
				throw std::runtime_error(std::format("Component \"{}\" does not exist.", component));
			}

			this->_component_interactions.erase(component);

			for (auto &[_, ratedComponents] : this->_affiliations)
			{
				ratedComponents.erase(component);
			}
		}

		void insert_component_group(const std::string &component, const std::string &group)
		{
			auto node = this->_components.extract(component);

			if (node.empty())
			{
				throw std::runtime_error(std::format("Component \"{}\" does not exist.", component));
			}

			node.value().groups.insert(group);

			this->_components.insert(std::move(node));
		}

		void erase_component_group(const std::string &component, const std::string &group)
		{
			auto node = this->_components.extract(component);

			if (node.empty())
			{
				throw std::runtime_error(std::format("Component \"{}\" does not exist.", component));
			}

			node.value().groups.erase(group);

			this->_components.insert(std::move(node));
		}

		void insert_component_interface(
			const std::string &component1,
			const std::string &component2)
		{
			if (!this->_components.contains(component1))
			{
				throw std::runtime_error(std::format("Component \"{}\" does not exist.", component1));
			}

			if (!this->_components.contains(component2))
			{
				throw std::runtime_error(std::format("Component \"{}\" does not exist.", component2));
			}

			this->_component_interactions.insert(component1, component2);
		}

		void erase_component_interface(
			const std::string &component1,
			const std::string &component2)
		{
			if (!this->_components.contains(component1))
			{
				throw std::runtime_error(std::format("Component \"{}\" does not exist.", component1));
			}

			if (!this->_components.contains(component2))
			{
				throw std::runtime_error(std::format("Component \"{}\" does not exist.", component2));
			}

			this->_component_interactions.erase(component1, component2);
		}

		void insert_or_assign_affiliation(
			const std::string &activity,
			const std::string &component,
			const float degree)
		{
			if (!this->_activities.contains(activity))
			{
				throw std::runtime_error(std::format("Activity \"{}\" does not exist.", activity));
			}

			if (!this->_components.contains(component))
			{
				throw std::runtime_error(std::format("Component \"{}\" does not exist.", component));
			}

			auto &components =
				this->_affiliations.emplace(
					activity,
					std::map < std::string, float > {}).first->second;

			components.insert_or_assign(component, degree);
		}

		void erase_affiliation(
			const std::string &activity,
			const std::string &component)
		{
			if (!this->_activities.contains(activity))
			{
				throw std::runtime_error(std::format("Activity \"{}\" does not exist.", activity));
			}

			if (!this->_components.contains(component))
			{
				throw std::runtime_error(std::format("Component \"{}\" does not exist.", component));
			}

			this->_affiliations.at(activity).erase(component);
		}

		void clear() noexcept
		{
			this->_agents.clear();
			this->_activities.clear();
			this->_activity_dependencies.clear();
			this->_components.clear();
			this->_component_interactions.clear();
			this->_affiliations.clear();
			this->_blueprint.clear();

			this->_up_to_date = false;

			this->_components_interfaces_matrix.clear();
			this->_activities_dependencies_matrix.clear();
			this->_affiliations_matrices[0].clear();
			this->_affiliations_matrices[1].clear();
			this->_potential_matrices[0].clear();
			this->_potential_matrices[1].clear();
			this->_strong_potential_matrix_without_redundancies.clear();
			this->_comparative_matrix_without_redundancies_step_1.clear();
			this->_comparative_matrix_without_redundancies_step_2.clear();
			this->_comparative_matrix_with_redundancies_step_1.clear();
			this->_comparative_matrix_with_redundancies_step_2.clear();
		}

		[[nodiscard]] std::vector < std::set < std::string > > identify_parallelizations() const
		{
			if (this->_activity_dependencies.empty())
			{
				return std::vector < std::set < std::string > > ();
			}

			return processor::identify_parallelizations(this->_activity_dependencies.transpose());
		}

		[[nodiscard]] std::map < std::string, size_t > identify_priorities() const
		{
			if (this->_activity_dependencies.empty())
			{
				return std::map < std::string, size_t > ();
			}

			const auto activitiesStraightSense =
				processor::identify_parallelizations(this->_activity_dependencies.transpose());

			auto activitiesReversedSense =
				processor::identify_parallelizations(this->_activity_dependencies);

			std::reverse(activitiesReversedSense.begin(), activitiesReversedSense.end());

			std::map < std::string, size_t > priorities;

			for (size_t i = 0; i < activitiesStraightSense.size(); i++)
			{
				for (const auto &straightActivity : activitiesStraightSense[i])
				{
					priorities.insert(std::make_pair(straightActivity, i));
				}

				for (const auto &reversedActivity : activitiesReversedSense[i])
				{
					priorities.at(reversedActivity) = i - priorities.at(reversedActivity);
				}
			}

			return priorities;
		}

		[[nodiscard]] auto components_without_agents_in_charge() const
		{
			std::vector < std::string > componentsWithoutAgentsInCharge;

			for (const auto &component : this->_components)
			{
				if (component.agents_in_charge.empty())
				{
					componentsWithoutAgentsInCharge.push_back(component.identification);
				}
			}

			return componentsWithoutAgentsInCharge;
		}

		[[nodiscard]] auto activities_without_agents_in_charge() const
		{
			std::vector < std::string > activitiesWithoutAgentsInCharge;

			for (const auto &activity : this->_activities)
			{
				if (activity.agents_in_charge.empty())
				{
					activitiesWithoutAgentsInCharge.push_back(activity.identification);
				}
			}

			return activitiesWithoutAgentsInCharge;
		}

		void minimum_relation_degree_for_agents_in_charge_of_components(const float degree)
		{
			for (auto iterator = this->_components.begin(); iterator != this->_components.end(); ++iterator)
			{
				auto node = this->_components.extract(iterator);

				auto &component = node.value();

				component.agents_in_charge.clear();

				for (const auto &[activity, componentsOnAffiliations] : this->_affiliations)
				{
					if (componentsOnAffiliations.contains(component.identification) &&
						componentsOnAffiliations.at(component.identification) >= degree)
					{
						const auto &agentsInChargeOfActivity =
							this->_activities.find(activity)->agents_in_charge;

						component.agents_in_charge.insert(
							agentsInChargeOfActivity.cbegin(),
							agentsInChargeOfActivity.cend());
					}
				}

				iterator = this->_components.insert(std::move(node)).position;
			}
		}

		[[nodiscard]] std::string agent_role(const std::string &agent) const
		{
			if (const auto iterator = this->_agents.find(agent);
				iterator != this->_agents.cend())
			{
				return iterator->role;
			}

			throw std::runtime_error(std::format("Agent \"{}\" does not exist.", agent));
		}

		[[nodiscard]] std::string activity_name(const std::string &activity) const
		{
			if (const auto iterator = this->_activities.find(activity);
				iterator != this->_activities.cend())
			{
				return iterator->name;
			}

			throw std::runtime_error(std::format("Activity \"{}\" does not exist.", activity));
		}

		[[nodiscard]] std::string component_name(const std::string &component) const
		{
			if (const auto iterator = this->_components.find(component);
				iterator != this->_components.cend())
			{
				return iterator->name;
			}

			throw std::runtime_error(std::format("Component \"{}\" does not exist.", component));
		}

		void compare_activities_and_organization()
		{
			std::map < size_t, std::string > activityIndexToKeyMap;

			this->align_architecture_process < comparison_mode::activity_and_organization > (activityIndexToKeyMap);
		}

		void compare_activities_and_organization(
			std::ostream &outputReportWithoutRedundancies,
			std::ostream &outputReportWithRedundancies)
		{
			std::map < size_t, std::string > activityIndexToKeyMap;

			this->align_architecture_process < comparison_mode::activity_and_organization > (activityIndexToKeyMap);

			writer::write_report(
				outputReportWithoutRedundancies,
				this->_comparative_matrix_without_redundancies_step_2,
				activityIndexToKeyMap,
				this->_indirectly_related_degree,
				this->_related_degree,
				this->_directly_related_degree);

			writer::write_report(
				outputReportWithRedundancies,
				this->_comparative_matrix_with_redundancies_step_2,
				activityIndexToKeyMap,
				this->_indirectly_related_degree,
				this->_related_degree,
				this->_directly_related_degree);
		}

		void compare_components_and_organization(
			const float minimumRelationDegreeForAgentsInChargeOfComponents)
		{
			std::map < size_t, std::string > componentIndexToKeyMap;

			this->minimum_relation_degree_for_agents_in_charge_of_components(
				minimumRelationDegreeForAgentsInChargeOfComponents);

			this->align_architecture_process < comparison_mode::component_and_organization > (componentIndexToKeyMap);
		}

		void compare_components_and_organization(
			const float minimumRelationDegreeForAgentsInChargeOfComponents,
			std::ostream &outputReportWithoutRedundancies,
			std::ostream &outputReportWithRedundancies)
		{
			std::map < size_t, std::string > componentIndexToKeyMap;

			this->minimum_relation_degree_for_agents_in_charge_of_components(
				minimumRelationDegreeForAgentsInChargeOfComponents);

			this->align_architecture_process < comparison_mode::component_and_organization > (componentIndexToKeyMap);

			writer::write_report(
				outputReportWithoutRedundancies,
				this->_comparative_matrix_without_redundancies_step_2,
				componentIndexToKeyMap,
				this->_indirectly_related_degree,
				this->_related_degree,
				this->_directly_related_degree);

			writer::write_report(
				outputReportWithRedundancies,
				this->_comparative_matrix_with_redundancies_step_2,
				componentIndexToKeyMap,
				this->_indirectly_related_degree,
				this->_related_degree,
				this->_directly_related_degree);
		}

		[[nodiscard]] const matrix_type &activities_dependencies_matrix() const
		{
			if (!this->_up_to_date)
			{
				throw std::runtime_error("\"processor\" is not up to date.");
			}

			return this->_activities_dependencies_matrix;
		}

		[[nodiscard]] const matrix_type &components_interfaces_matrix() const
		{
			if (!this->_up_to_date)
			{
				throw std::runtime_error("\"processor\" is not up to date.");
			}

			return this->_components_interfaces_matrix;
		}

		[[nodiscard]] const matrix_type &weak_affiliations_matrix() const
		{
			if (!this->_up_to_date)
			{
				throw std::runtime_error("\"processor\" is not up to date.");
			}

			return this->_affiliations_matrices[0];
		}

		[[nodiscard]] const matrix_type &strong_affiliations_matrix() const
		{
			if (!this->_up_to_date)
			{
				throw std::runtime_error("\"processor\" is not up to date.");
			}

			return this->_affiliations_matrices[1];
		}

		[[nodiscard]] const matrix_type &total_affiliations_matrix() const
		{
			if (!this->_up_to_date)
			{
				throw std::runtime_error("\"processor\" is not up to date.");
			}

			return this->_affiliations_matrices[2];
		}

		[[nodiscard]] const matrix_type &comparative_matrix_without_redundancies() const
		{
			if (!this->_up_to_date)
			{
				throw std::runtime_error("\"processor\" is not up to date.");
			}

			return this->_comparative_matrix_without_redundancies_step_2;
		}

		[[nodiscard]] const matrix_type &comparative_matrix_with_redundancies() const
		{
			if (!this->_up_to_date)
			{
				throw std::runtime_error("\"processor\" is not up to date.");
			}

			return this->_comparative_matrix_with_redundancies_step_2;
		}

		[[nodiscard]] const auto &blueprint_elements() const
		{
			return this->_blueprint.elements();
		}

		[[nodiscard]] const auto &blueprint_element_instances() const
		{
			return this->_blueprint.element_instances();
		}

		void insert_blueprint_element(
			const std::string &identification,
			const std::array < unsigned char, 3 > &RGB,
			const traversability state)
		{
			this->_blueprint.insert_element(identification, RGB, RGB, state);
		}

		void insert_blueprint_element(
			const std::string &identification,
			const std::array < unsigned char, 3 > &minDomainRGB,
			const std::array < unsigned char, 3 > &maxDomainRGB,
			const traversability state)
		{
			this->_blueprint.insert_element(identification, minDomainRGB, maxDomainRGB, state);
		}

		void rename_blueprint_element_instance(
			const std::string &oldIdentification,
			const std::string &newIdentification)
		{
			this->_blueprint.rename_element_instance(oldIdentification, newIdentification);
		}

		void rename_blueprint_element_instance_hash(
			const bool absolute,
			const size_t hash,
			const std::string &newIdentification)
		{
			this->_blueprint.rename_element_instance_hash(absolute, hash, newIdentification);
		}

		std::pair < size_t, size_t > blueprint_element_instance_hash(const std::string &identification) const
		{
			return this->_blueprint.element_instance_hash(identification);
		}

		void blueprint_element_traversability(const std::string &identification, const traversability state)
		{
			this->_blueprint.element_traversability(identification, state);
		}

		void blueprint_element_instance_traversability(const std::string &identification, const traversability state)
		{
			this->_blueprint.element_instance_traversability(identification, state);
		}

		void erase_blueprint_element(const std::string &identification)
		{
			this->_blueprint.erase_element(identification);
		}

		void read_blueprint_and_detect_instances(const std::string &path, const float referenceInMeters)
		{
			this->_blueprint.read_image_and_detect_instances(path, referenceInMeters);
		}

		void detect_blueprint_instances()
		{
			this->_blueprint.detect_instances();
		}

		[[nodiscard]] auto blueprint_element_instance_neighborhood() const
		{
			return this->_blueprint.element_instance_neighborhood();
		}

		[[nodiscard]] auto trace_path_on_blueprint(const std::string &activity) const
		{
			const auto iterator = this->_activities.find(activity);

			if (iterator == this->_activities.cend())
			{
				throw std::runtime_error(std::format("Activity \"{}\" does not exist.", activity));
			}

			return this->_blueprint.trace_path(iterator->tasks);
		}

		[[nodiscard]] auto trace_path_on_blueprint_and_update_affiliations(const std::string &activity)
		{
			const auto iterator1 = this->_activities.find(activity);

			if (iterator1 == this->_activities.cend())
			{
				throw std::runtime_error(std::format("Activity \"{}\" does not exist.", activity));
			}

			auto result = this->_blueprint.trace_path(iterator1->tasks);

			for (const auto &task : std::get < 0 > (result))
			{
				const auto &_task = iterator1->tasks.container().find(activity::task(task))->first.value;

				if (_task.degree == float{})
				{
					continue;
				}

				if (const auto iterator2 = this->_components.find(task);
					iterator2 != this->_components.end())
				{
					this->insert_or_assign_affiliation(activity, iterator2->identification, _task.degree);
				}
			}

			return result;
		}

		[[nodiscard]] auto absolute_coordinates_from_element_instance_coordinates_on_blueprint(
			const std::string &identification,
			const int cameraDistanceLevel,
			const size_t x,
			const size_t y) const
		{
			return this->_blueprint.absolute_coordinates_from_element_instance_coordinates(identification, cameraDistanceLevel, x, y);
		}

		[[nodiscard]] std::string element_instance_from_absolute_coordinates_on_blueprint(
			const size_t x,
			const size_t y) const
		{
			return this->_blueprint.element_instance_from_absolute_coordinates(x, y);
		}

		[[nodiscard]] std::vector < std::string > element_instance_identifications() const
		{
			std::vector < std::string > identifications;

			for (const auto &elementInstance : this->_blueprint.element_instances())
			{
				identifications.push_back(elementInstance.identification);
			}

			return identifications;
		}

		void write_blueprint(const std::string &path) const
		{
			this->_blueprint.write_image(path);
		}

		void write_blueprint_contours(const std::string &path) const
		{
			this->_blueprint.write_contours(path);
		}

		void write_blueprint_element_instance(
			const std::string &directory,
			const std::string &identification,
			const int cameraDistanceLevel) const
		{
			this->_blueprint.write_element_instance(directory, identification, cameraDistanceLevel);
		}

		void write_blueprint_element_instances(
			const std::string &directory,
			const int cameraDistanceLevel,
			const std::vector < std::string > &inclusion = { "floor" }) const
		{
			this->_blueprint.write_element_instances(directory, cameraDistanceLevel, inclusion);
		}

		[[nodiscard]]
			std::pair <
				std::array < unsigned char, 3 >,
				std::array < unsigned char, 3 > > blueprint_element_domain(const std::string &identification) const
		{
			return this->_blueprint.domain(identification);
		}

		[[nodiscard]] traversability blueprint_element_traversability(const std::string &identification) const
		{
			return this->_blueprint.element_traversability(identification);
		}

		[[nodiscard]] traversability blueprint_element_instance_traversability(const std::string &identification) const
		{
			return this->_blueprint.element_instance_traversability(identification);
		}

		[[nodiscard]] float meters_per_pixel_on_blueprint() const
		{
			return this->_blueprint.meters_per_pixel();
		}

		void read_inputs(
			std::istream &agentsInput,
			std::istream &activitiesInput,
			std::istream &componentsInput,
			std::istream &affiliationsInput,
			std::ostream &errorOutput = std::cerr,
			const std::locale &locale = std::locale(""))
		{
			this->_up_to_date = false;

			reader::read_agents(agentsInput, this->_agents, errorOutput, locale);
			reader::read_activities(activitiesInput, this->_activities, this->_activity_dependencies, this->_agents, errorOutput, locale);
			reader::read_components < ComponentsInterfacesAreReciprocal > (componentsInput, this->_components, this->_component_interactions, errorOutput, locale);
			reader::read_affiliations(affiliationsInput, this->_affiliations, this->_activities, this->_components, errorOutput, locale);
		}

		void write_agents(std::ostream &output, const char separator, const char lister) const
		{
			writer::write_agents(output, this->_agents, separator, lister);
		}

		void write_activities(
			std::ostream &output,
			const char separator,
			const char lister) const
		{
			writer::write_activities(output, this->_activities, this->_activity_dependencies, this->_agents, separator, lister);
		}

		void write_components(
			std::ostream &output,
			const char separator,
			const char lister) const
		{
			writer::write_components < ComponentsInterfacesAreReciprocal > (
				output,
				this->_components,
				this->_component_interactions,
				separator,
				lister);
		}

		void write_affiliations(
			std::ostream &output,
			const char separator,
			const char lister) const
		{
			writer::write_affiliations(
				output,
				this->_activities,
				this->_affiliations,
				this->_components,
				separator,
				lister);
		}

		void write_weak_affiliations_matrix(
			std::ostream &output,
			const char separator,
			const char lister) const
		{
			if (!this->_up_to_date)
			{
				throw std::runtime_error("\"processor\" is not updated.");
			}

			std::vector < std::string > rowLabels{};
			std::vector < std::string > columnLabels{};

			rowLabels.reserve(this->_activities.size());
			columnLabels.reserve(this->_components.size());

			for (const auto &activity : this->_activities)
			{
				rowLabels.push_back(activity.identification + lister + activity.name);
			}

			for (const auto &component : this->_components)
			{
				columnLabels.push_back(component.identification + lister + component.name);
			}

			const auto optionalRowLabels = std::make_optional(std::move(rowLabels));
			const auto optionalColumnLabels = std::make_optional(std::move(columnLabels));

			writer::write_matrix(output, this->_affiliations_matrices[0], separator, lister, optionalRowLabels, optionalColumnLabels);
		}

		void write_strong_affiliations_matrix(
			std::ostream &output,
			const char separator,
			const char lister) const
		{
			if (!this->_up_to_date)
			{
				throw std::runtime_error("\"processor\" is not updated.");
			}

			std::vector < std::string > rowLabels{};
			std::vector < std::string > columnLabels{};

			rowLabels.reserve(this->_activities.size());
			columnLabels.reserve(this->_components.size());

			for (const auto &activity : this->_activities)
			{
				rowLabels.push_back(activity.identification + lister + activity.name);
			}

			for (const auto &component : this->_components)
			{
				columnLabels.push_back(component.identification + lister + component.name);
			}

			const auto optionalRowLabels = std::make_optional(std::move(rowLabels));
			const auto optionalColumnLabels = std::make_optional(std::move(columnLabels));

			writer::write_matrix(output, this->_affiliations_matrices[1], separator, lister, optionalRowLabels, optionalColumnLabels);
		}

		void write_total_affiliations_matrix(
			std::ostream &output,
			const char separator,
			const char lister) const
		{
			if (!this->_up_to_date)
			{
				throw std::runtime_error("\"processor\" is not updated.");
			}

			std::vector < std::string > rowLabels{};
			std::vector < std::string > columnLabels{};

			rowLabels.reserve(this->_activities.size());
			columnLabels.reserve(this->_components.size());

			for (const auto &activity : this->_activities)
			{
				rowLabels.push_back(activity.identification + lister + activity.name);
			}

			for (const auto &component : this->_components)
			{
				columnLabels.push_back(component.identification + lister + component.name);
			}

			const auto optionalRowLabels = std::make_optional(std::move(rowLabels));
			const auto optionalColumnLabels = std::make_optional(std::move(columnLabels));

			writer::write_matrix(output, this->_affiliations_matrices[2], separator, lister, optionalRowLabels, optionalColumnLabels);
		}

		void write_total_potential_matrix(
			std::ostream &output,
			const char separator,
			const char lister) const
		{
			if (!this->_up_to_date)
			{
				throw std::runtime_error("\"processor\" is not updated.");
			}

			std::vector < std::string > labels{};
			std::optional < std::vector < std::string > > optionalLabels{};

			if (this->_last_comparison_mode == comparison_mode::component_and_organization)
			{
				labels.reserve(this->_components.size());

				for (const auto &component : this->_components)
				{
					labels.push_back(component.identification + lister + component.name);
				}

				optionalLabels = std::make_optional(std::move(labels));
			}

			else
			{
				labels.reserve(this->_activities.size());

				for (const auto &activity : this->_activities)
				{
					labels.push_back(activity.identification + lister + activity.name);
				}

				optionalLabels = std::make_optional(std::move(labels));
			}

			writer::write_matrix(output, this->_potential_matrices[0], separator, lister, optionalLabels, optionalLabels);
		}

		void write_strong_potential_matrix_without_redundancies(
			std::ostream &output,
			const char separator,
			const char lister) const
		{
			if (!this->_up_to_date)
			{
				throw std::runtime_error("\"processor\" is not updated.");
			}

			std::vector < std::string > labels{};
			std::optional < std::vector < std::string > > optionalLabels{};

			if (this->_last_comparison_mode == comparison_mode::component_and_organization)
			{
				labels.reserve(this->_components.size());

				for (const auto &component : this->_components)
				{
					labels.push_back(component.identification + lister + component.name);
				}

				optionalLabels = std::make_optional(std::move(labels));
			}

			else
			{
				labels.reserve(this->_activities.size());

				for (const auto &activity : this->_activities)
				{
					labels.push_back(activity.identification + lister + activity.name);
				}

				optionalLabels = std::make_optional(std::move(labels));
			}

			writer::write_matrix(output, this->_strong_potential_matrix_without_redundancies, separator, lister, optionalLabels, optionalLabels);
		}

		void write_strong_potential_matrix_with_redundancies(
			std::ostream &output,
			const char separator,
			const char lister) const
		{
			if (!this->_up_to_date)
			{
				throw std::runtime_error("\"processor\" is not updated.");
			}

			std::vector < std::string > labels{};
			std::optional < std::vector < std::string > > optionalLabels{};

			if (this->_last_comparison_mode == comparison_mode::component_and_organization)
			{
				labels.reserve(this->_components.size());

				for (const auto &component : this->_components)
				{
					labels.push_back(component.identification + lister + component.name);
				}

				optionalLabels = std::make_optional(std::move(labels));
			}

			else
			{
				labels.reserve(this->_activities.size());

				for (const auto &activity : this->_activities)
				{
					labels.push_back(activity.identification + lister + activity.name);
				}

				optionalLabels = std::make_optional(std::move(labels));
			}

			writer::write_matrix(output, this->_potential_matrices[1], separator, lister, optionalLabels, optionalLabels);
		}

		void write_comparative_matrix_without_redundancies(
			std::ostream &output,
			const char separator,
			const char lister) const
		{
			if (!this->_up_to_date)
			{
				throw std::runtime_error("\"processor\" is not updated.");
			}

			std::vector < std::string > labels{};
			std::optional < std::vector < std::string > > optionalLabels{};

			if (this->_last_comparison_mode == comparison_mode::component_and_organization)
			{
				labels.reserve(this->_components.size());

				for (const auto &component : this->_components)
				{
					labels.push_back(component.identification + lister + component.name);
				}

				optionalLabels = std::make_optional(std::move(labels));
			}

			else
			{
				labels.reserve(this->_activities.size());

				for (const auto &activity : this->_activities)
				{
					labels.push_back(activity.identification + lister + activity.name);
				}

				optionalLabels = std::make_optional(std::move(labels));
			}

			writer::write_matrix(output, this->_comparative_matrix_without_redundancies_step_2, separator, lister, optionalLabels, optionalLabels);
		}

		void write_comparative_matrix_with_redundancies(
			std::ostream &output,
			const char separator,
			const char lister) const
		{
			if (!this->_up_to_date)
			{
				throw std::runtime_error("\"processor\" is not updated.");
			}

			std::vector < std::string > labels{};
			std::optional < std::vector < std::string > > optionalLabels{};

			if (this->_last_comparison_mode == comparison_mode::component_and_organization)
			{
				labels.reserve(this->_components.size());

				for (const auto &component : this->_components)
				{
					labels.push_back(component.identification + lister + component.name);
				}

				optionalLabels = std::make_optional(std::move(labels));
			}

			else
			{
				labels.reserve(this->_activities.size());

				for (const auto &activity : this->_activities)
				{
					labels.push_back(activity.identification + lister + activity.name);
				}

				optionalLabels = std::make_optional(std::move(labels));
			}

			writer::write_matrix(output, this->_comparative_matrix_with_redundancies_step_2, separator, lister, optionalLabels, optionalLabels);
		}

		void write_element_instances(
			const std::string &directory,
			const char separator,
			const char lister) const
		{
			using TableType =
				xablau::algebra::tensor_dense_dynamic <
					std::string,
					xablau::algebra::tensor_rank < 2 >,
					xablau::algebra::tensor_contiguity < false > >;

			constexpr auto pointCount =
				[] (const element_instance &elementInstance) -> size_t
				{
					size_t counter = elementInstance.contour.size();

					for (const auto &island : elementInstance.islands)
					{
						counter += island.size();
					}

					return counter;
				};

			if (!this->_blueprint.up_to_date())
			{
				throw std::runtime_error("\"blueprint\" is not updated.");
			}

			if (!std::filesystem::exists(directory) && !std::filesystem::create_directory(directory))
			{
				throw std::runtime_error(std::format("Directory \"{}\" does not exist and could not be created.", directory));
			}

			const auto metadataDirectory = directory + "/metadata/";

			if (!std::filesystem::exists(metadataDirectory) && !std::filesystem::create_directory(metadataDirectory))
			{
				throw std::runtime_error(std::format("Directory \"{}\" does not exist and could not be created.", metadataDirectory));
			}

			std::vector < std::string > labelsMetadata{};

			labelsMetadata.push_back("element_instance_identification");
			labelsMetadata.push_back("element_identification");
			labelsMetadata.push_back("traversability");

			std::vector < std::string > labelsPolygon{};

			labelsPolygon.push_back("polygon_id");
			labelsPolygon.push_back("x");
			labelsPolygon.push_back("y");

			size_t indexInstance{};
			TableType metadata(this->_blueprint.element_instances().size(), 3);

			for (const auto &elementInstance : this->_blueprint.element_instances())
			{
				metadata(indexInstance, 0) = elementInstance.identification;
				metadata(indexInstance, 1) = elementInstance.element.identification;
				metadata(indexInstance, 2) = std::to_string(static_cast < int > (elementInstance.traversability));

				TableType polygons(pointCount(elementInstance), 3);

				size_t indexPoint = 0;

				for (const auto &point : elementInstance.contour)
				{
					polygons(indexPoint, 0) = std::to_string(0);
					polygons(indexPoint, 1) = std::to_string(point.x);
					polygons(indexPoint, 2) = std::to_string(point.y);

					indexPoint++;
				}

				size_t indexPolygon = 1;

				for (const auto &island : elementInstance.islands)
				{
					for (const auto &point : island)
					{
						polygons(indexPoint, 0) = std::to_string(indexPolygon);
						polygons(indexPoint, 1) = std::to_string(point.x);
						polygons(indexPoint, 2) = std::to_string(point.y);

						indexPoint++;
					}

					indexPolygon++;
				}

				xablau::io::fstream < char > instanceOutput(
					directory + "/" + elementInstance.identification + ".csv",
					std::ios_base::out | std::ios_base::trunc);

				writer::write_matrix(
					instanceOutput,
					polygons,
					separator,
					lister,
					std::nullopt,
					std::make_optional(labelsPolygon));

				indexInstance++;
			}

			xablau::io::fstream < char > metadataOutput(
				metadataDirectory + "/metadata.csv",
				std::ios_base::out | std::ios_base::trunc);

			writer::write_matrix(
				metadataOutput,
				metadata,
				separator,
				lister,
				std::nullopt,
				std::make_optional(std::move(labelsMetadata)));
		}

		void write_element_instance_neighborhood(
			const std::string &directory,
			const char separator,
			const char lister) const
		{
			using TableType =
				xablau::algebra::tensor_dense_dynamic <
					std::string,
					xablau::algebra::tensor_rank < 2 >,
					xablau::algebra::tensor_contiguity < false > >;

			constexpr auto relationCount =
				[] (const blueprint::element_instance_neighborhood_type &neighborhood) -> size_t
				{
					size_t counter{};

					for (const auto &[_, setOfPoints] : neighborhood)
					{
						counter += setOfPoints.size();
					}

					return counter;
				};

			if (!std::filesystem::exists(directory) && !std::filesystem::create_directory(directory))
			{
				throw std::runtime_error(std::format("Directory \"{}\" does not exist and could not be created.", directory));
			}

			std::vector < std::string > labels{};

			labels.push_back("element_instance_1");
			labels.push_back("element_instance_2");
			labels.push_back("x");
			labels.push_back("y");

			size_t index = 0;
			const auto neighborhood = this->_blueprint.element_instance_neighborhood();
			TableType relations(relationCount(neighborhood), 4);

			for (const auto &[instancesIdentifications, setOfPoints] : neighborhood)
			{
				for (const auto &point : setOfPoints)
				{
					std::tie(relations(index, 0), relations(index, 1)) = instancesIdentifications;
					relations(index, 2) = std::to_string(point[0]);
					relations(index, 3) = std::to_string(point[1]);

					index++;
				}
			}

			xablau::io::fstream < char > output(
				directory + "/relations.csv",
				std::ios_base::out | std::ios_base::trunc);

			writer::write_matrix(
				output,
				relations,
				separator,
				lister,
				std::nullopt,
				std::make_optional(std::move(labels)));
		}
	};
}