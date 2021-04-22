/***********************************************************************
 * Module:  RoomRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.RoomRepository
 ***********************************************************************/

using System;
using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Hospital.Repository
{
   public class RoomRepository
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

            }
        }
        public Hospital.Model.Room GetRoomById(int id)
      {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM room WHERE id = " + id.ToString();
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Room room = new Room();
            room.Id = reader.GetInt32(0);
            room.Floor = reader.GetInt32(1);
            room.Area = reader.GetDouble(2);
            room.Description = reader.GetString(3);

            con.Close();
            return room;
      }

        public Room GetAppointmentRoomById(int id)
        {
            setConnection();
            
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM ROOM WHERE ID = :id";
            cmd.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader a = cmd.ExecuteReader();
            a.Read();
            Room room = new Room();
            room.Id = a.GetInt32(0);
            room.Floor = a.GetInt32(1);
            room.Area = a.GetDouble(2);
            room.Description = a.GetString(3);
            con.Close();
            return room;
        }
      
      public Hospital.Model.Room GetRoomByAppointmentId(int appointmentId)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Room GetRoomByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<Room> GetAllRooms()
      {
            setConnection();
            ObservableCollection<Room> rooms = new ObservableCollection<Room>();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT room.id, floor, area, description, rtype, room_type.id ROOMTYPEID FROM room LEFT OUTER JOIN room_type ON room.rtype_id = room_type.id ORDER BY room.id";
            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                RoomType newRoomType = new RoomType(reader.GetInt32(5), reader.GetString(4), null);
                Room newRoom = new Room(reader.GetInt32(0), reader.GetInt32(1), reader.GetDouble(2), reader.GetString(3), newRoomType);
                rooms.Add(newRoom);
            }

            con.Close();
            return rooms;
      }
      
      public System.Collections.ArrayList GetAllRoomsByFloor(int floor)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllRoomsByRoomType(Hospital.Model.RoomType roomType)
      {
         // TODO: implement
         return null;
      }
        public ObservableCollection<RoomType> GetAllRoomTypesForEachRoom()
        {
            setConnection();

            ObservableCollection<RoomType> roomTypes = new ObservableCollection<RoomType>();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM room LEFT OUTER JOIN room_type ON room.rtype_id = room_type.id ORDER BY room.id";
            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                RoomType roomType = new RoomType
                {
                    Id = reader.GetInt32(5),
                    Type = reader.GetString(6)
                };
                roomTypes.Add(roomType);
            }

            con.Close();
            return roomTypes;
        }

        public ObservableCollection<RoomType> GetAllRoomTypes()
        {
            setConnection();
            ObservableCollection<RoomType> roomTypes = new ObservableCollection<RoomType>();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM room_type";
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                RoomType roomType = new RoomType(reader.GetInt32(0), reader.GetString(1), null);
                roomTypes.Add(roomType);
            }

            con.Close();
            return roomTypes;
        }

        public Boolean DeleteRoomById(int id)
      {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM room WHERE id = " + id.ToString();

            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception e)
            {
                con.Close();
                return false;
            }
      }
      
      public Boolean DeleteRoomByAppointmentId(int appointmentId)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean DeleteRoomByDoctorId(int doctorId)
      {
         // TODO: implement
         return false;
      }
      
      public Hospital.Model.Room UpdateRoom(Hospital.Model.Room room)
      {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText =
                "UPDATE room "    +
                "SET floor = "    + room.Floor.ToString()       + ", "  +
                "area = "         + room.Area.ToString()        + ", "  +
                "description = '" + room.Description.ToString() + "', " +
                "rtype_id = "     + room.roomType.Id.ToString() + " "   +
                "WHERE id = "     + room.Id.ToString();

            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
                return room;
            }
            catch(Exception e)
            {
                con.Close();
                return null;
            }
      }
      
      public Hospital.Model.Room NewRoom(Hospital.Model.Room room)
      {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT max(id) FROM room";
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            cmd.CommandText = "INSERT INTO room VALUES(" + 
                (reader.GetInt32(0)+1).ToString() + ", "  +
                room.Floor.ToString()             + ", "  +
                room.Area.ToString()              + ", '" +
                room.Description.ToString()       + "', " +
                room.roomType.Id.ToString()       + ")";
            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
                return room;
            }
            catch(Exception exp)
            {
                Trace.WriteLine("Failed adding room with ID " + reader.GetInt32(0).ToString() + " .");
                con.Close();
                return null;
            }
      }
      
      public int GetLastId()
      {
            setConnection();

            con.Close();
            return 0;
      }
      public RoomType GetRoomTypeByType(string Type)
        {
            setConnection();
            try
            {
                OracleCommand cmd = con.CreateCommand();
                RoomType roomType = new RoomType();
                cmd.CommandText = "SELECT * FROM room_type WHERE rtype = '" + Type + "'";
                OracleDataReader reader = cmd.ExecuteReader();
                reader.Read();
                roomType.Id = reader.GetInt32(0);
                roomType.Type = reader.GetString(1);

                con.Close();
                return roomType;
            }
            catch (Exception exp)
            {
                con.Close();
                throw new Exception(exp.ToString());
            }
        }

        public ObservableCollection<Room> GetAllRoomsExceptSource(int id)
        {
            setConnection();
            ObservableCollection<Room> rooms = new ObservableCollection<Room>();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT room.id, floor, area, description, rtype, room_type.id ROOMTYPEID FROM room LEFT OUTER JOIN room_type ON room.rtype_id = room_type.id " +
                "WHERE room.id != " + id.ToString() + 
                " ORDER BY room.id";
            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                RoomType newRoomType = new RoomType(reader.GetInt32(5), reader.GetString(4), null);
                Room newRoom = new Room(reader.GetInt32(0), reader.GetInt32(1), reader.GetDouble(2), reader.GetString(3), newRoomType);
                rooms.Add(newRoom);
            }

            con.Close();
            return rooms;
        }

    }
}