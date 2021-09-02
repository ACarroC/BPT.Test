using BPT.Test.ACC.Client.Services;
using BPT.Test.ACC.Core.Entities;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BPT.Test.ACC.Client
{
    class Program
    {
        private static ServiceRepository service = new ServiceRepository();
        static void Main(string[] args)
        {

            string Parameter1 = string.Empty;
            string Parameter2 = string.Empty;
            string Option = string.Empty;
            // Display title as the C# console calculator app.
            Console.WriteLine("School Test\r");
            Console.WriteLine("------------------------\n");

            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\t1 - Student");
            Console.WriteLine("\t2 - Assigment");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Choose an option from the following list:");
                    Console.WriteLine("\t1 - Add Student");
                    Console.WriteLine("\t2 - View Student's");
                    Console.WriteLine("\t3 - Update Student");
                    Console.WriteLine("\t4 - Delete Student");
                    Console.Write("Your option? ");

                    // Use a switch statement to do the math.
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine("Name Student");
                            Parameter1 = Console.ReadLine();

                            // Ask the user to type the second number.
                            Console.WriteLine("Date of birth date");
                            Parameter2 = Console.ReadLine();
                            var streamTask = service.PostAsync("https://localhost:44349/", "api/student", "", "", new StudentCls() { Name = Parameter1, DateOfBirth = Convert.ToDateTime(Parameter2) }).Result;
                            Console.WriteLine(JsonConvert.SerializeObject(streamTask.Result));
                            break;
                        case "2":
                            var result = service.GetAsync("https://localhost:44349/", "api/student", "", "", new List<StudentCls>()).Result;
                            Console.WriteLine(JsonConvert.SerializeObject(result.Result));
                            Console.WriteLine();
                            break;
                        case "3":
                            Console.WriteLine("Id Student");
                            int id = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Name Student");
                            Parameter1 = Console.ReadLine();

                            // Ask the user to type the second number.
                            Console.WriteLine("Date of birth date");
                            Parameter2 = Console.ReadLine();
                            var update = service.PutAsync("https://localhost:44349/", $"api/student?id={id}", "", "", new StudentCls() { Id = id, Name = Parameter1, DateOfBirth = Convert.ToDateTime(Parameter2) }).Result;
                            Console.WriteLine(JsonConvert.SerializeObject(update.Result));
                            break;
                        case "4":
                            Console.WriteLine("Id Student");
                            int idDel = Convert.ToInt32(Console.ReadLine());

                            var delete = service.DeleteAsync("https://localhost:44349/", $"api/student?id={idDel}", "", "", new StudentCls() { Id = idDel, Name = Parameter1, DateOfBirth = Convert.ToDateTime(Parameter2) }).Result;
                            Console.WriteLine(JsonConvert.SerializeObject(delete.Result));
                            break;
                    }
                    break;
                case "2":

                    Console.WriteLine("Choose an option from the following list:");
                    Console.WriteLine("\t1 - Add Assigment");
                    Console.WriteLine("\t2 - View Assigments");
                    Console.WriteLine("\t3 - Update Assigment");
                    Console.WriteLine("\t4 - Delete Assigment");
                    Console.Write("Your option? ");

                    // Use a switch statement to do the math.
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine("Name Assigment");
                            Parameter1 = Console.ReadLine();

                            // Ask the user to type the second number.
                            
                            var streamTask = service.PostAsync("https://localhost:44349/", "api/assigment", "", "", new AssignmentsCls() { Name = Parameter1}).Result;
                            Console.WriteLine(JsonConvert.SerializeObject(streamTask.Result));
                            break;
                        case "2":
                            var result = service.GetAsync("https://localhost:44349/", "api/assigment", "", "", new List<AssignmentsCls>()).Result;
                            Console.WriteLine(JsonConvert.SerializeObject(result.Result));
                            Console.WriteLine();
                            break;
                        case "3":
                            Console.WriteLine("Id Assigment");
                            int id = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Name Assigment");
                            Parameter1 = Console.ReadLine();

                            // Ask the user to type the second number.
                            
                            var update = service.PutAsync("https://localhost:44349/", $"api/assigment?id={id}", "", "", new AssignmentsCls() { Id = id, Name = Parameter1}).Result;
                            Console.WriteLine(JsonConvert.SerializeObject(update.Result));
                            break;
                        case "4":
                            Console.WriteLine("Id Assigment");
                            int idDel = Convert.ToInt32(Console.ReadLine());

                            var delete = service.DeleteAsync("https://localhost:44349/", $"api/assigment?id={idDel}", "", "", new StudentCls() { Id = idDel, Name = Parameter1 }).Result;
                            Console.WriteLine(JsonConvert.SerializeObject(delete.Result));
                            break;
                    }
                    break;
            }



            // Wait for the user to respond before closing.
            Console.Write("Press any key to close");
            Console.ReadKey();



        }
    }
}
