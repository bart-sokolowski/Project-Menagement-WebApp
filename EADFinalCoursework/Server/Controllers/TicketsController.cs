using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EADFinalCoursework.Server.Data;
using EADFinalCoursework.Shared;
using EADFinalCoursework.Server.Data.Repositories;

namespace EADFinalCoursework.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketsController(ApplicationDbContext context, ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        // Read Tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTicketDataset()
        {
            var items = await _ticketRepository.GetAllAsync();
            return items.ToList();
        }


        // GET Single Ticket
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> ReadTicket(Guid id)
        {
            var ticket = await _ticketRepository.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            } 

            return ticket;
        }

        // Create Ticket
        [HttpPost]
        public async Task<ActionResult<Ticket>> CreateTicket(Ticket ticket)
        {
            _ticketRepository.Add(ticket);
            await _ticketRepository.SaveChangesAsync();

            return CreatedAtAction("GetTicket", new { id = ticket.Id }, ticket);
        }

        // Update Ticket
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(Guid id, Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return BadRequest();
            }

            _ticketRepository.Update(ticket);


            try
            {
                await _ticketRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // Delete Ticket
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(Guid id)
        {
            var ticket = await _ticketRepository.FindAsync(id);
            _ticketRepository.Delete(ticket);
            await _ticketRepository.SaveChangesAsync();


            return NoContent();
        }



        private bool TicketExists(Guid id)
        {
            return _ticketRepository.Any(id);
        }
    }
}
