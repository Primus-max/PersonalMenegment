using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagement.Helpers
{
    public class DepartmentStatisticsCalculator
    {
        public DepartmentStatistics CalculateDepartmentStatistics(Department department)
        {
            // Выполните необходимые вычисления на основе данных отдела
            int employeeCount = department.Employees.Count;
            decimal totalProfit = CalculateTotalProfit(department);
            decimal budget = department.Budget;
            decimal efficiency = CalculateEfficiency(totalProfit, budget);

            // Создайте объект DepartmentStatistics с вычисленными значениями
            DepartmentStatistics departmentStatistics = new DepartmentStatistics
            {
                DepartmentName = department.Name,
                EmployeeCount = employeeCount,
                TotalProfit = totalProfit,
                Budget = budget,
                Efficiency = efficiency
            };

            return departmentStatistics;
        }

        private decimal CalculateTotalProfit(Department department)
        {
            // Выполните необходимые вычисления для определения общей прибыли отдела
            // Например, суммируйте прибыль всех проектов, связанных с отделом
            decimal totalProfit = 0;
            foreach (Project project in department.Projects)
            {
                totalProfit += project.Profit;
            }

            return totalProfit;
        }

        private decimal CalculateEfficiency(decimal totalProfit, decimal budget)
        {
            // Выполните необходимые вычисления для определения эффективности отдела
            // Например, вычислите отношение общей прибыли к бюджету
            decimal efficiency = totalProfit / budget * 100;

            return efficiency;
        }
    }

}
