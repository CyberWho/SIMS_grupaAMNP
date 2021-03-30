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
      public String Name;
      public String Description;
      
      public System.Collections.ArrayList user;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetUser()
      {
         if (user == null)
            user = new System.Collections.ArrayList();
         return user;
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
         if (this.user == null)
            this.user = new System.Collections.ArrayList();
         if (!this.user.Contains(newUser))
            this.user.Add(newUser);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveUser(User oldUser)
      {
         if (oldUser == null)
            return;
         if (this.user != null)
            if (this.user.Contains(oldUser))
               this.user.Remove(oldUser);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllUser()
      {
         if (user != null)
            user.Clear();
      }
   
   }
}