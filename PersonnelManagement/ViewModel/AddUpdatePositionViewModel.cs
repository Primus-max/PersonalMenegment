using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using PersonnelManagement.Model;

namespace PersonnelManagement.ViewModel
{
    public class AddUpdatePositionViewModel : BaseViewModel
    {
        private Position _position;
        
        public Position Position
        {
            get => _position;
            set
            {
                _position = value;
                OnProperty("Position");
            }
        }

        public AddUpdatePositionViewModel(DataModel data, Position position, string action)
        {
            _data = data;
            if (position == null)
                Position = new Position();
            else Position = position;

            Action = action;
        }

        public override void Execute()
        {
            if(Position.Title == "")
            {
                Message("Не введено название");
                return;
            }

            switch (Action)
            {
                case "Добавить":
                    {
                        Position.Id = _data.Positions.Count() == 0 ? 2 : _data.Positions.Last().Id + 1;
                        _data.Add(Position);
                    }; break;
                case "Обновить":
                    {
                        _data.Update(Position);
                    }; break;
            }

            Close();
        }

        public RelayCommand ExecuteCommand => new RelayCommand(Execute);
    }
}
