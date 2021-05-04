namespace Hospital.Model
{
    class Review
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        public string Description { get; set; }

        public Patient patient { get; set; }
        public Doctor doctor { get; set; }

        public Review()
        {

        }
        public Review(int id,int rate,string description,Patient patient,Doctor doctor)
        {
            this.Id = id;
            this.Rate = rate;
            this.Description = description;
            this.patient = patient;
            this.doctor = doctor;
        }
    }
}
