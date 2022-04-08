using System;
using Xunit;
using FluentAssertions;
using Domain.Domain;
using Moq;

namespace DomainUnitTests
{
    public class TestRegularUser
    {
        [Fact]
        public void TestCreateRegularUserThrowsExceptionOnNullFirstname()
        {
            string firstname = null;

            Func<DRegularUser> func1 = () => new DRegularUser("username", "parola", "0234578723", firstname, It.IsAny<string>());

            func1.Should().Throw<ArgumentException>();
        }
        
        [Fact]
        public void TestCreateRegularUserThrowsExceptionOnWhitespaceFirstname()
        {
            string firstname = " ";

            Func<DRegularUser> func1 = () => new DRegularUser("username", "parola", "0234578723", firstname, It.IsAny<string>());

            func1.Should().Throw<ArgumentException>();
        }
        
        [Fact]
        public void TestCreateRegularUserThrowsExceptionOnNullLastname()
        {
            string lastname = null;

            Func<DRegularUser> func1 = () => new DRegularUser("username", "parola", "0234578723", "firstname", lastname);

            func1.Should().Throw<ArgumentException>();
        }
        
        [Fact]
        public void TestCreateRegularUserThrowsExceptionOnWhitespaceLastname()
        {
            string lastname = " ";

            Func<DRegularUser> func1 = () => new DRegularUser("username", "parola", "0234578723", "firstname", lastname);

            func1.Should().Throw<ArgumentException>();
        }

    }
}
