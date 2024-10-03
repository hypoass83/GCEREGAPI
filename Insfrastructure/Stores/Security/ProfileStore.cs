using Domain.DTO;
using Domain.InterfacesStores.Security;
using Domain.Models;
using Domain.Models.Security;
using Infrastructure.Entities;
using Insfrastructure.Entities.Security;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;

namespace Insfrastructure.Stores
{
    public class ProfileStore : IProfileStore
    {
        private readonly FsContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public ProfileStore(FsContext dbContext, AutoMapper.IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public ProfileModel CreateProfile(CreateOrUpdateProfileRequest request)
        {
            Profile pro = _mapper.Map<Profile>(request.Profile);
            _dbContext.Profiles.Add(pro);
            _dbContext.SaveChanges();
            UpdateAssignationMenu(request.Menus, pro.ProfileID);
            UpdateAssignationSubMenu(request.SubMenus, pro.ProfileID);
            var profile = _mapper.Map<ProfileModel>(pro);
            return profile;

        }
        public ProfileModel UpdateProfile(CreateOrUpdateProfileRequest request)
        {

            Profile pro = _mapper.Map<Profile>(request.Profile);
            var p = _dbContext.Profiles.FirstOrDefault(x => x.ProfileID == request.Profile.ProfileID);
            if (p == null)
            {
                throw new CustomException("profile not exist", 404);
            }

            _dbContext.Profiles.Entry(p).CurrentValues.SetValues(pro);
            _dbContext.SaveChanges();
            UpdateAssignationMenu(request.Menus, p.ProfileID);
            UpdateAssignationSubMenu(request.SubMenus, p.ProfileID);
            var profile = _mapper.Map<ProfileModel>(pro);
            return profile;

        }

        public bool DeleteProfile(int profileID)
        {
            var pro = _dbContext.Profiles.FirstOrDefault(x => x.ProfileID == profileID);
            if (pro == null)
            {
                return false;
            }
            _dbContext.Profiles.Remove(pro);
            _dbContext.SaveChanges();
            return true;
        }

        public ProfileModel GetProfileById(int id)
        {

            var pro = _dbContext.Profiles.FirstOrDefault(x => x.ProfileID == id);
            if (pro == null)
            {
                throw new CustomException("profile not exist");
            }
            ProfileModel profile = _mapper.Map<ProfileModel>(pro);
            return profile;
        }



        internal void UpdateActionMenu(List<ActionMenuProfileModel> menuactions)
        {
            foreach (var menuitem in menuactions)
            {
                var subm = _mapper.Map<ActionMenuProfile>(menuitem);

                var action = _dbContext.ActionMenuProfiles.FirstOrDefault(x => x.ProfileID == subm.ProfileID && x.MenuID == subm.MenuID);

                if (action == null)
                {
                    throw new CustomException("action not exist", 404);
                }

                action.Update = subm.Update;
                action.Add = subm.Add;
                action.Delete = subm.Delete;

                _dbContext.ActionMenuProfiles.Update(action);
            }


            _dbContext.SaveChanges();
        }

        internal void UpdateActionSubMenu(List<ActionSubMenuProfileModel> submenuactions)
        {
            foreach (var submenuitem in submenuactions)
            {
                var subm = _mapper.Map<ActionSubMenuProfile>(submenuitem);

                var action = _dbContext.ActionSubMenuProfiles.FirstOrDefault(x => x.ProfileID == subm.ProfileID && x.SubMenuID == subm.SubMenuID);

                if (action == null)
                {
                    throw new CustomException("action not exist", 404);
                }

                action.Update = subm.Update;
                action.Add = subm.Add;
                action.Delete = subm.Delete;

                _dbContext.ActionSubMenuProfiles.Update(action);
            }

            _dbContext.SaveChanges();
        }

        public bool UpdateActionModule(UpdateActionModuleRequest req)
        {

            if (req.Menu != null)
            {
                UpdateActionMenu(req.Menu);
            }

            if (req.Sub != null)
            {
                UpdateActionSubMenu(req.Sub);
            }

            return true;


        }

        public List<ModuleModel> GetModule(int profileID)
        {
            var menuWithoutSubMenu = _dbContext.ActionMenuProfiles
           .Where(amp => amp.ProfileID == profileID)
           .Select(amp => amp.Menu.Module)
           .Distinct()
           //.Include(m => m.Menus)
           .ProjectTo<ModuleModel>(_mapper.ConfigurationProvider)
           .ToList()
           .Select(mod =>
            {
                mod.Menus = mod.Menus.Where(men => men.SubMenus.Count == 0 && men.ActionMenuProfiles.Any(x => x.MenuID == men.MenuID && x.ProfileID == profileID)).ToList();
                return mod;
            })
            .Where(mod => mod.Menus.Count != 0)
            .ToList();

            var menuWithitSubMenu = _dbContext.ActionSubMenuProfiles
            .Where(amp => amp.ProfileID == profileID)
            .Select(amp => amp.SubMenu.Menu.Module)
            .Distinct()
            //.Include(m => m.Menus)
            .ProjectTo<ModuleModel>(_mapper.ConfigurationProvider)
            .ToList();

            var menuWithitSubMenuFinal = menuWithitSubMenu
            .Select(mod =>
             {
                 mod.Menus = mod.Menus.Select(men =>
                 {
                     men.SubMenus = men.SubMenus.Where(sub => sub.ActionSubMenuProfiles.Any(act => act.SubMenuID == sub.SubMenuID && act.ProfileID == profileID)).ToList();
                     return men;
                 }).ToList();

                 mod.Menus = mod.Menus.Where(m => m.SubMenus.Count > 0).ToList();

                 return mod;
             })
             .ToList();

            var combinedModules = menuWithitSubMenuFinal.Select(mod =>
            {
                List<MenuModel> result = [];
                menuWithoutSubMenu.ForEach(mod1 =>
                {
                    if (mod.ModuleID == mod1.ModuleID)
                    {
                        mod1.Menus.ToList().ForEach(X => { result.Add(X); });
                    }
                });
                mod.Menus = mod.Menus.Concat(result).ToList();
                return mod;

            }).ToList();
            return combinedModules;

        }

        public List<ModuleModel> GetAllModules()
        {
            var modules = _dbContext.Modules
                                    //.Include(m => m.Menus)
                                    .Distinct()
                                    .ProjectTo<ModuleModel>(_mapper.ConfigurationProvider)
                                    .ToList();

            return modules;
        }

        internal void UpdateAssignationMenu(List<AssignMenu> menus, int profileID)
        {
            foreach (var menu in menus)
            {
                if (_dbContext.Menus.FirstOrDefault(x => x.MenuID == menu.MenuID) == null)
                {
                    throw new CustomException("menu not exist", 404);
                }

                if (_dbContext.Profiles.FirstOrDefault(x => x.ProfileID == profileID) == null)
                {
                    throw new CustomException("profile not exist", 404);
                }

                if (menu.Activated)
                {
                    if (_dbContext.ActionMenuProfiles.FirstOrDefault(X => X.MenuID == menu.MenuID && X.ProfileID == profileID) == null)
                    {
                        ActionMenuProfile action = new ActionMenuProfile()
                        {
                            ProfileID = profileID,
                            MenuID = menu.MenuID,

                        };
                        _dbContext.ActionMenuProfiles.Add(action);
                    }
                }
                else
                {
                    var action = _dbContext.ActionMenuProfiles.FirstOrDefault(x => x.MenuID == menu.MenuID && x.ProfileID == profileID);
                    if (action != null)
                    {
                        _dbContext.ActionMenuProfiles.Remove(action);
                    }
                }

            }
            _dbContext.SaveChanges();
        }

        internal void UpdateAssignationSubMenu(List<AssignSubMenu> submenus, int profileID)
        {
            foreach (var submenu in submenus)
            {
                if (_dbContext.SubMenus.FirstOrDefault(x => x.SubMenuID == submenu.SubMenuID) == null)
                {
                    throw new CustomException("menu not exist", 404);
                }

                if (_dbContext.Profiles.FirstOrDefault(x => x.ProfileID == profileID) == null)
                {
                    throw new CustomException("profile not exist", 404);
                }

                if (submenu.Activated)
                {
                    if (_dbContext.ActionSubMenuProfiles.FirstOrDefault(X => X.SubMenuID == submenu.SubMenuID && X.ProfileID == profileID) == null)
                    {
                        ActionSubMenuProfile action = new ActionSubMenuProfile()
                        {
                            ProfileID = profileID,
                            SubMenuID = submenu.SubMenuID,

                        };
                        _dbContext.ActionSubMenuProfiles.Add(action);
                    }
                }
                else
                {
                    var action = _dbContext.ActionSubMenuProfiles.FirstOrDefault(x => x.SubMenuID == submenu.SubMenuID && x.ProfileID == profileID);
                    if (action != null)
                    {
                        _dbContext.ActionSubMenuProfiles.Remove(action);
                    }
                }
            }

            _dbContext.SaveChanges();
        }

        public List<ProfileModel> GetAllProfile()
        {
            var profiles = _dbContext.Profiles.Select(_mapper.Map<ProfileModel>).ToList();
            return profiles;
        }

        public List<ProfileModel> GetAllProfileById(int profileID)
        {
            var profile = _dbContext.Profiles.FirstOrDefault(x => x.ProfileID == profileID);
            var profiles = _dbContext.Profiles.Select(_mapper.Map<ProfileModel>).Where(x => x.ProfileLevel <= profile.ProfileLevel).ToList();
            return profiles;
        }

        public ActionMenuProfileModel? GetActionByPath(int profileID, string path)
        {
            path = path.Substring(1);
            var actionMenu = _dbContext.Menus.FirstOrDefault(men => men.MenuPath.ToLower().Equals(path.ToLower()));
            if (actionMenu != null)
            {
                //var actionMenuProfileModel = actionMenu.ActionMenuProfiles.FirstOrDefault(x => x.ProfileID == profileID);
                var actionMenuProfileModel = _dbContext.ActionMenuProfiles.Where(x=>x.MenuID==actionMenu.MenuID && x.ProfileID==profileID).FirstOrDefault();
                return _mapper.Map<ActionMenuProfileModel>(actionMenuProfileModel);
            }
            else
            {
                var actionSubmenu = _dbContext.SubMenus.FirstOrDefault(sub => sub.SubMenuPath.ToLower().Equals(path.ToLower()));

                if (actionSubmenu != null)
                {

                    //var actionSub = actionSubmenu.ActionSubMenuProfiles.FirstOrDefault(x => x.ProfileID == profileID);
                    var actionSub = _dbContext.ActionSubMenuProfiles.Where(x => x.SubMenuID == actionSubmenu.SubMenuID && x.ProfileID == profileID).FirstOrDefault();
                    var actionMenuProfileModel = _mapper.Map<ActionMenuProfile>(actionSub);
                    return _mapper.Map<ActionMenuProfileModel>(actionMenuProfileModel);
                }
                else
                {
                    return null;
                }

                
            }

        }

    }
}
