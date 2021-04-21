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
        public Hospital.Model.MedicalTreatment GetMedicalTreatmentById(int id)
        {
            setConnection();
            OracleCommand command = con.CreateCommand();
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

            return medicalTreatment;
        }

        public ObservableCollection<Model.MedicalTreatment> GetAllMedicalTreatmentsByAnamnesisId(int anamnesisId)
        {
            setConnection();
            OracleCommand command = con.CreateCommand();
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
            con.Close();
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

        public Hospital.Model.MedicalTreatment UpdateMedicalTreatment(Hospital.Model.MedicalTreatment medicalTreatment)
        {
            // TODO: implement
            return null;
        }

        public Hospital.Model.MedicalTreatment NewMedicalTreatment(Hospital.Model.MedicalTreatment medicalTreatment)
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