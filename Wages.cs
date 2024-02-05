namespace Lab2
{
    class Wages : Employee
    {
        private double rate;
        private double hours;
        public double Rate { get => rate; set => rate = value; }
        public double Hours { get => hours; set => hours = value; }

        public Wages()
        {

        }
        public Wages(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours) : base(id, name, address, phone, sin, dob, dept)
        {
            this.rate = rate;
            this.hours = hours;
        }
        public override double getPay()
        {
            // Wage employees’ pay is calculated using hourly rate * work hours with overtime paid at time and a half for any hours worked over 40 in one week
            double overtimeHours = hours - 40;
            if (overtimeHours > 0)
            {
                return (40 * rate) + (rate * 1.5 * overtimeHours);
            }
            else
            {
                return rate * hours;
            }

        }

        public override void toString()
        {
            Console.WriteLine($"{Id}:{Name}:{Address}:{Phone}:{Sin}:{Dob}:{Dept}:{Rate}:{Hours}");
        }
    }
}