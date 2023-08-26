using Base.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataContext
{
    public class DataDemo:DbContext
    {
        public DataDemo(DbContextOptions<DataDemo> options):base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<StaffEmoloyee> StaffEmoloyees { get; set; }


        public void SeedDataCompany (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(new List<Company>
            {
                new Company()
                {
                    Id = Guid.Parse("ab950de1-34ef-4e87-8111-fef59e38e467"),
                    Name = "Najot ta`lim",
                    Address = "Toshkent" ,
                    Email = "...",
                    Phone = "+998999999999",

                },
                new Company()
                {
                    Id= Guid.Parse("5d76e748-011f-4cb6-bc8d-2423b06bb696"),
                    Name ="Kohinur",
                    Address = "Toshkent",
                    Email = "...",
                    Phone = "+998938853616",
                },

            });
        }

        public void SeedDataStaff(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>().HasData(new List<Staff>
            {
                new Staff()
                {
                    Id= Guid.Parse("0f30f95b-6ee6-4822-8fed-f53a4084383e"),
                    Name = "O`quv bo`limi",
                },
                new Staff()
                {
                    Id = Guid.Parse("eea4ff91-2222-4e5f-a0e0-d5a2348d9efe"),
                    Name = "Moliya bo`limi",
                },
            }); ;
        }
        public void SeedDataEmployee(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(new List<Employee>
            {
                new Employee()
                {
                    Id = Guid.Parse("b1af9ed4-7cb5-47af-963e-5ce381403e00"),
                    FirstName = "Sevinch",
                    LastName = "Xayriddinova",
                    Email= "Sev@gmail.com",
                    Phone = "+998939613663",
                    CompanyId = Guid.Parse("5d76e748-011f-4cb6-bc8d-2423b06bb696"),
                   
                },

                new Employee()
                {
                    Id = Guid.Parse("ffb9a741-99b1-4e9e-a44f-5d0b111dbc37"),
                    FirstName = "Sadaf",
                    LastName = "Karimova",
                    Email= "Sadaf@gmail.com",
                    Phone = "+998994027833",
                    CompanyId = Guid.Parse("ab950de1-34ef-4e87-8111-fef59e38e467"),
                   
                }
            });
        }

        public void SeedDataStaffEmployee(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StaffEmoloyee>().HasData(new List<StaffEmoloyee> {
                new StaffEmoloyee()
                {
                    Id = Guid.Parse("a9fa9ff6-fb96-488e-a8c1-9a59767a7706"),
                    EmployeeId = Guid.Parse("b1af9ed4-7cb5-47af-963e-5ce381403e00"),
                    StaffId =  Guid.Parse("0f30f95b-6ee6-4822-8fed-f53a4084383e"),
                },
                new StaffEmoloyee()
                {
                    Id = Guid.Parse("7838b104-32d2-47ba-b02b-3871cd03cafa"),
                    EmployeeId =  Guid.Parse("ffb9a741-99b1-4e9e-a44f-5d0b111dbc37"),
                    StaffId =  Guid.Parse("0f30f95b-6ee6-4822-8fed-f53a4084383e"),
                }
            });
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedDataCompany(modelBuilder);
            SeedDataEmployee(modelBuilder);
            SeedDataStaff(modelBuilder);
            SeedDataStaffEmployee(modelBuilder); 
            base.OnModelCreating(modelBuilder);
        }


    }
}
