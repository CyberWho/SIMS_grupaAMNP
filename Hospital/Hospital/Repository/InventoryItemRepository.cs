/***********************************************************************
 * Module:  InventoryItemRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.InventoryItemRepository
 ***********************************************************************/

using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using Hospital.Model;

namespace Hospital.Repository
{
   public class InventoryItemRepository
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
                Trace.WriteLine(exp.ToString());
            }
        }
        public Model.InventoryItem GetInventoryItemById(int id)
        {
            
            //connection.Close();
            //connection.Dispose();
            /*String conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            connection = new OracleConnection(conString);
            connection.Open();*/
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM inventory_item WHERE id = " + id.ToString();
            Model.InventoryItem item = new Model.InventoryItem();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();

            item.Id = reader.GetInt32(0);
            item.Name = reader.GetString(1);
            item.Price = Convert.ToUInt32(reader.GetInt32(2));
            item.Unit = reader.GetString(3);
            item.Type = (Model.ItemType)reader.GetInt32(4);

            connection.Close();
            connection.Dispose();

            return item;
        }

        public System.Collections.ArrayList GetAllInventoryItems()
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<InventoryItem> GetAllInvenotryItemsByItemTypeId(int itemTypeId)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "select * from inventory_item where item_type = " + itemTypeId;
            ObservableCollection<Model.InventoryItem> items = new ObservableCollection<InventoryItem>();
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Model.InventoryItem item = new InventoryItem();
                item.Id = reader.GetInt32(0);
                item.Name = reader.GetString(1);
                item.Price = uint.Parse(reader.GetString(2));
                item.Unit = reader.GetString(3);
                item.Type = reader.GetInt32(4) == 0 ? ItemType.EXPENDABLE : ItemType.PERSISTENT;
                items.Add(item);
            }
            return items;
        }

        public Boolean DeleteInventoryItemById(int id)
        {
            // TODO: implement
            return false;
        }

        public Model.InventoryItem UpdateInventoryItem(Model.InventoryItem inventoryItem)
        {
            // TODO: implement
            return null;
        }

        public Model.InventoryItem NewInventoryItem(Model.InventoryItem inventoryItem)
        {
            setConnection();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO inventory_item VALUES (:name, :price, :unit, :item_type)";
            cmd.Parameters.Add("name",      OracleDbType.Varchar2).Value = inventoryItem.Name;
            cmd.Parameters.Add("price",     OracleDbType.Int32).Value    = inventoryItem.Price;
            cmd.Parameters.Add("unit",      OracleDbType.Varchar2).Value = inventoryItem.Unit;
            cmd.Parameters.Add("item_type", OracleDbType.Int32).Value    = inventoryItem.Type;

            try
            {
                cmd.ExecuteNonQuery();
                inventoryItem.Id = GetLastId();
                return inventoryItem;
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
            cmd.CommandText = "SELECT max(id) FROM inventory_item";
            OracleDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();
                reader.Read();
                return reader.GetInt32(0);
            }
            catch (Exception exp)
            {
                Trace.WriteLine(exp.ToString());
                return -1;
            }
        }
   
   }
}