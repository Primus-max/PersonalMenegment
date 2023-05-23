using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagement.Model
{
    public class ProjectsWorker : BaseEntity
    {
        public int ProjectsId { get; set; }
        public int WorkerID { get; set; }

        public Projects Projects { get; set; }
        public Worker Worker { get; set; }
    }
}
