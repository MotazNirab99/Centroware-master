using AutoMapper;
using Centroware.Model.Entities.Awards;
using Centroware.Model.Entities.Blog;
using Centroware.Model.Entities.Blogs;
using Centroware.Model.Entities.Contact;
using Centroware.Model.Entities.Culture;
using Centroware.Model.Entities.Jobs;
using Centroware.Model.Entities.OurFrinds;
using Centroware.Model.Entities.Sayings;
using Centroware.Model.Entities.Settings;
using Centroware.Model.Entities.Teams;
using Centroware.Model.Entities.Works;
using Centroware.Model.ViewModels.AwardsVm;
using Centroware.Model.ViewModels.Blog;
using Centroware.Model.ViewModels.Contacts;
using Centroware.Model.ViewModels.Culture;
using Centroware.Model.ViewModels.HomeVms;
using Centroware.Model.ViewModels.Jobs;
using Centroware.Model.ViewModels.OurFrinds;
using Centroware.Model.ViewModels.Sayings;
using Centroware.Model.ViewModels.Services;
using Centroware.Model.ViewModels.Settings;
using Centroware.Model.ViewModels.Teams;
using Centroware.Model.ViewModels.Works;
using Centroware.Repository.Interfaces.Generic;
using Centroware.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centroware.Service.Services
{
    public class HomeService : IHomeService
    {
        private readonly IBaseRepository<HomeSetting> _homeSettingRepository;
        private readonly IBaseRepository<AboutSetting> _aboutSettingRepository;
        private readonly IBaseRepository<MainSetting> _mainSettingRepository;
        private readonly IBaseRepository<Opinion> _opinionRepository;
        private readonly IBaseRepository<Contact> _contactRepository;
        private readonly IBaseRepository<Work> _workRepository;
        private readonly IBaseRepository<Category> _categoryRepository;
        private readonly IBaseRepository<Team> _teamRepository;
        private readonly IBaseRepository<Job> _jobRepository;
        private readonly IBaseRepository<OurFriends> _ourFriendsRepository;
        private readonly IBaseRepository<Awards> _awardsRepository;
        private readonly IBaseRepository<Culture> _cultureRepository;
        private readonly IBaseRepository<Posts> _postsRepository;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Model.Entities.Services.Service> _ServicesRepository;

        public HomeService(IBaseRepository<HomeSetting> homeSettingRepository, IBaseRepository<AboutSetting> aboutSettingRepository, IBaseRepository<MainSetting> mainSettingRepository, IBaseRepository<Opinion> opinionRepository, IBaseRepository<Contact> contactRepository, IBaseRepository<Work> workRepository, IBaseRepository<Category> categoryRepository, IBaseRepository<Team> teamRepository, IBaseRepository<Job> jobRepository, IBaseRepository<OurFriends> ourFriendsRepository, IBaseRepository<Awards> awardsRepository, IBaseRepository<Culture> cultureRepository, IBaseRepository<Posts> postsRepository, IMapper mapper, IBaseRepository<Model.Entities.Services.Service> servicesRepository)
        {
            _homeSettingRepository = homeSettingRepository;
            _aboutSettingRepository = aboutSettingRepository;
            _mainSettingRepository = mainSettingRepository;
            _opinionRepository = opinionRepository;
            _contactRepository = contactRepository;
            _workRepository = workRepository;
            _categoryRepository = categoryRepository;
            _teamRepository = teamRepository;
            _jobRepository = jobRepository;
            _ourFriendsRepository = ourFriendsRepository;
            _awardsRepository = awardsRepository;
            _cultureRepository = cultureRepository;
            _postsRepository = postsRepository;
            _mapper = mapper;
            _ServicesRepository = servicesRepository;
        }

        public async Task<ContactVm> CreateContact(ContactVm contactVm)
        {
            var contact = _mapper.Map<Contact>(contactVm);
            var result = await _contactRepository.AddAsync(contact);
            return contactVm;
        }
        public async Task<AboutVm> GetAboutPage()
        {

            var teams = await _teamRepository.Filter(filter: x => x.Id > 0, orderBy: x => x.OrderByDescending(x => x.Id))
                .Select(x => new TeamVm
                {
                    Id = x.Id,
                    MovedImage = x.MovedImage,
                    Name = x.Name,
                    Specialization = x.Specialization,
                    StaticImage = x.StaticImage,
                    Description = x.Description
                }).ToListAsync();
            var services = await GetServices();
            var cultures = await GetCulture();
            var about = await _aboutSettingRepository.FindFirst(x => x.Id > 0);
            var mapAbout = _mapper.Map<AboutSetting, AboutSettingVm>(about);
            return new AboutVm
            {
                About = mapAbout,
                Services = services,
                Teams = teams,
                Cultures = cultures
            };
        }
        public async Task<HomeVm> GetHomePage()
        {
            var homeSetting = await _homeSettingRepository.FindFirst(x => x.Id > 0);
            var homeSettingVm = _mapper.Map<HomeSetting, HomeSettingVm>(homeSetting);
            var works = await _workRepository
                .Filter(filter: x => x.Id > 0, 0, 4, orderBy: x => x.OrderByDescending(x => x.Id)).Select(x => new WorkVm
                {
                    Title = x.Title,
                    Id = x.Id,
                    MainImage = x.MainImage,
                    Category = x.Category.Name,
                    SubTitle = x.SubTitle,
                }).ToListAsync();
            var Opinoin = await GetOpinoin();
            var OurFriends = await GetOurFriends();
            var Awards = await GetSumAwards();

            return new HomeVm
            {
                HomeSetting = homeSettingVm,
                Worsk = works,
                OpinoinVm = Opinoin,
                OurFriends = OurFriends,
                Awards = Awards
            };
        }
        public async Task<List<OurFriendsVm>> GetOurFriends()
        {
            return await _ourFriendsRepository.Filter(filter: x => x.Id > 0,
               orderBy: x => x.OrderByDescending(x => x.Id)).Select(x => new OurFriendsVm
               {
                   Name = x.Name,
                   Image = x.Image,
                   CategoryFriends = x.CategoryFriends

               }).ToListAsync();

        }
        public async Task<List<CultureVm>> GetCulture()
        {
            return await _cultureRepository.Filter(filter: x => x.Id > 0, include: x => x.Include(x => x.CultureItems),
              orderBy: x => x.OrderByDescending(x => x.Id))
            .Select(x => new CultureVm
            {
                Id = x.Id,
                MainImage = x.MainImage,
                Titel = x.Titel,
                TitelLink = x.TitelLink,
                Description = x.Description,
                CultureItems = x.CultureItems.Select(m => new CultureItemVm { ImageItem = m.ImageItem, TitleItem = m.TitleItem }).ToList(),
            }).ToListAsync();

        }
        public async Task<SumAwards> GetSumAwards()
        {
            var data = await _awardsRepository.Filter(filter: x => x.Id > 0,
                 orderBy: x => x.OrderByDescending(x => x.Id)).Select(x => new AwardsVm
                 {
                     Name = x.Name,
                     Count = x.Count,

                 }).ToListAsync();
            var sumCount = data.Sum(x => x.Count);
            return new SumAwards
            {
                Awards = data,
                sumCount = sumCount,
            };


        }
        public async Task<List<OpinoinVm>> GetOpinoin()
        {
            return await _opinionRepository.Filter(filter: x => x.Id > 0, orderBy: x => x.OrderByDescending(x => x.Id)).Select(x => new OpinoinVm
            {
                Id = x.Id,
                Name = x.Name,
                Specialty = x.Specialty,
                Image = x.Image,
                Logo = x.Logo,
                Description = x.Description
            }).ToListAsync();
        }
        public async Task<JoinVm> GetJob()
        {
            var jobs = await _jobRepository.Filter(filter: x => x.Id > 0, orderBy: x => x.OrderByDescending(x => x.Id)).Select(x => new JobVm
            {
                Title = x.Title,
                Description = x.Description
            }).ToListAsync();
            var about = await _aboutSettingRepository.FindFirst(x => x.Id > 0);
            var abouVm = _mapper.Map<AboutSetting, AboutSettingVm>(about);
            return new JoinVm
            {
                About = abouVm,
                Jobs = jobs,
            };
        }
        public async Task<MainSettingsVm> GetMainSettings()
        {
            var data = await _mainSettingRepository.FindFirst(x => x.Id > 0);
            return _mapper.Map<MainSetting, MainSettingsVm>(data);
        }

        public async Task<List<ServiceVm>> GetServices()
        {
            return await _ServicesRepository.Filter(filter: x => x.Id > 0, 0, 5, orderBy: x => x.OrderByDescending(x => x.Id)).Select(x => new ServiceVm
            {
                Title = x.Title,
                Image = x.Image,
                Description = x.Description
            }).ToListAsync();
        }
        public async Task<WorkRelated> GetWork(int id)
        {
            var work = await _workRepository.Filter(x => x.Id == id, include: x => x.Include(x => x.Articles).Include(x => x.Category)).FirstOrDefaultAsync();
            if (work == null)
            {
                return null;
            }
            var works = await _workRepository.Filter(x => x.CategoryId == work.CategoryId && x.Id != id, 0, 3, orderBy: x => x.OrderByDescending(x => x.Id)).ToListAsync();
            var dataVm = _mapper.Map<WorkVm>(work);
            var worksVm = _mapper.Map<List<WorkVm>>(works);
            return new WorkRelated { Work = dataVm, Works = worksVm };
        }
        public async Task<WorksVm> GetWorksPage()
        {
            var works = await _workRepository.Filter(filter: x => x.Id > 0,
                orderBy: x => x.OrderByDescending(x => x.Id),
                include: x => x.Include(x => x.Category)).Select(x => new WorkVm
                {
                    Id = x.Id,
                    Title = x.Title,
                    SubTitle = x.SubTitle,
                    MainImage = x.MainImage,
                    Category = x.Category.Name,
                    CategoryId = x.CategoryId
                }).ToListAsync();

            return new WorksVm { Works = works };
        }

        public async Task<BlogVm> GetBlogs()
        {
            var about = await _aboutSettingRepository.FindFirst(x => x.Id > 0);
            var mapAbout = _mapper.Map<AboutSetting, AboutSettingVm>(about);
            var posts = await _postsRepository.Filter(filter: x => x.Id > 0,
               orderBy: x => x.OrderByDescending(x => x.Id)).Select(x => new PostsVm
               {
                   Id = x.Id,
                   Title = x.Title,
                   Description = x.Description,
                   CreatedAt = x.CreatedAt.ToString("dd/MM/yyyy"),
                   Image = x.Image
               }).ToListAsync();

            return new BlogVm { Posts = posts, About = mapAbout };
        }

        public async Task<PostsVm> GetBlog(int id)
        {
            var about = await _postsRepository.FindFirst(x => x.Id == id);
            var mapPost = _mapper.Map<Posts, PostsVm>(about);
            return mapPost;
        }
    }
}
