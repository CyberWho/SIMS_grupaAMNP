/***********************************************************************
 * Module:  HealthRecordService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.HealthRecordService
 ***********************************************************************/

using Hospital.Model;
using Hospital.Repository;
using System;

namespace Hospital.Service
{
    public class HealthRecordService
    {
        public HealthRecordRepository healthRecordRepository = new HealthRecordRepository();

        public HealthRecord GetHealthRecordById(int id)
        {
            // TODO: implement
            return null;
        }

        public HealthRecord GetHealthRecordByPatientId(int id)
        {
            return this.healthRecordRepository.GetHealthRecordByPatientId(id);
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

        public HealthRecord AddHealthRecord(HealthRecord healthRecord)
        {
            // TODO: implement
            return null;
        }

        public HealthRecord AddAllergiesToHealthRecord(HealthRecord healthRecord, Allergy allergy)
        {
            // TODO: implement
            return null;
        }


    }
}