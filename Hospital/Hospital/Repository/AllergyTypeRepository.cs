/***********************************************************************
 * Module:  AllergyTypeRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.AllergyTypeRepository
 ***********************************************************************/

using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Hospital.Repository
{
    public class AllergyTypeRepository
    {
        UserRepository userRepository = new UserRepository();
        PatientRepository patientRepository = new PatientRepository();
        HealthRecordRepository healthRecordRepository = new HealthRecordRepository();

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

        public AllergyType UpdateAllergyType(int allergyType)
        {
            // TODO: implement
            return null;
        }

        public AllergyType NewAllergyType(AllergyType allergyType)
        {
            // TODO: implement
            return null;
        }

        public int GetLastId()
        {
            // TODO: implement
            return 0;
        }

        public AllergyType GetAllergyTypeByType(string type)
        {
            setConnection();

            AllergyType at = new AllergyType();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM allergy_type WHERE name LIKE '" + type + "'";
            //////////////////////////////////////////////////////////////////////////
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();

            at.Id = int.Parse(reader.GetString(0));
            at.Type = reader.GetString(1);

            return at;
        }

        public ObservableCollection<AllergyType> GetAllMissingAllergyTypesByUserId(int userId)
        {
            setConnection();

            /////////////////////////////////////////////////////////////////////////////////////
            /// ispraviti ovo gore
            /////////////////////////////////////////////////////////////////////////////////////

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
            command.CommandText = "SELECT * FROM allergy_type MINUS SELECT allergy_type.id, allergy_type.name FROM allergy, allergy_type WHERE allergy.allergy_type_id = allergy_type.id AND health_record_id = " + healthRecordId;
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                AllergyType allergyType = new AllergyType();
                allergyType.Id = int.Parse(reader.GetString(0));
                allergyType.Type = reader.GetString(1);

                allergyTypes.Add(allergyType);
            }

            connection.Close();
            connection.Dispose();

            return allergyTypes;
        }

        public AllergyType GetAllergyTypeById(int id)
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
        public ObservableCollection<AllergyType> GetAllTypesByHealthRecordId(int id)
        {
            setConnection();

            ObservableCollection<AllergyType> allergyTypes = new ObservableCollection<AllergyType>();

            OracleCommand command = connection.CreateCommand();

            command.CommandText = "SELECT allergy_type.id, allergy_type.name FROM allergy, allergy_type WHERE allergy.allergy_type_id = allergy_type.id AND health_record_id = " + id;
            OracleDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                AllergyType allergyType = new AllergyType();
                allergyType.Id = int.Parse(reader.GetString(0));
                allergyType.Type = reader.GetString(1);

                allergyTypes.Add(allergyType);
            }

            connection.Close();
            connection.Dispose();

            return allergyTypes;
        }

    }
}