﻿using AnimalAdoption.Data.Entities;
using System;
using System.Collections.Generic;

namespace AnimalAdoption.BusinessLogic.Dtos
{
    public class FosteringAnnouncementListModelDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AnimalType AnimalType { get; set; }
        public AnimalSize AnimalSize { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public CountyDto County { get; set; }
        public CityDto City { get; set; }
        public string Street { get; set; }
        public string MoreDetails { get; set; }
        public bool Status { get; set; }
        public bool HasRequest { get; set; }
        public string FromDate { get; set; }
        public IEnumerable<PhotoDto> Photos { get; set; }
    }
}
