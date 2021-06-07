/***********************************************************************
 * Module:  AnamnesisRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.AnamnesisRepository
 ***********************************************************************/

using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Hospital.IRepository;

namespace Hospital.Repository
{
    public class AnamnesisRepository : IAnamnesisRepo<Anamnesis>
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
                Trace.WriteLine(exp.ToString());
            }
        }
        public Anamnesis GetById(int id)
        {

            //health record repo dopunjava jos anamnezu
            setConnection();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select * from anamnesis where id = " + id;
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            var anamnesis = ParseAnamnesis(reader);
            connection.Close();
            connection.Dispose();

            return anamnesis;
        }

        public ObservableCollection<Anamnesis> GetAllByHealthRecordId(int healthRecordId)
        {

            setConnection();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select * from anamnesis where health_record_id = " + healthRecordId;
            OracleDataReader reader = cmd.ExecuteReader();

            ObservableCollection<Anamnesis> anamneses = new ObservableCollection<Anamnesis>();

            while (reader.Read())
            {
                var anamnesis = ParseAnamnesis(reader);
                anamneses.Add(anamnesis);
            }

            connection.Close();
            connection.Dispose();

            return anamneses;
        }

        private static Anamnesis ParseAnamnesis(OracleDataReader reader)
        {
            Anamnesis anamnesis = new Anamnesis();
           
            anamnesis.Id = reader.GetInt32(0);
            anamnesis.Description = reader.GetString(1);
            anamnesis.MedicalTreatments = new MedicalTreatment().GetAllByAnamnesisId(reader.GetInt32(0));
            anamnesis.Perscriptions = new PerscriptionRepository().GetAllByAnamnesisId(reader.GetInt32(0));
            anamnesis.appointment = new AppointmentRepository().GetById(reader.GetInt32(3));
            return anamnesis;
        }

        public Boolean DeleteById(int id)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteAllByHealthRecordId(int healthRecordId)
        {
            // TODO: implement
            return false;
        }

        public Anamnesis Update(Anamnesis anamnesis)
        {
            setConnection();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE anamnesis SET Description = '" + anamnesis.Description +"' WHERE ID = " + anamnesis.Id;
            cmd.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();

            return null;
        }

        public Anamnesis Add(Anamnesis anamnesis)
        {
          
            setConnection();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = "insert into anamnesis(description, health_record_id, appointment_id) values('" + anamnesis.Description + "'," +  anamnesis.healthRecord.Id + "," + anamnesis.appointment.Id + ")";
            cmd.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();

            return null;
        }

        public int GetLastId()
        {
            // TODO: implement
            return 0;
        }

        public ObservableCollection<Anamnesis> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}