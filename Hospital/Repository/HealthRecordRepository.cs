/***********************************************************************
 * Module:  HealthRecordRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.HealthRecordRepository
 ***********************************************************************/

using System;

namespace Hospital.Repository
{
   public class HealthRecordRepository
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
      
      public Hospital.Model.HealthRecord NewHealthRecord(Hospital.Model.HealthRecord healthRecord)
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