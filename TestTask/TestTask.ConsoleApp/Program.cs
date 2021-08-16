using System;
using System.Collections.Generic;
using TestTask.BLL.Models;
using TestTask.BLL.Services;

namespace TestTask.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var factory = new FactoryService();

            var employees = new List<Employee>
            {
                new Employee { Id = 1, IndividualSpeedForOnePicture = 2 },
                new Employee { Id = 2, IndividualSpeedForOnePicture = 3 },
                new Employee { Id = 3, IndividualSpeedForOnePicture = 4 },
                new Employee { Id = 4, IndividualSpeedForOnePicture = 6 },
                new Employee { Id = 5, IndividualSpeedForOnePicture = 10 }
            };

            var calc = new Calculate
            {
                AmountOfImages = 10000,
                Employees = employees
            };

            var time = factory.GetTotalJobTime(calc);

            var images = factory.GetImagesEditedByEveryPerson(calc);

            Console.WriteLine($" {calc.Employees.Count} people edited {calc.AmountOfImages} images in {time} minutes");
            Console.WriteLine();
            
            foreach (var image in images)
            {
                Console.WriteLine($" {image} images");            
            }

            Console.ReadLine();
        }
    }
}