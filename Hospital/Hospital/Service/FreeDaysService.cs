/***********************************************************************
 * Module:  FreeDaysService.cs
 * Author:  DELL
 * Purpose: Definition of the Class Hospital.Service.FreeDaysService
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.IRepository;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class FreeDaysService
    {
        private IFreeDaysRepo<FreeDays> freeDaysRepository;

        public FreeDaysService(IFreeDaysRepo<FreeDays> iFreeDaysRepo)
        {
            freeDaysRepository = iFreeDaysRepo;
        }
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
            return this.freeDaysRepository.Add(freeDays);
        }

        public Boolean DeleteFreeDaysById(int id)
        {
            // TODO: implement
            return false;
        }


    }
}