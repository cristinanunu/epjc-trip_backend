using epjctrip_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace epjctrip_backend.Repositories;

public class ActivityRepository : IActivityRepository
{
    public Task<ActionResult<IEnumerable<Plan>>> GetAll()
    {
        throw new NotImplementedException();
    }
}