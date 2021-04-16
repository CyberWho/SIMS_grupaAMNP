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
         // TODO: implement
         return null;
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
         // TODO: implement
         return null;
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
      
      public Hospital.Model.Room ChangeRoomArea(Hospital.Model.Room room, double newArea)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Room AddRoom(Hospital.Model.Room room)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Room UpdateRoom(Hospital.Model.Room room)
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Service.RoomService roomService;
   
   }
}