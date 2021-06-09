/***********************************************************************
 * Module:  DrugTypeRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.DrugTypeRepository
 ***********************************************************************/

using Hospital.Model;
using System;
using System.Collections.ObjectModel;
//using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;
using System.Diagnostics;


namespace Hospital.Repository
{
    public class DrugTypeRepository
    {
        public DrugType GetDrugTypeById(int id)
        {
            
            OracleCommand cmd = Globals.globalConnection.CreateCommand();
            cmd.CommandText = "SELECT * FROM drug_type WHERE id = " + id.ToString();
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();

            DrugType newDrugType = new DrugType();
            newDrugType.Id = reader.GetInt32(0);
            newDrugType.Type = reader.GetString(1);
            return newDrugType;
        }

        public DrugType GetDrugTypeByType(string type)
        {
            
            OracleCommand cmd = Globals.globalConnection.CreateCommand();
            cmd.CommandText = "SELECT * FROM drug_type WHERE type = '" + type + "'";
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();

            DrugType newDrugType = new DrugType();
            newDrugType.Id = reader.GetInt32(0);
            newDrugType.Type = reader.GetString(1);

            return newDrugType;
        }

        public ObservableCollection<DrugType> GetAllDrugTypes()
        {

            ObservableCollection<DrugType> drugTypes = new ObservableCollection<DrugType>();

            
            OracleCommand cmd = Globals.globalConnection.CreateCommand();
            cmd.CommandText = "SELECT * FROM drug_type";
            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DrugType newDrugType = new DrugType();
                newDrugType.Id = reader.GetInt32(0);
                newDrugType.Type = reader.GetString(1);
                drugTypes.Add(newDrugType);
            }

            return drugTypes;
        }

        public Boolean DeleteDrugTypeById(int id)
        {
            // TODO: implement
            return false;
        }

        public DrugType UpdateDrugType(DrugType drugType)
        {
            // TODO: implement
            return null;
        }

        public DrugType NewDrugType(DrugType drugType)
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