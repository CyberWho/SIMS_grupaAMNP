/***********************************************************************
 * Module:  ItemInRoomRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.ItemInRoomRepository
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Hospital.Model;
using Oracle.ManagedDataAccess.Client;

namespace Hospital.Repository
{
   public class ItemInRoomRepository
   {
        
        string SelectAllCommandText = "SELECT * FROM item_in_room LEFT OUTER JOIN INVENTORY_ITEM ON inventory_item.ID = ITEM_IN_ROOM.inventory_item_ID LEFT OUTER JOIN room ON room_id = room.id LEFT OUTER JOIN room_type ON room.RTYPE_ID = room_type.ID";
        bool GotAllItemsInRoom = false;
        ObservableCollection<ItemInRoom> AllItemsInRoom = new ObservableCollection<ItemInRoom>();

        private void setConnection()
        {
            string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
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
        public ItemInRoom GetItemInRoomById(int id)
        {
            
            OracleCommand cmd = Globals.globalConnection.CreateCommand();
            cmd.CommandText = "SELECT * FROM item_in_room WHERE id = " + id.ToString();
            OracleDataReader reader;
            try
            {
                reader = cmd.ExecuteReader();
            }
            catch(Exception exp)
            {
                Trace.WriteLine("GetItemInRoomById ERROR: " + exp.ToString());
                return null;
            }
            reader.Read();
            ItemInRoom newItemInRoom = new ItemInRoom(reader.GetInt32(0), uint.Parse(reader.GetInt32(2).ToString()), null, null);
            newItemInRoom.inventoryItem_id = reader.GetInt32(1);
            newItemInRoom.room_id = reader.GetInt32(3);
            
            

            newItemInRoom.room = roomRepository.GetRoomById(newItemInRoom.room_id);
            newItemInRoom.inventoryItem = inventoryItemRepository.GetInventoryItemById(newItemInRoom.inventoryItem_id);

            return newItemInRoom;
        }

        public ObservableCollection<ItemInRoom> GetAllItemsInRoomByRoomId(int id)
        {
            
            ObservableCollection<ItemInRoom> itemsInRoom = new ObservableCollection<ItemInRoom>();
            OracleCommand cmd = Globals.globalConnection.CreateCommand();
            cmd.CommandText = SelectAllCommandText + " WHERE room_ID = " + id.ToString();
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ItemInRoom newItemInRoom = new ItemInRoom(reader.GetInt32(0), Convert.ToUInt32(reader.GetInt32(2)), null, null);
                newItemInRoom.room_id = reader.GetInt32(3);
                newItemInRoom.inventoryItem_id = reader.GetInt32(1);
                itemsInRoom.Add(newItemInRoom);

            }
            
            

            foreach (ItemInRoom itemInRoom in itemsInRoom)
            {
                itemInRoom.room = roomRepository.GetRoomById(itemInRoom.room_id);
                itemInRoom.inventoryItem = inventoryItemRepository.GetInventoryItemById(itemInRoom.inventoryItem_id);
            }


            return itemsInRoom;
        }

        public ObservableCollection<ItemInRoom> GetAllItemsInRoom()
        {
            if (!GotAllItemsInRoom)
            {
                
                OracleCommand cmd = Globals.globalConnection.CreateCommand();
                cmd.CommandText = SelectAllCommandText;
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AllItemsInRoom.Add(ParseFromReader(reader));
                }

                
                GotAllItemsInRoom = true;
            }
            return AllItemsInRoom;
        }

        public void ResetGotAllItemsInRoomFlag()
        {
            GotAllItemsInRoom = false;
        }

        public ObservableCollection<ItemInRoom> GetAllItemsInRoomByItemType(ItemType type)
        {
            
            ObservableCollection<ItemInRoom> itemsInRoom = new ObservableCollection<ItemInRoom>();
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = SelectAllCommandText + " WHERE item_type = " + ((int)type).ToString();
            OracleDataReader reader;
            try
            {
                reader = command.ExecuteReader();
            }
            catch (Exception exp)
            {
                Trace.WriteLine(exp.ToString());
                return null;
            }

            while (reader.Read())
            {
                itemsInRoom.Add(ParseFromReader(reader));
            }

            
            
            return itemsInRoom;
        }

        public bool DeleteItemInRoomById(int id)
        {
            
            OracleCommand cmd = Globals.globalConnection.CreateCommand();
            cmd.CommandText = "DELETE FROM item_in_room WHERE id = " + id.ToString();

            try
            {
                cmd.ExecuteNonQuery();
                
                
                return true;
            }
            catch (Exception exp)
            {
                Trace.WriteLine(exp.ToString());
                
                
                return false;
            }
        }

        public Boolean DeleteAllItemsInRoomByRoomId(int roomId)
        {
            // TODO: implement
            return false;
        }

        public ItemInRoom UpdateItemInRoom(ItemInRoom itemInRoom)
        {
            
            OracleCommand cmd = Globals.globalConnection.CreateCommand();
            cmd.CommandText =
                "UPDATE item_in_room "     +
                "SET inventory_item_id = " + itemInRoom.inventoryItem.Id.ToString() + ", " +
                "quantity = "              + itemInRoom.Quantity.ToString()         + ", " +
                "room_id = "               + itemInRoom.room.Id.ToString()          + " "  +
                "WHERE id = "              + itemInRoom.Id.ToString();

            Trace.WriteLine("SQL COMMAND: " + cmd.CommandText);
            try
            {
                cmd.ExecuteNonQuery();
                
                
                return itemInRoom;  
            }
            catch (Exception exp)
            {
                
                
                Trace.WriteLine("UPDATE ITEM IN ROOM ERROR: " + exp.ToString());

                return null;
            }

        }

        public ItemInRoom NewItemInRoom(ItemInRoom itemInRoom)
        {
            
            OracleCommand cmd = Globals.globalConnection.CreateCommand();
            cmd.CommandText = "INSERT INTO item_in_room (inventory_item_id, quantity, room_id) VALUES (" +
                itemInRoom.inventoryItem.Id.ToString() + ", " +
                itemInRoom.Quantity.ToString()         + ", " +
                itemInRoom.room.Id.ToString()          + ")";
            try
            {
                cmd.ExecuteNonQuery();
                
                
                

                return itemInRoom;
            }
            catch (Exception exp)
            {
                Trace.WriteLine("NewItemInRoom ERROR: \n" + exp.ToString());
                
                

                return null;
            }
        }

        public ObservableCollection<ItemInRoom> SearchByName(string name)
        {
            
            ObservableCollection<ItemInRoom> searchResults = new ObservableCollection<ItemInRoom>();
            OracleCommand cmd = Globals.globalConnection.CreateCommand();
            cmd.CommandText = SelectAllCommandText + " WHERE name like '%" + name + "%'";
            OracleDataReader reader;

            try
            {
                reader = cmd.ExecuteReader();
            }
            catch (Exception exp)
            {
                Trace.WriteLine("SEARCH BY NAME ERROR: " + exp.ToString());
                
                
                return null;
            }

            while (reader.Read())
            {
                searchResults.Add(ParseFromReader(reader));
            }
            return searchResults;
        }

        public int GetLastId()
        {
            // TODO: implement
            return 0;
        }

        public ItemInRoom ParseFromReader(OracleDataReader reader)
        {
            InventoryItem newItem = new InventoryItem(reader.GetInt32(1), reader.GetString(5), (uint)reader.GetInt32(6), reader.GetString(7), (ItemType)reader.GetInt32(8));
            Room newRoom = new Room(reader.GetInt32(3), reader.GetInt32(10), reader.GetDouble(11), reader.GetString(12), null);
            RoomType newRoomType = new RoomType(reader.GetInt32(13), reader.GetString(14), null); 
            ItemInRoom newItemInRoom = new ItemInRoom(reader.GetInt32(0), Convert.ToUInt32(reader.GetInt32(2)), newRoom, newItem);
            return newItemInRoom;
        }

        public InventoryItemRepository inventoryItemRepository = new InventoryItemRepository();
        public RoomRepository roomRepository = new RoomRepository();   

   }
}