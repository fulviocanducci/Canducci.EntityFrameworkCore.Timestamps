using System;

namespace Canducci.EntityFrameworkCore.Timestamps.Test.Models
{
    public class Person : ITimestamps
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }
    }
}
