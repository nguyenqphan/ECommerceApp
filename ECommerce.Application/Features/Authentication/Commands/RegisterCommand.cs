using ECommerce.Application.DTOs.Authentication;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.Features.Authentication.Commands
{
    public class RegisterCommand : IRequest<AuthResponseDto>
    {
        public RegisterRequestDto RegisterRequest { get; set; }

        public RegisterCommand(RegisterRequestDto registerRequest)
        {
            RegisterRequest = registerRequest;
        }
    }
}