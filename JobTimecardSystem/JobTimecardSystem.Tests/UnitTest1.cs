using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using JobTimecardSystem.Data.Mappings;
using JobTimecardSystem.Data.Models;
using JobTimecardSystem.Data.Models.JobTimecardSystem.Data.Models;
using JobTimecardSystem.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace JobTimecardSystem.Tests
{
    public class AssessmentTests
    {
        // =========================================================
        // 1. DOMAIN & SPECIFICATION COMPLIANCE TESTS
        // =========================================================

        [Fact]
        public void JobType_ShouldContainOnlyBriefSpecifiedValues()
        {
            var expected = new[] { "Repair", "Support", "Warranty" };
            var actual = Enum.GetNames(typeof(JobType));

            Assert.Equal(expected.Length, actual.Length);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClientModel_ShouldMatchBriefClientInformationFieldsOnly()
        {
            var properties = typeof(Client).GetProperties().Select(p => p.Name).ToList();

            Assert.Contains(nameof(Client.Id), properties);
            Assert.Contains(nameof(Client.CompanyName), properties);
            Assert.Contains(nameof(Client.ContactName), properties);
            Assert.Contains(nameof(Client.TelephoneNumber), properties);
            Assert.DoesNotContain("Email", properties);
        }

        [Fact]
        public void TimecardModel_ShouldAllowEmployeeToWorkMultipleJobsPerDay()
        {
            var workDate = new DateTime(2026, 11, 20);
            var job1 = new Job { Id = 1, JobNumber = "JOB-101", JobType = JobType.Repair };
            var job2 = new Job { Id = 2, JobNumber = "JOB-102", JobType = JobType.Support };

            var morningShift = new Timecard
            {
                Id = 1,
                Employee = "Thabo Mokoena",
                DateWorked = workDate,
                HoursWorked = 4.5m,
                JobId = job1.Id,
                Job = job1
            };

            var afternoonShift = new Timecard
            {
                Id = 2,
                Employee = "Thabo Mokoena",
                DateWorked = workDate,
                HoursWorked = 3.5m,
                JobId = job2.Id,
                Job = job2
            };

            var dailyCards = new List<Timecard> { morningShift, afternoonShift };

            Assert.Equal(2, dailyCards.Count);
            Assert.Equal(8.0m, dailyCards.Sum(t => t.HoursWorked));
            Assert.NotEqual(morningShift.JobId, afternoonShift.JobId);
        }

        // =========================================================
        // 2. FLUENT NHIBERNATE MAPPING VERIFICATION
        // =========================================================

        [Fact]
        public void FluentNHibernateMappings_ShouldBuildValidConfiguration()
        {
            var cfg = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString("Server=(localdb)\\MSSQLLocalDB;Database=JobTimecardDb;Trusted_Connection=True;"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<JobMap>())
                .BuildConfiguration();

            Assert.NotNull(cfg.GetClassMapping(typeof(Job)));
            Assert.NotNull(cfg.GetClassMapping(typeof(Timecard)));
            Assert.NotNull(cfg.GetClassMapping(typeof(Client)));
            Assert.NotNull(cfg.GetClassMapping(typeof(Employee)));
        }

        // =========================================================
        // 3. WEB API CONTROLLER VALIDATION TESTS
        // =========================================================

        [Theory]
        [InlineData("", "Acme Corp", "Jane Doe", "012 345 6789")]
        [InlineData("JOB-01", "", "Jane Doe", "012 345 6789")]
        [InlineData("JOB-01", "Acme Corp", "", "012 345 6789")]
        [InlineData("JOB-01", "Acme Corp", "Jane Doe", "")]
        public void JobsController_Create_ShouldReturnBadRequest_WhenRequiredFieldsMissing(
            string jobNumber, string company, string contact, string phone)
        {
            var controller = new JobsController(null!);
            var invalidJob = new Job
            {
                JobNumber = jobNumber,
                JobType = JobType.Repair,
                JobDate = DateTime.Today,
                CompanyName = company,
                ContactName = contact,
                TelephoneNumber = phone
            };

            var result = controller.Create(invalidJob);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1.5)]
        [InlineData(24.5)]
        [InlineData(30)]
        public void TimecardsController_Create_ShouldReturnBadRequest_WhenHoursOutOfRange(decimal invalidHours)
        {
            var controller = new TimecardsController(null!, null!);
            var invalidTimecard = new Timecard
            {
                JobId = 1,
                Employee = "John Smith",
                DateWorked = DateTime.Today,
                HoursWorked = invalidHours
            };

            var result = controller.Create(invalidTimecard);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void TimecardsController_Create_ShouldReturnBadRequest_WhenEmployeeIsBlank()
        {
            var controller = new TimecardsController(null!, null!);
            var invalidTimecard = new Timecard
            {
                JobId = 1,
                Employee = "   ",
                DateWorked = DateTime.Today,
                HoursWorked = 5.0m
            };

            var result = controller.Create(invalidTimecard);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Theory]
        [InlineData("", "Sarah Connor", "011 555 1234")]
        [InlineData("Cyberdyne", "", "011 555 1234")]
        [InlineData("Cyberdyne", "Sarah Connor", "")]
        public void ClientsController_Create_ShouldReturnBadRequest_WhenRequiredFieldsMissing(
            string company, string contact, string phone)
        {
            var controller = new ClientsController(null!);
            var invalidClient = new Client
            {
                CompanyName = company,
                ContactName = contact,
                TelephoneNumber = phone
            };

            var result = controller.Create(invalidClient);

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }
    }
}