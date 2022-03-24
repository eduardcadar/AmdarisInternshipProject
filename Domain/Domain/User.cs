using System;

namespace Domain.Domain
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public User(int id, string username, string password, string phoneNumber)
        {
            ValidateUser(id, username, password, phoneNumber);

            Id = id;
            Username = username;
            Password = password;
            PhoneNumber = phoneNumber;
        }

        private void ValidateUser(int id, string username, string password, string phoneNumber)
        {
            if (id < 0)
                throw new ArgumentException("Id cannot be negative");
            if (username.Length < 6)
                throw new ArgumentException("Username length cannot be less than 6");
            if (password.Length < 6)
                throw new ArgumentException("Password length cannot be less than 6");

        }
    }
}
