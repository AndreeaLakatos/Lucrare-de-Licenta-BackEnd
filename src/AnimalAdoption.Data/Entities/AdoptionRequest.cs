﻿using System;

namespace AnimalAdoption.Data.Entities
{
    public class AdoptionRequest
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public DateTime AvailableDate { get; set; }
        public bool Status { get; set; }
        public string SomethingElse { get; set; }
        public bool Reviewed { get; set; }
        public string Username { get; set; }
    }
}
