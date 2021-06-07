/***********************************************************************
 * Module:  MedicalTreatmentService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.MedicalTreatmentService
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.IRepository;
using Hospital.Repository;

namespace Hospital.Service
{
   public class MedicalTreatmentService
   {
       private IMedicalTreatmentRepo<Model.MedicalTreatment> medicalTreatment;

       public MedicalTreatmentService()
       {
           medicalTreatment = new Repository.MedicalTreatment();
       }
        public Model.MedicalTreatment GetMedicalTreatmentById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<Model.MedicalTreatment> GetAllMedicalTreatmentsByAnamnesisId(int anamnesisId)
      {
          return medicalTreatment.GetAllByAnamnesisId(anamnesisId);
      }
      
      public Boolean DeleteMedicalTreatmentById(int id)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean DelelteAllMedicalTreatmentsByAnamnesisId(int anamnesisId)
      {
         // TODO: implement
         return false;
      }
      
      public Model.MedicalTreatment UpdateMedicalTreatment(Model.MedicalTreatment medicalTreatment)
      {
         // TODO: implement
         return null;
      }
      
      public Model.MedicalTreatment AddMedicalTreatment(Model.MedicalTreatment medicalTreatment)
      {
         // TODO: implement
         return null;
      }
      
      public Model.MedicalTreatment ChangeMedicalTreatmentEndTime(Model.MedicalService medicalTreatment, DateTime newEndTime)
      {
         // TODO: implement
         return null;
      }
      
      public Model.MedicalTreatment ChangeMedicalTreatmentPeriod(Model.MedicalTreatment medicalTreatment, int newPeriod)
      {
         // TODO: implement
         return null;
      }

   }
}