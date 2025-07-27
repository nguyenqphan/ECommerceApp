using ECommerce.Application.DTOs.Authentication;
using MediatR;

namespace ECommerce.Application.Features.Authentication.Commands
{
    public class LoginCommand : IRequest<AuthResponseDto>
    {
        public LoginRequestDto LoginRequest { get; set; }

        public LoginCommand(LoginRequestDto loginRequest)
        {
            LoginRequest = loginRequest;
        }
    }
}