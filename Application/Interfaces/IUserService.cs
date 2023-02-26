using Application.DTOs;
using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task CreateUserAsync(User user);
        Task<UserDto> AuthenticateAsync(string username, string password);
    }
}