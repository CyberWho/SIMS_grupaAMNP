/***********************************************************************
 * Module:  AnamnesisController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.AnamnesisController
 ***********************************************************************/

using System;

namespace Hospital.Controller
{
   public class AnamnesisController
   {
      public Hospital.Model.Anamnesis AddAnamnesis(Hospital.Model.Anamnesis anamnesis)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Anamnesis GetAnamnesisById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Anamnesis> GetAllAnamnesesByHealthRecordId(int healthRecordId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteAnamnesisById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteAnamnesisByHealthRecordId(int healthRecordId)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Anamnesis UpdateAnamnesis(Hospital.Model.Anamnesis anamnesis)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Anamnesis AddMedicalTreatmentToAnamnesis(Hospital.Model.Anamnesis anamnesis, Hospital.Model.MedicalTreatment medicalTreatment)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Anamnesis AddPerscriptionToAnamnesis(Hospital.Model.Anamnesis anamnesis, Hospital.Model.Perscription perscription)
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Service.AnamnesisService anamnesisService;
   
   }
}