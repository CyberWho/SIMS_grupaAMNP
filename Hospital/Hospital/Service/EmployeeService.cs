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
      
      public Hospital.Model.Employee AddEmployee(Hospital.Model.Employee employee)
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Repository.EmployeesRepository employeesRepository;
   
   }
}