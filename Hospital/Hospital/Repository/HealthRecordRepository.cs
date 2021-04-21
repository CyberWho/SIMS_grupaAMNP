/***********************************************************************
 * Module:  HealthRecordRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.HealthRecordRepository
 ***********************************************************************/

using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.ObjectModel;

namespace Hospital.Repository
{
    public class HealthRecordRepository
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
        public Hospital.Model.HealthRecord GetHealthRecordById(int id)
        {
            return null;
        }

        public Hospital.Model.HealthRecord GetHealthRecordByPatientId(int patientId)
        {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from health_record where health_record.PATIENT_ID = " + patientId;
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
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

            HealthRecord healthRecord = new HealthRecord(int.Parse(reader.GetString(0)), gender,
                                                         maritalStatus, int.Parse(reader.GetString(4)));

            //cmd.CommandText = "select * from health_record, anamnesis where anamnesis.HEALTH_RECORD_ID = health_record.ID and health_record.PATIENT_ID = " + patientId;
            //reader = cmd.ExecuteReader();

            
            healthRecord.anamnesis = new AnamnesisRepository().GetAllAnamnesesByHealthRecordId(reader.GetInt32(0));
            healthRecord.patient_id = patientId;


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

        public Hospital.Model.HealthRecord UpdateHealthRecord(Hospital.Model.HealthRecord healthRecord)
        {
            // TODO: implement
            return null;
        }

        public Hospital.Model.HealthRecord NewHealthRecord(Hospital.Model.HealthRecord healthRecord)
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