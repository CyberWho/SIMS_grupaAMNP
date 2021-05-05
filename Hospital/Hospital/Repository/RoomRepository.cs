using System;
using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Hospital.Repository
{
    public class RoomRepository
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
        public Hospital.Model.Room GetRoomById(int id)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM room WHERE id = " + id.ToString();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            Room room = new Room();
            room.Id = reader.GetInt32(0);
            room.Floor = reader.GetInt32(1);
            room.Area = reader.GetDouble(2);
            room.Description = reader.GetString(3);

            connection.Close();
            connection.Dispose();

            return room;
        }

        public Room GetAppointmentRoomById(int id)
        {
            setConnection();
            
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM ROOM WHERE ID = :id";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            Room room = new Room();
            room.Id = reader.GetInt32(0);
            room.Floor = reader.GetInt32(1);
            room.Area = reader.GetDouble(2);
            room.Description = reader.GetString(3);
            connection.Close();
            connection.Dispose();
            return room;
        }
      
      public Room GetRoomByAppointmentId(int appointmentId)
      {
         // TODO: implement
         return null;
      }
      
      public Room GetRoomByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<Room> GetAllRooms()
      {
            setConnection();
            ObservableCollection<Room> rooms = new ObservableCollection<Room>();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT room.id, floor, area, description, rtype, room_type.id ROOMTYPEID FROM room LEFT OUTER JOIN room_type ON room.rtype_id = room_type.id ORDER BY room.id";
            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                RoomType newRoomType = new RoomType(reader.GetInt32(5), reader.GetString(4), null);
                Room newRoom = new Room(reader.GetInt32(0), reader.GetInt32(1), reader.GetDouble(2), reader.GetString(3), newRoomType);
                rooms.Add(newRoom);
            }

            connection.Close();
            connection.Dispose();

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
            OracleCommand cmd = connection.CreateCommand();
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
            
            connection.Close();
            connection.Dispose();

            return roomTypes;
        }

        public ObservableCollection<RoomType> GetAllRoomTypes()
        {
            setConnection();
            ObservableCollection<RoomType> roomTypes = new ObservableCollection<RoomType>();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM room_type";
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                RoomType roomType = new RoomType(reader.GetInt32(0), reader.GetString(1), null);
                roomTypes.Add(roomType);
            }

            connection.Close();
            connection.Dispose();

            return roomTypes;
        }

        public Boolean DeleteRoomById(int id)
        {
            setConnection();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM room WHERE id = " + id.ToString();

            try
            {
                cmd.ExecuteNonQuery();

                connection.Close();
                connection.Dispose();

                return true;
            }
            catch (Exception e)
            {

                connection.Close();
                connection.Dispose();

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
      
      public Room UpdateRoom(Room room)
      {
            setConnection();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText =
                "UPDATE room " +
                "SET floor = " + room.Floor.ToString() + ", " +
                "area = " + room.Area.ToString() + ", " +
                "description = '" + room.Description.ToString() + "', " +
                "rtype_id = " + room.roomType.Id.ToString() + " " +
                "WHERE id = " + room.Id.ToString();

            try
            {
                cmd.ExecuteNonQuery();

                connection.Close();
                connection.Dispose();

                return room;
            }
            catch (Exception e)
            {

                connection.Close();
                connection.Dispose();

                return null;
            }
      }
      
      public Room NewRoom(Room room)
      {
            setConnection();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT max(id) FROM room";
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            cmd.CommandText = "INSERT INTO room VALUES(" +
                (reader.GetInt32(0) + 1).ToString() + ", " +
                room.Floor.ToString() + ", " +
                room.Area.ToString() + ", '" +
                room.Description.ToString() + "', " +
                room.roomType.Id.ToString() + ")";
            try
            {
                cmd.ExecuteNonQuery();

                connection.Close();
                connection.Dispose();

                return room;
            }
            catch (Exception exp)
            {
                Trace.WriteLine("Failed adding room with ID " + reader.GetInt32(0).ToString() + " .");

                connection.Close();
                connection.Dispose();

                return null;
            }
        }

        public int GetLastId()
        {
            setConnection();

            connection.Close();
            connection.Dispose();

            return 0;
        }
        public RoomType GetRoomTypeByType(string Type)
        {
            setConnection();
            try
            {
                OracleCommand cmd = connection.CreateCommand();
                RoomType roomType = new RoomType();
                cmd.CommandText = "SELECT * FROM room_type WHERE rtype = '" + Type + "'";
                OracleDataReader reader = cmd.ExecuteReader();
                reader.Read();
                roomType.Id = reader.GetInt32(0);
                roomType.Type = reader.GetString(1);

                connection.Close();
                connection.Dispose();

                return roomType;
            }
            catch (Exception exp)
            {

                connection.Close();
                connection.Dispose();

                throw new Exception(exp.ToString());
            }
        }

        public ObservableCollection<Room> GetAllRoomsExceptSource(int id)
        {
            setConnection();
            ObservableCollection<Room> rooms = new ObservableCollection<Room>();
            OracleCommand cmd = connection.CreateCommand();
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

            connection.Close();
            connection.Dispose();

            return rooms;
        }

    }
}