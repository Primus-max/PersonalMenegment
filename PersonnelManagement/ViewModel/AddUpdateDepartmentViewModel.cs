using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using PersonnelManagement.Model;

namespace PersonnelManagement.ViewModel
{
    public class AddUpdateDepartmentViewModel : BaseViewModel
    {
        private Department _department;

        public Department Department
        {
            get => _department;
            set
            {
                _department = value;
                OnProperty("Department");
            }
        }

        public AddUpdateDepartmentViewModel(DataModel data, Department department, string action)
        {
            _data = data;
            if (department == null)
                Department = new Department();
            else Department = department;

            Action = action;
        }

        public override void Execute()
        {
            if(Department.Title == "")
            {
                Message("Не введено название");
                return;
            }

            switch(Action)
            {
                case "Добавить":
                    {
                        Department.Id = _data.Departments.Count() == 0 ? 2 : _data.Departments.Last().Id + 1;
                        _data.Add(Department);
                    }; break;
                case "Обновить":
                    {
                        _data.Update(Department);
                    };break;
            }

            Close();
        }

        public RelayCommand ExcecuteCommand => new RelayCommand(Execute);
    }
}
