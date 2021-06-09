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
        
        private void setConnection()
        {
            String conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            Globals.globalConnection = new OracleConnection(conString);
            try
            {
                Globals.globalConnection.Open();
            }
            catch (Exception exp)
            {
                Trace.WriteLine(exp.ToString());
            }
        }
        public InventoryItem GetInventoryItemById(int id)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM inventory_item WHERE id = " + id.ToString();
            InventoryItem item = new InventoryItem();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();

            item.Id = reader.GetInt32(0);
            item.Name = reader.GetString(1);
            item.Price = Convert.ToUInt32(reader.GetInt32(2));
            item.Unit = reader.GetString(3);
            item.Type = (ItemType)reader.GetInt32(4);

            
            

            return item;
        }

        public System.Collections.ArrayList GetAllInventoryItems()
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<InventoryItem> GetAllInvenotryItemsByItemTypeId(int itemTypeId)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "select * from inventory_item where item_type = " + itemTypeId;
            ObservableCollection<InventoryItem> items = new ObservableCollection<InventoryItem>();
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                InventoryItem item = new InventoryItem();
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

        public InventoryItem UpdateInventoryItem(InventoryItem inventoryItem)
        {
            // TODO: implement
            return null;
        }

        public InventoryItem NewInventoryItem(InventoryItem inventoryItem)
        {
            
            OracleCommand cmd = Globals.globalConnection.CreateCommand();
            cmd.CommandText = "INSERT INTO inventory_item (name, price, unit, item_type) VALUES ('" +
                inventoryItem.Name                   + "', " +
                inventoryItem.Price.ToString()       + ", '" +
                inventoryItem.Unit                   + "', " +
                ((int)inventoryItem.Type).ToString() + ")";
            

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
            
            OracleCommand cmd = Globals.globalConnection.CreateCommand();
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