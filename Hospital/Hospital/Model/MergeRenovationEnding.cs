using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    class MergeRenovationEnding : RenovationEnding
    {
        protected override void RoomsUpdate(Renovation renovation, Repository.RoomRepository repo)
        {
            Room NewRoom = GetRoomWithSmallestRoomID(renovation.Rooms);
            NewRoom = MergeAreasAndInventories(renovation, NewRoom);
            DeleteAllMergedRoomsExceptNewRoom(renovation, NewRoom, repo);
            repo.UpdateRoom(NewRoom);
        }

        private Room MergeAreasAndInventories(Renovation renovation, Room newRoom)
        {
            foreach (Room renovatedRoom in renovation.Rooms)
            {
                if (newRoom.Id != renovatedRoom.Id)
                {
                    newRoom.Area += renovatedRoom.Area;
                    //itemInRoomRepository.MoveAllItemsFromRoom(renovatedRoom, NewRoom);
                }
            }
            return newRoom;
        }
        private void DeleteAllMergedRoomsExceptNewRoom(Renovation renovation, Room newRoom, Repository.RoomRepository repo)
        {
            foreach (Room roomToDelete in renovation.Rooms)
            {
                if (roomToDelete.Id != newRoom.Id)
                    repo.DeleteRoomById((int)roomToDelete.Id);
            }
        }
        private Room GetRoomWithSmallestRoomID(ObservableCollection<Room> rooms)
        {
            return rooms.Aggregate((curMin, x) => (curMin == null || (x.Id ?? int.MaxValue) < curMin.Id ? x : curMin));
        }
    }
}
