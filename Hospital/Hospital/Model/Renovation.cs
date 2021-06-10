/***********************************************************************
 * Module:  Renovation.cs
 * Author:  Pedja
 * Purpose: Definition of the Class Renovation
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Repository;
using Xceed.Wpf.Toolkit.Core.Converters;

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

        public Renovation(IRenovationDto DTO) : this()
        {
            Id = DTO.renovation.Id;
            StartDate = DTO.renovation.StartDate;
            Type = DTO.renovation.Type;
            Rooms = DTO.renovation.Rooms;
            Ended = DTO.renovation.Ended;
            NewArea = DTO.renovation.NewArea;
            RoomIDs = new ObservableCollection<int?>();
        }
        public Renovation()
        {
        }

        public static Renovation EndRenovation(Renovation renovation, RenovationEnding renovationEnding, RenovationRepository repo)
        {
            return renovationEnding.EndRenovation(renovation, repo);
        }
    }
}