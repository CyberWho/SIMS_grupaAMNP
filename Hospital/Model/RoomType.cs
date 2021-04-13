/***********************************************************************
 * Module:  RoomType.cs
 * Author:  Pedja
 * Purpose: Definition of the Class RoomType
 ***********************************************************************/

using System;

namespace Hospital.Model
{
   public class RoomType
   {
      public string Type;
      
      public System.Collections.ArrayList room;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetRoom()
      {
         if (room == null)
            room = new System.Collections.ArrayList();
         return room;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetRoom(System.Collections.ArrayList newRoom)
      {
         RemoveAllRoom();
         foreach (Room oRoom in newRoom)
            AddRoom(oRoom);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddRoom(Room newRoom)
      {
         if (newRoom == null)
            return;
         if (this.room == null)
            this.room = new System.Collections.ArrayList();
         if (!this.room.Contains(newRoom))
         {
            this.room.Add(newRoom);
            newRoom.SetRoomType(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveRoom(Room oldRoom)
      {
         if (oldRoom == null)
            return;
         if (this.room != null)
            if (this.room.Contains(oldRoom))
            {
               this.room.Remove(oldRoom);
               oldRoom.SetRoomType((RoomType)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllRoom()
      {
         if (room != null)
         {
            System.Collections.ArrayList tmpRoom = new System.Collections.ArrayList();
            foreach (Room oldRoom in room)
               tmpRoom.Add(oldRoom);
            room.Clear();
            foreach (Room oldRoom in tmpRoom)
               oldRoom.SetRoomType((RoomType)null);
            tmpRoom.Clear();
         }
      }
   
   }
}