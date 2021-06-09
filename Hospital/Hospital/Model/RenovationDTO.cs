using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Hospital.Model
{
    public class RenovationDTO
    {


        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public string Type { get; set; }
        public RenovationType EnumType { get; set; }

        public string Rooms { get; set; }

        public ObservableCollection<Room> RoomsList { get; set; }

        public string Ended { get; set; }

        public uint NewArea { get; set; }

        public RenovationDTO(Renovation renovation)
        {
            Id = renovation.Id;
            StartDate = renovation.StartDate;
            RoomsList = renovation.Rooms;
            EnumType = renovation.Type;
            switch ((int)renovation.Type)
            {
                case 0:
                    Type = "Obična";
                    break;
                case 1:
                    Type = "Spajanje";
                    break;
                case 2:
                    Type = "Razdvajanje";
                    break;
                default:
                    Type = "";
                    break;
            }
            Rooms = "";
            foreach(int? RoomID in renovation.RoomIDs)
            {
                Rooms += RoomID.ToString() + ", ";
            }
            Rooms = Rooms.Remove(Rooms.Length - 2);

            if (renovation.Ended)
            {
                Ended = "Završena";
            }
            else
            {
                Ended = "U toku";
            }
            NewArea = renovation.NewArea;
        }

        public RenovationDTO()
        {
        }
    }
}