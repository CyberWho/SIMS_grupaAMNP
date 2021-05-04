/***********************************************************************
 * Module:  Class20.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.Class20
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Controller
{
   public class RefferalForSpecialistController
   {
      public Hospital.Model.ReferralForSpecialist GetReferralForSpecialistById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<ReferralForSpecialist> GetAllReferrals()
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<ReferralForSpecialist> GetAllReferralsByPatientId(int patientId)
      {
            //TODO: implement
            return null;
      }
        public ObservableCollection<ReferralForSpecialist> GetReferralForSpecialistsByHealthRecordId(int healthRecordId)
        {
            return referralForSpecialistService.GetReferralForSpecialistsByHealthRecordId(healthRecordId);
        }

        public ObservableCollection<ReferralForSpecialist> GetAllReferralsByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteReferralById(int id)
      {

            return referralForSpecialistService.DeleteReferralById(id);
      }
      
      public Boolean DeleteReferralByPatientId(int patientId)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean DeleteReferralByDoctorId(int doctorId)
      {
         // TODO: implement
         return false;
      }
      
      public Hospital.Model.ReferralForSpecialist UpdateReferral(Hospital.Model.ReferralForSpecialist referral)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.ReferralForSpecialist AddReferral(Hospital.Model.ReferralForSpecialist referral)
      {
            return referralForSpecialistService.AddReferral(referral);
      }
      
      public Hospital.Model.ReferralForSpecialist DeactivateReferral(Hospital.Model.ReferralForSpecialist referral)
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Service.ReferralForSpecialistService referralForSpecialistService = new Service.ReferralForSpecialistService();
   
   }
}