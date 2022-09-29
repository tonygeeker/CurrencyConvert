using CurrencyConverterApi.Models;
using CurrencyConverterApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Description;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CurrencyConverterApi.Controllers
{
  [Route("api/currencies")]
  [ApiController]
  public class CurrencyConverterController : ControllerBase
  {
    private readonly ICurrencyConverterService _service;
    //private readonly ILogger _logger;

    public CurrencyConverterController(ICurrencyConverterService service)
    {
      _service = service;
    }

    // GET: api/currencies
    [HttpGet]
    [ResponseType(typeof(LatestExchangeRatesResponseModel))]
    public async Task<IActionResult> Get()
    {
      try
      {
        var result = await _service.GetAllCurrencyConversions();
        return Ok(result);
      }
      catch(Exception)
      {
        // log exception here
        throw;
      }
    }

    // GET api/currencies/{baseCurrency}
    [HttpGet("{baseCurrency}")]
    [ResponseType(typeof(LatestExchangeRatesResponseModel))]
    public async Task<IActionResult > Get(string baseCurrency)
    {
      try
      {
        if (baseCurrency.Length == 3)
        {
          var result = await _service.GetByBase(baseCurrency);
          return Ok(result);
        }
        else
        {
          return BadRequest();
        }
        
      }
      catch (WebException ex) 
      {
        // log exception here
        throw;
      }
    }

    // GET api/currencies/historical/{days}
    [HttpGet("historical/{days}")]
    [ResponseType(typeof(HistoricalExchangeRatesResponseMiodel))]
    public async Task<IActionResult> Get(int days)
    {
      try
      {
        var result = await _service.GetLastPastDays(days);
        return Ok(result);
      }
      catch (Exception)
      {
        // log exception here
        throw;
      }
    }

    // POST api/currencies
    [HttpPost]
    [ResponseType(typeof(CurrencyConversionResponseModel))]
    public async Task<IActionResult> Post([FromBody] CurrencyConversionRequestModel requestModel)
    {
      try
      {
        if (ModelState.IsValid)
        {
          var result = await _service.ConvertBtwnCurrencies(requestModel);
          return Ok(result);
        }
        else
        {
          return BadRequest();
        }
        
      }
      catch (Exception)
      {
        // log exception here
        throw;
      }
    }

  }
}
