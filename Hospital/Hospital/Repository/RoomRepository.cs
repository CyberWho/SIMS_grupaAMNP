using System;
using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;

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

            return null;
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

        public System.Collections.ArrayList GetAllRooms()
        {
            // TODO: implement
            return null;
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

        public Boolean DeleteRoomById(int id)
        {
            // TODO: implement
            return false;
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
            // TODO: implement
            return null;
        }

        public Hospital.Model.Room NewRoom(Hospital.Model.Room room)
        {
            // TODO: implement
            return null;
        }

        public int GetLastId()
        {
            // TODO: implement
            return 0;
        }

    }
}