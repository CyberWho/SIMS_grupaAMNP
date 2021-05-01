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
        public Hospital.Model.Doctor GetDoctorById(int id)
        {
            // TODO: implement
            return null;
        }

        public Doctor GetWorkHoursDoctorById(int id)
        {
            Doctor doctor = new Doctor();
            doctor = doctorRepository.GetWorkHoursDoctorById(id);
            return doctor;
        }
        public System.Collections.ArrayList GetAllDoctors()
        {
            // TODO: implement
            return null;
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

        public Hospital.Model.Doctor UpdateDoctor(Hospital.Model.Doctor doctor)
        {
            // TODO: implement
            return null;
        }

        public Hospital.Model.Doctor AddDoctor(Hospital.Model.Doctor doctor)
        {
            // TODO: implement
            return null;
        }

        public Hospital.Repository.DoctorRepository doctorRepository = new Repository.DoctorRepository();

    }
}