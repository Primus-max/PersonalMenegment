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
    }
}
