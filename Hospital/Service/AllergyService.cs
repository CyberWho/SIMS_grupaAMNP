/***********************************************************************
 * Module:  AllergyService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.AllergyService
 ***********************************************************************/

using System;

namespace Hospital.Service
{
   public class AllergyService
   {
      public Hospital.Model.Allergy AddAllergy(Hospital.Model.Allergy allergy)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<int> GetAllergiesByTypeId(int allergyTypeId)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Allergy> GetAllAllergiesByHealthRecordId(int healthRecordId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteAllergyById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteAllergiesByHealthRecordId(int healthRecordId)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Allergy UpdateAllergy(Hospital.Model.Allergy allergy)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Allergy> GetAllAllergies()
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Repository.AllergyRepository allergyRepository;
   
   }
}