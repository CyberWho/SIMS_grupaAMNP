/***********************************************************************
 * Module:  AllergyTypeService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.AllergyTypeService
 ***********************************************************************/

using System;
using Hospital.Model;


namespace Hospital.Service
{
   public class AllergyTypeService
   {
      public System.Collections.ArrayList GetAllAllergyTypes()
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
   
      public Hospital.Repository.AllergyTypeRepository allergyTypeRepository;
   
   }
}