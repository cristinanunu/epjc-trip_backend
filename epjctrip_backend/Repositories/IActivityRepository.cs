using epjctrip_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace epjctrip_backend.Repositories;

public interface IActivityRepository 
{
    Task<ActionResult<IEnumerable<Plan>>> GetAll(); 
}