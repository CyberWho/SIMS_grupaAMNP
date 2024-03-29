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
      
      public ObservableCollection<Room> GetAllRoomsByRoomType(RoomType roomType)
      {
         return this.roomService.GetAllRoomsByRoomType(roomType);
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
        public ObservableCollection<int> GetAllRoomIDs()
        {
            return roomService.GetAllRoomIDs();
        }

        public bool DeleteRoomById(int id)
        {
            return roomService.DeleteRoomById(id);
        }

        public Room GetAppointmentRoomById(int roomId)
        {
            return roomService.GetAppointmentRoomById(roomId);
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

        public ObservableCollection<Room> findSuitableRoomsWithEquipment(DateRange dateRange,
            ObservableCollection<InventoryItem> items_needed)
        {
            return roomService.findSuitableRoomsWithEquipment(dateRange,
                items_needed);
        }

        public String findSuitableRoomsForOperation1(DateRange dateRange,
            ObservableCollection<InventoryItem> items_needed)
        {
            return roomService.findSuitableRoomsForOperation1(dateRange,
                items_needed);
        }

        public ObservableCollection<TimeSlot> findSuitableTimeSlotsForOperation(int id_room, int id_doc, int id_patient, DateTime startTime)
        {
            return roomService.findSuitableTimeSlotsForOperation(id_room, id_doc, id_patient, startTime);
        }

        public Hospital.Service.RoomService roomService = new Service.RoomService();
   
   }
}