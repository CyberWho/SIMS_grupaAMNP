/***********************************************************************
 * Module:  EmployeeController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.EmployeeController
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Controller
{
    public class EmployeeController
    {
        public Employee GetEmployeeByUserId(int id)
        {
            return employeeService.GetEmployeeByUserId(id);
        }

        public ObservableCollection<Employee> GetAllEmployees()
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Employee> GetAllEmployeesByRoleId(int roleId)
        {
            // TODO: implement
            return null;
        }

        public int getEmployeeIdByDoctorId(int doctor_id)
        {
            return this.employeeService.getEmployeeIdByDoctorId(doctor_id);
        }

        public Boolean DeleteEmployeeById(int id)
        {
            // TODO: implement
            return false;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            return this.employeeService.UpdateEmployee(employee);
        }

        public Employee AddEmployee(Employee employee)
        {
            return this.employeeService.AddEmployee(employee);
        }

        public Service.EmployeeService employeeService = new Service.EmployeeService(new EmployeesRepository(),new UserRepository());

    }
}