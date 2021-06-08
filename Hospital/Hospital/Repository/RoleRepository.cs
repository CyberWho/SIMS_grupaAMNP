/***********************************************************************
 * Module:  RoleRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.RoleRepository
 ***********************************************************************/

using System;
using Oracle.ManagedDataAccess.Client;
using Hospital.Model;
using System.Diagnostics;

namespace Hospital.Repository
{
    public class RoleRepository
   {
       

       private void setConnection()
       {
           String conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
           Globals.globalConnection = new OracleConnection(conString);
           try
           {
               Globals.globalConnection.Open();

           }
           catch (Exception exp)
           {
               Trace.WriteLine(exp.ToString());
           }
       }
        public Model.Role GetRoleById(int id)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM ROLE WHERE ID = :id";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            Role role = new Role(reader.GetInt32(0), reader.GetString(1));
            
            return role;
        }
      
      public Model.Role GetRoleByRole(String role)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllRoles()
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteRoleById(int id)
      {
         // TODO: implement
         return false;
      }
      
      public Model.Role UpdateRole(Model.Role role)
      {
         // TODO: implement
         return null;
      }
      
      public Model.Role NewRole(Model.Role role)
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