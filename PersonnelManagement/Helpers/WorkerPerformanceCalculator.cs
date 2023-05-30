using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.ObjectModel;
using System.Linq;
using PersonnelManagement.Model;


namespace PersonnelManagement.Helpers
{

    public class WorkerPerformanceCalculator
    {
        public ObservableCollection<Projects> Projects { get; }
        public ObservableCollection<Department> Departments { get; }

        public WorkerPerformanceCalculator(ObservableCollection<Projects> projects, ObservableCollection<Department> departments)
        {
            Projects = projects;
            Departments = departments;
        }

        public ObservableCollection<WorkerStatistic> CalculateWorkerPerformance()
        {
            ObservableCollection<WorkerStatistic> workerStatistics = new ObservableCollection<WorkerStatistic>();

            foreach (var project in Projects)
            {
                decimal totalBudget = 0;
                decimal workerSalary = 0;
                int projectsCompletedBeforeDeadline = 0;

                // Перебираем все проекты работника
                // Вычисляем общий бюджет и количество проектов, выполненных до срока
                totalBudget += project.ProjectBudget;

                if (project.FinishedDate < project.FinishProject)
                {
                    projectsCompletedBeforeDeadline++;
                }

                // Находим отдел сотрудника
                Department workerDepartment = Departments.FirstOrDefault(d => d.Title == project.ProjectManager);

                if (workerDepartment != null && workerDepartment.EmployeesCount > 0)
                {
                    // Вычисляем зарплату сотрудника
                    workerSalary = totalBudget / workerDepartment.EmployeesCount;
                }

                // Вычисляем продуктивность работника
                decimal productivity = projectsCompletedBeforeDeadline > 0 ? (decimal)projectsCompletedBeforeDeadline / Projects.Count : 0;

                // Вычисляем значение продуктивности в процентах
                int progress = (int)(productivity * 100);

                // Создаем объект WorkerStatistic и добавляем его в коллекцию
                WorkerStatistic statistic = new WorkerStatistic
                {
                    FullName = project.ProjectManager,
                    Department = workerDepartment?.Title ?? "Unknown",
                    Progress = progress
                };

                workerStatistics.Add(statistic);
            }

            return workerStatistics;
        }
    }
}
