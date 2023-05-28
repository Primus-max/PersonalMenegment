﻿using PersonnelManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PersonnelManagement.Model.DB
{
    public class ChangeDB
    {
        private Command _command;
        public ChangeDB()
        {
            _command = new Command();
        }

        #region Get
        public ObservableCollection<Department> GetDepartment()
        {
            List<Department> temp;
            DataTable _dataTemp = new DataTable();
            _command.InitialTable(out _dataTemp, "SELECT d.Id, d.Title, COUNT(w.Id) AS EmployeesCount " +
                                                 "FROM Department d " +
                                                 "LEFT JOIN Worker w ON d.Id = w.DepartmentId " +
                                                 "GROUP BY d.Id, d.Title");
            temp = (from DataRow dr in _dataTemp.Rows
                    select new Department()
                    {
                        Id = int.Parse(dr["Id"].ToString()),
                        Title = dr["Title"].ToString(),
                        EmployeesCount = int.Parse(dr["EmployeesCount"].ToString())
                    }).ToList();

            return new ObservableCollection<Department>(temp);
        }

        public ObservableCollection<Position> GetPosition()
        {
            List<Position> temp;
            DataTable _dataTemp = new DataTable();
            _command.InitialTable(out _dataTemp, "Select * from Position");
            temp = (from DataRow dr in _dataTemp.Rows
                    select new Position()
                    {
                        Id = int.Parse(dr["Id"].ToString()),
                        Title = dr["Title"].ToString(),
                    }).ToList();

            return new ObservableCollection<Position>(temp);
        }
        public ObservableCollection<Projects> GetProjects()
        {
            List<Projects> temp;
            DataTable _dataTemp = new DataTable();
            _command.InitialTable(out _dataTemp, "Select * from Projects");
            temp = (from DataRow dr in _dataTemp.Rows
                    select new Projects()
                    {
                        Id = int.Parse(dr["Id"].ToString()),
                        Title = dr["Title"].ToString(),
                    }).ToList();

            return new ObservableCollection<Projects>(temp);
        }
        public ObservableCollection<ProjectsWorker> GetProjectsWorker()
        {
            List<ProjectsWorker> temp;
            DataTable _dataTemp = new DataTable();
            _command.InitialTable(out _dataTemp, "Select * from ProjectsWorker");
            temp = (from DataRow dr in _dataTemp.Rows
                    select new ProjectsWorker()
                    {
                        Id = int.Parse(dr["Id"].ToString()),
                        ProjectsId = int.Parse(dr["ProjectsId"].ToString()),
                        WorkerID = int.Parse(dr["WorkerID"].ToString())
                    }).ToList();

            return new ObservableCollection<ProjectsWorker>(temp);
        }
        public ObservableCollection<Roles> GetRoles()
        {
            List<Roles> temp;
            DataTable _dataTemp = new DataTable();
            _command.InitialTable(out _dataTemp, "Select * from Roles");
            temp = (from DataRow dr in _dataTemp.Rows
                    select new Roles()
                    {
                        Id = int.Parse(dr["Id"].ToString()),
                        Title = dr["Title"].ToString(),
                    }).ToList();

            return new ObservableCollection<Roles>(temp);
        }
        public ObservableCollection<Users> GetUsers()
        {
            List<Users> temp;
            DataTable _dataTemp = new DataTable();
            _command.InitialTable(out _dataTemp, "Select * from Users");
            temp = (from DataRow dr in _dataTemp.Rows
                    select new Users()
                    {
                        Id = int.Parse(dr["Id"].ToString()),              
                        WorkerID = int.Parse(dr["WorkerID"].ToString()),
                        RoleID = int.Parse(dr["RoleID"].ToString()),
                        Login = dr["Login"].ToString(),
                        Password = dr["Password"].ToString(),
                    }).ToList();

            return new ObservableCollection<Users>(temp);
        }
        public ObservableCollection<Worker> GetWorker()
        {
            List<Worker> temp;
            DataTable _dataTemp = new DataTable();
            _command.InitialTable(out _dataTemp, "Select * from Worker");
            temp = (from DataRow dr in _dataTemp.Rows
                    select new Worker()
                    {
                        Id = int.Parse(dr["Id"].ToString()),
                        FullName = dr["FullName"].ToString(),
                        DepartmentID = int.Parse(dr["DepartmentID"].ToString()),
                        PositionID = int.Parse(dr["PositionID"].ToString()),
                        DateOfHire = DateTime.Parse(dr["DateOfHire"].ToString())
                    }).ToList();

            return new ObservableCollection<Worker>(temp);
        }
        #endregion

        public void AddAll(BaseEntity baseEntity)
        {
            _command.Execute(Add(baseEntity));
        }
        public void UpdateAll(BaseEntity baseEntity)
        {
            _command.Execute(Update(baseEntity));
        }
        public void RemoveAll(BaseEntity baseEntity)
        {
            _command.Execute(Remove(baseEntity));
        }

        #region Converter class to sql query

        private string Add(BaseEntity entity)
        {
            List<PropertyInfo> props = entity.GetType().GetProperties().ToList();

            string tableName = entity.GetType().Name;
            List<string> columnNames = new List<string>();
            List<string> values = new List<string>();

            for (int i = 0; i < props.Count(); i++)
            {
                if (!props[i].PropertyType.IsSubclassOf(typeof(BaseEntity)) && props[i].PropertyType != typeof(DateTime))
                {
                    columnNames.Add(props[i].Name);
                    if (props[i].GetValue(entity) == null)
                    {
                        values.Add("NULL");
                    }
                    else
                    {
                        values.Add($"N'{props[i].GetValue(entity)}'");
                    }
                }
                else if (props[i].PropertyType == typeof(DateTime))
                {
                    columnNames.Add(props[i].Name);
                    DateTime dateTimeValue = (DateTime)props[i].GetValue(entity);
                    string formattedDateTime = dateTimeValue.ToString("yyyy-MM-dd HH:mm:ss");
                    values.Add($"N'{formattedDateTime}'");
                }
            }

            string columns = string.Join(", ", columnNames);
            string columnValues = string.Join(", ", values);

            string command = $"INSERT INTO {tableName} ({columns}) VALUES ({columnValues});";
            return command;
        }


        private string Remove(BaseEntity entity)
        {
            PropertyInfo[] props = entity.GetType().GetProperties();
            return $"Delete from {entity.GetType().Name} where Id = {props[props.Count() - 1].GetValue(entity)}";           
        }

        private string Update(BaseEntity entity)
        {
            List<PropertyInfo> props = entity.GetType().GetProperties().ToList();
            string command = $"Update {entity.GetType().Name} set ";

            foreach (PropertyInfo p in props)
            {
                if (!p.PropertyType.IsSubclassOf(typeof(BaseEntity)))
                {
                    if (p.PropertyType == typeof(DateTime))
                    {
                        DateTime dateTimeValue = (DateTime)p.GetValue(entity);
                        string formattedDateTime = dateTimeValue.ToString("yyyy-MM-dd HH:mm:ss"); // Форматируем дату и время в строку с подходящим форматом
                        command += $"{p.Name} = N'{formattedDateTime}', ";
                    }
                    else
                    {
                        if (p.GetValue(entity) == null)
                        {
                            command += $"{p.Name} = null, ";
                        }
                        else
                        {
                            command += $"{p.Name} = N'{p.GetValue(entity)}', ";
                        }
                    }
                }
            }

            command = command.Remove(command.Length - 2, 2);
            command += $" where Id = {props[props.Count() - 1].GetValue(entity)}";

            return command;
        }


        #endregion
    }
}
