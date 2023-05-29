using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using PersonnelManagement.Model;

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

        public AddUpdateProjectsViewModel(DataModel data, Projects projects, string action)
        {
            _data = data;
            if (projects == null)
                Projects = new Projects();
            else Projects = projects;

            Action = action;
        }

        public override void Execute()
        {
            if(Projects.Title == "")
            {
                Message("Не введено название");
                return; 
            }

            switch (Action)
            {
                case "Добавить":
                    {
                        Projects.Id = _data.Projects.Count() == 0 ? 2 : _data.Projects.Last().Id + 1;
                        Projects.StartProject = SelectedStartDate;
                        Projects.FinishProject = SelectedFinishDate;
                        _data.Add(Projects);
                    }; break;
                case "Обновить":
                    {
                        Projects.StartProject = SelectedStartDate;
                        Projects.FinishProject = SelectedFinishDate;
                        _data.Update(Projects);
                    }; break;
            }

            Close();
        }

        public RelayCommand ExecuteCommand => new RelayCommand(Execute);
    }
}
