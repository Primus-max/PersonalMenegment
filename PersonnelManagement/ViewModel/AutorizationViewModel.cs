using GalaSoft.MvvmLight.Command;
using PersonnelManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagement.ViewModel
{
    public class AutorizationViewModel : BaseViewModel
    {
        private Users _user;
        public Users User
        {
            get => _user;
            set => Set(ref _user, value);
        }

        public Action Hide { get; set; }
        public Action Show { get; set; }

        public AutorizationViewModel()
        {
            _data = new DataModel();
            User = new Users();
        }

        public override void Execute()
        {
            if (User.Login == "" || User.Password == "")
            {
                Message("Не все поля заполнены");
                return;
            }

            Users temp = _data.Users.Where(x => x.Login == User.Login && x.Password == User.Password).FirstOrDefault();
            //Users temp = new Users();
            if (temp == null)
            {
                Message("Неправильный логин или пароль");
                return;
            }

            temp.IsUserAcrive = true;
            _data.Update(temp);
            

            Hide();
            MainWindow main = new MainWindow(_data, temp);
            main.ShowDialog();
            Show();
        }

        public RelayCommand ExecuteCommand => new RelayCommand(Execute);
    }
}
