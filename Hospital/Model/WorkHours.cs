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
        public Boolean Approved = False;
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }

        public Doctor doctor;


        public bool Approve()
        {
            // TODO: implement
            return false;
        }

        public bool Decline()
        {
            // TODO: implement
            return false;
        }

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

    }
}