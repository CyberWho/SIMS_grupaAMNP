/***********************************************************************
 * Module:  Perscription.cs
 * Author:  Dell
 * Purpose: Definition of the Class Bolnica.Model.Patient.Perscription
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class Perscription : IEntity
    {
        public int Id { get; set; }
        public Boolean IsActive { get; set; }
        public String Description { get; set; }

        public Drug Drug { get; set; }
        public int Drug_id { get; set; }
        public Anamnesis anamnesis { get; set; }

        /// <pdGenerated>default parent getter</pdGenerated>
        public Anamnesis GetAnamnesis()
        {
            return anamnesis;
        }

        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newAnamnesis</param>
        public void SetAnamnesis(Anamnesis newAnamnesis)
        {
            if (this.anamnesis != newAnamnesis)
            {
                if (this.anamnesis != null)
                {
                    Anamnesis oldAnamnesis = this.anamnesis;
                    this.anamnesis = null;
                    oldAnamnesis.RemovePerscriptions(this);
                }
                if (newAnamnesis != null)
                {
                    this.anamnesis = newAnamnesis;
                    this.anamnesis.AddPerscriptions(this);
                }
            }
        }

        public Perscription(int id, bool isActive, string description, Drug drug, Anamnesis anamnesis)
        {
            Id = id;
            IsActive = isActive;
            Description = description;
            Drug = drug;
            this.anamnesis = anamnesis;
        }

        public Perscription()
        {
        }
    }
}