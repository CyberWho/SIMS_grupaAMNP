/***********************************************************************
 * Module:  RoomType.cs
 * Author:  Pedja
 * Purpose: Definition of the Class RoomType
 ***********************************************************************/

using System.Collections;

namespace Hospital.Model
{
    public class RoomType
    {

        public int Id { get; set; }
        public string Type { get; set; }

        public ArrayList room;

        /// <pdGenerated>default getter</pdGenerated>
        public ArrayList GetRoom()
        {
            if (room == null)
                room = new ArrayList();
            return room;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetRoom(ArrayList newRoom)
        {
            RemoveAllRoom();
            foreach (Room oRoom in newRoom)
                AddRoom(oRoom);
        }

        /// <pdGenerated>default New</pdGenerated>
        public void AddRoom(Room newRoom)
        {
            if (newRoom == null)
                return;
            if (this.room == null)
                this.room = new ArrayList();
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
                ArrayList tmpRoom = new ArrayList();
                foreach (Room oldRoom in room)
                    tmpRoom.Add(oldRoom);
                room.Clear();
                foreach (Room oldRoom in tmpRoom)
                    oldRoom.SetRoomType((RoomType)null);
                tmpRoom.Clear();
            }
        }

        public RoomType(int id, string type, ArrayList room)
        {
            Id = id;
            Type = type;
            this.room = room;
        }

        public RoomType()
        {
        }
    }
}