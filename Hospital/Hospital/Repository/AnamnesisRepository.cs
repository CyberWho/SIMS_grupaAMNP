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

namespace Hospital.Repository
{
    public class AnamnesisRepository
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
                Trace.WriteLine(exp.ToString());
            }
        }
        public Anamnesis GetAnamnesisById(int id)
        {

            //health record repo dopunjava jos anamnezu
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from anamnesis where id = " + id;
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Anamnesis anamnesis = new Anamnesis();
            //anamnesis.appointment =
            anamnesis.Id = reader.GetInt32(0);
            anamnesis.Description = reader.GetString(1);
            anamnesis.MedicalTreatments = new MedicalTreatment().GetAllMedicalTreatmentsByAnamnesisId(id);
            anamnesis.Perscriptions = new PerscriptionRepository().GetAllPerscriptionsByAnamnesisId(id);
            return anamnesis;
        }

        public ObservableCollection<Anamnesis> GetAllAnamnesesByHealthRecordId(int healthRecordId)
        {

            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from anamnesis where health_record_id = " + healthRecordId;
            OracleDataReader reader = cmd.ExecuteReader();

            ObservableCollection<Anamnesis> anamneses = new ObservableCollection<Anamnesis>();

            while (reader.Read())
            {

                Anamnesis anamnesis = new Anamnesis();
                //anamnesis.appointment =
                anamnesis.Id = reader.GetInt32(0);
                anamnesis.Description = reader.GetString(1);
                anamnesis.MedicalTreatments = new MedicalTreatment().GetAllMedicalTreatmentsByAnamnesisId(reader.GetInt32(0));
                anamnesis.Perscriptions = new PerscriptionRepository().GetAllPerscriptionsByAnamnesisId(reader.GetInt32(0));
                anamnesis.appointment = new AppointmentRepository().GetAppointmentById(reader.GetInt32(3));
                anamneses.Add(anamnesis);
            }

            return anamneses;
        }

        public Boolean DeleteAnamnesisById(int id)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteAnamnesisByHealthRecordId(int healthRecordId)
        {
            // TODO: implement
            return false;
        }

        public Anamnesis UpdateAnamnesis(Anamnesis anamnesis)
        {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE anamnesis SET Description = '" + anamnesis.Description +"' WHERE ID = " + anamnesis.Id;
            cmd.ExecuteNonQuery();
            return null;
        }

        public Anamnesis NewAnamnesis(Anamnesis anamnesis)
        {
          
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "insert into anamnesis(description, health_record_id, appointment_id) values('" + anamnesis.Description + "'," +  anamnesis.healthRecord.Id + "," + anamnesis.appointment.Id + ")";
            cmd.ExecuteNonQuery();
            return null;
        }

        public int GetLastId()
        {
            // TODO: implement
            return 0;
        }

    }
}