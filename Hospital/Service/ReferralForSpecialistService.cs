/***********************************************************************
 * Module:  ReferralForSpecialistService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.ReferralForSpecialistService
 ***********************************************************************/

using System;

namespace Hospital.Service
{
   public class ReferralForSpecialistService
   {
      public Hospital.Model.ReferralForSpecialist GetReferralForSpecialistById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Referral> GetAllReferrals()
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Referral> GetAllReferralsByPatientId(int patientId)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Referral> GetAllReferralsByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteReferralById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteReferralByPatientId(int patientId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteReferralByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.ReferralForSpecialist UpdateReferral(Hospital.Model.ReferralForSpecialist referral)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.ReferralForSpecialist AddReferral(Hospital.Model.ReferralForSpecialist referral)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.ReferralForSpecialist DeactivateReferral(Hospital.Model.ReferralForSpecialist referral)
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Repository.ReferralForSpecialistRepository referralForSpecialistRepository;
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
      
      /// <pdGenerated>default Add</pdGenerated>
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