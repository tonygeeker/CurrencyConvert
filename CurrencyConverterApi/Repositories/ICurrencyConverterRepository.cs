using CurrencyConverterApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverterApi.Repositories
{
  public interface ICurrencyConverterRepository : IRepository<LatestExchangeRatesResponseModel>
  {
  }
}
