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


        public int Id { get; set; }
        public  DateRange dateRange { get; set; }
        public Boolean Approved { get; set; }

        public Doctor doctor { get; set; }

        /// <pdGenerated>default parent getter</pdGenerated>
        public Doctor GetDoctor()
        {
            return doctor;
        }

        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newDoctor</param>
        public void SetDoctor(Doctor newDoctor)
        {
            if (this.doctor != newDoctor)
            {
                if (this.doctor != null)
                {
                    Doctor oldDoctor = this.doctor;
                    this.doctor = null;
                    oldDoctor.RemoveWorkHours(this);
                }
                if (newDoctor != null)
                {
                    this.doctor = newDoctor;
                    this.doctor.AddWorkHours(this);
                }
            }
        }

        public WorkHours(int id, DateTime shiftStart, DateTime shiftEnd, bool approved, Doctor doctor)
        {
            Id = id;
            dateRange = new DateRange(shiftStart, shiftEnd);
            Approved = approved;
            this.doctor = doctor;
        }

        public WorkHours()
        {
            dateRange = new DateRange();
        }
    }
}