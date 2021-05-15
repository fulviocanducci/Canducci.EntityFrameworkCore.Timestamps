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
    /// <summary>
    /// class TimestampsSaveChangesInterceptor
    /// </summary>
    public sealed class TimestampsSaveChangesInterceptor : SaveChangesInterceptor
    {
        private List<EntityEntry> GetEntityEntries(DbContextEventData eventData)
        {
            return eventData
                .Context
                .ChangeTracker
                .Entries()
                .Where(w => w
                .Entity
                .GetType()
                .GetInterfaces()
                .Contains(typeof(ITimestamps))
                )
                .ToList();
        }

        private void Timestamps(DbContextEventData eventData)
        {
            List<EntityEntry> entityEntries = GetEntityEntries(eventData);
            if (entityEntries.Any())
            {
                DateTime dateTimeNow = DateTime.Now;
                foreach (var entity in entityEntries)
                {
                    if (entity.State == EntityState.Added)
                    {
                        entity.Property(nameof(ITimestamps.CreatedAt)).CurrentValue = dateTimeNow;
                        entity.Property(nameof(ITimestamps.UpdatedAt)).CurrentValue = dateTimeNow;
                    }
                    if (entity.State == EntityState.Modified)
                    {
                        entity.Property(nameof(ITimestamps.UpdatedAt)).CurrentValue = dateTimeNow;
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
