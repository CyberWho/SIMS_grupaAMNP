using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
    class SpecializationContoller
    {
        private SpecializationService specializationService = new SpecializationService();

        public ObservableCollection<Specialization> GetAllSpecializations(bool withoutGPD = true)
        {
            return this.specializationService.GetAllSpecializations(withoutGPD);
        }

        public int GetSpecializationByType(string selectedSpecialization)
        {
            return this.specializationService.GetSpecializationByType(selectedSpecialization);
        }
    }
}
