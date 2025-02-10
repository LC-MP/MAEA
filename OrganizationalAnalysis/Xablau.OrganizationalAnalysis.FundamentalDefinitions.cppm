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

export module MAEA.organizational_analysis:fundamental_definitions;

export import std;

export import xablau.graph;

namespace MAEA::organizational_analysis
{
	struct agent final
	{
		std::string identification{};
		std::string role{};
		std::set < std::string > groups{};

		[[nodiscard]] constexpr bool operator<(const agent &other) const
		{
			return this->identification < other.identification;
		}

		[[nodiscard]] constexpr bool operator==(const agent &other) const
		{
			return this->identification == other.identification;
		}

		agent() = default;

		agent(const std::string &identification, const std::string &role = "") :
			identification(identification),
			role(role)
		{
		}

		agent(const agent &) = default;

		agent(agent &&) = default;
	};

	using agents_type = std::set < organizational_analysis::agent >;

	struct activity final
	{
		struct task final
		{
			std::string identification{};
			std::string name{};
			float degree{};
			std::array < size_t, 2 > coordinates{};

			[[nodiscard]] constexpr bool operator<(const task &other) const
			{
				return this->identification < other.identification;
			}

			[[nodiscard]] constexpr bool operator==(const task &other) const
			{
				return this->identification == other.identification;
			}

			friend std::ostream &operator<<(std::ostream &stream, const task &task)
			{
				stream << task.identification;

				return stream;
			}

			task() = default;

			task(const std::string &identification,
				const std::string &name = "",
				const float degree = float{},
				const std::array < size_t, 2 > &coordinates = {}) :

				identification(identification),
				name(name),
				degree(degree),
				coordinates(coordinates)
			{
			}

			task(const task &) = default;

			task(task &&) = default;
		};

		using tasks_type =
			xablau::graph::digraph <
				activity::task,
				xablau::graph::graph_container_type < xablau::graph::graph_container_type_value::ordered >,
				xablau::graph::edge < float > >;

		std::string identification{};
		std::string name{};
		std::set < std::string > groups{};
		std::set < std::string > agents_in_charge{};
		tasks_type tasks{};

		[[nodiscard]] constexpr bool operator<(const activity &other) const
		{
			return this->identification < other.identification;
		}

		[[nodiscard]] constexpr bool operator==(const activity &other) const
		{
			return this->identification == other.identification;
		}

		activity() = default;

		activity(const std::string &identification, const std::string &name = "") :
			identification(identification),
			name(name)
		{
		}

		activity(const activity &) = default;

		activity(activity &&) = default;
	};

	using activities_type = std::set < organizational_analysis::activity >;

	using activity_dependencies_type =
		xablau::graph::digraph <
			std::string,
			xablau::graph::graph_container_type < xablau::graph::graph_container_type_value::ordered >,
			xablau::graph::edge < float > >;

	struct component final
	{
		std::string identification{};
		std::string name{};
		std::set < std::string > groups{};
		std::set < std::string > agents_in_charge{};

		[[nodiscard]] constexpr bool operator<(const component &other) const
		{
			return this->identification < other.identification;
		}

		[[nodiscard]] constexpr bool operator==(const component &other) const
		{
			return this->identification == other.identification;
		}

		component() = default;

		component(const std::string &identification, const std::string &name = "") :
			identification(identification),
			name(name)
		{
		}

		component(const component &) = default;

		component(component &&) = default;
	};

	using components_type = std::set < organizational_analysis::component >;

	template < bool InterfacesAreReciprocal >
	using component_interactions_type =
		typename std::conditional <
			InterfacesAreReciprocal,
			xablau::graph::graph <
				std::string,
				xablau::graph::graph_container_type < xablau::graph::graph_container_type_value::ordered >,
				xablau::graph::edge < float > >,
			xablau::graph::digraph <
				std::string,
				xablau::graph::graph_container_type < xablau::graph::graph_container_type_value::ordered >,
				xablau::graph::edge < float > > > ::type;

	using affiliations_type =
		std::map <
			std::string,
			std::map < std::string, float > >;
}