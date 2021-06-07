/***********************************************************************
 * Module:  StateRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.StateRepository
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.IRepository;
using Oracle.ManagedDataAccess.Client;
using Hospital.Model;

namespace Hospital.Repository
{
    public class StateRepository : IStateRepo<State>
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
        public State GetById(int id)
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
        
      public State Add(State state)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<State> GetAll()
      {
         // TODO: implement
         return null;
      }
      
      public int GetLastId()
      {
         // TODO: implement
         return 0;
      }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public State Update(State t)
        {
            throw new NotImplementedException();
        }
    }
}