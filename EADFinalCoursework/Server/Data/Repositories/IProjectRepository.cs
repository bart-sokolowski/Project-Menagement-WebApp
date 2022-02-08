using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EADFinalCoursework.Shared;

namespace EADFinalCoursework.Server.Data.Repositories
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        public bool Any(Guid id);
    }
}
