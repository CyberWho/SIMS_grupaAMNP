using System;
using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static Globals;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Hospital.Repository
{
    public class RoomRepository
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
        public Room GetRoomById(int id)
        {
            Room room = new Room();
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM room LEFT OUTER JOIN room_type ON room.rtype_id = room_type.id WHERE room.id = " + id.ToString();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            room.Id = reader.GetInt32(0);
            room.Floor = reader.GetInt32(1);
            room.Area = reader.GetDouble(2);
            room.Description = reader.GetString(3);
            RoomType newRoomType = new RoomType(reader.GetInt32(4), reader.GetString(5), null);
            room.roomType = newRoomType;

            
            

            return room;
        }

        public Room GetAppointmentRoomById(int id)
        {
            

            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM ROOM WHERE ID = :id";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = null; //prvo inicijalizacija na null resava operation on closed object
            reader = command.ExecuteReader();
            reader.Read();
            Room room = new Room();
            room.Id = reader.GetInt32(0);
            room.Floor = reader.GetInt32(1);
            room.Area = reader.GetDouble(2);
            room.Description = reader.GetString(3);
            
            
            return room;
        }

        public ObservableCollection<Room> GetRoomByDiscardingIDList(ObservableCollection<int> IDs)
        {
            string IDsString = "";
            foreach(int ID in IDs)
            {
                IDsString += ID.ToString() + ", ";
            }
            IDsString = IDsString.Remove(IDsString.Length - 2);

            
            OracleCommand query = globalConnection.CreateCommand();
            query.CommandText = "SELECT * FROM room LEFT OUTER JOIN room_type ON room.rtype_id = room_type.id WHERE room.id not in (" + IDsString + ") and rtype_id != 5 order by room.id";
            OracleDataReader reader;
            
            try
            {
                reader = query.ExecuteReader();
            }
            catch (Exception exp)
            {
                ThrowException(exp);
                return null;
            }

            ObservableCollection<Room> Rooms = new ObservableCollection<Room>();
            while (reader.Read())
            {
                RoomType newRoomType = new RoomType(reader.GetInt32(4), reader.GetString(6), null);
                Rooms.Add(new Room(reader.GetInt32(0), reader.GetInt32(1), reader.GetDouble(2), reader.GetString(3), newRoomType));
            }

            return Rooms;
        }

        public Room GetRoomByAppointmentId(int appointmentId)
        { 
            // TODO: implement
            return null;
        }

        public Room GetRoomByDoctorId(int doctorId)
        {
            //select room_id from doctor where id = 1;
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "select room_id from doctor where id = " + doctorId;
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            int room_id = reader.GetInt32(0);
            
            return GetAppointmentRoomById(room_id);
        }

        public ObservableCollection<Room> GetAllRooms()
        {
            
            ObservableCollection<Room> rooms = new ObservableCollection<Room>();
            OracleCommand cmd = Globals.globalConnection.CreateCommand();
            cmd.CommandText = "SELECT room.id, floor, area, description, rtype, room_type.id ROOMTYPEID FROM room LEFT OUTER JOIN room_type ON room.rtype_id = room_type.id ORDER BY room.id";
            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                RoomType newRoomType = new RoomType(reader.GetInt32(5), reader.GetString(4), null);
                Room newRoom = new Room(reader.GetInt32(0), reader.GetInt32(1), reader.GetDouble(2), reader.GetString(3), newRoomType);
                rooms.Add(newRoom);
            }

            
            

            return rooms;
        }

        public System.Collections.ArrayList GetAllRoomsByFloor(int floor)
        {
            // TODO: implement
            return null;
        }

        #region marko_kt5
        public ObservableCollection<Room> GetAllRoomsByRoomType(RoomType roomType)
        {
            

            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM room WHERE rtype_id = " + roomType.Id;
            OracleDataReader reader = command.ExecuteReader();

            ObservableCollection<Room> rooms = new ObservableCollection<Room>();

            while (reader.Read())
            {
                rooms.Add(ParseRoom(reader));
            }

            return rooms;
        }

        private static Room ParseRoom(OracleDataReader reader)
        {
            Room room = new Room();
            room.Id = int.Parse(reader.GetString(0));
            room.Floor = int.Parse(reader.GetString(1));
            room.Area = int.Parse(reader.GetString(2));
            room.Description = reader.GetString(4);
            return room;
        }
        #endregion

        public ObservableCollection<RoomType> GetAllRoomTypesForEachRoom()
        {
            

            ObservableCollection<RoomType> roomTypes = new ObservableCollection<RoomType>();
            OracleCommand cmd = Globals.globalConnection.CreateCommand();
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

            
            

            return roomTypes;
        }

        public ObservableCollection<RoomType> GetAllRoomTypes()
        {
            
            ObservableCollection<RoomType> roomTypes = new ObservableCollection<RoomType>();
            OracleCommand cmd = Globals.globalConnection.CreateCommand();
            cmd.CommandText = "SELECT * FROM room_type";
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                RoomType roomType = new RoomType(reader.GetInt32(0), reader.GetString(1), null);
                roomTypes.Add(roomType);
            }

            
            

            return roomTypes;
        }
        public ObservableCollection<int> GetAllRoomIDs()
        {
            
            ObservableCollection<int> roomIDs = new ObservableCollection<int>();
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT id FROM room";
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
                roomIDs.Add(reader.GetInt32(0));
            }

            return roomIDs;
        }

        public Boolean DeleteRoomById(int id)
        {
            
            OracleCommand cmd = Globals.globalConnection.CreateCommand();
            cmd.CommandText = "DELETE FROM room WHERE id = " + id.ToString();

            try
            {
                cmd.ExecuteNonQuery();

                
                

                return true;
            }
            catch (Exception e)
            {

                
                

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
            
            OracleCommand cmd = Globals.globalConnection.CreateCommand();
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

                
                

                return room;
            }
            catch (Exception e)
            {

                
                

                return null;
            }
        }

        public Room NewRoom(Room room)
        {
            
            OracleCommand cmd = Globals.globalConnection.CreateCommand();
            cmd.CommandText = "SELECT max(id) FROM room";
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            
            
            cmd.CommandText = "INSERT INTO room VALUES(" +
                (reader.GetInt32(0) + 1).ToString() + ", " +
                room.Floor.ToString() + ", " +
                room.Area.ToString() + ", '" +
                room.Description.ToString() + "', " +
                room.roomType.Id.ToString() + ")";
            QuickTrace("----- FAIL SQL COMMAND: " + cmd.CommandText);
            try
            {
                cmd.ExecuteNonQuery();

                
                

                return room;
            }
            catch (Exception exp)
            {
                Trace.WriteLine("Failed adding room with ID " + (reader.GetInt32(0)+1).ToString() + " .");

                
                

                return null;
            }
        }

        public int GetLastId()
        {
            

            
            

            return 0;
        }
        public RoomType GetRoomTypeByType(string Type)
        {
            
            try
            {
                OracleCommand cmd = Globals.globalConnection.CreateCommand();
                RoomType roomType = new RoomType();
                cmd.CommandText = "SELECT * FROM room_type WHERE rtype = '" + Type + "'";
                OracleDataReader reader = cmd.ExecuteReader();
                reader.Read();
                roomType.Id = reader.GetInt32(0);
                roomType.Type = reader.GetString(1);

                
                

                return roomType;
            }
            catch (Exception exp)
            {

                
                

                throw new Exception(exp.ToString());
            }
        }

        public ObservableCollection<Room> GetAllRoomsExceptSource(int id)
        {
            
            ObservableCollection<Room> rooms = new ObservableCollection<Room>();
            OracleCommand cmd = Globals.globalConnection.CreateCommand();
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

            
            

            return rooms;
        }

        private Room ParseFromReader(OracleDataReader reader)
        {
            RoomType newRoomType = new RoomType(reader.GetInt32(5), reader.GetString(4), null);
            Room newRoom = new Room(reader.GetInt32(0), reader.GetInt32(1), reader.GetDouble(2), reader.GetString(3), newRoomType);
            return newRoom;
        }
    }
}