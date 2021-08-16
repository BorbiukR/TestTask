using System.Collections.Generic;
using TestTask.BLL.Models;
using TestTask.BLL.Services;
using Xunit;

namespace XUnitTestProject
{
    public class FactoryServiceTests
    {
        private readonly FactoryService _factoryService = new FactoryService();

        [Theory]
        [MemberData(nameof(Data_To_GetTotalJobTime))]
        public void GetTotalJobTime_Test(Calculate calculate, decimal expectedTime)
        {
            var actualTime = _factoryService.GetTotalJobTime(calculate);
            
            Assert.Equal(expectedTime, actualTime);        
        }

        [Theory]
        [MemberData(nameof(Data_To_GetImagesEditedByEveryPerson))]
        public void GetImagesEditedByEveryPerson_Test(Calculate calculate, IEnumerable<decimal> expectedImages)
        {
            var actualImages = _factoryService.GetImagesEditedByEveryPerson(calculate);

            Assert.Equal(expectedImages, actualImages);
        }

        public static IEnumerable<object[]> Data_To_GetTotalJobTime()
        {
            yield return new object[] 
            { 
                new Calculate
                {
                    AmountOfImages = 1200,
                    Employees = new List<Employee>
                    {
                        new Employee { IndividualSpeedForOnePicture = 2 },
                        new Employee { IndividualSpeedForOnePicture = 3 },
                        new Employee { IndividualSpeedForOnePicture = 4 },
                        new Employee { IndividualSpeedForOnePicture = 6 }
                    }
                },
                960 
            };

            yield return new object[]
            {
                new Calculate
                {
                    AmountOfImages = 1000,
                    Employees = new List<Employee>
                    {
                        new Employee { IndividualSpeedForOnePicture = 2 },
                        new Employee { IndividualSpeedForOnePicture = 3 },
                        new Employee { IndividualSpeedForOnePicture = 4 }
                    }
                },
                923.08m
            };

            yield return new object[]
            {
                new Calculate
                {
                    AmountOfImages = 10000,
                    Employees = new List<Employee>
                    {
                        new Employee { IndividualSpeedForOnePicture = 2 },
                        new Employee { IndividualSpeedForOnePicture = 3 },
                        new Employee { IndividualSpeedForOnePicture = 4 },
                        new Employee { IndividualSpeedForOnePicture = 6 },
                        new Employee { IndividualSpeedForOnePicture = 10 }
                    }
                },
                7407.41m
            };
        }

        public static IEnumerable<object[]> Data_To_GetImagesEditedByEveryPerson()
        {
            yield return new object[]
            {
                new Calculate
                {
                    AmountOfImages = 1200,
                    Employees = new List<Employee>
                    {
                        new Employee { IndividualSpeedForOnePicture = 2 },
                        new Employee { IndividualSpeedForOnePicture = 3 },
                        new Employee { IndividualSpeedForOnePicture = 4 },
                        new Employee { IndividualSpeedForOnePicture = 6 }
                    }
                },
                new List<decimal> { 480, 320, 240, 160 }
            };

            yield return new object[]
            {
                new Calculate
                {
                    AmountOfImages = 1000,
                    Employees = new List<Employee>
                    {
                        new Employee { IndividualSpeedForOnePicture = 2 },
                        new Employee { IndividualSpeedForOnePicture = 3 },
                        new Employee { IndividualSpeedForOnePicture = 4 }
                    }
                },
                new List<decimal> { 461.54m, 307.69m, 230.77m }
            };

            yield return new object[]
            {
                new Calculate
                {
                    AmountOfImages = 10000,
                    Employees = new List<Employee>
                    {
                        new Employee { IndividualSpeedForOnePicture = 2 },
                        new Employee { IndividualSpeedForOnePicture = 3 },
                        new Employee { IndividualSpeedForOnePicture = 4 },
                        new Employee { IndividualSpeedForOnePicture = 6 },
                        new Employee { IndividualSpeedForOnePicture = 10 }
                    }
                },
                new List<decimal> { 3703.70m, 2469.14m, 1851.85m, 1234.57m, 740.74m }
            };
        }
    }
}