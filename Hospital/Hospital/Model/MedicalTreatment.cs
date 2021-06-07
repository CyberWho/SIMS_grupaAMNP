/***********************************************************************
 * Module:  MedicalTreatment.cs
 * Author:  Dell
 * Purpose: Definition of the Class Bolnica.Model.Patient.MedicalTreatment
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    /// Period: 2 (na svaka dva sata treba da se pije lek)
    public class MedicalTreatment : IEntity
    {
        public int Id { get; set; }
        public int Period { get; set; }
        public DateRange dateRange { get; set; }
        public String Description { get; set; }

        public Drug Drug { get; set; }
        public int Drug_id { get; set; }
        public Anamnesis anamnesis;
        public int Anamnesis_id { get; set; }
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
                oldAnamnesis.RemoveMedicalTreatments(this);
            }
            if (newAnamnesis != null)
            {
                this.anamnesis = newAnamnesis;
                this.anamnesis.AddMedicalTreatments(this);
            }
        }
    }

    public MedicalTreatment(int id, int period, DateTime startTime, DateTime endTime, string description, Drug drug, Anamnesis anamnesis)
    {
        Id = id;
        Period = period;
        dateRange = new DateRange(startTime, endTime);
        Description = description;
        Drug = drug;
        this.anamnesis = anamnesis;
    }

    public MedicalTreatment()
    {
        dateRange = new DateRange();
    }
}
}