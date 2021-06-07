/***********************************************************************
 * Module:  AnamnesisService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.AnamnesisService
 ***********************************************************************/

using Hospital.Repository;
using System;
using System.Collections.ObjectModel;
using Hospital.IRepository;
using Hospital.Model;

namespace Hospital.Service
{
    public class AnamnesisService
    {
        private IAnamnesisRepo<Anamnesis> anamnesisRepository;
        private IPerscriptionRepo<Perscription> perscriptionRepository;

        public AnamnesisService(IAnamnesisRepo<Anamnesis> iAnamnesisRepo,
            IPerscriptionRepo<Perscription> iPerscriptionRepo)
        {
            anamnesisRepository = iAnamnesisRepo;
            perscriptionRepository = iPerscriptionRepo;
        }
        public Model.Anamnesis AddAnamnesis(Model.Anamnesis anamnesis)
        {
            // TODO: implement
            return null;
        }

        public Model.Anamnesis GetAnamnesisById(int id)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Anamnesis> GetAllAnamnesesByHealthRecordId(int healthRecordId)
        {
            return anamnesisRepository.GetAllByHealthRecordId(healthRecordId);
        }

        public ObservableCollection<Perscription> GetAllActivePerscriptionsByHealthRecordId(int healthRecordId)
        {
            ObservableCollection<Anamnesis> anamneses = anamnesisRepository.GetAllByHealthRecordId(healthRecordId);
            ObservableCollection<Perscription> perscriptions = new ObservableCollection<Perscription>();
            foreach(Anamnesis anamnesis in anamneses)
            {
                ObservableCollection<Perscription> perscriptionInAnamnesis = perscriptionRepository.GetAllActiveByAnamnesisId(anamnesis.Id);
                foreach(Perscription perscription in perscriptionInAnamnesis)
                {
                    perscriptions.Add(perscription);
                }
            }
            return perscriptions;
        }

        internal ObservableCollection<Model.MedicalTreatment> GetAllMedicalTreatmentsByHealthRecordId(int healthRecordId)
        {
            ObservableCollection<Anamnesis> anamneses = anamnesisRepository.GetAllByHealthRecordId(healthRecordId);
            ObservableCollection<Model.MedicalTreatment> medicalTreatments = new ObservableCollection<Model.MedicalTreatment>();
            foreach (Anamnesis anamnesis in anamneses)
            {
                ObservableCollection<Model.MedicalTreatment> medicalTreatmentsInAnamnesis =
                    new Repository.MedicalTreatment().GetAllMedicalTreatmentsByAnamnesisId(anamnesis.Id);
                foreach (Model.MedicalTreatment medicalTreatment in medicalTreatmentsInAnamnesis)
                {
                    medicalTreatments.Add(medicalTreatment);
                }
            }

            return medicalTreatments;
        }

        public Boolean DeleteAnamnesisById(int id)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteAnamnesisByHealthRecordId(int healthRecordId)
        {
            // TODO: implement
            return false;
        }

        public Model.Anamnesis UpdateAnamnesis(Model.Anamnesis anamnesis)
        {
            return new AnamnesisRepository().Update(anamnesis);
        }

        public Model.Anamnesis NewAnamnesis(Model.Anamnesis anamnesis)
        {
            return new AnamnesisRepository().Add(anamnesis);
        }

        public Model.Anamnesis AddMedicalTreatmentToAnamnesis(Model.Anamnesis anamnesis, Model.MedicalTreatment medicalTreatment)
        {
            // TODO: implement
            return null;
        }

        public Model.Anamnesis AddPerscriptionToAnamnesis(Model.Anamnesis anamnesis, Model.Perscription perscription)
        {
            // TODO: implement
            return null;
        }


    }
}