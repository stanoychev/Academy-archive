using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sensei.Contracts.DatabaseContexts;
using Sensei.Models;
using Sensei.Database.DbContext;
using Sensei.Seeder;

namespace Sensei.Seeders
{
    public abstract class Seeder : ISeeder
    {
        protected ApplicationDbContext appDbCtx;

        protected Seeder(ApplicationDbContext appDbCtx)
        {
            this.appDbCtx = appDbCtx;
        }

        public abstract void Seed();
    }
}