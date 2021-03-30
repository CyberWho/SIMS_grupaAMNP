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
      public String Education;
      public Gender Gender;
      
      public Patient patient;
      public System.Collections.ArrayList allergies;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetAllergies()
      {
         if (allergies == null)
            allergies = new System.Collections.ArrayList();
         return allergies;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetAllergies(System.Collections.ArrayList newAllergies)
      {
         RemoveAllAllergies();
         foreach (Allergies oAllergies in newAllergies)
            AddAllergies(oAllergies);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddAllergies(Allergies newAllergies)
      {
         if (newAllergies == null)
            return;
         if (this.allergies == null)
            this.allergies = new System.Collections.ArrayList();
         if (!this.allergies.Contains(newAllergies))
            this.allergies.Add(newAllergies);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveAllergies(Allergies oldAllergies)
      {
         if (oldAllergies == null)
            return;
         if (this.allergies != null)
            if (this.allergies.Contains(oldAllergies))
               this.allergies.Remove(oldAllergies);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllAllergies()
      {
         if (allergies != null)
            allergies.Clear();
      }
      public City placeOfBirth;
      public System.Collections.ArrayList perscriptions;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetPerscriptions()
      {
         if (perscriptions == null)
            perscriptions = new System.Collections.ArrayList();
         return perscriptions;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetPerscriptions(System.Collections.ArrayList newPerscriptions)
      {
         RemoveAllPerscriptions();
         foreach (Perscription oPerscription in newPerscriptions)
            AddPerscriptions(oPerscription);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddPerscriptions(Perscription newPerscription)
      {
         if (newPerscription == null)
            return;
         if (this.perscriptions == null)
            this.perscriptions = new System.Collections.ArrayList();
         if (!this.perscriptions.Contains(newPerscription))
         {
            this.perscriptions.Add(newPerscription);
            newPerscription.SetHealthRecord(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemovePerscriptions(Perscription oldPerscription)
      {
         if (oldPerscription == null)
            return;
         if (this.perscriptions != null)
            if (this.perscriptions.Contains(oldPerscription))
            {
               this.perscriptions.Remove(oldPerscription);
               oldPerscription.SetHealthRecord((HealthRecord)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllPerscriptions()
      {
         if (perscriptions != null)
         {
            System.Collections.ArrayList tmpPerscriptions = new System.Collections.ArrayList();
            foreach (Perscription oldPerscription in perscriptions)
               tmpPerscriptions.Add(oldPerscription);
            perscriptions.Clear();
            foreach (Perscription oldPerscription in tmpPerscriptions)
               oldPerscription.SetHealthRecord((HealthRecord)null);
            tmpPerscriptions.Clear();
         }
      }
      public System.Collections.ArrayList medicalTreatments;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetMedicalTreatments()
      {
         if (medicalTreatments == null)
            medicalTreatments = new System.Collections.ArrayList();
         return medicalTreatments;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetMedicalTreatments(System.Collections.ArrayList newMedicalTreatments)
      {
         RemoveAllMedicalTreatments();
         foreach (MedicalTreatment oMedicalTreatment in newMedicalTreatments)
            AddMedicalTreatments(oMedicalTreatment);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddMedicalTreatments(MedicalTreatment newMedicalTreatment)
      {
         if (newMedicalTreatment == null)
            return;
         if (this.medicalTreatments == null)
            this.medicalTreatments = new System.Collections.ArrayList();
         if (!this.medicalTreatments.Contains(newMedicalTreatment))
         {
            this.medicalTreatments.Add(newMedicalTreatment);
            newMedicalTreatment.SetHealthRecord(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveMedicalTreatments(MedicalTreatment oldMedicalTreatment)
      {
         if (oldMedicalTreatment == null)
            return;
         if (this.medicalTreatments != null)
            if (this.medicalTreatments.Contains(oldMedicalTreatment))
            {
               this.medicalTreatments.Remove(oldMedicalTreatment);
               oldMedicalTreatment.SetHealthRecord((HealthRecord)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllMedicalTreatments()
      {
         if (medicalTreatments != null)
         {
            System.Collections.ArrayList tmpMedicalTreatments = new System.Collections.ArrayList();
            foreach (MedicalTreatment oldMedicalTreatment in medicalTreatments)
               tmpMedicalTreatments.Add(oldMedicalTreatment);
            medicalTreatments.Clear();
            foreach (MedicalTreatment oldMedicalTreatment in tmpMedicalTreatments)
               oldMedicalTreatment.SetHealthRecord((HealthRecord)null);
            tmpMedicalTreatments.Clear();
         }
      }
   
   }
}