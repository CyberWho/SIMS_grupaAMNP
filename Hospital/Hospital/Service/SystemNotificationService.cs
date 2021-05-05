/***********************************************************************
 * Module:  SystemNotificationService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.SystemNotificationService
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class SystemNotificationService
    {
        public SystemNotificationRepository systemNotificationRepository = new SystemNotificationRepository();

        public ObservableCollection<SystemNotification> GetAllSystemWideSystemNotifications()
        {
            return this.systemNotificationRepository.GetAllSystemWideSystemNotifications();
        }



        public SystemNotification GetSystemNotificationById(int id)
        {
            return this.systemNotificationRepository.GetSystemNotificationById(id);
        }

        public System.Collections.ArrayList GetAllSystemNotificationsByUserId(int userId)
        {
            return systemNotificationRepository.GetAllSystemNotificationsByUserId(userId);
        }

        public Boolean DeleteSystemNotificationById(int id)
        {
            return this.systemNotificationRepository.DeleteSystemNotificationById(id);
        }

        public Boolean DeleteAllSystemNotificationsByUserId(int userId)
        {
            // TODO: implement
            return false;
        }

        public SystemNotification UpdateSystemNotification(SystemNotification systemNotification)
        {
            return this.systemNotificationRepository.UpdateSystemNotification(systemNotification);
        }

        public SystemNotification AddSystemNotification(SystemNotification systemNotification)
        {
            return this.systemNotificationRepository.NewSystemNotification(systemNotification);
        }


    }
}