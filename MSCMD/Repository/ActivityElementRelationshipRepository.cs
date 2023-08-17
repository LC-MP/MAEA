using Microsoft.EntityFrameworkCore;
using MSCMD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Repository
{

	public interface IActivityElementRelationshipRepository
	{
		void AddNew(ActivityElementRelationship relationship);
		IEnumerable<ActivityElementRelationship> ListAll();
		IEnumerable<ActivityElementRelationship> GetByActivity(int activityId);

		IEnumerable<ActivityElementRelationship> GetByElement(int elementId);
		void Delete(ActivityElementRelationship relationship);
		ActivityElementRelationship GetById(int id);
		void DeleteById(int id);
	}

	public class ActivityElementRelationshipRepository : IActivityElementRelationshipRepository
	{
		private MscmdContext _context;

		public ActivityElementRelationshipRepository(MscmdContext context)
		{
			_context = context;

		}

		public IEnumerable<ActivityElementRelationship> Relationships
		{
			get { return _context.ActivityElementRelationships.Include(r => r.Activity).Include(r => r.Component); }
		}


		public void AddNew(ActivityElementRelationship relationship)
		{
			_context.ActivityElementRelationships.Add(relationship);
			_context.SaveChanges();
		}

		public IEnumerable<ActivityElementRelationship> ListAll()
		{
			return _context.ActivityElementRelationships.AsEnumerable();
		}

		public IEnumerable<ActivityElementRelationship> GetByActivity(int activityId)
		{
			return Relationships.Where(f => f.ActivityId == activityId);
		}

		public IEnumerable<ActivityElementRelationship> GetByElement(int elementId)
		{
			return Relationships.Where(f => f.ComponentId == elementId);
		}

		public void Delete(ActivityElementRelationship relationship)
		{
			_context.ActivityElementRelationships.Remove(relationship);
			_context!.SaveChanges();
		}

		public ActivityElementRelationship GetById(int id)
		{
			return Relationships.FirstOrDefault(r => r.RelationshipId == id);
		}

		public void DeleteById(int id)
		{
			ActivityElementRelationship relationship = GetById(id);
			Delete(relationship);
		}

		public void ImportList(List<ActivityElementRelationship> relationshipList)
		{
			foreach (ActivityElementRelationship rel in relationshipList)
			{
				AddNew(rel);
			}

		}

		public bool RelationAlreadyExist(string activityCode, string elementCode)
		{
			var rel = Relationships.Where(f => f.Activity.ActivityCode == activityCode && f.Component.Code == elementCode).ToList();

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
