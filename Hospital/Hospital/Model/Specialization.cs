/***********************************************************************
 * Module:  Specialization.cs
 * Author:  Pedja
 * Purpose: Definition of the Class Specialization
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class Specialization
    {
        public string Type { get; set; }

        public System.Collections.ArrayList Doctor;

        public System.Collections.ArrayList GetDoctor()
        {
            if (Doctor == null)
                Doctor = new System.Collections.ArrayList();
            return Doctor;
        }

        public void SetDoctor(System.Collections.ArrayList newDoctor)
        {
            RemoveAllDoctor();
            foreach (Doctor oDoctor in newDoctor)
                AddDoctor(oDoctor);
        }

        public void AddDoctor(Doctor newDoctor)
        {
            if (newDoctor == null)
                return;
            if (this.Doctor == null)
                this.Doctor = new System.Collections.ArrayList();
            if (!this.Doctor.Contains(newDoctor))
            {
                this.Doctor.Add(newDoctor);
                newDoctor.SetSpecialization(this);
            }
        }

        public void RemoveDoctor(Doctor oldDoctor)
        {
            if (oldDoctor == null)
                return;
            if (this.Doctor != null)
                if (this.Doctor.Contains(oldDoctor))
                {
                    this.Doctor.Remove(oldDoctor);
                    oldDoctor.SetSpecialization((Specialization)null);
                }
        }

        public void RemoveAllDoctor()
        {
            if (Doctor != null)
            {
                System.Collections.ArrayList tmpDoctor = new System.Collections.ArrayList();
                foreach (Doctor oldDoctor in Doctor)
                    tmpDoctor.Add(oldDoctor);
                Doctor.Clear();
                foreach (Doctor oldDoctor in tmpDoctor)
                    oldDoctor.SetSpecialization((Specialization)null);
                tmpDoctor.Clear();
            }
        }

    }
}