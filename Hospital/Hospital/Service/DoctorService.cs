/***********************************************************************
 * Module:  DoctorService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.DoctorService
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;

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

        public ObservableCollection<Doctor> GetAllGeneralPurposeDoctors()
        {
            ObservableCollection<Doctor> doctors = new ObservableCollection<Doctor>();
            doctors = doctorRepository.GetAllGeneralPurposeDoctors();
            return doctors;
        }
        public Boolean DeleteDoctorById(int doctorId)
        {
            // TODO: implement
            return false;
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            // TODO: implement
            return null;
        }

        public Doctor AddDoctor(Doctor doctor)
        {
            // TODO: implement
            return null;
        }

        public Repository.DoctorRepository doctorRepository = new Repository.DoctorRepository();

    }
}