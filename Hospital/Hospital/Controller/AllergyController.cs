/***********************************************************************
 * Module:  AllergyController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.AllergyController
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Controller
{
   public class AllergyController
   {
      public Hospital.Model.Anamnesis AddAllergy(Hospital.Model.Anamnesis allergy)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<Anamnesis> GetAllergiesByTypeId(int allergyTypeId)
      {
         // TODO: implement
         return null;
      }

        public ObservableCollection<Anamnesis> GetAllAllergiesByHealthRecordId(int healthRecordId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteAllergyById(int id)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean DeleteAllergiesByHealthRecordId(int healthRecordId)
      {
         // TODO: implement
         return false;
      }
      
      public Hospital.Model.Anamnesis UpdateAllergy(Hospital.Model.Anamnesis allergy)
      {
         // TODO: implement
         return null;
      }

        public ObservableCollection<Anamnesis> GetAllAllergies()
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Service.AllergyService allergyService;
   
   }
}