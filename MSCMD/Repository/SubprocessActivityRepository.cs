using Microsoft.EntityFrameworkCore;
using MSCMD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Repository
{
	public interface ISubprocessActivityRepository
	{
		void AddNew(SubprocessActivity relationship);
		IEnumerable<SubprocessActivity> ListAll();
		IEnumerable<SubprocessActivity> GetByActivity(int activityId);
		IEnumerable<SubprocessActivity> GetBySubprocess(int subprocessId);
		SubprocessActivity GetBySubprocessActivity(int subprocessId, int activityId);
		void Delete(SubprocessActivity relationship);

	}

	public class SubprocessActivityRepository : ISubprocessActivityRepository
	{
		private MscmdContext _context;

		public SubprocessActivityRepository()
		{
			_context = new MscmdContext();

		}

		public IEnumerable<SubprocessActivity> SubprocessActivities
		{
			get { return _context.SubprocessActivities.Include(s => s.Activity).Include(s => s.Subprocess); }
		}


		public void AddNew(SubprocessActivity relationship)
		{

			var rel = SubprocessActivities.Where(f => f.ActivityId == relationship.ActivityId && f.SubprocessId == relationship.SubprocessId);

			if (rel == null || rel.ToList().Count == 0)
			{
				_context.SubprocessActivities.Add(relationship);
				_context.SaveChanges();
			}
			
		}

		public IEnumerable<SubprocessActivity> ListAll()
		{
			return _context.SubprocessActivities.AsEnumerable();
		}

		public IEnumerable<SubprocessActivity> GetByActivity(int activityId)
		{
			return SubprocessActivities.Where(f => f.ActivityId == activityId);
		}

		public IEnumerable<SubprocessActivity> GetBySubprocess(int subprocessId)
		{
			return SubprocessActivities.Where(f => f.SubprocessId == subprocessId);
		}

		public SubprocessActivity GetBySubprocessActivity(int subprocessId, int activityId)
		{
			return SubprocessActivities.Where(f => f.SubprocessId == subprocessId && f.ActivityId == activityId).First();
		}

		public void Delete(SubprocessActivity relationship)
		{
			_context.SubprocessActivities.Remove(relationship);
			_context!.SaveChanges();
		}

	}
}

