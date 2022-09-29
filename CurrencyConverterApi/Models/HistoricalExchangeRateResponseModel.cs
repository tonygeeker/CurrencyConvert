using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CurrencyConverterApi.Models
{
  public class HistoricalExchangeRatesResponseMiodel
  {
    [JsonProperty("historical")]

    public bool IsHistorical { get; set; }

    [JsonProperty("base")]
    public string BaseCurrency { get; set; }

    [JsonProperty("date")]
    public DateTime Date { get; set; }

    [JsonProperty("rates")]
    public Dictionary<string, double> Rates { get; set; }

    [JsonProperty("success")]
    public bool Success { get; set; }

    [JsonProperty("timestamp")]
    public long Timestamp { get; set; }
  }
}
