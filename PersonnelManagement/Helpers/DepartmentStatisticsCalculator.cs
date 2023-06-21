using GalaSoft.MvvmLight.Command;
using PersonnelManagement.Helpers;
using PersonnelManagement.Model;
using PersonnelManagement.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PersonnelManagement.Helpers
{
    public class DepartmentStatisticsCalculator
    {
        private ObservableCollection<Department> _departments;
        private ObservableCollection<Position> _positions;
        private ObservableCollection<Worker> _workers;
        private ObservableCollection<Projects> _projects;

        public DepartmentStatisticsCalculator(ObservableCollection<Department> departments, ObservableCollection<Position> positions, ObservableCollection<Worker> workers, ObservableCollection<Projects> projects)
        {
            _departments = departments;
            _positions = positions;
            _workers = workers;
            _projects = projects;
        }
        
        public ObservableCollection<DepartmentStatistics> CalculateDepartmentStatistics()
        {
            ObservableCollection<DepartmentStatistics> statistics = new ObservableCollection<DepartmentStatistics>();

            foreach (Department department in _departments)
            {
                DepartmentStatistics departmentStats = new DepartmentStatistics();

                // Set DepartmentName
                departmentStats.DepartmentName = department.Title;

                // Set EmployeeCount
                departmentStats.EmployeeCount = department.EmployeesCount;

                // Calculate and set TotalProfit
                departmentStats.TotalProfit = CalculateTotalProfit(department);

                // Calculate and set Budget
                departmentStats.Budget = CalculateBudget(department);

                // Calculate and set Efficiency
                departmentStats.Efficiency = CalculateEfficiency(departmentStats.TotalProfit, departmentStats.Budget);

                statistics.Add(departmentStats);
            }

            return statistics;
        }

        // Считаю бюджет отдела
        private decimal CalculateBudget(Department department)
        {
            decimal departmentBudget = _workers
                .Where(w => w.DepartmentID == department.Id)
                .Sum(w => _positions.FirstOrDefault(p => p.Id == w.PositionID)?.Salary ?? 0);

            return departmentBudget;
        }

        // Считаю прибыль отдела
        private decimal CalculateTotalProfit(Department department)
        {
            // Получение сотрудников отдела
            List<Worker> workers = _workers
                .Where(w => w.DepartmentID == department.Id)
                .ToList();

            // Получение проектов, над которыми работают сотрудники отдела
            List<Projects> projects = _projects
                .Where(p => workers.Any(w => p.ProjectManager == w.FullName))
                .ToList();

            // Расчет общей прибыли проектов
            decimal totalProjectBudget = projects.Sum(p => p.ProjectBudget);

            // Расчет общего бюджета отдела
            decimal departmentBudget = CalculateBudget(department);

            // Вычитание бюджета отдела из общей прибыли проектов
            decimal totalProfit = totalProjectBudget - departmentBudget;

            if (totalProfit < 0) totalProfit = 0;

            return totalProfit;
        }

        private decimal CalculateEfficiency(decimal totalProfit, decimal budget)
        {
            if (budget == 0)
            {
                return 0; // Избегаем деления на ноль
            }

            decimal efficiency = totalProfit / budget;
            return efficiency;
        }

    }

}
