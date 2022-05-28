using Employee_Crud_Operation.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Crud_Operation.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Employees.Any())
                {
                    context.Employees.AddRange(new Employee()
                    {
                        Name = "rayhan",
                        Gender = "male",
                        Age = 22,
                        Designation = "HR Department",
                        Salary = 12000,
                    },
                    new Employee()
                    {
                        Name = "ashik",
                        Gender = "male",
                        Age = 23,
                        Designation = "CS Department",
                        Salary = 14000,
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
