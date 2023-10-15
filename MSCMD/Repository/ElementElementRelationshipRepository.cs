using Microsoft.EntityFrameworkCore;
using MSCMD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Repository
{
	public interface IElementElementRelationshipRepository
	{
		void AddNew(ElementElementRelationship relationship);
		IEnumerable<ElementElementRelationship> ListAll();
		IEnumerable<ElementElementRelationship> GetByReferredComponentId(int elementId);

		IEnumerable<ElementElementRelationship> GetByReferenceComponentId(int elementId);
		void Delete(ElementElementRelationship relationship);
		ElementElementRelationship GetById(int id);
		ElementElementRelationship? GetByReferenceIdAndReferredId(int referenceId, int referredId);
		void DeleteById(int id);
	}

	public class ElementElementRelationshipRepository : IElementElementRelationshipRepository
	{
		private MscmdContext _context;

		public ElementElementRelationshipRepository(MscmdContext context)
		{
			_context = context;

		}

		public IEnumerable<ElementElementRelationship> Relationships
		{
			get { return _context.ElementElementRelationships.Include(r => r.ReferredComponent).Include(r => r.ReferenceComponent); }
		}


		public void AddNew(ElementElementRelationship relationship)
		{
			_context.ElementElementRelationships.Add(relationship);
			_context.SaveChanges();
		}

		public IEnumerable<ElementElementRelationship> ListAll()
		{
			return _context.ElementElementRelationships.AsEnumerable();
		}

		public IEnumerable<ElementElementRelationship> GetByReferredComponentId(int elementId)
		{
			return Relationships.Where(f => f.ReferredComponentId == elementId);
		}

		public IEnumerable<ElementElementRelationship> GetByReferenceComponentId(int elementId)
		{
			return Relationships.Where(f => f.ReferenceComponentId == elementId);
		}
		public ElementElementRelationship? GetByReferenceIdAndReferredId(int referenceId, int referredId)
		{
			var rel = Relationships.Where(f => f.ReferenceComponentId == referenceId && f.ReferredComponentId == referredId);

			if (rel.Any())
			{
				return rel.First();
			} else
			{
				return null;
			}
			
		}

		public void Delete(ElementElementRelationship relationship)
		{
			_context.ElementElementRelationships.Remove(relationship);
			_context!.SaveChanges();
		}

		public ElementElementRelationship GetById(int id)
		{
			return Relationships.FirstOrDefault(r => r.RelationshipId == id);
		}

		public void DeleteById(int id)
		{
			ElementElementRelationship relacao = GetById(id);
			Delete(relacao);
		}

		public void ImportList(List<ElementElementRelationship> relationshipList)
		{
			foreach (ElementElementRelationship rel in relationshipList)
			{
				AddNew(rel);
			}

		}

		public bool RelationAlreadyExist(string referenceElementCode, string referredElementCode)
		{
			var rel = Relationships.Where(f => f.ReferenceComponent.Code == referenceElementCode && f.ReferredComponent.Code == referredElementCode).ToList();

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
