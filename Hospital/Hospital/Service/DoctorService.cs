/***********************************************************************
 * Module:  DoctorService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.DoctorService
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class DoctorService
    {
        public Doctor GetDoctorById(int id)
        {
            return doctorRepository.GetDoctorById(id);
        }

        public Hospital.Model.Doctor GetDoctorByUserId(int id)
        {
            return doctorRepository.GetDoctorByUserId(id);
        }

        public Doctor GetWorkHoursDoctorById(int id)
        {
            Doctor doctor = new Doctor();
            doctor = doctorRepository.GetWorkHoursDoctorById(id);
            return doctor;
        }
        public ObservableCollection<Doctor> GetAllDoctors()
        {
            return doctorRepository.GetAllDoctors();
        }

        public ObservableCollection<Doctor> GetAllDoctorsBySpecializationId(int specializationId)
        {
            return this.doctorRepository.GetAllDoctorsBySpecializationId(specializationId);
        }

        public ObservableCollection<Doctor> searchDoctorByNameAndSurname(string identifyString)
        {
            return doctorRepository.SearchDoctorByNameAndSurname(identifyString);
        }
        public ObservableCollection<Doctor> GetAllGeneralPurposeDoctors()
        {
            ObservableCollection<Doctor> doctors = new ObservableCollection<Doctor>();
            doctors = doctorRepository.GetAllGeneralPurposeDoctors();
            return doctors;
        }
        #region marko_kt5
        public Boolean DeleteDoctorById(int doctorId)
        {
            Doctor doctor = this.doctorRepository.GetDoctorById(doctorId);
            
            int employee_id = this.employeesRepository.GetIdByDoctorId(doctorId);
            Employee employee = this.employeesRepository.GetById(employee_id);

            User user = this.userRepository.GetById(employee.User.Id);


            if (this.doctorRepository.DeleteDoctorById(doctorId) &&
                this.employeesRepository.DeleteById(employee_id) && 
                this.userRepository.DeleteById(user.Id))

                return true;

            return false;
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            return this.doctorRepository.UpdateDoctor(doctor);
        }

        private Doctor setSpecialization(Doctor doctor, string specialization)
        {
            if (doctor.specialization_id == 0)
            {
                doctor.specialization_id = this.specializationRepository.GetSpecializationByType(specialization);
            }

            return doctor;
        }
        public Doctor AddDoctor(Doctor doctor, string specialization)
        {
            doctor = setSpecialization(doctor, specialization);

            return this.doctorRepository.NewDoctor(doctor);
        }
        #endregion

        public SpecializationRepository specializationRepository = new SpecializationRepository();

        public DoctorRepository doctorRepository = new DoctorRepository();
        private EmployeesRepository employeesRepository = new EmployeesRepository();
        private UserRepository userRepository = new UserRepository();
    }
}