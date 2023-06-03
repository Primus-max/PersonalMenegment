using PersonnelManagement.Model;
using PersonnelManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PersonnelManagement
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel model;
        public MainWindow(DataModel data, Users users)
        {
            InitializeComponent();
             model = new MainViewModel(data, users);
            this.DataContext = model;

            Closing += OnWindowClosing;
        }

        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            model.CloseWindowCommand.Execute(null);
        }
    }
}
