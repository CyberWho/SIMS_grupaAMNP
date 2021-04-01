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

      public int Id { get; set; }

      public string Type;
      
      public System.Collections.ArrayList Employees;
      
      public System.Collections.ArrayList GetEmployees()
      {
         if (Employees == null)
            Employees = new System.Collections.ArrayList();
         return Employees;
      }
      
      public void SetEmployees(System.Collections.ArrayList newEmployees)
      {
         RemoveAllEmployees();
         foreach (Employees oEmployees in newEmployees)
            AddEmployees(oEmployees);
      }
      
      public void AddEmployees(Employees newEmployees)
      {
         if (newEmployees == null)
            return;
         if (this.Employees == null)
            this.Employees = new System.Collections.ArrayList();
         if (!this.Employees.Contains(newEmployees))
         {
            this.Employees.Add(newEmployees);
            newEmployees.SetRole(this);      
         }
      }
      
      public void RemoveEmployees(Employees oldEmployees)
      {
         if (oldEmployees == null)
            return;
         if (this.Employees != null)
            if (this.Employees.Contains(oldEmployees))
            {
               this.Employees.Remove(oldEmployees);
               oldEmployees.SetRole((Role)null);
            }
      }
      
      public void RemoveAllEmployees()
      {
         if (Employees != null)
         {
            System.Collections.ArrayList tmpEmployees = new System.Collections.ArrayList();
            foreach (Employees oldEmployees in Employees)
               tmpEmployees.Add(oldEmployees);
            Employees.Clear();
            foreach (Employees oldEmployees in tmpEmployees)
               oldEmployees.SetRole((Role)null);
            tmpEmployees.Clear();
         }
      }
   
   }
}