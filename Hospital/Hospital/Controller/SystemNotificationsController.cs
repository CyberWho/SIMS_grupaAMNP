/***********************************************************************
 * Module:  Class20.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.Class20
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
    public class SystemNotificationsController
    {
        public SystemNotificationService systemNotificationService = new SystemNotificationService();

        public ObservableCollection<SystemNotification> GetAllSystemWideSystemNotifications()
        {
            return this.systemNotificationService.GetAllSystemWideSystemNotifications();
        }

        public SystemNotification GetSystemNotificationById(int id)
        {
            return this.systemNotificationService.GetSystemNotificationById(id);
        }

        public ObservableCollection<SystemNotification> GetAllSystemNotificationsByUserId(int userId)
        {
            return systemNotificationService.GetAllSystemNotificationsByUserId(userId);
        }

        public Boolean DeleteSystemNotificationById(int id)
        {
            return this.systemNotificationService.DeleteSystemNotificationById(id);
        }

        public Boolean DeleteAllSystemNotificationsByUserId(int userId)
        {
            // TODO: implement
            return false;
        }

        public SystemNotification UpdateSystemNotification(SystemNotification systemNotification)
        {
            return this.systemNotificationService.UpdateSystemNotification(systemNotification);
        }

        public SystemNotification AddSystemNotification(SystemNotification systemNotification)
        {
            return this.systemNotificationService.AddSystemNotification(systemNotification);
        }


    }
}