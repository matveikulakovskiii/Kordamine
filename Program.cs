using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Start
    {
        public static void Main(string[] args)
        {
            // Ül. 1
            int[] numbers = { 3, 7, 11, 15, 19 };
            if (IsSorted(numbers))
            {
                Console.WriteLine("Massiiv tellitud.");
            }
            else
            {
                Console.WriteLine("Massiiv järjestamata.");
            }
            Console.ReadLine();




            //Ül. 2
            int N = 100;
            double[] nums = GenerateRandomNumbers(N);
            int count = CountOutOfRange(nums);
            Console.WriteLine($"Üksuste arv, mis jäävad vahemikku -10 kuni +10 välja: {count}");
            Console.ReadLine();
            static double[] GenerateRandomNumbers(int N)
            {
                Random random = new Random();
                double[] numbers = new double[N];
                for (int i = 0; i < N; i++)
                {
                    numbers[i] = random.NextDouble() * 200 - 100;
                }
                return numbers;
            }
            static int CountOutOfRange(double[] arr)
            {
                int count = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] < -10 || arr[i] > 10)
                    {
                        count++;
                    }
                }
                return count;
            }
            Citizen[] M = new Citizen[]
        {
            new Citizen("Kulakovski", "Matvei", "Alekseivitš", "Pärnu mnt 16", new DateTime(2006, 9, 4)),
            new Citizen("Petrov", "Peeter", "Petrovitš", "Lageda tee 1", new DateTime(1998, 9, 30)),
            new Citizen("Sidorov", "Sergei", "Aleksandrovitš", "Narva mnt 34", new DateTime(1972, 3, 10)),
            new Citizen("Andrejev", "Andrei", "Andrejevitš", "Pärnu mnt 16", new DateTime(2001, 11, 20)),
            new Citizen("Kozlov", "Dmitri", "Igorevitš", "Lageda tee 1", new DateTime(1990, 7, 5)),
            new Citizen("Petrov", "Ivan", "Ivanovitš", "Narva mnt 34", new DateTime(1980, 12, 25)),
        };
            string searchAddress = "Pärnu mnt 16";
            List<Citizen> voters = new List<Citizen>();
            foreach (Citizen citizen in M)
            {
                if (citizen.Address == searchAddress && citizen.Age >= 18)
                {
                    voters.Add(citizen);
                }
            }
            voters = voters.OrderBy(c => c.FullName).ToList();
            Console.WriteLine("Aadressil elavate valijate nimekiri " + searchAddress + " tähestiku järjekorras:");
            foreach (Citizen voter in voters)
            {
                Console.WriteLine(voter.FullName);
            }
        }
        class Citizen
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string Patronymic { get; set; }
            public string Address { get; set; }
            public DateTime BirthDate { get; set; }
            public string FullName => LastName + " " + FirstName + " " + Patronymic;
            public int Age => (DateTime.Now - BirthDate).Days / 365;
            public Citizen(string lastName, string firstName, string patronymic, string address, DateTime birthDate)
            {
                LastName = lastName;
                FirstName = firstName;
                Patronymic = patronymic;
                Address = address;
                BirthDate = birthDate;
            }
        }
        static bool IsSorted(int[] arr)
        {
            bool ascending = true;
            bool descending = true;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > arr[i - 1])
                {
                    descending = false;
                }
                else if (arr[i] < arr[i - 1])
                {
                    ascending = false;
                }
            }
            return ascending || descending;
        }
    }
}