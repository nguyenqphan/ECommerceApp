using AutoMapper;
using ECommerce.Application.DTOs.Authentication;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Application.Features.Authentication.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthResponseDto>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public RegisterCommandHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<AuthResponseDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.RegisterRequest.Email);
            if (existingUser != null)
                throw new Exception("Email already exists.");

            var user = new AppUser
            {
                FullName = request.RegisterRequest.FullName,
                Email = request.RegisterRequest.Email,
                UserName = request.RegisterRequest.Email
            };

            var result = await _userManager.CreateAsync(user, request.RegisterRequest.Password);
            if (!result.Succeeded)
                throw new Exception("Failed to create user.");

            await _userManager.AddToRoleAsync(user, request.RegisterRequest.Role);

            return new AuthResponseDto
            {
                UserId = user.Id,
                Email = user.Email!,
                Role = request.RegisterRequest.Role,
                Token = "" // Placeholder, add real JWT later
            };
        }
    }
}
