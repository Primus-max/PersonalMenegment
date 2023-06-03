using GalaSoft.MvvmLight.Command;
using PersonnelManagement.Model;
using System.Linq;

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

            // Если переданный отдел равен null, создаем новый отдел
            if (department == null)
                Department = new Department();
            else
                Department = department;

            Action = action;
        }

        // Метод, вызываемый при выполнении команды
        public override void Execute()
        {
            // Проверяем, введено ли название отдела
            if (string.IsNullOrWhiteSpace(Department.Title))
            {
                Message("Не введено название");
                return;
            }
           
            // В зависимости от выбранного действия (Добавить или Обновить) выполняем соответствующую операцию
            switch (Action)
            {
                case "Добавить":
                    {
                        // Генерируем уникальный идентификатор для нового отдела
                        Department.Id = _data.Departments.Count() == 0 ? 2 : _data.Departments.Last().Id + 1;
                        _data.Add(Department); // Добавляем новый отдел в модель данных
                    }; break;
                case "Обновить":
                    {
                        _data.Update(Department); // Обновляем информацию об отделе в модели данных
                    }; break;
            }

            Close();
        }

        // Команда, связанная с методом Execute
        public RelayCommand ExcecuteCommand => new RelayCommand(Execute);
    }
}
