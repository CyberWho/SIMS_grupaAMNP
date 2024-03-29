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
using static Globals;
using System.Linq;

namespace Hospital.Repository
{
    public class DrugRepository
    {

        
        const string SelectAllCommandText = "SELECT * FROM drug, inventory_item WHERE drug.INVENTORY_ITEM_ID = inventory_item.ID";
        
        public Drug GetDrugById(int id)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM DRUG,INVENTORY_ITEM WHERE DRUG.ID = :id AND DRUG.INVENTORY_ITEM_ID = INVENTORY_ITEM.ID";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = command.ExecuteReader();

            reader.Read();
            Drug newDrug = ParseFromReader(reader);

            return newDrug;
        }

        public ObservableCollection<Drug> GetAllDrugs()
        {
            ObservableCollection<Drug> drugs = new ObservableCollection<Drug>();
            
            OracleCommand cmd = Globals.globalConnection.CreateCommand();
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
            
            ObservableCollection<Drug> drugs = new ObservableCollection<Drug>();
            OracleCommand cmd = Globals.globalConnection.CreateCommand();
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
            
            ObservableCollection<Drug> pendingDrugs = new ObservableCollection<Drug>();
            OracleCommand cmd = Globals.globalConnection.CreateCommand();
            cmd.CommandText = SelectAllCommandText + "and drug_status = 2";
            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                pendingDrugs.Add(ParseFromReader(reader));
            }

            return pendingDrugs;
        }
        public DrugDTO GetRejectionInfo(DrugDTO newDrugDTO)
        {
            
            OracleCommand query = Globals.globalConnection.CreateCommand();
            query.CommandText = "SELECT * FROM drug_rejection WHERE drug_id = " + newDrugDTO.Id;
            OracleDataReader reader;
            try
            {
                reader = query.ExecuteReader();
            }
            catch (Exception exp)
            {
                ThrowException(exp);
                
                return null;
            }
            reader.Read();
            int doctorID = reader.GetInt32(2);
            Doctor rejectionDoctor = doctorRepository.GetById(doctorID);
            string RejectionInfo = "(dr " + rejectionDoctor.User.Surname + ")\n";
            RejectionInfo += reader.GetString(3);

            newDrugDTO.RejectionInfo = RejectionInfo;

            return newDrugDTO;
        }

        public bool DeleteDrugById(int id, int invID)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "DELETE FROM drug WHERE id = " + id.ToString();

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                Trace.WriteLine(exp.ToString());
            }

            command.CommandText = "DELETE FROM inventory_item WHERE id = " + invID.ToString();

            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                Trace.WriteLine(exp.ToString());
                return false;
            }
        }
        public Drug UpdateDrugNoInventoryPart(Drug drug)
        {
            int needsPerscription = drug.NeedsPerscription ? 1 : 0;
            
            OracleCommand cmd = Globals.globalConnection.CreateCommand();
            cmd.CommandText =
                "UPDATE drug " +
                "SET grams = " + drug.Grams.ToString() + ", " +
                "needs_perscription = " + needsPerscription.ToString() + ", " +
                "drug_status = '" + ((int)drug.Status).ToString() + "', " +
                "drug_type_id = " + drug.drugType.Id.ToString() + " " +
                "WHERE id = " + drug.Id.ToString();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                Trace.WriteLine(exp.ToString());
                
                return null;
            }

            return drug;
        }
        public Drug UpdateDrug(Drug drug)
        {
            int needsPerscription = drug.NeedsPerscription ? 1 : 0;
            
            OracleCommand cmd = Globals.globalConnection.CreateCommand();
            cmd.CommandText =
                "UPDATE drug " +
                "SET grams = " + drug.Grams.ToString() + ", " +
                "needs_perscription = " + needsPerscription.ToString() + ", " +
                "drug_status = '" + ((int)drug.Status).ToString() + "', " +
                "drug_type_id = " + drug.drugType.Id.ToString() + " " +
                "WHERE id = " + drug.Id.ToString();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                Trace.WriteLine(exp.ToString());
                
                return null;
            }

            cmd.CommandText =
                "UPDATE inventory_item " +
                "SET name = '" + drug.Name + "', " +
                "price = " + drug.Price.ToString() + ", " +
                "unit = '" + drug.Unit.ToString() + "', " +
                "item_type = " + ((int)drug.Type).ToString() + " " +
                "WHERE id = " + drug.InventoryItemID.ToString();

            try
            {
                cmd.ExecuteNonQuery();
                
                return drug;
            }
            catch (Exception exp)
            {
                Trace.WriteLine(exp.ToString());
                
                return null;
            }
        }

        public Drug NewDrug(Drug drug)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();

            InventoryItem inventoryItem = inventoryItemRepository.NewInventoryItem(new InventoryItem(-1, drug.Name, drug.Price, drug.Unit, drug.Type));

            command.CommandText = "INSERT INTO drug (inventory_item_id, grams, needs_perscription, drug_status, drug_type_id) VALUES (:inventory_item_id, :grams, :needs_perscription, :drug_status, :drug_type_id)";
            command.Parameters.Add("inventory_item_id", OracleDbType.Int32).Value = inventoryItem.Id;
            command.Parameters.Add("grams", OracleDbType.Int32).Value = drug.Grams;
            command.Parameters.Add("needs_perscription", OracleDbType.Int32).Value = drug.NeedsPerscription ? 1 : 0;
            command.Parameters.Add("drug_status", OracleDbType.Int32).Value = drug.Status;
            command.Parameters.Add("drug_type_id", OracleDbType.Int32).Value = drug.drugType.Id;

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
            
            OracleCommand cmd = Globals.globalConnection.CreateCommand();
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
            drug.InventoryItemID = reader.GetInt32(1);
            drug.Grams = reader.GetInt32(2);
            drug.NeedsPerscription = reader.GetInt32(3) == 1 ? true : false;
            drug.Status = (DrugStatus)reader.GetInt32(4);
            drug.drugType = drugTypeRepository.GetDrugTypeById(reader.GetInt32(5));
            drug.Name = reader.GetString(7);
            drug.Price = (uint)reader.GetInt32(8);
            drug.Unit = reader.GetString(9);
            drug.Type = (ItemType)reader.GetInt32(10);

            return drug;
        }

        public void RejectDrug(int id_drug, int id_doctor, String description)
        {
            
            OracleCommand cmd = Globals.globalConnection.CreateCommand();
            cmd.CommandText = "insert into drug_rejection (drug_id, doctor_id, description) values (" + id_drug + "," +
                              id_doctor + ",'" + description + "')";
            cmd.ExecuteNonQuery();
            
            
        }

        public ObservableCollection<int> getDrugAllergy(int health_record_id)
        {
            
            ObservableCollection<int> ids = new ObservableCollection<int>();
            OracleCommand cmd = Globals.globalConnection.CreateCommand();
            cmd.CommandText =
                "SELECT drug.ID FROM allergy, allergy_type, drug_allergies, drug where allergy.allergy_type_id = allergy_type.id and " + 
                "drug_allergies.ALLERGY_TYPE_ID = allergy_type.ID  and drug.DRUG_TYPE_ID = drug_allergies.ALLERGY_TYPE_ID and health_record_id = " +
                health_record_id;
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int i = reader.GetInt32(0);
                ids.Add(i);
            }
            
            
            return ids;
        }

        InventoryItemRepository inventoryItemRepository = new InventoryItemRepository();
        DrugTypeRepository drugTypeRepository = new DrugTypeRepository();
        DoctorRepository doctorRepository = new DoctorRepository();
    }
}