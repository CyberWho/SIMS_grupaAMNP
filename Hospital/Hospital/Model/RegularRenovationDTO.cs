using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    class RegularRenovationDTO : IRenovationDto
    {
        public int Id { get; set; }
        public Renovation renovation { get; set; }
        public string Type { get; set; }
        public string Rooms { get; set; }
        public string Ended { get; set; }

        public RegularRenovationDTO(Renovation _renovation)
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
        }
        public RegularRenovationDTO(){}

        public object CreateDto(Renovation _renovation)
        {
            return new RegularRenovationDTO(_renovation);
        }
    }
}
