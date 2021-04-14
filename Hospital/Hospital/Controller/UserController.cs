/***********************************************************************
 * Module:  UserController.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Controller.UserController
 ***********************************************************************/

using System;

namespace Hospital.Controller
{
   public class UserController
   {
      public Hospital.Model.User RegisterUser(String username, String password)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.User LoginUser(String username, String password)
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Service.UserService userService;
      public Hospital.Service.SystemNotificationService systemNotificationService;
   
   }
}