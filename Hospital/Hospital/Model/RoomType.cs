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

        private string Type { get; set; }

        public System.Collections.ArrayList Room;

        public System.Collections.ArrayList GetRoom()
        {
            if (Room == null)
                Room = new System.Collections.ArrayList();
            return Room;
        }

        public void SetRoom(System.Collections.ArrayList newRoom)
        {
            RemoveAllRoom();
            foreach (Room oRoom in newRoom)
                AddRoom(oRoom);
        }

        public void AddRoom(Room newRoom)
        {
            if (newRoom == null)
                return;
            if (this.Room == null)
                this.Room = new System.Collections.ArrayList();
            if (!this.Room.Contains(newRoom))
            {
                this.Room.Add(newRoom);
                newRoom.SetRoomType(this);
            }
        }

        public void RemoveRoom(Room oldRoom)
        {
            if (oldRoom == null)
                return;
            if (this.Room != null)
                if (this.Room.Contains(oldRoom))
                {
                    this.Room.Remove(oldRoom);
                    oldRoom.SetRoomType((RoomType)null);
                }
        }

        public void RemoveAllRoom()
        {
            if (Room != null)
            {
                System.Collections.ArrayList tmpRoom = new System.Collections.ArrayList();
                foreach (Room oldRoom in Room)
                    tmpRoom.Add(oldRoom);
                Room.Clear();
                foreach (Room oldRoom in tmpRoom)
                    oldRoom.SetRoomType((RoomType)null);
                tmpRoom.Clear();
            }
        }

    }
}