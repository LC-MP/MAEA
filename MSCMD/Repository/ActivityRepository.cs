using Microsoft.EntityFrameworkCore;
using MSCMD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCMD.Repository
{
	public interface IActivityRepository
	{
		void AddNew(Activity activity);
		void Save(Activity activity);
		IEnumerable<Activity> ListAll();
		Activity FindBy(int activityId);

		Activity? FindByCode(string activityCode);
		void Delete(Activity activity);
	}

	public class ActivityRepository : IActivityRepository
	{
		private MscmdContext _context;

		public ActivityRepository(MscmdContext context)
		{
			_context = context;
		}

		public IEnumerable<Activity> Activities
		{
			get
			{
				return _context.Activities.Include(a => a.Subprocesses);
			}
		}

		public void Save(Activity activity)
		{
			if (activity.ActivityId == 0)
			{
				_context.Activities.Add(activity);
				_context!.SaveChanges();
			}
			else
			{
				Activity dado = _context.Activities.Find(activity.ActivityId);
				if (dado != null)
				{
					dado.ActivityCode = activity.ActivityCode;
					dado.ActivityName = activity.ActivityName;
					dado.ActivityDescription = activity.ActivityDescription;
					dado.Periodicity1 = activity.Periodicity1;
					dado.Periodicity2 = activity.Periodicity2;
					dado.Duration = activity.Duration;
					dado.RequiredCompetence = activity.RequiredCompetence;

				}
				_context!.SaveChanges();
			}
		}

		public void AddNew(Activity atividade)
		{
			_context.Activities.Add(atividade);
			_context!.SaveChanges();
		}

		public IEnumerable<Activity> ListAll()
		{
			return Activities.AsEnumerable();
		}

		public Activity FindBy(int ActivityId)
		{
			return Activities.Where(f => f.ActivityId == ActivityId).First();
		}

		public Activity? FindByCode(string ActivityCode)
		{
			var activities = Activities.Where(f => f.ActivityCode == ActivityCode);

			if (activities.Any())
			{
				return activities.FirstOrDefault();
			}
			else
			{
				return null;
			}

		}

		public void Delete(Activity activity)
		{
			_context.Activities.Remove(activity);
			_context!.SaveChanges();
		}

		public void ImportList(List<Activity> activities)
		{
			foreach (Activity activ in activities)
			{
				AddNew(activ);
			}

		}

		public void SaveList(List<Activity> activities)
		{
			foreach (Activity activ in activities)
			{
				Save(activ);
			}

		}


	}
}