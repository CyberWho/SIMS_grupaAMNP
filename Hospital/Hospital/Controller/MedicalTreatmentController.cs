/***********************************************************************
 * Module:  MedicalTreatmentController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.MedicalTreatmentController
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Controller
{
   public class MedicalTreatmentController
   {
      public MedicalTreatment GetMedicalTreatmentById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<MedicalTreatment> GetAllMedicalTreatmentsByAnamnesisId(int anamnesisId)
      {
          return medicalTreatmentService.GetAllMedicalTreatmentsByAnamnesisId(anamnesisId);
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
      
      public MedicalTreatment UpdateMedicalTreatment(MedicalTreatment medicalTreatment)
      {
         // TODO: implement
         return null;
      }
      
      public MedicalTreatment AddMedicalTreatment(MedicalTreatment medicalTreatment)
      {
         // TODO: implement
         return null;
      }
      
      public MedicalTreatment ChangeMedicalTreatmentEndTime(MedicalService medicalTreatment, DateTime newEndTime)
      {
         // TODO: implement
         return null;
      }
      
      public MedicalTreatment ChangeMedicalTreatmentPeriod(MedicalTreatment medicalTreatment, int newPeriod)
      {
         // TODO: implement
         return null;
      }
   
      public Service.MedicalTreatmentService medicalTreatmentService;
   
   }
}