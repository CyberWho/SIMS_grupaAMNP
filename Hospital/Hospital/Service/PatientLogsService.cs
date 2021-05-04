using System;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Service
{
    class PatientLogsService
    {
        public ObservableCollection<PatientLogs> GetAllPatientLogs()
        {
            // TODO: implement
            return null;
        }

        public PatientLogs GetPatientLogsById(int id)
        {
            // TODO: implement
            return null;
        }

        public PatientLogs GetPatientLogsByPatientId(int patientId)
        {
            
            return patientLogsRepository.GetPatientLogsByPatientId(patientId);
        }

        public PatientLogs UpdatePatientLogs(PatientLogs patientLogs)
        {
            // TODO: implement
            return null;
        }

        public Boolean ResetAllPatientLogs()
        {
            // TODO: implement
            return false;
        }
        public Boolean ResetPatientLogCounterByPatientId(int patientId)
        {
            return patientLogsRepository.ResetPatientLogCounterByPatientId(patientId);
        }

        public Boolean DeletePatientLogsByPatientId(int patientId)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeletePatientLogsById(int id)
        {
            // TODO: implement
            return false;
        }
        public Boolean IncrementLogCounterByPatientId(int patientId)
        {
            return patientLogsRepository.IncrementLogCounterByPatientId(patientId);
        }

        public Boolean AddPatientLogs(int patientId)
        {
            return patientLogsRepository.NewPatientLogs(patientId);
        }
        public Boolean CheckIfPatientIsBlockedByPatientId(int patientId)
        {
            return patientLogsRepository.CheckIfPatientIsBlockedByPatientId(patientId);
        }



        public Repository.PatientLogsRepository patientLogsRepository = new Repository.PatientLogsRepository();

    }
}
