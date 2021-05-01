/***********************************************************************
 * Module:  PerscriptionRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.PerscriptionRepository
 ***********************************************************************/

using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.ObjectModel;

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
        public Hospital.Model.Perscription GetPerscriptionById(int id)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM perscription WHERE id = " + id;
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();

            Model.Perscription perscription = new Model.Perscription();
            //kreiranje i vranjacanje isto za get by anam id isto tako i za perscription onda uraditi za anamnezu za karton
            perscription.Id = reader.GetInt32(0);
            perscription.IsActive = reader.GetInt32(1) == 0 ? false : true;
            perscription.Description = reader.GetString(2);
            perscription.Drug_id = reader.GetInt32(3);

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
                Model.Perscription perscription = new Model.Perscription();
                perscription.Id = reader.GetInt32(0);
                perscription.IsActive = reader.GetInt32(1) == 0 ? false : true;
                perscription.Description = reader.GetString(2);
                perscription.Drug_id = int.Parse(reader.GetString(3));
                //Console.WriteLine(reader.GetString(3));
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

        public System.Collections.ArrayList GetAllActivePerscriptionsByAnamnesisId(int anamnesisId)
        {
            // TODO: implement
            return null;
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

        public Hospital.Model.Perscription UpdatePerscription(Hospital.Model.Perscription perscription)
        {
            // TODO: implement
            return null;
        }

        public Hospital.Model.Perscription NewPerscription(Hospital.Model.Perscription perscription)
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