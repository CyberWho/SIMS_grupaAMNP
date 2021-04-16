/***********************************************************************
 * Module:  AllergyTypeController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.AllergyTypeController
 ***********************************************************************/

using System;
using Hospital.Model;
using System.Collections.ObjectModel;

namespace Hospital.Controller
{
   public class AllergyTypeController
   {
      public ObservableCollection<AllergyType> GetAllAllergyTypes()
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteAllergieTypeById(int id)
      {
         // TODO: implement
         return false;
      }
      
      public Hospital.Model.AllergyType UpdateAllergyType(int allergyType)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.AllergyType AddAllergyType(Hospital.Model.AllergyType allergyType)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.AllergyType GetAllergyTypeById(int id)
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Service.AllergyTypeService allergyTypeService;
   
   }
}