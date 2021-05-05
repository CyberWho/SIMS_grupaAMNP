/***********************************************************************
 * Module:  SystemNotification.cs
 * Author:  Dell
 * Purpose: Definition of the Class Bolnica.SystemNotification
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;

namespace Hospital.Model
{
    public class SystemNotification
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public User user { get; set; }
        public int user_id { get; set; }

        // is false if the notification is created for only one user
        // otherwise its set to true, and then all users will get this notification
        public bool applicationWideNotification { get; set; }
        public DateTime creationDateTime { get; set; }
        public DateTime expirationDateTime { get; set; }


        public ObservableCollection<User> users;

        /// <pdGenerated>default getter</pdGenerated>
        public ObservableCollection<User> GetUser()
        {
            if (users == null)
                users = new ObservableCollection<User>();
            return users;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetUser(System.Collections.ArrayList newUser)
        {
            RemoveAllUser();
            foreach (User oUser in newUser)
                AddUser(oUser);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddUser(User newUser)
        {
            if (newUser == null)
                return;
            if (this.users == null)
                this.users = new ObservableCollection<User>();
            if (!this.users.Contains(newUser))
                this.users.Add(newUser);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveUser(User oldUser)
        {
            if (oldUser == null)
                return;
            if (this.users != null)
                if (this.users.Contains(oldUser))
                    this.users.Remove(oldUser);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllUser()
        {
            if (users != null)
                users.Clear();
        }

        public SystemNotification(int id, string name, string description, ObservableCollection<User> users)
        {
            Id = id;
            Name = name;
            Description = description;
            this.users = users;
        }
        public SystemNotification(int id, string name, string description, int userId)
        {
            Id = id;
            Name = name;
            Description = description;
            user_id = userId;
        }

        public SystemNotification(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public SystemNotification(int id, DateTime creationDateTime, DateTime expirationDateTime, string notificationName,
            string notificationDescription, bool applicationWideNotification)
        {
            this.Id = id;
            this.creationDateTime = creationDateTime;
            this.expirationDateTime = expirationDateTime;
            this.Name = notificationName;
            this.Description = notificationDescription;
            this.applicationWideNotification = applicationWideNotification;
        }


        public SystemNotification()
        {
        }


    }
}