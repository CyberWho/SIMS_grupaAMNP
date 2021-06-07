/***********************************************************************
 * Module:  MedicalTreatment.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.MedicalTreatment
 ***********************************************************************/

using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.ObjectModel;
using Hospital.IRepository;
using Hospital.Model;

namespace Hospital.Repository
{
    public class MedicalTreatment : IMedicalTreatmentRepo<Model.MedicalTreatment>
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
        public Model.MedicalTreatment GetById(int id)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM medical_treatment WHERE id = " + id;
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();

            var medicalTreatment = ParseMedicalTreatment(reader);

            connection.Close();
            connection.Dispose();

            return medicalTreatment;
        }

        private static Model.MedicalTreatment ParseMedicalTreatment(OracleDataReader reader)
        {
           // Model.MedicalTreatment medicalTreatment = new Model.MedicalTreatment(reader.GetInt32(0),reader.GetInt32(1),reader.GetDateTime(2),
            //    reader.GetDateTime(3),reader.GetString(6),new DrugRepository().GetDrugById(reader.GetInt32(5)),new AnamnesisRepository().GetById(reader.GetInt32(4)));
            //kreiranje i vranjacanje isto za get by anam id isto tako i za perscription onda uraditi za anamnezu za karton
            Model.MedicalTreatment medicalTreatment = new Model.MedicalTreatment();
            medicalTreatment.Id = reader.GetInt32(0);
            medicalTreatment.Period = reader.GetInt32(1);
            medicalTreatment.dateRange.StartTime = reader.GetDateTime(2);
            medicalTreatment.dateRange.EndTime = reader.GetDateTime(3);
            medicalTreatment.Anamnesis_id = reader.GetInt32(4);
            medicalTreatment.Drug_id = reader.GetInt32(5);
            medicalTreatment.Drug = new DrugRepository().GetDrugById(reader.GetInt32(5));
            medicalTreatment.Description = reader.GetString(6);
            return medicalTreatment;
        }

        public ObservableCollection<Model.MedicalTreatment> GetAllByAnamnesisId(int anamnesisId)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "select * from medical_treatment where anamnesis_id = " + anamnesisId;
            OracleDataReader reader = command.ExecuteReader();
            ObservableCollection<Model.MedicalTreatment> medicalTreatments = new ObservableCollection<Model.MedicalTreatment>();

            //kreiranje i vranjacanje isto za get by anam id isto tako i za perscription onda uraditi za anamnezu za karton
            while (reader.Read())
            {
                var medicalTreatment = ParseMedicalTreatment(reader);
                medicalTreatments.Add(medicalTreatment);
            }

            connection.Close();
            connection.Dispose();
            
            return medicalTreatments;
        }

        public Boolean DeleteById(int id)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteAllByAnamnesisId(int anamnesisId)
        {
            // TODO: implement
            return false;
        }

        public Model.MedicalTreatment Update(Model.MedicalTreatment medicalTreatment)
        {
            // TODO: implement
            return null;
        }

        public Model.MedicalTreatment Add(Model.MedicalTreatment medicalTreatment)
        {
            // TODO: implement
            return null;
        }

        public int GetLastId()
        {
            // TODO: implement
            return 0;
        }

        public ObservableCollection<Model.MedicalTreatment> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}