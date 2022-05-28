using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreTestApp.Models
{
    public class MigrationsManager
    {
        private IEnumerable<Type> _contextTypes;
        private IServiceProvider _provider;

        public IEnumerable<string> ContextNames;
        public string ContextName { get; set; }

        public MigrationsManager(IServiceProvider provider)
        {
            _provider = provider;

            _contextTypes = _provider.GetServices<DbContextOptions>().Select(o => o.ContextType);
            ContextNames = _contextTypes.Select(t => t.FullName);
            ContextName = ContextNames.First();
        }
        public DbContext Context => _provider.GetRequiredService(Type.GetType(ContextName)) as DbContext;

        public IEnumerable<string> AppliedMigrations => Context.Database.GetAppliedMigrations();

        public IEnumerable<string> PendingMigrations => Context.Database.GetPendingMigrations();

        public IEnumerable<string> AllMigrations => Context.Database.GetMigrations();

        public void Migrate(string contextName, string target = null)
        {
            Context.GetService<IMigrator>().Migrate(target);
        }
    }
}
