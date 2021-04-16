/***********************************************************************
 * Module:  EmployeeController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.EmployeeController
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Controller
{
   public class EmployeeController
   {
      public Hospital.Model.Employee GetEmployeeById(int id)
      {
         // TODO: implement
         return null;
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
   
      public Hospital.Service.EmployeeService employeeService;
   
   }
}