using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.Model
{
    class SplitRenovationDTO : ISplitRenovationDto
    {
        public int Id { get; set; }
        public Renovation renovation { get; set; }
        public string Type { get; set; }
        public string Rooms { get; set; }
        public string Ended { get; set; }
        public uint NewArea { get; set; }
        public SplitRenovationDTO(Renovation _renovation)
        {
            renovation = _renovation;
            Id = _renovation.Id;
            Type = "Obična";
            Rooms = "";
            foreach (int? RoomID in _renovation.RoomIDs)
            {
                Rooms += RoomID + ", ";
            }
            Rooms = Rooms.Remove(Rooms.Length - 2);

            Ended = _renovation.Ended ? "Završena" : "U toku";
            NewArea = _renovation.NewArea;
        }

        public SplitRenovationDTO() { }
    }
}
