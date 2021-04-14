/***********************************************************************
 * Module:  Drug.cs
 * Author:  Dell
 * Purpose: Definition of the Class Bolnica.Model.Patient.Drug
 ***********************************************************************/

using System;

namespace Hospital.Model
{
   public class Drug : InventoryItem
   {
     
   
      public int Grams { get; set; }
      public DrugStatus Status { get; set; }
      public Boolean NeedsPerscription { get; set; }
      
      public DrugType drugType;
      
      /// <pdGenerated>default parent getter</pdGenerated>
      public DrugType GetDrugType()
      {
         return drugType;
      }
      
      /// <pdGenerated>default parent setter</pdGenerated>
      /// <param>newDrugType</param>
      public void SetDrugType(DrugType newDrugType)
      {
         if (this.drugType != newDrugType)
         {
            if (this.drugType != null)
            {
               DrugType oldDrugType = this.drugType;
               this.drugType = null;
               oldDrugType.RemoveDrug(this);
            }
            if (newDrugType != null)
            {
               this.drugType = newDrugType;
               this.drugType.AddDrug(this);
            }
         }
      }
   
   }
}