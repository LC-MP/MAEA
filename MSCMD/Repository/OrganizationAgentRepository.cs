using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MSCMD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Repository
{
	
	public interface IOrganizationAgentRepository
	{
		void AddNew(OrganizationAgent relationship);
		IEnumerable<OrganizationAgent> ListAll();
		IEnumerable<OrganizationAgent> GetByOrganization(int organizationId);
		IEnumerable<OrganizationAgent> GetByAgent(int agentId);
		OrganizationAgent GetByOrganizationAgent(int organizationId, int agentId);
		void Delete(OrganizationAgent relationship);

	}

	public class OrganizationAgentRepository : IOrganizationAgentRepository
	{
		private MscmdContext _context;

		public OrganizationAgentRepository()
		{
			_context = new MscmdContext(); 

		}

		public IEnumerable<OrganizationAgent> OrganizationAgents
		{
			get { return _context.OrganizationAgents.Include(x => x.Agent).Include(x => x.Organization); }
		}


		public void AddNew(OrganizationAgent relationship)
		{
			var rel = OrganizationAgents.Where(f => f.OrganizationId == relationship.OrganizationId && f.AgentId == relationship.AgentId);

			if (rel == null || rel.ToList().Count == 0)
			{
				_context.OrganizationAgents.Add(relationship);
				_context.SaveChanges();
			}

		}

		public IEnumerable<OrganizationAgent> ListAll()
		{
			return _context.OrganizationAgents.AsEnumerable();
		}

		public IEnumerable<OrganizationAgent> GetByAgent(int agentId)
		{
			return OrganizationAgents.Where(f => f.AgentId == agentId);
		}

		public IEnumerable<OrganizationAgent> GetByOrganization(int organizationId)
		{
			return OrganizationAgents.Where(f => f.OrganizationId == organizationId);
		}

		public OrganizationAgent GetByOrganizationAgent(int organizationId, int agentId)
		{
			return OrganizationAgents.Where(f => f.OrganizationId == organizationId && f.AgentId == agentId).First();
		}

		public void Delete(OrganizationAgent relationship)
		{
			_context.OrganizationAgents.Remove(relationship);
			_context!.SaveChanges();
		}


	}
}
