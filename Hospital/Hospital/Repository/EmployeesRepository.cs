/***********************************************************************
 * Module:  EmployeesRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.EmployeesRepository
 ***********************************************************************/

using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using System;
using OracleInternal.SqlAndPlsqlParser.LocalParsing;

namespace Hospital.Repository
{
    public class EmployeesRepository
    {
        OracleConnection connection = null;


        private void setConnection()
        {
            String conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            connection = new OracleConnection(conString);
            try
            {
                connection.Open();
            }
            catch (Exception exp)
            {

            }
        }
        public Employee GetEmployeeByUserId(int id)
        {
            setConnection();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM employee LEFT OUTER JOIN users ON employee.user_id = users.id LEFT OUTER JOIN role on role.id = employee.role_id WHERE users.id = " + id.ToString();
            OracleDataReader reader = cmd.ExecuteReader();

            var employee = ParseEmployee(reader);
            connection.Close();
            connection.Dispose();

            return employee;
        }

        public int GetUserIdByEmployeeId(int employee_id)
        {
            setConnection();

            int user_id;

            OracleCommand commannd = connection.CreateCommand();
            commannd.CommandText = "SELECT user_id FROM employee WHERE id = " + employee_id;
            OracleDataReader reader = commannd.ExecuteReader();
            reader.Read();

            user_id = int.Parse(reader.GetString(0));

            return user_id;
        }

        public Employee GetEmployeeById(int id)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM EMPLOYEE WHERE ID = :id";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();

            OracleDataReader reader = command.ExecuteReader();
            var employee = ParseEmployee(reader);
            connection.Close();
            connection.Dispose();
            
            return employee;
        }

        private static Employee ParseEmployee(OracleDataReader reader)
        {
            reader.Read();
            int id = int.Parse(reader.GetString(3));

            if (id == 0)
            {
                int id_emp = int.Parse(reader.GetString(0));
                int salary = int.Parse(reader.GetString(1));
                int yearso = int.Parse(reader.GetString(2));
                int userid = int.Parse(reader.GetString(3));
                int roleid = int.Parse(reader.GetString(4));

            }

            User user = new UserRepository().GetUserById(id); 
            
            Role role = new RoleRepository().GetRoleById(reader.GetInt32(4));
            
            Employee employee = new Employee(reader.GetInt32(0),reader.GetInt32(1),reader.GetInt32(2),user,role);
            return employee;
        }

        public System.Collections.ArrayList GetAllEmployees()
        {
            // TODO: implement
            return null;
        }

        public System.Collections.ArrayList GetAllEmployeesByRoleId(int roleId)
        {
            // TODO: implement
            return null;
        }

        public Boolean DeleteEmployeeById(int id)
        {
            // TODO: implement
            return false;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            // TODO: implement
            return null;
        }

        #region marko_kt5
        public Employee NewEmployee(Employee employee)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            
            command.CommandText = "INSERT INTO employee (id, salary, years_of_service, user_id, role_id) VALUES (:id, :salary, :years_of_service, :user_id, :role_id)";

            int id = GetLastId() + 1;
            employee.Id = id;

            command.Parameters.Add("id", OracleDbType.Int32).Value = employee.Id;
            command.Parameters.Add("salary", OracleDbType.Int32).Value = employee.Salary;
            command.Parameters.Add("years_of_service", OracleDbType.Int32).Value = employee.YearsOfService;
            command.Parameters.Add("user_id", OracleDbType.Int32).Value = employee.User.Id;
            command.Parameters.Add("role_id", OracleDbType.Int32).Value = employee.role.Id;
            

            if (command.ExecuteNonQuery() > 0)
            {
                connection.Close();
                connection.Dispose();

                return employee;
            }

            connection.Close();
            connection.Dispose();

            return null;
        }
        #endregion

        public int GetLastId()
        {   
            setConnection();
            OracleCommand command = connection.CreateCommand();

            command.CommandText = "SELECT MAX(id) FROM employee";
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            int id = int.Parse(reader.GetString(0));

            connection.Close();
            connection.Dispose();

            return id;
        }

    }
}