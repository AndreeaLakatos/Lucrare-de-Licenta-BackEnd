﻿using System.Text.Json;

namespace AnimalAdoption.Web.Utils
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorStack { get; set; }
        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
