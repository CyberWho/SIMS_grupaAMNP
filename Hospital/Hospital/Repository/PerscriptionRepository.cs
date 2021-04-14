/***********************************************************************
 * Module:  PerscriptionRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.PerscriptionRepository
 ***********************************************************************/

using System;

namespace Hospital.Repository
{
   public class PerscriptionRepository
   {
      public Hospital.Model.Perscription GetPerscriptionById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllPerscriptionsByAnamnesisId(int anamnesisId)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllActivePerscriptions()
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllActivePerscriptionsByAnamnesisId(int anamnesisId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeletePerscriptionById(int id)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean DeleteAllPerscriptionsByAnamnesisId(int anamnesisId)
      {
         // TODO: implement
         return false;
      }
      
      public Hospital.Model.Perscription UpdatePerscription(Hospital.Model.Perscription perscription)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Perscription NewPerscription(Hospital.Model.Perscription perscription)
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