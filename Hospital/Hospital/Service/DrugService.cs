/***********************************************************************
 * Module:  DrugService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.DrugService
 ***********************************************************************/

using Hospital.Model;
using System;
using System.Collections.ObjectModel;
using Hospital.Repository;

namespace Hospital.Service
{

    public class DrugService
    {
        public Drug GetDrugById(int id)
        {
            return drugRepository.GetDrugById(id);
        }

        public ObservableCollection<Drug> GetAllDrugs()
        {
            return new DrugRepository().GetAllDrugs();
        }

        public ObservableCollection<Drug> GetAllDrugsByDrugTypeId(int drugTypeId)
        { 
            return drugRepository.GetAllDrugsByDrugTypeId(drugTypeId);
        }

        public ObservableCollection<Drug> GetAllDrugsPending()
        {
            return drugRepository.GetAllDrugsPending();
        }

        public bool DeleteDrugById(int id, int invID)
        {
            return drugRepository.DeleteDrugById(id, invID);
        }

        public Drug UpdateDrug(Drug drug)
        { 
            return drugRepository.UpdateDrug(drug);
        }
        
        public Drug UpdateDrugNoInventoryPart(Drug drug)
        {
            return drugRepository.UpdateDrugNoInventoryPart(drug);
        }
        public Drug AddDrug(Drug drug)
        {
            return drugRepository.NewDrug(drug);
        }

        public Drug ApproveDrug(Drug drug)
        {
            // TODO
            return null;
        }

        public Drug RejectDrug(Drug drug)
        {
            // TODO: implement
            return null;
        }

        public void RejectDrug(int id_drug, int id_doctor, string description)
        {
            drugRepository.RejectDrug(id_drug, id_doctor, description);
        }

        public DrugRepository drugRepository = new DrugRepository();

    }
}