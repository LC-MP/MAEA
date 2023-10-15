using MSCMD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Repository
{

	public interface IAgentSubordinationRepository
	{
		void AddNew(AgentSubordination relationship);
		IEnumerable<AgentSubordination> ListAll();
		IEnumerable<AgentSubordination> GetByAgent(int agentId);
		IEnumerable<AgentSubordination> GetBySubordination(int subordinatedToId);
		AgentSubordination GetByAgentSubordination(int agentId, int subordinatedToId);
		void Delete(AgentSubordination relationship);

	}

	public class AgentSubordinationRepository : IAgentSubordinationRepository
	{
		private MscmdContext _context;

		public AgentSubordinationRepository(MscmdContext context)
		{
			_context = context;

		}

		public IEnumerable<AgentSubordination> AgentSubordinations
		{
			get { return _context.AgentSubordinations; }
		}


		public void AddNew(AgentSubordination relationship)
		{
			_context.AgentSubordinations.Add(relationship);
			_context.SaveChanges();
		}

		public IEnumerable<AgentSubordination> ListAll()
		{
			return _context.AgentSubordinations.AsEnumerable();
		}

		public IEnumerable<AgentSubordination> GetByAgent(int agentId)
		{
			return AgentSubordinations.Where(f => f.AgentId == agentId);
		}

		public IEnumerable<AgentSubordination> GetBySubordination(int subordinatedToId)
		{
			return AgentSubordinations.Where(f => f.FunctionalSubordinationId == subordinatedToId);
		}

		public AgentSubordination GetByAgentSubordination(int agentId, int subordinatedToId)
		{
			return AgentSubordinations.Where(f => f.AgentId == agentId && f.FunctionalSubordinationId == subordinatedToId).First();
		}

		public void Delete(AgentSubordination relationship)
		{
			_context.AgentSubordinations.Remove(relationship);
			_context!.SaveChanges();
		}

	}
}
