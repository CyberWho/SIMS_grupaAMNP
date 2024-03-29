/***********************************************************************
 * Module:  AnamnesisController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.AnamnesisController
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Repository;
using Hospital.Service;
using MedicalTreatment = Hospital.Model.MedicalTreatment;

namespace Hospital.Controller
{
    public class AnamnesisController
    {
        public Anamnesis AddAnamnesis(Anamnesis anamnesis)
        {
            // TODO: implement
            return null;
        }

        public Anamnesis GetAnamnesisById(int id)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Anamnesis> GetAllAnamnesesByHealthRecordId(int healthRecordId)
        {
            return anamnesisService.GetAllAnamnesesByHealthRecordId(healthRecordId);
        }
        public ObservableCollection<Perscription> GetAllActivePerscriptionsByHealthRecordId(int healthRecordId)
        {
            return anamnesisService.GetAllActivePerscriptionsByHealthRecordId(healthRecordId);
        }

        public ObservableCollection<Model.MedicalTreatment> GetAllMedicalTreatmentsByHealthRecordId(int healthRecordId)
        {
            return anamnesisService.GetAllMedicalTreatmentsByHealthRecordId(healthRecordId);
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

        public Anamnesis UpdateAnamnesis(Anamnesis anamnesis)
        {
            return anamnesisService.UpdateAnamnesis(anamnesis);
        }

        public Anamnesis NewAnamnesis(Anamnesis anamnesis)
        {
            return anamnesisService.NewAnamnesis(anamnesis);
        }
        public Anamnesis AddMedicalTreatmentToAnamnesis(Anamnesis anamnesis, MedicalTreatment medicalTreatment)
        {
            // TODO: implement
            return null;
        }

        public Anamnesis AddPerscriptionToAnamnesis(Anamnesis anamnesis, Perscription perscription)
        {
            // TODO: implement
            return null;
        }

        public AnamnesisService anamnesisService = new AnamnesisService(new AnamnesisRepository(),new PerscriptionRepository());

    }
}