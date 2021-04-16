/***********************************************************************
 * Module:  HealthRecordController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.HealthRecordController
 ***********************************************************************/

using System;

namespace Hospital.Controller
{
   public class HealthRecordController
   {
      public Hospital.Model.HealthRecord GetHealthRecordById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.HealthRecord GetHealthRecordByPatientId(int patientId)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<HealthRecord> GetAllHealthRecords()
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteHealthRecordById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteHealthRecordByPatientId(int patientId)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.HealthRecord UpdateHealthRecord(Hospital.Model.HealthRecord healthRecord)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.HealthRecord AddHealthRecord(Hospital.Model.HealthRecord healthRecord)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.HealthRecord AddAllergiesToHealthRecord(Hospital.Model.HealthRecord healthRecord, Hospital.Model.Allergy allergy)
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Service.HealthRecordService healthRecordService;
   
   }
}