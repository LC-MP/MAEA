using Microsoft.EntityFrameworkCore;
using MSCMD.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Repository
{
	public interface IHumanResourceRepository
	{
		void AddNew(HumanResource person);
		void Save(HumanResource person);
		IEnumerable<HumanResource> ListAll();
		HumanResource FindBy(int personId);
		HumanResource? FindByCode(string code);
		void Delete(HumanResource person);
	}

	public class HumanResourceRepository : IHumanResourceRepository
	{
		private MscmdContext _context;

		public HumanResourceRepository(MscmdContext context)
		{
			_context = context;
		}

		public IEnumerable<HumanResource> HumanResources
		{
			get { return _context.HumanResources; }
		}

		public void Save(HumanResource person)
		{
			if (person.PersonId == 0)
			{
				_context.HumanResources.Add(person);
				_context!.SaveChanges();
			}
			else
			{
				HumanResource dado = _context.HumanResources.Find(person.PersonId);
				if (dado != null)
				{
					dado.Code = person.Code;
					dado.Name = person.Name;
					dado.Type = person.Type;
					dado.Competences = person.Competences;
					dado.Contact = person.Contact;
					dado.Registry = person.Registry;
				}
			}
			saveContextChanges();
		}

		public void AddNew(HumanResource person)
		{
			_context.HumanResources.Add(person);
			saveContextChanges();
		}

		public IEnumerable<HumanResource> ListAll()
		{
			return _context.HumanResources.AsEnumerable();
		}

		public HumanResource FindBy(int personId)
		{
			return _context.HumanResources.First(f => f.PersonId == personId);
		}

		public HumanResource? FindByCode(string code)
		{
			var resource = _context.HumanResources.Where(f => f.Code == code);

			if (resource.Any())
			{
				return resource.FirstOrDefault();
			}
			else
			{
				return null;
			}

		}

		public void Delete(HumanResource person)
		{
			_context.HumanResources.Remove(person);
			saveContextChanges();
		}

		public void ImportList(List<HumanResource> people)
		{
			foreach (HumanResource person in people)
			{
				Save(person);
			}

		}

		public BindingList<HumanResource> getBindingList()
		{
			_context.HumanResources.Load();
			return _context.HumanResources.Local.ToBindingList();
		}

		public void saveContextChanges()
		{
			_context!.SaveChanges();
		}


	}
}
