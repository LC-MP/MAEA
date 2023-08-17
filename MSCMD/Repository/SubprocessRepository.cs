using Microsoft.EntityFrameworkCore;
using MSCMD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Repository
{
	public interface ISubprocessRepository
	{
		void AddNew(Subprocess subprocess);
		void Save(Subprocess subprocess);
		IEnumerable<Subprocess> ListAll();
		Subprocess FindBy(int subprocessId);
		Subprocess? FindByCode(string code);
		void Delete(Subprocess subprocess);
	}
	public class SubprocessRepository : ISubprocessRepository
	{
		private MscmdContext _context;

		public SubprocessRepository(MscmdContext context)
		{
			_context = context;
		}

		public IEnumerable<Subprocess> Subprocesses
		{
			get
			{
				return _context.Subprocesses.Include(s => s.Activities);
			}
		}

		public void Save(Subprocess subprocess)
		{
			if (subprocess.SubprocessId == 0)
			{
				_context.Subprocesses.Add(subprocess);
				_context!.SaveChanges();
			}
			else
			{
				Subprocess dado = _context.Subprocesses.Find(subprocess.SubprocessId);
				if (dado != null)
				{
					dado.Code = subprocess.Code;
					dado.Name = subprocess.Name;					

				}
				_context!.SaveChanges();
			}
		}

		public void AddNew(Subprocess subprocess)
		{
			_context.Subprocesses.Add(subprocess);
			_context!.SaveChanges();
		}

		public IEnumerable<Subprocess> ListAll()
		{
			return Subprocesses.AsEnumerable();
		}

		public Subprocess FindBy(int subprocessId)
		{
			return Subprocesses.Where(f => f.SubprocessId == subprocessId).First();
		}

		public Subprocess? FindByCode(string code)
		{
			var item = _context.Subprocesses.Where(f => f.Code == code);

			if (item.Any())
			{
				return item.FirstOrDefault();
			}
			else
			{
				return null;
			}

		}
		public void Delete(Subprocess subprocess)
		{
			_context.Subprocesses.Remove(subprocess);
			_context!.SaveChanges();
		}

		public void ImportList(List<Subprocess> subprocess)
		{
			foreach (Subprocess sub in subprocess)
			{
				AddNew(sub);
			}

		}

		public void SaveList(List<Subprocess> subprocess)
		{
			foreach (Subprocess sub in subprocess)
			{
				Save(sub);
			}

		}

	}
}
