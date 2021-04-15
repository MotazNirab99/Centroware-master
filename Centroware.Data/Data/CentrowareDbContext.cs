using Centroware.Model.Entities.Awards;
using Centroware.Model.Entities.Blogs;
using Centroware.Model.Entities.Contact;
using Centroware.Model.Entities.Culture;
using Centroware.Model.Entities.Identity;
using Centroware.Model.Entities.Jobs;
using Centroware.Model.Entities.OurFrinds;
using Centroware.Model.Entities.Sayings;
using Centroware.Model.Entities.Services;
using Centroware.Model.Entities.Settings;
using Centroware.Model.Entities.Teams;
using Centroware.Model.Entities.Works;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Centroware.Data.Data
{
    public class CentrowareDbContext : IdentityDbContext<CentrowareUser>
    {
        public CentrowareDbContext(DbContextOptions<CentrowareDbContext> options)
            : base(options)
        {
        }

        #region Work
        public DbSet<Category> Categories { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Article> Articles { get; set; }
        #endregion

        #region Teams
        public DbSet<Team> Teams { get; set; }
        #endregion

        #region Settings
        public DbSet<AboutSetting> AboutSettings { get; set; }
        public DbSet<HomeSetting> HomeSettings { get; set; }
        public DbSet<MainSetting> MainSetting { get; set; }
        #endregion

        #region Serivecs
        public DbSet<Service> Services { get; set; }
        #endregion

        #region Sayings
        public DbSet<Opinion> Opinions { get; set; }
        #endregion

        #region Contacts
        public DbSet<Contact> Contacts { get; set; }
        #endregion
        #region Blogs
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        #endregion
        #region Jobs
        public DbSet<Job> Jobs { get; set; }
        #endregion
        #region OurFriends
        public DbSet<OurFriends> OurFriends { get; set; }
        #endregion

        #region Awards
        public DbSet<Awards> Awards { get; set; }
        #endregion
        #region Culture
        public DbSet<Culture> Cultures { get; set; }
        #endregion
        #region CultureItem
        public DbSet<CultureItem> CulturesItem { get; set; }
        #endregion
    }
}
