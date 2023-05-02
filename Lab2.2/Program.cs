using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2._2
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }

    public class TaxiDriver : Person
    {
        public string LicenseNumber { get; set; }
        public DateTime LicenseExpirationDate { get; set; }
        public string TaxiLicenseNumber { get; set; }
        public DateTime TaxiLicenseExpirationDate { get; set; }
        public int Shift { get; set; }

        public double GetTaxiRate()
        {
            if (Shift == 0)
            {
                return 2.5; // Day shift rate
            }
            else
            {
                return 3.5; // Night shift rate
            }
        }

        public DateTime GetLicenseRenewalDate()
        {
            return LicenseExpirationDate.AddDays(-30);
        }

        public DateTime GetTaxiLicenseRenewalDate()
        {
            return TaxiLicenseExpirationDate.AddDays(-30);
        }
    }

    public class DriverInstructor : Person
    {
        public int YearsOfExperience { get; set; }
        public string LicenseNumber { get; set; }

        public bool CanTeachDriving()
        {
            return YearsOfExperience >= 5;
        }

        public double GetSalary(int numberOfStudents, int hoursPerStudent)
        {
            double hourlyRate = 20;
            return numberOfStudents * hoursPerStudent * hourlyRate;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int Repline;
            do
            {
                Console.WriteLine("Enter 1 for instructor or 2 for taxi driver: ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    DriverInstructor instructor = new DriverInstructor();

                    Console.Write("Enter instructor name: ");
                    instructor.Name = Console.ReadLine();

                    Console.Write("Enter instructor age: ");
                    instructor.Age = int.Parse(Console.ReadLine());

                    Console.Write("Enter instructor gender: ");
                    instructor.Gender = Console.ReadLine();

                    Console.Write("Enter instructor years of experience: ");
                    instructor.YearsOfExperience = int.Parse(Console.ReadLine());

                    Console.Write("Enter instructor license number: ");
                    instructor.LicenseNumber = Console.ReadLine();

                    Console.Write("Enter number of students: ");
                    int numberOfStudents = int.Parse(Console.ReadLine());

                    Console.Write("Enter hours per student: ");
                    int hoursPerStudent = int.Parse(Console.ReadLine());

                    Console.WriteLine("Instructor information:");
                    Console.WriteLine("Name: " + instructor.Name);
                    Console.WriteLine("Age: " + instructor.Age);
                    Console.WriteLine("Gender: " + instructor.Gender);
                    Console.WriteLine("Years of experience: " + instructor.YearsOfExperience);
                    Console.WriteLine("License number: " + instructor.LicenseNumber);
                    Console.WriteLine("Can teach driving: " + instructor.CanTeachDriving());
                    Console.WriteLine("Salary: " + instructor.GetSalary(numberOfStudents, hoursPerStudent));
                }
                else if (choice == 2)
                {
                    TaxiDriver driver = new TaxiDriver();

                    Console.Write("Enter driver name: ");
                    driver.Name = Console.ReadLine();

                    Console.Write("Enter driver age: ");
                    driver.Age = int.Parse(Console.ReadLine());

                    Console.Write("Enter driver gender: ");
                    driver.Gender = Console.ReadLine();

                    Console.Write("Enter driver license number: ");
                    driver.LicenseNumber = Console.ReadLine();

                    Console.Write("Enter driver license expiration date (MM/dd/yyyy): ");
                    driver.LicenseExpirationDate = DateTime.Parse(Console.ReadLine());

                    Console.Write("Enter driver taxi license number: ");
                    driver.TaxiLicenseNumber = Console.ReadLine();

                    Console.Write("Enter driver taxi license expiration date (MM/dd/yyyy): ");
                    driver.TaxiLicenseExpirationDate = DateTime.Parse(Console.ReadLine());

                    Console.Write("Enter driver shift (0 for day shift, 1 for night shift): ");
                    driver.Shift = int.Parse(Console.ReadLine());

                    Console.WriteLine("Driver information:");
                    Console.WriteLine("Name: " + driver.Name);
                    Console.WriteLine("Age: " + driver.Age);
                    Console.WriteLine("Gender: " + driver.Gender);
                    Console.WriteLine("License number: " + driver.LicenseNumber);
                    Console.WriteLine("License expiration date: " + driver.LicenseExpirationDate.ToString("MM/dd/yyyy"));
                    Console.WriteLine("Taxi license number: " + driver.TaxiLicenseNumber);
                    Console.WriteLine("Taxi license expiration date: " + driver.TaxiLicenseExpirationDate.ToString("MM/dd/yyyy"));
                    Console.WriteLine("Shift: " + (driver.Shift == 0 ? "Day shift" : "Night shift"));
                    Console.WriteLine("Taxi rate: " + driver.GetTaxiRate());
                    Console.WriteLine("License renewal date: " + driver.GetLicenseRenewalDate().ToString("MM/dd/yyyy"));
                    Console.WriteLine("Taxi rate: " + driver.GetTaxiRate());
                    Console.WriteLine("License renewal date: " + driver.GetLicenseRenewalDate().ToString("MM/dd/yyyy"));
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter 1 for Driver Instructor or 2 for Taxi Driver.");
                }

                Console.WriteLine("repeat?(1 = yes,0 = no)");
                Repline = int.Parse(Console.ReadLine());
            } while (Repline == 1 & Repline != 0);
            Console.ReadKey();
        }
    }
}