using PersonnelManagement.Model;
using PersonnelManagement.ViewModel;
using System;
using System.Windows;

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
