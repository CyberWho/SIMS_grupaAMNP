/***********************************************************************
 * Module:  Perscription.cs
 * Author:  Dell
 * Purpose: Definition of the Class Bolnica.Model.Patient.Perscription
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class Perscription
    {
        public int Id { get; set; }
        public Boolean IsActive { get; set; }
        public String Description { get; set; }
        public Drug Drug { get; set; }

        public HealthRecord HealthRecord;

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
                    oldHealthRecord.RemovePerscriptions(this);
                }
                if (newHealthRecord != null)
                {
                    this.HealthRecord = newHealthRecord;
                    this.HealthRecord.AddPerscriptions(this);
                }
            }
        }

    }
}