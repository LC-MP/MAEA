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

module;

#include <opencv2/opencv.hpp>

export module xablau.organizational_analysis:blueprint;
export import :fundamental_definitions;

export import <algorithm>;
export import <array>;
export import <filesystem>;
export import <format>;
export import <limits>;
export import <map>;
export import <set>;
export import <string>;
export import <type_traits>;

export import xablau.algebra;
export import xablau.graph;

namespace xablau::organizational_analysis
{
	const cv::Vec3b wall_color(0, 0, 0);
	const cv::Vec3b external_color(100, 100, 100);
	const cv::Vec3b floor_island_color(200, 200, 200);
	const cv::Vec3b floor_color(255, 255, 255);
	const cv::Vec3b reference_color(255, 60, 0);

	export enum class traversability
	{
		closed,
		open,
		border,
		teleport
	};

	class element final
	{
	public:
		std::string identification{};
		std::pair < cv::Vec3b, cv::Vec3b > domain{};
		xablau::organizational_analysis::traversability traversability = xablau::organizational_analysis::traversability::closed;

		bool operator<(const element &other) const
		{
			return this->identification < other.identification;
		}

		bool operator==(const element &other) const
		{
			return this->identification == other.identification;
		}

		element() noexcept = default;

		element(
			const char *identification,
			const std::pair < cv::Vec3b, cv::Vec3b > domain = std::make_pair(cv::Vec3b{}, cv::Vec3b{}),
			const xablau::organizational_analysis::traversability traversability = xablau::organizational_analysis::traversability::closed) :

			identification(identification),
			domain(domain),
			traversability(traversability)
		{
		}

		element(
			const std::string &identification,
			const std::pair < cv::Vec3b, cv::Vec3b > domain = std::make_pair(cv::Vec3b{}, cv::Vec3b{}),
			const xablau::organizational_analysis::traversability traversability = xablau::organizational_analysis::traversability::closed) :

			identification(identification),
			domain(domain),
			traversability(traversability)
		{
		}
	};

	const element null_element{};

	class element_instance final
	{
	public:
		std::string identification{};
		const xablau::organizational_analysis::element &element;
		xablau::organizational_analysis::traversability traversability = xablau::organizational_analysis::traversability::closed;
		cv::Vec3b color{};
		cv::Vec3b island_color{};
		std::vector < cv::Point > contour{};
		std::vector < std::vector < cv::Point > > islands{};
		size_t hashAbsolutePosition{};
		size_t hashRelativePosition{};

		bool operator<(const element_instance &other) const
		{
			return this->identification < other.identification;
		}

		bool operator==(const element_instance &other) const
		{
			return this->identification == other.identification;
		}

		element_instance(
			const std::string &identification,
			const xablau::organizational_analysis::element &element = null_element,
			const cv::Vec3b &color = cv::Vec3b{},
			const cv::Vec3b &islandColor = cv::Vec3b{},
			std::vector < cv::Point > contour = {}) :

			identification(identification),
			element(element),
			traversability(element.traversability),
			color(color),
			island_color(islandColor),
			contour(std::move(contour))
		{
		}
	};

	class blueprint final
	{
	public:
		using task_type = typename organizational_analysis::activity::task;

		using dependencies_type = typename organizational_analysis::activity::tasks_type;

		using space_type =
			xablau::algebra::tensor_dense_dynamic <
				std::optional < std::reference_wrapper < const xablau::organizational_analysis::element_instance > >,
				xablau::algebra::tensor_rank < 2 >,
				xablau::algebra::tensor_contiguity < true > >;

		struct less_pair
		{
			[[nodiscard]] constexpr bool operator()(
				const std::pair < std::string, std::string > &pair1,
				const std::pair < std::string, std::string > &pair2) const
			{
				return std::minmax(pair1.first, pair1.second) < std::minmax(pair2.first, pair2.second);
			}
		};

		using element_instance_neighborhood_type =
			std::map <
				std::pair < std::string, std::string >,
				std::set < std::array < size_t, 2 > >,
				less_pair >;

	private:
		using space_abstraction_type =
			xablau::graph::digraph <
				xablau::graph::node < blueprint::task_type >,
				xablau::graph::graph_container_type < xablau::graph::graph_container_type_value::ordered >,
				xablau::graph::edge < float > >;

		bool _up_to_date{};
		std::set < xablau::organizational_analysis::element > _elements{};
		std::set < xablau::organizational_analysis::element_instance > _element_instances{};
		space_type _space{};
		float _meters_per_pixel{};
		cv::Mat _original_image{};

		// Based on https://cp-algorithms.com/string/string-hashing.html
		static std::pair < size_t, size_t > element_instance_deterministic_hash(const element_instance &elementInstance)
		{
			constexpr auto closestPointToReference =
				[] (const std::vector < cv::Point > &polygon, const cv::Point &reference) -> size_t
				{
					size_t index{};
					double distance = std::numeric_limits < double > ::max();
					cv::Point bestPoint(std::numeric_limits < int > ::max(), std::numeric_limits < int > ::max());

					for (size_t i = 0; i < polygon.size(); i++)
					{
						if (const double _distance = cv::norm(polygon[i] - reference);
							_distance < distance ||
							(_distance == distance &&
								((polygon[i].x < bestPoint.x) ||
								(polygon[i].x == bestPoint.x && polygon[i].y < bestPoint.y))))
						{
							distance = _distance;
							bestPoint = polygon[i];
							index = i;
						}
					}

					return index;
				};

			constexpr auto contourHash =
				[] (const size_t p,
					const size_t m,
					size_t hash,
					size_t pPow,
					const std::vector < cv::Point > &contour,
					const std::vector < std::vector < cv::Point > > &islands) -> size_t
				{
					const auto hashFunction =
						[&] (const auto pixelCoordinate)
						{
							hash = (hash + (pixelCoordinate + 1) * pPow) % m;
							pPow = (pPow * p) % m;
						};

					for (const auto &pixel : contour)
					{
						hashFunction(pixel.x);
						hashFunction(pixel.y);
					}

					for (const auto &island : islands)
					{
						for (const auto &pixel : island)
						{
							hashFunction(pixel.x);
							hashFunction(pixel.y);
						}
					}

					return hash;
				};

			const auto upperLeftCorner = cv::boundingRect(elementInstance.contour).tl();

			auto absoluteContour = elementInstance.contour;
			auto absoluteIslands = elementInstance.islands;
			auto relativeContour = elementInstance.contour;
			auto relativeIslands = elementInstance.islands;

			std::ranges::rotate(absoluteContour, absoluteContour.begin() + closestPointToReference(absoluteContour, cv::Point()));

			for (auto &island : absoluteIslands)
			{
				std::ranges::rotate(island, island.begin() + closestPointToReference(island, cv::Point()));
			}

			for (auto &pixel : relativeContour)
			{
				pixel.x -= upperLeftCorner.x;
				pixel.y -= upperLeftCorner.y;
			}

			std::ranges::rotate(relativeContour, relativeContour.begin() + closestPointToReference(relativeContour, upperLeftCorner));

			for (auto &island : relativeIslands)
			{
				for (auto &pixel : island)
				{
					pixel.x -= upperLeftCorner.x;
					pixel.y -= upperLeftCorner.y;
				}

				std::ranges::rotate(island, island.begin() + closestPointToReference(island, upperLeftCorner));
			}

			constexpr size_t p{63};
			constexpr size_t m{2891462833508853931};
			size_t hash = 0;
			size_t pPow = 1;

			for (const char character : elementInstance.element.identification)
			{
				hash = (hash + (character - 'a' + 1) * pPow) % m;
				pPow = (pPow * p) % m;
			}

			return
				std::make_pair(
					contourHash(p, m, hash, pPow, absoluteContour, absoluteIslands),
					contourHash(p, m, hash, pPow, relativeContour, relativeIslands));
		}

		const xablau::organizational_analysis::element &find_element(const cv::Vec3b &color) const
		{
			for (const auto &element : this->_elements)
			{
				const auto &[minDomain, maxDomain] = element.domain;

				if (color[0] >= minDomain[0] && color[0] <= maxDomain[0] &&
					color[1] >= minDomain[1] && color[1] <= maxDomain[1] &&
					color[2] >= minDomain[2] && color[2] <= maxDomain[2])
				{
					return element;
				}
			}

			return *(this->_elements.find("wall"));
		}

		void calculate_meters_per_pixel(const float referenceInMeters)
		{
			if (referenceInMeters <= float{})
			{
				throw std::domain_error(std::format("Reference in meters must be positive: {}", referenceInMeters));
			}

			cv::Mat image = this->_original_image.clone();

			image.forEach < cv::Vec3b > (
				[&] (cv::Vec3b &pixel, const int *position) -> void
				{
					static_cast < void > (position);

					const auto &element = this->find_element(pixel);

					if (element.identification == "reference")
					{
						pixel = xablau::organizational_analysis::floor_color;
					}

					else
					{
						pixel = xablau::organizational_analysis::wall_color;
					}
				});

			std::vector < std::vector < cv::Point > > contours;
			std::vector < cv::Vec4i > hierarchy;

			cv::cvtColor(image, image, cv::ColorConversionCodes::COLOR_BGR2GRAY);

			cv::findContours(
				image,
				contours,
				hierarchy,
				cv::RetrievalModes::RETR_LIST,
				cv::ContourApproximationModes::CHAIN_APPROX_NONE);

			if (contours.size() != 1)
			{
				if (contours.empty())
				{
					throw std::runtime_error("There is not a reference in the image.");
				}

				throw std::runtime_error("There are two or more references in the image.");
			}

			const auto &[minX, maxX] =
				std::minmax_element(
					contours.cbegin()->cbegin(),
					contours.cbegin()->cend(),
					[] (const cv::Point &point1, const cv::Point &point2) -> bool
					{
						return point1.x < point2.x;
					});

			const auto &[minY, maxY] =
				std::minmax_element(
					contours.cbegin()->cbegin(),
					contours.cbegin()->cend(),
					[] (const cv::Point &point1, const cv::Point &point2) -> bool
					{
						return point1.y < point2.y;
					});

			cv::fillPoly(this->_original_image, contours, xablau::organizational_analysis::external_color);

			if (maxX->x - minX->x > maxY->y - minY->y)
			{
				this->_meters_per_pixel = referenceInMeters / static_cast < float > (maxX->x - minX->x);
			}

			else
			{
				this->_meters_per_pixel = referenceInMeters / static_cast < float > (maxY->y - minY->y);
			}
		}

		void construct_element_instances()
		{
			size_t identification{};

			for (const auto &element : this->_elements)
			{
				cv::Mat image = this->_original_image.clone();

				image.forEach < cv::Vec3b > (
					[&] (cv::Vec3b &pixel, const int *position) -> void
					{
						static_cast < void > (position);

						const auto &candidateElement = find_element(pixel);

						if (candidateElement.identification != element.identification)
						{
							pixel = xablau::organizational_analysis::wall_color;
						}

						else
						{
							pixel = xablau::organizational_analysis::floor_color;
						}
					});

				std::vector < std::vector < cv::Point > > contours;
				std::vector < cv::Vec4i > hierarchy;

				cv::cvtColor(image, image, cv::ColorConversionCodes::COLOR_BGR2GRAY);

				if (element.identification != "wall")
				{
					cv::findContours(
						image,
						contours,
						hierarchy,
						cv::RetrievalModes::RETR_CCOMP,
						cv::ContourApproximationModes::CHAIN_APPROX_NONE);
				}

				else
				{
					cv::findContours(
						image,
						contours,
						hierarchy,
						cv::RetrievalModes::RETR_LIST,
						cv::ContourApproximationModes::CHAIN_APPROX_NONE);
				}

				if (contours.empty())
				{
					continue;
				}

				for (int i = 0; i != -1;)
				{
					auto &contour = contours[i];

					if (cv::contourArea(contour, true) > double{})
					{
						std::ranges::reverse(contour);
					}

					const auto &colorIdentification = this->_original_image.at < cv::Vec3b > (contour.at(0));

					element_instance instance(
						std::to_string(identification) + "__",
						element,
						colorIdentification,
						element.identification == "floor" ?
							xablau::organizational_analysis::floor_island_color :
							element.identification == "external" ?
								xablau::organizational_analysis::external_color :
								xablau::organizational_analysis::wall_color,
						std::move(contour));

					for (int j = hierarchy[i][2]; j != -1;)
					{
						if (cv::contourArea(contours[j], true) < double{})
						{
							std::ranges::reverse(contours[j]);
						}

						instance.islands.push_back(std::move(contours[j]));

						j = hierarchy[j][0];
					}

					identification++;

					i = hierarchy[i][0];

					std::tie(
						instance.hashAbsolutePosition,
						instance.hashRelativePosition) = blueprint::element_instance_deterministic_hash(instance);

					this->_element_instances.insert(std::move(instance));
				}
			}
		}

		void construct_space()
		{
			cv::Mat image(this->_original_image.rows, this->_original_image.cols, CV_8UC1, uchar{});

			this->_space.resize(
				static_cast < size_t > (this->_original_image.cols),
				static_cast < size_t > (this->_original_image.rows));

			for (const auto &elementInstance : this->_element_instances)
			{
				std::vector < std::vector < cv::Point > > contours(1, elementInstance.contour);

				cv::fillPoly(image, contours, 1);
				cv::fillPoly(image, elementInstance.islands, 0);
				cv::drawContours(image, elementInstance.islands, -1, 1);

				const auto rectangle = cv::boundingRect(elementInstance.contour);
				cv::Mat ROI(image, rectangle);

				ROI.forEach < uchar > (
					[&] (uchar &pixel, const int *position) -> void
					{
						if (pixel == 1)
						{
							this->_space(
								static_cast < size_t > (rectangle.x + position[1]),
								static_cast < size_t > (rectangle.y + position[0])) = elementInstance;

							pixel = 0;
						}
					});
			}

			this->_up_to_date = true;
		}

		float calculate_distance(const auto &path) const
		{
			if (path.size() <= 1)
			{
				return float{};
			}

			float distance{};
			const auto diagonal = std::sqrt(float{2});

			for (auto previous = path.cbegin(), next = ++(path.cbegin()); next != path.cend(); ++previous, ++next)
			{
				if ((*previous)[0] == (*next)[0] || (*previous)[1] == (*next)[1])
				{
					distance += float{1};
				}

				else
				{
					distance += diagonal;
				}
			}

			return distance * this->_meters_per_pixel;
		}

		static void assert_element_is_not_reserved(const std::string &identification)
		{
			if (identification == "wall" || identification == "floor_island" ||
				identification == "floor" || identification == "external" ||
				identification == "reference")
			{
				throw std::runtime_error("Element is a reserved element.");
			}
		}

	public:
		[[nodiscard]] const auto &elements() const
		{
			return this->_elements;
		}

		[[nodiscard]] const auto &element_instances() const
		{
			return this->_element_instances;
		}

		[[nodiscard]] const auto &space() const
		{
			return this->_space;
		}

		[[nodiscard]] const auto &image() const
		{
			return this->_original_image;
		}

		void read_image_and_detect_instances(const std::string &path, const float referenceInMeters)
		{
			this->_meters_per_pixel = 0.0f;

			this->_original_image = cv::imread(path, cv::ImreadModes::IMREAD_COLOR);
			this->calculate_meters_per_pixel(referenceInMeters);
			this->detect_instances();
		}

		void detect_instances()
		{
			if (this->_original_image.empty())
			{
				throw std::runtime_error("There is no blueprint image.");
			}

			this->_element_instances.clear();

			this->construct_element_instances();
			this->construct_space();
		}

		[[nodiscard]] element_instance_neighborhood_type element_instance_neighborhood() const
		{
			using CoordinateSetType = std::set < std::array < size_t, 2 > >;

			if (!this->_up_to_date)
			{
				throw std::runtime_error("\"blueprint\" is not updated.");
			}

			element_instance_neighborhood_type neighborhood{};

			for (size_t i = 0; i < this->_space.rows(); i++)
			{
				for (size_t j = 0; j < this->_space.columns(); j++)
				{
					const auto kernel = this->_space.kernel < xablau::algebra::tensor_fixed_dimensionalities < 3, 3 > > (i, j);
					const auto &center = kernel(1, 1).value().get();

					if (const auto neighbor = kernel(1, 2);
						neighbor.has_value() && center.identification != neighbor.value().get().identification)
					{
						auto &setOfCoordinates =
							neighborhood.emplace(
								std::make_pair(center.identification, neighbor.value().get().identification),
								CoordinateSetType()).first->second;

						setOfCoordinates.emplace(std::to_array({ i, j }));
						setOfCoordinates.emplace(std::to_array({ i, j + 1 }));
					}

					for (size_t k = 0; k < 3; k++)
					{
						if (const auto neighbor = kernel(2, k);
							neighbor.has_value() && center.identification != neighbor.value().get().identification)
						{
							auto &setOfCoordinates =
								neighborhood.emplace(
									std::make_pair(center.identification, neighbor.value().get().identification),
									CoordinateSetType()).first->second;

							setOfCoordinates.emplace(std::to_array({ i, j }));
							setOfCoordinates.emplace(std::to_array({ i + 1, j + k - 1 }));
						}
					}
				}
			}

			return neighborhood;
		}

		[[nodiscard]] auto trace_path(const dependencies_type &dependencies) const
		{
			if (!this->_up_to_date)
			{
				throw std::runtime_error("\"blueprint\" is not updated.");
			}

			using NaryNode =
				xablau::graph::nary_tree_node <
					blueprint::task_type,
					xablau::graph::nary_tree_node_container < xablau::graph::nary_tree_node_container_value::vector > >;

			using NaryTree = xablau::graph::nary_tree < NaryNode >;

			if (const auto components = dependencies.Tarjan_strongly_connected_components();
				components.size() != dependencies.node_count())
			{
				throw std::runtime_error("There is a cyclic dependency on the task list.");
			}

			const auto startTask = dependencies.sink_nodes();

			if (startTask.size() != 1)
			{
				throw std::runtime_error("There is more than one starting task.");
			}

			constexpr auto blockedPath =
				[] (const std::optional < std::reference_wrapper < const xablau::organizational_analysis::element_instance > > &cell) -> bool
				{
					return !cell.has_value() || cell.value().get().traversability != traversability::open;
				};

			for (const auto &[node, _]: dependencies.container())
			{
				if (node.value.coordinates[0] >= this->_space.dimensionalities()[0] ||
					node.value.coordinates[1] >= this->_space.dimensionalities()[1])
				{
					throw
						std::runtime_error(
							std::format(
								"Coordinates ({}, {}) are out of bounds: ({}, {}).",
								node.value.coordinates[0],
								node.value.coordinates[1],
								this->_space.dimensionalities()[0],
								this->_space.dimensionalities()[1]));
				}

				if (blockedPath(this->_space(node.value.coordinates)))
				{
					throw
						std::runtime_error(
							std::format(
								"Coordinates ({}, {}) from task \"{}\" are in a blocked path.",
								node.value.coordinates[0],
								node.value.coordinates[1],
								node.value.identification));
				}

				if (dependencies.edges(node, node).has_value())
				{
					throw
						std::runtime_error(
							std::format(
								"Task \"{}\" is depending on itself.",
								node.value.identification));
				}
			}

			constexpr auto taskPairing =
				[] (const std::pair < blueprint::task_type, blueprint::task_type > &pair1,
					const std::pair < blueprint::task_type, blueprint::task_type > &pair2) -> bool
				{
					const auto &[min1, max1] = std::minmax(pair1.first, pair1.second);
					const auto &[min2, max2] = std::minmax(pair2.first, pair2.second);

					return (min1 < min2 ? true : (!(min2 < min1) ? max1 < max2 : false));
				};

			std::map <
				std::pair < blueprint::task_type, blueprint::task_type >,
				std::pair < std::vector < std::array < size_t, space_type::rank() > >, float >,
				decltype(taskPairing) > calculatedPaths(taskPairing);

			auto transposedDependencies = dependencies.transpose();

			const auto fullTree =
				transposedDependencies.template generate_tree <
					NaryTree,
					xablau::graph::tree_generation_modes::breadth_first_search > (*startTask.cbegin());

			std::set < blueprint::task_type > fullTreeSet;

			for (const auto &node : fullTree)
			{
				fullTreeSet.insert(node);
			}

			std::map < blueprint::task_type, std::set < blueprint::task_type > > treeSets;

			for (const auto &[node, _] : dependencies.container())
			{
				const auto tree =
					dependencies.template generate_tree <
						NaryTree,
						xablau::graph::tree_generation_modes::breadth_first_search > (node);

				for (const auto &treeNode : tree)
				{
					treeSets[node.value].insert(treeNode);
				}
			}

			for (const auto &[node, connections] : dependencies.container())
			{
				std::set < blueprint::task_type > destinationsSet;
				std::set < blueprint::task_type > auxDestinationsSet;
				std::set < blueprint::task_type > transposedTreeSet;

				const auto transposedTree =
					transposedDependencies.template generate_tree <
						NaryTree,
						xablau::graph::tree_generation_modes::breadth_first_search > (node);

				for (const auto &transposedTreeNode : transposedTree)
				{
					transposedTreeSet.insert(transposedTreeNode);
				}

				std::set_difference(
					fullTreeSet.cbegin(),
					fullTreeSet.cend(),
					treeSets[node.value].cbegin(),
					treeSets[node.value].cend(),
					std::inserter(auxDestinationsSet, auxDestinationsSet.begin()));

				std::set_difference(
					auxDestinationsSet.cbegin(),
					auxDestinationsSet.cend(),
					transposedTreeSet.cbegin(),
					transposedTreeSet.cend(),
					std::inserter(destinationsSet, destinationsSet.begin()));

				for (const auto &[connection1, _1] : connections)
				{
					bool validConnection = true;

					for (const auto &[connection2, _2] : connections)
					{
						if (connection1 == connection2)
						{
							continue;
						}

						if (treeSets[connection2.value].contains(connection1.value))
						{
							validConnection = false;

							break;
						}
					}

					if (validConnection)
					{
						destinationsSet.insert(connection1.value);
					}
				}

				for (const auto &destination : destinationsSet)
				{
					if (calculatedPaths.contains(std::make_pair(destination, node.value)))
					{
						continue;
					}

					auto path =
						xablau::graph::algorithm::A_star(
							this->_space,
							destination.coordinates,
							node.value.coordinates,
							blockedPath);

					if (path.empty())
					{
						throw std::runtime_error(
							std::format(
								"Could not find a path between tasks \"{}\" and \"{}\".",
								destination.identification,
								node.value.identification));
					}

					auto distance = this->calculate_distance(path);

					if (distance == float{})
					{
						distance = std::numeric_limits < float > ::min();
					}

					calculatedPaths.insert(
						std::make_pair(
							std::make_pair(destination, node.value),
							std::make_pair(std::move(path), distance)));
				}
			}

			space_abstraction_type spaceAbstraction{};

			for (const auto &[nodes, pathAndDistance] : calculatedPaths)
			{
				const auto &[node1, node2] = nodes;

				if (!dependencies.contains(node1, node2))
				{
					spaceAbstraction.insert(node1, node2, pathAndDistance.second);
				}

				if (!dependencies.contains(node2, node1))
				{
					spaceAbstraction.insert(node2, node1, pathAndDistance.second);
				}
			}

			std::vector < xablau::graph::node < blueprint::task_type > > _tasks{};
			float distance{};

			if (dependencies.edge_count() == 0)
			{
				std::tie(_tasks, distance) = spaceAbstraction.traveling_salesman_problem(*(startTask.cbegin()));
			}

			else
			{
				std::tie(_tasks, distance) = spaceAbstraction.traveling_salesman_problem(*(startTask.cbegin()), dependencies);
			}

			std::vector < std::reference_wrapper < const blueprint::task_type > > tasks;
			std::vector < std::reference_wrapper < const element_instance > > instances;
			std::vector < std::array < size_t, 2 > > fullPath;

			tasks.reserve(_tasks.size());

			for (const auto &node : _tasks)
			{
				tasks.push_back(node.value);
			}

			instances.push_back(this->_space(_tasks.cbegin()->value.coordinates).value());

			for (auto previous = tasks.begin(), next = ++(tasks.begin());
				next != tasks.end();
				++previous, ++next)
			{
				const auto &path = calculatedPaths.at(std::make_pair(previous->get(), next->get())).first;

				size_t i = fullPath.size();

				if (next->get().coordinates == *(path.cbegin()))
				{
					std::copy(path.crbegin(), path.crend(), std::back_inserter(fullPath));
				}

				else
				{
					std::copy(path.cbegin(), path.cend(), std::back_inserter(fullPath));
				}

				while (i < fullPath.size())
				{
					const auto &instanceCandidate = this->_space(fullPath[i]).value().get();

					if (instances.crbegin()->get() != instanceCandidate)
					{
						instances.push_back(instanceCandidate);
					}

					i++;
				}
			}

			std::vector < std::string > taskIdentifications;
			std::vector < std::string > instanceIdentifications;

			taskIdentifications.reserve(tasks.size());
			instanceIdentifications.reserve(instances.size());

			std::transform(
				tasks.cbegin(),
				tasks.cend(),
				std::back_inserter(taskIdentifications),
				[] (const auto &task)
				{
					return task.get().identification;
				});

			std::transform(
				instances.cbegin(),
				instances.cend(),
				std::back_inserter(instanceIdentifications),
				[] (const auto &instance)
				{
					return instance.get().identification;
				});

			return std::make_tuple(std::move(taskIdentifications), std::move(instanceIdentifications), std::move(fullPath), distance);
		}

		[[nodiscard]] auto absolute_coordinates_from_element_instance_coordinates(
			const std::string &identification,
			const int cameraDistanceLevel,
			const size_t x,
			const size_t y) const
		{
			cv::Point selectedPoint(static_cast < int > (x), static_cast < int > (y));

			if (cameraDistanceLevel < 0 || cameraDistanceLevel > 100)
			{
				throw std::runtime_error("\"cameraDistanceLevel\" must be [0, 100].");
			}

			const auto iterator = this->_element_instances.find(identification);

			if (iterator == this->_element_instances.cend())
			{
				throw std::runtime_error(std::format("Could not find element instance \"{}\".", identification));
			}

			const auto &elementInstance = *iterator;
			const auto rectangle = cv::boundingRect(elementInstance.contour);

			const int offset = (std::max(rectangle.width, rectangle.height) * static_cast < int > (cameraDistanceLevel + 3)) / 2;

			int startX = rectangle.x - offset;
			int startY = rectangle.y - offset;

			startX = startX < 0 ? 0 : startX;
			startY = startY < 0 ? 0 : startY;

			std::vector < cv::Point > contour = elementInstance.contour;

			std::for_each(contour.begin(), contour.end(),
				[&] (cv::Point &point) -> void
				{
					point.x -= startX;
					point.y -= startY;
				});

			if (cv::pointPolygonTest(contour, selectedPoint, false) == -1)
			{
				throw
					std::runtime_error(
						std::format(
							"Point at ({}, {}) is not inside element instance \"{}\".",
							selectedPoint.x,
							selectedPoint.y,
							identification));
			}

			if (!elementInstance.islands.empty())
			{
				auto islands = elementInstance.islands;

				std::for_each(islands.begin(), islands.end(),
					[&] (std::vector < cv::Point > &island) -> void
					{
						std::for_each(island.begin(), island.end(),
							[&] (cv::Point &point) -> void
							{
								point.x -= startX;
								point.y -= startY;
							});
					});

				for (const auto &island : islands)
				{
					if (cv::pointPolygonTest(island, selectedPoint, false) != -1)
					{
						throw
							std::runtime_error(
								std::format(
									"Point at ({}, {}) is an invalid position of element instance \"{}\".",
									selectedPoint.x,
									selectedPoint.y,
									identification));
					}
				}
			}

			return std::make_pair(x + static_cast < size_t > (startX), y + static_cast < size_t > (startY));
		}

		[[nodiscard]] std::string element_instance_from_absolute_coordinates(
			const size_t x,
			const size_t y) const
		{
			cv::Point selectedPoint(static_cast < int > (x), static_cast < int > (y));

			if (selectedPoint.x >= this->_original_image.cols ||
				selectedPoint.y >= this->_original_image.rows)
			{
				throw
					std::runtime_error(
						std::format(
							"Point at ({}, {}) is not inside image dimensions ({}, {}).",
							selectedPoint.x,
							selectedPoint.y,
							this->_original_image.cols,
							this->_original_image.rows));
			}

			for (const auto &elementInstance : this->_element_instances)
			{
				if (cv::pointPolygonTest(elementInstance.contour, selectedPoint, false) != -1)
				{
					return elementInstance.identification;
				}
			}

			throw
				std::runtime_error(
					std::format(
						"There is not an element instance for point at ({}, {}).",
						selectedPoint.x,
						selectedPoint.y));
		}

		void write_image(const std::string &path) const
		{
			cv::imwrite(path, this->_original_image);
		}

		void write_contours(const std::string &path) const
		{
			cv::Mat image(this->_original_image.rows, this->_original_image.cols, CV_8UC3, xablau::organizational_analysis::floor_color);

			for (const auto &elementInstance : this->_element_instances)
			{
				std::vector < std::vector < cv::Point > > contours(1, elementInstance.contour);

				cv::drawContours(
					image,
					contours,
					0,
					elementInstance.color == xablau::organizational_analysis::floor_color ?
						xablau::organizational_analysis::reference_color :
						elementInstance.color);

				cv::drawContours(image, elementInstance.islands, -1, elementInstance.island_color);
			}

			cv::imwrite(path, image);
		}

		void write_element_instance(
			const std::string &directory,
			const std::string &identification,
			const int cameraDistanceLevel) const
		{
			if (cameraDistanceLevel < 0 || cameraDistanceLevel > 100)
			{
				throw std::runtime_error("\"cameraDistanceLevel\" must be [0, 100].");
			}

			if (!std::filesystem::exists(directory) && !std::filesystem::create_directory(directory))
			{
				throw std::runtime_error(std::format("Directory \"{}\" does not exist and could not be created.", directory));
			}

			const auto iterator = this->_element_instances.find(identification);

			if (iterator == this->_element_instances.cend())
			{
				throw std::runtime_error(std::format("Could not find element instance \"{}\".", identification));
			}

			const auto &elementInstance = *iterator;
			const auto elementDirectory = directory + "/" + elementInstance.element.identification + "/";

			if (!std::filesystem::exists(elementDirectory) && !std::filesystem::create_directory(elementDirectory))
			{
				throw std::runtime_error(std::format("Directory \"{}\" does not exist and could not be created.", elementDirectory));
			}

			const auto rectangle = cv::boundingRect(elementInstance.contour);

			const int offset = (std::max(rectangle.width, rectangle.height) * static_cast < int > (cameraDistanceLevel + 3)) / 2;

			int startX = rectangle.x - offset;
			int startY = rectangle.y - offset;

			int endX = rectangle.x + rectangle.width + offset;
			int endY = rectangle.y + rectangle.height + offset;

			startX = startX < 0 ? 0 : startX;
			startY = startY < 0 ? 0 : startY;

			endX = endX >= this->_original_image.cols ? this->_original_image.cols - 1 : endX;
			endY = endY >= this->_original_image.rows ? this->_original_image.rows - 1 : endY;

			cv::Mat element =
				this->_original_image.
					colRange(startX, endX).
					rowRange(startY, endY).clone();

			std::vector < std::vector < cv::Point > > contours(1, elementInstance.contour);

			std::for_each(contours[0].begin(), contours[0].end(),
				[&] (cv::Point &point) -> void
				{
					point.x -= startX;
					point.y -= startY;
				});

			cv::fillPoly(element, contours, xablau::organizational_analysis::reference_color);

			if (!elementInstance.islands.empty())
			{
				auto islands = elementInstance.islands;

				std::for_each(islands.begin(), islands.end(),
					[&] (std::vector < cv::Point > &island) -> void
					{
						std::for_each(island.begin(), island.end(),
							[&] (cv::Point &point) -> void
							{
								point.x -= startX;
								point.y -= startY;
							});
					});

				cv::fillPoly(element, islands, xablau::organizational_analysis::floor_island_color);
			}

			cv::imwrite(
				elementDirectory + elementInstance.identification + std::to_string(cameraDistanceLevel) + ".png",
				element);
		}

		void write_element_instances(
			const std::string &directory,
			const int cameraDistanceLevel,
			const std::vector < std::string > &inclusion = { "floor" }) const
		{
			if (!std::filesystem::exists(directory) && !std::filesystem::create_directory(directory))
			{
				throw std::runtime_error(std::format("Directory \"{}\" could not be created.", directory));
			}

			for (const auto &elementInstance : this->_element_instances)
			{
				if (!inclusion.empty() &&
					std::ranges::find(inclusion, elementInstance.element.identification) == inclusion.cend())
				{
					continue;
				}

				this->write_element_instance(directory, elementInstance.identification, cameraDistanceLevel);
			}
		}

		void insert_element(
			const std::string &identification,
			const std::array < unsigned char, 3 > &minDomainRGB,
			const std::array < unsigned char, 3 > &maxDomainRGB,
			const traversability state)
		{
			cv::Vec3b minDomainCV(minDomainRGB[2], minDomainRGB[1], minDomainRGB[0]);
			cv::Vec3b maxDomainCV(maxDomainRGB[2], maxDomainRGB[1], maxDomainRGB[0]);

			if (this->_elements.contains(identification))
			{
				throw std::runtime_error(std::format("Element \"{}\" already exists.", identification));
			}

			for (const auto &element : this->_elements)
			{
				const auto &[_minDomain, _maxDomain] = element.domain;

				const auto &min0 = std::max(minDomainCV[0], _minDomain[0]);
				const auto &max0 = std::min(maxDomainCV[0], _maxDomain[0]);
				const auto &min1 = std::max(minDomainCV[1], _minDomain[1]);
				const auto &max1 = std::min(maxDomainCV[1], _maxDomain[1]);
				const auto &min2 = std::max(minDomainCV[2], _minDomain[2]);
				const auto &max2 = std::min(maxDomainCV[2], _maxDomain[2]);

				if (max0 >= min0 && max1 >= min1 && max2 >= min2)
				{
					throw
						std::runtime_error(
							std::format(
								"There is a color intersection between \"{}\" and \"{}\".",
								identification,
								element.identification));
				}
			}

			this->_elements.insert({ identification, { std::make_pair(std::move(minDomainCV), std::move(maxDomainCV)) }, state });
			this->_element_instances.clear();
			this->_space.clear();
			this->_up_to_date = false;
		}

		void rename_element_instance(
			const std::string &oldIdentification,
			const std::string &newIdentification)
		{
			if (!this->_element_instances.contains(oldIdentification))
			{
				throw std::runtime_error(std::format("Element \"{}\" does not exist.", oldIdentification));
			}

			if (oldIdentification == newIdentification)
			{
				return;
			}

			if (this->_element_instances.contains(newIdentification))
			{
				throw std::runtime_error(std::format("Element \"{}\" already exists.", newIdentification));
			}

			auto node = this->_element_instances.extract(oldIdentification);

			node.value().identification = newIdentification;

			this->_element_instances.insert(std::move(node));
		}

		void rename_element_instance_hash(
			const bool absolute,
			const size_t hash,
			const std::string &newIdentification)
		{
			std::vector < std::reference_wrapper < const element_instance > > instancesFound;

			for (const auto &elementInstance : this->_element_instances)
			{
				if (absolute && elementInstance.hashAbsolutePosition == hash ||
					!absolute && elementInstance.hashRelativePosition == hash)
				{
					instancesFound.emplace_back(elementInstance);
				}
			}

			if (instancesFound.empty())
			{
				throw std::runtime_error("There is no element for the given hash.");
			}

			if (instancesFound.size() >= 2)
			{
				std::string message = "Multiples instances were found for the given hash: ";

				for (const auto &elementInstance : instancesFound)
				{
					message += std::format("\"{}\" ", elementInstance.get().identification);
				}

				throw std::runtime_error(message);
			}

			this->rename_element_instance(instancesFound.cbegin()->get().identification, newIdentification);
		}

		std::pair < size_t, size_t > element_instance_hash(const std::string &identification) const
		{
			const auto iterator = this->_element_instances.find(identification);

			if (iterator == this->_element_instances.cend())
			{
				throw std::runtime_error(std::format("Element instance \"{}\" does not exist.", identification));
			}

			return std::make_pair(iterator->hashAbsolutePosition, iterator->hashRelativePosition);
		}

		void element_traversability(const std::string &identification, const traversability state)
		{
			auto node = this->_elements.extract(identification);

			if (node.empty())
			{
				throw std::runtime_error(std::format("Element \"{}\" does not exist.", identification));
			}

			node.value().traversability = state;

			this->_elements.insert(std::move(node));

			this->_up_to_date = false;
		}

		void element_instance_traversability(const std::string &identification, const traversability state)
		{
			auto node = this->_element_instances.extract(identification);

			if (node.empty())
			{
				throw std::runtime_error(std::format("Element instance \"{}\" does not exist.", identification));
			}

			node.value().traversability = state;

			this->_element_instances.insert(std::move(node));

			this->_up_to_date = false;
		}

		void erase_element(const std::string &identification)
		{
			blueprint::assert_element_is_not_reserved(identification);

			const auto iterator = this->_elements.find(identification);

			if (iterator == this->_elements.cend())
			{
				throw std::runtime_error(std::format("Element \"{}\" does not exist.", identification));
			}

			this->_element_instances.clear();
			this->_elements.erase(iterator);
			this->_space.clear();
			this->_up_to_date = false;
		}

		void clear() noexcept
		{
			this->_up_to_date = false;
			this->_elements.clear();
			this->_element_instances.clear();
			this->_meters_per_pixel = 0.0f;
			this->_space.clear();
			this->_original_image.release();

			this->_elements.insert({ "wall", { std::make_pair(xablau::organizational_analysis::wall_color, xablau::organizational_analysis::wall_color) }, traversability::closed });
			this->_elements.insert({ "floor_island", { std::make_pair(xablau::organizational_analysis::floor_island_color, xablau::organizational_analysis::floor_island_color) }, traversability::closed });
			this->_elements.insert({ "floor", { std::make_pair(xablau::organizational_analysis::floor_color, xablau::organizational_analysis::floor_color) }, traversability::open });
			this->_elements.insert({ "external", { std::make_pair(xablau::organizational_analysis::external_color, xablau::organizational_analysis::external_color) }, traversability::closed });
			this->_elements.insert({ "reference", { std::make_pair(xablau::organizational_analysis::reference_color, xablau::organizational_analysis::reference_color) }, traversability::open });
		}

		[[nodiscard]] std::pair < std::array < unsigned char, 3 >, std::array < unsigned char, 3 > > domain(const std::string &identification) const
		{
			const auto iterator = this->_elements.find(identification);

			if (iterator == this->_elements.cend())
			{
				throw std::runtime_error(std::format("Could not find element \"{}\".", identification));
			}

			std::pair < std::array < unsigned char, 3 >, std::array < unsigned char, 3 > > result{};

			std::array < unsigned char, 3 > &minDomain = result.first;
			std::array < unsigned char, 3 > &maxDomain = result.second;

			const auto &minDomainCV = iterator->domain.first;
			const auto &maxDomainCV = iterator->domain.second;

			minDomain[0] = minDomainCV[2];
			minDomain[1] = minDomainCV[1];
			minDomain[2] = minDomainCV[0];

			maxDomain[0] = maxDomainCV[2];
			maxDomain[1] = maxDomainCV[1];
			maxDomain[2] = maxDomainCV[0];

			return result;
		}

		[[nodiscard]] traversability element_traversability(const std::string &identification) const
		{
			const auto iterator = this->_elements.find(identification);

			if (iterator == this->_elements.cend())
			{
				throw std::runtime_error(std::format("Could not find element \"{}\".", identification));
			}

			return iterator->traversability;
		}

		[[nodiscard]] traversability element_instance_traversability(const std::string &identification) const
		{
			const auto iterator = this->_element_instances.find(identification);

			if (iterator == this->_element_instances.cend())
			{
				throw std::runtime_error(std::format("Could not find element instance \"{}\".", identification));
			}

			return iterator->traversability;
		}

		[[nodiscard]] float meters_per_pixel() const
		{
			return this->_meters_per_pixel;
		}

		[[nodiscard]] bool up_to_date() const
		{
			return this->_up_to_date;
		}

		blueprint()
		{
			this->_elements.insert({ "wall", { std::make_pair(xablau::organizational_analysis::wall_color, xablau::organizational_analysis::wall_color) }, traversability::closed });
			this->_elements.insert({ "floor_island", { std::make_pair(xablau::organizational_analysis::floor_island_color, xablau::organizational_analysis::floor_island_color) }, traversability::closed });
			this->_elements.insert({ "floor", { std::make_pair(xablau::organizational_analysis::floor_color, xablau::organizational_analysis::floor_color) }, traversability::open });
			this->_elements.insert({ "external", { std::make_pair(xablau::organizational_analysis::external_color, xablau::organizational_analysis::external_color) }, traversability::closed });
			this->_elements.insert({ "reference", { std::make_pair(xablau::organizational_analysis::reference_color, xablau::organizational_analysis::reference_color) }, traversability::open });
		}
	};
}