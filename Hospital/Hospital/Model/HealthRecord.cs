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
        public int Id { get; set; }
        public String Education { get; set; }
        public String Gender { get; set; }
        public City PlaceOfBirth { get; set; }
        public Patient Patient { get; set; }

        public System.Collections.ArrayList Allergies;
        public System.Collections.ArrayList Perscriptions;
        public System.Collections.ArrayList MedicalTreatments;

        public System.Collections.ArrayList GetAllergies()
        {
            if (Allergies == null)
                Allergies = new System.Collections.ArrayList();
            return Allergies;
        }

        public void SetAllergies(System.Collections.ArrayList newAllergies)
        {
            RemoveAllAllergies();
            foreach (Allergies oAllergies in newAllergies)
                AddAllergies(oAllergies);
        }

        public void AddAllergies(Allergies newAllergies)
        {
            if (newAllergies == null)
                return;
            if (this.Allergies == null)
                this.Allergies = new System.Collections.ArrayList();
            if (!this.Allergies.Contains(newAllergies))
                this.Allergies.Add(newAllergies);
        }

        public void RemoveAllergies(Allergies oldAllergies)
        {
            if (oldAllergies == null)
                return;
            if (this.Allergies != null)
                if (this.Allergies.Contains(oldAllergies))
                    this.Allergies.Remove(oldAllergies);
        }

        public void RemoveAllAllergies()
        {
            if (Allergies != null)
                Allergies.Clear();
        }

        public System.Collections.ArrayList GetPerscriptions()
        {
            if (Perscriptions == null)
                Perscriptions = new System.Collections.ArrayList();
            return Perscriptions;
        }

        public void SetPerscriptions(System.Collections.ArrayList newPerscriptions)
        {
            RemoveAllPerscriptions();
            foreach (Perscription oPerscription in newPerscriptions)
                AddPerscriptions(oPerscription);
        }

        public void AddPerscriptions(Perscription newPerscription)
        {
            if (newPerscription == null)
                return;
            if (this.Perscriptions == null)
                this.Perscriptions = new System.Collections.ArrayList();
            if (!this.Perscriptions.Contains(newPerscription))
            {
                this.Perscriptions.Add(newPerscription);
                newPerscription.SetHealthRecord(this);
            }
        }

        public void RemovePerscriptions(Perscription oldPerscription)
        {
            if (oldPerscription == null)
                return;
            if (this.Perscriptions != null)
                if (this.Perscriptions.Contains(oldPerscription))
                {
                    this.Perscriptions.Remove(oldPerscription);
                    oldPerscription.SetHealthRecord((HealthRecord)null);
                }
        }

        public void RemoveAllPerscriptions()
        {
            if (Perscriptions != null)
            {
                System.Collections.ArrayList tmpPerscriptions = new System.Collections.ArrayList();
                foreach (Perscription oldPerscription in Perscriptions)
                    tmpPerscriptions.Add(oldPerscription);
                Perscriptions.Clear();
                foreach (Perscription oldPerscription in tmpPerscriptions)
                    oldPerscription.SetHealthRecord((HealthRecord)null);
                tmpPerscriptions.Clear();
            }
        }

        public System.Collections.ArrayList GetMedicalTreatments()
        {
            if (MedicalTreatments == null)
                MedicalTreatments = new System.Collections.ArrayList();
            return MedicalTreatments;
        }

        public void SetMedicalTreatments(System.Collections.ArrayList newMedicalTreatments)
        {
            RemoveAllMedicalTreatments();
            foreach (MedicalTreatment oMedicalTreatment in newMedicalTreatments)
                AddMedicalTreatments(oMedicalTreatment);
        }

        public void AddMedicalTreatments(MedicalTreatment newMedicalTreatment)
        {
            if (newMedicalTreatment == null)
                return;
            if (this.MedicalTreatments == null)
                this.MedicalTreatments = new System.Collections.ArrayList();
            if (!this.MedicalTreatments.Contains(newMedicalTreatment))
            {
                this.MedicalTreatments.Add(newMedicalTreatment);
                newMedicalTreatment.SetHealthRecord(this);
            }
        }

        public void RemoveMedicalTreatments(MedicalTreatment oldMedicalTreatment)
        {
            if (oldMedicalTreatment == null)
                return;
            if (this.MedicalTreatments != null)
                if (this.MedicalTreatments.Contains(oldMedicalTreatment))
                {
                    this.MedicalTreatments.Remove(oldMedicalTreatment);
                    oldMedicalTreatment.SetHealthRecord((HealthRecord)null);
                }
        }

        public void RemoveAllMedicalTreatments()
        {
            if (MedicalTreatments != null)
            {
                System.Collections.ArrayList tmpMedicalTreatments = new System.Collections.ArrayList();
                foreach (MedicalTreatment oldMedicalTreatment in MedicalTreatments)
                    tmpMedicalTreatments.Add(oldMedicalTreatment);
                MedicalTreatments.Clear();
                foreach (MedicalTreatment oldMedicalTreatment in tmpMedicalTreatments)
                    oldMedicalTreatment.SetHealthRecord((HealthRecord)null);
                tmpMedicalTreatments.Clear();
            }
        }

    }
}