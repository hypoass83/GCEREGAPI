using Domain.Models.Localisation;
using Insfrastructure.Entities.Localisation;
using Insfrastructure.Entities.Parameters;
using Insfrastructure.Entities.Security;
using System.Security.Cryptography.X509Certificates;


namespace Insfrastructure.Initialiser
{
    internal static partial class Parameters
    {

        /*====================== Modules parameters ==========================================*/
        public static Module _Security = new()
        {

            ModuleCode = "MODULE_5",
            ModuleLabel = "Security",
            ModuleDescription = "Bien fait",
            ModuleArea = "Administration",
            ModuleState = true,
            ModuleImagePath = "MOD_IMG_SECURITY",

        };
        /*Ce module est commun à tous les autres modules. On l'utilisera afin de définir les paramètres (menu de paramétrage) de chaque module*/
        private static Module _Parameters = new()
        {


            ModuleCode = "MODULE_6",
            ModuleLabel = "Paramètres",
            ModuleDescription = "Bien fait",
            ModuleArea = "Administration",
            ModuleState = true,
            ModuleImagePath = "MOD_IMG_PARAMETERS",
        };
        public static List<Module> Modules
        {
            get
            {
                return new List<Module>() { _Security,  _Parameters };
            }
        }





        /*=====================================================================================*/
        /*=========================== Menus initialization ====================================*/
        //**** Security Module
        private static Menu _Security_Profile = new Menu()
        {
            MenuLabel = "Profile",
            MenuCode = CodeValue.Security.Profile.CODE,
            MenuDescription = "Définir les profiles d'accès à l'application",
            MenuFlat = true,
            MenuIconName = "profile.png",
            MenuController = "Profile",
            MenuPath = "securityprofile",
            MenuState = true,
            Module = _Security,
            ModuleID = _Security.ModuleID
        };
        private static Menu _Security_User = new Menu()
        {
            MenuLabel = "Utilisateur",
            MenuCode = CodeValue.Security.User.CODE,
            MenuDescription = "Définir les utilisateurs de l'application",
            MenuFlat = false,
            MenuIconName = "users.png",
            MenuController = "User",
            MenuPath = "security/users",
            MenuState = true,
            Module = _Security,
            ModuleID = _Security.ModuleID
        };

        //********* Module Paramètres
        private static Menu localization = new Menu()
        {
            MenuLabel = "Localité",
            MenuCode = CodeValue.Parameter.Localization.MenuCODE,
            MenuDescription = "Définir les lieux de localisation",
            MenuFlat = true,
            MenuIconName = "localization.png",
            MenuController = "Parameter",
            MenuPath = "Parameter",
            MenuState = true,
            Module = _Parameters,
            ModuleID = _Parameters.ModuleID
        };
        


        public static List<Menu> Menus
        {
            get
            {
                return new List<Menu>()
                    {
                        _Security_Profile, _Security_User};

            }
        }
        /*=====================================================================================*/
        /*=========================== SubMenus initialization =================================*/
        //****** Utilisateur subMenus
        static SubMenu _Security_Profile_Profile = new SubMenu()
        {
            Menu = _Security_Profile,
            MenuID = _Security_Profile.MenuID,
            SubMenuCode = CodeValue.Security.Profile.CODE,
            SubMenuDescription = "sous menu",
            SubMenuLabel = "Profile",
            SubMenuController = "Profile",
            SubMenuPath = "security/profiles"

        };
        static SubMenu _Security_Profile_Advanced = new SubMenu()
        {
            Menu = _Security_Profile,
            MenuID = _Security_Profile.MenuID,
            SubMenuCode = CodeValue.Security.User.ProAvancedCODE,
            SubMenuDescription = "sous menu",
            SubMenuLabel = "Profile Avancé",
            SubMenuController = "Profile",
            SubMenuPath = "security/advanced-profiles"

        };

        //****** Localization subMenus
        //==== Sub menu country
        static SubMenu country = new SubMenu()
        {
            Menu = localization,
            MenuID = localization.MenuID,
            SubMenuCode = CodeValue.Parameter.COUNTRYCODE,
            SubMenuDescription = "sous menu",
            SubMenuLabel = "Pays",
            SubMenuController = "Parameter",
            SubMenuPath = "localization/country"

        };
        //Sub menu region
        static SubMenu region = new SubMenu()
        {
            Menu = localization,
            MenuID = localization.MenuID,
            SubMenuCode = CodeValue.Parameter.REGIONCode,
            SubMenuDescription = "sous menu",
            SubMenuLabel = "Région",
            SubMenuController = "Parameter",
            SubMenuPath = "localization/region"


        };
        //Sub menu Division
        static SubMenu Division = new SubMenu()
        {
            Menu = localization,
            MenuID = localization.MenuID,
            SubMenuCode = CodeValue.Parameter.DivisionCode,
            SubMenuDescription = "sous menu",
            SubMenuLabel = "Ville",
            SubMenuController = "Parameter",
            SubMenuPath = "localization/Division"

        };
        //Sub menu SubDivision
        static SubMenu SubDivision = new SubMenu()
        {
            Menu = localization,
            MenuID = localization.MenuID,
            SubMenuCode = CodeValue.Parameter.SubDivision,
            SubMenuDescription = "sous menu",
            SubMenuLabel = "Quartier",
            SubMenuController = "Parameter",
            SubMenuPath = "localization/SubDivision"

        };
        
        

        public static List<SubMenu> SubMenus
        {
            get
            {
                return new List<SubMenu>() { _Security_Profile_Profile, _Security_Profile_Advanced, country, region, Division, SubDivision};
            }
        }





        /*=====================================================================================*/
        /*============================== Adress initialization ================================*/
        //country
        private static Country cameroon = new Country() { CountryCode = "CMR", CountryName = "Cameroon" };
        public static List<Country> userCountries
        {
            get
            {
                return new List<Country>() { cameroon };
            }
        }

        //regions
        private static Region nordwest = new Region()
        {
            RegionCode = 1,
            RegionName = "Nord West",
            Country = cameroon,
            CountryID = cameroon.CountryID

        };
        private static Region southwest = new Region()
        {
            RegionCode = 2,
            RegionName = "South West",
            Country = cameroon,
            CountryID = cameroon.CountryID
        };
        private static Region center = new Region()
        {
            RegionCode = 3,
            RegionName = "Center",
            Country = cameroon,
            CountryID = cameroon.CountryID
        };
        private static Region littoral = new Region()
        {
            RegionCode = 4,
            RegionName = "Litoral",
            Country = cameroon,
            CountryID = cameroon.CountryID
        };
        private static Region west = new Region()
        {
            RegionCode = 5,
            RegionName = "West",
            Country = cameroon,
            CountryID = cameroon.CountryID
        };
        
        public static List<Region> Regions
        {
            get
            {
                return new List<Region>() { nordwest, southwest, center, littoral, west};
            }
        }
        

        private static Archive defaultArchive = new Archive()
        {
            FileBase64 = "",
            FileName = "",
            ContentType = ""
        };


         public static List<Archive> Archives
        {
            get
            {
                return new List<Archive>() { defaultArchive };
            }
        }

       

        /*=====================================================================================*/
        /*=========================== Profiles initialization =================================*/
        private static Profile administrator = new Profile()
        {
            ProfileCode = "admin-Dental",
            ProfileLabel = "Administrateur",
            ProfileLevel = 3,
            ProfileDescription = "Détient le contrôle sur toute l'application",
            ProfileState = true
        };

        private static Profile superAdministrator = new Profile()
        {
            ProfileCode = "Super-Admin-FSInventory",
            ProfileLabel = "Super Administrator",
            ProfileDescription = "Détient le contrôle sur toute l'application",
            ProfileState = true,
            ProfileLevel = 1,
        };

        private static Profile employee = new Profile()
        {
            ProfileCode = CodeValue.Security.Profile.ClASS_CODE,
            ProfileLabel = "Employé",
            ProfileDescription = "Un employé de la compagnie qui ne peut se connecter à l'application",
            ProfileState = false
        };
        public static List<Profile> Profiles
        {
            get
            {
                return new List<Profile>() { superAdministrator, administrator, employee };
            }
        }
        /*======================== company and Jobs initialization ============================*/

        private static Job computeristJob = new Job()
        {
            JobLabel = "Computer Engineer",
            JobDescription = "Manage Information system",
            JobCode = "Info",
        };
        private static Job ChiefOfCentreJob = new Job()
        {
            JobLabel = "Chief of Centre",
            JobDescription = "Chief of Centre",
            JobCode = "COC",
        };
        private static Job accountantJob = new Job()
        {
            JobLabel = "Accountant",
            JobDescription = "Manage Account",
            JobCode = "Accountant",
        };
       
        public static List<Job> Jobs
        {
            get
            {
                return new List<Job>() { computeristJob, accountantJob, ChiefOfCentreJob };
            }
        }
        /*=====================================================================================*/
        /*========================== ProfilesMenus initialization =============================*/
        static ActionMenuProfile adminMenu_User = new ActionMenuProfile()
        {
            Add = true,
            Delete = true,
            Update = true,
            Profile = administrator,
            ProfileID = administrator.ProfileID,
            Menu = _Security_User,
            MenuID = _Security_User.MenuID
        };

        static ActionMenuProfile adminMenu_Profile = new ActionMenuProfile()
        {
            Add = true,
            Delete = true,
            Update = true,
            Profile = administrator,
            ProfileID = administrator.ProfileID,
            Menu = _Security_Profile,
            MenuID = _Security_Profile.MenuID
        };
       
        /// <summary>
        /// Action menu for localization
        /// </summary>
        static ActionMenuProfile adminMenu_Localization = new ActionMenuProfile()
        {
            Add = true,
            Delete = true,
            Update = true,
            Profile = administrator,
            ProfileID = administrator.ProfileID,
            Menu = localization,
            MenuID = localization.MenuID
        };
        
        /// <summary>
        /// fin de la création des ActionMenuProfile en vue de préparer l'affectation des menus à l'administrateur
        /// </summary>


        public static List<ActionMenuProfile> ActionMenuProfiles
        {
            get
            {
                return new List<ActionMenuProfile>() { adminMenu_User, adminMenu_Profile, adminMenu_Localization};

            }
        }

        public static List<ActionMenuProfile> SuperAdminActionMenuProfiles
        {
            get
            {
                List<ActionMenuProfile> saMenus = new List<ActionMenuProfile>();

                foreach (ActionMenuProfile asmp in ActionMenuProfiles)
                {
                    asmp.Profile = superAdministrator;
                    asmp.ProfileID = superAdministrator.ProfileID;
                    saMenus.Add(asmp);
                }

                return saMenus;
            }
        }

        /*=====================================================================================*/
        /*========================== ProfilesSubMenus initialization ==========================*/
        //, , , , , calculate2
        static ActionSubMenuProfile adminSubMenu_User_User = new ActionSubMenuProfile()
        {
            Add = true,
            Delete = true,
            Update = true,
            Profile = administrator,
            ProfileID = administrator.ProfileID,
            SubMenu = _Security_Profile_Profile,
            SubMenuID = _Security_Profile_Profile.SubMenuID
        };
        static ActionSubMenuProfile adminSubMenu_ProfileAvanced = new ActionSubMenuProfile()
        {
            Add = true,
            Delete = true,
            Update = true,
            Profile = administrator,
            ProfileID = administrator.ProfileID,
            SubMenu = _Security_Profile_Advanced,
            SubMenuID = _Security_Profile_Advanced.SubMenuID
        };
        
        static ActionSubMenuProfile adminSubMenu_Localization_Country = new ActionSubMenuProfile()
        {
            Add = true,
            Delete = true,
            Update = true,
            Profile = administrator,
            ProfileID = administrator.ProfileID,
            SubMenu = country,
            SubMenuID = country.SubMenuID
        };
        static ActionSubMenuProfile adminSubMenu_Localization_Region = new ActionSubMenuProfile()
        {
            Add = true,
            Delete = true,
            Update = true,
            Profile = administrator,
            ProfileID = administrator.ProfileID,
            SubMenu = region,
            SubMenuID = region.SubMenuID
        };
        static ActionSubMenuProfile adminSubMenu_Localization_Division = new ActionSubMenuProfile()
        {
            Add = true,
            Delete = true,
            Update = true,
            Profile = administrator,
            ProfileID = administrator.ProfileID,
            SubMenu = Division,
            SubMenuID = Division.SubMenuID
        };
        static ActionSubMenuProfile adminSub_Localization_SubDivision = new ActionSubMenuProfile()
        {
            Add = true,
            Delete = true,
            Update = true,
            Profile = administrator,
            ProfileID = administrator.ProfileID,
            SubMenu = SubDivision,
            SubMenuID = SubDivision.SubMenuID
        };
        
        /// <summary>
        /// début de la création des ActionSubMenuProfile en vue de préparer l'affectation des sous menus à l'administrateur
        /// </summary>

        
       
        public static List<ActionSubMenuProfile> ActionSubMenuProfiles
        {
            get
            {
                return new List<ActionSubMenuProfile>() { adminSubMenu_User_User, adminSubMenu_ProfileAvanced, 
                                                          adminSubMenu_Localization_Country, adminSubMenu_Localization_Region, adminSubMenu_Localization_Division,
                                                          adminSub_Localization_SubDivision};
            }
        }

        public static List<ActionSubMenuProfile> SuperAdminActionSubMenuProfiles
        {
            get
            {
                List<ActionSubMenuProfile> saSubMenus = new List<ActionSubMenuProfile>();

                foreach (ActionSubMenuProfile asmp in ActionSubMenuProfiles)
                {
                    asmp.Profile = superAdministrator;
                    asmp.ProfileID = superAdministrator.ProfileID;
                    saSubMenus.Add(asmp);
                }

                return saSubMenus;
            }
        }



        /*============================== Users initialization =================================*/
        private static Sex masculin = new Sex() { SexCode = "M", SexLabel = "Masculin" };
        private static Sex feminin = new Sex() { SexCode = "F", SexLabel = "Feminin" };

        public static List<Sex> Sexes
        {
            get
            {
                return new List<Sex>() { feminin, masculin };
            }
        }
        /*=========================== Division =================================*/

        private static Division Division14 = new Division()
        {
            DivisionCode = 14,
            DivisionName = "Mezam",
            DivisionTag = "E",
            //Region=nordwest,
            RegionID = 1
        };

        public static List<Division> UserDivisions
        {
            get
            {
                return new List<Division>() { Division14 };
            }
        }

        /*=========================== SubDivision =================================*/

        private static SubDivision SubDivision248 = new SubDivision()
        {
            SubDivisionCode = 248,
            SubDivisionName = "Bamenda I",
            DivisionID = 3
        };

        public static List<SubDivision> UserSubDivisions
        {
            get
            {
                return new List<SubDivision>() { SubDivision248 };
            }
        }

        /*=========================== Adress =================================*/

        private static Adress adressAdmin = new Adress()
        {
            AdressCellNumber = "679209406",
            SubDivisionID = 3

        };

        public static List<Adress> UserAdress
        {
            get
            {
                return new List<Adress>() { adressAdmin };
            }
        }
        /*=====================================================================================*/

        private static User adminAccount = new User()
        {
            CNI = "12457DLA5",
            Name = "Admin",
            Description = "Admin Surname",
            Sex = masculin,
            SexID = masculin.SexID,
            IsConnected = true,
            AdressID = adressAdmin.AdressID,
            Adress = adressAdmin,
            UserAccountState = true,
            UserLogin = "dental",
            UserPassword = "password",
            UserAccessLevel = 3,
            Profile = administrator,
            ProfileID = administrator.ProfileID,
            JobID = computeristJob.JobID,
            Job = computeristJob
            
        };


        public static List<User> Users
        {
            get
            {
                return new List<User>() {  adminAccount };
            }
        }

        

        /*======================================================================================*/
        
        

        

    }
}

