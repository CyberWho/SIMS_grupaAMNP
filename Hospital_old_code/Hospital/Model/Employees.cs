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
        public int Salary { get; set; }
        public int YearsOfService { get; set; }
        public User User { get; set; }

        public Role Role;

        public Patient ListAllPatients()
        {
            // TODO: implement
            return null;
        }

        public HealthRecord ListAllHealthRecords()
        {
            // TODO: implement
            return null;
        }

        public Role GetRole()
        {
            return Role;
        }

        public void SetRole(Role newRole)
        {
            if (this.Role != newRole)
            {
                if (this.Role != null)
                {
                    Role oldRole = this.Role;
                    this.Role = null;
                    oldRole.RemoveEmployees(this);
                }
                if (newRole != null)
                {
                    this.Role = newRole;
                    this.Role.AddEmployees(this);
                }
            }
        }

    }
}