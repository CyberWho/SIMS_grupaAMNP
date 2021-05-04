/***********************************************************************
 * Module:  Allergies.cs
 * Author:  Dell
 * Purpose: Definition of the Class Bolnica.Model.Patient.Allergies
 ***********************************************************************/

namespace Hospital.Model
{
    public class Allergy
    {
        public int Id { get; set; }
        public int allergy_type_id { get; set; }
        public int health_record_id { get; set; }
        public AllergyType allergyType { get; set; }

        public HealthRecord healthRecord;

        /// <pdGenerated>default parent getter</pdGenerated>
        public HealthRecord GetHealthRecord()
        {
            return healthRecord;
        }

        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newHealthRecord</param>
        public void SetHealthRecord(HealthRecord newHealthRecord)
        {
            if (this.healthRecord != newHealthRecord)
            {
                if (this.healthRecord != null)
                {
                    HealthRecord oldHealthRecord = this.healthRecord;
                    this.healthRecord = null;
                    oldHealthRecord.RemoveAllergy(this);
                }
                if (newHealthRecord != null)
                {
                    this.healthRecord = newHealthRecord;
                    this.healthRecord.AddAllergy(this);
                }
            }
        }

        public Allergy(int id, AllergyType allergyType, HealthRecord healthRecord)
        {
            Id = id;
            this.allergyType = allergyType;
            this.healthRecord = healthRecord;
        }

        public Allergy()
        {
        }
    }
}