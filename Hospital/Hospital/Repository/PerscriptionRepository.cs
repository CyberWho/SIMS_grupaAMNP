/***********************************************************************
 * Module:  PerscriptionRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.PerscriptionRepository
 ***********************************************************************/

using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Repository
{
    public class PerscriptionRepository
    {

        OracleConnection connection = null;

        private void setConnection()
        {
            String conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            connection = new OracleConnection(conString);
            try
            {
                connection.Open();

            }
            catch (Exception exp)
            {

            }
        }
        public Model.Perscription GetPerscriptionById(int id)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM perscription WHERE id = " + id;
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();

            var perscription = ParsePerscription(reader);

            connection.Close();
            connection.Dispose();

            return perscription;
        }

        public ObservableCollection<Model.Perscription> GetAllPerscriptionsByAnamnesisId(int anamnesisId)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "select * from perscription where anamnesis_id = " + anamnesisId;
            OracleDataReader reader = command.ExecuteReader();
            ObservableCollection<Model.Perscription> perscriptions = new ObservableCollection<Model.Perscription>();

            //kreiranje i vranjacanje isto za get by anam id isto tako i za perscription onda uraditi za anamnezu za karton
            while (reader.Read())
            {
                var perscription = ParsePerscription(reader);
                perscriptions.Add(perscription);
            }
            
            connection.Close();
            connection.Dispose();

            return perscriptions;
        }

        public System.Collections.ArrayList GetAllActivePerscriptions()
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Perscription> GetAllActivePerscriptionsByAnamnesisId(int anamnesisId)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "select * from perscription where anamnesis_id = :anamnesis_id and is_active = 1";
            command.Parameters.Add("anamnesis_id", OracleDbType.Int32).Value = anamnesisId.ToString();
            OracleDataReader reader = command.ExecuteReader();
            ObservableCollection<Model.Perscription> perscriptions = new ObservableCollection<Model.Perscription>();

            while (reader.Read())
            {
                var perscription = ParsePerscription(reader);
                perscriptions.Add(perscription);
            }

            connection.Close();
            
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

        public Boolean DeletePerscriptionById(int id)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteAllPerscriptionsByAnamnesisId(int anamnesisId)
        {
            // TODO: implement
            return false;
        }

        public Model.Perscription UpdatePerscription(Model.Perscription perscription)
        {
            // TODO: implement
            return null;
        }

        public Model.Perscription NewPerscription(Model.Perscription perscription)
        {
            setConnection();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO perscription (is_active,description ,drug_id ,anamnesis_id) VALUES (1,'" + perscription.Description + "',"+ perscription.Drug.Id+ ","+perscription.anamnesis.Id+")";
            int a = cmd.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();

            return null;
        }

        public int GetLastId()
        {
            // TODO: implement
            return 0;
        }

    }
}