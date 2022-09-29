using CurrencyConverterApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverterApi.Services
{
  public interface ICurrencyConverterService
  {
    Task<LatestExchangeRatesResponseModel> GetAllCurrencyConversions();
    Task<HistoricalExchangeRatesResponseMiodel> GetLastPastDays(int days);
    Task<LatestExchangeRatesResponseModel> GetByBase(string baseCurrency);
    Task<CurrencyConversionResponseModel> ConvertBtwnCurrencies(CurrencyConversionRequestModel model);
  }
}
