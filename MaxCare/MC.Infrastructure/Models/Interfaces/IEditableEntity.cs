﻿namespace MC.Infrastructure.Models.Interfaces
{
    public interface IEditableEntity
    {
        public string? EditedBy { get; set; }
        public DateTime? EditedAtUtc { get; set; }
    }
}
