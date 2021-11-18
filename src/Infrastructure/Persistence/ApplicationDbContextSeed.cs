using ExchangeAGram.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ExchangeAGram.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUsersAsync(ApplicationDbContext context, IHashService _hashService)
        {
            var users = await context.Users.ToListAsync();

            if (users.Count > 0) 
            {
                return;
            }

            await context.Users.AddAsync(new Domain.Entities.User
            {
                Active = true,
                Email = "admin.haha.co.za",
                Username = "admin",
                Password = _hashService.Hash("admin")
            });

            await context.SaveChangesAsync();
        }
    }
}
