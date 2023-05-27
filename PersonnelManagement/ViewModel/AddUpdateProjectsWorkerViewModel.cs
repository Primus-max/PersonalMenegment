using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using PersonnelManagement.Model;

namespace PersonnelManagement.ViewModel
{
    public class AddUpdateProjectsWorkerViewModel : BaseViewModel
    {
        private ProjectsWorker _projectsWorker;
        private Projects _selectProjects;
        private Worker _selectWorker;

        public ProjectsWorker ProjectsWorker
        {
            get => _projectsWorker;
            set
            {
                _projectsWorker = value;
                OnProperty("ProjectsWorker");
            }
        }

        public ObservableCollection<Projects> Projects
        {
            get => _data.Projects;
        }

        public Projects SelectProjects
        {
            get => _selectProjects;
            set
            {
                _selectProjects = value;
                ProjectsWorker.ProjectsId = value == null ? -1 : value.Id;
                OnProperty("SelectProjects");
            }
        }

        public ObservableCollection<Worker> Workers
        {
            get => _data.Workers;
        }

        public Worker SelectWorker
        {
            get => _selectWorker;
            set
            {
                _selectWorker = value;
                ProjectsWorker.WorkerID = value == null ? -1 : value.Id;
                OnProperty("");
            }
        }

        public AddUpdateProjectsWorkerViewModel(DataModel data, ProjectsWorker projectsWorker, string action)
        {
            _data = data;

            if (projectsWorker == null)
            {
                ProjectsWorker = new ProjectsWorker();
                SelectProjects = Projects != null && Projects.Count > 0 ? Projects[0] : null;
                SelectWorker = Workers != null && Workers.Count > 0 ? Workers[0] : null;
            }
            else
            {
                ProjectsWorker = projectsWorker;
                SelectProjects = projectsWorker.Projects;
                SelectWorker = projectsWorker.Worker;
            }

            Action = action;
        }


        public override void Execute()
        {
            switch (Action)
            {
                case "Добавить":
                    {
                        ProjectsWorker.Id = _data.ProjectsWorkers.Count() == 0 ? 2 : _data.ProjectsWorkers.Last().Id + 1;
                        _data.Add(ProjectsWorker);
                    }; break;
                case "Обновить":
                    {
                        _data.Update(ProjectsWorker);
                    }; break;
            }

            Close();
        }

        public RelayCommand ExecuteCommand => new RelayCommand(Execute);
    }
}
