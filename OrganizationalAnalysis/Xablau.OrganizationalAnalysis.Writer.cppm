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

export module xablau.organizational_analysis:writer;
export import :fundamental_definitions;

export import std;

import xablau.algebra;

namespace xablau::organizational_analysis::writer
{
	namespace internals
	{
		std::string remove_separator(
			const std::string &string,
			const char separator,
			const char lister)
		{
			auto filteredString = string;

			std::replace(filteredString.begin(), filteredString.end(), separator, lister);

			return filteredString;
		}
	}

	void write_agents(
		std::ostream &output,
		const organizational_analysis::agents_type &agents,
		const char separator,
		const char lister)
	{
		output << "Identification" << separator << "Groups" << separator << "Role\n";

		for (const auto &agent : agents)
		{
			output << internals::remove_separator(agent.identification, separator, lister) << separator;

			size_t i = 1;
			const auto groupCount = agent.groups.size();

			for (const auto &group : agent.groups)
			{
				output << internals::remove_separator(group, separator, lister);

				if (i < groupCount)
				{
					output << lister;
					output << ' ';
				}

				i++;
			}

			output << separator;
			output << internals::remove_separator(agent.role, separator, lister) << '\n';
		}
	}

	void write_activities(
		std::ostream &output,
		const organizational_analysis::activities_type &activities,
		const organizational_analysis::activity_dependencies_type &activityDependencies,
		const organizational_analysis::agents_type &agents,
		const char separator,
		const char lister)
	{
		using offset_type = typename std::ostream::off_type;

		output << "Agent in charge" << separator << "Groups" << separator << "Activity" << separator;

		for (const auto &activity : activities)
		{
			output << separator;
			output << internals::remove_separator(activity.identification, separator, lister);
		}

		output << '\n';

		for (const auto &activity : activities)
		{
			size_t i = 1;
			const auto agentCount = activity.agents_in_charge.size();

			for (const auto item : activity.agents_in_charge)
			{
				output << internals::remove_separator(agents.find(item)->role, separator, lister);

				if (i < agentCount)
				{
					output << lister;
					output << ' ';
				}

				i++;
			}

			output << separator;

			i = 1;
			const auto groupCount = activity.groups.size();

			for (const auto &group : activity.groups)
			{
				output << internals::remove_separator(group, separator, lister);

				if (i < groupCount)
				{
					output << lister;
					output << ' ';
				}

				i++;
			}

			output << separator;
			output << internals::remove_separator(activity.name, separator, lister);
			output << separator;
			output << internals::remove_separator(activity.identification, separator, lister);
			output << separator;

			i = 1;
			const auto activityCount = activities.size();

			for (const auto &otherActivity : activities)
			{
				if (activity.identification == otherActivity.identification)
				{
					output << "####";
				}

				else if (activityDependencies.contains(activity.identification, otherActivity.identification))
				{
					output << 1;
				}

				if (i < activityCount)
				{
					output << separator;
				}

				i++;
			}

			output << '\n';
		}
	}

	template < bool InterfacesAreReciprocal >
	void write_components(
		std::ostream &output,
		const organizational_analysis::components_type &components,
		const organizational_analysis::component_interactions_type < InterfacesAreReciprocal > &componentInteractions,
		const char separator,
		const char lister)
	{
		using offset_type = typename std::ostream ::off_type;

		output << "Groups" << separator << "Component" << separator;

		for (const auto &component : components)
		{
			output << separator;
			output << internals::remove_separator(component.identification, separator, lister);
		}

		output << '\n';

		for (const auto &component1 : components)
		{
			size_t i = 1;
			const auto groupCount = component1.groups.size();

			for (const auto &group : component1.groups)
			{
				output << internals::remove_separator(group, separator, lister);

				if (i < groupCount)
				{
					output << lister;
					output << ' ';
				}

				i++;
			}

			output << separator;
			output << internals::remove_separator(component1.name, separator, lister);
			output << separator;
			output << internals::remove_separator(component1.identification, separator, lister);
			output << separator;

			i = 1;
			const auto componentCount = components.size();

			for (const auto &component2 : components)
			{
				if (component1.identification == component2.identification)
				{
					output << "####";
				}

				else if (componentInteractions.contains(component1.identification, component2.identification))
				{
					output << 1;
				}

				if (i < componentCount)
				{
					output << separator;
				}

				i++;
			}

			output << '\n';
		}
	}

	void write_affiliations(
		std::ostream &output,
		const organizational_analysis::activities_type &activities,
		const organizational_analysis::affiliations_type &affiliations,
		const organizational_analysis::components_type &components,
		const char separator,
		const char lister)
	{
		output << "Descriptions" << separator;

		for (const auto &component : components)
		{
			output << separator;
			output << internals::remove_separator(component.name, separator, lister);
		}

		output << '\n';
		output << separator;

		output << "Activity by Component";

		for (const auto &component : components)
		{
			output << separator;
			output << internals::remove_separator(component.identification, separator, lister);
		}

		output << '\n';

		for (const auto &[activity, _components] : affiliations)
		{
			output << internals::remove_separator(activities.find(activity)->name, separator, lister);
			output << separator;

			output << internals::remove_separator(activity, separator, lister);
			output << separator;

			auto iterator = _components.cbegin();

			for (const auto &component : components)
			{
				if (iterator != _components.cend() && iterator->first == component.identification)
				{
					output << iterator->second;

					++iterator;
				}

				output << separator;
			}

			output << '\n';
		}
	}

	template <
		typename MatrixType,
		typename OptionalRowRangeType,
		typename OptionalColumnRangeType >
	requires (
		xablau::algebra::concepts::xablau_matrix < MatrixType > && (
			(std::ranges::forward_range < typename OptionalRowRangeType::value_type > &&
			std::ranges::sized_range < typename OptionalRowRangeType::value_type > &&
			std::same_as < std::ranges::range_value_t < typename OptionalRowRangeType::value_type >, std::string >) ||
			(std::same_as < OptionalRowRangeType, std::nullopt_t >)) && (

			(std::ranges::forward_range < typename OptionalColumnRangeType::value_type > &&
			std::ranges::sized_range < typename OptionalColumnRangeType::value_type > &&
			std::same_as < std::ranges::range_value_t < typename OptionalColumnRangeType::value_type >, std::string >) ||
			(std::same_as < OptionalColumnRangeType, std::nullopt_t >)))
	void write_matrix(
		std::ostream &output,
		const MatrixType &matrix,
		const char separator,
		const char lister,
		const OptionalRowRangeType optionalRowLabels,
		const OptionalColumnRangeType optionalColumnLabels)
	requires (
		std::same_as < typename MatrixType::value_type, float > ||
		std::same_as < typename MatrixType::value_type, std::string >)
	{
		constexpr bool isRowNullopt = std::same_as < OptionalRowRangeType, std::nullopt_t >;
		constexpr bool isColumnNullopt = std::same_as < OptionalColumnRangeType, std::nullopt_t >;
		bool hasRowLabels = false;
		bool hasColumnLabels = false;

		if constexpr (!isRowNullopt)
		{
			hasRowLabels = optionalRowLabels.has_value();
		}

		if constexpr (!isColumnNullopt)
		{
			hasColumnLabels = optionalColumnLabels.has_value();
		}

		if constexpr (!isRowNullopt)
		{
			if (hasRowLabels && optionalRowLabels.value().size() != matrix.dimensionalities()[0])
			{
				throw
					std::runtime_error(
						std::format(
							"\"optionalRowLabels\" size and matrix row count are different: {} != {}.",
							optionalRowLabels.value().size(),
							matrix.dimensionalities()[0]));
			}
		}

		if constexpr (!isColumnNullopt)
		{
			if (hasColumnLabels && optionalColumnLabels.value().size() != matrix.dimensionalities()[1])
			{
				throw
					std::runtime_error(
						std::format(
							"\"optionalColumnLabels\" size and matrix column count are different: {} != {}.",
							optionalColumnLabels.value().size(),
							matrix.dimensionalities()[1]));
			}
		}

		if (hasRowLabels && hasColumnLabels)
		{
			output << separator;
		}

		if constexpr (!isColumnNullopt)
		{
			if (hasColumnLabels)
			{
				const auto &range = optionalColumnLabels.value();

				for (const auto &columnLabel : range)
				{
					output << internals::remove_separator(columnLabel, separator, lister);
					output << separator;
				}

				output << '\n';
			}
		}

		for (size_t i = 0; i < matrix.dimensionalities()[0]; i++)
		{
			if constexpr (!isRowNullopt)
			{
				if (hasRowLabels)
				{
					auto iterator = optionalRowLabels.value().cbegin();

					std::advance(iterator, i);

					output << internals::remove_separator(*iterator, separator, lister);
					output << separator;
				}
			}

			for (size_t j = 0; j < matrix.dimensionalities()[1]; j++)
			{
				if constexpr (std::same_as < typename MatrixType::value_type, float >)
				{
					if (matrix(i, j) != float{})
					{
						output << matrix(i, j);
					}
				}

				else
				{
					output << matrix(i, j);
				}

				output << separator;
			}

			output << '\n';
		}
	}

	template < xablau::algebra::concepts::xablau_matrix MatrixType >
	void write_report(
		std::ostream &output,
		const MatrixType &comparativeMatrix,
		const std::map < size_t, std::string > &baseIndexToKeyMap,
		const float indirectlyRelatedDegree,
		const float relatedDegree,
		const float directlyRelatedDegree)
	{
		std::array < std::vector < size_t >, 3 > interactions =
		{
			std::vector < size_t > (comparativeMatrix.dimensionalities()[0], size_t{}),
			std::vector < size_t > (comparativeMatrix.dimensionalities()[0], size_t{}),
			std::vector < size_t > (comparativeMatrix.dimensionalities()[0], size_t{})
		};

		for (size_t i = 0; i < comparativeMatrix.dimensionalities()[0]; i++)
		{
			std::array < std::set < std::string >, 3 > attendances{};

			for (size_t j = 0; j < comparativeMatrix.dimensionalities()[1]; j++)
			{
				const auto cell1 = comparativeMatrix(i, j);

				if (cell1 >= indirectlyRelatedDegree && cell1 < relatedDegree)
				{
					interactions[0][i]++;

					attendances[0].insert(baseIndexToKeyMap.at(j));
				}

				else if (cell1 >= relatedDegree && cell1 < directlyRelatedDegree)
				{
					interactions[1][i]++;

					attendances[1].insert(baseIndexToKeyMap.at(j));
				}

				else
				{
					interactions[2][i]++;

					attendances[2].insert(baseIndexToKeyMap.at(j));
				}

				const auto cell2 = comparativeMatrix(j, i);

				if (cell2 >= indirectlyRelatedDegree && cell2 < relatedDegree)
				{
					interactions[0][i]++;

					attendances[0].insert(baseIndexToKeyMap.at(j));
				}

				else if (cell2 >= relatedDegree && cell2 < directlyRelatedDegree)
				{
					interactions[1][i]++;

					attendances[1].insert(baseIndexToKeyMap.at(j));
				}

				else
				{
					interactions[2][i]++;

					attendances[2].insert(baseIndexToKeyMap.at(j));
				}
			}

			output << "Element " << baseIndexToKeyMap.at(i) << "\n";

			output << "Attended interactions: " << interactions[1][i] << "\n";

			for (const auto &attendance : attendances[1])
			{
				output << "\t" << attendance << "\n";
			}

			output << "Unexpected interactions: " << interactions[2][i] << "\n";

			for (const auto &attendance : attendances[2])
			{
				output << "\t" << attendance << "\n";
			}

			output << "Unattended interactions: " << interactions[0][i] << "\n";

			for (const auto &attendance : attendances[0])
			{
				output << "\t" << attendance << "\n";
			}

			output << "\n";
		}

		output <<
			"Total of attended interactions: " << std::accumulate(interactions[1].cbegin(), interactions[1].cend(), size_t{}) << "\n" <<
			"Total of unexpected interactions: " << std::accumulate(interactions[2].cbegin(), interactions[2].cend(), size_t{}) << "\n" <<
			"Total of unattended interactions: " << std::accumulate(interactions[0].cbegin(), interactions[0].cend(), size_t{}) << "\n\n";
	}
}