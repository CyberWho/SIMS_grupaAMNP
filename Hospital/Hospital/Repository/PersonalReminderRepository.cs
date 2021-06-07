using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Hospital.Model;
using System.Collections.ObjectModel;

namespace Hospital.Repository
{
    class PersonalReminderRepository
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
        public PersonalReminder GetPersonalReminderById(int id)
        {
            setConnection();
           
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM PERSONAL_REMINDER,REMINDER WHERE PERSONAL_REMINDER.ID = :id AND PERSONAL_REMINDER.REMINDER_ID = REMINDER.ID";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            var personalReminder = ParsePersonalReminder(reader);
            connection.Close();
            return personalReminder;
        }

        private static PersonalReminder ParsePersonalReminder(OracleDataReader reader)
        {
            PersonalReminder personalReminder = new PersonalReminder();
            personalReminder.Id = reader.GetInt32(0);
            personalReminder.reminderId = reader.GetInt32(1);
            int personalReminderFrequencyId = reader.GetInt32(2);
            switch (personalReminderFrequencyId)
            {
                case 0:
                    personalReminder.PersonalReminderFrequency = PersonalReminderFrequency.ONLY_ONCE;
                    break;
                case 1:
                    personalReminder.PersonalReminderFrequency = PersonalReminderFrequency.DAILY;
                    break;
                case 2:
                    personalReminder.PersonalReminderFrequency = PersonalReminderFrequency.WEEKLY;
                    break;
            }

            personalReminder.Name = reader.GetString(4);
            personalReminder.Description = reader.GetString(5);
            personalReminder.AlarmTime = reader.GetDateTime(6);
            personalReminder.Patient = new PatientRepository().GetById(reader.GetInt32(7));
            return personalReminder;
        }

        public ObservableCollection<PersonalReminder> GetAllPersonalRemindersByPatientId(int patientId)
        {
            setConnection();
            ObservableCollection<PersonalReminder> personalReminders = new ObservableCollection<PersonalReminder>();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM PERSONAL_REMINDER,REMINDER WHERE PERSONAL_REMINDER.REMINDER_ID = REMINDER.ID AND REMINDER.PATIENT_ID = :patient_id";
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = patientId.ToString();
            OracleDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                PersonalReminder personalReminder = ParsePersonalReminder(reader);
                
                personalReminders.Add(personalReminder);
            }
            connection.Close();
            return personalReminders;
        }
        public PersonalReminder UpdatePersonalReminderFrequency(PersonalReminder personalReminder)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE PERSONAL_REMINDER SET FREQUENCY_ID = :frequency_id WHERE ID = :id";
            command.Parameters.Add("frequency_id", OracleDbType.Int32).Value = Convert.ToInt32(personalReminder.PersonalReminderFrequency);
            command.Parameters.Add("id", OracleDbType.Int32).Value = personalReminder.Id.ToString();
            command.ExecuteNonQuery();
            connection.Close();
            return personalReminder;
        }
        public PersonalReminder AddPersonalReminder(PersonalReminder personalReminder)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO PERSONAL_REMINDER(REMINDER_ID,FREQUENCY_ID) VALUES (:reminder_id,:frequency_id)";
            command.Parameters.Add("reminder_id", OracleDbType.Int32).Value = personalReminder.reminderId.ToString();
            int frequencyId = 0;
            switch(personalReminder.PersonalReminderFrequency)
            {
                case PersonalReminderFrequency.ONLY_ONCE:
                    frequencyId = 0;
                    break;
                case PersonalReminderFrequency.DAILY:
                    frequencyId = 1;
                    break;
                case PersonalReminderFrequency.WEEKLY:
                    frequencyId = 2;
                    break;

            }
            command.Parameters.Add("frequency_id", OracleDbType.Int32).Value = frequencyId;
            command.ExecuteNonQuery();
            connection.Close();
            return personalReminder;
        }
        public Boolean DeletePersonalReminderById(int id)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM PERSONAL_REMINDER WHERE ID = :id";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }
        public Boolean DeleteAllPersonalRemindersByPatientId(int patientId)
        {
            return false;
        }
        public int GetLastId()
        {
            setConnection();
            int id = 0;
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT MAX(ID) FROM PERSONAL_REMINDER";
            OracleDataReader reader = command.ExecuteReader();
            reader = command.ExecuteReader();
            reader.Read();
            id = int.Parse(reader.GetString(0));

            connection.Close();
            connection.Dispose();

            return id;
        }
    }
}
