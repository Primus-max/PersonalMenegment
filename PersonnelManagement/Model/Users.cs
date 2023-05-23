using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagement.Model
{
    public class Users : BaseEntity
    {
        public int WorkerID { get; set; }
        public int RoleID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public Worker Worker { get; set; }
        public Roles Roles { get; set; }
    }
}
