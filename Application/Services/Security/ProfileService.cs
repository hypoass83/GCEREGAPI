using Domain.Models;
using Domain.InterfacesStores.Security;
using Domain.InterfacesServices.Security;
using Domain.Models.Security;
using Domain.DTO;

namespace Application.Service
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileStore _profileStore;

        public ProfileService(IProfileStore profileService)
        {
            _profileStore = profileService;
        }
        public ProfileModel CreateProfile(CreateOrUpdateProfileRequest request)
        {
            return _profileStore.CreateProfile(request);
        }

        public bool DeleteProfile(int profile)
        {
            return _profileStore.DeleteProfile(profile);
        }

        public ProfileModel GetProfileById(int id)
        {
            return _profileStore.GetProfileById(id);
        }

        public ProfileModel UpdateProfile(CreateOrUpdateProfileRequest request)
        {
            return _profileStore.UpdateProfile(request);
        }
        public bool UpdateActionModule(UpdateActionModuleRequest req)
        {
            return _profileStore.UpdateActionModule(req);
        }
        public List<ModuleModel> GetModule(int profileID)
        {
            return _profileStore.GetModule(profileID);
        }
        public List<ModuleModel> GetAllModules()
        {
            return _profileStore.GetAllModules();
        }
        List<ProfileModel> IProfileService.GetAllProfile()
        {
            return _profileStore.GetAllProfile();
        }
        public List<ProfileModel> GetAllProfileById(int profileID)
        {
            return _profileStore.GetAllProfileById(profileID);
        }
        public ActionMenuProfileModel GetActionByPath(int profileID, string path)
        {
            return _profileStore.GetActionByPath(profileID, path);
        }
    }
}
