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
        public int drugType_id { get; set; }

        /// <pdGenerated>default parent getter</pdGenerated>
        public DrugType GetDrugType()
        {
            return DrugType;
        }

        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newDrugType</param>
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
        public Drug(int grams, DrugStatus status, bool needsPerscription, DrugType drugType)
        {
            Grams = grams;
            Status = status;
            NeedsPerscription = needsPerscription;
            this.DrugType = drugType;
        }

        public Drug()
        {
        }
    }
}