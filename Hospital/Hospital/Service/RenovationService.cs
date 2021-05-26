/***********************************************************************
 * Module:  RenovationService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.RenovationService
 ***********************************************************************/

using Hospital.Model;
using System;
using System.Collections.ObjectModel;
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
                QuickTrace("Usao ovde");
                foreach(ItemInRoom itemInRenovatedRoom in itemInRoomService.GetAllItemsInRoomByRoomId(renovatedRoom.Id))
                {
                    QuickTrace("A i ovde");
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
                    break;
                case RenovationType.SPLIT:
                    EndSplitRenovation(renovation);
                    break;
                case RenovationType.MERGE:
                    break;
                default:
                    return null;
            }

            return renovationRepository.UpdateRenovation(renovation);
        }

        private void EndSplitRenovation(Renovation renovation)
        {

        }

        public Repository.RenovationRepository renovationRepository = new Repository.RenovationRepository();
        public Service.ItemInRoomService itemInRoomService = new ItemInRoomService();
   }
}