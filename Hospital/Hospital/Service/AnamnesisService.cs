/***********************************************************************
 * Module:  AnamnesisService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.AnamnesisService
 ***********************************************************************/

using Hospital.Repository;
using System;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Service
{
    public class AnamnesisService
    {
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
            return anamnesisRepository.GetAllAnamnesesByHealthRecordId(healthRecordId);
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
            return new AnamnesisRepository().UpdateAnamnesis(anamnesis);
        }

        public Model.Anamnesis NewAnamnesis(Model.Anamnesis anamnesis)
        {
            return new AnamnesisRepository().NewAnamnesis(anamnesis);
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

        public AnamnesisRepository anamnesisRepository = new AnamnesisRepository();

    }
}