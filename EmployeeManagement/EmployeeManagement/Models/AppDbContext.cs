using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class AppDbContext : DbContext
    {
        //creating a AppDbContext constructor class for easiest way to pass an instance of dbcontext option
        public AppDbContext(DbContextOptions<AppDbContext> options): 
            base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
