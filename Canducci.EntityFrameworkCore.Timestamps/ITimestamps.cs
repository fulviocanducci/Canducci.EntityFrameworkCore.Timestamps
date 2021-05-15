using System;

namespace Canducci.EntityFrameworkCore.Timestamps
{
    /// <summary>
    /// Interface ITimestamps - CreatedAt && UpdatedAt
    /// </summary>
    public interface ITimestamps
    {
        /// <summary>
        /// CreatedAt - DateTime
        /// </summary>
        DateTime CreatedAt { get; }
        /// <summary>
        /// UpdatedAt - DateTime
        /// </summary>
        DateTime UpdatedAt { get; }
    }
}
