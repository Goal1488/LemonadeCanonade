using Lemonade.Api.ViewModels.Lemonade;
using Lemonade.Application.Exceptions;
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
        IMapper<LemonadeModel, LemonadeViewModel> lemonadeModelMapper,
        IMapper<LemonadeViewModel, LemonadeModel> lemonadeViewModelMapper)
    {
        Mandate.That(lemonadeProvider, nameof(lemonadeProvider)).IsNotNull();
        Mandate.That(logger, nameof(logger)).IsNotNull();

        LemonadeProvider = lemonadeProvider;
        Log = logger;
        LemonadeModelMapper = lemonadeModelMapper;
        LemonadeViewModelMapper = lemonadeViewModelMapper;
    }

    private LemonadeProvider LemonadeProvider { get; }
    private ILogger Log { get; }
    private IMapper<LemonadeModel, LemonadeViewModel> LemonadeModelMapper { get; }
    private IMapper<LemonadeViewModel, LemonadeModel> LemonadeViewModelMapper { get; }

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
                Items = lemonadeViewModels.Items.Select(x => LemonadeModelMapper.Map(x))?.ToList(),
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
    public async Task<IActionResult> CreateAsync([FromBody] LemonadeViewModel lemonadeViewModel)
    {
        Mandate.That(lemonadeViewModel, nameof(lemonadeViewModel)).IsNotNull();

        try
        {
            var lemonadeModel = LemonadeViewModelMapper.Map(lemonadeViewModel);

            var lemonadeId = await LemonadeProvider
                .CreateAsync(lemonadeModel, Request.HttpContext.RequestAborted)
                .ConfigureAwait(false);

            return Created($"lemonades/{lemonadeId}", lemonadeId);
        }
        catch (Exception ex)
        {
            Log.LogError(ex.Message, ex);

            return StatusCode(500);
        }
    }

    [HttpPut]
    [SwaggerResponse(200, type: typeof(string))]
    [SwaggerOperation(Tags = new[] { "Lemonade" })]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid lemonadeId,
        [FromBody] LemonadeViewModel lemonadeViewModel)
    {
        Mandate.That(lemonadeViewModel, nameof(lemonadeViewModel)).IsNotNull();
        Mandate.That(lemonadeViewModel, nameof(lemonadeViewModel)).IsNotNull();

        try
        {
            var lemonadeModel = LemonadeViewModelMapper.Map(lemonadeViewModel);

            await LemonadeProvider
                .UpdateAsync(lemonadeId, lemonadeModel, Request.HttpContext.RequestAborted)
                .ConfigureAwait(false);

            return Ok();
        }
        catch (Exception ex)
        {
            Log.LogError(ex.Message, ex);

            return StatusCode(500);
        }
    }

    [HttpDelete]
    [SwaggerResponse(200)]
    [SwaggerOperation(Tags = new[] { "Lemonade" })]
    public async Task<IActionResult> DeleteAsync([FromQuery] Guid lemonadeId)
    {
        try
        {
            await LemonadeProvider.DeleteAsync(lemonadeId, Request.HttpContext.RequestAborted).ConfigureAwait(false);

            return Ok();
        }
        catch (EntityIsNotFoundException ex)
        {
            Log.LogError(ex.Message, ex);

            return BadRequest();
        }
    }
}