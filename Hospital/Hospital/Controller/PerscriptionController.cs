/***********************************************************************
 * Module:  PerscriptionController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.PerscriptionController
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Controller
{
   public class PerscriptionController
   {
      public Hospital.Model.Perscription GetPerscriptionById(int id)
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
      
      public Hospital.Model.Perscription UpdatePerscription(Hospital.Model.Perscription perscription)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Perscription AddPerscription(Hospital.Model.Perscription perscription)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Perscription DeactivatePerscription(Hospital.Model.Perscription perscription)
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Service.PerscriptionService perscriptionService;
   
   }
}