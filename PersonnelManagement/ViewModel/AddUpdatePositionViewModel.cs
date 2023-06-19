using System;
using GalaSoft.MvvmLight.Command;
using PersonnelManagement.Model;
using System.Linq;

namespace PersonnelManagement.ViewModel
{
    public class AddUpdatePositionViewModel : BaseViewModel
    {
        private Position _position;

        public Position Position
        {
            get => _position;
            set => Set(ref _position, value);
        }

        public AddUpdatePositionViewModel(DataModel data, Position position, string action)
        {
            _data = data;

            // Если переданная должность равна null, создаем новую должность
            if (position == null)
                Position = new Position();
            else
                Position = position;

            Action = action;
        }

        // Метод, вызываемый при выполнении команды
        public override void Execute()
        {
            // Проверяем, введено ли название должности и зарплата           
            if (String.IsNullOrWhiteSpace(Position.Title))
            {
                Message("Не введено название");                
                return;
            }
            if (Position.Salary == 0)
            {
                Message("Укажите зарплату для этой должности");
                return;
            }

            // В зависимости от выбранного действия (Добавить или Обновить) выполняем соответствующую операцию
            switch (Action)
            {
                case "Добавить":
                    {
                        // Генерируем уникальный идентификатор для новой должности
                        Position.Id = _data.Positions.Count() == 0 ? 2 : _data.Positions.Last().Id + 1;
                        _data.Add(Position); // Добавляем новую должность в модель данных
                    }; break;
                case "Обновить":
                    {
                        _data.Update(Position); // Обновляем информацию о должности в модели данных
                    }; break;
            }

            Close();
        }

        // Команда, связанная с методом Execute
        public RelayCommand ExecuteCommand => new RelayCommand(Execute);
    }
}
