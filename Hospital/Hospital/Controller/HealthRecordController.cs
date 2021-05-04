/***********************************************************************
 * Module:  HealthRecordController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.HealthRecordController
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
    public class HealthRecordController
    {
        public HealthRecordService healthRecordService = new HealthRecordService();

        public HealthRecord GetHealthRecordById(int id)
        {
            // TODO: implement
            return null;
        }

        public HealthRecord GetHealthRecordByPatientId(int id)
        {
            return this.healthRecordService.GetHealthRecordByPatientId(id);
        }

        public ObservableCollection<HealthRecord> GetAllHealthRecords()
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