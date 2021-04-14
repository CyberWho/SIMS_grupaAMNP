/***********************************************************************
 * Module:  UserService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.UserService
 ***********************************************************************/

using System;

namespace Hospital.Service
{
   public class UserService
   {
      public Hospital.Model.User RegisterUser(String username, String password)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.User Unguest(Hospital.Model.User user)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean IsValidUsername()
      {
         // TODO: implement
         return false;
      }
      
      public Boolean IsValidPassword()
      {
         // TODO: implement
         return false;
      }
      
      public Hospital.Model.User GetUserById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.User GetUserByUsername(String username)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllUsers()
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteUserById(int id)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean DeleteUserByUsername(String username)
      {
         // TODO: implement
         return false;
      }
      
      public Hospital.Model.User UpdateUser(Hospital.Model.User user)
      {
         // TODO: implement
         return null;
      }
   
      public Boolean IsGuest;
      public int MinPasswordLength;
      
      public Hospital.Repository.UserRepository userRepository;
   
   }
}