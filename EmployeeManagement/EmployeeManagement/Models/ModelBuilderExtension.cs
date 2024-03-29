﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
               new Employee
               {
                   Id = 1,
                   Name = "Mark",
                   Department = Dept.IT,
                   Email = "mark@pragimtech.com"
               },
               new Employee
               {
                   Id = 2,
                   Name = "Alley",
                   Department = Dept.IT,
                   Email = "alley@pragimtech.com"
               }
           );
        }
     }
     
}
