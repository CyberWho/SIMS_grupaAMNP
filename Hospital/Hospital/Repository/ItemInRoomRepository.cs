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
        public ItemInRoom GetItemInRoomById(int id)
        {
            setConnection();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM item_in_room WHERE id = " + id.ToString();
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            ItemInRoom newItemInRoom = new ItemInRoom(reader.GetInt32(0), Convert.ToUInt32(reader.GetInt32(2)), null, null);
            newItemInRoom.room_id = reader.GetInt32(3);
            newItemInRoom.inventoryItem_id = reader.GetInt32(1);
            con.Close();
            con.Dispose();

            newItemInRoom.room = roomRepository.GetRoomById(newItemInRoom.room_id);
            newItemInRoom.inventoryItem = inventoryItemRepository.GetInventoryItemById(newItemInRoom.inventoryItem_id);

            return newItemInRoom;
        }

        public ObservableCollection<ItemInRoom> GetAllItemsInRoomByRoomId(int id)
        {
            setConnection();
            ObservableCollection<ItemInRoom> itemsInRoom = new ObservableCollection<ItemInRoom>();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT* FROM ITEM_IN_ROOM LEFT OUTER JOIN INVENTORY_ITEM ON inventory_item.ID = ITEM_IN_ROOM.inventory_item_ID WHERE room_ID = " + id.ToString();
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ItemInRoom newItemInRoom = new ItemInRoom(reader.GetInt32(0), Convert.ToUInt32(reader.GetInt32(2)), null, null);
                newItemInRoom.room_id = reader.GetInt32(3);
                newItemInRoom.inventoryItem_id = reader.GetInt32(1);
                itemsInRoom.Add(newItemInRoom);

            }
            con.Close();
            con.Dispose();

            foreach (ItemInRoom itemInRoom in itemsInRoom)
            {
                itemInRoom.room = roomRepository.GetRoomById(itemInRoom.room_id);
                itemInRoom.inventoryItem = inventoryItemRepository.GetInventoryItemById(itemInRoom.inventoryItem_id);
            }


            return itemsInRoom;
        }

        public Boolean DeleteItemInRoomById(int id)
        {
            setConnection();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM item_in_room WHERE id = " + id.ToString();

            try
            {
                cmd.ExecuteNonQuery();

                connection.Close();
                connection.Dispose();

                Trace.WriteLine("DeleteItemInRoomById");

                return true;
            }
            catch (Exception e)
            {
                connection.Close();
                connection.Dispose();
                
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
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText =
                "UPDATE item_in_room "     +
                "SET inventory_item_id = " + itemInRoom.inventoryItem.Id.ToString() + ", " +
                "quantity = "              + itemInRoom.Quantity.ToString()         + ", " +
                "room_id = "               + itemInRoom.room.Id.ToString()          + " "  +
                "WHERE id = "              + itemInRoom.Id.ToString();


            try
            {
                cmd.ExecuteNonQuery();

                connection.Close();
                connection.Dispose();
                
                Trace.WriteLine("Prosao UpdateItemInRoom");
                return itemInRoom;  
            }
            catch (Exception e)
            {
                connection.Close();
                connection.Dispose();

                return null;
            }

        }

        public ItemInRoom NewItemInRoom(ItemInRoom itemInRoom)
        {
            setConnection();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO item_in_room (inventory_item_id, quantity, room_id) VALUES (" +
                itemInRoom.inventoryItem.Id.ToString() + ", " +
                itemInRoom.Quantity.ToString()         + ", " +
                itemInRoom.room.Id.ToString()          + ")";
            try
            {
                cmd.ExecuteNonQuery();
                
                connection.Close();
                connection.Dispose();

                return itemInRoom;
            }
            catch (Exception exp)
            {
                connection.Close();
                connection.Dispose();

                return null;
            }

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