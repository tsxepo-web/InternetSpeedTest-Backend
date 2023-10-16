using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetSpeedTest.Infrastructure.Models.Entities;

namespace InternetSpeedTest.Infrastructure.Abstract
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);
        Task<IEnumerable<User>> GetUsersAsync();
    }
}