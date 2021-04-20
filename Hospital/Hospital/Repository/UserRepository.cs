/***********************************************************************
 * Module:  UserRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.UserRepository
 ***********************************************************************/

using System;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using Hospital.Model;

namespace Hospital.Repository
{
   public class UserRepository
   {
        OracleConnection con = null;
        

        private void setConnection()
        {
            String conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            con = new OracleConnection(conString);
            try
            {
                con.Open();

            }
            catch (Exception exp)
            {

            }
        }
        public Hospital.Model.User GetUserById(int id)
      {
            
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
      
      public Hospital.Model.User NewUser(Hospital.Model.User user)
      {
         // TODO: implement
         return null;
      }
      
      public int GetLastId()
      {
         // TODO: implement
         return 0;
      }
   
   }
}