using Microsoft.EntityFrameworkCore;
using MSCMD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Repository
{
	public interface IAgentRepository
	{
		void AddNew(Agent agent);
		void Save(Agent agent);
		IEnumerable<Agent> ListAll();
		Agent FindBy(int agentId);
		Agent? FindByCode(string code);
		void Delete(Agent agent);
	}

	public class AgentRepository : IAgentRepository
	{
		private MscmdContext _context;

		public AgentRepository(MscmdContext context)
		{
			_context = context;
		}

		public IEnumerable<Agent> Agents
		{
			get { return _context.Agents.Include(f => f.FunctionalSubordinations).Include(f => f.Organizations); }
		}

		public void Save(Agent agent)
		{
			if (agent.AgentId == 0)
			{
				_context.Agents.Add(agent);
				_context!.SaveChanges();
			}
			else
			{
				Agent dado = _context.Agents.Find(agent.AgentId);
				if (dado != null)
				{
					dado.Code = agent.Code;
					dado.Name = agent.Name;
					dado.Description = agent.Description;
					
				}
			}
			_context!.SaveChanges();
		}

		public void AddNew(Agent agent)
		{
			_context.Agents.Add(agent); 
			_context!.SaveChanges();
		}

		public IEnumerable<Agent> ListAll()
		{
			return Agents.AsEnumerable();
		}

		public Agent FindBy(int agentId)
		{
			return Agents.Where(f => f.AgentId == agentId).First();
		}
		public Agent? FindByCode(string code)
		{
			var agents = Agents.Where(f => f.Code == code);

			if (agents.Any())
			{
				return agents.FirstOrDefault();
			}
			else
			{
				return null;
			}

		}

		public void Delete(Agent agent)
		{
			_context.Agents.Remove(agent);
			_context!.SaveChanges();
		}

		public void ImportList(List<Agent> agents)
		{
			foreach (Agent a in agents)
			{
				AddNew(a);
			}

		}

		public void SalveList(List<Agent> agents)
		{
			foreach (Agent a in agents)
			{
				Save(a);
			}

		}



	}
}
