/***********************************************************************
 * Module:  SystemNotificationRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.SystemNotificationRepository
 ***********************************************************************/

using Hospital.Model;
using System;

namespace Hospital.Repository
{
    public class SystemNotificationRepository
    {
        public Hospital.Model.SystemNotification GetSystemNotificationById(int id)
        {
            // TODO: implement
            return null;
        }

        public System.Collections.ArrayList GetAllSystemNotificationsByUserId(int userId)
        {
            // TODO: implement
            return null;
        }

        public Boolean DeleteSystemNotificationById(int id)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteAllSystemNotificationsByUserId(int userId)
        {
            // TODO: implement
            return false;
        }

        public Hospital.Model.SystemNotification UpdateSystemNotification(Hospital.Model.SystemNotification systemNotification)
        {
            // TODO: implement
            return null;
        }

        public SystemNotification NewSystemNotification(SystemNotification systemNotification)
        {




            return null;
        }

        public int GetLastId()
        {
            // TODO: implement
            return 0;
        }

    }
}