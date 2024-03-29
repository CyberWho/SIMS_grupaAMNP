/***********************************************************************
 * Module:  ReservedItemRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.ReservedItemRepository
 ***********************************************************************/

using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Security.Cryptography;
using Hospital.Model;
using Hospital.Repository;
using static Globals;

namespace Hospital.Repository
{
    public class ReservedItemRepository
    {
        private ItemInRoomRepository itemInRoomRepository = new ItemInRoomRepository();
        private RoomRepository roomRepository = new RoomRepository();

        
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
        public ReservedItem GetReservedItemById(int id)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<ReservedItem> GetAllReservedItems()
        {
            //
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            ObservableCollection<ReservedItem> reservedItems = new ObservableCollection<ReservedItem>();
            command.CommandText = "select * from reserved_item";
            OracleDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReservedItem reservedItem = new ReservedItem();
                reservedItem.Id = reader.GetInt32(0);
                reservedItem.ReservedDate = reader.GetDateTime(1);

                reservedItem.room_id = reader.GetInt32(2);

                reservedItem.item_in_room_id = reader.GetInt32(3);
                reservedItem.ItemInRoom = itemInRoomRepository.GetItemInRoomById(reservedItem.item_in_room_id);
                reservedItem.Room = roomRepository.GetRoomById(reservedItem.room_id);

                reservedItems.Add(reservedItem);
            }
            
            

            /*foreach (ReservedItem reservedItem in reservedItems)
            {
                reservedItem.Room = roomRepository.GetRoomById(reservedItem.room_id);
                reservedItem.ItemInRoom = itemInRoomRepository.GetItemInRoomById(reservedItem.item_in_room_id);
            }*/

            return reservedItems;
        }

        public System.Collections.ArrayList GetAllReservedItemsByRoomId(int roomId)
        {
            // TODO: implement
            return null;
        }

        public System.Collections.ArrayList GetAllReservedItemsByItemInRoomId(int itemInRoomId)
        {
            // TODO: implement
            return null;
        }

        public Boolean DeleteReservedItemById(int id)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteAllReservedItemsByRoomId(int roomId)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteAllReservedItemsByItemInRoomId(int itemInRoomId)
        {
            // TODO: implement
            return false;
        }

        public ReservedItem UpdateReservedItem(ReservedItem reservedItem)
        {
            // TODO: implement
            return null;
        }

        public ReservedItem NewReservedItem(ReservedItem reservedItem)
        {
            
            OracleCommand cmd = globalConnection.CreateCommand();

            if (reservedItem.ReservedDate == null)
            {
                Trace.WriteLine("ReservedDate je null");
            }
            if (reservedItem.Room == null)
            {
                Trace.WriteLine("Room je null");
            }
            if (reservedItem.ItemInRoom == null)
            {
                Trace.WriteLine("ItemInRoom je null");
            }


            cmd.CommandText = "INSERT INTO reserved_item (reserved_date, room_id, item_in_room_id) VALUES (to_date('" +
               reservedItem.ReservedDate.ToString() + "','DD-MON-YY HH:MI:SS PM')," +
               reservedItem.Room.Id.ToString() + ", " +
               reservedItem.ItemInRoom.Id.ToString() + ")";

            Trace.WriteLine(cmd.CommandText);
            try
            {
                cmd.ExecuteNonQuery();

                globalConnection.Close();
                globalConnection.Dispose();

                return reservedItem;
            }
            catch (Exception exp)
            {

                globalConnection.Close();
                globalConnection.Dispose();
                Trace.WriteLine(exp.ToString());
                return null;
            }
        }


        public int GetLastId()
        {
            // TODO: implement
            return 0;
        }

    }
}