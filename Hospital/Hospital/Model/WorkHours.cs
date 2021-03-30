/***********************************************************************
 * Module:  WorkHours.cs
 * Author:  Pedja
 * Purpose: Definition of the Class WorkHours
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class WorkHours
    {
        private int Id { get; set; }
        private Boolean Approved { get; set; } = false;
        private DateTime ShiftStart { get; set; }
        private DateTime ShiftEnd { get; set; }

        public Doctor Doctor;

        public Doctor GetDoctor()
        {
            return Doctor;
        }

        public void SetDoctor(Doctor newDoctor)
        {
            if (this.Doctor != newDoctor)
            {
                if (this.Doctor != null)
                {
                    Doctor oldDoctor = this.Doctor;
                    this.Doctor = null;
                    oldDoctor.RemoveWorkHours(this);
                }
                if (newDoctor != null)
                {
                    this.Doctor = newDoctor;
                    this.Doctor.AddWorkHours(this);
                }
            }
        }


    }
}