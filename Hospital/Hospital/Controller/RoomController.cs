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
      public Hospital.Model.Room GetRoomById(int id)
      {
         return roomService.GetRoomById(id);
      }
      
      public Hospital.Model.Room GetRoomByAppointmentId(int appointmentId)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Room GetRoomByDoctorId(int doctorId)
      {
         return roomService.GetRoomByDoctorId(doctorId);
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
      
      public ObservableCollection<ReservedItem> GetAllRoomsByRoomType(Hospital.Model.RoomType roomType)
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
      
      public Hospital.Model.Room ChangeRoomArea(Hospital.Model.Room room, double newArea)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Room AddRoom(Hospital.Model.Room room)
      {
         return roomService.AddRoom(room);
      }
      
      public Hospital.Model.Room UpdateRoom(Hospital.Model.Room room)
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

        public ObservableCollection<Room> findSuitableRoomsForOperation(DateTime fromFuture, DateTime toFuture,
            ObservableCollection<InventoryItem> items_needed)
        {
            return roomService.findSuitableRoomsForOperation(fromFuture, toFuture,
                items_needed);
        }

        public ObservableCollection<TimeSlot> findSuitableTimeSlotsForOperation(int id_room, int id_doc, int id_patient, DateTime startTime)
        {
            return roomService.findSuitableTimeSlotsForOperation(id_room, id_doc, id_patient, startTime);
        }

        public Hospital.Service.RoomService roomService = new Service.RoomService();
   
   }
}