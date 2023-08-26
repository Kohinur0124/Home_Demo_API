using AutoMapper;
using Base.Models;
using Microsoft.EntityFrameworkCore;
using Services.DataContext;
using Services.Interfaces;
using Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataDemo dbContext;
        public IMapper Mapper { get; set; } 

        public EmployeeRepository(DataDemo dataDemo,IMapper mapper)
        {
            dbContext = dataDemo;
            Mapper = mapper;
        }
        public async Task Create(CreateEmoloyeeViewModel obj)
        {
            var employee = Mapper.Map<Employee>(obj);
            employee.Id = new Guid();
            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {

            var employee = await dbContext.Employees.FirstOrDefaultAsync(com => com.Id == id);
            dbContext.Employees.Remove(employee);
            var nlist = dbContext.StaffEmoloyees.Where(employee => employee.EmployeeId == id).ToList();
            foreach (var item in nlist)
            {
                dbContext.StaffEmoloyees.Remove(item);
                await dbContext.SaveChangesAsync();
            }

            await dbContext.SaveChangesAsync();

        }

        public async Task<List<CreateEmoloyeeViewModel>> Get()
        {
            var newList = new List<CreateEmoloyeeViewModel>();
            foreach (var employee in dbContext.Staffs.ToList())
            {
                newList.Add(Mapper.Map<CreateEmoloyeeViewModel>(employee));
            }
            return newList;
        }

        public async Task Update(Guid id, CreateEmoloyeeViewModel obj)
        {
            var employee = await dbContext.Employees.AsNoTracking().FirstOrDefaultAsync(com => com.Id == id);
            if (employee is not null)
            {
                employee = Mapper.Map<Employee>(obj);
                employee.Id = id;
            }

            dbContext.Employees.Update(employee);
            await dbContext.SaveChangesAsync();

        }
    }
}
