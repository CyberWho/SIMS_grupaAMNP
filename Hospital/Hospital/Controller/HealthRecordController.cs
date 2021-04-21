/***********************************************************************
 * Module:  HealthRecordController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.HealthRecordController
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Service;

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
         return new HealthRecordService().GetHealthRecordByPatientId(patientId);
      }
      
      public ObservableCollection<HealthRecord> GetAllHealthRecords()
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteHealthRecordById(int id)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean DeleteHealthRecordByPatientId(int patientId)
      {
         // TODO: implement
         return false;
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
      
      public Hospital.Model.HealthRecord AddAllergiesToHealthRecord(Hospital.Model.HealthRecord healthRecord, Hospital.Model.Anamnesis allergy)
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Service.HealthRecordService healthRecordService;
   
   }
}