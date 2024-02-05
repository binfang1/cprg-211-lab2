namespace Lab2
{
    class Salaried : Employee
    {
        private double salary;
        public double Salary { get => salary; set => salary = value; }

        public Salaried()
        {

        }

        public Salaried(string id, string name, string address, string phone, long sin, string dob, string dept, double salary) : base(id, name, address, phone, sin, dob, dept)
        {
            this.salary = salary;
        }

        public override double getPay()
        {
            // Salaried employees are paid a set salary each week
            return salary;
        }

        public override void toString()
        {
            Console.WriteLine($"{Id}:{Name}:{Address}:{Phone}:{Sin}:{Dob}:{Dept}:{Salary}");
        }
    }
}