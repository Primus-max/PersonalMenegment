using PersonnelManagement.Model.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagement.Model
{
    public class DataModel
    {
        private ChangeDB _changeDB;

        public ObservableCollection<Department> Departments { get; set; }
        public ObservableCollection<Position> Positions { get; set; }
        public ObservableCollection<Projects> Projects { get; set; }
        public ObservableCollection<ProjectsWorker> ProjectsWorkers { get; set; }
        public ObservableCollection<Roles> Roles { get; set; }
        public ObservableCollection<Users> Users { get; set; }
        public ObservableCollection<Worker> Workers { get; set; }

        public DataModel()
        {
            _changeDB = new ChangeDB();
            Initial();
        }

        public void Initial()
        {
            Departments = _changeDB.GetDepartment();
            Positions = _changeDB.GetPosition();
            Projects = _changeDB.GetProjects();
            ProjectsWorkers = _changeDB.GetProjectsWorker();
            Roles = _changeDB.GetRoles();           
            Users = _changeDB.GetUsers();
            Workers = _changeDB.GetWorker();

            ProjectsWorkers.ToList().ForEach(x => x.Projects = Projects.Where(y => x.ProjectsId == y.Id).FirstOrDefault());
            ProjectsWorkers.ToList().ForEach(x => x.Worker = Workers.Where(y => x.WorkerID == y.Id).FirstOrDefault());

            Users.ToList().ForEach(x => x.Worker = Workers.Where(y => x.WorkerID == y.Id).FirstOrDefault());
            Users.ToList().ForEach(x => x.Roles = Roles.Where(y => x.RoleID == y.Id).FirstOrDefault());

            Workers.ToList().ForEach(x => x.Department = Departments.Where(y => x.DepartmentID == y.Id).FirstOrDefault());
            Workers.ToList().ForEach(x => x.Position = Positions.Where(y => x.PositionID == y.Id).FirstOrDefault());
        }

        public void Add(BaseEntity baseEntity)
        {
            _changeDB.AddAll(baseEntity);
            Initial();
        }

        public void Update(BaseEntity baseEntity)
        {
            _changeDB.UpdateAll(baseEntity);
            Initial();
        }

        public void Remove(BaseEntity baseEntity)
        {
            _changeDB.RemoveAll(baseEntity);
            Initial();
        }
    }
}
