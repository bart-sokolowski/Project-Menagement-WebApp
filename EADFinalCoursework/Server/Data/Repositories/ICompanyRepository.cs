using EADFinalCoursework.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EADFinalCoursework.Server.Data.Repositories
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {

        public bool Any(Guid id);
    }
}
