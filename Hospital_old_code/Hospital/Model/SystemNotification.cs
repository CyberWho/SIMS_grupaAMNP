/***********************************************************************
 * Module:  SystemNotification.cs
 * Author:  Dell
 * Purpose: Definition of the Class Bolnica.SystemNotification
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class SystemNotification
    {
        public String Name { get; set; }
        public String Description { get; set; }

        public System.Collections.ArrayList User;

        public System.Collections.ArrayList GetUser()
        {
            if (User == null)
                User = new System.Collections.ArrayList();
            return User;
        }

        public void SetUser(System.Collections.ArrayList newUser)
        {
            RemoveAllUser();
            foreach (User oUser in newUser)
                AddUser(oUser);
        }

        public void AddUser(User newUser)
        {
            if (newUser == null)
                return;
            if (this.User == null)
                this.User = new System.Collections.ArrayList();
            if (!this.User.Contains(newUser))
                this.User.Add(newUser);
        }

        public void RemoveUser(User oldUser)
        {
            if (oldUser == null)
                return;
            if (this.User != null)
                if (this.User.Contains(oldUser))
                    this.User.Remove(oldUser);
        }

        public void RemoveAllUser()
        {
            if (User != null)
                User.Clear();
        }

    }
}