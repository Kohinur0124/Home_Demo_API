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
    public class StaffEmployeeRepository : IStaffEmployeeRepository
    {
        private readonly DataDemo dbContext;
        public IMapper Mapper { get; set; }

        public StaffEmployeeRepository(DataDemo dataDemo , IMapper mapper)
        {
            dbContext = dataDemo;
            Mapper = mapper;
        }

        public async Task Create(CreateStaffEmployeeViewModel obj)
        {
            var staffemployee = Mapper.Map<StaffEmoloyee>(obj);
            staffemployee.Id = new Guid();
            await dbContext.StaffEmoloyees.AddAsync(staffemployee);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var staffemployee = await dbContext.StaffEmoloyees.FirstOrDefaultAsync(com => com.Id == id);
            dbContext.StaffEmoloyees.Remove(staffemployee);
            await dbContext.SaveChangesAsync();

        }

        public  async Task<List<CreateStaffEmployeeViewModel>> Get()
        {
            var newList = new List<CreateStaffEmployeeViewModel>();
            foreach (var staffemployee in dbContext.Staffs.ToList())
            {
                newList.Add(Mapper.Map<CreateStaffEmployeeViewModel>(staffemployee));
            }
            return newList;
        }

        public async Task Update(Guid id, CreateStaffEmployeeViewModel obj)
        {
            var staffemployee = await dbContext.StaffEmoloyees.FirstOrDefaultAsync(com => com.Id == id);
            if (staffemployee is not null)
            {
                staffemployee = Mapper.Map<StaffEmoloyee>(obj);
                staffemployee.Id = id;
            }

            dbContext.StaffEmoloyees.Update(staffemployee);
            await dbContext.SaveChangesAsync();

        }
    }
}
