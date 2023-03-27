using epjctrip_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace epjctrip_backend.Repositories;

public interface IPlanRepository
{
    Task<ActionResult<IEnumerable<Plan>>> GetAll();
    Task<Plan> GetById(int id);
    Task<Plan> Create(Plan plan);
    Task<Plan> UpdatePlan(Plan plan);
    void Delete(int id);
}