/***********************************************************************
 * Module:  RenovationService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.RenovationService
 ***********************************************************************/

using Hospital.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using static Globals;

namespace Hospital.Service
{
   public class RenovationService
   {
        public ObservableCollection<Renovation> GetAllRenovations()
        {
            return renovationRepository.GetAllRenovations();
        }
        public ObservableCollection<Renovation> GetAllActiveRenovations()
        {
            return renovationRepository.GetAllActiveRenovations();
        }

        public Renovation GetRenovationById(int id)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Room> GetAllRoomsNotInRenovation()
        {
            return renovationRepository.GetAllRoomsNotInRenovation();
        }
        public System.Collections.ArrayList GetRenovationByRoomId(int roomId)
        {
            // TODO: implement
            return null;
        }

        public Boolean DeleteRenovationById(int id)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteRenovationByRoomId(int roomId)
        {
            // TODO: implement
            return false;
        }

        public Renovation UpdateRenovation(Renovation renovation)
        { 
            return renovationRepository.UpdateRenovation(renovation);
        }

        public Renovation AddRenovation(Renovation renovation)
        {
            if (DateTime.Compare(renovation.StartDate, DateTime.Now) < 0)
            {
                return null;
            }
            foreach(Room renovatedRoom in renovation.Rooms)
            {
                foreach(ItemInRoom itemInRenovatedRoom in itemInRoomService.GetAllItemsInRoomByRoomId((int)renovatedRoom.Id))
                {
                    itemInRoomService.MoveWholeItemNowToMainStorage(itemInRenovatedRoom);
                }
            }
            return renovationRepository.NewRenovation(renovation);
        }

        public Renovation ChangeStartDate(Renovation renovation, DateTime newStartDate)
        {
            if (DateTime.Compare(newStartDate, DateTime.Now) < 0)
            {
                return null;
            }
            if (DateTime.Compare(newStartDate, renovation.StartDate) == 0)
            {
                return renovation;
            }
            renovation.StartDate = newStartDate;
            return renovationRepository.UpdateRenovation(renovation);
        }
        public Renovation EndRenovation(Renovation renovation)
        {
            renovation.Ended = true;

            switch (renovation.Type)
            {
                case RenovationType.REGULAR:
                    return Renovation.EndRenovation(renovation, new RegularRenovationEnding(), renovationRepository);
                case RenovationType.SPLIT:
                    return Renovation.EndRenovation(renovation, new SplitRenovationEnding(), renovationRepository);
                case RenovationType.MERGE:
                    return Renovation.EndRenovation(renovation, new MergeRenovationEnding(), renovationRepository);
                default:
                    return null;
            }
        }

        private void EndMergeRenovation(Renovation renovation)
        {
            Room NewRoom = GetRoomWithSmallestRoomID(renovation.Rooms);
            NewRoom = MergeAreasAndInventories(renovation, NewRoom);
            DeleteAllMergedRoomsExceptNewRoom(renovation, NewRoom);
            roomRepository.UpdateRoom(NewRoom);
        }
        private Room MergeAreasAndInventories(Renovation renovation, Room NewRoom)
        {
            foreach (Room renovatedRoom in renovation.Rooms)
            {
                if (NewRoom.Id != renovatedRoom.Id)
                {
                    NewRoom.Area += renovatedRoom.Area;
                    //itemInRoomRepository.MoveAllItemsFromRoom(renovatedRoom, NewRoom);
                }
            }
            QuickTrace("Nova soba ima površinu: " + NewRoom.Area.ToString() + ", a broj sobe je: " + NewRoom.Id.ToString());
            return NewRoom;
        }
        private void DeleteAllMergedRoomsExceptNewRoom(Renovation renovation, Room NewRoom)
        {
            foreach(Room RoomToDelete in renovation.Rooms)
            {
                if(RoomToDelete.Id != NewRoom.Id)
                    roomRepository.DeleteRoomById((int)RoomToDelete.Id);
            }
        }
        private Room GetRoomWithSmallestRoomID(ObservableCollection<Room> Rooms)
        {
            return Rooms.Aggregate((curMin, x) => (curMin == null || (x.Id ?? int.MaxValue) < curMin.Id ? x : curMin));
        }

        public Repository.RenovationRepository renovationRepository = new Repository.RenovationRepository();
        public ItemInRoomService itemInRoomService = new ItemInRoomService();
        public Repository.RoomRepository roomRepository = new Repository.RoomRepository();
        public Repository.ItemInRoomRepository itemInRoomRepository = new Repository.ItemInRoomRepository();
   }
}