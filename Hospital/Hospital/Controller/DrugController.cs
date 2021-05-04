/***********************************************************************
 * Module:  DrugController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.DrugController
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
    public class DrugController
    {
        public Drug GetDrugById(int id)
        {
            return drugService.GetDrugById(id);
        }

        public ObservableCollection<Drug> GetAllDrugs()
        {
            return drugService.GetAllDrugs();
        }

        public ObservableCollection<Drug> GetAllDrugsByDrugTypeId(int drugTypeId)
        {
            return drugService.GetAllDrugsByDrugTypeId(drugTypeId);
        }

        public ObservableCollection<Drug> GetAllDrugsPending()
        {
            return drugService.GetAllDrugsPending();
        }

        public Boolean DeleteDrugById(int id)
        {
            return drugService.DeleteDrugById(id);
        }

        public Drug UpdateDrug(Drug drug)
        {
            return drugService.UpdateDrug(drug);
        }
        public Drug UpdateDrugNoInventoryPart(Drug drug)
        {
            return drugService.UpdateDrugNoInventoryPart(drug);
        }
        public Drug AddDrug(Drug drug)
        {
            return drugService.AddDrug(drug);
        }

        public Drug ApproveDrug(Drug drug)
        {
            return drugService.ApproveDrug(drug);
        }

        public Drug RejectDrug(Drug drug)
        {
            return drugService.RejectDrug(drug);
        }

        public void RejectDrug(int id_drug, int id_doctor, String description)
        {
            drugService.RejectDrug(id_drug, id_doctor, description);
        }

        public DrugService drugService = new DrugService();

    }
}