/***********************************************************************
 * Module:  EmployeesRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.EmployeesRepository
 ***********************************************************************/

using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using System;

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
            reader.Read();

            User user = new User();
            user.Id = reader.GetInt32(3);
            user.Username = reader.GetString(6);
            user.Password = reader.GetString(7);
            user.Name = reader.GetString(8);
            user.Surname = reader.GetString(9);
            user.PhoneNumber = reader.GetString(10);
            user.EMail = reader.GetString(11);

            Role role = new Role(reader.GetInt32(12), reader.GetString(13), null);

            Employee employee = new Employee();
            employee.SetRole(role);
            employee.User = user;
            employee.Salary = reader.GetInt32(1);
            employee.YearsOfService = reader.GetInt32(2);

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

        public Hospital.Model.Employee UpdateEmployee(Hospital.Model.Employee employee)
        {
            // TODO: implement
            return null;
        }

        public Hospital.Model.Employee NewEmployee(Hospital.Model.Employee employee)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO employee (id, salary, years_of_service, user_id, role_id) VALUES (:id, :salary, :years_of_service, :user_id, :role_id)";

            command.Parameters.Add("id", OracleDbType.Int32).Value = 7;
            command.Parameters.Add("salary", OracleDbType.Int32).Value = employee.Salary;
            command.Parameters.Add("years_of_service", OracleDbType.Int32).Value = employee.YearsOfService;
            command.Parameters.Add("user_id", OracleDbType.Int32).Value = employee.User.Id;
            command.Parameters.Add("role_id", OracleDbType.Int32).Value = employee.role.Id;

            command.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();

            Doctor doctor = new
                Doctor(
                    id: 0,
                    employee_id: employee.Id,
                    room_id: 10,
                    specialization_id: 2
                );

            this.doctorRepository.NewDoctor(doctor);

            return null;
        }

        private DoctorRepository doctorRepository = new DoctorRepository();

        public int GetLastId()
        {
            // TODO: implement
            return 0;
        }

    }
}