using Microsoft.EntityFrameworkCore;
using MSCMD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Repository
{

	public interface IAgentResourceRelationshipRepository
	{
		void AddNew(AgentResourceRelationship relationship);
		IEnumerable<AgentResourceRelationship> ListAll();
		IEnumerable<AgentResourceRelationship> GetByAgent(int agentId);
		IEnumerable<AgentResourceRelationship> GetByResource(int resourceId);
		void Delete(AgentResourceRelationship relationship);
		AgentResourceRelationship GetById(int id);
		void DeleteById(int id);
	}

	public class AgentResourceRelationshipRepository : IAgentResourceRelationshipRepository
	{
		private MscmdContext _context;

		public AgentResourceRelationshipRepository(MscmdContext context)
		{
			_context = context;

		}

	public IEnumerable<AgentResourceRelationship> RelacoesPessoaFuncao
		{
			get { return _context.AgentResourceRelationships.Include(r => r.Resource).Include(r => r.Agent); }
		}

		
		public void AddNew(AgentResourceRelationship relationship)
		{
			_context.AgentResourceRelationships.Add(relationship);
			_context.SaveChanges();
		}

		public IEnumerable<AgentResourceRelationship> ListAll()
		{
			return _context.AgentResourceRelationships.AsEnumerable();
		}

		public IEnumerable<AgentResourceRelationship> GetByAgent(int agentId)
		{
			return RelacoesPessoaFuncao.Where(f => f.AgentId == agentId);
		}

		public IEnumerable<AgentResourceRelationship> GetByResource(int resourceId)
		{
			return RelacoesPessoaFuncao.Where(f => f.ResourceId == resourceId);
		}

		public void Delete(AgentResourceRelationship relationship)
		{
			_context.AgentResourceRelationships.Remove(relationship);
			_context!.SaveChanges();
		}

		public AgentResourceRelationship GetById(int id)
		{
			return RelacoesPessoaFuncao.FirstOrDefault(r => r.RelationshipId == id);
		}

		public void DeleteById(int id)
		{
			AgentResourceRelationship relationship = GetById(id);
			Delete(relationship);
		}

		public void ImportList(List<AgentResourceRelationship> relationshipList)
		{
			foreach (AgentResourceRelationship rel in relationshipList)
			{
				AddNew(rel);
			}

		}

		public bool RelationAlreadyExist(string agentCode, string resourceCode)
		{
			var rel = RelacoesPessoaFuncao.Where(f => f.Agent.Code == agentCode && f.Resource.Code == resourceCode).ToList();

			if (rel.Any())
			{
				return true;
			}
			else
			{
				return false;
			}

		}
	}
}
