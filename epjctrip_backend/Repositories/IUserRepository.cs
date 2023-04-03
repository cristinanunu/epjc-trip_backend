using epjctrip_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace epjctrip_backend.Repositories;

public interface IUserRepository
{
    Task<User> Create(User user);

    Task<User?> Login(LoginRequest request);
    
    Task<ActionResult<User>> GetOne(int id);
}