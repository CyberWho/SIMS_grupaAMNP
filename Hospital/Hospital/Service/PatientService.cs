using System;
using Hospital.Model;
using System.Collections.ObjectModel;

namespace Hospital.Service
{
    public class PatientService
    {
        public Hospital.Model.Patient GetPatientById(int id)
        {
            return patientRepository.GetPatientById(id);
        }

        public Hospital.Model.Patient GetPatientByPatientId(int id)
        {
            Patient patient = this.patientRepository.GetPatientByPatientId(id);
            return patient;
        }
        public ObservableCollection<Patient> GetAllPatients()
        { 
            return patientRepository.GetAllPatients();
        }

        public System.Collections.ArrayList GetAllPatientsByDoctorId(int doctorId)
        {
            // TODO: implement
            return null;
        }

        public Boolean DeletePatientById(int id)
        {
            // TODO: implement
            return false;
        }

        public Hospital.Model.Patient UpdatePatient(Hospital.Model.Patient patient)
        {
            // TODO: implement
            return null;
        }

        public Hospital.Model.Patient RegisterPatient(Hospital.Model.Patient patient)
        {
            // TODO: implement
            return null;
        }

        public Hospital.Repository.PatientRepository patientRepository = new Repository.PatientRepository();

    }
}