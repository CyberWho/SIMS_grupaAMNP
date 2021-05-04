/***********************************************************************
 * Module:  Class20.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.Class20
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Controller
{
   public class RoomController
   {
      public Room GetRoomById(int id)
      {
         return roomService.GetRoomById(id);
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
         return roomService.GetAllRooms();
      }
      
      public ObservableCollection<ReservedItem> GetAllRoomsByFloor(int floor)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<ReservedItem> GetAllRoomsByRoomType(RoomType roomType)
      {
         // TODO: implement
         return null;
      }

        public ObservableCollection<RoomType> GetAllRoomTypesForEachRoom()
        {
            return roomService.GetAllRoomTypes();
        }

        public ObservableCollection<RoomType> GetAllRoomTypes()
        {
            return roomService.GetAllRoomTypes();
        }

        public ObservableCollection<Room> GetAllRoomsExceptSource(int id)
        {
            return roomService.GetAllRoomsExceptSource(id);
        }

      public Boolean DeleteRoomById(int id)
        { 
            return roomService.DeleteRoomById(id);
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
         return roomService.AddRoom(room);
      }
      
      public Room UpdateRoom(Room room)
      {
         return roomService.UpdateRoom(room);
      }
        public int GetLastId()
        {
            // TODO: implement
            return 0;
        }

        public RoomType GetRoomTypeByType(string Type)
        {
            return roomService.GetRoomTypeByType(Type);
        }

        public Service.RoomService roomService = new Service.RoomService();
   
   }
}