using Canducci.EntityFrameworkCore.Timestamps.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace Canducci.EntityFrameworkCore.Timestamps.Extensions
{
    /// <summary>
    /// TimestampsExtensions - Extensions
    /// </summary>
    public static class TimestampsExtensions
    {
        /// <summary>
        /// method AddInterceptorTimestamps
        /// </summary>
        /// <param name="options">class DbContextOptionsBuilder</param>
        /// <returns>DbContextOptionsBuilder</returns>
        public static DbContextOptionsBuilder AddInterceptorTimestamps(this DbContextOptionsBuilder options)
        {
            return options.AddInterceptors(new TimestampsSaveChangesInterceptor());
        }
    }
}
