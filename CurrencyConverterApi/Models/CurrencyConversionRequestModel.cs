using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverterApi.Models
{
  public class CurrencyConversionRequestModel
  {
    [Required]
    public string FromCurrency { get; set; }
    [Required]
    public string ToCurrency { get; set; }
    [Required]
    public decimal RequestValue { get; set; }
    public DateTime? Date { get; set; }
  }
}
