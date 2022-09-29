using CurrencyConverterApi.Models;
using CurrencyConverterApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverterApi.Services
{
  public class CurrencyConverterService : ICurrencyConverterService
  {
    private readonly ICurrencyConverterRepository _currencyRepository;

    public CurrencyConverterService(ICurrencyConverterRepository currencyConverterRepository)
    {
      _currencyRepository = currencyConverterRepository;
    }
    public async Task<CurrencyConversionResponseModel> ConvertBtwnCurrencies(CurrencyConversionRequestModel model)
    {
      string uriParameters = $"/exchangerates_data/convert?to={model.ToCurrency}&from={model.FromCurrency}&amount={model.RequestValue}";
      var result = await _currencyRepository.Get<CurrencyConversionResponseModel>(uriParameters);
      return result;
    }

    public async Task<LatestExchangeRatesResponseModel> GetAllCurrencyConversions()
    {
      string uriParameters = "/exchangerates_data/latest";
      var result = await _currencyRepository.Get<LatestExchangeRatesResponseModel>(uriParameters);
      return result;
    }

    public async Task<LatestExchangeRatesResponseModel> GetByBase(string baseCurrency)
    {
      string uriParameters = $"/exchangerates_data/latest?base={baseCurrency}";
      var result = await _currencyRepository.Get<LatestExchangeRatesResponseModel>(uriParameters);
      return result;
    }

    public async Task<HistoricalExchangeRatesResponseMiodel> GetLastPastDays(int days)
    {
      var date = DateTime.Now.AddDays(-days);
      string uriParameters = $"/exchangerates_data/{date.ToString("yyyy-MM-dd")}";
      var result = await _currencyRepository.Get<HistoricalExchangeRatesResponseMiodel>(uriParameters);
      return result;
    }
  }
}
