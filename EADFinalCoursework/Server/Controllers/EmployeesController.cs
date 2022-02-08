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
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(ApplicationDbContext context, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET all Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeDataset()
        {
          var item = await _employeeRepository.GetAllAsync();
            return item.ToList();
        }

        // GET single Employee
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> ReadEmployee(Guid id)
        {


            var employee = await _employeeRepository.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // Create Employee
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateProject(Employee employee)
        {
            _employeeRepository.Add(employee);
            await _employeeRepository.SaveChangesAsync();
            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }


            _employeeRepository.Update(employee);

            try
            {

                await _employeeRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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


        private bool EmployeeExists(Guid id)
        {
            return _employeeRepository.Any(id);
        }
    }
}
