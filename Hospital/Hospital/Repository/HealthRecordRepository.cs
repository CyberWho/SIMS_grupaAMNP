/***********************************************************************
 * Module:  HealthRecordRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.HealthRecordRepository
 ***********************************************************************/

using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.ObjectModel;
using Hospital.IRepository;

namespace Hospital.Repository
{
    public class HealthRecordRepository : IHealthRecordRepo<HealthRecord>
    {


            

        internal AbstractPatient insertAbstractHealthRecordData(AbstractPatient abstractUser)
        {
            int id = GetLastId() + 1;
            abstractUser.health_record_id = id;
            setConnection();

            OracleCommand command = connection.CreateCommand();

            command.CommandText = "INSERT INTO health_record (patient_id, gender_id, marital_status_id, birth_place_id) VALUES (:patient_id, :gender_id, :spec_id, :birth_place_id)";
            //command.Parameters.Add("id", OracleDbType.Int32).Value = abstractUser.health_record_id;
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = abstractUser.patient_id;
            command.Parameters.Add("gender_id", OracleDbType.Int32).Value = 0;
            command.Parameters.Add("marital_status_id", OracleDbType.Int32).Value = 0;
            command.Parameters.Add("birth_place_id", OracleDbType.Int32).Value = 0;


            if (command.ExecuteNonQuery() > 0)
            {
                connection.Close();
                connection.Dispose();

                return abstractUser;
            }
            connection.Close();
            connection.Dispose();

            return null;
        }

        public HealthRecord GetHealthRecordById(int id)
        {
            // TODO: implement
            return null;
        }

        public HealthRecord GetByPatientId(int patientId)
        {
            PatientRepository pr = new PatientRepository();
            UserRepository ur = new UserRepository();
            Patient p = pr.GetById(patientId);
            User u = ur.GetById(p.user_id);

            

            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM health_record WHERE patient_id = " + patientId;
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();

            HealthRecord healthRecord = new HealthRecord();

            PatientRepository patientRepository = new PatientRepository();
            UserRepository userRepository = new UserRepository();

            Patient patient = patientRepository.GetById(patientId);
            User user = userRepository.GetById(patient.user_id);
            patient.User = user;
            healthRecord.Id = int.Parse(reader.GetString(0));
            healthRecord.patient_id = int.Parse(reader.GetString(1));

            if (user.Username.Contains("guestUser"))
            {
                return healthRecord;
            }

            MaritalStatus maritalStatus = new MaritalStatus();

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


            healthRecord = new HealthRecord(int.Parse(reader.GetString(0)), gender,
                                                         maritalStatus, int.Parse(reader.GetString(4)));

            int record_id = int.Parse(reader.GetString(0));

            int city_id = int.Parse(reader.GetString(4));

            
            


            healthRecord.anamnesis = new AnamnesisRepository().GetAllByHealthRecordId(record_id);
            healthRecord.patient_id = patientId;
            healthRecord.Patient = patient;
            healthRecord.PlaceOfBirth = new CityRepository().GetById(city_id);
            healthRecord.Gender = gender;
            healthRecord.MaritalStatus = maritalStatus;
            



            return healthRecord;
        }

        public ObservableCollection<HealthRecord> GetAll()
        {
            // TODO: implement
            return null;
        }

        public Boolean DeleteById(int id)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteByPatientId(int patientId)
        {
            // TODO: implement
            return false;
        }

        public HealthRecord Update(HealthRecord healthRecord)
        {
            // TODO: implement
            return null;
        }

        public HealthRecord New(HealthRecord healthRecord, int guest = 0)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();

            int last_id = this.GetLastId() + 1;
            healthRecord.Id = last_id;

            if (guest == 1)
            {
                command.CommandText = "INSERT INTO health_record (patient_id) VALUES (:patient_id)";

                //command.Parameters.New("patientId", OracleDbType.Int32).Value = healthRecord.Id;
                command.Parameters.Add("patient_id", OracleDbType.Int32).Value = healthRecord.patient_id;

                if (command.ExecuteNonQuery() > 0)
                {
                    
                    

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

        public HealthRecord Add(HealthRecord t)
        {
            throw new NotImplementedException();
        }
    }
}