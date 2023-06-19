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
    public class AddUpdateWorkerViewModel : BaseViewModel
    {
        private Worker _worker;
        private Department _selectDepartment;
        private Position _selectPosition;
        private DateTime _selectDateOfHire = DateTime.Now;

        public Worker Worker
        {
            get => _worker;
            set => Set(ref _worker, value);
        }

        public ObservableCollection<Department> Departments
        {
            get => _data.Departments;
        }

        public Department SelectDepartment
        {
            get => _selectDepartment;
            set
            {
                if (Set(ref _selectDepartment, value))
                {
                    _selectDepartment = value;
                    Worker.DepartmentID = value == null ? -1 : value.Id;
                }                
            }
        }

        public ObservableCollection<Position> Positions
        {
            get => _data.Positions;
        }

        public Position SelectPosition
        {
            get => _selectPosition;
            set
            {
                if (Set(ref _selectPosition, value))
                {
                    _selectPosition = value;
                    Worker.PositionID = value == null ? -1 : value.Id;
                }               
            }
        }

        public DateTime SelectDateOfHire
        {
            get => _selectDateOfHire;
            set => Set(ref _selectDateOfHire, value);
            
        }

        public AddUpdateWorkerViewModel(DataModel data, Worker worker, string action)
        {
            _data = data;

            if (worker == null)
            {
                Worker = new Worker();
                SelectDepartment = Departments != null && Departments.Count > 0 ? Departments[0] : null;
                SelectPosition = Positions != null && Positions.Count > 0 ? Positions[0] : null;
            }
            else
            {
                Worker = worker;
                SelectDepartment = worker.Department;
                SelectPosition = worker.Position;
                SelectDateOfHire = worker.DateOfHire;
            }

            Action = action;
        }


        public override void Execute()
        {
            // Проверка на коореткно введённые данные
            if(string.IsNullOrWhiteSpace(Worker.FullName))
            {
                Message("Не введено ФИО");
                return;
            }

            switch (Action)
            {
                case "Добавить":
                    {
                        Worker.Id = _data.Workers.Count() == 0 ? 2 : _data.Workers.Last().Id + 1;
                        Worker.DateOfHire = SelectDateOfHire;
                        _data.Add(Worker);
                    }; break;
                case "Обновить":
                    {
                        Worker.DateOfHire = SelectDateOfHire;
                        _data.Update(Worker);
                    }; break;
            }

            Close();
        }

        public RelayCommand ExecuteCommand => new RelayCommand(Execute);
    }
}
