/***********************************************************************
 * Module:  FreeDaysController.cs
 * Author:  DELL
 * Purpose: Definition of the Class Hospital.Controller.FreeDaysController
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Repository;
using Hospital.Service;

namespace Hospital.Controller
{
    public class FreeDaysController
    {
        public FreeDays GetFreeDaysById(int id)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<FreeDays> GetAllPendingFreeDays()
        {
            // TODO: implement
            return null;
        }

        public FreeDays ApproveFreeDays(FreeDays freeDays)
        {
            // TODO: implement
            return null;
        }

        public FreeDays RejectFreeDays(FreeDays freeDays)
        {
            // TODO: implement
            return null;
        }

        public FreeDays AddFreeDays(FreeDays freeDays)
        {
            return this.freeDaysService.AddFreeDays(freeDays);
        }

        public Boolean DeleteFreeDaysById(int id)
        {
            // TODO: implement
            return false;
        }

        public FreeDaysService freeDaysService = new FreeDaysService(new FreeDaysRepository());

    }
}