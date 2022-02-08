using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EADFinalCoursework.Server.Data;
using EADFinalCoursework.Shared;
using EADFinalCoursework.Server.Data.Repositories;

namespace EADFinalCoursework.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectsController(ApplicationDbContext context, IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        // Get all Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjectsDataset()
        {
            var items =  await _projectRepository.GetAllAsync();
            return items.ToList();
        }

        // Read Project
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> ReadProject(Guid id)
        {
            var project = await _projectRepository.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }



        // Update Project
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(Guid id, Project project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }

            _projectRepository.Update(project);

            try
            {
                await _projectRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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

        // Create Project
        [HttpPost]
        public async Task<ActionResult<Project>> CreateProject(Project project)
        {
            _projectRepository.Add(project);
            await _projectRepository.SaveChangesAsync();

            return CreatedAtAction("GetProject", new { id = project.Id }, project);
        }

        // DELETE Project
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            var project = await _projectRepository.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _projectRepository.Delete(project);
            await _projectRepository.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectExists(Guid id)
        {
            return _projectRepository.Any(id);
        }
    }
}
