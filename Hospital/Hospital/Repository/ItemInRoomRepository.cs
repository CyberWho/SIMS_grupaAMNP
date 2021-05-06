/***********************************************************************
 * Module:  ItemInRoomRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.ItemInRoomRepository
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Hospital.Model;
using Oracle.ManagedDataAccess.Client;

namespace Hospital.Repository
{
   public class ItemInRoomRepository
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
                Trace.WriteLine(exp.ToString());
            }
        }
        public ItemInRoom GetItemInRoomById(int id)
        {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM item_in_room WHERE id = " + id.ToString();
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            ItemInRoom newItemInRoom = ParseFromReader(reader);

            con.Close();
            return newItemInRoom;
        }

        public ObservableCollection<ItemInRoom> GetAllItemsInRoomByRoomId(int id)
        {
            setConnection();
            ObservableCollection<ItemInRoom> itemsInRoom = new ObservableCollection<ItemInRoom>();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT* FROM ITEM_IN_ROOM LEFT OUTER JOIN INVENTORY_ITEM ON inventory_item.ID = ITEM_IN_ROOM.inventory_item_ID WHERE room_ID = " + id.ToString();
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ItemInRoom newItemInRoom = ParseFromReader(reader);
                itemsInRoom.Add(newItemInRoom);
            }

            con.Close();
            return itemsInRoom;
        }

        public ObservableCollection<ItemInRoom> GetAllItemsInRoom()
        {
            setConnection();
            ObservableCollection<ItemInRoom> itemsInRoom = new ObservableCollection<ItemInRoom>();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM ITEM_IN_ROOM LEFT OUTER JOIN INVENTORY_ITEM ON inventory_item.ID = ITEM_IN_ROOM.inventory_item_ID";
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                InventoryItem newItem = inventoryItemRepository.GetInventoryItemById(reader.GetInt32(1));
                ItemInRoom newItemInRoom = new ItemInRoom(reader.GetInt32(0), Convert.ToUInt32(reader.GetInt32(2)), null, newItem);
                itemsInRoom.Add(newItemInRoom);
            }

            con.Close();
            return itemsInRoom;
        }

        public bool DeleteItemInRoomById(int id)
        {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM item_in_room WHERE id = " + id.ToString();

            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
                Trace.WriteLine("DeleteItemInRoomById");
                return true;
            }
            catch (Exception exp)
            {
                Trace.WriteLine(exp.ToString());
                con.Close();
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
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText =
                "UPDATE item_in_room "     +
                "SET inventory_item_id = " + itemInRoom.inventoryItem.Id.ToString() + ", " +
                "quantity = "              + itemInRoom.Quantity.ToString()         + ", " +
                "room_id = "               + itemInRoom.room.Id.ToString()          + " "  +
                "WHERE id = "              + itemInRoom.Id.ToString();


            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
                Trace.WriteLine("Prosao UpdateItemInRoom");
                return itemInRoom;  
            }
            catch (Exception e)
            {
                con.Close();
                return null;
            }

        }

        public ItemInRoom NewItemInRoom(ItemInRoom itemInRoom)
        {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO item_in_room (inventory_item_id, quantity, room_id) VALUES (" +
                itemInRoom.inventoryItem.Id.ToString() + ", " +
                itemInRoom.Quantity.ToString()         + ", " +
                itemInRoom.room.Id.ToString()          + ")";
            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
                return itemInRoom;
            }
            catch (Exception exp)
            {
                Trace.WriteLine(exp.ToString());
                con.Close();
                return null;
            }

        }

        public ObservableCollection<ItemInRoom> SearchByName(string name)
        {
            setConnection();
            ObservableCollection<ItemInRoom> searchResults = new ObservableCollection<ItemInRoom>();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM ITEM_IN_ROOM LEFT OUTER JOIN INVENTORY_ITEM ON inventory_item.ID = ITEM_IN_ROOM.inventory_item_ID WHERE name like '%" + name + "%'";
            OracleDataReader reader = cmd.ExecuteReader();

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
            InventoryItem newItem = inventoryItemRepository.GetInventoryItemById(reader.GetInt32(1));
            Room newRoom = roomRepository.GetRoomById(reader.GetInt32(3));
            ItemInRoom newItemInRoom = new ItemInRoom(reader.GetInt32(0), Convert.ToUInt32(reader.GetInt32(2)), newRoom, newItem);
            return newItemInRoom;
        }

        public InventoryItemRepository inventoryItemRepository = new InventoryItemRepository();
        public RoomRepository roomRepository = new RoomRepository();   

   }
}