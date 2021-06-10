using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    class SplitRenovationEnding : RenovationEnding
    {
        protected override void RoomsUpdate(Renovation renovation, Repository.RoomRepository repo)
        {
            renovation.Rooms.First().Area -= renovation.NewArea;
            repo.UpdateRoom(renovation.Rooms.First());
            Room newRoom = renovation.Rooms.First();
            newRoom.Area = renovation.NewArea;
            newRoom.roomType = renovation.Rooms.First().roomType;
            repo.NewRoom(newRoom);
        }
    }
}
