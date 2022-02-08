using EADFinalCoursework.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EADFinalCoursework.Server.Data.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public bool Any(Guid id)
        {
            return _dbContext.ProjectsDataset.Any(t => t.Id == id);
        }
    }
}
