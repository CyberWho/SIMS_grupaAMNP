/***********************************************************************
 * Module:  DrugType.cs
 * Author:  Dell
 * Purpose: Definition of the Class Bolnica.Model.Patient.DrugType
 ***********************************************************************/

using System;

namespace Hospital.Model
{
   public class DrugType
   {
      public int Id;
      public String Type;
      
      public System.Collections.ArrayList drug;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetDrug()
      {
         if (drug == null)
            drug = new System.Collections.ArrayList();
         return drug;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetDrug(System.Collections.ArrayList newDrug)
      {
         RemoveAllDrug();
         foreach (Drug oDrug in newDrug)
            AddDrug(oDrug);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddDrug(Drug newDrug)
      {
         if (newDrug == null)
            return;
         if (this.drug == null)
            this.drug = new System.Collections.ArrayList();
         if (!this.drug.Contains(newDrug))
         {
            this.drug.Add(newDrug);
            newDrug.SetDrugType(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveDrug(Drug oldDrug)
      {
         if (oldDrug == null)
            return;
         if (this.drug != null)
            if (this.drug.Contains(oldDrug))
            {
               this.drug.Remove(oldDrug);
               oldDrug.SetDrugType((DrugType)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllDrug()
      {
         if (drug != null)
         {
            System.Collections.ArrayList tmpDrug = new System.Collections.ArrayList();
            foreach (Drug oldDrug in drug)
               tmpDrug.Add(oldDrug);
            drug.Clear();
            foreach (Drug oldDrug in tmpDrug)
               oldDrug.SetDrugType((DrugType)null);
            tmpDrug.Clear();
         }
      }
   
   }
}