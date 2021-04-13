/***********************************************************************
 * Module:  ReferralForClinicalTreatmentService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.ReferralForClinicalTreatmentService
 ***********************************************************************/

using System;

namespace Hospital.Service
{
   public class ReferralForClinicalTreatmentService
   {
      public System.Array<ReferralForClinicalTreatment> GetAllReferralsForClinicalTreatment()
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<ReferralForClinicalTreatment> GetAllReferralsForClinicalTreatmentByPatientId(int patientId)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<ReferralForClinicalTreatment> GetAllReferralsForClinicalTreatmentByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<ReferralForClinicalTreatment> GetAllReferralsForClinicalTreatmentByRoomId(int roomId)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.ReferralForClinicalTreatment GetReferralForClinicalTreatmentById()
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteReferralForClinicalTreatmentById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteReferralForClinicalTreatmentByPatientId(int patientId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteReferralForClinicalTreatmentByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.ReferralForClinicalTreatment UpdateReferralForClinicalTreatment(Hospital.Model.ReferralForClinicalTreatment referralForClinicalTreatment)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.ReferralForClinicalTreatment AddReferralForClinicalTreatment(Hospital.Model.ReferralForClinicalTreatment referralForClinicalTreatment)
      {
         // TODO: implement
         return null;
      }
      
      public int GetLastId()
      {
         // TODO: implement
         return 0;
      }
      
      public System.Array<ReferralForClinicalTreatment> GetAllActiveReferralsForClinicalTreatmentByPatientId(int patientId)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.ReferralForClinicalTreatment DeactivateReferralForClinicalTreatment(Hospital.Model.ReferralForClinicalTreatment referralForClinicalTreatment)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.ReferralForClinicalTreatment ProlongReferralForClinicalTreatment(Hospital.Model.ReferralForClinicalTreatment referralForClinicalTreatment, DateTime newEndDate)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.ReferralForClinicalTreatment ChangeRoomReferralForClinicalTreatment(Hospital.Model.ReferralForClinicalTreatment referralForClinicalTreatment, Hospital.Model.Room newRoom)
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Repository.ReferralForClinicalTreatmentRepository referralForClinicalTreatmentRepository;
   
   }
}