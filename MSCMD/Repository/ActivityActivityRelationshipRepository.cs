using Microsoft.EntityFrameworkCore;
using MSCMD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Repository
{

	public interface IActivityActivityRelationshipRepository
	{
		void AddNew(ActivityActivityRelationship relationship);
		IEnumerable<ActivityActivityRelationship> ListAll();
		IEnumerable<ActivityActivityRelationship> GetByReferredActivity(int activityId);
		IEnumerable<ActivityActivityRelationship> GetByReferenceActivity(int activityId);

		void Delete(ActivityActivityRelationship relationship);
		ActivityActivityRelationship GetById(int id);
		void DeleteById(int id);
		void ImportList(List<ActivityActivityRelationship> relationshipList);
		bool RelationAlreadyExist(int referenceActivityId, int referredActivityId);
		bool RelationAlreadyExist(string referenceCode, string referredCode);
	}

	public class ActivityActivityRelationshipRepository : IActivityActivityRelationshipRepository
	{
		private MscmdContext _context;

		public ActivityActivityRelationshipRepository(MscmdContext context)
		{
			_context = context;

		}

		public IEnumerable<ActivityActivityRelationship> Relationships
		{
			get { return _context.ActivityActivityRelationships.Include(r => r.ReferenceActivity).Include(r => r.ReferredActivity); }
		}


		public void AddNew(ActivityActivityRelationship relationship)
		{
			_context.ActivityActivityRelationships.Add(relationship);
			_context.SaveChanges();
		}

		public IEnumerable<ActivityActivityRelationship> ListAll()
		{
			return Relationships.AsEnumerable();
		}

		public IEnumerable<ActivityActivityRelationship> GetByReferredActivity(int activityId)
		{
			return Relationships.Where(f => f.ReferredActivityId == activityId);
		}

		public IEnumerable<ActivityActivityRelationship> GetByReferenceActivity(int activityId)
		{
			return Relationships.Where(f => f.ReferenceActivityId == activityId);
		}

		public void Delete(ActivityActivityRelationship relationship)
		{
			_context.ActivityActivityRelationships.Remove(relationship);
			_context!.SaveChanges();
		}

		public ActivityActivityRelationship GetById(int id)
		{
			return Relationships.FirstOrDefault(r => r.RelationshipId == id);
		}

		public void DeleteById(int id)
		{
			ActivityActivityRelationship relacao = GetById(id);
			Delete(relacao);
		}

		public void ImportList(List<ActivityActivityRelationship> relationshipList)
		{
			foreach (ActivityActivityRelationship rel in relationshipList)
			{
				AddNew(rel);
			}

		}

		public bool RelationAlreadyExist(int referenceActivityId, int referredActivityId)
		{
			var rel = Relationships.Where(f => f.ReferenceActivityId == referenceActivityId && f.ReferredActivityId == referenceActivityId).ToList();

			if (rel.Any())
			{
				return true;
			} else
			{
				return false;
			}
			
		}

		public bool RelationAlreadyExist(string referenceCode, string referredCode)
		{
			var rel = Relationships.Where(f => f.ReferenceActivity.ActivityCode == referenceCode && f.ReferredActivity.ActivityCode == referredCode).ToList();

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
