using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reactivities.Domain;
using Reactivities.Persistence;

namespace Reactivities.API.Controllers
{

    public class ActivitiesController : BaseAPIController
    {
        private readonly DataContext _context;
        public ActivitiesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] //api/Activities
        public async Task<ActionResult<IList<Activity>>> GetActivities()
        {
            return await _context.Activities.ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            var data = _context.Activities.FindAsync(id).GetAwaiter().GetResult();
            if (data !=null)
            {
                return data;
            }
            return NotFound();
        }
    }
}
