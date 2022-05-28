﻿namespace Application.Authentication.Models
{
    public class AuthenticationResponse
    {
        public string Id { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Token { get; set; } = null!;
        public bool IsAgency { get; set; }
    }
}
