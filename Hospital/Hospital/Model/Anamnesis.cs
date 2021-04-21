/***********************************************************************
 * Module:  Anamnesis.cs
 * Author:  Nikola
 * Purpose: Definition of the Class Hospital.Model.Anamnesis
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;

namespace Hospital.Model
{
    public class Anamnesis
    {
        public int Id { get; set; }
        public String Description { get; set; }
        public HealthRecord healthRecord { get; set; }

        public ObservableCollection<Perscription> Perscriptions;

        /// <pdGenerated>default getter</pdGenerated>
        public ObservableCollection<Perscription> GetPerscriptions()
        {
            if (Perscriptions == null)
                Perscriptions = new ObservableCollection<Perscription>();
            return Perscriptions;
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
            if (this.Perscriptions == null)
                this.Perscriptions = new ObservableCollection<Perscription>();
            if (!this.Perscriptions.Contains(newPerscription))
            {
                this.Perscriptions.Add(newPerscription);
                newPerscription.SetAnamnesis(this);
            }
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemovePerscriptions(Perscription oldPerscription)
        {
            if (oldPerscription == null)
                return;
            if (this.Perscriptions != null)
                if (this.Perscriptions.Contains(oldPerscription))
                {
                    this.Perscriptions.Remove(oldPerscription);
                    oldPerscription.SetAnamnesis((Anamnesis)null);
                }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllPerscriptions()
        {
            if (Perscriptions != null)
            {
                System.Collections.ArrayList tmpPerscriptions = new System.Collections.ArrayList();
                foreach (Perscription oldPerscription in Perscriptions)
                    tmpPerscriptions.Add(oldPerscription);
                Perscriptions.Clear();
                foreach (Perscription oldPerscription in tmpPerscriptions)
                    oldPerscription.SetAnamnesis((Anamnesis)null);
                tmpPerscriptions.Clear();
            }
        }
        public Appointment appointment;
        public ObservableCollection<MedicalTreatment> MedicalTreatments;

        /// <pdGenerated>default getter</pdGenerated>
        public ObservableCollection<MedicalTreatment> GetMedicalTreatments()
        {
            if (MedicalTreatments == null)
                MedicalTreatments = new ObservableCollection<MedicalTreatment>();
            return MedicalTreatments;
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
            if (this.MedicalTreatments == null)
                this.MedicalTreatments = new ObservableCollection<MedicalTreatment>();
            if (!this.MedicalTreatments.Contains(newMedicalTreatment))
            {
                this.MedicalTreatments.Add(newMedicalTreatment);
                newMedicalTreatment.SetAnamnesis(this);
            }
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveMedicalTreatments(MedicalTreatment oldMedicalTreatment)
        {
            if (oldMedicalTreatment == null)
                return;
            if (this.MedicalTreatments != null)
                if (this.MedicalTreatments.Contains(oldMedicalTreatment))
                {
                    this.MedicalTreatments.Remove(oldMedicalTreatment);
                    oldMedicalTreatment.SetAnamnesis((Anamnesis)null);
                }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllMedicalTreatments()
        {
            if (MedicalTreatments != null)
            {
                System.Collections.ArrayList tmpMedicalTreatments = new System.Collections.ArrayList();
                foreach (MedicalTreatment oldMedicalTreatment in MedicalTreatments)
                    tmpMedicalTreatments.Add(oldMedicalTreatment);
                MedicalTreatments.Clear();
                foreach (MedicalTreatment oldMedicalTreatment in tmpMedicalTreatments)
                    oldMedicalTreatment.SetAnamnesis((Anamnesis)null);
                tmpMedicalTreatments.Clear();
            }
        }
        public HealthRecord healthRecord { get; set; }


       

        public Anamnesis(int id, string description, ObservableCollection<Perscription> perscriptions, Appointment appointment, ObservableCollection<MedicalTreatment> medicalTreatments, HealthRecord healthRecord)
        {
            this.Id = id;
            Description = description;
            this.Perscriptions = perscriptions;
            this.appointment = appointment;
            this.MedicalTreatments = medicalTreatments;
            this.healthRecord = healthRecord;
        }



        public Anamnesis()
        {
        }
    }
}