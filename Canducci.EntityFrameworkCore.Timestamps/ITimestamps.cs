using System;

namespace Canducci.EntityFrameworkCore.Timestamps
{
    public interface ITimestamps
    {
        DateTime CreatedAt { get; }
        DateTime UpdatedAt { get; }
    }
}
