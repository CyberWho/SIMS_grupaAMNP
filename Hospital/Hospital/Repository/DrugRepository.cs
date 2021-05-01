/***********************************************************************
 * Module:  DrugRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.DrugRepository
 ***********************************************************************/

using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.ObjectModel;

namespace Hospital.Repository
{
    public class DrugRepository
    {

        OracleConnection connection = null;
        private void setConnection()
        {
            String conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            connection = new OracleConnection(conString);
            try
            {
                connection.Open();

            }
            catch (Exception exp)
            {

            }
        }
        public Hospital.Model.Drug GetDrugById(int id)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Drug> GetAllDrugs()
        {
            ObservableCollection<Drug> drugs = new ObservableCollection<Drug>();
            setConnection();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select * from drug, inventory_item where drug.INVNTORY_ITEM_ID = inventory_item.ID";
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Drug drug = new Drug();
                drug.Id = reader.GetInt16(0);
                drug.Grams = reader.GetInt16(2);
                drug.Name = reader.GetString(7);
                //TO DO OSTALO
                drugs.Add(drug);
            }
            return drugs;
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

        public Hospital.Model.Drug NewDrug(Hospital.Model.Drug drug)
        {
            // TODO: implement
            return null;
        }

        public int GetLastId()
        {
            // TODO: implement
            return 0;
        }

    }
}