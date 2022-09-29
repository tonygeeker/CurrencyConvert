﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverterApi.Models
{
  public class RelativeRate
  {
    [JsonProperty("rate")]
    public KeyValuePair<string, double> ExchangeRate { get; set; }
  }
}
