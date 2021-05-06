/***********************************************************************
 * Module:  DrugRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.DrugRepository
 ***********************************************************************/

using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Hospital.Repository
{
    public class DrugRepository
    {

        OracleConnection connection = null;
        const string SelectAllCommandText = "SELECT * FROM drug, inventory_item WHERE drug.INVENTORY_ITEM_ID = inventory_item.ID";
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
                Trace.Write(exp.ToString());
            }
        }
        public Drug GetDrugById(int id)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = SelectAllCommandText + "and id = " + id.ToString();
            OracleDataReader reader = command.ExecuteReader();
            
            reader.Read();
            Drug newDrug = ParseFromReader(reader);

            connection.Close();
            return newDrug;
        }

        public ObservableCollection<Drug> GetAllDrugs()
        {
            ObservableCollection<Drug> drugs = new ObservableCollection<Drug>();
            setConnection();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = SelectAllCommandText;
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                drugs.Add(ParseFromReader(reader));
            }
            return drugs;
        }

        public ObservableCollection<Drug> GetAllDrugsByDrugTypeId(int drugTypeId)
        {
            setConnection();
            ObservableCollection<Drug> drugs = new ObservableCollection<Drug>();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = SelectAllCommandText + "and drug_type_id = " + drugTypeId;
            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                drugs.Add(ParseFromReader(reader));
            }

            return drugs;
        }

        public ObservableCollection<Drug> GetAllDrugsPending()
        {
            setConnection();
            ObservableCollection<Drug> pendingDrugs = new ObservableCollection<Drug>();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = SelectAllCommandText + "and drug_status = 2";
            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                pendingDrugs.Add(ParseFromReader(reader));
            }

            return pendingDrugs;
        }

        public Boolean DeleteDrugById(int id)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM drug WHERE id = " + id.ToString();

            try{
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception exp)
            {
                Trace.WriteLine(exp.ToString());
                return false;
            }
        }

        public Drug UpdateDrug(Drug drug)
        {
            int needsPerscription = drug.NeedsPerscription ? 1 : 0;
            setConnection();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText =
                "UPDATE drug "               +  
                "SET grams = "               + drug.Grams.ToString()         + ", " +
                "needs_perscription = "      + needsPerscription.ToString()  + ", " +
                "drug_status = '"            + ((int)drug.Status).ToString() + "', " +
                "drug_type_id = "            + drug.DrugType.Id.ToString()   + " " +
                "WHERE inventory_item_id = " + drug.Id.ToString();
            
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                Trace.WriteLine(exp.ToString());
                connection.Close();
                return null;
            }

            cmd.CommandText =
                "UPDATE inventory_item " +
                "SET name = '"           + drug.Name                     + "', " +
                "price = "               + drug.Price.ToString()         + ", "  +
                "unit = '"               + drug.Unit.ToString()          + "', " +
                "item_type = "           + ((int)drug.Type).ToString()   + " "   +
                "WHERE id = "            + drug.Id.ToString();

            try
            {
                cmd.ExecuteNonQuery();
                connection.Close();
                return drug;
            }
            catch (Exception exp)
            {
                Trace.WriteLine(exp.ToString());
                connection.Close();
                return null;
            }

        }

        public Drug NewDrug(Drug drug)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();

            InventoryItem inventoryItem = inventoryItemRepository.NewInventoryItem(new InventoryItem(-1, drug.Name, drug.Price, drug.Unit, drug.Type));

            string needsPrescription = drug.NeedsPerscription ? "1" : "0";

            command.CommandText = "INSERT INTO drug (inventory_item_id, grams, needs_perscription, drug_status, drug_type_id) VALUES (" +
                inventoryItem.Id.ToString()   + ", " +
                drug.Grams.ToString()         + ", " +
                needsPrescription             + ", " +
                ((int)drug.Status).ToString() + ", " +
                drug.DrugType.Id              + ")";
            
    

            try
            {
                command.ExecuteNonQuery();
                return drug;
            }
            catch (Exception exp)
            {
                Trace.WriteLine(exp.ToString());
                return null;
            }
            
        }

        public int GetLastId()
        {
            setConnection();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT MAX(id) FROM drug";

            OracleDataReader reader = cmd.ExecuteReader();

            try
            {
                reader.Read();
                return reader.GetInt32(0);
            }
            catch (Exception exp)
            {
                Trace.WriteLine(exp.ToString());
                return -1;
            }
        }

        public Drug ParseFromReader(OracleDataReader reader)
        {
            Drug drug = new Drug();
            drug.Id = reader.GetInt16(0);
            drug.Name = reader.GetString(7);
            drug.Price = (uint)reader.GetInt32(8);
            drug.Unit = reader.GetString(9);
            drug.Type = (ItemType)reader.GetInt32(10);
            drug.Grams = reader.GetInt32(2);
            drug.NeedsPerscription = reader.GetInt32(3) == 1 ? true : false;
            drug.Status = (DrugStatus)reader.GetInt32(4);
            drug.DrugType = drugTypeRepository.GetDrugTypeById(reader.GetInt32(5));
            
            return drug;
        }

        InventoryItemRepository inventoryItemRepository = new InventoryItemRepository();
        DrugTypeRepository drugTypeRepository = new DrugTypeRepository();
    }
}