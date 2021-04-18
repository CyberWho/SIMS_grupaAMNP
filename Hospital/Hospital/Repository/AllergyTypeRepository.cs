/***********************************************************************
 * Module:  AllergyTypeRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.AllergyTypeRepository
 ***********************************************************************/

using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.ObjectModel;

namespace Hospital.Repository
{
    public class AllergyTypeRepository
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


        public ObservableCollection<AllergyType> GetAllTypesByUserId(int userId)
        {
            setConnection();

            // trazim pacijenta sa user id-em userId, 
            // trazim karton sa pacijent id-em koji sam dobio gore
            // trazim sve alergije iz kartona na osnovu karton id-a koji sam dobio gore
            // trazim sve tipove alergija na osnovu alergija koje korisnik ima
            ObservableCollection<AllergyType> allergyTypes = new ObservableCollection<AllergyType>();

            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM patient WHERE user_id = " + userId;
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();

            int patientId = int.Parse(reader.GetString(0));
            command.CommandText = "SELECT * FROM health_record WHERE patient_id = " + patientId;
            reader = command.ExecuteReader();
            reader.Read();

            int healthRecordId = int.Parse(reader.GetString(0));
            command.CommandText = "SELECT allergy_type.id, allergy_type.name FROM allergy, allergy_type WHERE allergy.allergy_type_id = allergy_type.id AND health_record_id = " + healthRecordId;
            reader = command.ExecuteReader();

            HealthRecord healthRecord = new HealthRecord();
            healthRecord.Id = healthRecordId;

            while (reader.Read())
            {
                // MessageBox.Show(reader.GetString(0));

                AllergyType allergyType = new AllergyType();
                allergyType.Id = int.Parse(reader.GetString(0));
                allergyType.Type = reader.GetString(1);

                allergyTypes.Add(allergyType);
            }

            connection.Close();
            connection.Dispose();


            return allergyTypes;
        }


        public System.Collections.ArrayList GetAllAllergyTypes()
        {
            // TODO: implement
            return null;
        }

        public Boolean DeleteAllergieTypeById(int id)
        {
            // TODO: implement
            return false;
        }

        public Hospital.Model.AllergyType UpdateAllergyType(int allergyType)
        {
            // TODO: implement
            return null;
        }

        public Hospital.Model.AllergyType NewAllergyType(Hospital.Model.AllergyType allergyType)
        {
            // TODO: implement
            return null;
        }

        public int GetLastId()
        {
            // TODO: implement
            return 0;
        }

        public Hospital.Model.AllergyType GetAllergyTypeById(int id)
        {
            setConnection();

            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM allergy_type WHERE id = " + id;
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();

            AllergyType at = new AllergyType
            {
                Id = int.Parse(reader.GetString(0)),
                Type = reader.GetString(1)
            };

            connection.Close();
            connection.Dispose();

            return at;
        }

    }
}