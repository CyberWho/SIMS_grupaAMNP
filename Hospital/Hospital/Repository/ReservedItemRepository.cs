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

namespace Hospital.Repository
{
    public class ReservedItemRepository
    {
        private ItemInRoomRepository itemInRoomRepository = new ItemInRoomRepository();
        private RoomRepository roomRepository = new RoomRepository();

        OracleConnection con = null;
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
        public Model.ReservedItem GetReservedItemById(int id)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<ReservedItem> GetAllReservedItems()
        {
            setConnection();
            OracleCommand command = con.CreateCommand();
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

                reservedItems.Add(reservedItem);
            }
            con.Close();
            con.Dispose();

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

        public Model.ReservedItem UpdateReservedItem(Model.ReservedItem reservedItem)
        {
            // TODO: implement
            return null;
        }

        public Model.ReservedItem NewReservedItem(Model.ReservedItem reservedItem)
        {
            setConnection();
            OracleCommand cmd = con.CreateCommand();

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

                connection.Close();
                connection.Dispose();

                return reservedItem;
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

    }
}