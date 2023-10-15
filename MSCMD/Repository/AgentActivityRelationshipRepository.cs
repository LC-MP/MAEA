using Microsoft.EntityFrameworkCore;
using MSCMD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Repository
{
	public interface IAgentActivityRelationshipRepository
	{
		void AddNew(AgentActivityRelationship relationship);
		IEnumerable<AgentActivityRelationship> ListAll();
		IEnumerable<AgentActivityRelationship> GetByAgentId(int agentId);
		IEnumerable<AgentActivityRelationship> GetByActivityId(int activityId);
		void Delete(AgentActivityRelationship relationship);
		AgentActivityRelationship GetById(int id);
		void DeleteById(int id);
	}

	public class AgentActivityRelationshipRepository : IAgentActivityRelationshipRepository
	{
		private MscmdContext _context;

		public AgentActivityRelationshipRepository(MscmdContext context)
		{
			_context = context;

		}

		public IEnumerable<AgentActivityRelationship> Relationships
		{
			get { return _context.AgentActivityRelationships.Include(r => r.ResponsibleAgent).Include(r => r.Activity); }
		}


		public void AddNew(AgentActivityRelationship relationship)
		{
			_context.AgentActivityRelationships.Add(relationship);
			_context.SaveChanges();
		}

		public IEnumerable<AgentActivityRelationship> ListAll()
		{
			return _context.AgentActivityRelationships.AsEnumerable();
		}

		public IEnumerable<AgentActivityRelationship> GetByAgentId(int agentId)
		{
			return Relationships.Where(f => f.AgentId == agentId);
		}

		public IEnumerable<AgentActivityRelationship> GetByActivityId(int activityId)
		{
			return Relationships.Where(f => f.ActivityId == activityId);
		}

		public void Delete(AgentActivityRelationship relationship)
		{
			_context.AgentActivityRelationships.Remove(relationship);
			_context!.SaveChanges();
		}

		public AgentActivityRelationship GetById(int id)
		{
			return Relationships.FirstOrDefault(r => r.RelationshipId == id);
		}

		public void DeleteById(int id)
		{
			AgentActivityRelationship relationship = GetById(id);
			Delete(relationship);
		}

		public void ImportList(List<AgentActivityRelationship> relationshipList)
		{
			foreach (AgentActivityRelationship rel in relationshipList)
			{
				AddNew(rel);
			}

		}

		public bool RelationAlreadyExist(string activityCode, string agentCode)
		{
			var rel = Relationships.Where(f => f.Activity.ActivityCode == activityCode && f.ResponsibleAgent.Code == agentCode).ToList();

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
