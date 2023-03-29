using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using epjctrip_backend.Models;
using epjctrip_backend.Repositories;

namespace epjctrip_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlansController : ControllerBase
    {
        private readonly IPlanRepository _planRepository;
        
        public PlansController(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        // GET: api/Plans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plan>>> GetPlan()
        {
            if (_planRepository != null)
            {
                return await _planRepository.GetAll();
            }

            return NotFound();
        }

        // GET: api/Plans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Plan>> GetPlan(int id)
        {
            var planFromDb = await _planRepository.GetById(id);
            if (planFromDb != null)
            {
                return planFromDb;
            }

            return NotFound();
        }
        
        // POST: api/Plans
        [HttpPost]
        public async Task<ActionResult<Plan>> PostPlan(PlanRequest plan)
        {
            var savedPlan = await _planRepository.Create(new Plan
            {
                Name = plan.Name,
                StartDate = plan.StartDate,
                EndDate = plan.EndDate,
                Destination = plan.Destination,
                Departure = plan.Departure,
                Participants = plan.Participants,
                Cost = plan.Cost
            });
            
            var actionName = nameof(GetPlan);
            var routeValue = new { id = savedPlan.Id };
            return CreatedAtAction(actionName, routeValue, savedPlan);
        }

        // PUT: api/Plans/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Plan>> PutPlan(int id, PlanRequest plan)
        {
            var planFromDb = await _planRepository.GetById(id);
            if (planFromDb == null)
            {
                return NotFound();
            }
            
            planFromDb.Name = plan.Name;
            planFromDb.StartDate = plan.StartDate;
            planFromDb.EndDate = plan.EndDate;
            planFromDb.Destination = plan.Destination;
            planFromDb.Departure = plan.Departure;
            planFromDb.Participants = plan.Participants;
            planFromDb.Cost = plan.Cost;

            await _planRepository.UpdatePlan(planFromDb);
            return planFromDb;
        }

        // [HttpPut("{id}/activities")]
        // public async Task<ActionResult<Plan>> AddActivitiesToPlan(int id, Activity activity)
        // {
        //     var planFromDb = await _planRepository.GetById(id);
        //     if (planFromDb == null)
        //     {
        //         return NotFound();
        //     }
        //     planFromDb.Activities.Add(activity);
        //     await _planRepository.UpdatePlan(planFromDb);
        //     return planFromDb;
        // }

        

        // DELETE: api/Plans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlan(int id)
        {
            // if (_context.Plan == null)
            // {
            //     return NotFound();
            // }
            //
            // var plan = await _context.Plan.FindAsync(id);
            // if (plan == null)
            // {
            //     return NotFound();
            // }
            //
            // _context.Plan.Remove(plan);
            // await _context.SaveChangesAsync();
            //
            // return NoContent();

            // var plan = await GetPlan(id);
            // if (plan == null)
            // {
            //     return NotFound();
            // }
            _planRepository.Delete(id);
            return NoContent();
        }
    }
}