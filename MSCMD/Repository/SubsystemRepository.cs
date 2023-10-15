using Microsoft.EntityFrameworkCore;
using MSCMD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Repository
{
	

	public interface ISubsystemRepository
	{
		void AddNew(Subsystem subsystem);
		void Save(Subsystem subsystem);
		IEnumerable<Subsystem> ListAll();
		Subsystem FindBy(int subsystemId);
		Subsystem? FindByCode(string code);
		void Delete(Subsystem subsystem);
	}
	public class SubsystemRepository : ISubsystemRepository
	{
		private MscmdContext _context;

		public SubsystemRepository(MscmdContext context)
		{
			_context = context;
		}

		public IEnumerable<Subsystem> Subsystems
		{
			get
			{
				return _context.Subsystems.Include(s => s.Elements);
			}
		}

		public void Save(Subsystem subsystem)
		{
			if (subsystem.SubsystemId == 0)
			{
				_context.Subsystems.Add(subsystem);
				_context!.SaveChanges();
			}
			else
			{
				Subsystem dado = _context.Subsystems.Find(subsystem.SubsystemId);
				if (dado != null)
				{
					dado.Code = subsystem.Code;
					dado.Name = subsystem.Name;

				}
				_context!.SaveChanges();
			}
		}

		public void AddNew(Subsystem subsystem)
		{
			_context.Subsystems.Add(subsystem);
			_context!.SaveChanges();
		}

		public IEnumerable<Subsystem> ListAll()
		{
			return Subsystems.AsEnumerable();
		}

		public Subsystem FindBy(int subsystemId)
		{
			return Subsystems.Where(f => f.SubsystemId == subsystemId).First();
		}

		public Subsystem? FindByCode(string code)
		{
			var item = _context.Subsystems.Where(f => f.Code == code);

			if (item.Any())
			{
				return item.FirstOrDefault();
			}
			else
			{
				return null;
			}

		}

		public void Delete(Subsystem subsystem)
		{
			_context.Subsystems.Remove(subsystem);
			_context!.SaveChanges();
		}

		public void ImportList(List<Subsystem> subsystem)
		{
			foreach (Subsystem sub in subsystem)
			{
				AddNew(sub);
			}

		}

		public void SaveList(List<Subsystem> subsystem)
		{
			foreach (Subsystem sub in subsystem)
			{
				Save(sub);
			}

		}

	}
}
