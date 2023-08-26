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
    public class StaffRepository : IStaffRepository
    {
        private readonly DataDemo dbContext;
        public IMapper Mapper { get; set; }

        public StaffRepository(DataDemo dataDemo,IMapper mapper)
        {
            dbContext = dataDemo;
            Mapper = mapper;
        }

        public async Task Create(CreateStaffViewModel obj)
        {
            var staff = Mapper.Map<Staff>(obj);
            staff.Id = new Guid();
            await dbContext.Staffs.AddAsync(staff);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var staff = await dbContext.Staffs.FirstOrDefaultAsync(com => com.Id == id);
            dbContext.Staffs.Remove(staff);
            await dbContext.SaveChangesAsync();
            var nlist = dbContext.StaffEmoloyees.Where(employee => employee.StaffId == id).ToList();
            foreach (var item in nlist)
            {
                dbContext.StaffEmoloyees.Remove(item);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<CreateStaffViewModel>> Get()
        {
            var newList = new List<CreateStaffViewModel>();
            foreach (var staff in dbContext.Staffs.ToList())
            {
                newList.Add(Mapper.Map<CreateStaffViewModel>(staff));
            }
            return newList;
        }

        public async Task Update(Guid id, CreateStaffViewModel obj)
        {
            var staff = await dbContext.Staffs.AsNoTracking().FirstOrDefaultAsync(com => com.Id == id);
            if (staff is not null)
            {
                staff = Mapper.Map<Staff>(obj);
                staff.Id = id;
            }

            dbContext.Staffs.Update(staff);
            await dbContext.SaveChangesAsync();
        }
    }
}
