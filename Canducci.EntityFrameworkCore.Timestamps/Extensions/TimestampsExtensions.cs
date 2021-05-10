using Canducci.EntityFrameworkCore.Timestamps.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace Canducci.EntityFrameworkCore.Timestamps.Extensions
{
    public static class TimestampsExtensions
    {
        public static DbContextOptionsBuilder AddInterceptorITimestamps(this DbContextOptionsBuilder options)
        {
            return options.AddInterceptors(new TimestampsSaveChangesInterceptor());
        }
    }
}
