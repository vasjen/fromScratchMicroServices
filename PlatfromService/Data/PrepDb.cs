using PlatfromService.Models;

namespace PlatfromService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using ( var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }

        }

        private static void SeedData (AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("=> Seedong Data");
                context.Platforms.AddRange(
                    new Platform{Name="DotNet",Publisher="Microsoft", Cost="Free"},
                    new Platform{Name="PHP",Publisher="FaceBook", Cost="Free"},
                    new Platform{Name="GoLang",Publisher="Google", Cost="Free"}
                );
                context.SaveChanges();
            }
            else{
                System.Console.WriteLine("We already have a data");
            }
        }

    }
}