using CurrencyConverterApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyConverterApi.Repositories
{
  public class CurrencyConverterRepository: Repository<LatestExchangeRatesResponseModel>, ICurrencyConverterRepository
  {
    public CurrencyConverterRepository(IHttpClientFactory factory):base(factory)
    {
    }
  }
}
