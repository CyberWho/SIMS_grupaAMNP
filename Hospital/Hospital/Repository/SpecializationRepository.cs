using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.IRepository;
using Hospital.Model;
using Oracle.ManagedDataAccess.Client;

namespace Hospital.Repository
{
    public class SpecializationRepository : ISpecializationRepo<Specialization>
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

            }
        }

        private ObservableCollection<Specialization> specializations;

        public ObservableCollection<Specialization> GetAll(bool withoutGPD)
        {
            
            specializations = new ObservableCollection<Specialization>();

            // id of general specialization is 1, and for urgent appointments it is not necessary to pull that data among other
            int generalSpecialization = 1;

            OracleCommand command = Globals.globalConnection.CreateCommand();

            if (withoutGPD)
            {
                command.CommandText = "SELECT * FROM specialization WHERE id != " + generalSpecialization;

            }
            else
            {
                command.CommandText = "SELECT * FROM specialization";
            }
            OracleDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = int.Parse(reader.GetString(0));
                string type = reader.GetString(1);

                Specialization specialization = new
                    Specialization(
                        id,
                        type
                    );
                
                specializations.Add(specialization);
            }

            
            

            return specializations;
        }

        public int GetByType(string type)
        {
            

            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM specialization WHERE spectype LIKE '" + type + "'";
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();

            int id = int.Parse(reader.GetString(0));

            
            

            return id;
        }

        public Specialization GetById(int id)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM SPECIALIZATION WHERE ID = :id";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            Specialization specialization = new Specialization(reader.GetInt32(0), reader.GetString(1));
            
            
            return specialization;
        }

        public ObservableCollection<Specialization> GetAll()
        {
            throw new NotImplementedException();
        }

        public Specialization Add(Specialization t)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Specialization Update(Specialization t)
        {
            throw new NotImplementedException();
        }

        public int GetLastId()
        {
            throw new NotImplementedException();
        }
    }
}
