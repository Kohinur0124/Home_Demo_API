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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataDemo dbContext;
        public IMapper Mapper { get; }
        
            
        public CompanyRepository(DataDemo appDbContext ,IMapper mapper)
        {
            this.dbContext = appDbContext;
            Mapper = mapper;
        }


        public async Task Create(CreateCompanyViewModel obj)
        {
            var company = Mapper.Map<Company>(obj);
            company.Id = new Guid();
            await dbContext.Companies.AddAsync(company);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var company = await dbContext.Companies.FirstOrDefaultAsync(com => com.Id == id);
            dbContext.Companies.Remove(company);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<CreateCompanyViewModel>> Get()
        {
            var newList = new List<CreateCompanyViewModel>();
            foreach(var company in dbContext.Companies.ToList())
            {
                newList.Add(Mapper.Map<CreateCompanyViewModel>(company));
            }
            return newList;
            
        }

        public async Task Update(Guid id, CreateCompanyViewModel obj)
        {
            var company = await dbContext.Companies.FirstOrDefaultAsync(com => com.Id == id);
            if (company is not null) 
            {
                company = Mapper.Map<Company>(obj);
                company.Id = id;
            }

            dbContext.Companies.Update(company);
            await dbContext.SaveChangesAsync();

        }
    }
}
