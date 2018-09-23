using Sensei.Database.Contracts;

namespace Sensei.Database.Seeder
{
    public abstract class Seeder : ISeeder
    {
        protected ApplicationDbContext appApplicationDbContext;

        protected Seeder(ApplicationDbContext appApplicationDbContext)
        {
            this.appApplicationDbContext = appApplicationDbContext;
        }

        public abstract void Seed();
    }
}