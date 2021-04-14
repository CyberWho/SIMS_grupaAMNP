/***********************************************************************
 * Module:  DrugRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.DrugRepository
 ***********************************************************************/

using System;

namespace Hospital.Repository
{
   public class DrugRepository
   {
      public Hospital.Model.Drug GetDrugById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllDrugs()
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllDrugsByDrugTypeId(int drugTypeId)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllDrugsPending()
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteDrugById(int id)
      {
         // TODO: implement
         return false;
      }
      
      public Hospital.Model.Drug UpdateDrug(Hospital.Model.Drug drug)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Drug NewDrug(Hospital.Model.Drug drug)
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