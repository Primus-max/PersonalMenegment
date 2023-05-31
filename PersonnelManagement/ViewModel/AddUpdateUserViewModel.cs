using GalaSoft.MvvmLight.Command;
using PersonnelManagement.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace PersonnelManagement.ViewModel
{
    public class AddUpdateUserViewModel : BaseViewModel
    {
        private Users _users;
        private Worker _selectWorker;
        private Roles _selectRole;

        public Users Users
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
            get => _data.Workers;
        }

        public Worker SelectWorker
        {
            get => _selectWorker;
            set
            {
                _selectWorker = value;
                Users.WorkerID = value == null ? -1 : value.Id;
                OnProperty("SelectWorker");
            }
        }

        public ObservableCollection<Roles> Roles
        {
            get => _data.Roles;
        }

        public Roles SelectRoles
        {
            get => _selectRole;
            set
            {
                _selectRole = value;
                Users.RoleID = value == null ? -1 : value.Id;
                OnProperty("SelectRoles");
            }
        }

        public AddUpdateUserViewModel(DataModel data, Users user, string action)
        {
            _data = data;

            if (user == null)
            {
                Users = new Users();
                SelectWorker = Workers != null && Workers.Count > 0 ? Workers[0] : null;
                SelectRoles = Roles != null && Roles.Count > 0 ? Roles[0] : null;
            }
            else
            {
                Users = user;
                SelectWorker = user.Worker;
                SelectRoles = Roles != null && Roles.Count > 0 ? Roles[0] : null;
            }

            Action = action;
        }


        public override void Execute()
        {
            if (string.IsNullOrWhiteSpace(Users.Login) || string.IsNullOrWhiteSpace(Users.Password))
            {
                Message("Не все поля заполнены");
                return;
            }

            switch (Action)
            {
                case "Добавить":
                    {
                        Users.Id = _data.Users.Count() == 0 ? 2 : _data.Users.Last().Id + 1;
                        _data.Add(Users);
                    }; break;
                case "Обновить":
                    {
                        _data.Update(Users);
                    }; break;
            }

            Close();
        }

        public RelayCommand ExecuteCommand => new RelayCommand(Execute);
    }
}
