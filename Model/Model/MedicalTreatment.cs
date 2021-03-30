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
      public int Id;
      public DateTime StartTime;
      public DateTime EndTime;
      public String Description;
      
      public System.Collections.ArrayList drug;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetDrug()
      {
         if (drug == null)
            drug = new System.Collections.ArrayList();
         return drug;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetDrug(System.Collections.ArrayList newDrug)
      {
         RemoveAllDrug();
         foreach (Drug oDrug in newDrug)
            AddDrug(oDrug);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddDrug(Drug newDrug)
      {
         if (newDrug == null)
            return;
         if (this.drug == null)
            this.drug = new System.Collections.ArrayList();
         if (!this.drug.Contains(newDrug))
            this.drug.Add(newDrug);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveDrug(Drug oldDrug)
      {
         if (oldDrug == null)
            return;
         if (this.drug != null)
            if (this.drug.Contains(oldDrug))
               this.drug.Remove(oldDrug);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllDrug()
      {
         if (drug != null)
            drug.Clear();
      }
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
               oldHealthRecord.RemoveMedicalTreatments(this);
            }
            if (newHealthRecord != null)
            {
               this.healthRecord = newHealthRecord;
               this.healthRecord.AddMedicalTreatments(this);
            }
         }
      }
   
   }
}