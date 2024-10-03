using System;
using Domain.Models;
using Domain.Models.Security;
using Insfrastructure.Entities.Security;
using Insfrastructure.Entities.Localisation;
using Domain.Models.Localisation;
using Domain.DTO;
using Insfrastructure.Entities.Parameters;
using Domain.Models.Parameters;


namespace Insfrastructure.Mapper
{
    public class AutoMapping : AutoMapper.Profile
    {
        public AutoMapping()
        {
            // Exemple de mappage simple
            CreateMap<ProfileModel, Entities.Security.Profile>().ReverseMap();

            // Exemple de mappage avec des conversions spécifiques
            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<User, UserCreateDTO>().ReverseMap();
            CreateMap<SexModel, Sex>().ReverseMap();

            CreateMap<GlobalPerson, GlobalPersonModel>().ReverseMap();
            CreateMap<PeopleModel, People>().ReverseMap();
            CreateMap<AdressModel, Adress>().ReverseMap();
            CreateMap<AdressCreateDTO, Adress>().ReverseMap();
            CreateMap<SubDivisionModel, SubDivision>().ReverseMap();
            CreateMap<CountryModel, Country>().ReverseMap();
            CreateMap<DivisionModel, Division>().ReverseMap();
            CreateMap<RegionModel, Region>().ReverseMap();
            CreateMap<Job, JobModel>().ReverseMap();
            CreateMap<ExamCentre, ExamCentreModel>().ReverseMap();

            //CreateMap<PaymentMethod, PaymentMethodModel>().ReverseMap();

            //CreateMap<DigitalPaymentMethod, DigitalPaymentMethodModel>().ReverseMap();

            //CreateMap<Candidat, BankModel>().ReverseMap();
            //CreateMap<Till, TillModel>().ReverseMap();
            //CreateMap<UserTill, UserTillModel>().ReverseMap();

            CreateMap<ActionMenuProfileModel, ActionMenuProfile>().ReverseMap();
            CreateMap<ActionSubMenuProfileModel, ActionSubMenuProfile>().ReverseMap();

            CreateMap<Menu, MenuModel>().ReverseMap();
            CreateMap<SubMenu, SubMenuModel>().ReverseMap();
            CreateMap<Menu, MenuModel>().ReverseMap();
            CreateMap<ActionSubMenuProfile, ActionMenuProfile>().ForMember(dest => dest.MenuID, opt => opt.MapFrom(src => src.SubMenuID));


            CreateMap<Module, ModuleModel>().ReverseMap();
            //CreateMap<Exam, BudgetAllocatedModel>().ReverseMap();
            //CreateMap<SubjectGroup, BudgetAllocatedUpdateModel>().ReverseMap();
            //CreateMap<Specialty, BudgetLineModel>().ReverseMap();
            //CreateMap<Subject, FiscalYearModel>().ReverseMap();
            //CreateMap<SpecSubject, CompanyModel>().ReverseMap();
            CreateMap<Mouchard, MouchardModel>().ReverseMap();
            //CreateMap<BusinessDayModel, ExamSession>().ReverseMap();

        }
    }
}


