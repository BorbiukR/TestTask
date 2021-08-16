using System;
using System.Collections.Generic;
using System.Linq;
using TestTask.BLL.Interfaces;
using TestTask.BLL.Models;

namespace TestTask.BLL.Services
{
    public class FactoryService : IFactoryService
    {
        public decimal GetTotalJobTime(Calculate calculate)
        {
            if (calculate == null)
                throw new ArgumentNullException(nameof(calculate));

            var leastCommonMultiple = GetLeastCommonMultiple(calculate.Employees);

            return HelpMethodToGetTotalJobTime(leastCommonMultiple, calculate);
        }

        public IEnumerable<decimal> GetImagesEditedByEveryPerson(Calculate calculate)
        {
            if (calculate == null)
                throw new ArgumentNullException(nameof(calculate));

            var leastCommonMultiple = GetLeastCommonMultiple(calculate.Employees);

            var totalJobTime = HelpMethodToGetTotalJobTime(leastCommonMultiple, calculate);

            return HelpMethodToGetImagesEditedByEveryPerson(calculate.Employees, totalJobTime, calculate);
        }

        private int GetLeastCommonMultiple(List<Employee> employees)
        {
            if (employees == null)
                throw new ArgumentNullException(nameof(employees));

            var maxInteger = employees.Select(x => x.IndividualSpeedForOnePicture).Max();

            for (int multiple = maxInteger; multiple < 10_000; multiple++)
            {
                var isMultiple = true;

                foreach (var integer in employees)
                {
                    if (multiple % integer.IndividualSpeedForOnePicture != 0)
                        isMultiple = false;
                }

                if (isMultiple)
                    return multiple;
            }

            throw new ArgumentNullException(
                "Some of integers is <= 0 or multiple integer is > 10000",
                nameof(employees));
        }

        private decimal HelpMethodToGetTotalJobTime(int leastCommonMultiple, Calculate calculate)
        {
            var result = (decimal) calculate.AmountOfImages *
                                   leastCommonMultiple /
                                   calculate.Employees.Sum(x => leastCommonMultiple / x.IndividualSpeedForOnePicture);

            return Math.Round(result, 2);
        }        
        
        private IEnumerable<decimal> HelpMethodToGetImagesEditedByEveryPerson(List<Employee> employees,
                                                                              decimal totalJobTime,
                                                                              Calculate calculate)
        {
            if (calculate == null)
                throw new ArgumentNullException(nameof(calculate));
            if (totalJobTime <= 0)
                throw new ArgumentNullException("TotalJobTime cannot be less or equal to zero", nameof(totalJobTime));
            if (employees.Count == 0)
                throw new ArgumentNullException(nameof(totalJobTime));

            foreach (var item in employees)
                yield return Math.Round(totalJobTime / item.IndividualSpeedForOnePicture, 2);            
        }    
    }
}