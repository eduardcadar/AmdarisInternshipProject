using System;
using Xunit;
using FluentAssertions;
using Domain.Domain;

namespace DomainUnitTests
{
    public class TestAgencyUser
    {
        private readonly DAgency agency = new("agency", "0222222222");
        [Fact]
        public void TestCreateAgencyUserThrowsExceptionOnNullUsername()
        {
            string username = null;

            Func<DAgencyUser> func1 = () => new DAgencyUser(username, "parola", "0234578723", agency);

            func1.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestCreateAgencyUserThrowsExceptionOnWhitespaceUsername()
        {
            string username = "              ";

            Func<DAgencyUser> func1 = () => new DAgencyUser(username, "parola", "0234578723", agency);

            func1.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestCreateAgencyUserThrowsExceptionOnNullPassword()
        {
            string password = null;

            Func<DAgencyUser> func1 = () => new DAgencyUser("username", password, "0234578723", agency);

            func1.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestCreateAgencyUserThrowsExceptionOnPasswordContainsWhitespaceCharacters()
        {
            string password = "parol amea";

            Func<DAgencyUser> func1 = () => new DAgencyUser("username", password, "0234578723", agency);

            func1.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestCreateAgencyUserThrowsExceptionOnWhitespacePassword()
        {
            string password = "       ";

            Func<DAgencyUser> func1 = () => new DAgencyUser("username", password, "0234578723", agency);

            func1.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestCreateAgencyUserThrowsExceptionOnTooShortUsername()
        {
            string username = "usern";

            Func<DAgencyUser> func1 = () => new DAgencyUser(username, "parola", "0234578723", agency);

            func1.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestCreateAgencyUserThrowsExceptionOnTooShortPassword()
        {
            string username = "passw";

            Func<DAgencyUser> func1 = () => new DAgencyUser(username, "parola", "0234578723", agency);

            func1.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestCreateAgencyUserThrowsExceptionOnInvalidPhoneNumber()
        {
            string phoneNumber = "02a3457872";

            Func<DAgencyUser> func1 = () => new DAgencyUser("username", "parola", phoneNumber, agency);

            func1.Should().Throw<ArgumentException>();
        }
    }
}
