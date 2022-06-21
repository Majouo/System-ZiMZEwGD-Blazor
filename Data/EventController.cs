using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace System_ZiMZEwGD_Blazor.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;


        public EventController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<List<EventDeviceHandler>> Get()
        {
            return await _dbContext.EventDeviceHandler.ToListAsync();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<bool> Create([FromBody] EventDeviceHandler employee)
        {
            if (ModelState.IsValid)
            {
                //employee.type = Guid.NewGuid().ToString();
                _dbContext.Add(employee);
                try
                {
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                catch (DbUpdateException)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        [HttpGet]
        [Route("Details/{id}")]
        public async Task<EventDeviceHandler> Details(string id)
        {
            return await _dbContext.EventDeviceHandler.FindAsync(id);
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<bool> Edit(string id, [FromBody] EventDeviceHandler employee)
        {
            if (id != employee.Name)
            {
                return false;
            }

            _dbContext.Entry(employee).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<bool> DeleteConfirmed(string id)
        {
            var employee = await _dbContext.EventDeviceHandler.FindAsync(id);
            if (employee == null)
            {
                return false;
            }

            _dbContext.EventDeviceHandler.Remove(employee);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
