using GalaSoft.MvvmLight.Command;
using PersonnelManagement.Model;
using PersonnelManagement.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PersonnelManagement.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private Users _users2;
        #region private Collection
        private ObservableCollection<Department> _departments;
        private ObservableCollection<Position> _positions;
        private ObservableCollection<Projects> _projects;
        private ObservableCollection<ProjectsWorker> _projectsWorkers;
        private ObservableCollection<Users> _users;
        private ObservableCollection<Worker> _workers;
        private ObservableCollection<ProjectsWorker> _userProject;
        #endregion

        #region private Select
        private Department _selectDepartment;
        private Position _selectPosition;
        private Projects _selectProjects;
        private ProjectsWorker _selectProjectsWorker;
        private Users _selectUsers;
        private Worker _selectWorker;      
        #endregion

        #region public Collection
        public ObservableCollection<Department> Departments
        {
            get => _departments;
            set
            {
                _departments = value;
                OnProperty("Departments");
            }
        }
        public ObservableCollection<Position> Positions
        {
            get => _positions;
            set
            {
                _positions = value;
                OnProperty("Positions");
            }
        }
        public ObservableCollection<Projects> Projects
        {
            get => _projects;
            set
            {
                _projects = value;
                OnProperty("Projects");
            }
        }
        public ObservableCollection<ProjectsWorker> ProjectsWorkers
        {
            get => _projectsWorkers;
            set
            {
                _projectsWorkers = value;
                OnProperty("ProjectsWorkers");
            }
        }
        public ObservableCollection<Users> Users
        {
            get => _users; 
            set
            {
                _users = value;
                OnProperty("Users");
            }
        }
        public ObservableCollection<Worker> Workers
        {
            get => _workers; 
            set
            {
                _workers = value;
                OnProperty("Workers");
            }
        }
        public ObservableCollection<ProjectsWorker> UserProject
        {
            get => _userProject;
            set
            {
                _userProject = value;
                OnProperty("UserProject");
            }
        }
        #endregion

        #region public Select
        public Department SelectDepartment
        {
            get => _selectDepartment;
            set
            {
                _selectDepartment = value;
                OnProperty("SelectDepartment");
            }
        }
        public Position SelectPosition
        {
            get => _selectPosition;
            set
            {
                _selectPosition = value;
                OnProperty("SelectPosition");
            }
        }
        public Projects SelectProjects
        {
            get => _selectProjects; 
            set
            {
                _selectProjects = value;
                OnProperty("SelectProjects");
            }
        }
        public ProjectsWorker SelectProjectsWorker
        {
            get => _selectProjectsWorker;
            set
            {
                _selectProjectsWorker = value;
                OnProperty("SelectProjectsWorker");
            }
        }
        public Users SelectUsers
        {
            get => _selectUsers;
            set
            {
                _selectUsers = value;
                OnProperty("SelectUsers");
            }
        }
        public Worker SelectWorkers
        {
            get => _selectWorker;
            set
            {
                _selectWorker = value;
                OnProperty("SelectWorkers");
            }
        }       
        #endregion

        #region Visibility
        private Visibility _isAdmin = Visibility.Collapsed;
        private Visibility _isUser = Visibility.Visible;

        public Visibility IsAdmin
        {
            get => _isAdmin;
            set
            {
                _isAdmin = value;
                OnProperty("IsAdmin");
            }
        }

        public Visibility IsUser
        {
            get => _isUser;
            set
            {
                _isUser = value;
                OnProperty("IsUser");
            }
        }
        #endregion

        public Users InputUsers
        {
            get => _users2;
            
            set
            {
                _users2 = value;
                OnProperty("InputUsers");
            }
        }

        public MainViewModel(DataModel data, Users users)
        {
            _data = data;


            if(true)
            {
                IsAdmin = Visibility.Visible;
                IsUser = Visibility.Collapsed;

                Departments = _data.Departments;
                Positions = _data.Positions;
                Projects = _data.Projects;
                ProjectsWorkers = _data.ProjectsWorkers;
                Users = _data.Users;
                Workers = _data.Workers;                
            }
            else
            {
                IsAdmin = Visibility.Collapsed;
                IsUser = Visibility.Visible;
                InputUsers = users;
                UserProject = new ObservableCollection<ProjectsWorker>(_data.ProjectsWorkers.Where(x => x.WorkerID == users.Worker.Id).ToList());
            }

            var dep = Workers;
        }

        #region Department
        public void AddDepartment()
        {
            AddUpdateDepartmentView add = new AddUpdateDepartmentView(_data, null, "Добавить");
            add.ShowDialog();

            Departments = _data.Departments;
        }

        public void UpdateDepartment()
        {
            if(SelectDepartment == null)
            {
                Message("Отдел не выбран");
                return;
            }

            AddUpdateDepartmentView update = new AddUpdateDepartmentView(_data, SelectDepartment, "Обновить");
            update.ShowDialog();

            Departments = _data.Departments;
            Users = _data.Users;
        }

        public void RemoveDepartment()
        {
            if (SelectDepartment == null)
            {
                Message("Отдел не выбран");
                return;
            }

            List<Worker> temp = _data.Workers.Where(x => x.DepartmentID == SelectDepartment.Id).ToList();
            temp.ForEach(x => RemoveWorker(x));

            _data.Remove(SelectDepartment);

            Departments = _data.Departments;
            Users = _data.Users;
        }
        #endregion

        #region Position
        public void AddPosition()
        {
            AddUpdatePositionView add = new AddUpdatePositionView(_data, null, "Добавить");
            add.ShowDialog();

            Positions = _data.Positions;
        }

        public void UpdatePosition()
        {
            if(SelectPosition == null)
            {
                Message("Должность не выбрана");
                return;
            }

            AddUpdatePositionView update = new AddUpdatePositionView(_data, SelectPosition, "Обновить");
            update.ShowDialog();

            Positions = _data.Positions;
            Users = _data.Users;
        }

        public void RemovePosition()
        {
            if (SelectPosition == null)
            {
                Message("Должность не выбрана");
                return;
            }

            List<Worker> temp = _data.Workers.Where(x => x.PositionID == SelectPosition.Id).ToList();
            temp.ForEach(x => RemoveWorker(x));

            _data.Remove(SelectPosition);

            Positions = _data.Positions;
            Users = _data.Users;
        }
        #endregion

        #region Projects
        public void AddProjects()
        {
            AddUpdateProjectsView add = new AddUpdateProjectsView(_data, null, "Добавить");
            add.ShowDialog();

            Projects = _data.Projects;
        }

        public void UpdateProjects()
        {
            if (SelectProjects == null)
            {
                Message("Не выбран проект");
                return;
            }

            AddUpdateProjectsView update = new AddUpdateProjectsView(_data, SelectProjects, "Обновить");
            update.ShowDialog();

            Projects = _data.Projects;
            ProjectsWorkers = _data.ProjectsWorkers;
        }

        public void RemoveProjects()
        {
            if (SelectProjects == null)
            {
                Message("Не выбран проект");
                return;
            }

            List<ProjectsWorker> temp = _data.ProjectsWorkers.Where(x => x.ProjectsId == SelectProjects.Id).ToList();
            temp.ForEach(x => RemoveProjectsWorker(x));

            _data.Remove(SelectProjects);

            Projects = _data.Projects;
            ProjectsWorkers = _data.ProjectsWorkers;
        }
        #endregion

        #region ProjectsWorker
        public void AddProjectsWorker()
        {
            AddUpdateProjectsWorkerView add = new AddUpdateProjectsWorkerView(_data, null, "Добавить");
            add.ShowDialog();

            ProjectsWorkers = _data.ProjectsWorkers;
        }

        public void UpdateProjectsWorker()
        {
            if(SelectProjectsWorker == null)
            {
                Message("Проект сотрудника не выбран");
                return;
            }

            AddUpdateProjectsWorkerView update = new AddUpdateProjectsWorkerView(_data, SelectProjectsWorker, "Обновить");
            update.ShowDialog();

            ProjectsWorkers = _data.ProjectsWorkers;
        }

        public void RemoveProjectsWorker()
        {
            if (SelectProjectsWorker == null)
            {
                Message("Проект сотрудника не выбран");
                return;
            }

            _data.Remove(SelectProjectsWorker);

            ProjectsWorkers = _data.ProjectsWorkers;
        }

        public void RemoveProjectsWorker(ProjectsWorker projectsWorker)
        {
            _data.Remove(projectsWorker);

            ProjectsWorkers = _data.ProjectsWorkers;
        }
        #endregion

        #region User
        public void AddUser()
        {
            AddUpdateUserView add = new AddUpdateUserView(_data, null, "Добавить");
            add.ShowDialog();

            Users = _data.Users;
        }

        public void UpdateUser()
        {
            if (SelectUsers == null)
            {
                Message("Не выбран пользователь");
                return;
            }

            AddUpdateUserView update = new AddUpdateUserView(_data, SelectUsers, "Обновить");
            update.ShowDialog();

            Users = _data.Users;
        }

        public void RemoveUser()
        {
            if (SelectUsers == null)
            {
                Message("Не выбран пользователь");
                return;
            }

            _data.Remove(SelectUsers);
        }

        public void RemoveUser(Users users)
        {
            _data.Remove(users);

            Users = _data.Users;
        }
        #endregion

        #region Worker
        public void AddWorker()
        {
            AddUpdateWorkerView add = new AddUpdateWorkerView(_data, null, "Добавить");
            add.ShowDialog();

            Workers = _data.Workers;
        }

        public void UpdateWorker()
        {
            if(SelectWorkers == null)
            {
                Message("Сотрудник не выбран");
                return;
            }

            AddUpdateWorkerView update = new AddUpdateWorkerView(_data, SelectWorkers, "Обновить");
            update.ShowDialog();

            Workers = _data.Workers;
            ProjectsWorkers = _data.ProjectsWorkers;
            Users = _data.Users;
        }

        public void RemoveWorker()
        {
            if(SelectWorkers == null)
            {
                Message("Сотрудник не выбран");
                return;
            }

            List<Users> users = _data.Users.Where(x => x.WorkerID == SelectWorkers.Id).ToList();
            List<ProjectsWorker> projectsWorkers = _data.ProjectsWorkers.Where(x => x.WorkerID == SelectWorkers.Id).ToList();

            users.ForEach(x => RemoveUser(x));
            projectsWorkers.ForEach(x => RemoveProjectsWorker(x));

            _data.Remove(SelectWorkers);

            Workers = _data.Workers;
            ProjectsWorkers = _data.ProjectsWorkers;
            Users = _data.Users;
        }

        public void RemoveWorker(Worker worker)
        {
            List<Users> users = _data.Users.Where(x => x.WorkerID == worker.Id).ToList();
            List<ProjectsWorker> projectsWorkers = _data.ProjectsWorkers.Where(x => x.WorkerID == worker.Id).ToList();

            users.ForEach(x => RemoveUser(x));
            projectsWorkers.ForEach(x => RemoveProjectsWorker(x));

            _data.Remove(worker);

            Workers = _data.Workers;
            ProjectsWorkers = _data.ProjectsWorkers;
            Users = _data.Users;
        }
        #endregion

        public RelayCommand AddDepartmentCommand => new RelayCommand(AddDepartment);
        public RelayCommand UpdateDepartmentCommand => new RelayCommand(UpdateDepartment);
        public RelayCommand RemoveDepartmentCommand => new RelayCommand(RemoveDepartment);

        public RelayCommand AddPositionCommand => new RelayCommand(AddPosition);
        public RelayCommand UpdatePositionCommand => new RelayCommand(UpdatePosition);
        public RelayCommand RemovePositionCommand => new RelayCommand(RemovePosition);

        public RelayCommand AddProjectsCommand => new RelayCommand(AddProjects);
        public RelayCommand UpdateProjectsCommand => new RelayCommand(UpdateProjects);
        public RelayCommand RemoveProjectsCommand => new RelayCommand(RemoveProjects);

        public RelayCommand AddProjectsWorkerCommand => new RelayCommand(AddProjectsWorker);
        public RelayCommand UpdateProjectsWorkerCommand => new RelayCommand(UpdateProjectsWorker);
        public RelayCommand RemoveProjectsWorkerCommand => new RelayCommand(RemoveProjectsWorker);

        public RelayCommand AddUserCommand => new RelayCommand(AddUser);
        public RelayCommand UpdateUserCommand => new RelayCommand(UpdateUser);
        public RelayCommand RemoveUserCommand => new RelayCommand(RemoveUser);

        public RelayCommand AddWorkerCommand => new RelayCommand(AddWorker);
        public RelayCommand UpdateWorkerCommand => new RelayCommand(UpdateWorker);
        public RelayCommand RemoveWorkerCommand => new RelayCommand(RemoveWorker);
    }
}
