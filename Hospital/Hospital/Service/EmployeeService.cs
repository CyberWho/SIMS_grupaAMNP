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
      
      public Boolean DeleteEmployeeById(int id)
      {
         // TODO: implement
         return false;
      }
      
      public Model.Employee UpdateEmployee(Model.Employee employee)
      {
         // TODO: implement
         return null;
      }
      
      public Model.Employee AddEmployee(Model.Employee employee)
      {
         // TODO: implement
         return null;
      }
   
      public Repository.EmployeesRepository employeesRepository = new Repository.EmployeesRepository();
   
   }
}