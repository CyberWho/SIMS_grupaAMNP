/***********************************************************************
 * Module:  Employees.cs
 * Author:  Pedja
 * Purpose: Definition of the Class Employees
 ***********************************************************************/

using System;

namespace Hospital.Model
{
   public class Employee
   {
      public System.Array<Patient> ListAllPatients()
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<HealthRecord> ListAllHealthRecords()
      {
         // TODO: implement
         return null;
      }
   
      public int Id;
      public int Salary;
      public int YearsOfService;
      
      public User user;
      public Role role;
      
      /// <pdGenerated>default parent getter</pdGenerated>
      public Role GetRole()
      {
         return role;
      }
      
      /// <pdGenerated>default parent setter</pdGenerated>
      /// <param>newRole</param>
      public void SetRole(Role newRole)
      {
         if (this.role != newRole)
         {
            if (this.role != null)
            {
               Role oldRole = this.role;
               this.role = null;
               oldRole.RemoveEmployee(this);
            }
            if (newRole != null)
            {
               this.role = newRole;
               this.role.AddEmployee(this);
            }
         }
      }
   
   }
}