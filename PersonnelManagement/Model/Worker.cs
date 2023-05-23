using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagement.Model
{
    public class Worker : BaseEntity
    {
        public string FullName { get; set; }
        public int DepartmentID { get; set; }
        public int PositionID { get; set; }

        public Department Department { get; set; }
        public Position Position { get; set; }
    }
}
