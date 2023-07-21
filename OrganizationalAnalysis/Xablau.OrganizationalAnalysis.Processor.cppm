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

export namespace xablau::organizational_analysis
{
	template <
		bool ComponentsInterfacesAreReciprocal,
		typename CharType,
		typename Traits = std::char_traits < CharType > >
	class processor final
	{
	private:
		using string_type = std::basic_string < CharType, Traits >;

		using agents_type = organizational_analysis::agents < CharType, Traits >;
		using activities_type = organizational_analysis::activities < CharType, Traits >;
		using components_type = organizational_analysis::components < ComponentsInterfacesAreReciprocal, CharType, Traits >;
		using affiliations_type = organizational_analysis::affiliations < CharType, Traits >;
		using node_type = xablau::graph::node < string_type >;

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

		[[nodiscard]] matrix_type create_activities_matrix(
			const std::map < string_type, size_t > &activityKeyToIndexMap) const
		{
			matrix_type activitiesMatrix(
				this->_activities.descriptions.size(),
				this->_activities.descriptions.size());

			for (const auto &[identification1, description1] : this->_activities.descriptions)
			{
				const auto edges = this->_activities.dependencies.edges(identification1);

				if (!edges.has_value())
				{
					if constexpr (std::same_as < CharType, char >)
					{
						throw std::runtime_error("Could not find node " + identification1 + ".");
					}

					else
					{
						throw std::runtime_error(L"Could not find a node.");
					}
				}

				for (const auto &[identification2, description2] : this->_activities.descriptions)
				{
					if (this->_activities.dependencies.contains(identification1, identification2))
					{
						activitiesMatrix(
							activityKeyToIndexMap.at(identification1),
							activityKeyToIndexMap.at(identification2)) =
								edges.value().get().at(identification2).weight();
					}
				}
			}

			return activitiesMatrix;
		}

		[[nodiscard]] matrix_type create_components_matrix(
			const std::map < string_type, size_t > &componentKeyToIndexMap) const
		{
			matrix_type componentsMatrix(
				this->_components.descriptions.size(),
				this->_components.descriptions.size());

			for (const auto &[identification1, description1] : this->_components.descriptions)
			{
				for (const auto &[identification2, description2] : this->_components.descriptions)
				{
					if (this->_components.interactions.contains(identification1, identification2))
					{
						componentsMatrix(
							componentKeyToIndexMap.at(identification1),
							componentKeyToIndexMap.at(identification2)) = float{1};
					}
				}
			}

			return componentsMatrix;
		}

		[[nodiscard]] std::array < matrix_type, 2 > create_affiliations_matrices(
			const std::map < string_type, size_t > &activityKeyToIndexMap,
			const std::map < string_type, size_t > &componentKeyToIndexMap) const
		{
			std::array < matrix_type, 2 > affiliationsMatrices;

			affiliationsMatrices[0].resize(
				this->_activities.descriptions.size(),
				this->_components.descriptions.size(),
				float{});

			affiliationsMatrices[1].resize(
				this->_activities.descriptions.size(),
				this->_components.descriptions.size(),
				float{});

			for (const auto &[identification1, description1] : this->_activities.descriptions)
			{
				const auto iterator1 = this->_affiliations.responsabilities.find(identification1);

				if (iterator1 == this->_affiliations.responsabilities.cend())
				{
					if constexpr (std::same_as < CharType, char >)
					{
						throw std::runtime_error("Could not find the responsability of the activity " + identification1 + ".");
					}

					else
					{
						throw std::runtime_error("Could not find the responsability of an activity.");
					}
				}

				for (const auto &[identification2, description2] : this->_components.descriptions)
				{
					const auto iterator2 = iterator1->second.find(identification2);
				
					if (iterator2 != iterator1->second.cend())
					{
						if (iterator2->second >= float{1})
						{
							affiliationsMatrices[0](
								activityKeyToIndexMap.at(identification1),
								componentKeyToIndexMap.at(identification2)) = float{1};
						}

						if (iterator2->second >= float{3})
						{
							affiliationsMatrices[1](
								activityKeyToIndexMap.at(identification1),
								componentKeyToIndexMap.at(identification2)) = float{1};
						}
					}
				}
			}

			return affiliationsMatrices;
		}

		static void create_comparative_matrix_step_1(
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
						finalComparativeMatrixCell = organizational_analysis::indirectly_related;
					}
				}
			}
		}

		static void create_comparative_matrix_step_2(
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
							finalComparativeMatrixCell = organizational_analysis::related;
						}

						else
						{
							finalComparativeMatrixCell = organizational_analysis::directly_related;
						}
					}
				}
			}
		}

		template < typename DescriptionType >
		[[nodiscard]] matrix_type erase_redundancies(
			const matrix_type &strongPotentialMatrixWithRedundancies,
			const std::map < size_t, string_type > &baseIndexToKeyMap,
			const DescriptionType &baseDescription) const
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
						const auto &agentsInCharge1 = baseDescription.at(key1).agents_in_charge;
						const auto &agentsInCharge2 = baseDescription.at(key2).agents_in_charge;

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
		[[nodiscard]] static std::vector < std::set < string_type > > identify_parallelizations(
			const DigraphType &activitiesSequence)
		{
			using node_type = xablau::graph::node < string_type >;

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

			std::vector < std::set < string_type > > finalActivitiesSequence;

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
			std::map < size_t, string_type > &baseIndexToKeyMap)
		{
			size_t index{};
			std::map < string_type, size_t > activityKeyToIndexMap;
			std::map < string_type, size_t > componentKeyToIndexMap;

			if (this->_activities.descriptions.size() == 0)
			{
				throw std::runtime_error("There are no registered activities.");
			}

			if (this->_components.descriptions.size() == 0)
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

			for (const auto &[identification, description] : this->_activities.descriptions)
			{
				activityKeyToIndexMap.insert(std::make_pair(identification, index));

				if constexpr (ComparisonMode == comparison_mode::activity_and_organization)
				{
					baseIndexToKeyMap.insert(std::make_pair(index, identification));
				}

				index++;
			}

			index = 0;

			for (const auto &[identification, description] : this->_components.descriptions)
			{
				componentKeyToIndexMap.insert(std::make_pair(identification, index));

				if constexpr (ComparisonMode == comparison_mode::component_and_organization)
				{
					baseIndexToKeyMap.insert(std::make_pair(index, identification));
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
						this->_activities.descriptions);
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
						this->_components.descriptions);

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
		components_type _components{};
		affiliations_type _affiliations{};

		bool _up_to_date = false;
		comparison_mode _last_comparison_mode = comparison_mode::invalid;

		matrix_type _components_interfaces_matrix{};
		matrix_type _activities_dependencies_matrix{};
		std::array < matrix_type, 2 > _affiliations_matrices{};
		std::array < matrix_type, 2 > _potential_matrices{};
		matrix_type _strong_potential_matrix_without_redundancies{};
		matrix_type _comparative_matrix_without_redundancies_step_1{};
		matrix_type _comparative_matrix_without_redundancies_step_2{};
		matrix_type _comparative_matrix_with_redundancies_step_1{};
		matrix_type _comparative_matrix_with_redundancies_step_2{};

	public:
		void insert_or_assign_agent(
			const string_type &agent,
			const string_type &role)
		{
			this->_agents.descriptions.insert_or_assign(
				agent,
				typename agents_type::description{ std::set < string_type > {}, role });
		}

		void erase_agent(const string_type &agent)
		{
			const auto iterator = this->_agents.descriptions.find(agent);

			if (iterator == this->_agents.descriptions.end())
			{
				throw std::runtime_error(std::format("Agent \"{}\" does not exist.", agent));
			}

			this->_agents.descriptions.erase(iterator);

			for (auto &[_, activityDescription] : this->_activities.descriptions)
			{
				activityDescription.agents_in_charge.erase(agent);
			}

			for (auto &[_, componentDescription] : this->_components.descriptions)
			{
				componentDescription.agents_in_charge.erase(agent);
			}
		}

		void insert_agent_group(const string_type &agent, const string_type &group)
		{
			const auto iterator = this->_agents.descriptions.find(agent);

			if (iterator == this->_agents.descriptions.end())
			{
				throw std::runtime_error(std::format("Agent \"{}\" does not exist.", agent));
			}

			iterator->second.groups.insert(group);
		}

		void erase_agent_group(const string_type &agent, const string_type &group)
		{
			const auto iterator = this->_agents.descriptions.find(agent);

			if (iterator == this->_agents.descriptions.end())
			{
				throw std::runtime_error(std::format("Agent \"{}\" does not exist.", agent));
			}

			iterator->second.groups.erase(group);
		}

		void insert_or_edit_activity(
			const string_type &activity,
			const string_type &name)
		{
			const auto pair =
				this->_activities.descriptions.insert(
					std::make_pair(
						activity,
						typename activities_type::description{
							name,
							std::set < string_type > {},
							std::set < string_type > {} }));

			if (pair.second)
			{
				this->_activities.dependencies.insert(activity);
			}

			else
			{
				pair.first->second.name = name;
			}
		}

		void erase_activity(const string_type &activity)
		{
			const auto iterator = this->_activities.descriptions.find(activity);

			if (iterator == this->_activities.descriptions.end())
			{
				throw std::runtime_error(std::format("Activity \"{}\" does not exist.", activity));
			}

			this->_activities.descriptions.erase(iterator);
			this->_activities.dependencies.erase(activity);
			this->_affiliations.responsabilities.erase(activity);
		}

		void insert_activity_group(const string_type &activity, const string_type &group)
		{
			const auto iterator = this->_activities.descriptions.find(activity);

			if (iterator == this->_activities.descriptions.end())
			{
				throw std::runtime_error(std::format("Activity \"{}\" does not exist.", activity));
			}

			iterator->second.groups.insert(group);
		}

		void erase_activity_group(const string_type &activity, const string_type &group)
		{
			const auto iterator = this->_activities.descriptions.find(activity);

			if (iterator == this->_activities.descriptions.end())
			{
				throw std::runtime_error(std::format("Activity \"{}\" does not exist.", activity));
			}

			iterator->second.groups.erase(group);
		}

		void insert_agent_in_charge_of_activity(
			const string_type &agent,
			const string_type &activity)
		{
			if (!this->_agents.descriptions.contains(agent))
			{
				throw std::runtime_error(std::format("Agent \"{}\" does not exist.", agent));
			}

			const auto iterator = this->_activities.descriptions.find(activity);

			if (iterator == this->_activities.descriptions.end())
			{
				throw std::runtime_error(std::format("Activity \"{}\" does not exist.", activity));
			}

			iterator->second.agents_in_charge.insert(agent);
		}

		void erase_agent_in_charge_of_activity(
			const string_type &agent,
			const string_type &activity)
		{
			if (!this->_agents.descriptions.contains(agent))
			{
				throw std::runtime_error(std::format("Agent \"{}\" does not exist.", agent));
			}

			const auto iterator = this->_activities.descriptions.find(activity);

			if (iterator == this->_activities.descriptions.end())
			{
				throw std::runtime_error(std::format("Activity \"{}\" does not exist.", activity));
			}

			iterator->second.agents_in_charge.erase(agent);
		}

		void insert_activity_dependency(
			const string_type &dependent,
			const string_type &dependency)
		{
			if (!this->_activities.descriptions.contains(dependent))
			{
				throw std::runtime_error(std::format("Activity \"{}\" does not exist.", dependent));
			}

			if (!this->_activities.descriptions.contains(dependency))
			{
				throw std::runtime_error(std::format("Activity \"{}\" does not exist.", dependency));
			}

			this->_activities.dependencies.insert(dependent, dependency);
		}

		void erase_activity_dependency(
			const string_type &dependent,
			const string_type &dependency)
		{
			if (!this->_activities.descriptions.contains(dependent))
			{
				throw std::runtime_error(std::format("Activity \"{}\" does not exist.", dependent));
			}

			if (!this->_activities.descriptions.contains(dependency))
			{
				throw std::runtime_error(std::format("Activity \"{}\" does not exist.", dependency));
			}

			this->_activities.dependencies.erase(dependent, dependency);
		}

		void insert_or_edit_component(
			const string_type &component,
			const string_type &name)
		{
			const auto pair =
				this->_components.descriptions.insert(
					std::make_pair(
						component,
						typename components_type::description{
							name,
							std::set < string_type > {},
							std::set < string_type > {} }));

			if (pair.second)
			{
				this->_components.interactions.insert(component);
			}

			else
			{
				pair.first->second.name = name;
			}
		}

		void erase_component(const string_type &component)
		{
			const auto iterator = this->_components.descriptions.find(component);

			if (iterator == this->_components.descriptions.end())
			{
				throw std::runtime_error(std::format("Component \"{}\" does not exist.", component));
			}

			this->_components.descriptions.erase(iterator);
			this->_components.interactions.erase(component);

			for (auto &[_, ratedComponent] : this->_affiliations.responsabilities)
			{
				ratedComponent.erase(component);
			}
		}

		void insert_component_group(const string_type &component, const string_type &group)
		{
			const auto iterator = this->_components.descriptions.find(component);

			if (iterator == this->_components.descriptions.end())
			{
				throw std::runtime_error(std::format("Component \"{}\" does not exist.", component));
			}

			iterator->second.groups.insert(group);
		}

		void erase_component_group(const string_type &component, const string_type &group)
		{
			const auto iterator = this->_components.descriptions.find(component);

			if (iterator == this->_components.descriptions.end())
			{
				throw std::runtime_error(std::format("Component \"{}\" does not exist.", component));
			}

			iterator->second.groups.erase(group);
		}

		void insert_component_interface(
			const string_type &component1,
			const string_type &component2)
		{
			if (!this->_components.descriptions.contains(component1))
			{
				throw std::runtime_error(std::format("Component \"{}\" does not exist.", component1));
			}

			if (!this->_components.descriptions.contains(component2))
			{
				throw std::runtime_error(std::format("Component \"{}\" does not exist.", component2));
			}

			this->_components.interactions.insert(component1, component2);
		}

		void erase_component_interface(
			const string_type &component1,
			const string_type &component2)
		{
			if (!this->_components.descriptions.contains(component1))
			{
				throw std::runtime_error(std::format("Component \"{}\" does not exist.", component1));
			}

			if (!this->_components.descriptions.contains(component2))
			{
				throw std::runtime_error(std::format("Component \"{}\" does not exist.", component2));
			}

			this->_components.interactions.erase(component1, component2);
		}

		void insert_or_assign_affiliation(
			const string_type &activity,
			const string_type &component,
			const float rating)
		{
			if (!this->_activities.descriptions.contains(activity))
			{
				throw std::runtime_error(std::format("Activity \"{}\" does not exist.", activity));
			}

			if (!this->_components.descriptions.contains(component))
			{
				throw std::runtime_error(std::format("Component \"{}\" does not exist.", component));
			}

			const auto pair =
				this->_affiliations.responsabilities.insert(
					std::make_pair(
						activity,
						std::map < string_type, float > {} ));

			pair.first->second.insert_or_assign(component, rating);
		}

		void erase_affiliation(
			const string_type &activity,
			const string_type &component)
		{
			if (!this->_activities.descriptions.contains(activity))
			{
				throw std::runtime_error(std::format("Activity \"{}\" does not exist.", activity));
			}

			if (!this->_components.descriptions.contains(component))
			{
				throw std::runtime_error(std::format("Component \"{}\" does not exist.", component));
			}

			const auto iterator =
				this->_affiliations.responsabilities.insert(
					std::make_pair(
						activity,
						std::map < string_type, float > {} ));

			this->_affiliations.responsabilities.at(activity).erase(component);
		}

		void clear() noexcept
		{
			this->_agents.descriptions.clear();
			this->_activities.descriptions.clear();
			this->_activities.dependencies.clear();
			this->_components.descriptions.clear();
			this->_components.interactions.clear();
			this->_affiliations.responsabilities.clear();

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

		[[nodiscard]] std::vector < std::set < string_type > > identify_parallelizations() const
		{
			if (this->_activities.dependencies.empty())
			{
				return std::vector < std::set < string_type > > ();
			}

			return processor::identify_parallelizations(this->_activities.dependencies.transpose());
		}

		[[nodiscard]] std::map < string_type, size_t > identify_priorities() const
		{
			if (this->_activities.dependencies.empty())
			{
				return std::map < string_type, size_t > ();
			}

			const auto activitiesStraightSense =
				processor::identify_parallelizations(this->_activities.dependencies.transpose());

			auto activitiesReversedSense =
				processor::identify_parallelizations(this->_activities.dependencies);

			std::reverse(activitiesReversedSense.begin(), activitiesReversedSense.end());

			std::map < string_type, size_t > priorities;

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
			std::vector < string_type > componentsWithoutAgentsInCharge;

			for (auto &[component, description] : this->_components.descriptions)
			{
				if (description.agents_in_charge.empty())
				{
					componentsWithoutAgentsInCharge.push_back(component);
				}
			}

			return componentsWithoutAgentsInCharge;
		}

		[[nodiscard]] auto activities_without_agents_in_charge() const
		{
			std::vector < string_type > activitiesWithoutAgentsInCharge;

			for (const auto &[activity, description] : this->_activities.descriptions)
			{
				if (description.agents_in_charge.empty())
				{
					activitiesWithoutAgentsInCharge.push_back(activity);
				}
			}

			return activitiesWithoutAgentsInCharge;
		}

		void minimum_relation_degree_for_agents_in_charge_of_components(const float degree)
		{
			for (auto &[component, description] : this->_components.descriptions)
			{
				description.agents_in_charge.clear();

				for (const auto &[activity, componentsOnAffiliations] : this->_affiliations.responsabilities)
				{
					if (componentsOnAffiliations.contains(component) &&
						componentsOnAffiliations.at(component) >= degree)
					{
						const auto &agentsInChargeOfActivity =
							this->_activities.descriptions.at(activity).agents_in_charge;

						description.agents_in_charge.insert(
							agentsInChargeOfActivity.cbegin(),
							agentsInChargeOfActivity.cend());
					}
				}
			}
		}

		[[nodiscard]] string_type agent_role(const string_type &agent) const
		{
			return this->_agents.descriptions.at(agent).role;
		}

		[[nodiscard]] string_type activity_name(const string_type &activity) const
		{
			return this->_activities.descriptions.at(activity).name;
		}

		[[nodiscard]] string_type component_name(const string_type &component) const
		{
			return this->_components.descriptions.at(component).name;
		}

		void compare_activities_and_organization()
		{
			std::map < size_t, string_type > activityIndexToKeyMap;

			this->align_architecture_process < comparison_mode::activity_and_organization > (activityIndexToKeyMap);
		}

		void compare_activities_and_organization(
			std::basic_ostream < CharType, Traits > &outputReportWithoutRedundancies,
			std::basic_ostream < CharType, Traits > &outputReportWithRedundancies)
		{
			std::map < size_t, string_type > activityIndexToKeyMap;

			this->align_architecture_process < comparison_mode::activity_and_organization > (activityIndexToKeyMap);

			writer::write_report(
				outputReportWithoutRedundancies,
				this->_comparative_matrix_without_redundancies_step_2,
				activityIndexToKeyMap);

			writer::write_report(
				outputReportWithRedundancies,
				this->_comparative_matrix_with_redundancies_step_2,
				activityIndexToKeyMap);
		}

		void compare_components_and_organization(
			const float minimumRelationDegreeForAgentsInChargeOfComponents)
		{
			std::map < size_t, string_type > componentIndexToKeyMap;

			this->minimum_relation_degree_for_agents_in_charge_of_components(
				minimumRelationDegreeForAgentsInChargeOfComponents);

			this->align_architecture_process < comparison_mode::component_and_organization > (componentIndexToKeyMap);
		}

		void compare_components_and_organization(
			const float minimumRelationDegreeForAgentsInChargeOfComponents,
			std::basic_ostream < CharType, Traits > &outputReportWithoutRedundancies,
			std::basic_ostream < CharType, Traits > &outputReportWithRedundancies)
		{
			std::map < size_t, string_type > componentIndexToKeyMap;

			this->minimum_relation_degree_for_agents_in_charge_of_components(
				minimumRelationDegreeForAgentsInChargeOfComponents);

			this->align_architecture_process < comparison_mode::component_and_organization > (componentIndexToKeyMap);

			writer::write_report(
				outputReportWithoutRedundancies,
				this->_comparative_matrix_without_redundancies_step_2,
				componentIndexToKeyMap);

			writer::write_report(
				outputReportWithRedundancies,
				this->_comparative_matrix_with_redundancies_step_2,
				componentIndexToKeyMap);
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

		void read(
			std::basic_istream < CharType, Traits > &agentsInput,
			std::basic_istream < CharType, Traits > &activitiesInput,
			std::basic_istream < CharType, Traits > &componentsInput,
			std::basic_istream < CharType, Traits > &affiliationsInput,
			std::basic_ostream < CharType, Traits > &errorOutput = internals::default_error_output < CharType > (),
			const std::locale &locale = std::locale(""))
		{
			this->_up_to_date = false;

			reader::read_agents(agentsInput, this->_agents, errorOutput, locale);
			reader::read_activities(activitiesInput, this->_activities, this->_agents, errorOutput, locale);
			reader::read_components(componentsInput, this->_components, errorOutput, locale);
			reader::read_affiliations(affiliationsInput, this->_affiliations, this->_activities, this->_components, errorOutput, locale);
		}

		void write_agents(
			std::basic_ostream < CharType, Traits > &output,
			const CharType separator,
			const CharType lister) const
		{
			writer::write_agents(output, this->_agents, separator, lister);
		}

		void write_activities(
			std::basic_ostream < CharType, Traits > &output,
			const CharType separator,
			const CharType lister) const
		{
			writer::write_activities(output, this->_activities, this->_agents, separator, lister);
		}

		void write_components(
			std::basic_ostream < CharType, Traits > &output,
			const CharType separator,
			const CharType lister) const
		{
			writer::write_components(output, this->_components, separator, lister);
		}

		void write_affiliations(
			std::basic_ostream < CharType, Traits > &output,
			const CharType separator,
			const CharType lister) const
		{
			writer::write_affiliations(output, this->_activities, this->_affiliations, this->_components, separator, lister);
		}

		void write_weak_affiliations_matrix(
			std::basic_ostream < CharType, Traits > &output,
			const CharType separator,
			const CharType lister) const
		{
			if (!this->_up_to_date)
			{
				throw std::runtime_error("\"processor\" is not updated.");
			}

			std::vector < string_type > rowLabels{};
			std::vector < string_type > columnLabels{};

			rowLabels.reserve(this->_activities.descriptions.size());
			columnLabels.reserve(this->_components.descriptions.size());

			for (const auto &activity : this->_activities.descriptions)
			{
				rowLabels.push_back(activity.first + lister + activity.second.name);
			}

			for (const auto &component : this->_components.descriptions)
			{
				columnLabels.push_back(component.first + lister + component.second.name);
			}

			const auto optionalRowLabels = std::make_optional(std::move(rowLabels));
			const auto optionalColumnLabels = std::make_optional(std::move(columnLabels));

			writer::write_matrix(output, this->_affiliations_matrices[0], separator, lister, optionalRowLabels, optionalColumnLabels);
		}

		void write_strong_affiliations_matrix(
			std::basic_ostream < CharType, Traits > &output,
			const CharType separator,
			const CharType lister) const
		{
			if (!this->_up_to_date)
			{
				throw std::runtime_error("\"processor\" is not updated.");
			}

			std::vector < string_type > rowLabels{};
			std::vector < string_type > columnLabels{};

			rowLabels.reserve(this->_activities.descriptions.size());
			columnLabels.reserve(this->_components.descriptions.size());

			for (const auto &activity : this->_activities.descriptions)
			{
				rowLabels.push_back(activity.first + lister + activity.second.name);
			}

			for (const auto &component : this->_components.descriptions)
			{
				columnLabels.push_back(component.first + lister + component.second.name);
			}

			const auto optionalRowLabels = std::make_optional(std::move(rowLabels));
			const auto optionalColumnLabels = std::make_optional(std::move(columnLabels));

			writer::write_matrix(output, this->_affiliations_matrices[1], separator, lister, optionalRowLabels, optionalColumnLabels);
		}

		void write_total_potential_matrix(
			std::basic_ostream < CharType, Traits > &output,
			const CharType separator,
			const CharType lister) const
		{
			if (!this->_up_to_date)
			{
				throw std::runtime_error("\"processor\" is not updated.");
			}

			std::vector < string_type > labels{};
			std::optional < std::vector < string_type > > optionalLabels{};

			if (this->_last_comparison_mode == comparison_mode::component_and_organization)
			{
				labels.reserve(this->_components.descriptions.size());

				for (const auto &component : this->_components.descriptions)
				{
					labels.push_back(component.first + lister + component.second.name);
				}

				optionalLabels = std::make_optional(std::move(labels));
			}

			else
			{
				labels.reserve(this->_activities.descriptions.size());

				for (const auto &activity : this->_activities.descriptions)
				{
					labels.push_back(activity.first + lister + activity.second.name);
				}

				optionalLabels = std::make_optional(std::move(labels));
			}

			writer::write_matrix(output, this->_potential_matrices[0], separator, lister, optionalLabels, optionalLabels);
		}

		void write_strong_potential_matrix_without_redundancies(
			std::basic_ostream < CharType, Traits > &output,
			const CharType separator,
			const CharType lister) const
		{
			if (!this->_up_to_date)
			{
				throw std::runtime_error("\"processor\" is not updated.");
			}

			std::vector < string_type > labels{};
			std::optional < std::vector < string_type > > optionalLabels{};

			if (this->_last_comparison_mode == comparison_mode::component_and_organization)
			{
				labels.reserve(this->_components.descriptions.size());

				for (const auto &component : this->_components.descriptions)
				{
					labels.push_back(component.first + lister + component.second.name);
				}

				optionalLabels = std::make_optional(std::move(labels));
			}

			else
			{
				labels.reserve(this->_activities.descriptions.size());

				for (const auto &activity : this->_activities.descriptions)
				{
					labels.push_back(activity.first + lister + activity.second.name);
				}

				optionalLabels = std::make_optional(std::move(labels));
			}

			writer::write_matrix(output, this->_strong_potential_matrix_without_redundancies, separator, lister, optionalLabels, optionalLabels);
		}

		void write_strong_potential_matrix_with_redundancies(
			std::basic_ostream < CharType, Traits > &output,
			const CharType separator,
			const CharType lister) const
		{
			if (!this->_up_to_date)
			{
				throw std::runtime_error("\"processor\" is not updated.");
			}

			std::vector < string_type > labels{};
			std::optional < std::vector < string_type > > optionalLabels{};

			if (this->_last_comparison_mode == comparison_mode::component_and_organization)
			{
				labels.reserve(this->_components.descriptions.size());

				for (const auto &component : this->_components.descriptions)
				{
					labels.push_back(component.first + lister + component.second.name);
				}

				optionalLabels = std::make_optional(std::move(labels));
			}

			else
			{
				labels.reserve(this->_activities.descriptions.size());

				for (const auto &activity : this->_activities.descriptions)
				{
					labels.push_back(activity.first + lister + activity.second.name);
				}

				optionalLabels = std::make_optional(std::move(labels));
			}

			writer::write_matrix(output, this->_potential_matrices[1], separator, lister, optionalLabels, optionalLabels);
		}

		void write_comparative_matrix_without_redundancies(
			std::basic_ostream < CharType, Traits > &output,
			const CharType separator,
			const CharType lister) const
		{
			if (!this->_up_to_date)
			{
				throw std::runtime_error("\"processor\" is not updated.");
			}

			std::vector < string_type > labels{};
			std::optional < std::vector < string_type > > optionalLabels{};

			if (this->_last_comparison_mode == comparison_mode::component_and_organization)
			{
				labels.reserve(this->_components.descriptions.size());

				for (const auto &component : this->_components.descriptions)
				{
					labels.push_back(component.first + lister + component.second.name);
				}

				optionalLabels = std::make_optional(std::move(labels));
			}

			else
			{
				labels.reserve(this->_activities.descriptions.size());

				for (const auto &activity : this->_activities.descriptions)
				{
					labels.push_back(activity.first + lister + activity.second.name);
				}

				optionalLabels = std::make_optional(std::move(labels));
			}

			writer::write_matrix(output, this->_comparative_matrix_without_redundancies_step_2, separator, lister, optionalLabels, optionalLabels);
		}

		void write_comparative_matrix_with_redundancies(
			std::basic_ostream < CharType, Traits > &output,
			const CharType separator,
			const CharType lister) const
		{
			if (!this->_up_to_date)
			{
				throw std::runtime_error("\"processor\" is not updated.");
			}

			std::vector < string_type > labels{};
			std::optional < std::vector < string_type > > optionalLabels{};

			if (this->_last_comparison_mode == comparison_mode::component_and_organization)
			{
				labels.reserve(this->_components.descriptions.size());

				for (const auto &component : this->_components.descriptions)
				{
					labels.push_back(component.first + lister + component.second.name);
				}

				optionalLabels = std::make_optional(std::move(labels));
			}

			else
			{
				labels.reserve(this->_activities.descriptions.size());

				for (const auto &activity : this->_activities.descriptions)
				{
					labels.push_back(activity.first + lister + activity.second.name);
				}

				optionalLabels = std::make_optional(std::move(labels));
			}

			writer::write_matrix(output, this->_comparative_matrix_with_redundancies_step_2, separator, lister, optionalLabels, optionalLabels);
		}
	};
}