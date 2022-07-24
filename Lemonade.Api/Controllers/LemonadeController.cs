using Lemonade.Api.ViewModels.Lemonade;
using Lemonade.Application.Mappers;
using Lemonade.Application.Models;
using Lemonade.Application.Providers;
using Lemonade.Domain.Shared;
using MandateThat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using Swashbuckle.Swagger.Annotations;

namespace Lemonade.Api.Controllers;

[AllowAnonymous]
[ApiController]
[Route("lemonade")]
public class LemonadeController : ControllerBase
{
    public LemonadeController(
        LemonadeProvider lemonadeProvider,
        ILogger<LemonadeController> logger,
        IMapper<LemonadeModel, LemonadeViewModel> lemonadeMapper)
    {
        Mandate.That(lemonadeProvider, nameof(lemonadeProvider)).IsNotNull();
        Mandate.That(logger, nameof(logger)).IsNotNull();

        LemonadeProvider = lemonadeProvider;
        Log = logger;
        LemonadeMapper = lemonadeMapper;
    }

    private LemonadeProvider LemonadeProvider { get; }
    private ILogger Log { get; }
    private IMapper<LemonadeModel, LemonadeViewModel> LemonadeMapper { get; }

    [HttpGet]
    [SwaggerResponse(200, type: typeof(long))]
    [SwaggerOperation(Tags = new[] { "Lemonade" })]
    public async Task<IActionResult> GetAsync([FromQuery] SieveModel sieveModel)
    {
        Mandate.That(sieveModel, nameof(sieveModel)).IsNotNull();

        try
        {
            var lemonadeViewModels = await LemonadeProvider
                .GetAsync(sieveModel, Request.HttpContext.RequestAborted)
                .ConfigureAwait(false);

            return Ok(new ListResultsDto<LemonadeViewModel>
            {
                Items = lemonadeViewModels.Items.Select(x => LemonadeMapper.Map(x))?.ToList(),
                TotalCount = lemonadeViewModels.TotalCount
            });
        }
        catch (Exception e)
        {
            Log.LogError(e.Message, e);

            return StatusCode(500);
        }
    }

    [HttpPost]
    [SwaggerResponse(200, type: typeof(string))]
    [SwaggerOperation(Tags = new[] { "Lemonade" })]
    public async Task<IActionResult> CreateAsync([FromBody] LemonadeCreateViewModel lemonadeCreateViewModel)
    {
        Mandate.That(lemonadeCreateViewModel, nameof(lemonadeCreateViewModel)).IsNotNull();

        try
        {
            var lemonadeId = await LemonadeProvider
                .CreateAsync(new LemonadeModel
                {
                    Name = lemonadeCreateViewModel.Name,
                    AvailableSizes = lemonadeCreateViewModel.AvailableSizes.Select(x => new LemonadeSizeModel
                    {
                        Size = x.Size,
                        Price = x.Price
                    }).ToList()
                }, Request.HttpContext.RequestAborted)
                .ConfigureAwait(false);

            return Created($"lemonades/{lemonadeId}", lemonadeId);
        }
        catch (Exception ex)
        {
            Log.LogError(ex.Message, ex);

            return StatusCode(500);
        }
    }
}