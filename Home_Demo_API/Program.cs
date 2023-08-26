
using Home_Demo_API.AutoMapper;
using Microsoft.EntityFrameworkCore;
using Services.DataContext;
using Services.Interfaces;
using Services.Services;

namespace Home_Demo_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DataDemo>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("PostConnection")));

            builder.Services.AddAutoMapper(typeof(AppProfile))  ;
            builder.Services.AddTransient<ICompanyRepository,CompanyRepository>();
            builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddTransient<IStaffRepository,StaffRepository>();
            builder.Services.AddTransient<IStaffEmployeeRepository,StaffEmployeeRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}