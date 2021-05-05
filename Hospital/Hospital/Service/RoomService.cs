/***********************************************************************
 * Module:  RoomService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.RoomService
 ***********************************************************************/

using Hospital.Model;
using System;
using System.Collections.ObjectModel;

namespace Hospital.Service
{
    public class RoomService
    {
        public Room GetRoomById(int id)
        {
            return roomRepository.GetRoomById(id);
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
            return roomRepository.GetAllRooms();
        }

        public System.Collections.ArrayList GetAllRoomsByFloor(int floor)
        {
            // TODO: implement
            return null;
        }

        public System.Collections.ArrayList GetAllRoomsByRoomType(RoomType roomType)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<RoomType> GetAllRoomTypesForEachRoom()
        {
            return roomRepository.GetAllRoomTypes();
        }
        public ObservableCollection<RoomType> GetAllRoomTypes()
        {
            return roomRepository.GetAllRoomTypes();
        }

        public ObservableCollection<Room> GetAllRoomsExceptSource(int id)
        {
            return roomRepository.GetAllRoomsExceptSource(id);
        }

        public Boolean DeleteRoomById(int id)
        { 
            return roomRepository.DeleteRoomById(id);
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

        public Room ChangeRoomArea(Room room, double newArea)
        {
            // TODO: implement
            return null;
        }

        public Room AddRoom(Room room)
        { 
         return roomRepository.NewRoom(room);
        }
      
        public Room UpdateRoom(Room room)
        { 
            return roomRepository.UpdateRoom(room);
        }
        public int GetLastId()
        {
            // TODO: implement
            return 0;
        }

        public RoomType GetRoomTypeByType(string Type)
        {
            return roomRepository.GetRoomTypeByType(Type);
        }

        public Repository.RoomRepository roomRepository = new Repository.RoomRepository();
   
   }
}