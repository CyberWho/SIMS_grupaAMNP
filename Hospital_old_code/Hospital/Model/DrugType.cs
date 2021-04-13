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
        public String Type { get; set; }

        public System.Collections.ArrayList Drug;

        public System.Collections.ArrayList GetDrug()
        {
            if (Drug == null)
                Drug = new System.Collections.ArrayList();
            return Drug;
        }

        public void SetDrug(System.Collections.ArrayList newDrug)
        {
            RemoveAllDrug();
            foreach (Drug oDrug in newDrug)
                AddDrug(oDrug);
        }

        public void AddDrug(Drug newDrug)
        {
            if (newDrug == null)
                return;
            if (this.Drug == null)
                this.Drug = new System.Collections.ArrayList();
            if (!this.Drug.Contains(newDrug))
            {
                this.Drug.Add(newDrug);
                newDrug.SetDrugType(this);
            }
        }

        public void RemoveDrug(Drug oldDrug)
        {
            if (oldDrug == null)
                return;
            if (this.Drug != null)
                if (this.Drug.Contains(oldDrug))
                {
                    this.Drug.Remove(oldDrug);
                    oldDrug.SetDrugType((DrugType)null);
                }
        }

        public void RemoveAllDrug()
        {
            if (Drug != null)
            {
                System.Collections.ArrayList tmpDrug = new System.Collections.ArrayList();
                foreach (Drug oldDrug in Drug)
                    tmpDrug.Add(oldDrug);
                Drug.Clear();
                foreach (Drug oldDrug in tmpDrug)
                    oldDrug.SetDrugType((DrugType)null);
                tmpDrug.Clear();
            }
        }

    }
}