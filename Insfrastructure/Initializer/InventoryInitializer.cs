
using Infrastructure.Entities;
using Insfrastructure.Entities.Localisation;
using Insfrastructure.Entities.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



namespace Insfrastructure.Initialiser
{
    public static class InventoryInitializer
    {
        public static void Seed(FsContext context, IPasswordHasher<User> _passwordHasher)
        {
            try
            {
                context.Database.EnsureCreated();

                /*=========================== Localization initialization ================================*/

                if (!context.Countries.Any())
                {
                    context.Countries.AddRange(Parameters.userCountries);
                    context.SaveChanges();
                }
                if (!context.Regions.Any())
                {
                    context.Regions.AddRange(Parameters.Regions);
                    context.SaveChanges();
                }
                if (!context.Divisions.Any())
                {
                    context.Divisions.AddRange(Parameters.UserDivisions);
                    context.SaveChanges();
                }
                if (!context.SubDivisions.Any())
                {
                    context.SubDivisions.AddRange(Parameters.UserSubDivisions);
                    context.SaveChanges();
                }

                
                /*=========================== Modules initialization ================================*/

                if (!context.Modules.Any())
                {
                    context.Modules.AddRange(Parameters.Modules);
                    context.SaveChanges();
                }



                /*=========================== Menus initialization ==================================*/


                if (!context.Menus.Any())
                {
                    context.Menus.AddRange(Parameters.Menus);
                    context.SaveChanges();

                }


                // /*=========================== SubMenus initialization ===============================*/


                if (!context.SubMenus.Any())
                {
                    context.SubMenus.AddRange(Parameters.SubMenus);
                    context.SaveChanges();

                }

                context.SaveChanges();

                /*========================= Profile initialization===================================*/

                if (!context.Jobs.Any())
                {
                    context.Jobs.AddRange(Parameters.Jobs);
                    context.SaveChanges();

                }

                if (!context.Profiles.Any())
                {
                    context.Profiles.AddRange(Parameters.Profiles);
                    context.SaveChanges();

                }
                



                /*========================= ProfileMenus initialization==============================*/



                if (!context.ActionMenuProfiles.Any())
                {
                    context.ActionMenuProfiles.AddRange(Parameters.ActionMenuProfiles);
                    context.SaveChanges();

                }
                /*========================= ProfileSubMenus initialization===========================*/


                if (!context.ActionSubMenuProfiles.Any())
                {
                    context.ActionSubMenuProfiles.AddRange(Parameters.ActionSubMenuProfiles);
                    context.SaveChanges();

                }
                
                //context.SuperAdminActionSubMenuProfiles.AddRange(psM => Parameters.ActionSubMenuProfiles.Add(psM));
                ///*=========================== User Admin initialization =============================*/

                if (!context.Sexes.Any())
                {
                    context.Sexes.AddRange(Parameters.Sexes);
                    context.SaveChanges();

                }

                if (!context.Adresses.Any())
                {
                    context.Adresses.AddRange(Parameters.UserAdress);
                    context.SaveChanges();

                }

                if (!context.People.Any())
                {

                    Parameters.Users.ForEach(user =>
                    {
                        if (user.UserPassword != null)
                            user.UserPassword = _passwordHasher.HashPassword(user, user.UserPassword);
                    });

                    context.People.AddRange(Parameters.Users);
                    context.SaveChanges();
                }
               

            }
            catch (Exception e) { 
                Console.WriteLine(e.InnerException.ToString());
            }

            


        }
    }
}
