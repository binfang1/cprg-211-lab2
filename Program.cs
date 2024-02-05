/*
Company has 3 emlpoyee categories inherited from employee

Employee

Salaried
ID: 0-4
Paid a set salary each week

Wage 
ID: 5-7
Hourly rate * work hours with overtime paid at time and a half for any hours worked over 40 in one week

Part-Time
ID: 8-9
hourly rate * work hours with no overtime paid

*/

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = LoadEmployeesFromFile();

            // Calculate and display average pay
            double averagePay = AverageWeeklyPay(employees);
            Console.WriteLine($"Average Pay: {averagePay:F2}");

            // Find highest wage employee and display
            Employee highestWageEmployee = HighestWageEmployee(employees);
            Console.WriteLine($"Highest Paid Wage Employee: {highestWageEmployee.Name} with a pay of {highestWageEmployee.getPay()}");

            // Find lowest salaried employee and display
            Employee lowestSalaryEmployee = LowestSalaryEmployee(employees);
            Console.WriteLine($"Lowest Paid Salary Employee: {lowestSalaryEmployee.Name} with a pay of {lowestSalaryEmployee.getPay()}");

            // Display percentages
            EmployeePercentage(employees);
        }

        static private List<Employee> LoadEmployeesFromFile()
        {
            // Fill a list with objects based on the supplied data file.
            List<Employee> employees = new List<Employee>();
            using (StreamReader sr = new StreamReader("res/employees.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    // Split using ":" as delimiter
                    string[] split = line.Split(":");
                    int leadingIdNumber = Convert.ToInt32(split[0][0].ToString());

                    // If leading digit is >= 8, create Part Time
                    if (leadingIdNumber >= 8)
                    {
                        employees.Add(new PartTime(split[0], split[1], split[2], split[3], Convert.ToInt64(split[4]), split[5], split[6], Convert.ToDouble(split[7]), Convert.ToDouble(split[8])));
                    }
                    // >= 5, create Wage
                    else if (leadingIdNumber >= 5)
                    {
                        employees.Add(new Wages(split[0], split[1], split[2], split[3], Convert.ToInt64(split[4]), split[5], split[6], Convert.ToDouble(split[7]), Convert.ToDouble(split[8])));
                    }
                    // create Salaried
                    else
                    {
                        employees.Add(new Salaried(split[0], split[1], split[2], split[3], Convert.ToInt64(split[4]), split[5], split[6], Convert.ToDouble(split[7])));
                    }
                }
            }
            return employees;
        }

        static private double AverageWeeklyPay(List<Employee> employees)
        {
            double sum = 0;
            foreach (Employee employee in employees)
            {
                sum += employee.getPay();
            }
            return sum / employees.Count;
        }

        static private Employee HighestWageEmployee(List<Employee> employees)
        {
            double highest = 0;
            Employee highestEmployee = new Employee();
            foreach (Employee employee in employees)
            {
                // Check if Wage employee
                if (employee is Wages)
                {
                    // Console.WriteLine($"Wage Employee Found: {employee.Name} with weekly pay of {employee.getPay()}");
                    if (employee.getPay() > highest)
                    {
                        // Console.WriteLine($"Weekly pay of {employee.getPay()} is higher than current: {highest}");
                        highest = employee.getPay();
                        highestEmployee = employee;
                    }
                }
            }
            return highestEmployee;
        }

        static private Employee LowestSalaryEmployee(List<Employee> employees)
        {
            double lowest = employees.Max(e => e.getPay());
            Employee lowestEmployee = new Employee();
            foreach (Employee employee in employees)
            {
                // Check if Salaried employee
                if (employee is Salaried)
                {
                    // Console.WriteLine($"Salaried Employee Found: {employee.Name} with weekly pay of {employee.getPay()}");
                    if (employee.getPay() < lowest)
                    {
                        // Console.WriteLine($"Weekly pay of {employee.getPay()} is lower than current: {lowest}");
                        lowest = employee.getPay();
                        lowestEmployee = employee;
                    }
                }
            }
            return lowestEmployee;
        }

        static private void EmployeePercentage(List<Employee> employees)
        {
            float wageCount = 0;
            float salariedCount = 0;
            float partTimeCount = 0;
            foreach (Employee employee in employees)
            {
                if (employee is Wages)
                {
                    wageCount++;
                }
                else if (employee is Salaried)
                {
                    salariedCount++;
                }
                else if (employee is PartTime)
                {
                    partTimeCount++;
                }
            }
            // Convert to percentages
            float wagePercentage = wageCount / employees.Count * 100;
            float salariedPercentage = salariedCount / employees.Count * 100;
            float partTimePercentage = partTimeCount / employees.Count * 100;
            Console.WriteLine($"Employee Distribution: Wage: {wagePercentage:F2}% ({wageCount}/{employees.Count}) / Salaried: {salariedPercentage:F2}% ({salariedCount}/{employees.Count}) / Part Time: {partTimePercentage:F2}% ({partTimeCount}/{employees.Count})");
        }
    }
}



