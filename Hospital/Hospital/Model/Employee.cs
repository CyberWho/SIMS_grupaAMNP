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

        public int Id { get; set; }
        public int Salary { get; set; }
        public int YearsOfService { get; set; }

        public User User { get; set; }
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
        public Employee(int id, int salary, int yearsOfService, User user, Role role)
        {
            Id = id;
            Salary = salary;
            YearsOfService = yearsOfService;
            User = user;
            this.role = role;
        }

        public Employee()
        {
        }
    }
}