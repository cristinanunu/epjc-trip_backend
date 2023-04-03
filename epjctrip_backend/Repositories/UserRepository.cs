using epjctrip_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace epjctrip_backend.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TripContext _userContext;

    public UserRepository(TripContext context)
    {
        _userContext = context;
    }

    public async Task<User> Create(User user)
    {
        var createUser = _userContext.User.Add(user);
        await _userContext.SaveChangesAsync();
        return createUser.Entity;
    }

    public async Task<ActionResult<User>> GetOne(int id)
    {
        return await _userContext.User.Include(user => user.Plans).FirstOrDefaultAsync(user => user.Id == id);
    }

    public Task<User?> Login(LoginRequest request)
    {
        var user =  _userContext.User.FirstOrDefaultAsync(user =>
            user.Email == request.Email && user.Password == request.Password).Result;

        return Task.FromResult(user);
    }
    
}