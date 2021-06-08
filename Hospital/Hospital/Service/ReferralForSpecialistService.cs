/***********************************************************************
 * Module:  ReferralForSpecialistService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.ReferralForSpecialistService
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.IRepository;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
   public class ReferralForSpecialistService
   {
       private IReferralForSpecialistRepo<ReferralForSpecialist> referralForSpecialistRepository;

       public ReferralForSpecialistService()
       {
           referralForSpecialistRepository = new ReferralForSpecialistRepository();
       }
        public ReferralForSpecialist GetReferralForSpecialistById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllReferrals()
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
            return referralForSpecialistRepository.GetAllByHealthRecordId(healthRecordId);
        }


      public System.Collections.ArrayList GetAllReferralsByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteReferralById(int id)
      {
        
         return referralForSpecialistRepository.DeleteById(id);
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
         
         return referralForSpecialistRepository.Add(referral) ;
      }
      
      public ReferralForSpecialist DeactivateReferral(ReferralForSpecialist referral)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList referralForSpecialistServiceB;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetReferralForSpecialistServiceB()
      {
         if (referralForSpecialistServiceB == null)
            referralForSpecialistServiceB = new System.Collections.ArrayList();
         return referralForSpecialistServiceB;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetReferralForSpecialistServiceB(System.Collections.ArrayList newReferralForSpecialistServiceB)
      {
         RemoveAllReferralForSpecialistServiceB();
         foreach (ReferralForSpecialistService oReferralForSpecialistService in newReferralForSpecialistServiceB)
            AddReferralForSpecialistServiceB(oReferralForSpecialistService);
      }
      
      /// <pdGenerated>default New</pdGenerated>
      public void AddReferralForSpecialistServiceB(ReferralForSpecialistService newReferralForSpecialistService)
      {
         if (newReferralForSpecialistService == null)
            return;
         if (this.referralForSpecialistServiceB == null)
            this.referralForSpecialistServiceB = new System.Collections.ArrayList();
         if (!this.referralForSpecialistServiceB.Contains(newReferralForSpecialistService))
            this.referralForSpecialistServiceB.Add(newReferralForSpecialistService);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveReferralForSpecialistServiceB(ReferralForSpecialistService oldReferralForSpecialistService)
      {
         if (oldReferralForSpecialistService == null)
            return;
         if (this.referralForSpecialistServiceB != null)
            if (this.referralForSpecialistServiceB.Contains(oldReferralForSpecialistService))
               this.referralForSpecialistServiceB.Remove(oldReferralForSpecialistService);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllReferralForSpecialistServiceB()
      {
         if (referralForSpecialistServiceB != null)
            referralForSpecialistServiceB.Clear();
      }
   
   }
}