using System;

namespace Hospital.Model
{
    class PatientLogs
    {
        public int Id { get; set; }
        public int LogCounter { get; set; }

        public DateTime LastCounterReset { get; set; }
        public Patient patient { get; set; }

        public PatientLogs()
        {

        }
        public PatientLogs(int id,int logCounter,Patient patient,DateTime lastCounterReset)
        {
            this.Id = id;
            this.LogCounter = logCounter;
            this.patient = patient;
            this.LastCounterReset = lastCounterReset;
        }
    }
}
