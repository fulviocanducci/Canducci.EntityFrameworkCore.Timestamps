using Canducci.EntityFrameworkCore.Timestamps.Internals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Canducci.EntityFrameworkCore.Timestamps.Interceptors
{
    public sealed class TimestampsSaveChangesInterceptor : SaveChangesInterceptor
    {
        private Entries<ITimestamps> Entries { get; }
        public TimestampsSaveChangesInterceptor()
        {
            Entries = new EntriesTimestamps();
        }

        private void Timestamps(DbContextEventData eventData)
        {
            List<EntityEntry> entityEntries = Entries.GetEntityEntries(eventData);
            if (entityEntries.Any())
            {
                DateTime actual = DateTime.Now;
                foreach (var entity in entityEntries)
                {
                    if (entity.State == EntityState.Added)
                    {
                        entity.Property("CreatedAt").CurrentValue = actual;
                        entity.Property("UpdatedAt").CurrentValue = actual;
                    }
                    if (entity.State == EntityState.Modified)
                    {
                        entity.Property("UpdatedAt").CurrentValue = actual;
                    }
                }
            }
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            Timestamps(eventData);
            return result;
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = new CancellationToken())
        {
            Timestamps(eventData);
            return new ValueTask<InterceptionResult<int>>(result);
        }

    }
}
