/***********************************************************************
 * Module:  Renovation.cs
 * Author:  Pedja
 * Purpose: Definition of the Class Renovation
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class Renovation
    {


        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public RenovationType Type { get; set; }

        public Room Room { get; set; }

        public Renovation(int id, DateTime startDate, RenovationType type, Room room)
        {
            Id = id;
            StartDate = startDate;
            Type = type;
            Room = room;
        }

        public Renovation()
        {
        }
    }
}