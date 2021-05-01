/***********************************************************************
 * Module:  InventoryItemRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.InventoryItemRepository
 ***********************************************************************/

using Oracle.ManagedDataAccess.Client;
using System;

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

            }
        }
        public Hospital.Model.InventoryItem GetInventoryItemById(int id)
      {
            setConnection();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM inventory_item WHERE id = " + id.ToString();
            Model.InventoryItem item = new Model.InventoryItem();
            OracleDataReader reader = cmd.ExecuteReader();
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
      
      public System.Collections.ArrayList GetAllInvenotryItemsByItemTypeId(int itemTypeId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteInventoryItemById(int id)
      {
         // TODO: implement
         return false;
      }
      
      public Hospital.Model.InventoryItem UpdateInventoryItem(Hospital.Model.InventoryItem inventoryItem)
      {
         // TODO: implement
         return null;
      }
      
      public InventoryItemRepository NewInventoryItem(Hospital.Model.InventoryItem inventoryItem)
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