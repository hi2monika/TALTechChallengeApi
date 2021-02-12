using System.Threading;
using System.Threading.Tasks;

namespace TALTechChallenge.Core.Common.Interfaces.Services
{
    public interface ICustomerService
    {
      public  Task<double> CalculateMonthlyPremium(int age, double deathSumInsured, string occupation , CancellationToken cancellationToken);
    }
}
