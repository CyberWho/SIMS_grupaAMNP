/***********************************************************************
 * Module:  Role.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Model.Role
 ***********************************************************************/

using System;

namespace Hospital.Model
{
   public class Role
   {
      public int Id;
      public string Role;
      
      public System.Collections.ArrayList employee;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetEmployee()
      {
         if (employee == null)
            employee = new System.Collections.ArrayList();
         return employee;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetEmployee(System.Collections.ArrayList newEmployee)
      {
         RemoveAllEmployee();
         foreach (Employee oEmployee in newEmployee)
            AddEmployee(oEmployee);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddEmployee(Employee newEmployee)
      {
         if (newEmployee == null)
            return;
         if (this.employee == null)
            this.employee = new System.Collections.ArrayList();
         if (!this.employee.Contains(newEmployee))
         {
            this.employee.Add(newEmployee);
            newEmployee.SetRole(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveEmployee(Employee oldEmployee)
      {
         if (oldEmployee == null)
            return;
         if (this.employee != null)
            if (this.employee.Contains(oldEmployee))
            {
               this.employee.Remove(oldEmployee);
               oldEmployee.SetRole((Role)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllEmployee()
      {
         if (employee != null)
         {
            System.Collections.ArrayList tmpEmployee = new System.Collections.ArrayList();
            foreach (Employee oldEmployee in employee)
               tmpEmployee.Add(oldEmployee);
            employee.Clear();
            foreach (Employee oldEmployee in tmpEmployee)
               oldEmployee.SetRole((Role)null);
            tmpEmployee.Clear();
         }
      }
   
   }
}