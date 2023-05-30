using GalaSoft.MvvmLight.Command;
using PersonnelManagement.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace PersonnelManagement.ViewModel
{
    public class AddUpdateProjectsViewModel : BaseViewModel
    {
        private Projects _projects;
        public Projects Projects
        {
            get => _projects;
            set
            {
                _projects = value;
                OnProperty("Projects");
            }
        }

        // Дата начала проекта
        private DateTime _selectedStartDate = DateTime.Now;
        public DateTime SelectedStartDate
        {
            get => _selectedStartDate;
            set
            {
                _selectedStartDate = value;
                OnProperty("SelectStartDate");
            }
        }

        // Дата окончания проекта
        private DateTime _selectedFinishDate = DateTime.Now;
        public DateTime SelectedFinishDate
        {
            get => _selectedFinishDate;
            set
            {
                _selectedFinishDate = value;
                OnProperty("SelectStartDate");
            }
        }

        private Worker _selectWorker;
        public Worker SelectWorker
        {
            get => _selectWorker;
            set
            {
                _selectWorker = value;
                OnProperty("SelectWorker");
            }
        }

        public ObservableCollection<Worker> Workers
        {
            get => _data.Workers;
        }

        public AddUpdateProjectsViewModel(DataModel data, Projects projects, string action)
        {
            _data = data;

            // Если переданный проект равен null, создаем новый проект
            if (projects == null)
                Projects = new Projects();
            else
                Projects = projects;

            Action = action;
        }

        // Метод, вызываемый при выполнении команды
        public override void Execute()
        {
            // Проверяем, было ли введено название проекта
            if (Projects.Title == "")
            {
                Message("Не введено название");
                return;
            }

            // В зависимости от выбранного действия (Добавить или Обновить) выполняем соответствующую операцию
            switch (Action)
            {
                case "Добавить":
                    {
                        // Генерируем уникальный идентификатор для нового проекта
                        Projects.Id = _data.Projects.Count() == 0 ? 2 : _data.Projects.Last().Id + 1;

                        // Присваиваем выбранные значения даты начала и окончания проекта, а также выбранного менеджера проекта
                        Projects.StartProject = SelectedStartDate;
                        Projects.FinishProject = SelectedFinishDate;
                        Projects.ProjectManager = SelectWorker.FullName;

                        _data.Add(Projects); // Добавляем новый проект в модель данных
                    }; break;
                case "Обновить":
                    {
                        // Присваиваем выбранные значения даты начала и окончания проекта, а также выбранного менеджера проекта
                        Projects.StartProject = SelectedStartDate;
                        Projects.FinishProject = SelectedFinishDate;
                        Projects.ProjectManager = SelectWorker.FullName;

                        _data.Update(Projects); // Обновляем информацию о проекте в модели данных
                    }; break;
            }

            Close(); 
        }

        // Команда, связанная с методом Execute
        public RelayCommand ExecuteCommand => new RelayCommand(Execute);
    }
}
