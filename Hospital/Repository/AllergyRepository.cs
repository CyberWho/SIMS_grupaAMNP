/***********************************************************************
 * Module:  AllergyRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.AllergyRepository
 ***********************************************************************/

using System;

namespace Hospital.Repository
{
   /// GetAllergiesByTypeId vraca konkretno sve id-eve kartona koji su alergicni na to i to cije je id TypeId
   public class AllergyRepository
   {
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
      
      public Hospital.Model.Allergy NewAllergy(Hospital.Model.Allergy allergy)
      {
         // TODO: implement
         return null;
      }
      
      public int GetLastId()
      {
         // TODO: implement
         return 0;
      }
      
      public Hospital.Model.Allergy GetAllergyById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Allergy> GetAllAllergies()
      {
         // TODO: implement
         return null;
      }
   
   }
}