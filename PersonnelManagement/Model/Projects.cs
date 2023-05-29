using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagement.Model
{
    public class Projects : BaseEntity
    {
        public string Title { get; set; }
        public DateTime StartProject { get; set; }
        public DateTime FinishProject { get; set; }
        public decimal ProjectBudget { get; set; }
        public string ProjectManager { get; set; }
        public DateTime FinishedDate { get; set; }
        public int IsActive { get; set; }

        public int ProgressBarValue
        {
            get
            {
                DateTime currentDate = DateTime.Now;
                TimeSpan projectDuration = FinishProject - StartProject;
                TimeSpan elapsedDuration = currentDate - StartProject;

                // Calculate the progress as a percentage
                int progress = (int)((elapsedDuration.TotalDays / projectDuration.TotalDays) * 1000);

                // Make sure the progress value is within the valid range of 0-100
                return Math.Max(0, Math.Min(progress, 100));
            }
        }
    }
}
