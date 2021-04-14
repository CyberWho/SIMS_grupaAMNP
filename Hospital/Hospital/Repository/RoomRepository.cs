/***********************************************************************
 * Module:  RoomRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.RoomRepository
 ***********************************************************************/

using System;

namespace Hospital.Repository
{
   public class RoomRepository
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