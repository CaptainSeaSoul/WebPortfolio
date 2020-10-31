﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebPortfolio.Models;

namespace WebPortfolio.Migrations
{
    [DbContext(typeof(PortfolioContext))]
    partial class PortfolioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebPortfolio.Models.ContactFormModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(512)")
                        .HasMaxLength(512);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("WebPortfolio.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Progress")
                        .HasColumnType("int");

                    b.Property<int?>("SertificateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SertificateId");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Russian",
                            Progress = 100
                        },
                        new
                        {
                            Id = 2,
                            Name = "English",
                            Progress = 70
                        },
                        new
                        {
                            Id = 3,
                            Name = "Spanish",
                            Progress = 8
                        });
                });

            modelBuilder.Entity("WebPortfolio.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Images")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "This is a test content for the project with <a href='google.com'>link</a>",
                            Images = "imgs\\projects\\test.jpg",
                            ShortDescription = "Shortly",
                            Title = "Title"
                        });
                });

            modelBuilder.Entity("WebPortfolio.Models.Sertificate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Sertificates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Android app development on Kotlin",
                            Url = "https://stepik.org/cert/330993",
                            Year = 2020
                        },
                        new
                        {
                            Id = 2,
                            Name = "Self presentation course: public performance skills in 21 century.",
                            Year = 2019
                        },
                        new
                        {
                            Id = 3,
                            Name = "English Upper-Intermediate",
                            Year = 2019
                        },
                        new
                        {
                            Id = 4,
                            Name = "C# tutorial from SoloLearn",
                            Url = "https://www.sololearn.com/Certificate/1080-5118349/pdf/",
                            Year = 2019
                        },
                        new
                        {
                            Id = 5,
                            Name = "c++ programming course from Computer Science Center",
                            Url = "https://stepik.org/cert/113782",
                            Year = 2018
                        },
                        new
                        {
                            Id = 6,
                            Name = "SQL Fundamentals course from SoloLearn",
                            Url = "https://www.sololearn.com/Certificate/1060-5118349/pdf/",
                            Year = 2018
                        },
                        new
                        {
                            Id = 7,
                            Name = "Java Tutorial course from SoloLearn",
                            Url = "https://www.sololearn.com/Certificate/1068-5118349/pdf/",
                            Year = 2018
                        },
                        new
                        {
                            Id = 8,
                            Name = "Python 3 Tutorial course from SoloLearn",
                            Url = "https://www.sololearn.com/Certificate/1073-5118349/pdf/",
                            Year = 2018
                        },
                        new
                        {
                            Id = 9,
                            Name = "c++ Tutorial course from SoloLearn",
                            Url = "https://www.sololearn.com/Certificate/1051-5118349/pdf/",
                            Year = 2018
                        },
                        new
                        {
                            Id = 10,
                            Name = "Sertificate of Completion English Upper-Intermediate level from Simpler",
                            Url = "https://simpler.link/c/JmQM",
                            Year = 2018
                        },
                        new
                        {
                            Id = 11,
                            Name = "Participant of 5th student hackathon from First Line Software",
                            Year = 2018
                        });
                });

            modelBuilder.Entity("WebPortfolio.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Progress")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Android with Kotlin",
                            Progress = 40
                        },
                        new
                        {
                            Id = 2,
                            Name = "ASP.NET Core 3.1",
                            Progress = 35
                        },
                        new
                        {
                            Id = 3,
                            Name = "QT with C++",
                            Progress = 20
                        },
                        new
                        {
                            Id = 4,
                            Name = "Unity",
                            Progress = 15
                        },
                        new
                        {
                            Id = 5,
                            Name = "Git",
                            Progress = 55
                        },
                        new
                        {
                            Id = 6,
                            Name = "C#",
                            Progress = 60
                        },
                        new
                        {
                            Id = 7,
                            Name = "C++",
                            Progress = 60
                        },
                        new
                        {
                            Id = 8,
                            Name = "Java",
                            Progress = 60
                        },
                        new
                        {
                            Id = 9,
                            Name = "Python, Jupiter",
                            Progress = 60
                        },
                        new
                        {
                            Id = 10,
                            Name = "HTML",
                            Progress = 80
                        },
                        new
                        {
                            Id = 11,
                            Name = "CSS",
                            Progress = 75
                        });
                });

            modelBuilder.Entity("WebPortfolio.Models.Language", b =>
                {
                    b.HasOne("WebPortfolio.Models.Sertificate", "Sertificate")
                        .WithMany()
                        .HasForeignKey("SertificateId");
                });
#pragma warning restore 612, 618
        }
    }
}
