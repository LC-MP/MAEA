using Microsoft.EntityFrameworkCore;
using MSCMD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Repository
{
	
	public interface IOrganizationRepository
	{
		void AddNew(Organization organization);
		void Save(Organization organization);
		IEnumerable<Organization> ListAll();
		Organization FindBy(int organizationId);
		Organization? FindByCode(string code);
		void Delete(Organization organization);
	}

	public class OrganizationRepository : IOrganizationRepository
	{
		private MscmdContext _context;

		public OrganizationRepository(MscmdContext context)
		{
			_context = context;
		}

		public IEnumerable<Organization> Organizacoes
		{
			get
			{
				return _context.Organizations.Include(o => o.SuperiorInstance).Include(o => o.Agents);
			}
		}

		public void Save(Organization organizacao)
		{
			if (organizacao.SectorId == 0)
			{
				_context.Organizations.Add(organizacao);
				_context!.SaveChanges();
			}
			else
			{
				Organization dado = _context.Organizations.Find(organizacao.SectorId);
				if (dado != null)
				{
					dado.Code = organizacao.Code;
					dado.SectorName = organizacao.SectorName;
					dado.Description = organizacao.Description;
					dado.ResponsibleAgentId = organizacao.ResponsibleAgentId;
					dado.SuperiorInstanceId = organizacao.SuperiorInstanceId;

				}
				_context!.SaveChanges();
			}
		}

		public void AddNew(Organization organizacao)
		{
			_context.Organizations.Add(organizacao);
			_context!.SaveChanges();
		}

		public IEnumerable<Organization> ListAll()
		{
			return _context.Organizations.Include(o => o.SuperiorInstance).AsEnumerable();
		}

		public Organization FindBy(int idOrganizacao)
		{
			return Organizacoes.Where(f => f.SectorId == idOrganizacao).First();
		}

		public void Delete(Organization organizacao)
		{
			_context.Organizations.Remove(organizacao);
			_context!.SaveChanges();
		}

		public void ImportList(List<Organization> organizacoes)
		{
			foreach (Organization org in organizacoes)
			{
				AddNew(org);
			}

		}

		public void SaveList(List<Organization> sectors)
		{
			foreach (Organization sector in sectors)
			{
				Save(sector);
			}

		}

		public Organization? FindByCode(string code)
		{
			var organizations = _context.Organizations.Where(f => f.Code == code);

			if (organizations.Any())
			{
				return organizations.FirstOrDefault();
			}
			else
			{
				return null;
			}

		}

	}
}

