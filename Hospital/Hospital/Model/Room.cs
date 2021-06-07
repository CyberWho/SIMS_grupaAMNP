/***********************************************************************
 * Module:  Room.cs
 * Author:  Pedja
 * Purpose: Definition of the Class Room
 ***********************************************************************/

using System.Collections;
using System.Collections.ObjectModel;

namespace Hospital.Model
{
    public class Room
    {


        public int? Id { get; set; }
        public int? Floor { get; set; }
        public double? Area { get; set; }
        public string Description { get; set; }

        public Renovation Renovation { get; set; }
        public ArrayList appointment;

        public Room(int? id, int? floor, double? area, string description, RoomType newRoomType)
        {
            Id = id;
            Floor = floor;
            Area = area;
            Description = description;
            roomType = newRoomType;
        }

        /// <pdGenerated>default getter</pdGenerated>
        public ArrayList GetAppointment()
        {
            if (appointment == null)
                appointment = new ArrayList();
            return appointment;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetAppointment(ArrayList newAppointment)
        {
            RemoveAllAppointment();
            foreach (Appointment oAppointment in newAppointment)
                AddAppointment(oAppointment);
        }

        /// <pdGenerated>default New</pdGenerated>
        public void AddAppointment(Appointment newAppointment)
        {
            if (newAppointment == null)
                return;
            if (this.appointment == null)
                this.appointment = new ArrayList();
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
                ArrayList tmpAppointment = new ArrayList();
                foreach (Appointment oldAppointment in appointment)
                    tmpAppointment.Add(oldAppointment);
                appointment.Clear();
                foreach (Appointment oldAppointment in tmpAppointment)
                    oldAppointment.SetRoom((Room)null);
                tmpAppointment.Clear();
            }
        }
        public RoomType roomType { get; set; }

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
        public ObservableCollection<ItemInRoom> itemInRoom;

        /// <pdGenerated>default getter</pdGenerated>
        public ObservableCollection<ItemInRoom> GetItemInRoom()
        {
            if (itemInRoom == null)
                itemInRoom = new ObservableCollection<ItemInRoom>();
            return itemInRoom;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetItemInRoom(ArrayList newItemInRoom)
        {
            RemoveAllItemInRoom();
            foreach (ItemInRoom oItemInRoom in newItemInRoom)
                AddItemInRoom(oItemInRoom);
        }

        /// <pdGenerated>default New</pdGenerated>
        public void AddItemInRoom(ItemInRoom newItemInRoom)
        {
            if (newItemInRoom == null)
                return;
            if (this.itemInRoom == null)
                this.itemInRoom = new ObservableCollection<ItemInRoom>();
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
                ArrayList tmpItemInRoom = new ArrayList();
                foreach (ItemInRoom oldItemInRoom in itemInRoom)
                    tmpItemInRoom.Add(oldItemInRoom);
                itemInRoom.Clear();
                foreach (ItemInRoom oldItemInRoom in tmpItemInRoom)
                    oldItemInRoom.SetRoom((Room)null);
                tmpItemInRoom.Clear();
            }
        }
        public ArrayList doctor;

        /// <pdGenerated>default getter</pdGenerated>
        public ArrayList GetDoctor()
        {
            if (doctor == null)
                doctor = new ArrayList();
            return doctor;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetDoctor(ArrayList newDoctor)
        {
            RemoveAllDoctor();
            foreach (Doctor oDoctor in newDoctor)
                AddDoctor(oDoctor);
        }

        /// <pdGenerated>default New</pdGenerated>
        public void AddDoctor(Doctor newDoctor)
        {
            if (newDoctor == null)
                return;
            if (this.doctor == null)
                this.doctor = new ArrayList();
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
                ArrayList tmpDoctor = new ArrayList();
                foreach (Doctor oldDoctor in doctor)
                    tmpDoctor.Add(oldDoctor);
                doctor.Clear();
                foreach (Doctor oldDoctor in tmpDoctor)
                    oldDoctor.SetRoom((Room)null);
                tmpDoctor.Clear();
            }
        }

        public Room(int id, int floor, double area, string description, Renovation renovation, ArrayList appointment, RoomType roomType, ObservableCollection<ItemInRoom> itemInRoom, ArrayList doctor)
        {
            Id = id;
            Floor = floor;
            Area = area;
            Description = description;
            Renovation = renovation;
            this.appointment = appointment;
            this.roomType = roomType;
            this.itemInRoom = itemInRoom;
            this.doctor = doctor;
        }

        public Room()
        {
        }
    }

}