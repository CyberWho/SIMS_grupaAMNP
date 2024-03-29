/***********************************************************************
 * Module:  Class20.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.Class20
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Controller
{
   public class RefferalForSpecialistController
   {
      public ReferralForSpecialist GetReferralForSpecialistById(int id)
      {
          return referralForSpecialistService.GetReferralForSpecialistById(id);
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
      
      public ReferralForSpecialist UpdateReferral(ReferralForSpecialist referral)
      {
         // TODO: implement
         return null;
      }
      
      public ReferralForSpecialist AddReferral(ReferralForSpecialist referral)
      {
            return referralForSpecialistService.AddReferral(referral);
      }
      
      public ReferralForSpecialist DeactivateReferral(ReferralForSpecialist referral)
      {
         // TODO: implement
         return null;
      }
   
      public Service.ReferralForSpecialistService referralForSpecialistService = new Service.ReferralForSpecialistService(new ReferralForSpecialistRepository());
   
   }
}