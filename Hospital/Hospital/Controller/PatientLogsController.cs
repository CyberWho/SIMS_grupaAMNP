using System;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Controller
{
    class PatientLogsController
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
          
            return patientLogsService.GetPatientLogsByPatientId(patientId);
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
            return patientLogsService.ResetPatientLogCounterByPatientId(patientId);
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
            return patientLogsService.IncrementLogCounterByPatientId(patientId);
        }
        public Boolean CheckIfPatientIsBlockedByPatientId(int patientId)
        {
            return patientLogsService.CheckIfPatientIsBlockedByPatientId(patientId);
        }

        public Boolean AddPatientLogs(int patientId)
        {
            return patientLogsService.AddPatientLogs(patientId);
        }

       

        public Service.PatientLogsService patientLogsService = new Service.PatientLogsService();

    }
}
