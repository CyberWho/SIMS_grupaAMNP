using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Hospital.Model.PatientLogs GetPatientLogsById(int id)
        {
            // TODO: implement
            return null;
        }

        public Hospital.Model.PatientLogs GetPatientLogsByPatientId(int patientId)
        {
            
            return patientLogsRepository.GetPatientLogsByPatientId(patientId);
        }

        public Hospital.Model.PatientLogs UpdatePatientLogs(Hospital.Model.PatientLogs patientLogs)
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

        public Hospital.Model.PatientLogs AddPatientLogs()
        {
            // TODO: implement
            return null;
        }
        public Boolean CheckIfPatientIsBlockedByPatientId(int patientId)
        {
            return patientLogsRepository.CheckIfPatientIsBlockedByPatientId(patientId);
        }



        public Hospital.Repository.PatientLogsRepository patientLogsRepository = new Repository.PatientLogsRepository();

    }
}
