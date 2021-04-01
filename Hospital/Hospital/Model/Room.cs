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

        private int Id { get; set; }
        private int Floor { get; set; }
        private double Area { get; set; }
        private string Description { get; set; }
       // public Renovation Renovation { get; set; }

        public RoomType RoomType;
        public System.Collections.ArrayList Appointment;
        public System.Collections.ArrayList ItemInRoom;
        public System.Collections.ArrayList Doctor;

        public Room(int id, int floor, double area, string description, RoomType roomType)
        {
            Id = id;
            Floor = floor;
            Area = area;
            Description = description;
            RoomType = roomType;
        }

        public bool Reserve()
        {
            // TODO: implement
            return false;
        }

        public Boolean Free()
        {
            // TODO: implement
            return false;
        }

        public Boolean ChangeRoomType()
        {
            // TODO: implement
            return false;
        }

        public Boolean Remove()
        {
            // TODO: implement
            return false;
        }

        public Boolean SpendItem()
        {
            // TODO: implement
            return false;
        }

        public RoomType GetRoomType()
        {
            return RoomType;
        }

        public void SetRoomType(RoomType newRoomType)
        {
            if (this.RoomType != newRoomType)
            {
                if (this.RoomType != null)
                {
                    RoomType oldRoomType = this.RoomType;
                    this.RoomType = null;
                    oldRoomType.RemoveRoom(this);
                }
                if (newRoomType != null)
                {
                    this.RoomType = newRoomType;
                    this.RoomType.AddRoom(this);
                }
            }
        }

        public System.Collections.ArrayList GetAppointment()
        {
            if (Appointment == null)
                Appointment = new System.Collections.ArrayList();
            return Appointment;
        }

        public void SetAppointment(System.Collections.ArrayList newAppointment)
        {
            RemoveAllAppointment();
            foreach (Appointment oAppointment in newAppointment)
                AddAppointment(oAppointment);
        }

        public void AddAppointment(Appointment newAppointment)
        {
            if (newAppointment == null)
                return;
            if (this.Appointment == null)
                this.Appointment = new System.Collections.ArrayList();
            if (!this.Appointment.Contains(newAppointment))
            {
                this.Appointment.Add(newAppointment);
                newAppointment.SetRoom(this);
            }
        }

        public void RemoveAppointment(Appointment oldAppointment)
        {
            if (oldAppointment == null)
                return;
            if (this.Appointment != null)
                if (this.Appointment.Contains(oldAppointment))
                {
                    this.Appointment.Remove(oldAppointment);
                    oldAppointment.SetRoom((Room)null);
                }
        }

        public void RemoveAllAppointment()
        {
            if (Appointment != null)
            {
                System.Collections.ArrayList tmpAppointment = new System.Collections.ArrayList();
                foreach (Appointment oldAppointment in Appointment)
                    tmpAppointment.Add(oldAppointment);
                Appointment.Clear();
                foreach (Appointment oldAppointment in tmpAppointment)
                    oldAppointment.SetRoom((Room)null);
                tmpAppointment.Clear();
            }
        }

        public System.Collections.ArrayList GetItemInRoom()
        {
            if (ItemInRoom == null)
                ItemInRoom = new System.Collections.ArrayList();
            return ItemInRoom;
        }

        public void SetItemInRoom(System.Collections.ArrayList newItemInRoom)
        {
            RemoveAllItemInRoom();
            foreach (ItemInRoom oItemInRoom in newItemInRoom)
                AddItemInRoom(oItemInRoom);
        }

        public void AddItemInRoom(ItemInRoom newItemInRoom)
        {
            if (newItemInRoom == null)
                return;
            if (this.ItemInRoom == null)
                this.ItemInRoom = new System.Collections.ArrayList();
            if (!this.ItemInRoom.Contains(newItemInRoom))
            {
                this.ItemInRoom.Add(newItemInRoom);
                newItemInRoom.SetRoom(this);
            }
        }

        public void RemoveItemInRoom(ItemInRoom oldItemInRoom)
        {
            if (oldItemInRoom == null)
                return;
            if (this.ItemInRoom != null)
                if (this.ItemInRoom.Contains(oldItemInRoom))
                {
                    this.ItemInRoom.Remove(oldItemInRoom);
                    oldItemInRoom.SetRoom((Room)null);
                }
        }

        public void RemoveAllItemInRoom()
        {
            if (ItemInRoom != null)
            {
                System.Collections.ArrayList tmpItemInRoom = new System.Collections.ArrayList();
                foreach (ItemInRoom oldItemInRoom in ItemInRoom)
                    tmpItemInRoom.Add(oldItemInRoom);
                ItemInRoom.Clear();
                foreach (ItemInRoom oldItemInRoom in tmpItemInRoom)
                    oldItemInRoom.SetRoom((Room)null);
                tmpItemInRoom.Clear();
            }
        }

        public System.Collections.ArrayList GetDoctor()
        {
            if (Doctor == null)
                Doctor = new System.Collections.ArrayList();
            return Doctor;
        }

        public void SetDoctor(System.Collections.ArrayList newDoctor)
        {
            RemoveAllDoctor();
            foreach (Doctor oDoctor in newDoctor)
                AddDoctor(oDoctor);
        }

        public void AddDoctor(Doctor newDoctor)
        {
            if (newDoctor == null)
                return;
            if (this.Doctor == null)
                this.Doctor = new System.Collections.ArrayList();
            if (!this.Doctor.Contains(newDoctor))
            {
                this.Doctor.Add(newDoctor);
                newDoctor.SetRoom(this);
            }
        }

        public void RemoveDoctor(Doctor oldDoctor)
        {
            if (oldDoctor == null)
                return;
            if (this.Doctor != null)
                if (this.Doctor.Contains(oldDoctor))
                {
                    this.Doctor.Remove(oldDoctor);
                    oldDoctor.SetRoom((Room)null);
                }
        }

        public void RemoveAllDoctor()
        {
            if (Doctor != null)
            {
                System.Collections.ArrayList tmpDoctor = new System.Collections.ArrayList();
                foreach (Doctor oldDoctor in Doctor)
                    tmpDoctor.Add(oldDoctor);
                Doctor.Clear();
                foreach (Doctor oldDoctor in tmpDoctor)
                    oldDoctor.SetRoom((Room)null);
                tmpDoctor.Clear();
            }
        }

    }
}