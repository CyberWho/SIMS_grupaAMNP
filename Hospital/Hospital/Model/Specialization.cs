/***********************************************************************
 * Module:  Specialization.cs
 * Author:  Pedja
 * Purpose: Definition of the Class Specialization
 ***********************************************************************/

using System.Collections;
using System.Runtime.InteropServices;

namespace Hospital.Model
{
    public class Specialization
    {
        public int id { get; set; }
        public string Type { get; set; }

        public ArrayList doctor;

        /// <pdGenerated>default getter</pdGenerated>
        public ArrayList GetDoctor()
        {
            if (doctor == null)
                doctor = new ArrayList();
            return doctor;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetDoctor(ArrayList newDoctor)
        {
            RemoveAllDoctor();
            foreach (Doctor oDoctor in newDoctor)
                AddDoctor(oDoctor);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddDoctor(Doctor newDoctor)
        {
            if (newDoctor == null)
                return;
            if (this.doctor == null)
                this.doctor = new ArrayList();
            if (!this.doctor.Contains(newDoctor))
            {
                this.doctor.Add(newDoctor);
                newDoctor.SetSpecialization(this);
            }
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveDoctor(Doctor oldDoctor)
        {
            if (oldDoctor == null)
                return;
            if (this.doctor != null)
                if (this.doctor.Contains(oldDoctor))
                {
                    this.doctor.Remove(oldDoctor);
                    oldDoctor.SetSpecialization((Specialization)null);
                }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllDoctor()
        {
            if (doctor != null)
            {
                ArrayList tmpDoctor = new ArrayList();
                foreach (Doctor oldDoctor in doctor)
                    tmpDoctor.Add(oldDoctor);
                doctor.Clear();
                foreach (Doctor oldDoctor in tmpDoctor)
                    oldDoctor.SetSpecialization((Specialization)null);
                tmpDoctor.Clear();
            }
        }

        public Specialization(string type, ArrayList doctor)
        {
            Type = type;
            this.doctor = doctor;
        }

        public Specialization(int id, string type)
        {
            this.id = id;
            this.Type = type;
        }

        public Specialization()
        {
        }
    }
}