using EADFinalCoursework.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EADFinalCoursework.Server.Data.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        public bool Any(Guid id);
    }
}
