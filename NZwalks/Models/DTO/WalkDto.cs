﻿namespace NZWalks.Models.DTO
{
    public class WalkDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        //public Guid DifficulityId { get; set; }
        //public Guid RegionId { get; set; }

        public RegionDto? Region { get; set; }
        public DifficulityDto? Difficulity { get; set; }
    }
}
