using Microsoft.EntityFrameworkCore;
using MSCMD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Repository
{

	public interface IElementSubsystemRepository
	{
		void AddNew(ElementSubsystem relationship);
		IEnumerable<ElementSubsystem> ListAll();
		IEnumerable<ElementSubsystem> GetByElement(int elementId);
		IEnumerable<ElementSubsystem> GetBySubsystem(int subsystemId);
		ElementSubsystem GetByElementSubsystem(int subsystemId, int elementId);
		void Delete(ElementSubsystem relationship);
		
	}

	public class ElementSubsystemRepository : IElementSubsystemRepository
	{
		private MscmdContext _context;

		public ElementSubsystemRepository()
		{
			_context = new MscmdContext();

		}

		public IEnumerable<ElementSubsystem> ElementSubsystems
		{
			get { return _context.ElementSubsystems.Include(s => s.Element).Include(s => s.Subsystem); }
		}


		public void AddNew(ElementSubsystem relationship)
		{
			var rel = ElementSubsystems.Where(f => f.ElementId == relationship.ElementId && f.SubsystemId == relationship.SubsystemId);

			if (rel == null || rel.ToList().Count == 0)
			{
				_context.ElementSubsystems.Add(relationship);
				_context.SaveChanges();
			}
		}

		public IEnumerable<ElementSubsystem> ListAll()
		{
			return _context.ElementSubsystems.AsEnumerable();
		}

		public IEnumerable<ElementSubsystem> GetByElement(int elementId)
		{
			return ElementSubsystems.Where(f => f.ElementId == elementId);
		}

		public IEnumerable<ElementSubsystem> GetBySubsystem(int subsystemId)
		{
			return ElementSubsystems.Where(f => f.SubsystemId == subsystemId);
		}

		public ElementSubsystem GetByElementSubsystem(int subsystemId, int elementId)
		{
			return ElementSubsystems.Where(f => f.SubsystemId == subsystemId && f.ElementId == elementId).First();
		}

		public void Delete(ElementSubsystem relationship)
		{
			_context.ElementSubsystems.Remove(relationship);
			_context!.SaveChanges();
		}

	}
}
