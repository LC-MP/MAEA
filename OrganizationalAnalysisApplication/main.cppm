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

import xablau.io;
import xablau.organizational_analysis;

int main(int argc, char** argv)
{
	try
	{
		if (argc < 25)
		{
			std::cout << "There are not enough parameters.";

			return -1;
		}

		char separator{argv[23][0]};
		char lister{argv[24][0]};

		xablau::organizational_analysis::processor < true > processor{};

		processor.indirectly_related_degree(1.0f);
		processor.related_degree(2.0f);
		processor.directly_related_degree(3.0f);

		xablau::io::fstream < char > agentsInput(argv[1], std::ios_base::in);
		xablau::io::fstream < char > activitiesInput(argv[2], std::ios_base::in);
		xablau::io::fstream < char > componentsInput(argv[3], std::ios_base::in);
		xablau::io::fstream < char > affiliationsInput(argv[4], std::ios_base::in);

		std::cout << "\n--------------------Reading inputs---------------------\n";

		processor.read_inputs(agentsInput, activitiesInput, componentsInput, affiliationsInput);

		std::cout << "\n-------------------------------------------------------\n";
		std::cout << "\n\n";
		std::cout << "\n---------------Possible parallelizations---------------\n";

		xablau::io::fstream < char > parallelizationsOutput(argv[21], std::ios_base::out | std::ios_base::trunc);
		const auto parallelizations = processor.identify_parallelizations();

		size_t level{};

		for (const auto &parallelization : parallelizations)
		{
			auto iterator = parallelization.cbegin();
			parallelizationsOutput << "Level = { " << level << " }: [ ";

			for (size_t i = 1; i < parallelization.size(); i++)
			{
				parallelizationsOutput << *iterator << ", ";
				++iterator;
			}

			parallelizationsOutput << *iterator << " ]\n";

			level++;
		}

		std::cout << "\n-------------------------------------------------------\n";
		std::cout << "\n\n";
		std::cout << "\n-----------------------Priorities----------------------\n";

		xablau::io::fstream < char > prioritiesOutput(argv[22], std::ios_base::out | std::ios_base::trunc);
		const auto priorities = processor.identify_priorities();

		for (const auto &priority : priorities)
		{
			prioritiesOutput << "{ " << priority.first << ", " << priority.second << " }\n";
		}

		std::cout << "\n-------------------------------------------------------\n";
		std::cout << "\n\n";
		std::cout << "\n-----------------------Alignment-----------------------\n";

		bool everyProductHasAnAgentInCharge = false;
		float minimumRelationDegree = std::stof(argv[6], nullptr);

		while (std::atoi(argv[5]) == 1 && !everyProductHasAnAgentInCharge)
		{
			if (minimumRelationDegree <= 0.0f)
			{
				std::cout << "Minimum relation degree between agent and component is null or negative.\n";
				std::cout << "Exiting...\n";

				return -2;
			}

			processor.minimum_relation_degree_for_agents_in_charge_of_components(minimumRelationDegree);
			const auto productsWithoutAgentsInCharge = processor.components_without_agents_in_charge();

			if (productsWithoutAgentsInCharge.size() != 0)
			{
				std::cout << "The following components do not have an agent in charge:\n";

				for (const auto &productWithoutAgentsInCharge : productsWithoutAgentsInCharge)
				{
					std::cout << "\t" << productWithoutAgentsInCharge << "\n";
				}

				std::cout << "\n";

				minimumRelationDegree -= 1.0f;

				std::cout << "Trying again with a lesser value: " << minimumRelationDegree << "\n\n";
			}

			else
			{
				everyProductHasAnAgentInCharge = true;
			}
		}

		xablau::io::fstream < char > reportWithoutRedundanciesOutput(argv[19], std::ios_base::out | std::ios_base::trunc);
		xablau::io::fstream < char > reportWithRedundanciesOutput(argv[20], std::ios_base::out | std::ios_base::trunc);

		if (std::atoi(argv[5]) == 0)
		{
			processor.compare_activities_and_organization(
				reportWithoutRedundanciesOutput,
				reportWithRedundanciesOutput);
		}

		else
		{
			processor.compare_components_and_organization(
				minimumRelationDegree,
				reportWithoutRedundanciesOutput,
				reportWithRedundanciesOutput);
		}

		std::cout << "\n-------------------------------------------------------\n";
		std::cout << "\n\n";
		std::cout << "\n-------------------------Saving------------------------\n";

		xablau::io::fstream < char > agentsOutput(argv[7], std::ios_base::out | std::ios_base::trunc);
		xablau::io::fstream < char > activitiesOutput(argv[8], std::ios_base::out | std::ios_base::trunc);
		xablau::io::fstream < char > componentsOutput(argv[9], std::ios_base::out | std::ios_base::trunc);
		xablau::io::fstream < char > affiliationsOutput(argv[10], std::ios_base::out | std::ios_base::trunc);

		processor.write_agents(agentsOutput, separator, lister);
		processor.write_activities(activitiesOutput, separator, lister);
		processor.write_components(componentsOutput, separator, lister);
		processor.write_affiliations(affiliationsOutput, separator, lister);

		xablau::io::fstream < char > weakAffiliationsOutput(argv[11], std::ios_base::out | std::ios_base::trunc);
		xablau::io::fstream < char > strongAffiliationsOutput(argv[12], std::ios_base::out | std::ios_base::trunc);
		xablau::io::fstream < char > totalAffiliationsOutput(argv[13], std::ios_base::out | std::ios_base::trunc);
		xablau::io::fstream < char > totalPotentialOutput(argv[14], std::ios_base::out | std::ios_base::trunc);
		xablau::io::fstream < char > strongTotalPotentialWithoutRedundanciesOutput(argv[15], std::ios_base::out | std::ios_base::trunc);
		xablau::io::fstream < char > strongTotalPotentialWithRedundanciesOutput(argv[16], std::ios_base::out | std::ios_base::trunc);
		xablau::io::fstream < char > comparativeWithoutRedundanciesOutput(argv[17], std::ios_base::out | std::ios_base::trunc);
		xablau::io::fstream < char > comparativeWithRedundanciesOutput(argv[18], std::ios_base::out | std::ios_base::trunc);

		processor.write_weak_affiliations_matrix(weakAffiliationsOutput, separator, lister);
		processor.write_strong_affiliations_matrix(strongAffiliationsOutput, separator, lister);
		processor.write_total_affiliations_matrix(totalAffiliationsOutput, separator, lister);
		processor.write_total_potential_matrix(totalPotentialOutput, separator, lister);
		processor.write_strong_potential_matrix_without_redundancies(strongTotalPotentialWithoutRedundanciesOutput, separator, lister);
		processor.write_strong_potential_matrix_with_redundancies(strongTotalPotentialWithRedundanciesOutput, separator, lister);
		processor.write_comparative_matrix_without_redundancies(comparativeWithoutRedundanciesOutput, separator, lister);
		processor.write_comparative_matrix_with_redundancies(comparativeWithRedundanciesOutput, separator, lister);

		std::cout << "\n-------------------------------------------------------\n";
	}

	catch (const std::exception &exception)
	{
		std::cout << "FATAL ERROR: " << exception.what();

		return -3;
	}

	return 0;
}
