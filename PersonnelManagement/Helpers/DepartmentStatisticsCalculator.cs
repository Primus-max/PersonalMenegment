﻿using GalaSoft.MvvmLight.Command;
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

        public DepartmentStatisticsCalculator(ObservableCollection<Department> departments, ObservableCollection<Position> positions, ObservableCollection<Worker> workers)
        {
            _departments = departments;
            _positions = positions;
            _workers = workers;
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

        private decimal CalculateTotalProfit(Department department)
        {
            // Ваша логика для расчета TotalProfit на основе конкретного отдела
            return 0; // Замените этот заполнитель своей реализацией
        }

        private decimal CalculateBudget(Department department)
        {
            decimal departmentBudget = _workers
                .Where(w => w.DepartmentID == department.Id)
                .Sum(w => _positions.FirstOrDefault(p => p.Id == w.PositionID)?.Salary ?? 0);

            return departmentBudget;
        }



        private decimal CalculateEfficiency(decimal totalProfit, decimal budget)
        {
            // Ваша логика для расчета Efficiency на основе totalProfit и budget
            // Реализуйте расчет на основе ваших требований
            return 0; // Замените этот заполнитель своей реализацией
        }
    }

}
