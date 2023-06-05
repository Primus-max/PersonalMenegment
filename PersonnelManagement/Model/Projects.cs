using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        public bool IsActive { get; set; }
        
        public int ProgressBarValue
        {
            get
            {
                DateTime currentDate = DateTime.Now;
                TimeSpan projectDuration = FinishProject - StartProject;
                TimeSpan elapsedDuration = currentDate - StartProject;

                // Вычисляю в процентах сотавшееся время в просцентах
                int progress = (int)((elapsedDuration.TotalDays / projectDuration.TotalDays) * 1000);

                // Убеждаюсь, что значение не выйдет за границы
                return Math.Max(0, Math.Min(progress, 100));
            }
        }
    }
}
