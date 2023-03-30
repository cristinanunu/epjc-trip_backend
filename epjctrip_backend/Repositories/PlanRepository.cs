using epjctrip_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;

namespace epjctrip_backend.Repositories;

public class PlanRepository : IPlanRepository
{
    private readonly TripContext _dbTripContext;

    public PlanRepository(TripContext dbTripContext)
    {
        _dbTripContext = dbTripContext;
    }

    public async Task<ActionResult<IEnumerable<Plan>>> GetAll()
    {
        return await _dbTripContext.Plan.Include(plan => plan.Activities).ToListAsync();
    }

    public async Task<Plan> GetById(int id)
    {
        // return await _dbTripContext.Plan.Include(plan => plan.Activities).FirstAsync();
        return await _dbTripContext.Plan.Include(plan => plan.Activities).FirstOrDefaultAsync(plan => plan.Id == id);
    }

    public async Task<Plan> Create(Plan plan)
    {
        var addPlan = _dbTripContext.Plan.Add(plan);
        await _dbTripContext.SaveChangesAsync();
        return addPlan.Entity;
    }

    public async Task<Plan> UpdatePlan(Plan plan)
    {
        var updatedPlan = _dbTripContext.Plan.Update(plan);
        await _dbTripContext.SaveChangesAsync();
        return updatedPlan.Entity;
    }

    public void Delete(int id)
    {
        var plan = _dbTripContext.Plan.Find(id);

        if (plan == null)
        {
            return;
        }

        foreach (var activity in _dbTripContext.Activity.Where(activity => activity.PlanId == id))
        {
            _dbTripContext.Activity.Remove(activity);
        }
        
        _dbTripContext.Plan.Remove(plan);
        _dbTripContext.SaveChanges();
    }
}