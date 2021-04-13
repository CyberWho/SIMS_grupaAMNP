/***********************************************************************
 * Module:  RoomService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.RoomService
 ***********************************************************************/

using System;

namespace Hospital.Service
{
   public class RoomService
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
      
      public System.Array<Room> GetAllRooms()
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Room> GetAllRoomsByFloor(int floor)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Room> GetAllRoomsByRoomType(Hospital.Model.RoomType roomType)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteRoomById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteRoomByAppointmentId(int appointmentId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteRoomByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
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
   
      public Hospital.Repository.RoomRepository roomRepository;
   
   }
}