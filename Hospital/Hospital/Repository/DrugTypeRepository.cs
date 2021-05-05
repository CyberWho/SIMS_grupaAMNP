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


namespace Hospital.Repository
{
   public class DrugTypeRepository
   {
        OracleConnection con = null;
        private void setConnection()
        {
            String conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            con = new OracleConnection(conString);
            try
            {
                con.Open();

            }
            catch (Exception exp)
            {

            }
        }
        public DrugType GetDrugTypeById(int id)
        {
            //setConnection();
            String conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            con = new OracleConnection(conString);
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM drug_type WHERE id = " + id.ToString();
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();

            DrugType newDrugType = new DrugType();
            newDrugType.Id = reader.GetInt32(0);
            newDrugType.Type = reader.GetString(1);

            con.Close();
            return newDrugType;
        }

        public ObservableCollection<DrugType> GetAllDrugTypes()
        {

            ObservableCollection<DrugType> drugTypes = new ObservableCollection<DrugType>();

            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM drug_type";
            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DrugType newDrugType = new DrugType();
                newDrugType.Id = reader.GetInt32(0);
                newDrugType.Type = reader.GetString(1);
                drugTypes.Add(newDrugType);
            }

            con.Close();
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