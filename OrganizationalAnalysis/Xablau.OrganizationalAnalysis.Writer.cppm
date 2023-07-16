// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

// MIT License
//
// Copyright (c) 2023 Jean Amaro <jean.amaro@outlook.com.br>
// Copyright (c) 2023 Lucas Melchiori Pereira <lc.melchiori@gmail.com>
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

export import <algorithm>;
export import <concepts>;
export import <iostream>;
export import <istream>;
export import <format>;
export import <locale>;
export import <optional>;
export import <ranges>;
export import <regex>;
export import <stdexcept>;
export import <vector>;

import xablau.algebra;

export namespace xablau::organizational_analysis::writer
{
	namespace internals
	{
		template < typename CharType, typename Traits >
		std::basic_string < CharType, Traits > remove_separator(
			const std::basic_string < CharType, Traits > &string,
			const CharType separator,
			const CharType lister)
		{
			auto filteredString = string;

			std::replace(filteredString.begin(), filteredString.end(), separator, lister);

			return filteredString;
		}
	}

	template < typename CharType, typename Traits >
	requires (std::same_as < CharType, char > || std::same_as < CharType, wchar_t >)
	std::basic_ostream < CharType, Traits > &write_agents(
		std::basic_ostream < CharType, Traits > &output,
		const organizational_analysis::agents < CharType, Traits > &agents,
		const CharType separator,
		const CharType lister)
	{
		if constexpr (std::same_as < CharType, char >)
		{
			output << "Identification" << separator << "Groups" << separator << "Role\n";
		}

		else
		{
			output << L"Identification" << separator << L"Groups" << separator << L"Role\n";
		}

		for (const auto &[identification, description] : agents.descriptions)
		{
			output << internals::remove_separator(identification, separator, lister) << separator;

			size_t i = 1;
			const auto groupCount = description.groups.size();

			for (const auto &group : description.groups)
			{
				output << internals::remove_separator(group, separator, lister);

				if (i < groupCount)
				{
					output << lister;
					output << CharType{' '};
				}

				i++;
			}

			output << separator;
			output << internals::remove_separator(description.role, separator, lister) << CharType{'\n'};
		}

		return output;
	}

	template < typename CharType, typename Traits >
	requires (std::same_as < CharType, char > || std::same_as < CharType, wchar_t >)
	std::basic_ostream < CharType, Traits > &write_activities(
		std::basic_ostream < CharType, Traits > &output,
		const organizational_analysis::activities < CharType, Traits > &activities,
		const organizational_analysis::agents < CharType, Traits > &agents,
		const CharType separator,
		const CharType lister)
	{
		using offset_type = typename std::basic_ostream < CharType, Traits > ::off_type;

		if constexpr (std::same_as < CharType, char >)
		{
			output << "Agent in charge" << separator << "Groups" << separator << "Activity" << separator;
		}

		else
		{
			output << L"Agent in charge" << separator << "Groups" << separator << "Activity" << separator;
		}

		for (const auto &[identification, description] : activities.descriptions)
		{
			output << separator;
			output << internals::remove_separator(identification, separator, lister);
		}

		output << CharType{'\n'};

		for (const auto &[identification1, description1] : activities.descriptions)
		{
			size_t i = 1;
			const auto agentCount = description1.agents_in_charge.size();

			for (const auto item : description1.agents_in_charge)
			{
				output << internals::remove_separator(agents.descriptions.at(item).role, separator, lister);

				if (i < agentCount)
				{
					output << lister;
					output << CharType{' '};
				}

				i++;
			}

			output << separator;

			i = 1;
			const auto groupCount = description1.groups.size();

			for (const auto &group : description1.groups)
			{
				output << internals::remove_separator(group, separator, lister);

				if (i < groupCount)
				{
					output << lister;
					output << CharType{' '};
				}

				i++;
			}

			output << separator;
			output << internals::remove_separator(description1.name, separator, lister);
			output << separator;
			output << internals::remove_separator(identification1, separator, lister);
			output << separator;

			i = 1;
			const auto descriptionCount = activities.descriptions.size();

			for (const auto &[identification2, description2] : activities.descriptions)
			{
				if (identification1 == identification2)
				{
					if constexpr (std::same_as < CharType, char >)
					{
						output << "####";
					}

					else
					{
						output << L"####";
					}
				}

				else if (activities.dependencies.contains(identification1, identification2))
				{
					output << 1;
				}

				if (i < descriptionCount)
				{
					output << separator;
				}

				i++;
			}

			output << CharType{'\n'};
		}

		return output;
	}

	template < bool InterfacesAreReciprocal, typename CharType, typename Traits >
	requires (std::same_as < CharType, char > || std::same_as < CharType, wchar_t >)
	std::basic_ostream < CharType, Traits > &write_components(
		std::basic_ostream < CharType, Traits > &output,
		const organizational_analysis::components < InterfacesAreReciprocal, CharType, Traits > &components,
		const CharType separator,
		const CharType lister)
	{
		using offset_type = typename std::basic_ostream < CharType, Traits > ::off_type;

		if constexpr (std::same_as < CharType, char >)
		{
			output << "Groups" << separator << "Component" << separator;
		}

		else
		{
			output << L"Groups" << separator << L"Component" << separator;
		}

		for (const auto &[identification, description] : components.descriptions)
		{
			output << separator;
			output << internals::remove_separator(identification, separator, lister);
		}

		output << CharType{'\n'};

		for (const auto &[identification1, description1] : components.descriptions)
		{
			size_t i = 1;
			const auto groupCount = description1.groups.size();

			for (const auto &group : description1.groups)
			{
				output << internals::remove_separator(group, separator, lister);

				if (i < groupCount)
				{
					output << lister;
					output << CharType{' '};
				}

				i++;
			}

			output << separator;
			output << internals::remove_separator(description1.name, separator, lister);
			output << separator;
			output << internals::remove_separator(identification1, separator, lister);
			output << separator;

			i = 1;
			const auto componentCount = components.descriptions.size();

			for (const auto &[identification2, description2] : components.descriptions)
			{
				if (identification1 == identification2)
				{
					if constexpr (std::same_as < CharType, char >)
					{
						output << "####";
					}

					else
					{
						output << L"####";
					}
				}

				else if (components.interactions.contains(identification1, identification2))
				{
					output << 1;
				}

				if (i < componentCount)
				{
					output << separator;
				}

				i++;
			}

			output << CharType{'\n'};
		}

		return output;
	}

	template < bool InterfacesAreReciprocal, typename CharType, typename Traits >
	requires (std::same_as < CharType, char > || std::same_as < CharType, wchar_t >)
	std::basic_ostream < CharType, Traits > &write_affiliations(
		std::basic_ostream < CharType, Traits > &output,
		const organizational_analysis::activities < CharType, Traits > &activities,
		const organizational_analysis::affiliations < CharType, Traits > &affiliations,
		const organizational_analysis::components < InterfacesAreReciprocal, CharType, Traits > &components,
		const CharType separator,
		const CharType lister)
	{
		if constexpr (std::same_as < CharType, char >)
		{
			output << "Descriptions" << separator;
		}

		else
		{
			output << L"Descriptions" << separator;
		}

		for (const auto &[identification, description] : components.descriptions)
		{
			output << separator;
			output << internals::remove_separator(description.name, separator, lister);
		}

		output << CharType{'\n'};
		output << separator;

		if constexpr (std::same_as < CharType, char >)
		{
			output << "Activity by Component";
		}

		else
		{
			output << L"Activity by Component";
		}

		for (const auto &[identification, description] : components.descriptions)
		{
			output << separator;
			output << internals::remove_separator(identification, separator, lister);
		}

		output << CharType{'\n'};

		for (const auto &[identification1, description1] : affiliations.responsabilities)
		{
			output << internals::remove_separator(activities.descriptions.at(identification1).name, separator, lister);
			output << separator;

			output << internals::remove_separator(identification1, separator, lister);
			output << separator;

			auto iterator = description1.cbegin();

			for (const auto &[identification2, description2] : components.descriptions)
			{
				if (iterator != description1.cend() && iterator->first == identification2)
				{
					output << iterator->second;

					++iterator;
				}

				output << separator;
			}

			output << CharType{'\n'};
		}

		return output;
	}

	template <
		typename CharType,
		typename Traits,
		typename MatrixType,
		typename OptionalRowRangeType,
		typename OptionalColumnRangeType >
	requires (
		xablau::algebra::concepts::xablau_matrix < MatrixType > &&
		(std::same_as < CharType, char > || std::same_as < CharType, wchar_t >) &&
		std::ranges::forward_range < typename OptionalRowRangeType::value_type > &&
		std::ranges::forward_range < typename OptionalColumnRangeType::value_type > &&
		std::same_as < std::ranges::range_value_t < typename OptionalRowRangeType::value_type >, std::basic_string < CharType, Traits > > &&
		std::same_as < std::ranges::range_value_t < typename OptionalColumnRangeType::value_type >, std::basic_string < CharType, Traits > >)
	std::basic_ostream < CharType, Traits > &write_matrix(
		std::basic_ostream < CharType, Traits > &output,
		const MatrixType &matrix,
		const CharType separator,
		const CharType lister,
		const OptionalRowRangeType optionalRowLabels,
		const OptionalColumnRangeType optionalColumnLabels)
	requires (std::same_as < typename MatrixType::value_type, float >)
	{
		const bool hasRowLabels = optionalRowLabels.has_value();
		const bool hasColumnLabels = optionalColumnLabels.has_value();

		if (hasRowLabels && optionalRowLabels.value().size() != matrix.dimensionalities()[0])
		{
			throw
				std::runtime_error(
					std::format(
						"\"optionalRowLabels\" size and matrix row count are different: {} != {}.",
						optionalRowLabels.value().size(),
						matrix.dimensionalities()[0]));
		}

		if (hasColumnLabels && optionalColumnLabels.value().size() != matrix.dimensionalities()[1])
		{
			throw
				std::runtime_error(
					std::format(
						"\"optionalColumnLabels\" size and matrix column count are different: {} != {}.",
						optionalColumnLabels.value().size(),
						matrix.dimensionalities()[1]));
		}

		if (hasRowLabels && hasColumnLabels)
		{
			output << separator;
		}

		if (hasColumnLabels)
		{
			const auto &range = optionalColumnLabels.value();

			for (const auto &columnLabel : range)
			{
				output << internals::remove_separator(columnLabel, separator, lister);
				output << separator;
			}

			output << CharType{'\n'};
		}

		auto iterator = optionalRowLabels.value().cbegin();

		for (size_t i = 0; i < matrix.dimensionalities()[0]; i++)
		{
			if (hasRowLabels)
			{
				output << internals::remove_separator(*iterator, separator, lister);
				output << separator;

				++iterator;
			}

			for (size_t j = 0; j < matrix.dimensionalities()[1]; j++)
			{
				if (matrix(i, j) != float{})
				{
					output << matrix(i, j);
				}

				output << separator;
			}

			output << CharType{'\n'};
		}

		return output;
	}

	template <
		xablau::algebra::concepts::xablau_matrix MatrixType,
		typename CharType,
		typename Traits >
	requires (std::same_as < CharType, char > || std::same_as < CharType, wchar_t >)
	std::basic_ostream < CharType, Traits > &write_report(
		std::basic_ostream < CharType, Traits > &output,
		const MatrixType &comparativeMatrix,
		const std::map < size_t, std::basic_string < CharType, Traits > > &baseIndexToKeyMap)
	{
		std::array < std::vector < size_t >, 3 > interactions =
		{
			std::vector < size_t > (comparativeMatrix.dimensionalities()[0], size_t{}),
			std::vector < size_t > (comparativeMatrix.dimensionalities()[0], size_t{}),
			std::vector < size_t > (comparativeMatrix.dimensionalities()[0], size_t{})
		};

		for (size_t i = 0; i < comparativeMatrix.dimensionalities()[0]; i++)
		{
			for (size_t j = 0; j < comparativeMatrix.dimensionalities()[1]; j++)
			{
				const auto cell1 = comparativeMatrix(i, j);

				if (cell1 == organizational_analysis::indirectly_related)
				{
					interactions[0][i]++;
				}

				else if (cell1 == organizational_analysis::related)
				{
					interactions[1][i]++;
				}

				else if (cell1 == organizational_analysis::directly_related)
				{
					interactions[2][i]++;
				}

				const auto cell2 = comparativeMatrix(j, i);

				if (cell2 == organizational_analysis::indirectly_related)
				{
					interactions[0][i]++;
				}

				else if (cell2 == organizational_analysis::related)
				{
					interactions[1][i]++;
				}

				else if (cell2 == organizational_analysis::directly_related)
				{
					interactions[2][i]++;
				}
			}

			if constexpr (std::same_as < CharType, char >)
			{
				output <<
					"Element " << baseIndexToKeyMap.at(i) << "\n" <<
					"Attended interactions: " << interactions[1][i] << "\n" <<
					"Unexpected interactions: " << interactions[2][i] << "\n" <<
					"Unattended interactions: " << interactions[0][i] << "\n\n";
			}

			else
			{
				output <<
					L"Element " << baseIndexToKeyMap.at(i) << L"\n" <<
					L"Attended interactions: " << interactions[1][i] << L"\n" <<
					L"Unexpected interactions: " << interactions[2][i] << L"\n" <<
					L"Unattended interactions: " << interactions[0][i] << L"\n\n";
			}
		}

		if constexpr (std::same_as < CharType, char >)
		{
			output <<
				"Total of attended interactions: " << std::accumulate(interactions[1].cbegin(), interactions[1].cend(), size_t{}) << "\n" <<
				"Total of unexpected interactions: " << std::accumulate(interactions[2].cbegin(), interactions[2].cend(), size_t{}) << "\n" <<
				"Total of unattended interactions: " << std::accumulate(interactions[0].cbegin(), interactions[0].cend(), size_t{}) << "\n\n";
		}

		else
		{
			output <<
				L"Total of attended interactions: " << std::accumulate(interactions[1].cbegin(), interactions[1].cend(), size_t{}) << L"\n" <<
				L"Total of unexpected interactions: " << std::accumulate(interactions[2].cbegin(), interactions[2].cend(), size_t{}) << L"\n" <<
				L"Total of unattended interactions: " << std::accumulate(interactions[0].cbegin(), interactions[0].cend(), size_t{}) << L"\n\n";
		}

		return output;
	}
}