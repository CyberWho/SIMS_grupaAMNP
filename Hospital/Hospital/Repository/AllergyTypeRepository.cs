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
using Hospital.IRepository;

namespace Hospital.Repository
{
    public class AllergyTypeRepository : IAllergyTypeRepo<AllergyType>
    {
        UserRepository userRepository = new UserRepository();
        PatientRepository patientRepository = new PatientRepository();
        HealthRecordRepository healthRecordRepository = new HealthRecordRepository();


        public ObservableCollection<AllergyType> GetAll()
        {
            // TODO: implement
            return null;
        }



        public Boolean DeleteById(int id)
        {
            // TODO: implement
            return false;
        }

        public AllergyType Update(AllergyType allergyType)
        {
            // TODO: implement
            return null;
        }

        public AllergyType Add(AllergyType allergyType)
        {
            // TODO: implement
            return null;
        }

        public int GetLastId()
        {
            // TODO: implement
            return 0;
        }

        public AllergyType GetByType(string type)
        {

            AllergyType at = new AllergyType();
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM allergy_type WHERE name LIKE '" + type + "'";
            //////////////////////////////////////////////////////////////////////////
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();

            at.Id = int.Parse(reader.GetString(0));
            at.Type = reader.GetString(1);

            return at;
        }

        public ObservableCollection<AllergyType> GetAllMissingTypesByUserId(int userId)
        {


            ObservableCollection<AllergyType> allergyTypes = new ObservableCollection<AllergyType>();

            OracleCommand command = Globals.globalConnection.CreateCommand();

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

 

            return allergyTypes;
        }

        public AllergyType GetById(int id)
        {

            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM allergy_type WHERE id = " + id;
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();

            AllergyType allergyType = new AllergyType(reader.GetInt32(0), reader.GetString(1));


            return allergyType;
        }
        public ObservableCollection<AllergyType> GetAllByHealthRecordId(int id)
        {

            ObservableCollection<AllergyType> allergyTypes = new ObservableCollection<AllergyType>();

            OracleCommand command = Globals.globalConnection.CreateCommand();

            command.CommandText = "SELECT allergy_type.id, allergy_type.name FROM allergy, allergy_type WHERE allergy.allergy_type_id = allergy_type.id AND health_record_id = " + id;
            OracleDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                AllergyType allergyType = new AllergyType();
                allergyType.Id = int.Parse(reader.GetString(0));
                allergyType.Type = reader.GetString(1);

                allergyTypes.Add(allergyType);
            }


            return allergyTypes;
        }

    }
}