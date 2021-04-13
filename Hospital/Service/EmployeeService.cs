/***********************************************************************
 * Module:  EmployeeService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.EmployeeService
 ***********************************************************************/

using System;

namespace Hospital.Service
{
   public class EmployeeService
   {
      public Hospital.Model.Employee GetEmployeeById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Employee> GetAllEmployees()
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Employee> GetAllEmployeesByRoleId(int roleId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteEmployeeById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Employee UpdateEmployee(Hospital.Model.Employee employee)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Employee AddEmployee(Hospital.Model.Employee employee)
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Repository.EmployeesRepository employeesRepository;
   
   }
}