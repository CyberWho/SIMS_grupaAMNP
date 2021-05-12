/***********************************************************************
 * Module:  ReferralForClinicalTreatmentService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.ReferralForClinicalTreatmentService
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{

   public class ReferralForClinicalTreatmentService
   {
      public System.Collections.ArrayList GetAllReferralsForClinicalTreatment()
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllReferralsForClinicalTreatmentByPatientId(int patientId)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllReferralsForClinicalTreatmentByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
        public ObservableCollection<ReferralForClinicalTreatment> GetAllActiveReferralsForClinicalTreatmentByHealthRecordId(int healthRecordId)
        {
            return referralForClinicalTreatmentRepository.GetAllActiveReferralsForClinicalTreatmentByHealthRecordId(healthRecordId);
        }


      public System.Collections.ArrayList GetAllReferralsForClinicalTreatmentByRoomId(int roomId)
      {
         // TODO: implement
         return null;
      }
      
      public Model.ReferralForClinicalTreatment GetReferralForClinicalTreatmentById()
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteReferralForClinicalTreatmentById(int id)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean DeleteReferralForClinicalTreatmentByPatientId(int patientId)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean DeleteReferralForClinicalTreatmentByDoctorId(int doctorId)
      {
         // TODO: implement
         return false;
      }
      
      public Model.ReferralForClinicalTreatment UpdateReferralForClinicalTreatment(Model.ReferralForClinicalTreatment referralForClinicalTreatment)
      {
         // TODO: implement
         return null;
      }
      
      public Model.ReferralForClinicalTreatment AddReferralForClinicalTreatment(Model.ReferralForClinicalTreatment referralForClinicalTreatment)
      {
         // TODO: implement
         return null;
      }
      
      public int GetLastId()
      {
         // TODO: implement
         return 0;
      }
      
      public System.Collections.ArrayList GetAllActiveReferralsForClinicalTreatmentByPatientId(int patientId)
      {
         // TODO: implement
         return null;
      }
      
      public Model.ReferralForClinicalTreatment DeactivateReferralForClinicalTreatment(Model.ReferralForClinicalTreatment referralForClinicalTreatment)
      {
         // TODO: implement
         return null;
      }
      
      public Model.ReferralForClinicalTreatment ProlongReferralForClinicalTreatment(Model.ReferralForClinicalTreatment referralForClinicalTreatment, DateTime newEndDate)
      {
         // TODO: implement
         return null;
      }
      
      public Model.ReferralForClinicalTreatment ChangeRoomReferralForClinicalTreatment(Model.ReferralForClinicalTreatment referralForClinicalTreatment, Model.Room newRoom)
      {
         // TODO: implement
         return null;
      }
   
      public Repository.ReferralForClinicalTreatmentRepository referralForClinicalTreatmentRepository = new ReferralForClinicalTreatmentRepository();
   
   }
}