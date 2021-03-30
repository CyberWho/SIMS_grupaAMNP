/***********************************************************************
 * Module:  Employees.cs
 * Author:  Pedja
 * Purpose: Definition of the Class Employees
 ***********************************************************************/

using System;

namespace Hospital.Model
{
   public class Employees
   {
      public Patient ListAllPatients()
      {
         // TODO: implement
         return null;
      }
      
      public MedicalRecord ListAllMedicalRecords()
      {
         // TODO: implement
         return null;
      }
   
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
               oldRole.RemoveEmployees(this);
            }
            if (newRole != null)
            {
               this.role = newRole;
               this.role.AddEmployees(this);
            }
         }
      }
   
   }
}