/***********************************************************************
 * Module:  Role.cs
 * Author:  Nikola
 * Purpose: Definition of the Class Hospital.Model.Role
 ***********************************************************************/

using System;

namespace Hospital.Model
{
   public class Role
   {
      public string Role;
      
      public System.Collections.ArrayList employees;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetEmployees()
      {
         if (employees == null)
            employees = new System.Collections.ArrayList();
         return employees;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetEmployees(System.Collections.ArrayList newEmployees)
      {
         RemoveAllEmployees();
         foreach (Employees oEmployees in newEmployees)
            AddEmployees(oEmployees);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddEmployees(Employees newEmployees)
      {
         if (newEmployees == null)
            return;
         if (this.employees == null)
            this.employees = new System.Collections.ArrayList();
         if (!this.employees.Contains(newEmployees))
         {
            this.employees.Add(newEmployees);
            newEmployees.SetRole(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveEmployees(Employees oldEmployees)
      {
         if (oldEmployees == null)
            return;
         if (this.employees != null)
            if (this.employees.Contains(oldEmployees))
            {
               this.employees.Remove(oldEmployees);
               oldEmployees.SetRole((Role)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllEmployees()
      {
         if (employees != null)
         {
            System.Collections.ArrayList tmpEmployees = new System.Collections.ArrayList();
            foreach (Employees oldEmployees in employees)
               tmpEmployees.Add(oldEmployees);
            employees.Clear();
            foreach (Employees oldEmployees in tmpEmployees)
               oldEmployees.SetRole((Role)null);
            tmpEmployees.Clear();
         }
      }
   
   }
}