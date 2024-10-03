
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
            context.Database.EnsureCreated();

            /*=========================== Localization initialization ================================*/

            if (!context.Countries.Any())
            {
                context.Countries.AddRange(Parameters.userCountries);
            }
            if (!context.Regions.Any())
            {
                context.Regions.AddRange(Parameters.Regions);
            }
            if (!context.Divisions.Any())
            {
                context.Divisions.AddRange(Parameters.UserDivisions);
            }
            if (!context.SubDivisions.Any())
            {
                context.SubDivisions.AddRange(Parameters.UserSubDivisions);
            }

            context.SaveChanges();
            /*=========================== Modules initialization ================================*/

            if (!context.Modules.Any())
            {
                context.Modules.AddRange(Parameters.Modules);
            }
            


            /*=========================== Menus initialization ==================================*/


            if (!context.Menus.Any())
            {
                context.Menus.AddRange(Parameters.Menus);
               
            }


            // /*=========================== SubMenus initialization ===============================*/


            if (!context.SubMenus.Any())
            {
                context.SubMenus.AddRange(Parameters.SubMenus);
                
            }

            context.SaveChanges();

            /*========================= Profile initialization===================================*/

            if (!context.Jobs.Any())
            {
                context.Jobs.AddRange(Parameters.Jobs);
                
            }

            if (!context.Profiles.Any())
            {
                context.Profiles.AddRange(Parameters.Profiles);
                
            }
            context.SaveChanges();



            /*========================= ProfileMenus initialization==============================*/



            if (!context.ActionMenuProfiles.Any())
            {
                context.ActionMenuProfiles.AddRange(Parameters.ActionMenuProfiles);
                
            }
            /*========================= ProfileSubMenus initialization===========================*/


            if (!context.ActionSubMenuProfiles.Any())
            {
                context.ActionSubMenuProfiles.AddRange(Parameters.ActionSubMenuProfiles);

            }
            context.SaveChanges();
            //context.SuperAdminActionSubMenuProfiles.AddRange(psM => Parameters.ActionSubMenuProfiles.Add(psM));
            ///*=========================== User Admin initialization =============================*/

            if (!context.Sexes.Any())
            {
                context.Sexes.AddRange(Parameters.Sexes);
                
            }


            if (!context.People.Any())
            {

                Parameters.Users.ForEach(user =>
                {
                    if (user.UserPassword != null)
                        user.UserPassword = _passwordHasher.HashPassword(user, user.UserPassword);
                });
              
                context.People.AddRange( Parameters.Users);
                
            }
            context.SaveChanges();


        }
    }
}
