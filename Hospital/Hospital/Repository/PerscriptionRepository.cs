/***********************************************************************
 * Module:  PerscriptionRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.PerscriptionRepository
 ***********************************************************************/

using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.ObjectModel;
using Hospital.IRepository;
using Hospital.Model;

namespace Hospital.Repository
{
    public class PerscriptionRepository : IPerscriptionRepo<Perscription>
    {

        

        private void setConnection()
        {
            String conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            Globals.globalConnection = new OracleConnection(conString);
            try
            {
                Globals.globalConnection.Open();

            }
            catch (Exception exp)
            {

            }
        }
        public Model.Perscription GetById(int id)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM perscription WHERE id = " + id;
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();

            var perscription = ParsePerscription(reader);

            
            

            return perscription;
        }

        public ObservableCollection<Model.Perscription> GetAllByAnamnesisId(int anamnesisId)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "select * from perscription where anamnesis_id = " + anamnesisId;
            OracleDataReader reader = command.ExecuteReader();
            ObservableCollection<Model.Perscription> perscriptions = new ObservableCollection<Model.Perscription>();

            //kreiranje i vranjacanje isto za get by anam id isto tako i za perscription onda uraditi za anamnezu za karton
            while (reader.Read())
            {
                var perscription = ParsePerscription(reader);
                perscriptions.Add(perscription);
            }
            
            
            

            return perscriptions;
        }

        public ObservableCollection<Perscription> GetAllActive()
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Perscription> GetAllActiveByAnamnesisId(int anamnesisId)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "select * from perscription where anamnesis_id = :anamnesis_id and is_active = 1";
            command.Parameters.Add("anamnesis_id", OracleDbType.Int32).Value = anamnesisId.ToString();
            OracleDataReader reader = command.ExecuteReader();
            ObservableCollection<Model.Perscription> perscriptions = new ObservableCollection<Model.Perscription>();

            while (reader.Read())
            {
                var perscription = ParsePerscription(reader);
                perscriptions.Add(perscription);
            }

            
            
            return perscriptions;
        }

        private static Perscription ParsePerscription(OracleDataReader reader)
        {
            Model.Perscription perscription = new Model.Perscription();
            perscription.Id = reader.GetInt32(0);
            perscription.IsActive = reader.GetInt32(1) == 0 ? false : true;
            perscription.Description = reader.GetString(2);
            perscription.Drug_id = reader.GetInt32(3);
            perscription.Drug = new DrugRepository().GetDrugById(reader.GetInt32(3));
            return perscription;
        }

        public Boolean DeleteById(int id)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteAllByAnamnesisId(int anamnesisId)
        {
            // TODO: implement
            return false;
        }

        public Model.Perscription Update(Model.Perscription perscription)
        {
            // TODO: implement
            return null;
        }

        public Model.Perscription Add(Model.Perscription perscription)
        {
            
            OracleCommand cmd = Globals.globalConnection.CreateCommand();
            cmd.CommandText = "INSERT INTO perscription (is_active,description ,drug_id ,anamnesis_id) VALUES (1,'" + perscription.Description + "',"+ perscription.Drug.Id+ ","+perscription.anamnesis.Id+")";
            int a = cmd.ExecuteNonQuery();

            
            

            return null;
        }

        public int GetLastId()
        {
            // TODO: implement
            return 0;
        }

        public ObservableCollection<Perscription> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}