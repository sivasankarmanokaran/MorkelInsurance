using Insurance.Repository.DbContexts.Models;

namespace Insurance.Repository.DbContexts
{
    public static class DataSeeder
    {
        public static void SeedData(InsuranceDbContext dbContext)
        {
            if (!dbContext.Companies.Any())
            {
                dbContext.Companies.AddRange(new Company
                {
                    Id = 1,
                    Name = "Markel",
                    Active = true,
                    Address1 = "2nd Floor",
                    Address2 = "Verity House",
                    Address3 = "6 Canal Wharf",
                    Country = "England",
                    PostCode = "LS11 5AS",
                    InsuranceEndDate = DateTime.Now.AddYears(-1),
                },
                 new Company
                 {
                     Id = 2,
                     Name = "Royal London",
                     Active = true,
                     Address1 = "1nd Floor",
                     Address2 = "Corporation street",
                     Address3 = "",
                     Country = "Manchester",
                     PostCode = "M4 4AB",
                     InsuranceEndDate = DateTime.Now.AddYears(2),
                 });

                dbContext.Claims.AddRange(
                    new Claim()
                    {
                        Id = 100,
                        UCR = "10000",
                        ClaimDate = DateTime.Now.AddDays(-30),
                        LossDate = DateTime.Now.AddDays(-30),
                        Assured_Name = "Jack",
                        Incurred_Loss = 5000,
                        CompanyId = 1,
                        Closed = true
                    },
                    new Claim()
                    {
                        Id = 101,
                        UCR = "20000",
                        ClaimDate = DateTime.Now.AddDays(-50),
                        LossDate = DateTime.Now.AddDays(-50),
                        Assured_Name = "michele",
                        Incurred_Loss = 300,
                        CompanyId = 1,
                        Closed = true
                    });


                dbContext.SaveChanges();

            }
        }
    }
}
