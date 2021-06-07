/***********************************************************************
 * Module:  EmployeeService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.EmployeeService
 ***********************************************************************/

using System;
using Hospital.IRepository;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class EmployeeService
    {
        private IEmployeeRepo<Employee> employeesRepository;
        private IUserRepo<User> userRepository;

        public EmployeeService(IEmployeeRepo<Employee> iEmployeeRepo,IUserRepo<User> iUserRepo)
        {
            this.employeesRepository = iEmployeeRepo;
            this.userRepository = iUserRepo;
        }
        public Model.Employee GetEmployeeByUserId(int id)
        {
            return employeesRepository.GetByUserId(id);
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
            return this.employeesRepository.GetIdByDoctorId(doctor_id);
        }
        public Boolean DeleteEmployeeById(int id)
        {

            return false;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            employee = this.employeesRepository.Update(employee);

            if (employee.User.Id == 0)
            {
                employee.User.Id = this.employeesRepository.GetUserIdById(employee.Id);
            }

            employee.User = this.userRepository.Update(employee.User);

            return employee;

        }

        public Model.Employee AddEmployee(Model.Employee employee)
        {
            return this.employeesRepository.Add(employee);
        }

        #endregion


    }
}