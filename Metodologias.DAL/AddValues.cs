using Metodologias.Infrastracture.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodologias.DAL
{
    public static class AddValues
    {

        public static void AddValuesToMemory(IApplicationBuilder app)
        {
            using (var serviceScoped = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScoped.ServiceProvider.GetService<ApplicationDBContext>());
            }
        }

        private static void SeedData(ApplicationDBContext context)
        {
            if (!context.Sinals.Any())
            {
                Console.WriteLine("--> Seeding Data ...");

                context.Sinals.AddRange(
                    new Signal() { Ref = "12345", Value = 50, StreetRef = "A1", PutDate = DateTime.Now, FinalDate = null },
                    new Signal() { Ref = "13678", Value = 80, StreetRef = "A1", PutDate = DateTime.Now, FinalDate = null },
                    new Signal() { Ref = "14567", Value = 100, StreetRef = "A1", PutDate = DateTime.Now, FinalDate = null }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}
