/***********************************************************************
 * Module:  MedicalTreatment.cs
 * Author:  Dell
 * Purpose: Definition of the Class Bolnica.Model.Patient.MedicalTreatment
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class MedicalTreatment
    {
        public int Id { get; set; }
        public String Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public HealthRecord HealthRecord;
        public System.Collections.ArrayList Drug;

        public HealthRecord GetHealthRecord()
        {
            return HealthRecord;
        }

        public void SetHealthRecord(HealthRecord newHealthRecord)
        {
            if (this.HealthRecord != newHealthRecord)
            {
                if (this.HealthRecord != null)
                {
                    HealthRecord oldHealthRecord = this.HealthRecord;
                    this.HealthRecord = null;
                    oldHealthRecord.RemoveMedicalTreatments(this);
                }
                if (newHealthRecord != null)
                {
                    this.HealthRecord = newHealthRecord;
                    this.HealthRecord.AddMedicalTreatments(this);
                }
            }
        }

        public System.Collections.ArrayList GetDrug()
        {
            if (Drug == null)
                Drug = new System.Collections.ArrayList();
            return Drug;
        }

        public void SetDrug(System.Collections.ArrayList newDrug)
        {
            RemoveAllDrug();
            foreach (Drug oDrug in newDrug)
                AddDrug(oDrug);
        }

        public void AddDrug(Drug newDrug)
        {
            if (newDrug == null)
                return;
            if (this.Drug == null)
                this.Drug = new System.Collections.ArrayList();
            if (!this.Drug.Contains(newDrug))
                this.Drug.Add(newDrug);
        }

        public void RemoveDrug(Drug oldDrug)
        {
            if (oldDrug == null)
                return;
            if (this.Drug != null)
                if (this.Drug.Contains(oldDrug))
                    this.Drug.Remove(oldDrug);
        }

        public void RemoveAllDrug()
        {
            if (Drug != null)
                Drug.Clear();
        }

    }
}