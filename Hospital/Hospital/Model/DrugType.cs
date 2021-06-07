/***********************************************************************
 * Module:  DrugType.cs
 * Author:  Dell
 * Purpose: Definition of the Class Bolnica.Model.Patient.DrugType
 ***********************************************************************/

using System;
using System.Collections;

namespace Hospital.Model
{
    public class DrugType
    {
        public int Id { get; set; }
        public String Type { get; set; }

        public ArrayList drug;

        /// <pdGenerated>default getter</pdGenerated>
        public ArrayList GetDrug()
        {
            if (drug == null)
                drug = new ArrayList();
            return drug;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetDrug(ArrayList newDrug)
        {
            RemoveAllDrug();
            foreach (Drug oDrug in newDrug)
                AddDrug(oDrug);
        }

        /// <pdGenerated>default New</pdGenerated>
        public void AddDrug(Drug newDrug)
        {
            if (newDrug == null)
                return;
            if (this.drug == null)
                this.drug = new ArrayList();
            if (!this.drug.Contains(newDrug))
            {
                this.drug.Add(newDrug);
                newDrug.drugType = this;
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
                    oldDrug.drugType = ((DrugType)null);
                }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllDrug()
        {
            if (drug != null)
            {
                ArrayList tmpDrug = new ArrayList();
                foreach (Drug oldDrug in drug)
                    tmpDrug.Add(oldDrug);
                drug.Clear();
                foreach (Drug oldDrug in tmpDrug)
                    oldDrug.drugType = ((DrugType)null);
                tmpDrug.Clear();
            }
        }

        public DrugType(int id, string type, ArrayList drug)
        {
            Id = id;
            Type = type;
            this.drug = drug;
        }

        public DrugType()
        {
        }
    }
}