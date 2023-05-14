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

        public static void SeedData(ApplicationDBContext context)
        {
            if (!context.Sinals.Any())
            {
                Console.WriteLine("--> Seeding Data ...");


                context.Sinals.AddRange(
                    new Signal() { Ref = "12345", Value = 50, },
                    new Signal() { Ref = "13678", Value = 80, },
                    new Signal() { Ref = "14567", Value = 100, }
                );

                context.TemporalInformation.AddRange(
                    new TemporalInformation() { SignalId = 1, Quality = 5, StreetRef = "A1", FirstDate = DateTime.Now, },
                            new TemporalInformation() { SignalId = 1, Quality = 4, StreetRef = "A4", FirstDate = DateTime.Now.AddDays(-4), RemoveDate = DateTime.Now.AddDays(-2) },
                            new TemporalInformation() { SignalId = 2, Quality = 4, StreetRef = "A4", FirstDate = DateTime.Now.AddDays(-10), },
                            new TemporalInformation() { SignalId = 3, Quality = 5, StreetRef = "A2", FirstDate = DateTime.Now, }
                    );
                context.Surveys.AddRange(new Survey() { Date = DateTime.Now, Quality = 1, TeamId = 1, TempotalInformationId = 1 },
                    new Survey() { Date = DateTime.Now.AddDays(-3), Quality = 5, TeamId = 1, TempotalInformationId = 2 },
                    new Survey() { Date = DateTime.Now, Quality = 1, TeamId = 1, TempotalInformationId = 3 },
                    new Survey() { Date = DateTime.Now, Quality = 1, TeamId = 1, TempotalInformationId = 4 }
                    );

                context.Teams.AddRange(new Team() { Name = "Equipa1" }, new Team() { Name = "Equipa2" });

                context.Technicians.AddRange(new Technician() { Name = "Henrique", PhoneNumber = "911111111", Address = "Av dos Aliados nº999", TeamId = 1 },
                    new Technician() { Name = "David", PhoneNumber = "922222222", Address = "Av dos Aliados nº998", TeamId = 2 },
                    new Technician() { Name = "Diogo", PhoneNumber = "933333333", Address = "Av dos Aliados nº997", TeamId = 2 },
                    new Technician() { Name = "João", PhoneNumber = "944444444", Address = "Av dos Aliados nº996", TeamId = 1 }
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
