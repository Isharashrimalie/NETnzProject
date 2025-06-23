﻿namespace NZWalks.Models.DTO
{
    public class UpdateWalkRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        public Guid DifficulityId { get; set; }
        public Guid RegionId { get; set; }

    }
}
