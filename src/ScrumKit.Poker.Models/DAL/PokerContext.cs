using System;
using System.Data.Entity;
using System.Linq;

namespace ScrumKit.Poker.Models.DAL
{
    public class PokerContext : DbContext
    {
        private string _activeUser;

        public PokerContext() : base("PokerContext")
        {
        }

        public PokerContext(string activeUser) : base("PokerContext")
        {
            _activeUser = activeUser;
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }

        public override int SaveChanges()
        {
            var entityEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseModel)
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            foreach (var entityEntry in entityEntries)
            {
                var entity = (BaseModel)entityEntry.Entity;

                if (entityEntry.State == EntityState.Added)
                {
                    entity.DateCreated = DateTime.UtcNow;
                    entity.UserCreated = _activeUser;
                }

                entity.DateModified = DateTime.UtcNow;
                entity.UserModified = _activeUser;
            }

            entityEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseModel)
                .Where(x => x.State == EntityState.Deleted);

            foreach (var entityEntry in entityEntries)
            {
                var entity = (BaseModel)entityEntry.Entity;

                entity.DateModified = DateTime.UtcNow;
                entity.UserModified = _activeUser;

                entity.DateDeleted = DateTime.UtcNow;
                entity.UserDeleted = _activeUser;

                Entry(entityEntry.Entity).State = EntityState.Modified;
            }

            return base.SaveChanges();
        }
    }
}
