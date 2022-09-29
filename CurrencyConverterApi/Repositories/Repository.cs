using CurrencyConverterApi.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyConverterApi.Repositories
{
  public abstract class Repository<T> : IRepository<T>
  {
    protected IHttpClientFactory _factory { get; set; }
    public Repository(IHttpClientFactory factory)
    {
      _factory = factory;
    }


    async Task<T> IRepository<T>.Get<T>(string uriParameters)
    {
      var client = _factory.CreateClient("openExchangeApiUrl");

      var httpResponseMessage = await client.GetAsync(uriParameters);
  
      string jsonResult = httpResponseMessage.Content.ReadAsStringAsync().Result;
      var result = JsonConvert.DeserializeObject<T>(jsonResult);
      return result;
    }

    public Task<T1> Post<T1>(T1 entity)
    {
      throw new NotImplementedException();
    }
  }
}
