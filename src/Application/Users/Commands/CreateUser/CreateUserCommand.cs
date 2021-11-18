using ExchangeAGram.Application.Common.Interfaces;
using ExchangeAGram.Application.Users.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeAGram.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<UserCreateResultDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserCreateResultDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IHashService _hashService;

        public CreateUserCommandHandler(IApplicationDbContext context, IHashService hashService)
        {
            _context = context;
            _hashService = hashService;
        }

        public async Task<UserCreateResultDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var duplicateUsername = await _context.Users.AnyAsync(a => a.Username == request.Username, cancellationToken);
            if (duplicateUsername)
            {
                return new UserCreateResultDto
                {
                    Message = "User with that username already exists",
                    Success = false
                };
            }

            var duplicateEmail = await _context.Users.AnyAsync(a => a.Email == request.Email, cancellationToken);
            if (duplicateEmail)
            {
                return new UserCreateResultDto
                {
                    Message = "User with that email already exists",
                    Success = false
                };
            }

            await _context.Users.AddAsync(new Domain.Entities.User 
            {
                Email = request.Email,
                Password = _hashService.Hash(request.Password),
                Username = request.Username,
                Active = true
            }, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return new UserCreateResultDto 
            {
                Message = "User created",
                Success = true
            };
        }
    }
}
