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
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;

        public CompaniesController(ApplicationDbContext context, ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        // GET all Companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanyDataset()
        {
            var items = await _companyRepository.GetAllAsync();
            return items.ToList();
        }

        // GET single Company
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> ReadCompany(Guid id)
        {
            var company = await _companyRepository.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }

        // Create Employee
        [HttpPost]
        public async Task<ActionResult<Company>> CreateProject(Company company)
        {
            _companyRepository.Add(company);
            await _companyRepository.SaveChangesAsync();

            return CreatedAtAction("GetCompany", new { id = company.Id }, company);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(Guid id, Company company)
        {
            if (id != company.Id)
            {
                return BadRequest();
            }


            _companyRepository.Update(company);

            try
            {

                await _companyRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
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

        private bool CompanyExists(Guid id)
        {
            return _companyRepository.Any(id);
        }
    }
    }
