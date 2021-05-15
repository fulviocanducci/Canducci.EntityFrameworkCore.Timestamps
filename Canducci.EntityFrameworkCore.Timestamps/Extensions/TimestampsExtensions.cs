using Canducci.EntityFrameworkCore.Timestamps.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace Canducci.EntityFrameworkCore.Timestamps.Extensions
{
    public static class TimestampsExtensions
    {
        [System.Obsolete("Use the method AddInterceptorTimestamps", true)]
        public static DbContextOptionsBuilder AddInterceptorITimestamps(this DbContextOptionsBuilder options)
        {
            return options.AddInterceptors(new TimestampsSaveChangesInterceptor());
        }

        public static DbContextOptionsBuilder AddInterceptorTimestamps(this DbContextOptionsBuilder options)
        {
            return options.AddInterceptors(new TimestampsSaveChangesInterceptor());
        }
    }
}
