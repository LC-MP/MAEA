using Microsoft.EntityFrameworkCore;
using MSCMD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Repository
{
	
	public interface IProjectRepository
	{
		void AddNew(Project project);
		void Save(Project project);
		IEnumerable<Project> ListarTodos();
		Project FindBy(int projectId);
		void Delete(Project project);
	}

	public class ProjectRepository : IProjectRepository
	{
		private MscmdContext _context;

		public ProjectRepository(MscmdContext context)
		{
			_context = context;
		}

		public IEnumerable<Project> Projects
		{
			get
			{
				return _context.Projects.Include(o => o.ResponsibleAgent).Include(o => o.PromoterSector);
			}
		}

		public void Save(Project project)
		{
			if (project.projectId == 0)
			{
				_context.Projects.Add(project);
				_context!.SaveChanges();
			}
			else
			{
				Project dado = _context.Projects.Find(project.projectId);
				if (dado != null)
				{
					dado.Code = project.Code;
					dado.Name = project.Name;
					dado.Description = project.Description;
					dado.Start = project.Start;
					dado.End = project.End;
					dado.AgentId = project.AgentId;
					dado.OrganizationId = project.OrganizationId;
					dado.Team = project.Team;

				}
				_context!.SaveChanges();
			}
		}

		public void AddNew(Project project)
		{
			_context.Projects.Add(project);
			_context!.SaveChanges();
		}

		public IEnumerable<Project> ListarTodos()
		{
			return Projects.AsEnumerable();
		}

		public Project GetProject()
		{
			if (Projects.ToList().Count > 0)
			{
				return Projects.AsEnumerable().First();
			}
			return null;
		}

		public Project FindBy(int projectId)
		{
			return Projects.Where(f => f.projectId == projectId).First();
		}

		public void Delete(Project project)
		{
			_context.Projects.Remove(project);
			_context!.SaveChanges();
		}

		public void ImportList(List<Project> projects)
		{
			foreach (Project p in projects)
			{
				AddNew(p);
			}

		}

	}
}