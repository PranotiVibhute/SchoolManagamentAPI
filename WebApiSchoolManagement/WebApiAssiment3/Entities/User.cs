﻿namespace WebApiAssiment3.Entities
{
    public class User
    {
        public int UserId {get; set; }
        public string? UserName { get; set; }
        public string? PasswordHash { get; set; }
        public string? Role { get; set; }
    }
}
