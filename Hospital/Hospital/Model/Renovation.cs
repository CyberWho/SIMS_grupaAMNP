/***********************************************************************
 * Module:  Renovation.cs
 * Author:  Pedja
 * Purpose: Definition of the Class Renovation
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;

namespace Hospital.Model
{
    public class Renovation
    {


        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public RenovationType Type { get; set; }

        public ObservableCollection<Room> Rooms { get; set; }
        public ObservableCollection<int?> RoomIDs { get; set; } 
        public bool Ended { get; set; }

        public uint NewArea { get; set; }

        public Renovation(int id, DateTime startDate, RenovationType type, ObservableCollection<Room> rooms)
        {
            Id = id;
            StartDate = startDate;
            Type = type;
            Rooms = rooms;
            RoomIDs = new ObservableCollection<int?>();
        }

        public Renovation(int id, DateTime startDate, RenovationType type, ObservableCollection<Room> rooms, bool ended, uint newArea)
        {
            Id = id;
            StartDate = startDate;
            Type = type;
            Rooms = rooms;
            Ended = ended;
            NewArea = newArea;
            RoomIDs = new ObservableCollection<int?>();
        }

        public Renovation(RenovationDTO DTO)
        {
            Id = DTO.Id;
            StartDate = DTO.StartDate;
            Type = DTO.EnumType;
            Rooms = DTO.RoomsList;
            if (DTO.Ended.Equals("U toku"))
            {
                Ended = false;
            }
            else
            {
                Ended = true;
            }
            NewArea = DTO.NewArea;
            RoomIDs = new ObservableCollection<int?>();
            foreach(Room room in Rooms)
            {
                RoomIDs.Add(room.Id);
            }
        }

        public Renovation()
        {
        }
    }
}