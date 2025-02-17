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

export module MAEA.organizational_analysis:reader;
export import :fundamental_definitions;

export import std;

namespace MAEA::organizational_analysis::reader
{
	namespace internals
	{
		constexpr size_t max_line_length = 2048;

		consteval auto comment_expression()
		{
			return "^[\\s]*\\/\\/";
		}

		consteval auto relation_expression()
		{
			return "^(?!\t)\\s*(.*[^\\s])\\s*<=>\\s*(.*(?![\\s|\\0]).)";
		}

		consteval auto role_expression()
		{
			return relation_expression();
		}

		consteval auto activity_expression()
		{
			return relation_expression();
		}

		consteval auto component_expression()
		{
			return relation_expression();
		}

		consteval auto single_field_expression()
		{
			return "^(?!\t)\\s*(.*(?![\\s|\\0]).)";
		}

		consteval auto tabbed_single_field_expression()
		{
			return "^(?!\t\t)\t\\s*(.*(?![\\s|\\0]).)";
		}

		consteval auto double_tabbed_single_field_expression()
		{
			return "^(?!\t\t\t)\t\t\\s*(.*(?![\\s|\\0]).)";
		}

		consteval auto group_expression()
		{
			return single_field_expression();
		}

		consteval auto component_interaction_expression()
		{
			return tabbed_single_field_expression();
		}

		consteval auto agent_in_charge_expression()
		{
			return tabbed_single_field_expression();
		}

		consteval auto dependency_expression()
		{
			return double_tabbed_single_field_expression();
		}

		consteval auto affiliation_activity_expression()
		{
			return relation_expression();
		}

		consteval auto affiliation_component_weight_expression()
		{
			return "\t\\s*(.*[^\\s])\\s*,\\s*(.*(?![\\s|\\0]).)";
		}
	}

	std::istream &read_agents(
		std::istream &input,
		organizational_analysis::agents_type &agents,
		std::ostream &errorOutput = std::cerr,
		const std::locale &locale = std::locale(""))
	{
		size_t lineCounter{};
		std::string group;
		std::regex commentExpression;
		std::regex groupExpression;
		std::regex roleExpression;

		commentExpression.imbue(locale);
		groupExpression.imbue(locale);
		roleExpression.imbue(locale);

		commentExpression.assign(internals::comment_expression());
		groupExpression.assign(internals::group_expression());
		roleExpression.assign(internals::role_expression());

		while (input.good())
		{
			std::string line;
			std::smatch match;

			line.resize(internals::max_line_length);

			input.getline(line.data(), internals::max_line_length);

			lineCounter++;

			if (line.empty())
			{
				continue;
			}

			if (std::regex_search(line, match, commentExpression))
			{
				continue;
			}

			if (std::regex_search(line, match, roleExpression))
			{
				std::set < std::string > groups;
				organizational_analysis::agent _agent;

				groups.insert(group);

				_agent.identification = std::move(match[1].str());
				_agent.groups = std::move(groups);
				_agent.role = std::move(match[2].str());

				agents.insert(std::move(_agent));
			}

			else if (std::regex_search(line, match, groupExpression))
			{
				group = match[0].str();
			}

			else if (!line.empty())
			{
				errorOutput << std::format("Unknown agent at line {}: \"{}\"\n", lineCounter, line);
			}
		}

		return input;
	}

	std::istream &read_activities(
		std::istream &input,
		organizational_analysis::activities_type &activities,
		organizational_analysis::activity_dependencies_type &activityDependencies,
		const organizational_analysis::agents_type &agents,
		std::ostream &errorOutput = std::cerr,
		const std::locale &locale = std::locale(""))
	{
		size_t lineCounter{};
		std::string activity;
		std::string group;
		std::regex commentExpression;
		std::regex groupExpression;
		std::regex activityExpression;
		std::regex agentInChargeExpression;
		std::regex dependencyExpression;

		commentExpression.imbue(locale);
		groupExpression.imbue(locale);
		activityExpression.imbue(locale);
		agentInChargeExpression.imbue(locale);
		dependencyExpression.imbue(locale);

		commentExpression.assign(internals::comment_expression());
		groupExpression.assign(internals::group_expression());
		activityExpression.assign(internals::activity_expression());
		agentInChargeExpression.assign(internals::agent_in_charge_expression());
		dependencyExpression.assign(internals::dependency_expression());

		while (input.good())
		{
			std::string line;
			std::smatch match;

			line.resize(internals::max_line_length);

			input.getline(line.data(), internals::max_line_length);

			lineCounter++;

			if (line.empty())
			{
				continue;
			}

			if (std::regex_search(line, match, commentExpression))
			{
				continue;
			}

			if (std::regex_search(line, match, activityExpression))
			{
				std::set < std::string > groups;
				organizational_analysis::activity _activity;

				groups.insert(group);

				_activity.identification = std::move(match[1].str());
				_activity.groups = std::move(groups);
				_activity.name = std::move(match[2].str());

				activity = _activity.identification;

				activities.insert(std::move(_activity));
			}

			else if (std::regex_search(line, match, agentInChargeExpression))
			{
				std::string agentInCharge = match[1].str();

				if (!agents.contains(agentInCharge))
				{
					throw std::runtime_error(std::format("Could not find agent \"{}\".", agentInCharge));
				}

				auto node = activities.extract(activity);

				if (node.empty())
				{
					throw std::runtime_error(std::format("Could not find activity \"{}\".", activity));
				}

				auto &_activity = node.value();

				_activity.agents_in_charge.insert(std::move(agentInCharge));

				activities.insert(std::move(node));
			}

			else if (std::regex_search(line, match, dependencyExpression))
			{
				std::string dependency = match[1].str();

				if (activity == dependency)
				{
					throw std::runtime_error(std::format("Activity \"{}\" is depending on itself.", activity));
				}

				activityDependencies.insert(activity, dependency);
			}

			else if (std::regex_search(line, match, groupExpression))
			{
				group = match[1].str();
			}

			else if (!line.empty())
			{
				errorOutput << std::format("Unknown activity at line {}: \"{}\"\n", lineCounter, line);
			}
		}

		for (const auto &_activity : activities)
		{
			activityDependencies.insert(_activity.identification);
		}

		for (const auto &dependency : activityDependencies.container())
		{
			if (!activities.contains(dependency.first))
			{
				throw
					std::runtime_error(
						std::format(
							"Dependency \"{}\" does not have a description.",
							dependency.first));
			}
		}

		for (const auto &_activity : activities)
		{
			if (_activity.agents_in_charge.empty())
			{
				throw
					std::runtime_error(
						std::format(
							"Activity \"{}\" does not have an agent in charge.",
							_activity.identification));
			}
		}

		return input;
	}

	template < bool InterfacesAreReciprocal >
	std::istream &read_components(
		std::istream &input,
		organizational_analysis::components_type &components,
		organizational_analysis::component_interactions_type < InterfacesAreReciprocal > &componentInteractions,
		std::ostream &errorOutput = std::cerr,
		const std::locale &locale = std::locale(""))
	{
		size_t lineCounter{};
		std::string component;
		std::string group;
		std::regex commentExpression;
		std::regex groupExpression;
		std::regex componentExpression;
		std::regex interactionExpression;

		commentExpression.imbue(locale);
		groupExpression.imbue(locale);
		componentExpression.imbue(locale);
		interactionExpression.imbue(locale);

		commentExpression.assign(internals::comment_expression());
		groupExpression.assign(internals::group_expression());
		componentExpression.assign(internals::component_expression());
		interactionExpression.assign(internals::component_interaction_expression());

		while (input.good())
		{
			std::string line;
			std::smatch match;

			line.resize(internals::max_line_length);

			input.getline(line.data(), internals::max_line_length);

			lineCounter++;

			if (line.empty())
			{
				continue;
			}

			if (std::regex_search(line, match, commentExpression))
			{
				continue;
			}

			if (std::regex_search(line, match, componentExpression))
			{
				std::set < std::string > groups;
				organizational_analysis::component _component;

				groups.insert(group);

				_component.identification = std::move(match[1].str());
				_component.name = std::move(match[2].str());
				_component.groups = std::move(groups);

				component = _component.identification;

				components.insert(std::move(_component));
			}

			else if (std::regex_search(line, match, interactionExpression))
			{
				componentInteractions.insert(component, match[1].str());
			}

			else if (std::regex_search(line, match, groupExpression))
			{
				group = match[1].str();
			}

			else if (!line.empty())
			{
				errorOutput << std::format("Unknown component at line {}: \"{}\"\n", lineCounter, line);
			}
		}

		return input;
	}

	std::istream &read_affiliations(
		std::istream &input,
		organizational_analysis::affiliations_type &affiliations,
		const organizational_analysis::activities_type &activities,
		const organizational_analysis::components_type &components,
		std::ostream &errorOutput = std::cerr,
		const std::locale &locale = std::locale(""))
	{
		size_t lineCounter{};
		std::string activity;
		std::regex commentExpression;
		std::regex affiliationActivityExpression;
		std::regex affiliationComponentWeightExpression;

		commentExpression.imbue(locale);
		affiliationActivityExpression.imbue(locale);
		affiliationComponentWeightExpression.imbue(locale);

		commentExpression.assign(internals::comment_expression());
		affiliationActivityExpression.assign(internals::affiliation_activity_expression());
		affiliationComponentWeightExpression.assign(internals::affiliation_component_weight_expression());

		while (input.good())
		{
			std::string line;
			std::smatch match;

			line.resize(internals::max_line_length);

			input.getline(line.data(), internals::max_line_length);

			lineCounter++;

			if (line.empty())
			{
				continue;
			}

			if (std::regex_search(line, match, commentExpression))
			{
				continue;
			}

			if (std::regex_search(line, match, affiliationActivityExpression))
			{
				activity = match[1].str();

				if (!activities.contains(activity))
				{
					throw std::runtime_error(std::format("Could not find activity \"{}\".", activity));
				}

				affiliations.emplace(
					activity,
					std::map < std::string, float > ());
			}

			else if (std::regex_search(line, match, affiliationComponentWeightExpression))
			{
				std::string component = match[1].str();
				float weight = std::stof(match[2].str(), nullptr);

				if (!components.contains(component))
				{
					throw std::runtime_error(std::format("Could not find component \"{}\".", component));
				}

				if (weight == float{})
				{
					throw
						std::runtime_error(
							std::format(
								"Activity \"{}\" has null connection with component \"{}\".",
								activity,
								component));
				}

				affiliations.at(activity).emplace(std::move(component), std::move(weight));
			}

			else if (!line.empty())
			{
				errorOutput << std::format("Unknown affliation at line {}: \"{}\"\n", lineCounter, line);
			}
		}

		for (const auto &_activity : activities)
		{
			affiliations.emplace(_activity.identification, std::map < std::string, float > ());
		}

		return input;
	}
}