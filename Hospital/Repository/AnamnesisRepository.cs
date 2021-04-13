/***********************************************************************
 * Module:  AnamnesisRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.AnamnesisRepository
 ***********************************************************************/

using System;

namespace Hospital.Repository
{
   public class AnamnesisRepository
   {
      public Hospital.Model.Anamnesis GetAnamnesisById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Anamnesis> GetAllAnamnesesByHealthRecordId(int healthRecordId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteAnamnesisById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteAnamnesisByHealthRecordId(int healthRecordId)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Anamnesis UpdateAnamnesis(Hospital.Model.Anamnesis anamnesis)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Anamnesis NewAnamnesis(Hospital.Model.Anamnesis anamnesis)
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