using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO добавить поля количества сотрудников на должности и бюджет на всех сотрудников в одной должности

namespace PersonnelManagement.Model
{    
    public class Position : BaseEntity
    {
        public string Title { get; set; }   
        public decimal Salary { get; set; }
    }
}
