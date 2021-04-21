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
        public Hospital.Model.Drug GetDrugById(int id)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Drug> GetAllDrugs()
        {
            return new DrugRepository().GetAllDrugs();
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

        public Hospital.Repository.DrugRepository drugRepository;

    }
}