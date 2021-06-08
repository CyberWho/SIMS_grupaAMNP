/***********************************************************************
 * Module:  Employees.cs
 * Author:  Pedja
 * Purpose: Definition of the Class Employees
 ***********************************************************************/

namespace Hospital.Model
{
    public class Employee : RoleDescriptionBase
    {

        public int Id { get; set; }
        public int Salary { get; set; }
        public int YearsOfService { get; set; }

        public User User { get; set; }
        public Role role { get; set; }

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
        public Employee(int id, RoleDescriptionBase rdb)
        {
            this.Id = id;
            this.wrappee = rdb;
        }

        public override string describeMyRole()
        {
            return wrappee.describeMyRole() + "Vi se u nasoj kopaniji cenjeni radnik\n";
        }

        public override int howMuchAmIPaid()
        {
            return wrappee.howMuchAmIPaid() + 10000;
        }
    }
}