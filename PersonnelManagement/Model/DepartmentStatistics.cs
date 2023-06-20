using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagement.Model
{
    public class DepartmentStatistics
    {
        public string DepartmentName { get; set; }
        public int EmployeeCount { get; set; }
        public decimal TotalProfit { get; set; }
        public decimal Budget { get; set; }
        public decimal Efficiency { get; set; }
    }
}
