/***********************************************************************
 * Module:  RefferalForClinicalTreatmentController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.RefferalForClinicalTreatmentController
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Controller
{
   public class RefferalForClinicalTreatmentController
   {
      public ObservableCollection<ReferralForClinicalTreatment> GetAllReferralsForClinicalTreatment()
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<ReferralForClinicalTreatment> GetAllReferralsForClinicalTreatmentByPatientId(int patientId)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<ReferralForClinicalTreatment> GetAllReferralsForClinicalTreatmentByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<ReferralForClinicalTreatment> GetAllReferralsForClinicalTreatmentByRoomId(int roomId)
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
      
      public ObservableCollection<ReferralForClinicalTreatment> GetAllActiveReferralsForClinicalTreatmentByPatientId(int patientId)
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
   
      public Hospital.Service.ReferralForClinicalTreatmentService referralForClinicalTreatmentService;
   
   }
}