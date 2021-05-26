/***********************************************************************
 * Module:  RenovationController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.RenovationController
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;
using static Globals;

namespace Hospital.Controller
{
    public class RenovationController
    {
        public ObservableCollection<Renovation> GetAllRenovations()
        {
            return renovationService.GetAllRenovations();
        }
        public ObservableCollection<Renovation> GetAllActiveRenovations()
        {
            return renovationService.GetAllActiveRenovations();
        }
        public Renovation GetRenovationById(int id)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Room> GetAllRoomsNotInRenovation()
        {
            return renovationService.GetAllRoomsNotInRenovation();
        }
        public ObservableCollection<Renovation> GetRenovationByRoomId(int roomId)
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
            return renovationService.UpdateRenovation(renovation);
        }

        public Renovation AddRenovation(Renovation renovation)
        {
            return renovationService.AddRenovation(renovation);
        }

        public Renovation ChangeStartDate(Renovation renovation, DateTime newStartDate)
        {
            return renovationService.ChangeStartDate(renovation, newStartDate);
        }
        public Renovation EndRenovation(Renovation renovation)
        {
            return renovationService.EndRenovation(renovation);
        }


        public Service.RenovationService renovationService = new Service.RenovationService();

    }
}