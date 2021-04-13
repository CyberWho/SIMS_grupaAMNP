/***********************************************************************
 * Module:  HealthRecordService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.HealthRecordService
 ***********************************************************************/

using System;

namespace Hospital.Service
{
   public class HealthRecordService
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
   
      public Hospital.Repository.HealthRecordRepository healthRecordRepository;
   
   }
}