/***********************************************************************
 * Module:  MedicalTreatmentService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.MedicalTreatmentService
 ***********************************************************************/

using System;

namespace Hospital.Service
{
   public class MedicalTreatmentService
   {
      public Hospital.Model.MedicalTreatment GetMedicalTreatmentById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllMedicalTreatmentsByAnamnesisId(int anamnesisId)
      {
         // TODO: implement
         return null;
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
      
      public Hospital.Model.MedicalTreatment UpdateMedicalTreatment(Hospital.Model.MedicalTreatment medicalTreatment)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.MedicalTreatment AddMedicalTreatment(Hospital.Model.MedicalTreatment medicalTreatment)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.MedicalTreatment ChangeMedicalTreatmentEndTime(Hospital.Model.MedicalService medicalTreatment, DateTime newEndTime)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.MedicalTreatment ChangeMedicalTreatmentPeriod(Hospital.Model.MedicalTreatment medicalTreatment, int newPeriod)
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Repository.MedicalTreatment medicalTreatment;
   
   }
}