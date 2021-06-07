/***********************************************************************
 * Module:  EmployeeService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.EmployeeService
 ***********************************************************************/

using System;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class EmployeeService
    {
        public Model.Employee GetEmployeeByUserId(int id)
        {
            return employeesRepository.GetEmployeeByUserId(id);
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

        #region marko_kt5
        public int getEmployeeIdByDoctorId(int doctor_id)
        {
            return this.employeesRepository.getEmployeeIdByDoctorId(doctor_id);
        }
        public Boolean DeleteEmployeeById(int id)
        {

            return false;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            employee = this.employeesRepository.UpdateEmployee(employee);

            if (employee.User.Id == 0)
            {
                employee.User.Id = this.employeesRepository.GetUserIdByEmployeeId(employee.Id);
            }

            employee.User = this.userRepository.Update(employee.User);

            return employee;

        }

        public Model.Employee AddEmployee(Model.Employee employee)
        {
            return this.employeesRepository.NewEmployee(employee);
        }

        #endregion


        public EmployeesRepository employeesRepository = new EmployeesRepository();
        private UserRepository userRepository = new UserRepository();

    }
}