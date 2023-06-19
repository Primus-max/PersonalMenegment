using PersonnelManagement.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;



namespace PersonnelManagement.Helpers
{
    public class WorkerPerformanceCalculator
    {
        public ObservableCollection<Projects> Projects { get; }
        public ObservableCollection<Department> Departments { get; }
        public ObservableCollection<Worker> Workers { get; }

        public WorkerPerformanceCalculator(ObservableCollection<Projects> projects, ObservableCollection<Department> departments, ObservableCollection<Worker> workers)
        {
            Projects = projects;
            Departments = departments;
            Workers = workers;
        }

        public ObservableCollection<WorkerStatistic> CalculateWorkerPerformance()
        {
            ObservableCollection<WorkerStatistic> workerStatistics = new ObservableCollection<WorkerStatistic>();

            foreach (var project in Projects)
            {
                // Находим сотрудника по имени
                Worker worker = Workers.FirstOrDefault(w => w.FullName == project.ProjectManager);

                if (worker != null)
                {
                    // Находим отдел сотрудника
                    Department workerDepartment = Departments.FirstOrDefault(d => d.Title == worker.Department?.Title);

                    if (workerDepartment != null && workerDepartment.EmployeesCount > 0)
                    {
                        // Вычисляем прогресс проекта
                        DateTime currentDate = DateTime.Now;
                        TimeSpan projectDuration = project.FinishProject - project.StartProject;
                        TimeSpan elapsedDuration = currentDate - project.StartProject;
                        double progress = Math.Max(0, Math.Min(elapsedDuration.TotalDays / projectDuration.TotalDays, 1));

                        // Проверяем, существует ли уже запись о сотруднике в статистике
                        WorkerStatistic existingStatistic = workerStatistics.FirstOrDefault(s => s.FullName == worker.FullName);

                        if (existingStatistic != null)
                        {
                            // Обновляем прогресс существующей записи
                            existingStatistic.Progress += (int)(progress * 100);
                        }
                        else
                        {
                            // Создаем новую запись в статистике
                            WorkerStatistic statistic = new WorkerStatistic
                            {
                                FullName = worker.FullName,
                                Department = workerDepartment?.Title ?? "Unknown",
                                Progress = (int)(progress * 100)
                            };

                            workerStatistics.Add(statistic);
                        }
                    }
                }
            }
            return workerStatistics;
        }

    }

}
