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

        public DepartmentStatisticsCalculator(ObservableCollection<Department> departments, ObservableCollection<Position> positions)
        {
            _departments = departments;
            _positions = positions;
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
                departmentStats.Budget = CalculateBudget();

                // Calculate and set Efficiency
                departmentStats.Efficiency = CalculateEfficiency(departmentStats.TotalProfit, departmentStats.Budget);

                statistics.Add(departmentStats);
            }

            return statistics;
        }

        private decimal CalculateTotalProfit(Department department)
        {
            // Ваша логика для расчета TotalProfit на основе конкретного отдела
            return 0; // Замените этот заполнитель своей реализацией
        }

        private decimal CalculateBudget()
        {
            // Ваша логика для расчета Budget на основе коллекции _positions
            // Например, если вы хотите суммировать все зарплаты из каждой должности, вы можете использовать:
            return _positions.Sum(p => p.Salary);
        }

        private decimal CalculateEfficiency(decimal totalProfit, decimal budget)
        {
            // Ваша логика для расчета Efficiency на основе totalProfit и budget
            // Реализуйте расчет на основе ваших требований
            return 0; // Замените этот заполнитель своей реализацией
        }
    }

}
