using KZ.Entity.Models.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using KZ.Entity.Models.Mapping;

namespace KZ.Entity.Models.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;

            Database.Connection.ConnectionString = "Server=.; Database=Global_Yapi; Integrated Security=SSPI; MultipleActiveResultSets=True;";

            //Database.Connection.ConnectionString = "Server=mssql.ftcyazilim.com.tr; Database=Global_Yapi; User ID=Global_Yapi; Password=rZc993?v48ofb540W#; MultipleActiveResultSets =True;";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Tablo isimlerini tekil hale getirme işlemini gerçekleştirmektedir.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Tablo verileri ile ilişkili verileri otomatik silme işlemini devre dışı bırakmaktadır.
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new GalleryMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new PropertyGroupMap());
            modelBuilder.Configurations.Add(new PropertyMap());
            modelBuilder.Configurations.Add(new TabFilterMap());
        }

        public DbSet<Article> Article { get; set; }
        public DbSet<ExternalArticle> ExternalArticle { get; set; }
        public DbSet<GeneralSetting> GeneralSetting { get; set; }

        public DbSet<HomePageContent> HomePageContent { get; set; }
        public DbSet<LoginLog> LoginLog { get; set; }
        public DbSet<MailSetting> MailSetting { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Blog> Blog { get; set; }

        public DbSet<BlogType> BlogType { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserType> UserType { get; set; }

        public DbSet<Gallery> Gallery { get; set; }
        public DbSet<GalleryImage> GalleryImage { get; set; }

        public DbSet<Property> Property { get; set; }
        public DbSet<PropertyGroup> PropertyGroup { get; set; }

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<ProductProperty> ProductProperty { get; set; }
        public DbSet<ProductMenu> ProductMenu { get; set; }

        public DbSet<SeoPage> SeoPage { get; set; }

        public DbSet<TabFilter> TabFilter { get; set; }

        public DbSet<Language> Language { get; set; }

        public DbSet<TabFilterProduct> TabFilterProduct { get; set; }

        public DbSet<SeoUrlRedirect> SeoUrlRedirect { get; set; }

        public DbSet<Reference> Reference { get; set; }

        public DbSet<Comment> Comment { get; set; }

        public DbSet<Popup> Popup { get; set; }

        public DbSet<SSS> SSS { get; set; }

        public DbSet<MostSearched> MostSearched { get; set; }

    }
}
