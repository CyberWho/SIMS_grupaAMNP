/***********************************************************************
 * Module:  MedicalTreatment.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.MedicalTreatment
 ***********************************************************************/

using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.ObjectModel;

namespace Hospital.Repository
{
    public class MedicalTreatment
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
        public Model.MedicalTreatment GetMedicalTreatmentById(int id)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM medical_treatment WHERE id = " + id;
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();

            Model.MedicalTreatment medicalTreatment = new Model.MedicalTreatment();
            //kreiranje i vranjacanje isto za get by anam id isto tako i za perscription onda uraditi za anamnezu za karton
            medicalTreatment.Id = reader.GetInt32(0);
            medicalTreatment.Period = reader.GetInt32(1);
            medicalTreatment.StartTime = reader.GetDateTime(2);
            medicalTreatment.EndTime = reader.GetDateTime(3);
            medicalTreatment.Anamnesis_id = reader.GetInt32(4);
            medicalTreatment.Drug_id = reader.GetInt32(5);
            medicalTreatment.Description = reader.GetString(6);

            connection.Close();
            connection.Dispose();

            return medicalTreatment;
        }

        public ObservableCollection<Model.MedicalTreatment> GetAllMedicalTreatmentsByAnamnesisId(int anamnesisId)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "select * from medical_treatment where anamnesis_id = " + anamnesisId;
            OracleDataReader reader = command.ExecuteReader();
            ObservableCollection<Model.MedicalTreatment> medicalTreatments = new ObservableCollection<Model.MedicalTreatment>();

            //kreiranje i vranjacanje isto za get by anam id isto tako i za perscription onda uraditi za anamnezu za karton
            while (reader.Read()) { 
                Model.MedicalTreatment medicalTreatment = new Model.MedicalTreatment();
                medicalTreatment.Id = reader.GetInt32(0);
                medicalTreatment.Period = reader.GetInt32(1);
                medicalTreatment.StartTime = reader.GetDateTime(2);
                medicalTreatment.EndTime = reader.GetDateTime(3);
                medicalTreatment.Anamnesis_id = reader.GetInt32(4);
                medicalTreatment.Drug_id = reader.GetInt32(5);
                medicalTreatment.Description = reader.GetString(6);
                medicalTreatments.Add(medicalTreatment);
            }

            connection.Close();
            connection.Dispose();
            
            return medicalTreatments;
        }

        public Boolean DeleteMedicalTreatmentById(int id)
        {
            // TODO: implement
            return false;
        }

        public Boolean DelelteAllMedicalTreatmentsByAnamnesisId(int anamnesisId)
        {
            // TODO: implement
            return false;
        }

        public Model.MedicalTreatment UpdateMedicalTreatment(Model.MedicalTreatment medicalTreatment)
        {
            // TODO: implement
            return null;
        }

        public Model.MedicalTreatment NewMedicalTreatment(Model.MedicalTreatment medicalTreatment)
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