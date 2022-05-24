using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalAdoption.BusinessLogic.Dtos;
using AnimalAdoption.BusinessLogic.Helpers.PagedList;
using AnimalAdoption.Data.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AnimalAdoption.BusinessLogic.Services.Ngos
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
            adoptionAd.FromDate = DateTime.Now.Date.ToString("dd.MM.yyyy");
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

        public async Task<PagedEntity<AdoptionAnnouncementListModelDto>> GetUserAdoptionAnnouncements(PaginationEntity paginationEntity, string username)
        {
            var ngos = await _dbContext.Ngos
                .Include(x => x.AdoptionAnnouncements).ThenInclude(x => x.Photos)
                .Include(x => x.NgoAddress).ThenInclude(x => x.County)
                .Include(x => x.AdoptionAnnouncements).ThenInclude(x => x.AdoptionRequests)
                .Include(x => x.NgoAddress).ThenInclude(x => x.City)
                .Where(x => x.UserName == username)
                .ToListAsync();
            var adoptionAnnouncements = new List<AdoptionAnnouncementListModelDto>();
            if (ngos.Count == 0)
            {
                ngos = await _dbContext.Ngos
                                        .Include(x => x.AdoptionAnnouncements).ThenInclude(x => x.Photos)
                                        .Include(x => x.NgoAddress).ThenInclude(x => x.County)
                                        .Include(x => x.NgoAddress).ThenInclude(x => x.City)
                                        .Include(x => x.AdoptionAnnouncements).ThenInclude(x => x.AdoptionRequests)
                                        .ToListAsync();
            }
            foreach(var ngo in ngos)
            {
                var announcements = _mapper.Map<AdoptionAnnouncementListModelDto[]>(ngo.AdoptionAnnouncements);
                foreach (var announcement in announcements)
                {
                    announcement.County = _mapper.Map<CountyDto>(ngo.NgoAddress.County);
                    announcement.City = _mapper.Map<CityDto>(ngo.NgoAddress.City);
                    announcement.Street = ngo.NgoAddress.Street;
                    var ann = ngo.AdoptionAnnouncements.FirstOrDefault(x => x.Id == announcement.Id);
                    var req = ann.AdoptionRequests.FirstOrDefault(x => x.Username == username);
                    if (req is not null) announcement.HasRequest = true;
                }
                
                adoptionAnnouncements.AddRange(announcements);
            }

            if (!string.IsNullOrWhiteSpace(paginationEntity.SearchQuery))
            {
                var searchQuery = paginationEntity.SearchQuery;
                adoptionAnnouncements = adoptionAnnouncements.Where(x => x.Id.ToString().Contains(searchQuery)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(paginationEntity.Types))
            {
                var types = paginationEntity.Types.Split(',').ToList();
                adoptionAnnouncements = adoptionAnnouncements.Where(x => types.Contains(x.AnimalType.ToString())).ToList();
            }

            if(!string.IsNullOrWhiteSpace(paginationEntity.Sizes))
            {
                var sizes = paginationEntity.Sizes.Split(',').ToList();
                adoptionAnnouncements = adoptionAnnouncements.Where(x => sizes.Contains(x.AnimalSize.ToString())).ToList();
            }
            if (!string.IsNullOrWhiteSpace(paginationEntity.Others))
            {
                var others = paginationEntity.Others.Split(',').ToList();
                if (others.Contains("request"))
                    adoptionAnnouncements = adoptionAnnouncements.Where(x => x.HasRequest).ToList();
                if (others.Contains("notRequest"))
                    adoptionAnnouncements = adoptionAnnouncements.Where(x => !x.HasRequest).ToList();
            }
            if (!string.IsNullOrWhiteSpace(paginationEntity.Status))
            {
                var status = paginationEntity.Status.Split(',').ToList();
                if (status.Contains("active"))
                    adoptionAnnouncements = adoptionAnnouncements.Where(x => !x.Status).ToList();
                if (status.Contains("inactive"))
                    adoptionAnnouncements = adoptionAnnouncements.Where(x => x.Status).ToList();
            }

            return PagedEntity<AdoptionAnnouncementListModelDto>.Create(adoptionAnnouncements, paginationEntity.PageNumber,
                paginationEntity.PageSize);
        }

        public async Task<FosteringAnnouncementDto> AddFosteringAnnouncement(string username, FosteringAnnouncementDto fosteringAnnouncement)
        {
            var ngo = await _dbContext.Ngos.Include(x => x.FosteringAnnouncements).FirstOrDefaultAsync(x => x.UserName == username);
            if (ngo == null) throw new Exception();

            var fosteringAd = _mapper.Map<FosteringAnnouncement>(fosteringAnnouncement);
            fosteringAd.FromDate = DateTime.Now.Date.ToString("dd.MM.yyyy");
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

        public async Task<PagedEntity<FosteringAnnouncementListModelDto>> GetUserFosteringAnnouncements(PaginationEntity paginationEntity, string username)
        {
            var ngos = await _dbContext.Ngos.Include(x => x.FosteringAnnouncements).ThenInclude(x => x.Photos).Include(x => x.FosteringAnnouncements).ThenInclude(x => x.FosteringRequests)
                .Include(x => x.FosteringAnnouncements).ThenInclude(x => x.FosteringRequests)
                .Include(x => x.NgoAddress).ThenInclude(x => x.County)
                .Include(x => x.NgoAddress).ThenInclude(x => x.City)
                .Where(x => x.UserName == username).ToListAsync();

            var fosteringAnnouncements = new List<FosteringAnnouncementListModelDto>();
            if (!ngos.Any())
            {
                ngos = await _dbContext.Ngos
                    .Include(x => x.FosteringAnnouncements).ThenInclude(x => x.Photos)
                    .Include(x => x.FosteringAnnouncements).ThenInclude(x => x.FosteringRequests)
                    .Include(x => x.NgoAddress).ThenInclude(x => x.County)
                    .Include(x => x.NgoAddress).ThenInclude(x => x.City)
                    .ToListAsync();
            }
            foreach (var ngo in ngos)
            {
                var announcements = _mapper.Map<FosteringAnnouncementListModelDto[]>(ngo.FosteringAnnouncements);
                foreach (var announcement in announcements)
                {
                    announcement.County = _mapper.Map<CountyDto>(ngo.NgoAddress.County);
                    announcement.City = _mapper.Map<CityDto>(ngo.NgoAddress.City);
                    announcement.Street = ngo.NgoAddress.Street;
                    announcement.StartDate = DateTime.Parse(announcement.StartDate).ToString("dd.MM.yyyy");
                    announcement.EndDate = DateTime.Parse(announcement.EndDate).ToString("dd.MM.yyyy");
                    var ann = ngo.FosteringAnnouncements.FirstOrDefault(x => x.Id == announcement.Id);
                    var req = ann.FosteringRequests.FirstOrDefault(x => x.Username == username);
                    if (req is not null) announcement.HasRequest = true;
                }
                fosteringAnnouncements.AddRange(announcements);
            }

            if (!string.IsNullOrWhiteSpace(paginationEntity.SearchQuery))
            {
                var searchQuery = paginationEntity.SearchQuery;
                fosteringAnnouncements = fosteringAnnouncements.Where(x => x.Id.ToString().Contains(searchQuery)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(paginationEntity.Types))
            {
                var types = paginationEntity.Types.Split(',').ToList();
                fosteringAnnouncements = fosteringAnnouncements.Where(x => types.Contains(x.AnimalType.ToString())).ToList();
            }

            if (!string.IsNullOrWhiteSpace(paginationEntity.Sizes))
            {
                var sizes = paginationEntity.Sizes.Split(',').ToList();
                var foster = fosteringAnnouncements[0].AnimalSize.ToString();
                fosteringAnnouncements = fosteringAnnouncements.Where(x => sizes.Contains(x.AnimalSize.ToString())).ToList();
            }
            if (!string.IsNullOrWhiteSpace(paginationEntity.Others))
            {
                var others = paginationEntity.Others.Split(',').ToList();
                if (others.Contains("request"))
                    fosteringAnnouncements = fosteringAnnouncements.Where(x => x.HasRequest).ToList();
                if (others.Contains("notRequest"))
                    fosteringAnnouncements = fosteringAnnouncements.Where(x => !x.HasRequest).ToList();
            }
            if (!string.IsNullOrWhiteSpace(paginationEntity.Status))
            {
                var status = paginationEntity.Status.Split(',').ToList();
                if (status.Contains("active"))
                    fosteringAnnouncements = fosteringAnnouncements.Where(x => !x.Status).ToList();
                if (status.Contains("inactive"))
                    fosteringAnnouncements = fosteringAnnouncements.Where(x => x.Status).ToList();
            }

            return PagedEntity<FosteringAnnouncementListModelDto>.Create(fosteringAnnouncements, paginationEntity.PageNumber,
                paginationEntity.PageSize);
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
            var ngo = await _dbContext.Ngos.Include(x => x.AdoptionAnnouncements).Include(x => x.Notifications).FirstOrDefaultAsync(x => x.AdoptionAnnouncements.Contains(adoptionAnnouncement));
            
            var adoptionRequestM = _mapper.Map<AdoptionRequest>(adoptionRequest);
            var notification = new Notification
            {
                Text = "Ai primit o cerere pentru anuntul #" + adoptionAnnouncement.Id + " de la utilizatorul " + adoptionRequest.Username,
                Date = DateTime.Now.Date.ToString("dd.MM.yyyy"),
                Hour = DateTime.Now.TimeOfDay.ToString()
            };
            ngo.Notifications.Add(notification);
            adoptionAnnouncement.AdoptionRequests.Add(adoptionRequestM);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<AdoptionRequestDto>(adoptionRequestM);
        }

        public async Task<FosteringRequestDto> AddFosteringRequest(FosteringRequestDto fosteringRequest)
        {
            var fosteringAnnouncement = await _dbContext.FosteringAnnouncements.Include(x => x.FosteringRequests).FirstOrDefaultAsync(x => x.Id == fosteringRequest.FosteringAnnouncementId);
            var ngo = await _dbContext.Ngos.Include(x => x.FosteringAnnouncements).Include(x => x.Notifications).FirstOrDefaultAsync(x => x.FosteringAnnouncements.Contains(fosteringAnnouncement));

            var fosteringRequestM = _mapper.Map<FosteringRequest>(fosteringRequest);
            fosteringAnnouncement.FosteringRequests.Add(fosteringRequestM);
            var notification = new Notification
            {
                Text = "Ai primit o cerere pentru anuntul #" + fosteringAnnouncement.Id + " de la utilizatorul " + fosteringRequest.Username,
                Date = DateTime.Now.Date.ToString("dd.MM.yyyy"),
                Hour = DateTime.Now.TimeOfDay.ToString()
            };
            ngo.Notifications.Add(notification);
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
                    Reviewed = request.Reviewed,
                    AdoptionAnnouncementId = announcementId,
                    FromDate = request.FromDate
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
                    Reviewed = request.Reviewed,
                    FosteringAnnouncementId = announcementId,
                    FromDate = request.FromDate
                };
                fosteringRequestsModel.Add(reqModel);
            }
            return fosteringRequestsModel;
        }

        public async Task<AdoptionRequestListModelDto> UpdateAdoptionRequest(AdoptionRequestListModelDto adoptionRequest)
        {
            var adoptionRequests = await _dbContext.AdoptionAnnouncements.Where(x => x.Id == adoptionRequest.AdoptionAnnouncementId).Select(x => x.AdoptionRequests).FirstOrDefaultAsync();
            var announcement = await _dbContext.AdoptionAnnouncements.FirstOrDefaultAsync(x => x.Id == adoptionRequest.AdoptionAnnouncementId);
            
            foreach (var request in adoptionRequests)
            {
                var user = await _dbContext.BasicUsers.Include(x => x.Notifications).FirstOrDefaultAsync(x => x.UserName == request.Username);
                if (adoptionRequest.Id == request.Id)
                {
                    if (adoptionRequest.Status)
                    {
                        var notification = new Notification
                        {
                            Text = "Cererea cu numarul #" + request.Id + "pentru anuntul  #" + adoptionRequest.AdoptionAnnouncementId + " a fost acceptata, vei fi contactat telefonic de catre membrii asociatiei!!",
                            Date = DateTime.Now.Date.ToString("dd.MM.yyyy"),
                            Hour = DateTime.Now.TimeOfDay.ToString()
                        };
                        user.Notifications.Add(notification);
                        request.Reviewed = true;
                    }
                    request.Status = adoptionRequest.Status;
                }

                if (adoptionRequest.Status && adoptionRequest.Id != request.Id)
                {
                    var notification = new Notification
                    {
                        Text = "Cererea cu numarul #" + request.Id + "pentru anuntul  #" + adoptionRequest.AdoptionAnnouncementId + " a fost refuzata.",
                        Date = DateTime.Now.Date.ToString("dd.MM.yyyy"),
                        Hour = DateTime.Now.TimeOfDay.ToString()
                    };
                    user.Notifications.Add(notification);
                    request.Reviewed = true;
                }    
            }

            if (adoptionRequest.Status) announcement.Status = true;
                
            await _dbContext.SaveChangesAsync();
            return adoptionRequest;  
        }

        public async Task<FosteringRequestListModelDto> UpdateFosteringRequest(FosteringRequestListModelDto fosteringRequest)
        {
            var fosteringRequests =  await _dbContext.FosteringAnnouncements.Where(x => x.Id == fosteringRequest.FosteringAnnouncementId).Select(x => x.FosteringRequests).FirstOrDefaultAsync();
            var announcement = await _dbContext.FosteringAnnouncements.FirstOrDefaultAsync(x => x.Id == fosteringRequest.FosteringAnnouncementId);

            foreach (var request in fosteringRequests)
            {
                var user = await _dbContext.BasicUsers.Include(x => x.Notifications).FirstOrDefaultAsync(x => x.UserName == request.Username);
                if (fosteringRequest.Id == request.Id)
                {
                    if (fosteringRequest.Status)
                    {
                        var notification = new Notification
                        {
                            Text = "Cererea cu numarul #" + request.Id + "pentru anuntul  #" + fosteringRequest.FosteringAnnouncementId + " a fost acceptata, vei fi contactat telefonic de catre membrii asociatiei!!",
                            Date = DateTime.Now.Date.ToString("dd.MM.yyyy"),
                            Hour = DateTime.Now.TimeOfDay.ToString()
                        };
                        user.Notifications.Add(notification);
                        request.Reviewed = true;
                    }
                    request.Status = fosteringRequest.Status;
                }

                if (fosteringRequest.Status && fosteringRequest.Id != request.Id)
                {
                    var notification = new Notification
                    {
                        Text = "Cererea cu numarul #" + request.Id + "pentru anuntul  #" + fosteringRequest.FosteringAnnouncementId + " a fost refuzata.",
                        Date = DateTime.Now.Date.ToString("dd.MM.yyyy"),
                        Hour = DateTime.Now.TimeOfDay.ToString()
                    };
                    user.Notifications.Add(notification);
                    request.Reviewed = true;
                }
            }
            if (fosteringRequest.Status) announcement.Status = true;

            await _dbContext.SaveChangesAsync();
            return fosteringRequest;
        }

        public async Task<UserAdoptionRequestDto> GetUserAdoptionRequest(int announcementId, string username)
        {
            return await _dbContext.AdoptionAnnouncements
                .Where(x => x.Id == announcementId)
                .Include(x => x.AdoptionRequests.Where(x => x.Username == username))
                .Select(x => new UserAdoptionRequestDto
                {
                    AnnouncementId = x.Id,
                    Reason = x.AdoptionRequests.First().Reason,
                    FromDate = DateTime.Now.Date.ToString("dd.MM.yyyy"),
                    AvailableDate = x.AdoptionRequests.First().AvailableDate.ToString("dd.MM.yyyy"),
                    SomethingElse = x.AdoptionRequests.First().SomethingElse,
                    Reviewed = x.AdoptionRequests.First().Reviewed,
                    Status = x.AdoptionRequests.First().Status,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<UserFosteringRequestDto> GetUserFosteringRequest(int announcementId, string username)
        {
            return await _dbContext.FosteringAnnouncements
                .Where(x => x.Id == announcementId)
                .Include(x => x.FosteringRequests.Where(x => x.Username == username))
                .Select(x => new UserFosteringRequestDto
                {
                    AnnouncementId = x.Id,
                    Reason = x.FosteringRequests.First().Reason,
                    FromDate = DateTime.Now.Date.ToString("dd.MM.yyyy"),
                    AvailableDate = x.FosteringRequests.First().AvailableDate.ToString("dd.MM.yyyy"),
                    SomethingElse = x.FosteringRequests.First().SomethingElse,
                    Reviewed = x.FosteringRequests.First().Reviewed,
                    Status = x.FosteringRequests.First().Status
                })
                .FirstOrDefaultAsync();
        }

        public async Task<StatisticsDto> GetStatistics(string username)
        {
            var ngo = await _dbContext.Ngos
                .Include(x => x.AdoptionAnnouncements).ThenInclude(x => x.AdoptionRequests)
                .Include(x => x.FosteringAnnouncements).ThenInclude(x => x.FosteringRequests)
                .FirstOrDefaultAsync(x => x.UserName == username);
            var adoptionAnnouncements = ngo.AdoptionAnnouncements;
            var adoptionRequests = adoptionAnnouncements.SelectMany(x => x.AdoptionRequests).ToList();
            var fosteringAnnouncements = ngo.FosteringAnnouncements;
            var fosteringnRequests = fosteringAnnouncements.SelectMany(x => x.FosteringRequests).ToList();
            return new StatisticsDto
            {
                AdoptionAnnouncementsCount = adoptionAnnouncements.Count,
                ActiveAdoptionAnnouncements = adoptionAnnouncements.Where(x => !x.Status).Count(),
                ClosedAdoptionAnnouncements = adoptionAnnouncements.Where((x) => x.Status).Count(),
                AdoptionRequestsNumber = adoptionAnnouncements.Select(x => x.AdoptionRequests).Count(),
                AdoptionAverage = adoptionAnnouncements.Select(x => x.AdoptionRequests).Count() / adoptionAnnouncements.Count,
                FosteringAnnouncementsCount = fosteringAnnouncements.Count,
                ActiveFosteringAnnouncements = fosteringAnnouncements.Where(x => !x.Status).Count(),
                ClosedFosteringAnnouncements= fosteringAnnouncements.Where(x => x.Status).Count(),
                FosteringRequestsNumber = fosteringAnnouncements.Select(x => x.FosteringRequests).Count(),
                FosteringAverage = fosteringAnnouncements.Select(x => x.FosteringRequests).Count() / fosteringAnnouncements.Count,
                AdoptionUsersNo = adoptionRequests.Select(x => x.Username).Distinct().Count(),
                AcceptedAdoptionRequests = adoptionRequests.Where(x => x.Status).Count(),
                RejectedAdoptionRequests = adoptionRequests.Where(x => !x.Status && x.Reviewed).Count(),
                FosteringUsersNo = fosteringnRequests.Select(x => x.Username).Distinct().Count(),
                AcceptedFosteringRequests = fosteringnRequests.Where(x => x.Status).Count(),
                RejectedFosteringRequests = fosteringnRequests.Where(x => !x.Status && x.Reviewed).Count()
            };
        }
    }
}
