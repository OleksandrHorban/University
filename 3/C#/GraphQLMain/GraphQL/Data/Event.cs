using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConferencePlanner.GraphQL.Data
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string? Title { get; set; }

        [StringLength(4000)]
        public string? Abstract { get; set; }

        public DateTimeOffset? StartTime { get; set; }

        public DateTimeOffset? EndTime { get; set; }

        public TimeSpan Duration =>
            EndTime?.Subtract(StartTime ?? EndTime ?? DateTimeOffset.MinValue) ??
                TimeSpan.Zero;

        public int? CategoryId { get; set; }

        public ICollection<EventSeller> EventSellers { get; set; } =
            new List<EventSeller>();

        public ICollection<EventBuyer> EventBuyers { get; set; } =
            new List<EventBuyer>();

        public Category? Category { get; set; }
    }
}
