using System;
using Xunit;
using FluentAssertions;
using Domain.Domain;

namespace DomainUnitTests
{
    public class TestAgency
    {
        [Fact]
        public void TestCreateAgencyThrowsExceptionOnNullAgencyName()
        {
            // ARRANGE
            string agencyName = null;

            // ACT
            Func<DAgency> func1 = () => new DAgency(agencyName, "0755555555");

            // ASSERT
            func1.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestCreateAgencyThrowsExceptionOnEmptyAgencyName()
        {
            string agencyName = "";

            Func<DAgency> func1 = () => new DAgency(agencyName, "0755555555");

            func1.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestCreateAgencyThrowsExceptionOnWhitespaceAgencyName()
        {
            string agencyName = "  ";

            Func<DAgency> func1 = () => new DAgency(agencyName, "0755555555");

            func1.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestCreateAgencyThrowsExceptionOnNullPhoneNumber()
        {
            string phoneNumber = null;

            Func<DAgency> func1 = () => new DAgency("valid", phoneNumber);

            func1.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestCreateAgencyThrowsExceptionOnInvalidPhoneNumber()
        {
            string phoneNumber = "025629130"; // only 9 digits

            Func<DAgency> func1 = () => new DAgency("valid", phoneNumber);

            func1.Should().Throw<ArgumentException>();
        }
    }
}
