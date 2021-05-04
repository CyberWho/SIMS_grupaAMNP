/***********************************************************************
 * Module:  PerscriptionService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.PerscriptionService
 ***********************************************************************/

using System;
using Hospital.Repository;
namespace Hospital.Service
{
    public class PerscriptionService
   {
      public Model.Perscription GetPerscriptionById(int id)
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
      
      public Model.Perscription UpdatePerscription(Model.Perscription perscription)
      {
         // TODO: implement
         return null;
      }
      
      public Model.Perscription AddPerscription(Model.Perscription perscription)
      {
         return new PerscriptionRepository().NewPerscription(perscription);
      }
      
      public Model.Perscription DeactivatePerscription(Model.Perscription perscription)
      {
         // TODO: implement
         return null;
      }
   
      public PerscriptionRepository perscriptionRepository;
   
   }
}