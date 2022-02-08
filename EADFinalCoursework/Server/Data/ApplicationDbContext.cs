using EADFinalCoursework.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EADFinalCoursework.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Project> ProjectsDataset { get; set; }
        public DbSet<Ticket> TicketDataset { get; set; }
        public DbSet<Employee> EmployeeDataset { get; set; }
        public DbSet<Company> CompanyDataset { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
