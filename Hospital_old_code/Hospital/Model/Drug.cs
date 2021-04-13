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

        public DrugType DrugType;

        public DrugType GetDrugType()
        {
            return DrugType;
        }

        public void SetDrugType(DrugType newDrugType)
        {
            if (this.DrugType != newDrugType)
            {
                if (this.DrugType != null)
                {
                    DrugType oldDrugType = this.DrugType;
                    this.DrugType = null;
                    oldDrugType.RemoveDrug(this);
                }
                if (newDrugType != null)
                {
                    this.DrugType = newDrugType;
                    this.DrugType.AddDrug(this);
                }
            }
        }

    }
}