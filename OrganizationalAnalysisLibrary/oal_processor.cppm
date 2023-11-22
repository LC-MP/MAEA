export module xablau.organizational_analysis_c_sharp;

export import <cstdint>;
export import <fstream>;

export import xablau.organizational_analysis;

using ResizeContainer = void(*)(const size_t size);
using InsertStringIntoPosition1 = void(*)(const char *string, const size_t i);
using InsertPairOfStringAndSizeT = void(*)(const char *string, const size_t i);
using InsertSizeTInContainer = void(*)(const size_t value);
using InsertStringInContainer = void(*)(const char *string);
using InsertPairOfSizeTInContainer = void(*)(const size_t value1, const size_t value2);
using ResizeMatrix = void(*)(const size_t rows, const size_t columns);
using InsertFloatIntoPosition2 = void(*)(const float value, const size_t i, const size_t j);
using CopyNativeStringToManagedString = void(*)(const char *string);
using StringFromVector = const char *(*)(const size_t i);
using InsertMappedPairOfSizeTAndCoordinates = void(*)(const char *key1, const char *key2, const size_t x, const size_t y);

extern "C"
{
	_declspec(dllexport) uintptr_t construct()
	{
		return
			reinterpret_cast < uintptr_t > (
				new xablau::organizational_analysis::processor < true > ());
	}

	_declspec(dllexport) void destroy(uintptr_t address)
	{
		delete reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);
	}

	_declspec(dllexport) const char *indirectly_related_degree(
		const uintptr_t address,
		const float degree)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		processor->indirectly_related_degree(degree);

		return nullptr;
	}

	_declspec(dllexport) const char *related_degree(
		const uintptr_t address,
		const float degree)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		processor->related_degree(degree);

		return nullptr;
	}

	_declspec(dllexport) const char *directly_related_degree(
		const uintptr_t address,
		const float degree)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		processor->directly_related_degree(degree);

		return nullptr;
	}

	_declspec(dllexport) const char *insert_or_assign_agent(
		const uintptr_t address,
		const char *agent,
		const char *role)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->insert_or_assign_agent(agent, role);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *erase_agent(
		uintptr_t address,
		const char *agent)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->erase_agent(agent);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *insert_agent_group(
		const uintptr_t address,
		const char *agent,
		const char *group)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->insert_agent_group(agent, group);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *erase_agent_group(
		uintptr_t address,
		const char *agent,
		const char *group)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->erase_agent_group(agent, group);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *insert_or_edit_activity(
		uintptr_t address,
		const char *activity,
		const char *description)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->insert_or_edit_activity(activity, description);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *erase_activity(
		uintptr_t address,
		const char *activity)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->erase_activity(activity);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *insert_activity_group(
		const uintptr_t address,
		const char *activity,
		const char *group)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->insert_activity_group(activity, group);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *erase_activity_group(
		uintptr_t address,
		const char *activity,
		const char *group)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->erase_activity_group(activity, group);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *insert_task(
		uintptr_t address,
		const char *activity,
		const char *task_identification,
		const char *task_name,
		const float degree,
		const size_t x,
		const size_t y)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->insert_task(activity, task_identification, task_name, degree, std::to_array({ x, y }));
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *insert_task_dependency(
		uintptr_t address,
		const char *activity,
		const char *task_dependent,
		const char *task_dependency)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->insert_task_dependency(activity, task_dependent, task_dependency);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *erase_task(
		uintptr_t address,
		const char *activity,
		const char *task)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->erase_task(activity, task);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *erase_task_dependency(
		uintptr_t address,
		const char *activity,
		const char *task_dependent,
		const char *task_dependency)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->erase_task_dependency(activity, task_dependent, task_dependency);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *insert_agent_in_charge_of_activity(
		uintptr_t address,
		const char *agent,
		const char *activity)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->insert_agent_in_charge_of_activity(agent, activity);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *erase_agent_in_charge_of_activity(
		uintptr_t address,
		const char *agent,
		const char *activity)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->erase_agent_in_charge_of_activity(agent, activity);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *insert_activity_dependency(
		uintptr_t address,
		const char *dependent,
		const char *dependency)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->insert_activity_dependency(dependent, dependency);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *erase_activity_dependency(
		uintptr_t address,
		const char *dependent,
		const char *dependency)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->erase_activity_dependency(dependent, dependency);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *insert_or_edit_component(
		uintptr_t address,
		const char *component,
		const char *description)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->insert_or_edit_component(component, description);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *erase_component(
		uintptr_t address,
		const char *component)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->erase_component(component);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *insert_component_group(
		const uintptr_t address,
		const char *component,
		const char *group)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->insert_component_group(component, group);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *erase_component_group(
		uintptr_t address,
		const char *component,
		const char *group)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->erase_component_group(component, group);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *insert_component_interface(
		uintptr_t address,
		const char *component1,
		const char *component2)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->insert_component_interface(component1, component2);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *erase_component_interface(
		uintptr_t address,
		const char *component1,
		const char *component2)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->erase_component_interface(component1, component2);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *insert_or_assign_affiliation(
		uintptr_t address,
		const char *activity,
		const char *component,
		const float degree)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->insert_or_assign_affiliation(activity, component, degree);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *erase_affiliation(
		uintptr_t address,
		const char *activity,
		const char *component)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->erase_affiliation(activity, component);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) void clear(uintptr_t address)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		processor->clear();
	}

	_declspec(dllexport) const char *identify_parallelizations(
		uintptr_t address,
		ResizeContainer resizer,
		InsertStringIntoPosition1 inserter)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			const auto parallelizations = processor->identify_parallelizations();

			resizer(parallelizations.size());

			for (size_t i = 0; i < parallelizations.size(); i++)
			{
				for (const auto &activity : parallelizations[i])
				{
					inserter(activity.c_str(), i);
				}
			}
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *identify_priorities(
		uintptr_t address,
		InsertPairOfStringAndSizeT inserter)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			const auto priorities = processor->identify_priorities();

			for (const auto &[activity, priority] : priorities)
			{
				inserter(activity.c_str(), priority);
			}
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *components_without_agents_in_charge(
		uintptr_t address,
		InsertStringInContainer inserter)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			const auto componentsWithoutAgents = processor->components_without_agents_in_charge();

			for (const auto &componentWithoutAgents : componentsWithoutAgents)
			{
				inserter(componentWithoutAgents.c_str());
			}
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *activities_without_agents_in_charge(
		uintptr_t address,
		InsertStringInContainer inserter)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			const auto componentsWithoutAgents = processor->activities_without_agents_in_charge();

			for (const auto &componentWithoutAgents : componentsWithoutAgents)
			{
				inserter(componentWithoutAgents.c_str());
			}
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *minimum_relation_degree_for_agents_in_charge_of_components(
		uintptr_t address,
		float degree)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->minimum_relation_degree_for_agents_in_charge_of_components(degree);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *agent_role(
		uintptr_t address,
		const char *agent,
		CopyNativeStringToManagedString copier)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			copier(processor->agent_role(agent).c_str());
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *activity_name(
		uintptr_t address,
		const char *activity,
		CopyNativeStringToManagedString copier)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			copier(processor->activity_name(activity).c_str());
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *component_name(
		uintptr_t address,
		const char *component,
		CopyNativeStringToManagedString copier)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			copier(processor->component_name(component).c_str());
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *compare_activities_and_organization(uintptr_t address)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->compare_activities_and_organization();
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *compare_components_and_organization(
		uintptr_t address,
		float minimumRelationDegreeForAgentsInChargeOfComponents)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->compare_components_and_organization(minimumRelationDegreeForAgentsInChargeOfComponents);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *activities_dependencies_matrix(
		uintptr_t address,
		ResizeMatrix resizer,
		InsertFloatIntoPosition2 inserter)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			const auto &activities_dependencies_matrix = processor->activities_dependencies_matrix();

			resizer(activities_dependencies_matrix.rows(), activities_dependencies_matrix.columns());

			for (size_t i = 0; i < activities_dependencies_matrix.rows(); i++)
			{
				for (size_t j = 0; j < activities_dependencies_matrix.columns(); j++)
				{
					inserter(activities_dependencies_matrix(i, j), i, j);
				}
			}
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *components_interfaces_matrix(
		uintptr_t address,
		ResizeMatrix resizer,
		InsertFloatIntoPosition2 inserter)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			const auto &components_interfaces_matrix = processor->components_interfaces_matrix();

			resizer(components_interfaces_matrix.rows(), components_interfaces_matrix.columns());

			for (size_t i = 0; i < components_interfaces_matrix.rows(); i++)
			{
				for (size_t j = 0; j < components_interfaces_matrix.columns(); j++)
				{
					inserter(components_interfaces_matrix(i, j), i, j);
				}
			}
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *weak_affiliations_matrix(
		uintptr_t address,
		ResizeMatrix resizer,
		InsertFloatIntoPosition2 inserter)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			const auto &affiliations_matrix = processor->weak_affiliations_matrix();

			resizer(affiliations_matrix.rows(), affiliations_matrix.columns());

			for (size_t i = 0; i < affiliations_matrix.rows(); i++)
			{
				for (size_t j = 0; j < affiliations_matrix.columns(); j++)
				{
					inserter(affiliations_matrix(i, j), i, j);
				}
			}
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *strong_affiliations_matrix(
		uintptr_t address,
		ResizeMatrix resizer,
		InsertFloatIntoPosition2 inserter)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			const auto &affiliations_matrix = processor->strong_affiliations_matrix();

			resizer(affiliations_matrix.rows(), affiliations_matrix.columns());

			for (size_t i = 0; i < affiliations_matrix.rows(); i++)
			{
				for (size_t j = 0; j < affiliations_matrix.columns(); j++)
				{
					inserter(affiliations_matrix(i, j), i, j);
				}
			}
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *total_affiliations_matrix(
		uintptr_t address,
		ResizeMatrix resizer,
		InsertFloatIntoPosition2 inserter)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			const auto &affiliations_matrix = processor->total_affiliations_matrix();

			resizer(affiliations_matrix.rows(), affiliations_matrix.columns());

			for (size_t i = 0; i < affiliations_matrix.rows(); i++)
			{
				for (size_t j = 0; j < affiliations_matrix.columns(); j++)
				{
					inserter(affiliations_matrix(i, j), i, j);
				}
			}
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *comparative_matrix_without_redundancies(
		uintptr_t address,
		ResizeMatrix resizer,
		InsertFloatIntoPosition2 inserter)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			const auto &comparative_matrix_without_redundancies = processor->comparative_matrix_without_redundancies();

			resizer(comparative_matrix_without_redundancies.rows(), comparative_matrix_without_redundancies.columns());

			for (size_t i = 0; i < comparative_matrix_without_redundancies.rows(); i++)
			{
				for (size_t j = 0; j < comparative_matrix_without_redundancies.columns(); j++)
				{
					inserter(comparative_matrix_without_redundancies(i, j), i, j);
				}
			}
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *comparative_matrix_with_redundancies(
		uintptr_t address,
		ResizeMatrix resizer,
		InsertFloatIntoPosition2 inserter)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			const auto &comparative_matrix_with_redundancies = processor->comparative_matrix_with_redundancies();

			resizer(comparative_matrix_with_redundancies.rows(), comparative_matrix_with_redundancies.columns());

			for (size_t i = 0; i < comparative_matrix_with_redundancies.rows(); i++)
			{
				for (size_t j = 0; j < comparative_matrix_with_redundancies.columns(); j++)
				{
					inserter(comparative_matrix_with_redundancies(i, j), i, j);
				}
			}
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *insert_blueprint_element_single_color(
		uintptr_t address,
		const char *identification,
		const unsigned char red,
		const unsigned char green,
		const unsigned char blue,
		const xablau::organizational_analysis::traversability state)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->insert_blueprint_element(identification, std::to_array({ red, green, blue }), state);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *insert_blueprint_element_color_range(
		uintptr_t address,
		const char *identification,
		const unsigned char minRed,
		const unsigned char minGreen,
		const unsigned char minBlue,
		const unsigned char maxRed,
		const unsigned char maxGreen,
		const unsigned char maxBlue,
		const xablau::organizational_analysis::traversability state)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->insert_blueprint_element(
				identification,
				std::to_array({ minRed, minGreen, minBlue }),
				std::to_array({ maxRed, maxGreen, maxBlue }),
				state);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *rename_blueprint_element_instance(
		uintptr_t address,
		const char *oldIdentification,
		const char *newIdentification)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->rename_blueprint_element_instance(oldIdentification, newIdentification);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *rename_blueprint_element_instance_hash(
		uintptr_t address,
		const bool absolute,
		const size_t hash,
		const char *newIdentification)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->rename_blueprint_element_instance_hash(absolute, hash, newIdentification);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *blueprint_element_instance_hash(
		uintptr_t address,
		const char *identification,
		size_t &absolutePositionHash,
		size_t &relativePositionHash)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			std::tie(absolutePositionHash, relativePositionHash) =
				processor->blueprint_element_instance_hash(identification);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *set_blueprint_element_traversability(
		uintptr_t address,
		const char *identification,
		const xablau::organizational_analysis::traversability state)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->blueprint_element_traversability(identification, state);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *set_blueprint_element_instance_traversability(
		uintptr_t address,
		const char *identification,
		const xablau::organizational_analysis::traversability state)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->blueprint_element_instance_traversability(identification, state);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *erase_blueprint_element(uintptr_t address, const char *identification)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->erase_blueprint_element(identification);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *read_blueprint_and_detect_instances(
		uintptr_t address,
		const char *path,
		const float referenceInMeters)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->read_blueprint_and_detect_instances(path, referenceInMeters);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *detect_blueprint_instances(uintptr_t address)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->detect_blueprint_instances();
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *update_blueprint_space(uintptr_t address)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->update_blueprint_space();
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *blueprint_element_instance_neighborhood(
		uintptr_t address,
		InsertMappedPairOfSizeTAndCoordinates inserter)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			const auto neighborhood = processor->blueprint_element_instance_neighborhood();

			for (const auto &[key, coordinates] : neighborhood)
			{
				for (const auto &coordinate : coordinates)
				{
					inserter(key.first.c_str(), key.second.c_str(), coordinate[0], coordinate[1]);
				}
			}
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *trace_path_on_blueprint(
		uintptr_t address,
		const char *activity,
		InsertStringInContainer taskInserter,
		InsertStringInContainer instanceInserter,
		InsertPairOfSizeTInContainer coordinateInserter,
		float &distance)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			const auto [tasks, instances, path, _distance] = processor->trace_path_on_blueprint(activity);

			for (const auto &task : tasks)
			{
				taskInserter(task.c_str());
			}

			for (const auto &instance : instances)
			{
				instanceInserter(instance.c_str());
			}

			for (const auto &coordinate : path)
			{
				coordinateInserter(coordinate[0], coordinate[1]);
			}

			distance = _distance;
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *trace_path_on_blueprint_and_update_affiliations(
		uintptr_t address,
		const char *activity,
		InsertStringInContainer taskInserter,
		InsertStringInContainer instanceInserter,
		InsertPairOfSizeTInContainer coordinateInserter,
		float &distance)
	{
		auto processor = reinterpret_cast < xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			const auto [tasks, instances, path, _distance] = processor->trace_path_on_blueprint_and_update_affiliations(activity);

			for (const auto &task : tasks)
			{
				taskInserter(task.c_str());
			}

			for (const auto &instance : instances)
			{
				instanceInserter(instance.c_str());
			}

			for (const auto &coordinate : path)
			{
				coordinateInserter(coordinate[0], coordinate[1]);
			}

			distance = _distance;
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *absolute_coordinates_from_element_instance_coordinates_on_blueprint(
		uintptr_t address,
		const char *identification,
		const int cameraDistanceLevel,
		const size_t relativeX,
		const size_t relativeY,
		size_t &absoluteX,
		size_t &absoluteY)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			const auto result =
				processor->absolute_coordinates_from_element_instance_coordinates_on_blueprint(
					identification,
					cameraDistanceLevel,
					relativeX,
					relativeY);

			absoluteX = result.first;
			absoluteY = result.second;
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *element_instance_from_absolute_coordinates_on_blueprint(
		uintptr_t address,
		const size_t x,
		const size_t y,
		CopyNativeStringToManagedString copier)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			copier(processor->element_instance_from_absolute_coordinates_on_blueprint(x, y).c_str());
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *element_instance_identifications(
		uintptr_t address,
		InsertStringInContainer inserter)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			const auto identifications = processor->element_instance_identifications();

			for (const auto &identification : identifications)
			{
				inserter(identification.c_str());
			}
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *write_blueprint(uintptr_t address, const char *path)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->write_blueprint(path);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *write_blueprint_contours(uintptr_t address, const char *path)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->write_blueprint_contours(path);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *write_blueprint_element_instance(
		uintptr_t address,
		const char *directory,
		const char *identification,
		const int cameraDistanceLevel)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->write_blueprint_element_instance(directory, identification, cameraDistanceLevel);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *write_blueprint_element_instances(
		uintptr_t address,
		const char *directory,
		const int cameraDistanceLevel,
		StringFromVector getter,
		const size_t vectorSize)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			std::vector < std::string > inclusion;

			for (size_t i = 0; i < vectorSize; i++)
			{
				inclusion.push_back(getter(i));
			}

			processor->write_blueprint_element_instances(directory, cameraDistanceLevel, inclusion);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *blueprint_element_domain(
		uintptr_t address,
		const char *identification,
		unsigned char &minRed,
		unsigned char &minGreen,
		unsigned char &minBlue,
		unsigned char &maxRed,
		unsigned char &maxGreen,
		unsigned char &maxBlue)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			const auto [min, max] = processor->blueprint_element_domain(identification);

			minRed = min[0];
			minGreen = min[1];
			minBlue = min[2];

			maxRed = max[0];
			maxGreen = max[1];
			maxBlue = max[2];
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *get_blueprint_element_traversability(
		uintptr_t address,
		const char *identification,
		xablau::organizational_analysis::traversability &state)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			state = processor->blueprint_element_traversability(identification);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *get_blueprint_element_instance_traversability(
		uintptr_t address,
		const char *identification,
		xablau::organizational_analysis::traversability &state)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			state = processor->blueprint_element_instance_traversability(identification);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *meters_per_pixel_on_blueprint(
		uintptr_t address,
		float &metersPerPixel)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			metersPerPixel = processor->meters_per_pixel_on_blueprint();
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *write_agents(
		uintptr_t address,
		const char *filename,
		const char separator,
		const char lister)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			std::fstream file(filename, std::ios_base::out | std::ios_base::trunc);

			processor->write_agents(file, separator, lister);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *write_activities(
		uintptr_t address,
		const char *filename,
		const char separator,
		const char lister)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			std::fstream file(filename, std::ios_base::out | std::ios_base::trunc);

			processor->write_activities(file, separator, lister);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *write_components(
		uintptr_t address,
		const char *filename,
		const char separator,
		const char lister)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			std::fstream file(filename, std::ios_base::out | std::ios_base::trunc);

			processor->write_components(file, separator, lister);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *write_affiliations(
		uintptr_t address,
		const char *filename,
		const char separator,
		const char lister)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			std::fstream file(filename, std::ios_base::out | std::ios_base::trunc);

			processor->write_affiliations(file, separator, lister);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *write_weak_affiliations_matrix(
		uintptr_t address,
		const char *filename,
		const char separator,
		const char lister)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			std::fstream file(filename, std::ios_base::out | std::ios_base::trunc);

			processor->write_weak_affiliations_matrix(file, separator, lister);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *write_strong_affiliations_matrix(
		uintptr_t address,
		const char *filename,
		const char separator,
		const char lister)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			std::fstream file(filename, std::ios_base::out | std::ios_base::trunc);

			processor->write_strong_affiliations_matrix(file, separator, lister);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *write_total_affiliations_matrix(
		uintptr_t address,
		const char *filename,
		const char separator,
		const char lister)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			std::fstream file(filename, std::ios_base::out | std::ios_base::trunc);

			processor->write_total_affiliations_matrix(file, separator, lister);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *write_total_potential_matrix(
		uintptr_t address,
		const char *filename,
		const char separator,
		const char lister)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			std::fstream file(filename, std::ios_base::out | std::ios_base::trunc);

			processor->write_total_potential_matrix(file, separator, lister);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *write_strong_potential_matrix_without_redundancies(
		uintptr_t address,
		const char *filename,
		const char separator,
		const char lister)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			std::fstream file(filename, std::ios_base::out | std::ios_base::trunc);

			processor->write_strong_potential_matrix_without_redundancies(file, separator, lister);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *write_strong_potential_matrix_with_redundancies(
		uintptr_t address,
		const char *filename,
		const char separator,
		const char lister)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			std::fstream file(filename, std::ios_base::out | std::ios_base::trunc);

			processor->write_strong_potential_matrix_with_redundancies(file, separator, lister);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *write_comparative_matrix_without_redundancies(
		uintptr_t address,
		const char *filename,
		const char separator,
		const char lister)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			std::fstream file(filename, std::ios_base::out | std::ios_base::trunc);

			processor->write_comparative_matrix_without_redundancies(file, separator, lister);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *write_comparative_matrix_with_redundancies(
		uintptr_t address,
		const char *filename,
		const char separator,
		const char lister)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			std::fstream file(filename, std::ios_base::out | std::ios_base::trunc);

			processor->write_comparative_matrix_with_redundancies(file, separator, lister);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *write_element_instances(
		uintptr_t address,
		const char *directory,
		const char separator,
		const char lister)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->write_element_instances(directory, separator, lister);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}

	_declspec(dllexport) const char *write_element_instance_neighborhood(
		uintptr_t address,
		const char *directory,
		const char separator,
		const char lister)
	{
		auto processor = reinterpret_cast < const xablau::organizational_analysis::processor < true > * > (address);

		try
		{
			processor->write_element_instance_neighborhood(directory, separator, lister);
		}
		catch (const std::exception &exception)
		{
			static std::string message;

			message = exception.what();

			return message.c_str();
		}

		return nullptr;
	}
}