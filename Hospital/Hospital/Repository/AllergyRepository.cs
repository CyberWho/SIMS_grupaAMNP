/***********************************************************************
 * Module:  AllergyRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.AllergyRepository
 ***********************************************************************/

using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;

namespace Hospital.Repository
{
    /// GetAllergiesByTypeId vraca konkretno sve id-eve kartona koji su alergicni na to i to cije je id TypeId
    public class AllergyRepository
    {
        OracleConnection connection = null;
        UserRepository userRepository = new UserRepository();
        PatientRepository patientRepository = new PatientRepository();
        HealthRecordRepository healthRecordRepository = new HealthRecordRepository();

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
        public int GetLastId()
        {
            setConnection();

            int id = 0;
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT MAX(ID) FROM allergy";
            OracleDataReader reader = command.ExecuteReader();
            reader = command.ExecuteReader();
            reader.Read();
            id = int.Parse(reader.GetString(0));
            
            connection.Close();
            connection.Dispose();

            return id;
        }


        public ObservableCollection<Allergy> GetAllAllergiesByUserId(int userId)
        {
            setConnection();

            ObservableCollection<Allergy> allergies = new ObservableCollection<Allergy>();

            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM patient WHERE user_id = " + userId;
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();

            int patientId = int.Parse(reader.GetString(0));
            command.CommandText = "SELECT * FROM health_record WHERE patient_id = " + patientId;
            reader = command.ExecuteReader();
            reader.Read();

            int healthRecordId = int.Parse(reader.GetString(0));
            command.CommandText = "SELECT allergy_type.name FROM allergy, allergy_type WHERE allergy.allergy_type_id = allergy_type.id AND health_record_id = " + healthRecordId;
            reader = command.ExecuteReader();

            HealthRecord healthRecord = new HealthRecord();
            healthRecord.Id = healthRecordId;

            while (reader.Read())
            {
                Allergy allergy = new Allergy();
                AllergyType allergyType = new AllergyType();
                allergyType.Type = reader.GetString(0);
                allergy.allergyType = allergyType;

                allergies.Add(allergy);
            }

            connection.Close();
            connection.Dispose();

            return allergies;
        }

        public System.Collections.ArrayList GetAllergiesByTypeId(int allergyTypeId)
        {
            // TODO: implement
            return null;
        }

        public System.Collections.ArrayList GetAllAllergiesByHealthRecordId(int healthRecordId)
        {
            // TODO: implement
            return null;
        }
        public Boolean DeleteAllergyByUserIdAndAllergyTypeId(int userId, int atId)
        {
            setConnection();

            Patient patient = this.patientRepository.GetPatientByUserId(userId);
            HealthRecord healthRecord = this.healthRecordRepository.GetHealthRecordByPatientId(patient.Id);

            OracleCommand command = connection.CreateCommand();

            command.CommandText = "SELECT allergy.id FROM allergy, allergy_type WHERE allergy.allergy_type_id = " + atId + " AND health_record_id = " + healthRecord.Id;
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();

            int allergyId = int.Parse(reader.GetString(0));

            connection.Close();
            connection.Dispose();

            return this.DeleteAllergyById(allergyId);
        }

        public Boolean DeleteAllergyById(int id)
        {
            

            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM allergy WHERE id = " + id;

            if (cmd.ExecuteNonQuery() > 0)
            {
                connection.Close();
                connection.Dispose();
                return true;
            }

            connection.Close();
            connection.Dispose();

            return false;
        }

        public Boolean DeleteAllergiesByHealthRecordId(int healthRecordId)
        {
            // TODO: implement
            return false;
        }

        public Allergy UpdateAllergy(Allergy allergy)
        {
            // TODO: implement
            return null;
        }

        public Allergy NewAllergy(Allergy allergy)
        {
            setConnection();

            OracleCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO allergy (allergy_type_id, health_record_id) VALUES (:at_id, :hr_id)";

            command.Parameters.Add("at_id", OracleDbType.Int32).Value = allergy.allergy_type_id.ToString();
            command.Parameters.Add("hr_id", OracleDbType.Int32).Value = allergy.health_record_id.ToString();

            if (command.ExecuteNonQuery() > 0)
            {
                connection.Close();
                connection.Dispose();
                return allergy;
            }
            
            connection.Close();
            connection.Dispose();

            return null;
        }

        public Allergy GetAllergyById(int id)
        {
            // TODO: implement
            return null;
        }

        public System.Collections.ArrayList GetAllAllergies()
        {
            // TODO: implement
            return null;
        }

    }
}