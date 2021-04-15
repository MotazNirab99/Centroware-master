using Centroware.Model.Entities.Settings;
using Centroware.Model.ViewModels.AwardsVm;
using Centroware.Model.ViewModels.Contacts;
using Centroware.Model.ViewModels.Culture;
using Centroware.Model.ViewModels.HomeVms;
using Centroware.Model.ViewModels.Jobs;
using Centroware.Model.ViewModels.OurFrinds;
using Centroware.Model.ViewModels.Sayings;
using Centroware.Model.ViewModels.Services;
using Centroware.Model.ViewModels.Settings;
using Centroware.Model.ViewModels.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Service.Interfaces
{
    public interface IHomeService
    {
        Task<MainSettingsVm> GetMainSettings();
        Task<HomeVm> GetHomePage();
        Task<AboutVm> GetAboutPage();
        Task<ContactVm> CreateContact(ContactVm contact);
        Task<List<ServiceVm>> GetServices();
        Task<List<OpinoinVm>> GetOpinoin();
        Task<List<OurFriendsVm>> GetOurFriends();
        Task<SumAwards> GetSumAwards();
        Task<WorksVm> GetWorksPage();
        Task<WorkRelated> GetWork(int id);
        Task<JoinVm> GetJob();
        Task<List<CultureVm>> GetCulture();
    }
}
