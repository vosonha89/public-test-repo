using Test003.Presentation.APIs.Phone.Dtos;

namespace Test003.Core.Application.Interfaces;

/// <summary>
/// IPhone Service
/// </summary>
public interface IPhoneService
{
    /// <summary>
    /// Register phone
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<PhoneResponseDto> RegisterPhoneAsync(PhoneRegisterRequestDto request);
}