using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPortfolio.Models
{
    public class PortfolioContext : DbContext
    {
        public DbSet<Project> Projects { set; get; }
        public DbSet<Sertificate> Sertificates { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<ContactFormModel> Contacts { get; set; }

        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
            .Property(e => e.Images)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList<string>())
            .Metadata.SetValueComparer(
                 new ValueComparer<List<string>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToList())
                );

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Content = "This is a test content for the project with <a href='google.com'>link</a>",
                    Images = new List<string> { "imgs\\projects\\test.jpg" },
                    ShortDescription = "Shortly",
                    Title = "Title"
                });

            modelBuilder.Entity<Sertificate>().HasData(
                new Sertificate
                {
                    Id = 1,
                    Name = "Android app development on Kotlin",
                    Year = 2020,
                    Url = "https://stepik.org/cert/330993"
                },
                new Sertificate
                {
                    Id = 2,
                    Name = "Self presentation course: public performance skills in 21 century.",
                    Year = 2019,
                    Url = null
                },
                new Sertificate
                {
                    Id = 3,
                    Name = "English Upper-Intermediate",
                    Year = 2019,
                    Url = null
                },
                new Sertificate
                {
                    Id = 4,
                    Name = "C# tutorial from SoloLearn",
                    Url = "https://www.sololearn.com/Certificate/1080-5118349/pdf/",
                    Year = 2019
                },
                new Sertificate
                {
                    Id = 5,
                    Name = "c++ programming course from Computer Science Center",
                    Url = "https://stepik.org/cert/113782",
                    Year = 2018
                },
                new Sertificate
                {
                    Id = 6,
                    Name = "SQL Fundamentals course from SoloLearn",
                    Year = 2018,
                    Url = "https://www.sololearn.com/Certificate/1060-5118349/pdf/"
                },
                new Sertificate
                {
                    Id = 7,
                    Name = "Java Tutorial course from SoloLearn",
                    Year = 2018,
                    Url = "https://www.sololearn.com/Certificate/1068-5118349/pdf/"
                },
                new Sertificate
                {
                    Id = 8,
                    Name = "Python 3 Tutorial course from SoloLearn",
                    Year = 2018,
                    Url = "https://www.sololearn.com/Certificate/1073-5118349/pdf/"
                },
                new Sertificate
                {
                    Id = 9,
                    Name = "c++ Tutorial course from SoloLearn",
                    Year = 2018,
                    Url = "https://www.sololearn.com/Certificate/1051-5118349/pdf/"
                },
                new Sertificate
                {
                    Id = 10,
                    Name = "Sertificate of Completion English Upper-Intermediate level from Simpler",
                    Year = 2018,
                    Url = "https://simpler.link/c/JmQM"
                },
                new Sertificate
                {
                    Id = 11,
                    Name = "Participant of 5th student hackathon from First Line Software",
                    Year = 2018,
                    Url = null
                }
                );

            modelBuilder.Entity<Skill>().HasData(
                new Skill
                {
                    Id = 1,
                    Name = "Android with Kotlin",
                    Progress = 40
                },
                new Skill
                {
                    Id = 2,
                    Name = "ASP.NET Core 3.1",
                    Progress = 35
                },
                new Skill
                {
                    Id = 3,
                    Name = "QT with C++",
                    Progress = 20
                },
                new Skill
                {
                    Id = 4,
                    Name = "Unity",
                    Progress = 15
                },
                new Skill
                {
                    Id = 5,
                    Name = "Git",
                    Progress = 55
                },
                new Skill
                {
                    Id = 6,
                    Name = "C#",
                    Progress = 60
                },
                new Skill
                {
                    Id = 7,
                    Name = "C++",
                    Progress = 60
                },
                new Skill
                {
                    Id = 8,
                    Name = "Java",
                    Progress = 60
                },
                new Skill
                {
                    Id = 9,
                    Name = "Python, Jupiter",
                    Progress = 60
                },
                new Skill
                {
                    Id = 10,
                    Name = "HTML",
                    Progress = 80
                },
                new Skill
                {
                    Id = 11,
                    Name = "CSS",
                    Progress = 75
                }
                );

            modelBuilder.Entity<Language>().HasData(
                new Language
                {
                    Id = 1,
                    Name = "Russian",
                    Progress = 100                    
                },
                new Language
                {
                    Id = 2,
                    Name = "English",
                    Progress = 70
                },
                new Language {
                    Id = 3,
                    Name = "Spanish",
                    Progress = 8
                });
        }
    }
}
