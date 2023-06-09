﻿namespace SmartCare.PatientProfileManagement.Shared.Result
{
    public class Result
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }

        public IEnumerable<string>? Errors { get; set; }
    }
}
