using Canducci.EntityFrameworkCore.Timestamps;
using System;

namespace CslAppConsole.Models
{
    public class Todo : ITimestamps
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }
    }
}
