using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using NZWalks.Data;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;
using Microsoft.EntityFrameworkCore;
using NZWalks.Repositories;
using AutoMapper;
using System.Collections.Generic;

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository
            ,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get Data From Database - Domain Models
            var regionsDomain = await regionRepository.GetAllAsync();

            //Map Domain Models to DTOs
            //var regionsDto = new List<RegionDto>();
            //foreach (var regionDomain in regionsDomain)
            //{
            //    var regionDto = new RegionDto
            //    {
            //        Id = regionDomain.Id,
            //        Code = regionDomain.Code,
            //        Name = regionDomain.Name,
            //        RegionImageUrl = regionDomain.RegionImageUrl
            //    };
            //    regionsDto.Add(regionDto);
            //}

            //Map Domain Models to DTOs using AutoMapper
            //var regionsDto = mapper.Map<List<RegionDto>>(regionsDomain));

            //Return DTOs
            return Ok(mapper.Map<List<RegionDto>>(regionsDomain));

        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //Get Region Domain Model from Database
            //var regionDomain = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            var regionDomain = await regionRepository.GetByIdAsync(id);

            if (regionDomain == null)
            {
                return NotFound(); 
            }

            // map Domain Model to region DTO
            //var regionDto = new RegionDto
            //{
            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,
            //    RegionImageUrl = regionDomain.RegionImageUrl
            //};

            //Return DTO back to the client
            return Ok(mapper.Map<RegionDto>(regionDomain));
        }


        //POST to create new region 
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //Map DTO to Domain Model
            //var regionDomainModel = new Region
            //{
            //    Code = addRegionRequestDto.Code,
            //    Name = addRegionRequestDto.Name,
            //    RegionImageUrl = addRegionRequestDto.RegionImageUrl
            //};

            if (ModelState.IsValid)
            {
                var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);
                //Use Domain Model to create Region 
                //await dbContext.Regions.AddAsync(regionDomainModel);
                //await dbContext.SaveChangesAsync();
                regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

                //Map Domain Model back to DTO
                //var regionDto = new RegionDto
                //{
                //    Id = regionDomainModel.Id,
                //    Code = regionDomainModel.Code,
                //    Name = regionDomainModel.Name,
                //    RegionImageUrl = regionDomainModel.RegionImageUrl
                //};

                var regionDto = mapper.Map<RegionDto>(regionDomainModel);

                return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
            }
            else 
            {
                return BadRequest(ModelState);
            }
        }


        
        // Update regiom
        [HttpPut]
        [Route("{id:Guid}")]
        
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
            {
            //var regionDomainModel = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            //map dto to domain model
            //var regionDomainModel = new Region
            //{
            //    Code = updateRegionRequestDto.Code,
            //    Name = updateRegionRequestDto.Name,
            //    RegionImageUrl = updateRegionRequestDto.RegionImageUrl
            //};
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);

            //check if the region exists
            //await regionRepository.UpdateAsync(id, updateRegionRequestDto);
            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
                {
                    return NotFound();
                }

            //Map DTO to Domain Model
            //remove->
            //regionDomainModel.Code = updateRegionRequestDto.Code;
            //regionDomainModel.Name = updateRegionRequestDto.Name;
            //regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;

            //await dbContext.SaveChangesAsync();

            //Map Domain Model back to DTO
            //var regionDto = new RegionDto
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl
            //};
            
            return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }

        //Delete Region
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            //var regionDomainModel = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }
            //Delete Region
            //dbContext.Regions.Remove(regionDomainModel);
            //await dbContext.SaveChangesAsync();

            //Map Domain Model to DTO
            //var regionDto = new RegionDto
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl
            //};

            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            //Return No Content
            return Ok(regionDto);
        }

    }

}
