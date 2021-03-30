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
      public int Id;
      public Boolean IsActive;
      public String Description;
      
      public Drug drug;
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
               oldHealthRecord.RemovePerscriptions(this);
            }
            if (newHealthRecord != null)
            {
               this.healthRecord = newHealthRecord;
               this.healthRecord.AddPerscriptions(this);
            }
         }
      }
   
   }
}