using Microsoft.EntityFrameworkCore;
using MSCMD.Model;
using MSCMD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Repository
{
	public interface IElementRepository { 
		void AddNew(Element element);
		void Save(Element element);
		IEnumerable<Element> ListAll();
		Element FindBy(int elementId);
		Element? FindByCode(string elementCode);
		void Delete(Element element);
	}

	public class ElementRepository : IElementRepository
{
		private MscmdContext _context;

		public ElementRepository(MscmdContext context)
		{
			_context = context;
			_context.ChangeTracker.DetectChanges();
		}

		public IEnumerable<Element> Elements
		{
			get
			{
				return _context.Elements.Include(e => e.OcupiedBy).Include(e => e.Subsystems);
			}
		}

		public void Save(Element elemento)
		{
			if (elemento.ElementId == 0)
			{
				_context.Elements.Add(elemento);
				_context!.SaveChanges();
			}
			else
			{
				Element dado = _context.Elements.Find(elemento.ElementId);
				if (dado != null)
				{
					dado.Code = elemento.Code;
					dado.Name = elemento.Name;
					dado.Type = elemento.Type;
					dado.ExternalIdentifier = elemento.ExternalIdentifier;
					dado.ComponentClass = elemento.ComponentClass;
					dado.OrganizationId = elemento.OrganizationId;
					dado.SurfaceType = elemento.SurfaceType;
					_context!.SaveChanges();
				}
				
			}
		}

		public void AddNew(Element elemento)
		{
			_context.Elements.Add(elemento);
			_context!.SaveChanges();
		}

		public IEnumerable<Element> ListAll()
		{
			return _context.Elements.Include(e => e.OcupiedBy).Include(e => e.Subsystems);
		}

		public Element FindBy(int idElemento)
		{
			return Elements.Where(f => f.ElementId == idElemento).First();
		}

		public Element? FindByCode(string elementCode)
		{
			var elements = Elements.Where(f => f.Code == elementCode);

			if (elements.Any())
			{
				return elements.FirstOrDefault();
			}
			else
			{
				return null;
			}

		}

		public void Delete(Element elemento)
		{
			_context.Elements.Remove(elemento);
			_context!.SaveChanges();
		}

		public void ImportList(List<Element> elementos)
		{
			foreach (Element el in elementos)
			{
				Save(el);
			}

		}

		public void SaveList(List<Element> elementos)
		{
			foreach (Element el in elementos)
			{
				Save(el);
			}

		}

	}
}
