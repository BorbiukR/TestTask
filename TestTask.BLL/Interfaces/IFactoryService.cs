using System.Collections.Generic;
using TestTask.BLL.Models;

namespace TestTask.BLL.Interfaces
{
    public interface IFactoryService
    {
        decimal GetTotalJobTime(Calculate calculate);

        IEnumerable<decimal> GetImagesEditedByEveryPerson(Calculate model);
    }
}