/***********************************************************************
 * Module:  Doctor.cs
 * Author:  Pedja
 * Purpose: Definition of the Class Doctor
 ***********************************************************************/

using System.Collections;
using System.Windows.Controls;

namespace Hospital.Model
{
    public class Doctor : RoleDescriptionBase, IEntity//: Employee
    {

        public Room room { get; set; }

        public Employee employee = new Employee();
        public int employee_id { get; set; }
        public int room_id { get; set; }
        public int specialization_id { get; set; }

        //uklanjanje nasledjivanja
        public int Id
        {
            get { return this.employee.Id; }
            set { this.employee.Id = value; }
        }

        public int Salary
        {
            get { return this.employee.Salary; }
            set { this.employee.Salary = value;  }
        }

        public int YearsOfService
        {
            get { return this.employee.YearsOfService; }
            set { this.employee.YearsOfService = value; }
        }

        public User User
        {
            get { return this.employee.User; }
            set { this.employee.User = value; }
        }

        public Role role
        {
            get { return this.employee.role; }
            set { this.employee.role = value; }
        }

        /// <pdGenerated>default parent getter</pdGenerated>
        public Room GetRoom()
        {
            return room;
        }

        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newRoom</param>
        public void SetRoom(Room newRoom)
        {
            if (this.room != newRoom)
            {
                if (this.room != null)
                {
                    Room oldRoom = this.room;
                    this.room = null;
                    oldRoom.RemoveDoctor(this);
                }
                if (newRoom != null)
                {
                    this.room = newRoom;
                    this.room.AddDoctor(this);
                }
            }
        }
        public ArrayList workHours;

        /// <pdGenerated>default getter</pdGenerated>
        public ArrayList GetWorkHours()
        {
            if (workHours == null)
                workHours = new ArrayList();
            return workHours;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetWorkHours(ArrayList newWorkHours)
        {
            RemoveAllWorkHours();
            foreach (WorkHours oWorkHours in newWorkHours)
                AddWorkHours(oWorkHours);
        }

        /// <pdGenerated>default New</pdGenerated>
        public void AddWorkHours(WorkHours newWorkHours)
        {
            if (newWorkHours == null)
                return;
            if (this.workHours == null)
                this.workHours = new ArrayList();
            if (!this.workHours.Contains(newWorkHours))
            {
                this.workHours.Add(newWorkHours);
                newWorkHours.SetDoctor(this);
            }
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveWorkHours(WorkHours oldWorkHours)
        {
            if (oldWorkHours == null)
                return;
            if (this.workHours != null)
                if (this.workHours.Contains(oldWorkHours))
                {
                    this.workHours.Remove(oldWorkHours);
                    oldWorkHours.SetDoctor((Doctor)null);
                }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllWorkHours()
        {
            if (workHours != null)
            {
                ArrayList tmpWorkHours = new ArrayList();
                foreach (WorkHours oldWorkHours in workHours)
                    tmpWorkHours.Add(oldWorkHours);
                workHours.Clear();
                foreach (WorkHours oldWorkHours in tmpWorkHours)
                    oldWorkHours.SetDoctor((Doctor)null);
                tmpWorkHours.Clear();
            }
        }
        public Specialization specialization { get; set; }

        /// <pdGenerated>default parent getter</pdGenerated>
        public Specialization GetSpecialization()
        {
            return specialization;
        }

        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newSpecialization</param>
        public void SetSpecialization(Specialization newSpecialization)
        {
            if (this.specialization != newSpecialization)
            {
                if (this.specialization != null)
                {
                    Specialization oldSpecialization = this.specialization;
                    this.specialization = null;
                    oldSpecialization.RemoveDoctor(this);
                }
                if (newSpecialization != null)
                {
                    this.specialization = newSpecialization;
                    this.specialization.AddDoctor(this);
                }
            }
        }
        public ArrayList appointment;

        /// <pdGenerated>default getter</pdGenerated>
        public ArrayList GetAppointment()
        {
            if (appointment == null)
                appointment = new ArrayList();
            return appointment;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetAppointment(ArrayList newAppointment)
        {
            RemoveAllAppointment();
            foreach (Appointment oAppointment in newAppointment)
                AddAppointment(oAppointment);
        }

        /// <pdGenerated>default New</pdGenerated>
        public void AddAppointment(Appointment newAppointment)
        {
            if (newAppointment == null)
                return;
            if (this.appointment == null)
                this.appointment = new ArrayList();
            if (!this.appointment.Contains(newAppointment))
            {
                this.appointment.Add(newAppointment);
                newAppointment.SetDoctor(this);
            }
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveAppointment(Appointment oldAppointment)
        {
            if (oldAppointment == null)
                return;
            if (this.appointment != null)
                if (this.appointment.Contains(oldAppointment))
                {
                    this.appointment.Remove(oldAppointment);
                    oldAppointment.SetDoctor((Doctor)null);
                }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllAppointment()
        {
            if (appointment != null)
            {
                ArrayList tmpAppointment = new ArrayList();
                foreach (Appointment oldAppointment in appointment)
                    tmpAppointment.Add(oldAppointment);
                appointment.Clear();
                foreach (Appointment oldAppointment in tmpAppointment)
                    oldAppointment.SetDoctor((Doctor)null);
                tmpAppointment.Clear();
            }
        }


        public Doctor(int id, int employee_id, int room_id, int specialization_id)
        {
            this.Id = id;
            this.employee_id = employee_id;
            this.room_id = room_id;
            this.specialization_id = specialization_id;
            
        }

        public Doctor(Room room, ArrayList workHours, Specialization specialization, ArrayList appointment)
        {
            this.room = room;
            this.workHours = workHours;
            this.specialization = specialization;
            this.appointment = appointment;
        }

        public Doctor()
        {
        }

        public Doctor(int id, int salary, int yearsOfService, User user,Role role,Specialization specialization,Room room) 
        {
            //: base(id, salary, yearsOfService, user, role)
            this.Id = id;
            this.Salary = salary;
            this.YearsOfService = yearsOfService;
            this.User = user;
            this.role = role;


            this.User = user;
            this.role = role;
            this.specialization = specialization;

            
            this.room = room;

            this.room_id = (int)room.Id;
            //this.employee_id = id;
            this.specialization_id = specialization.id;
        }
        public Doctor(int id, int salary, int yearsOfService, User user, Role role, Specialization specialization) 
        {
            //: base(id, salary, yearsOfService, user, role)
            this.Id = id;
            this.Salary = salary;
            this.YearsOfService = yearsOfService;
            this.User = user;
            this.role = role;

            this.User = user;
            this.role = role;
            this.specialization = specialization;

            //Ovde se dodeljuje room.id, a room nikad nece biti definisano
            //this.room_id = room.Id;
            this.employee_id = id;
            this.specialization_id = specialization.id;
        }
        public Doctor(int id, IRoleDescriptior rdb)
        {
            this.wrappee = rdb;
            this.Id = id;
        }
        public override int howMuchAmIPaid()
        {
            return wrappee.howMuchAmIPaid() + 77000;
        }

        public override string describeMyRole()
        {
            return wrappee.describeMyRole() + "Vi ste jedan od doktora [" + this.Id + "] u nasoj kompaniji\n";
        }
    }
}