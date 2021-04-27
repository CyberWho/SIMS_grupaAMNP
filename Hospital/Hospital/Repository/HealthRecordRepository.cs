/***********************************************************************
 * Module:  HealthRecordRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.HealthRecordRepository
 ***********************************************************************/

using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Hospital.Repository
{
    public class HealthRecordRepository
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

        public HealthRecord GetHealthRecordById(int id)
        {
            // TODO: implement
            return null;
        }

        public HealthRecord GetHealthRecordByPatientId(int id)
        {
            setConnection();

            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM health_record WHERE patient_id = " + id;
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();

            HealthRecord healthRecord = new HealthRecord();

            PatientRepository patientRepository = new PatientRepository();
            UserRepository userRepository = new UserRepository();

            Patient patient = patientRepository.GetPatientById(id);
            User user = userRepository.GetUserById(patient.user_id);
            patient.User = user;
            healthRecord.Id = int.Parse(reader.GetString(0));
            healthRecord.patient_id = int.Parse(reader.GetString(1));

            if (user.Username.Contains("guestUser"))
            {
                return healthRecord;
            }

            MaritalStatus maritalStatus = MaritalStatus.MARRIED;

            switch (int.Parse(reader.GetString(3)))
            {
                case 0:
                    maritalStatus = MaritalStatus.MARRIED;
                    break;
                case 1:
                    maritalStatus = MaritalStatus.NOTMARRIED;
                    break;
                case 2:
                    maritalStatus = MaritalStatus.DIVORCED;
                    break;
                case 3:
                    maritalStatus = MaritalStatus.WIDOW;
                    break;
            }

            Gender gender = Gender.MALE;
            switch (int.Parse(reader.GetString(3)))
            {
                case 0:
                    gender = Gender.MALE;
                    break;
                case 1:
                    gender = Gender.FEMALE;
                    break;
            }

            /*healthRecord.gender_id = int.Parse(reader.GetString(2));
            healthRecord.marital_status_id = int.Parse(reader.GetString(3));
            healthRecord.birth_place_id = int.Parse(reader.GetString(4));   */
            healthRecord = new HealthRecord(int.Parse(reader.GetString(0)), gender,
                                                         maritalStatus, int.Parse(reader.GetString(4)));
            healthRecord.anamnesis = new AnamnesisRepository().GetAllAnamnesesByHealthRecordId(reader.GetInt32(0));
            healthRecord.patient_id = id;
            healthRecord.Patient = patient;
            healthRecord.PlaceOfBirth = new CityRepository().GetCityById(reader.GetInt32(4));
            connection.Close();
            


            return healthRecord;
        }

        public System.Collections.ArrayList GetAllHealthRecords()
        {
            // TODO: implement
            return null;
        }

        public Boolean DeleteHealthRecordById(int id)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteHealthRecordByPatientId(int patientId)
        {
            // TODO: implement
            return false;
        }

        public HealthRecord UpdateHealthRecord(HealthRecord healthRecord)
        {
            // TODO: implement
            return null;
        }

        public HealthRecord NewHealthRecord(HealthRecord healthRecord, int guest = 0)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();

            int last_id = this.GetLastId() + 1;
            healthRecord.Id = last_id;

            if (guest == 1)
            {
                command.CommandText = "INSERT INTO health_record (patient_id) VALUES (:patient_id)";

                //command.Parameters.Add("id", OracleDbType.Int32).Value = healthRecord.Id;
                command.Parameters.Add("patient_id", OracleDbType.Int32).Value = healthRecord.patient_id;

                if (command.ExecuteNonQuery() > 0)
                {
                    connection.Close();
                    return healthRecord;
                }
            }
            else
            {

            }

            return null;
        }

        public int GetLastId()
        {
            // TODO: implement
            return 0;
        }

    }
}