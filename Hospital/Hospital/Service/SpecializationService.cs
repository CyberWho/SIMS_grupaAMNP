using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.IRepository;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    class SpecializationService
    {
        private ISpecializationRepo<Specialization> specializationRepository;

        public SpecializationService()
        {
            this.specializationRepository = new SpecializationRepository();
        }
        public ObservableCollection<Specialization> GetAllSpecializations(bool withoutGPD)
        {
            return this.specializationRepository.GetAll(withoutGPD);
        }
        public int GetSpecializationByType(string selectedSpecialization)
        {
            return this.specializationRepository.GetByType(selectedSpecialization);
        }
    }
}
