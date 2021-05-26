using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Oracle.ManagedDataAccess.Client;

namespace Hospital.Repository
{
    public class SpecializationRepository
    {

        OracleConnection connection = null;
        private void setConnection()
        {
            String conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            connection = new OracleConnection(conString);
            try
            {
                connection.Open();
            }
            catch (Exception exp)
            {

            }
        }

        private ObservableCollection<Specialization> specializations;

        public ObservableCollection<Specialization> GetAllSpecializations(bool withoutGPD)
        {
            setConnection();
            specializations = new ObservableCollection<Specialization>();

            // id of general specialization is 1, and for urgent appointments it is not necessary to pull that data among other
            int generalSpecialization = 1;

            OracleCommand command = connection.CreateCommand();

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

            connection.Close();
            connection.Dispose();

            return specializations;
        }

        public int GetSpecializationByType(string type)
        {
            setConnection();

            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM specialization WHERE spectype LIKE '" + type + "'";
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();

            int id = int.Parse(reader.GetString(0));

            connection.Close();
            connection.Dispose();

            return id;
        }

        public Specialization GetSpecializationById(int id)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM SPECIALIZATION WHERE ID = :id";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            Specialization specialization = new Specialization(reader.GetInt32(0), reader.GetString(1));
            connection.Close();
            
            return specialization;
        }


    }
}
