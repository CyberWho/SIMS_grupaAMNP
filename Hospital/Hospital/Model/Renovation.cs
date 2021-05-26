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
        public bool Ended { get; set; }

        public uint NewArea { get; set; }

        public Renovation(int id, DateTime startDate, RenovationType type, ObservableCollection<Room> rooms)
        {
            Id = id;
            StartDate = startDate;
            Type = type;
            Rooms = rooms;
        }

        public Renovation(int id, DateTime startDate, RenovationType type, ObservableCollection<Room> rooms, uint newArea)
        {
            Id = id;
            StartDate = startDate;
            Type = type;
            Rooms = rooms;
            NewArea = newArea;
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
        }

        public Renovation()
        {
        }
    }
}