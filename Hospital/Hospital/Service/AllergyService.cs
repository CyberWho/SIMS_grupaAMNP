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
      
      public System.Collections.ArrayList GetAllergiesByTypeId(int allergyTypeId)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllAllergiesByHealthRecordId(int healthRecordId)
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
      
      public Hospital.Model.Allergy UpdateAllergy(Hospital.Model.Allergy allergy)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllAllergies()
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Repository.AllergyRepository allergyRepository;
   
   }
}