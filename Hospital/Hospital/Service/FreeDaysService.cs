/***********************************************************************
 * Module:  FreeDaysService.cs
 * Author:  DELL
 * Purpose: Definition of the Class Hospital.Service.FreeDaysService
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class FreeDaysService
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
            return this.freeDaysRepository.AddFreeDays(freeDays);
        }

        public Boolean DeleteFreeDaysById(int id)
        {
            // TODO: implement
            return false;
        }

        public FreeDaysRepository freeDaysRepository = new FreeDaysRepository();

    }
}