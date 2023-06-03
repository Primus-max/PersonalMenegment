using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagement.Model.DB
{
    public class Command : ICommand
    {
        //Строка подключения к БД
        //private string SQLConnection = @"Server=DESKTOP-FUOOUNG;Database=Test;Trusted_Connection=True;";
        private string SQLConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Z:\Programming\ProjectC#\PersonnelManagement\PersonnelManagement\PersonnelManagement\Test.mdf;Integrated Security=True";
        private SqlConnection connection;

        public Command()
        {
            connection = new SqlConnection(SQLConnection);
        }

        //Метод для заполнения данных
        public void InitialTable(out DataTable dt, string sqlCommand)
        {
            dt = new DataTable();
            dt.Clear();
            SqlCommand command = new SqlCommand(sqlCommand, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(dt);
        }

        //открываем подключение к БД
        public void Open()
        {
            connection.Open();
        }

        //Закрывем подключение
        public void Close()
        {
            connection.Close();
        }

        /// <summary>
        /// Метод для выполнения sql запроса к БД
        /// </summary>
        /// <param name="sqlComand"></param>
        public void Execute(string sqlComand)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(sqlComand, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
