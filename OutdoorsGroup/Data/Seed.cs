using Microsoft.AspNetCore.Identity;
using OutdoorsGroup.Data.Enum;
using OutdoorsGroup.Data;
using OutdoorsGroup.Models;


namespace RunGroopWebApp.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Clubs.Any())
                {
                    context.Clubs.AddRange(new List<Club>()
                    {
                        new Club()
                        {
                            Title = "Running Club 1",
                            Image = "https://i.imgur.com/vELEujh.jpg",
                            Description = "Here in this club you will find other peer to compete with",
                            ClubCategory = ClubCategory.City,
                            Address = new Address()
                            {
                                Street = "Wall Str 3",
                                City = "Los Angeles",
                                State = "NY"
                            }
                         },
                        new Club()
                        {
                            Title = "Running Club 2",
                            Image = "https://i.imgur.com/vELEujh.jpg",
                            Description = "Here in this club you will find other peer to compete with",
                            ClubCategory = ClubCategory.Endurance,
                            Address = new Address()
                            {
                                Street = "Wine Str 3",
                                City = "Los Angeles",
                                State = "NY"
                            }
                        },
                        new Club()
                        {
                            Title = "Running Club 3",
                            Image = "https://i.imgur.com/vELEujh.jpg",
                            Description = "Best fitness and running club in town",
                            ClubCategory = ClubCategory.Trail,
                            Address = new Address()
                            {
                                Street = "Milk Str 3",
                                City = "Los Angeles",
                                State = "NY"
                            }
                        },
                        new Club()
                        {
                            Title = "Running Club 3",
                            Image = "https://i.imgur.com/vELEujh.jpg",
                            Description = "Best fitness and running club in town",
                            ClubCategory = ClubCategory.City,
                            Address = new Address()
                            {
                                Street = "Ark Str 3",
                                City = "Michigan",
                                State = "NY"
                            }
                        }
                    }
                    );

                    context.SaveChanges();
                }
                //Races
                if (!context.Races.Any())
                {
                    context.Races.AddRange(new List<Race>()
                    {
                        new Race()
                        {
                            Title = "Running Race 1",
                            Image = "https://i.imgur.com/vELEujh.jpg",
                            Description = "This is the description of the first race",
                            RaceCategory = RaceCategory.Marathon,
                            Address = new Address()
                            {
                                Street = "King Str 3",
                                City = "Los Angeles",
                                State = "NY"
                            }
                        },
                        new Race()
                        {
                            Title = "Running Race 2",
                            Image = "https://i.imgur.com/vELEujh.jpg",
                            Description = "This is the description of the first race",
                            RaceCategory = RaceCategory.UltraMarathon,
                            AddressId = 5,
                            Address = new Address()
                            {
                                Street = "King Str 3",
                                City = "Los Angeles",
                                State = "NY"
                            }
                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "alin.iluca95@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "aliniluca",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            Street = "ArrowStr",
                            City = "NewYork",
                            State = "NY"
                        }
                    };
                    await userManager.CreateAsync(newAdminUser, "Outdoors2023?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "alin.iluca@gmail.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        UserName = "alin",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            Street = "Arrow Street",
                            City = "NetYork",
                            State = "NY"
                        }
                    };
                    await userManager.CreateAsync(newAppUser, "Outdoors2023?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}