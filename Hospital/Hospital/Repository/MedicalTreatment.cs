/***********************************************************************
 * Module:  MedicalTreatment.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.MedicalTreatment
 ***********************************************************************/

using System;

namespace Hospital.Repository
{
   public class MedicalTreatment
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
      
      public Hospital.Model.MedicalTreatment NewMedicalTreatment(Hospital.Model.MedicalTreatment medicalTreatment)
      {
         // TODO: implement
         return null;
      }
      
      public int GetLastId()
      {
         // TODO: implement
         return 0;
      }
   
   }
}