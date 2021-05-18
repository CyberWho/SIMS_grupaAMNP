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

        public Renovation(int id, DateTime startDate, RenovationType type, ObservableCollection<Room> rooms)
        {
            Id = id;
            StartDate = startDate;
            Type = type;
            Rooms = rooms;
        }

        public Renovation()
        {
        }
    }
}