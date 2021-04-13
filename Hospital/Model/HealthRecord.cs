/***********************************************************************
 * Module:  HealthRecord.cs
 * Author:  Dell
 * Purpose: Definition of the Class Bolnica.Model.Patient.HealthRecord
 ***********************************************************************/

using System;

namespace Hospital.Model
{
   public class HealthRecord
   {
      public int Id;
      public Gender Gender;
      public MaritalStatus MaritalStatus;
      
      public Patient patient;
      public System.Collections.ArrayList allergy;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetAllergy()
      {
         if (allergy == null)
            allergy = new System.Collections.ArrayList();
         return allergy;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetAllergy(System.Collections.ArrayList newAllergy)
      {
         RemoveAllAllergy();
         foreach (Allergy oAllergy in newAllergy)
            AddAllergy(oAllergy);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddAllergy(Allergy newAllergy)
      {
         if (newAllergy == null)
            return;
         if (this.allergy == null)
            this.allergy = new System.Collections.ArrayList();
         if (!this.allergy.Contains(newAllergy))
         {
            this.allergy.Add(newAllergy);
            newAllergy.SetHealthRecord(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveAllergy(Allergy oldAllergy)
      {
         if (oldAllergy == null)
            return;
         if (this.allergy != null)
            if (this.allergy.Contains(oldAllergy))
            {
               this.allergy.Remove(oldAllergy);
               oldAllergy.SetHealthRecord((HealthRecord)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllAllergy()
      {
         if (allergy != null)
         {
            System.Collections.ArrayList tmpAllergy = new System.Collections.ArrayList();
            foreach (Allergy oldAllergy in allergy)
               tmpAllergy.Add(oldAllergy);
            allergy.Clear();
            foreach (Allergy oldAllergy in tmpAllergy)
               oldAllergy.SetHealthRecord((HealthRecord)null);
            tmpAllergy.Clear();
         }
      }
      public City PlaceOfBirth;
      public System.Collections.ArrayList anamnesis;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetAnamnesis()
      {
         if (anamnesis == null)
            anamnesis = new System.Collections.ArrayList();
         return anamnesis;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetAnamnesis(System.Collections.ArrayList newAnamnesis)
      {
         RemoveAllAnamnesis();
         foreach (Anamnesis oAnamnesis in newAnamnesis)
            AddAnamnesis(oAnamnesis);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddAnamnesis(Anamnesis newAnamnesis)
      {
         if (newAnamnesis == null)
            return;
         if (this.anamnesis == null)
            this.anamnesis = new System.Collections.ArrayList();
         if (!this.anamnesis.Contains(newAnamnesis))
         {
            this.anamnesis.Add(newAnamnesis);
            newAnamnesis.SetHealthRecord(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveAnamnesis(Anamnesis oldAnamnesis)
      {
         if (oldAnamnesis == null)
            return;
         if (this.anamnesis != null)
            if (this.anamnesis.Contains(oldAnamnesis))
            {
               this.anamnesis.Remove(oldAnamnesis);
               oldAnamnesis.SetHealthRecord((HealthRecord)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllAnamnesis()
      {
         if (anamnesis != null)
         {
            System.Collections.ArrayList tmpAnamnesis = new System.Collections.ArrayList();
            foreach (Anamnesis oldAnamnesis in anamnesis)
               tmpAnamnesis.Add(oldAnamnesis);
            anamnesis.Clear();
            foreach (Anamnesis oldAnamnesis in tmpAnamnesis)
               oldAnamnesis.SetHealthRecord((HealthRecord)null);
            tmpAnamnesis.Clear();
         }
      }
      public ReferralForClinicalTreatment[] referralForClinicalTreatment;
      public ClinicalTreatment[] clinicalTreatment;
   
   }
}