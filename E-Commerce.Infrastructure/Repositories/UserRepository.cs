using Dapper;
using E_Commerce.Core.DTO;
using E_Commerce.Core.Entities;
using E_Commerce.Core.RepositoryContracts;
using E_Commerce.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperDbContext _dbContext;
        public UserRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            user.UserId = Guid.NewGuid();
            string query = "INSERT INTO public.\"Users\"(\"UserId\", \"Email\", \"Password\", \"PersonName\", \"Gender\") VALUES(@UserId, @Email, @Password, @PersonName, @Gender)";

            int rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(query, user);
            if (rowCountAffected > 0)
            {
                return user;
            }
            else
            {
                return null;
            }
        }
        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {
            string? query = "SELECT * FROM public.\"Users\" WHERE \"Email\" = @Email AND \"Password\" = @Password";
            var parameters = new { Email = email, Password = password };
            var result = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);

            return result;
        }
    }
}
