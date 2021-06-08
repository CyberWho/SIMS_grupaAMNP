/***********************************************************************
 * Module:  AllergyRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.AllergyRepository
 ***********************************************************************/

using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Hospital.IRepository;

namespace Hospital.Repository
{
    /// GetAllByTypeId vraca konkretno sve id-eve kartona koji su alergicni na to i to cije je id TypeId
    public class AllergyRepository : IAllergyRepo<Allergy>
    {
        UserRepository userRepository = new UserRepository();
        PatientRepository patientRepository = new PatientRepository();
        HealthRecordRepository healthRecordRepository = new HealthRecordRepository();

        public int GetLastId()
        {
            

            int id = 0;
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT MAX(ID) FROM allergy";
            OracleDataReader reader = command.ExecuteReader();
            reader = command.ExecuteReader();
            reader.Read();
            id = int.Parse(reader.GetString(0));
            
            
            

            return id;
        }


        public ObservableCollection<Allergy> GetAllByUserId(int userId)
        {
            

            ObservableCollection<Allergy> allergies = new ObservableCollection<Allergy>();

            OracleCommand command = Globals.globalConnection.CreateCommand();
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
                var allergy = ParseAllergy(reader);
                allergies.Add(allergy);
            }

            
            

            return allergies;
        }

        public ObservableCollection<Allergy> GetAllByTypeId(int allergyTypeId)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Allergy> GetAllByHealthRecordId(int healthRecordId)
        {
            
            ObservableCollection<Allergy> allergies = new ObservableCollection<Allergy>();
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM ALLERGY WHERE HEALTH_RECORD_ID = :health_record_id";
            command.Parameters.Add("health_record_id", OracleDbType.Int32).Value = healthRecordId.ToString();
            OracleDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                var allergy = ParseAllergy(reader);
                allergies.Add(allergy);
            }
            
            return allergies;
        }

        private static Allergy ParseAllergy(OracleDataReader reader)
        {
            HealthRecord healthRecord = new HealthRecordRepository().GetById(reader.GetInt32(2));
            Allergy allergy = new Allergy(reader.GetInt32(0),new AllergyTypeRepository().GetById(reader.GetInt32(1)),healthRecord);
            return allergy;
        }

        public Boolean DeleteByUserIdAndAllergyTypeId(int userId, int atId)
        {
            

            Patient patient = this.patientRepository.GetByUserId(userId);
            HealthRecord healthRecord = this.healthRecordRepository.GetByPatientId(patient.Id);

            OracleCommand command = Globals.globalConnection.CreateCommand();

            command.CommandText = "SELECT allergy.id FROM allergy, allergy_type WHERE allergy.allergy_type_id = " + atId + " AND health_record_id = " + healthRecord.Id;
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();

            int allergyId = int.Parse(reader.GetString(0));

            
            

            return this.DeleteById(allergyId);
        }

        public Boolean DeleteById(int id)
        {
            OracleCommand cmd = Globals.globalConnection.CreateCommand();
            cmd.CommandText = "DELETE FROM allergy WHERE id = " + id;

            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            return false;
        }

        public Boolean DeleteAllByHealthRecordId(int healthRecordId)
        {
            // TODO: implement
            return false;
        }

        public Allergy Update(Allergy allergy)
        {
            // TODO: implement
            return null;
        }

        public Allergy Add(Allergy allergy)
        {
            

            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "INSERT INTO allergy (allergy_type_id, health_record_id) VALUES (:at_id, :hr_id)";

            command.Parameters.Add("at_id", OracleDbType.Int32).Value = allergy.allergy_type_id.ToString();
            command.Parameters.Add("hr_id", OracleDbType.Int32).Value = allergy.health_record_id.ToString();

            if (command.ExecuteNonQuery() > 0)
            {
                return allergy;
            }
            return null;
        }

        public Allergy GetById(int id)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Allergy> GetAll()
        {
            // TODO: implement
            return null;
        }

    }
}