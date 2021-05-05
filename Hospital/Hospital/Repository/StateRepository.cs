/***********************************************************************
 * Module:  StateRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.StateRepository
 ***********************************************************************/

using System;
using Oracle.ManagedDataAccess.Client;
using Hospital.Model;

namespace Hospital.Repository
{
    public class StateRepository
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
        public State GetStateById(int id)
      {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM STATE WHERE ID = :id";
            cmd.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            State state = new State();
            state.Id = reader.GetInt32(0);
            state.Name = reader.GetString(1);
            con.Close();
         return state;
      }
      
      public State GetStateByName(String name)
      {
         // TODO: implement
         return null;
      }
      
      public State NewState(State state)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAll()
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