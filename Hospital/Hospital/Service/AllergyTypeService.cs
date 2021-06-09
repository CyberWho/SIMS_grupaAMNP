/***********************************************************************
 * Module:  AllergyTypeService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.AllergyTypeService
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.IRepository;
using Hospital.Model;
using Hospital.Repository;


namespace Hospital.Service
{
    public class AllergyTypeService
    {
        private IAllergyTypeRepo<AllergyType> allergyTypeRepository;

        public AllergyTypeService(IAllergyTypeRepo<AllergyType> iAllergyTypeRepo)
        {
            allergyTypeRepository = iAllergyTypeRepo;
        }

        public System.Collections.ArrayList GetAllAllergyTypes()
        {
            // TODO: implement
            return null;
        }

        public Boolean DeleteAllergieTypeById(int id)
        {
            // TODO: implement
            return false;
        }

        public AllergyType UpdateAllergyType(int allergyType)
        {
            // TODO: implement
            return null;
        }

        public AllergyType AddAllergyType(AllergyType allergyType)
        {
            // TODO: implement
            return null;
        }

        public AllergyType GetAllergyTypeByType(string type)
        {
            return this.allergyTypeRepository.GetByType(type);
        }
        public ObservableCollection<AllergyType> GetAllMissingAllergyTypesByUserId(int userId)
        {
            return this.allergyTypeRepository.GetAllMissingTypesByUserId(userId);
        }
        public ObservableCollection<AllergyType> GetAllTypesByHealthRecordId(int id)
        {
            return this.allergyTypeRepository.GetAllByHealthRecordId(id);
        }
        public AllergyType GetAllergyTypeById(int id)
        {
            return this.allergyTypeRepository.GetById(id);
        }


    }
}