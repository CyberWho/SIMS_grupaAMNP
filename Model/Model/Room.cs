/***********************************************************************
 * Module:  Room.cs
 * Author:  Pedja
 * Purpose: Definition of the Class Room
 ***********************************************************************/

using System;

namespace Hospital.Model
{
   public class Room
   {
      public bool Reserve()
      {
         // TODO: implement
         return null;
      }
      
      public Boolean Free()
      {
         // TODO: implement
         return null;
      }
      
      public Boolean ChangeRoomType()
      {
         // TODO: implement
         return null;
      }
      
      public Boolean Remove()
      {
         // TODO: implement
         return null;
      }
      
      public Boolean SpendItem()
      {
         // TODO: implement
         return null;
      }
   
      public Renovation renovation;
      public System.Collections.ArrayList appointment;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetAppointment()
      {
         if (appointment == null)
            appointment = new System.Collections.ArrayList();
         return appointment;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetAppointment(System.Collections.ArrayList newAppointment)
      {
         RemoveAllAppointment();
         foreach (Appointment oAppointment in newAppointment)
            AddAppointment(oAppointment);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddAppointment(Appointment newAppointment)
      {
         if (newAppointment == null)
            return;
         if (this.appointment == null)
            this.appointment = new System.Collections.ArrayList();
         if (!this.appointment.Contains(newAppointment))
         {
            this.appointment.Add(newAppointment);
            newAppointment.SetRoom(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveAppointment(Appointment oldAppointment)
      {
         if (oldAppointment == null)
            return;
         if (this.appointment != null)
            if (this.appointment.Contains(oldAppointment))
            {
               this.appointment.Remove(oldAppointment);
               oldAppointment.SetRoom((Room)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllAppointment()
      {
         if (appointment != null)
         {
            System.Collections.ArrayList tmpAppointment = new System.Collections.ArrayList();
            foreach (Appointment oldAppointment in appointment)
               tmpAppointment.Add(oldAppointment);
            appointment.Clear();
            foreach (Appointment oldAppointment in tmpAppointment)
               oldAppointment.SetRoom((Room)null);
            tmpAppointment.Clear();
         }
      }
      public RoomType roomType;
      
      /// <pdGenerated>default parent getter</pdGenerated>
      public RoomType GetRoomType()
      {
         return roomType;
      }
      
      /// <pdGenerated>default parent setter</pdGenerated>
      /// <param>newRoomType</param>
      public void SetRoomType(RoomType newRoomType)
      {
         if (this.roomType != newRoomType)
         {
            if (this.roomType != null)
            {
               RoomType oldRoomType = this.roomType;
               this.roomType = null;
               oldRoomType.RemoveRoom(this);
            }
            if (newRoomType != null)
            {
               this.roomType = newRoomType;
               this.roomType.AddRoom(this);
            }
         }
      }
      public System.Collections.ArrayList itemInRoom;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetItemInRoom()
      {
         if (itemInRoom == null)
            itemInRoom = new System.Collections.ArrayList();
         return itemInRoom;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetItemInRoom(System.Collections.ArrayList newItemInRoom)
      {
         RemoveAllItemInRoom();
         foreach (ItemInRoom oItemInRoom in newItemInRoom)
            AddItemInRoom(oItemInRoom);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddItemInRoom(ItemInRoom newItemInRoom)
      {
         if (newItemInRoom == null)
            return;
         if (this.itemInRoom == null)
            this.itemInRoom = new System.Collections.ArrayList();
         if (!this.itemInRoom.Contains(newItemInRoom))
         {
            this.itemInRoom.Add(newItemInRoom);
            newItemInRoom.SetRoom(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveItemInRoom(ItemInRoom oldItemInRoom)
      {
         if (oldItemInRoom == null)
            return;
         if (this.itemInRoom != null)
            if (this.itemInRoom.Contains(oldItemInRoom))
            {
               this.itemInRoom.Remove(oldItemInRoom);
               oldItemInRoom.SetRoom((Room)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllItemInRoom()
      {
         if (itemInRoom != null)
         {
            System.Collections.ArrayList tmpItemInRoom = new System.Collections.ArrayList();
            foreach (ItemInRoom oldItemInRoom in itemInRoom)
               tmpItemInRoom.Add(oldItemInRoom);
            itemInRoom.Clear();
            foreach (ItemInRoom oldItemInRoom in tmpItemInRoom)
               oldItemInRoom.SetRoom((Room)null);
            tmpItemInRoom.Clear();
         }
      }
      public System.Collections.ArrayList doctor;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetDoctor()
      {
         if (doctor == null)
            doctor = new System.Collections.ArrayList();
         return doctor;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetDoctor(System.Collections.ArrayList newDoctor)
      {
         RemoveAllDoctor();
         foreach (Doctor oDoctor in newDoctor)
            AddDoctor(oDoctor);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddDoctor(Doctor newDoctor)
      {
         if (newDoctor == null)
            return;
         if (this.doctor == null)
            this.doctor = new System.Collections.ArrayList();
         if (!this.doctor.Contains(newDoctor))
         {
            this.doctor.Add(newDoctor);
            newDoctor.SetRoom(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveDoctor(Doctor oldDoctor)
      {
         if (oldDoctor == null)
            return;
         if (this.doctor != null)
            if (this.doctor.Contains(oldDoctor))
            {
               this.doctor.Remove(oldDoctor);
               oldDoctor.SetRoom((Room)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllDoctor()
      {
         if (doctor != null)
         {
            System.Collections.ArrayList tmpDoctor = new System.Collections.ArrayList();
            foreach (Doctor oldDoctor in doctor)
               tmpDoctor.Add(oldDoctor);
            doctor.Clear();
            foreach (Doctor oldDoctor in tmpDoctor)
               oldDoctor.SetRoom((Room)null);
            tmpDoctor.Clear();
         }
      }
   
      private uint Id;
      private double Area;
      private uint Floor;
      private string Description;
   
   }
}