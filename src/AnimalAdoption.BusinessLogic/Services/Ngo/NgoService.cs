using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<PhotoDto> AddAdoptionImage(int adoptionAdId, PhotoDto image)
        {
            var adoptionAnnouncement = await _dbContext.AdoptionAnnouncements
                .Include(x => x.Photos)
                .FirstOrDefaultAsync(x => x.Id == adoptionAdId);
            if (adoptionAnnouncement == null) throw new Exception();

            var imageN = _mapper.Map<Photo>(image);
            adoptionAnnouncement.Photos.Add(imageN);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<PhotoDto>(imageN);
        }

        public async Task<IEnumerable<AdoptionAnnouncementListModelDto>> GetUserAdoptionAnnouncements(GetAnnouncementsDto username)
        {
            var ngos = await _dbContext.Ngos
                .Include(x => x.AdoptionAnnouncements).ThenInclude(x => x.Photos)
                .Include(x => x.NgoAddress).ThenInclude(x => x.County)
                .Include(x => x.NgoAddress).ThenInclude(x => x.City)
                .Where(x => x.UserName == username.Username)
                .ToListAsync();
            var adoptionAnnouncements = new List<AdoptionAnnouncementListModelDto>();
            if (ngos.Count == 0)
            {
                ngos = await _dbContext.Ngos
                                        .Include(x => x.AdoptionAnnouncements).ThenInclude(x => x.Photos)
                                        .Include(x => x.NgoAddress).ThenInclude(x => x.County)
                                        .Include(x => x.NgoAddress).ThenInclude(x => x.City)
                                        .ToListAsync();
            }
            foreach(var ngo in ngos)
            {
                var announcements = _mapper.Map<AdoptionAnnouncementListModelDto[]>(ngo.AdoptionAnnouncements);
                announcements = announcements.Where(x => !x.Status).ToArray();
                foreach (var announcement in announcements)
                {
                    announcement.County = _mapper.Map<CountyDto>(ngo.NgoAddress.County);
                    announcement.City = _mapper.Map<CityDto>(ngo.NgoAddress.City);
                    announcement.Street = ngo.NgoAddress.Street;
                }
                adoptionAnnouncements.AddRange(announcements);
            }
            return adoptionAnnouncements;
        }

        public async Task<FosteringAnnouncementDto> AddFosteringAnnouncement(string username, FosteringAnnouncementDto fosteringAnnouncement)
        {
            var ngo = await _dbContext.Ngos.Include(x => x.FosteringAnnouncements).FirstOrDefaultAsync(x => x.UserName == username);
            if (ngo == null) throw new Exception();

            var fosteringAd = _mapper.Map<FosteringAnnouncement>(fosteringAnnouncement);
            ngo.FosteringAnnouncements.Add(fosteringAd);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<FosteringAnnouncementDto>(fosteringAd);
        }

        public async Task<PhotoDto> AddFosteringImage(int fosteringAdId, PhotoDto image)
        {
            var fosteringAnnouncement = await _dbContext.FosteringAnnouncements
                .Include(x => x.Photos)
                .FirstOrDefaultAsync(x => x.Id == fosteringAdId);
            if (fosteringAnnouncement == null) throw new Exception();

            var imageN = _mapper.Map<Photo>(image);
            fosteringAnnouncement.Photos.Add(imageN);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<PhotoDto>(imageN);
        }

        public async Task<IEnumerable<FosteringAnnouncementListModelDto>> GetUserFosteringAnnouncements(GetAnnouncementsDto username)
        {
            var ngos = await _dbContext.Ngos
                .Include(x => x.FosteringAnnouncements).ThenInclude(x => x.Photos)
                .Include(x => x.NgoAddress).ThenInclude(x => x.County)
                .Include(x => x.NgoAddress).ThenInclude(x => x.City)
                .Where(x => x.UserName == username.Username)
                .ToListAsync();
            var fosteringAnnouncements = new List<FosteringAnnouncementListModelDto>();
            if (ngos.Count == 0)
            {
                ngos = await _dbContext.Ngos
                                        .Include(x => x.FosteringAnnouncements).ThenInclude(x => x.Photos)
                                        .Include(x => x.NgoAddress).ThenInclude(x => x.County)
                                        .Include(x => x.NgoAddress).ThenInclude(x => x.City)
                                        .ToListAsync();
            }
            foreach (var ngo in ngos)
            {
                var announcements = _mapper.Map<FosteringAnnouncementListModelDto[]>(ngo.FosteringAnnouncements);
                announcements = announcements.Where(x => !x.Status).ToArray();
                foreach (var announcement in announcements)
                {
                    announcement.County = _mapper.Map<CountyDto>(ngo.NgoAddress.County);
                    announcement.City = _mapper.Map<CityDto>(ngo.NgoAddress.City);
                    announcement.Street = ngo.NgoAddress.Street;
                }
                fosteringAnnouncements.AddRange(announcements);
            }
            return fosteringAnnouncements;
        }

        public async Task<int> DeleteAdoptionAnnouncement(string username, int adoptionAnnouncementId)
        {
            var ngo = await _dbContext.Ngos
                .Include(x => x.AdoptionAnnouncements).ThenInclude(x => x.Photos)
                .FirstOrDefaultAsync(x => x.UserName == username);
            var announcement = await _dbContext.AdoptionAnnouncements.FirstOrDefaultAsync(x => x.Id == adoptionAnnouncementId);
            _dbContext.Photos.RemoveRange(announcement.Photos);
            ngo.AdoptionAnnouncements.Remove(announcement);
            await _dbContext.SaveChangesAsync();
            return adoptionAnnouncementId;
        }

        public async Task<int> DeleteFosteringAnnouncement(string username, int fosteringAnnouncementId)
        {
            var ngo = await _dbContext.Ngos
                .Include(x => x.FosteringAnnouncements).ThenInclude(x => x.Photos)
                .FirstOrDefaultAsync(x => x.UserName == username);
            var announcement = await _dbContext.FosteringAnnouncements.FirstOrDefaultAsync(x => x.Id == fosteringAnnouncementId);
            _dbContext.Photos.RemoveRange(announcement.Photos);
            ngo.FosteringAnnouncements.Remove(announcement);
            await _dbContext.SaveChangesAsync();
            return fosteringAnnouncementId;
        }

        public async Task<AdoptionRequestDto> AddAdoptionRequest(AdoptionRequestDto adoptionRequest)
        {
            var adoptionAnnouncement = await _dbContext.AdoptionAnnouncements.Include(x => x.AdoptionRequests).FirstOrDefaultAsync(x => x.Id == adoptionRequest.AdoptionAnnouncementId);
            var adoptionRequestM = _mapper.Map<AdoptionRequest>(adoptionRequest);
            adoptionAnnouncement.AdoptionRequests.Add(adoptionRequestM);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<AdoptionRequestDto>(adoptionRequestM);
        }

        public async Task<FosteringRequestDto> AddFosteringRequest(FosteringRequestDto fosteringRequest)
        {
            var fosteringAnnouncement = await _dbContext.FosteringAnnouncements.Include(x => x.FosteringRequests).FirstOrDefaultAsync(x => x.Id == fosteringRequest.FosteringAnnouncementId);
            var fosteringRequestM = _mapper.Map<FosteringRequest>(fosteringRequest);
            fosteringAnnouncement.FosteringRequests.Add(fosteringRequestM);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<FosteringRequestDto>(fosteringRequestM);
        }

        public async Task<List<AdoptionRequestListModelDto>> GetAdoptionRequests(int announcementId)
        {
            var adoptionRequests = await _dbContext.AdoptionAnnouncements
                .Include(x => x.AdoptionRequests)
                .Where(x => x.Id == announcementId)
                .Select(x => x.AdoptionRequests)
                .FirstOrDefaultAsync();
            var usernames = adoptionRequests.Select(x => x.Username).ToList();
            var basicUser = await _dbContext.BasicUsers
                .Include(x => x.Address).ThenInclude(x => x.City)
                .Include(x => x.Address).ThenInclude(x => x.County)
                .Where(x => usernames.Contains(x.UserName)).ToListAsync();
            var adoptionRequestsModel = new List<AdoptionRequestListModelDto>();
            foreach(var request in adoptionRequests)
            {
                var user = basicUser.Where(x => x.UserName == request.Username).FirstOrDefault();
                var reqModel = new AdoptionRequestListModelDto
                {
                    Id = request.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    County = _mapper.Map<CountyDto>(user.Address.County),
                    City = _mapper.Map<CityDto>(user.Address.City),
                    Street = user.Address.Street,
                    Reason = request.Reason,
                    AvailableDate = request.AvailableDate,
                    SomethingElse = request.SomethingElse,
                    Status = request.Status,
                    AdoptionAnnouncementId = announcementId
                };
                adoptionRequestsModel.Add(reqModel);
            }
            return adoptionRequestsModel;
        }

        public async Task<List<FosteringRequestListModelDto>> GetFosteringRequests(int announcementId)
        {
            var fosteringRequests = await _dbContext.FosteringAnnouncements
                .Include(x => x.FosteringRequests)
                .Where(x => x.Id == announcementId)
                .Select(x => x.FosteringRequests)
                .FirstOrDefaultAsync();
            var usernames = fosteringRequests.Select(x => x.Username).ToList();
            var basicUser = await _dbContext.BasicUsers
                .Include(x => x.Address).ThenInclude(x => x.City)
                .Include(x => x.Address).ThenInclude(x => x.County)
                .Where(x => usernames.Contains(x.UserName)).ToListAsync();
            var fosteringRequestsModel = new List<FosteringRequestListModelDto>();
            foreach (var request in fosteringRequests)
            {
                var user = basicUser.Where(x => x.UserName == request.Username).FirstOrDefault();
                var reqModel = new FosteringRequestListModelDto
                {
                    Id = request.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    County = _mapper.Map<CountyDto>(user.Address.County),
                    City = _mapper.Map<CityDto>(user.Address.City),
                    Street = user.Address.Street,
                    Reason = request.Reason,
                    AvailableDate = request.AvailableDate,
                    SomethingElse = request.SomethingElse,
                    Status = request.Status,
                    FosteringAnnouncementId = announcementId
                };
                fosteringRequestsModel.Add(reqModel);
            }
            return fosteringRequestsModel;
        }
    }
}
