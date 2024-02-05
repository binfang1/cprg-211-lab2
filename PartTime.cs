namespace Lab2
{
    class PartTime : Employee
    {
        private double rate;
        private double hours;
        public double Rate { get => rate; set => rate = value; }
        public double Hours { get => hours; set => hours = value; }

        public PartTime()
        {

        }
        public PartTime(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours) : base(id, name, address, phone, sin, dob, dept)
        {
            this.rate = rate;
            this.hours = hours;
        }

        public override double getPay()
        {
            // Part-time employees’ pay is calculated based on hourly rate * work hours with no overtime paid
            return rate * hours;
        }

        public override void toString()
        {
            Console.WriteLine($"{Id}:{Name}:{Address}:{Phone}:{Sin}:{Dob}:{Dept}:{Rate}:{Hours}");
        }
    }
}