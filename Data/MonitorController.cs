﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace System_ZiMZEwGD_Blazor.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitorController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;


        public MonitorController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<List<Monitor>> Get()
        {
            return await _dbContext.Monitor.ToListAsync();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<bool> Create([FromBody] Monitor employee)
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
        public async Task<Monitor> Details(string id)
        {
            return await _dbContext.Monitor.FindAsync(id);
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<bool> Edit(uint id, [FromBody] Monitor employee)
        {
            if (id != employee.ID)
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
            var employee = await _dbContext.Monitor.FindAsync(id);
            if (employee == null)
            {
                return false;
            }

            _dbContext.Monitor.Remove(employee);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
