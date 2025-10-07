using Microsoft.AspNetCore.Mvc;
using Test003.Core.Application.Interfaces;
using Test003.Presentation.APIs.Phone.Dtos;

namespace Test003.Presentation.APIs.Phone;

/// <summary>
/// Phone controller
/// </summary>
[ApiController]
[Route("api/v1/phone")]
public class PhoneController : ControllerBase
{
    private readonly ILoggingService _loggingService;
    private readonly IPhoneService _phoneService;

    public PhoneController(ILoggingService loggingService, IPhoneService phoneService)
    {
        _loggingService = loggingService;
        _phoneService = phoneService;
    }

    /// <summary>
    /// Register phone action
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("/register-phone")]
    public async Task<IActionResult> RegisterPhone(PhoneRegisterRequestDto request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var responseDto = await _phoneService.RegisterPhoneAsync(request);
            return Ok(responseDto);
        }
        catch (Exception ex)
        {
            _loggingService.Error(ex, "Error registering phone");
            return Problem(ex.Message);
        }
    }
}