﻿namespace MC.Shared.Models.Interfaces
{
    public interface IDeletableEntity
    {
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAtUtc { get; set; }
    }
}