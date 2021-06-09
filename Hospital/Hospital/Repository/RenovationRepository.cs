/***********************************************************************
 * Module:  RenovationRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.RenovationRepository
 ***********************************************************************/

using Hospital.Model;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using static Globals;

namespace Hospital.Repository
{
   public class RenovationRepository
   {
        readonly string SelectAllCommandText = "SELECT * FROM renovation_rooms inner join renovation on renovation.id = renovation_id";

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
                QuickTrace("FAILED TO OPEN CONNECTION IN RENOVATION REPOSITORY: " + exp.ToString());
            }
        }
        public ObservableCollection<Renovation> GetAllRenovations()
        {
            
            OracleCommand query = globalConnection.CreateCommand();
            query.CommandText = SelectAllCommandText;
            OracleDataReader reader;

            try
            {
                reader = query.ExecuteReader();
            }
            catch(Exception exp)
            {
                ThrowException(exp);
                return null;
            }
            ObservableCollection<Renovation> Renovations = ParseRenovationsFromReader(reader);

            return Renovations;
        }
        public ObservableCollection<Renovation> GetAllActiveRenovations()
        {
            
            OracleCommand query = globalConnection.CreateCommand();
            query.CommandText = SelectAllCommandText + " WHERE ended = 0";
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
            ObservableCollection<Renovation> Renovations = ParseRenovationsFromReader(reader);

            return Renovations;
        }

        public Renovation GetRenovationById(int id)
        {
            
            OracleCommand query = globalConnection.CreateCommand();
            query.CommandText = SelectAllCommandText + " WHERE renovation_id = " + id.ToString();
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
            Renovation newRenovation = ParseFromReader(reader);
            return newRenovation;
        }
        public ObservableCollection<Room> GetAllRoomsNotInRenovation()
        {
            
            OracleCommand query = globalConnection.CreateCommand();
            ObservableCollection<int> RoomIDs = new ObservableCollection<int>();
            query.CommandText = "SELECT DISTINCT room_id FROM renovation_rooms inner join renovation on renovation.id = renovation_id WHERE ended = 0";
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

            while (reader.Read())
            {
                RoomIDs.Add(reader.GetInt32(0));
            }

            ObservableCollection<Room> Rooms = roomRepository.GetRoomByDiscardingIDList(RoomIDs);

            return Rooms;
        }
        public Renovation GetRenovationByRoomId(int roomId)
        {
            // TODO: implement
            return null;
        }

        public Boolean DeleteRenovationById(int id)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteRenovationByRoomId(int roomId)
        {
            // TODO: implement
            return false;
        }

        public Renovation UpdateRenovation(Renovation renovation)
        {
            
            OracleCommand query = globalConnection.CreateCommand();
            string ended = renovation.Ended ? "1" : "0";
            query.CommandText = "UPDATE renovation SET " +
                "start_time = to_date('" + renovation.StartDate.ToString() + "','DD-MON-YY HH:MI:SS PM'), " +
                "ended = " + ended + " " +
                "where id = " + renovation.Id.ToString();
            try
            {
                query.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                ThrowException(exp);
                return null;
            }

            Renovation existingRenovation = GetRenovationById(renovation.Id);
            ObservableCollection<Room> roomsToUpdate = new ObservableCollection<Room>();

            foreach (Room room in renovation.Rooms)
            {
                bool exists = false;
                foreach (Room existingRoom in existingRenovation.Rooms)
                {
                    if (room.Id == existingRoom.Id)
                    {
                        exists = true;
                        break;
                    }
                }
                if (!exists)
                {
                    roomsToUpdate.Add(room);
                }
            }

            foreach (Room roomToUpdate in roomsToUpdate)
            {
                query.CommandText = "INSERT INTO renovation_rooms(renovation_id, room_id) VALUES (" + renovation.Id + ", " + roomToUpdate.Id + ")";
                try
                {
                    query.ExecuteNonQuery();
                }
                catch (Exception exp)
                {
                    ThrowException(exp);
                    return null;
                }
            }


            return renovation;
        }

        public Renovation NewRenovation(Renovation renovation)
        {
            string ended = renovation.Ended ? "1" : "0";

            
            OracleCommand query = globalConnection.CreateCommand();
            query.CommandText = "INSERT INTO renovation (start_time, type, ended, new_area) VALUES (to_date('" + renovation.StartDate.ToString() + "','DD-MON-YY HH:MI:SS PM'), " +
                + (int)renovation.Type + ", " + ended + ", " + renovation.NewArea.ToString() + ")";
            
            try
            {
                query.ExecuteNonQuery();
            }
                catch (Exception exp)
            {
                ThrowException(exp);
                return null;
            }

            foreach (Room room in renovation.Rooms)
            {
                query.CommandText = "INSERT INTO renovation_rooms(renovation_id, room_id) VALUES (" + GetLastId() + ", " + room.Id + ")";
                try
                {
                    query.ExecuteNonQuery();
                }
                catch (Exception exp)
                {
                    ThrowException(exp);
                    return null;
                }
            }

            return renovation;
        }

        public int GetLastId()
        {
            
            OracleCommand query = globalConnection.CreateCommand();
            query.CommandText = "SELECT max(id) FROM renovation";
            OracleDataReader reader;

            try
            {
                reader = query.ExecuteReader();
            }
            catch(Exception exp)
            {
                ThrowException(exp);
                return -1;
            }

            reader.Read();
            int ID = reader.GetInt32(0);

            return ID;
        }

        private Renovation ParseFromReader(OracleDataReader reader)
        {
            ObservableCollection<Room> rooms = new ObservableCollection<Room>();
            reader.Read();
            Renovation newRenovation = new Renovation(reader.GetInt32(1), reader.GetDateTime(5), (RenovationType)reader.GetInt32(4), null);
            rooms.Add(roomRepository.GetRoomById(reader.GetInt32(2)));
            newRenovation.RoomIDs.Add(reader.GetInt32(2));
            while (reader.Read())
            {
                rooms.Add(roomRepository.GetRoomById(reader.GetInt32(2)));
                newRenovation.RoomIDs.Add(reader.GetInt32(2));
            }
            newRenovation.Rooms = rooms;
            return newRenovation;
        }
        private ObservableCollection<Renovation> ParseRenovationsFromReader(OracleDataReader reader)
        {
            ObservableCollection<Renovation> Renovations = new ObservableCollection<Renovation>();
            ObservableCollection<Renovation> RenovationsTemp = new ObservableCollection<Renovation>();

            while (reader.Read())
            {
                Room newRoom = roomRepository.GetRoomById(reader.GetInt32(2));
                ReadRenovationFromMultiple(reader, RenovationsTemp, newRoom);
            }

            foreach (Renovation existingRenovation in RenovationsTemp)
            {
                if(Renovations.Select(x => x.Id).Contains(existingRenovation.Id))
                {
                    Renovations.Where(x => x.Id == existingRenovation.Id).FirstOrDefault().Rooms.Add(existingRenovation.Rooms.FirstOrDefault());
                    Renovations.Where(x => x.Id == existingRenovation.Id).FirstOrDefault().RoomIDs.Add(existingRenovation.RoomIDs.FirstOrDefault());
                }
                else
                {
                    Renovations.Add(existingRenovation);
                }
            }
            return Renovations;
        }

        private void ReadRenovationFromMultiple(OracleDataReader reader, ObservableCollection<Renovation> Renovations, Room newRoom)
        {
            ObservableCollection<Room> newRooms = new ObservableCollection<Room>
                        {
                            newRoom
                        };
            bool Ended = reader.GetInt32(6) == 1;
            Renovation newRenovation = new Renovation(reader.GetInt32(1), reader.GetDateTime(5), (RenovationType)reader.GetInt32(4), newRooms, Ended, uint.Parse(reader.GetInt32(7).ToString()));
            newRenovation.RoomIDs.Add(reader.GetInt32(2));
            Renovations.Add(newRenovation);
        }

        RoomRepository roomRepository = new RoomRepository();
   }
}