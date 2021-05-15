﻿using Canducci.EntityFrameworkCore.Timestamps.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace Canducci.EntityFrameworkCore.Timestamps.Extensions
{
    /// <summary>
    /// TimestampsExtensions - Extensions
    /// </summary>
    public static class TimestampsExtensions
    {
        [System.Obsolete("Use the method AddInterceptorTimestamps", true)]
        public static DbContextOptionsBuilder AddInterceptorITimestamps(this DbContextOptionsBuilder options)
        {
            return options.AddInterceptors(new TimestampsSaveChangesInterceptor());
        }

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
