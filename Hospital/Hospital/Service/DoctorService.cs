/***********************************************************************
 * Module:  DoctorService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.DoctorService
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.IRepository;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class DoctorService
    {
        private IDoctorRepo<Doctor> doctorRepository;
        private IEmployeeRepo<Employee> employeesRepository;
        private IUserRepo<User> userRepository;
        private ISpecializationRepo<Specialization> specializationRepository;

        public DoctorService(IDoctorRepo<Model.Doctor> iDoctorRepo, IEmployeeRepo<Employee> iEmployeeRepo,
            IUserRepo<User> iUserRepo, ISpecializationRepo<Specialization> iSpecializationRepo)
        {
            this.doctorRepository = iDoctorRepo;
            this.employeesRepository = iEmployeeRepo;
            this.userRepository = iUserRepo;
            this.specializationRepository = iSpecializationRepo;
        }
        public Doctor GetDoctorById(int id)
        {
            return doctorRepository.GetById(id);
        }

        public Hospital.Model.Doctor GetDoctorByUserId(int id)
        {
            return doctorRepository.GetByUserId(id);
        }

        public Doctor GetWorkHoursDoctorById(int id)
        {
            Doctor doctor = new Doctor();
            doctor = doctorRepository.GetWorkHoursDoctorById(id);
            return doctor;
        }
        public ObservableCollection<Doctor> GetAllDoctors()
        {
            return doctorRepository.GetAll();
        }

        public ObservableCollection<Doctor> GetAllDoctorsBySpecializationId(int specializationId)
        {
            return this.doctorRepository.GetAllBySpecializationId(specializationId);
        }

        public ObservableCollection<Doctor> searchDoctorByNameAndSurname(string identifyString)
        {
            return doctorRepository.SearchByNameAndSurname(identifyString);
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
            Doctor doctor = this.doctorRepository.GetById(doctorId);
            
            int employee_id = this.employeesRepository.GetIdByDoctorId(doctorId);
            Employee employee = this.employeesRepository.GetById(employee_id);

            User user = this.userRepository.GetById(employee.User.Id);


            if (this.doctorRepository.DeleteById(doctorId) &&
                this.employeesRepository.DeleteById(employee_id) && 
                this.userRepository.DeleteById(user.Id))

                return true;

            return false;
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            return this.doctorRepository.Update(doctor);
        }

        private Doctor setSpecialization(Doctor doctor, string specialization)
        {
            if (doctor.specialization_id == 0)
            {
                doctor.specialization_id = this.specializationRepository.GetByType(specialization);
            }

            return doctor;
        }
        public Doctor AddDoctor(Doctor doctor, string specialization)
        {
            doctor = setSpecialization(doctor, specialization);

            return this.doctorRepository.Add(doctor);
        }
        #endregion


    }
}