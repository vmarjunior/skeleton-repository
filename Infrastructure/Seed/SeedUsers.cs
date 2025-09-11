using Microsoft.EntityFrameworkCore;
using MySolution.Domain.Entities;
using System.Reflection.Emit;
using System.Text.Json;

namespace MySolution.Infrastructure.Seed
{
    public static class SeedUsers
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var userData = File.ReadAllText("../Infrastructure/Seed/Data/UserSeedData.json");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var users = JsonSerializer.Deserialize<List<User>>(userData, options);

            if (users == null) return;

            modelBuilder.Entity<User>().HasData(users);
        }
    }
}