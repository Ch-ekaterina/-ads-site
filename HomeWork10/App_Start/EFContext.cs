using System.Data.Entity;
using HomeWork10.Entities;

namespace HomeWork10.App_Start
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Generic")
        {
        }

        public DbSet<UserEntity>  Users { get; set; }
        public DbSet<AdvertEntity> Adverts { get; set; }
        public DbSet<СategoryEntity> Сategories { get; set; }
    }
}