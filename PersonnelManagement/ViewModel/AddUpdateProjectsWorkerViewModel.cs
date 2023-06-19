using GalaSoft.MvvmLight.Command;
using PersonnelManagement.Model;
using System.Collections.ObjectModel;
using System.Linq;

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
            set => Set(ref _projectsWorker, value);
        }

        // Коллекция проектов
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

        // Коллекция работников
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
                OnProperty("SelectWorker");
            }
        }

        public AddUpdateProjectsWorkerViewModel(DataModel data, ProjectsWorker projectsWorker, string action)
        {
            _data = data;

            // Если переданный объект ProjectsWorker равен null, создаем новый объект ProjectsWorker и устанавливаем начальные значения для SelectProjects и SelectWorker
            if (projectsWorker == null)
            {
                ProjectsWorker = new ProjectsWorker();
                SelectProjects = Projects != null && Projects.Count > 0 ? Projects[0] : null;
                SelectWorker = Workers != null && Workers.Count > 0 ? Workers[0] : null;
            }
            else
            {
                // Иначе используем переданный объект ProjectsWorker и устанавливаем значения для SelectProjects и SelectWorker
                ProjectsWorker = projectsWorker;
                SelectProjects = projectsWorker.Projects;
                SelectWorker = projectsWorker.Worker;
            }

            Action = action;
        }

        // Метод, вызываемый при выполнении команды
        public override void Execute()
        {
            // В зависимости от выбранного действия (Добавить или Обновить) выполняем соответствующую операцию
            switch (Action)
            {
                case "Добавить":
                    {
                        // Генерируем уникальный идентификатор для нового объекта ProjectsWorker
                        ProjectsWorker.Id = _data.ProjectsWorkers.Count() == 0 ? 2 : _data.ProjectsWorkers.Last().Id + 1;

                        _data.Add(ProjectsWorker); // Добавляем новый объект ProjectsWorker в модель данных
                    }; break;
                case "Обновить":
                    {
                        _data.Update(ProjectsWorker); // Обновляем информацию о объекте ProjectsWorker в модели данных
                    }; break;
            }

            Close();
        }

        // Команда, связанная с методом Execute
        public RelayCommand ExecuteCommand => new RelayCommand(Execute);
    }
}
