﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    class SpecializationService
    {
        private SpecializationRepository specializationRepository = new SpecializationRepository();

        public ObservableCollection<Specialization> GetAllSpecializations(bool withoutGPD)
        {
            return this.specializationRepository.GetAllSpecializations(withoutGPD);
        }
        public int GetSpecializationByType(string selectedSpecialization)
        {
            return this.specializationRepository.GetSpecializationByType(selectedSpecialization);
        }
    }
}
