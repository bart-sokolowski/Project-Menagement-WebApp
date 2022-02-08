using EADFinalCoursework.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EADFinalCoursework.Server.Data.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public bool Any(Guid id)
        {
            return _dbContext.EmployeeDataset.Any(t => t.Id == id);
        }
    }
}



