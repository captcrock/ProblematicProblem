using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;



namespace ProblematicProblem
{
    class Program
    {
        public static Random rng = new Random();        
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static string yesNo;
        
        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            yesNo = Console.ReadLine();
            //bool cont = bool.Parse(yesNo);

            //if (yesNo == "yes")
            //{
            //    cont = true;
            //}
            //else if (yesNo == "no")
            //{
            //    cont = false;
            //}
            //else
            //{
            //    Console.WriteLine("Please respond yes or no");
            //}
            //bool cont = bool.Parse(Console.ReadLine());

            if (yesNo.ToLower() != "yes")
            {
                Console.WriteLine("Goodbye!");
                return;
            }
            

            Console.WriteLine();

            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();

            Console.WriteLine();

            Console.Write("What is your age? ");
            int userAge = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            //bool seeList = bool.Parse(Console.ReadLine());
            yesNo = Console.ReadLine();

            

            if (yesNo.ToLower() == "sure" || yesNo.ToLower() == "yes")
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }

                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                yesNo = Console.ReadLine();
                bool addToList;
                Console.WriteLine();


                if (yesNo.ToLower() == "yes")
                {
                    addToList = true;
                }
                else if (yesNo.ToLower() == "no")
                {
                    addToList = false;
               
                }
                else
                    addToList = false;


                while (addToList)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();


                    activities.Add(userAddition);

                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    string addMoreToList = Console.ReadLine();
                    if (addMoreToList.ToLower() == "yes")
                    {
                        addToList = true;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            
            while (cont == true)
            {
                Console.Write("Connecting to the database");

                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();

                Console.Write("Choosing your random activity");

                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();

                int randomNumber = rng.Next(activities.Count);

                string randomActivity = activities[randomNumber];

                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");

                    activities.Remove(randomActivity);

                    randomNumber = rng.Next(activities.Count);

                    randomActivity = activities[randomNumber];
                }

                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();
                if (Console.ReadLine().ToLower() == "redo")
                {
                    cont = true;
                }
                else if ((Console.ReadLine().ToLower() == "keep"))
                {
                    cont = false;
                }
                else
                    cont = false;
            }
        }
    }
}
