﻿namespace Microbuze.src.domain
{
    public class AgencyUser : User
    {
        public Agency Agency { get; set; }
        public AgencyUser(int id, string username, string password, string phoneNumber, Agency agency)
            : base(id, username, password,  phoneNumber)
        {
            this.Agency = agency;
        }
        public override string ToString()
        {
            return this.Agency.ToString();
        }
    }
}