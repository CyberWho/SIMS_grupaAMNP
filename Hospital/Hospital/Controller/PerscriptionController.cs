/***********************************************************************
 * Module:  PerscriptionController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.PerscriptionController
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Repository;
using Hospital.Service;

namespace Hospital.Controller
{
   public class PerscriptionController
   {
      public Perscription GetPerscriptionById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<Perscription> GetAllPerscriptionsByAnamnesisId(int anamnesisId)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<Perscription> GetAllActivePerscriptions()
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<Perscription> GetAllActivePerscriptionsByAnamnesisId(int anamnesisId)
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
      
      public Perscription UpdatePerscription(Perscription perscription)
      {
         // TODO: implement
         return null;
      }
      
      public Perscription AddPerscription(Perscription perscription)
      {
         return new PerscriptionService(new PerscriptionRepository()).AddPerscription(perscription);
      }
      
      public Perscription DeactivatePerscription(Perscription perscription)
      {
         // TODO: implement
         return null;
      }

      public PerscriptionService perscriptionService = new PerscriptionService(new PerscriptionRepository());

   }
}