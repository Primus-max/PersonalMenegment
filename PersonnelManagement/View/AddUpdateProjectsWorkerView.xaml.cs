using PersonnelManagement.Model;
using PersonnelManagement.ViewModel;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace PersonnelManagement.View
{
    /// <summary>
    /// Логика взаимодействия для AddUpdateProjectsWorkerView.xaml
    /// </summary>
    public partial class AddUpdateProjectsWorkerView : Window
    {
        public AddUpdateProjectsWorkerView(DataModel data, ProjectsWorker projectsWorker, string action)
        {
            InitializeComponent();
            AddUpdateProjectsWorkerViewModel model = new AddUpdateProjectsWorkerViewModel(data, projectsWorker, action);
            this.DataContext = model;

            if (model.Close == null)
                model.Close = new Action(this.Close);
        }
    }
}
