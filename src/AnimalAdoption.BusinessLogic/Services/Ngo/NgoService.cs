using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnimalAdoption.BusinessLogic.Dtos;
using AnimalAdoption.Data.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AnimalAdoption.BusinessLogic.Services.Ngo
{
    public class NgoService: INgoService
    {
        private readonly AnimalAdoptionDbContext _dbContext;
        private readonly IMapper _mapper;

        public NgoService(AnimalAdoptionDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<AdoptionAnnouncementDto> AddAdoptionAnnouncement(string username, AdoptionAnnouncementDto adoptionAnnouncement)
        {
            var ngo = await _dbContext.Ngos.Include(x => x.AdoptionAnnouncements).FirstOrDefaultAsync(x => x.UserName == username);
            if (ngo == null) throw new Exception();

            var adoptionAd = _mapper.Map<AdoptionAnnouncement>(adoptionAnnouncement);
            ngo.AdoptionAnnouncements.Add(adoptionAd);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<AdoptionAnnouncementDto>(adoptionAd);
        }

        public async Task<PhotoDto> AddImage(int adoptionAdId, PhotoDto image)
        {
            var adoptionAnnouncement = await _dbContext.AdoptionAnnouncements
                .Include(x => x.Images)
                .FirstOrDefaultAsync(x => x.Id == adoptionAdId);
            if (adoptionAnnouncement == null) throw new Exception();

            var imageN = _mapper.Map<Photo>(image);
            adoptionAnnouncement.Images.Add(imageN);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<PhotoDto>(imageN);
        }

        public Task<IEnumerable<NgoDto>> GetNgos()
        {
            throw new System.NotImplementedException();
        }

        public Task<NgoDto> GetNgo(int ngoId)
        {
            throw new System.NotImplementedException();
        }
    }
}
