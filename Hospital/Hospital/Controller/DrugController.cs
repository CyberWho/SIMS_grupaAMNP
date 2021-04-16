/***********************************************************************
 * Module:  DrugController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.DrugController
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Controller
{
   public class DrugController
   {
      public Hospital.Model.Drug GetDrugById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<Drug> GetAllDrugs()
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<Drug> GetAllDrugsByDrugTypeId(int drugTypeId)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<Drug> GetAllDrugsPending()
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
      
      public Hospital.Model.Drug AddDrug(Hospital.Model.Drug drug)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Drug ApproveDrug(Hospital.Model.Drug drug)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Drug RejectDrug(Hospital.Model.Drug drug)
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Service.DrugService drugService;
   
   }
}