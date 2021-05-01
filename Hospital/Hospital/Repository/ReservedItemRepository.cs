/***********************************************************************
 * Module:  ReservedItemRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.ReservedItemRepository
 ***********************************************************************/

using Oracle.ManagedDataAccess.Client;
using System;
using System.Diagnostics;

namespace Hospital.Repository
{
   public class ReservedItemRepository
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
        public Hospital.Model.ReservedItem GetReservedItemById(int id)
        {
            // TODO: implement
            return null;
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

        public Hospital.Model.ReservedItem UpdateReservedItem(Hospital.Model.ReservedItem reservedItem)
        {
            // TODO: implement
            return null;
        }

        public Hospital.Model.ReservedItem NewReservedItem(Hospital.Model.ReservedItem reservedItem)
        {
            setConnection();
            OracleCommand cmd = connection.CreateCommand();
            
            if(reservedItem.ReservedDate == null)
            {
                Trace.WriteLine("ReservedDate je null");
            }
            if (reservedItem.Room== null)
            {
                Trace.WriteLine("Room je null");
            }
            if (reservedItem.ItemInRoom == null)
            {
                Trace.WriteLine("ItemInRoom je null");
            }


            cmd.CommandText = "INSERT INTO reserved_item (reserved_date, room_id, item_in_room_id) VALUES (to_date('" +
               reservedItem.ReservedDate.ToString()  + "','DD-MON-YY HH:MI:SS PM')," +
               reservedItem.Room.Id.ToString()       + ", " +
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