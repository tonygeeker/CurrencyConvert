using CurrencyConverterApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverterApi.Repositories
{
  public interface IRepository<T>
  {
    Task<T> Get<T>(string uriParameters);
    Task<T1> Post<T1>(T1 entity);
  }
}
