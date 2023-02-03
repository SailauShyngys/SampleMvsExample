﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SampleMvsExample.Persistence;

#nullable disable

namespace SampleMvsExample.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SampleMvsExample.Models.Issue", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateId")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExecutorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedId")
                        .HasColumnType("datetime2");

                    b.Property<int>("PrioritiesId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ExecutorId");

                    b.HasIndex("PrioritiesId");

                    b.ToTable("Issuess");
                });

            modelBuilder.Entity("SampleMvsExample.Models.Position", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("CreateId")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedId")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("SampleMvsExample.Models.Priorities", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("CreateId")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedId")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Prioritiess");
                });

            modelBuilder.Entity("SampleMvsExample.Models.TimeTracking", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("CreateId")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExecutionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<int>("IssueId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedId")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("IssueId");

                    b.ToTable("TimeTracking");
                });

            modelBuilder.Entity("SampleMvsExample.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("CreateId")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedId")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("PositionId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SampleMvsExample.Models.Issue", b =>
                {
                    b.HasOne("SampleMvsExample.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SampleMvsExample.Models.User", "Executor")
                        .WithMany()
                        .HasForeignKey("ExecutorId");

                    b.HasOne("SampleMvsExample.Models.Priorities", "Priorities")
                        .WithMany()
                        .HasForeignKey("PrioritiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Executor");

                    b.Navigation("Priorities");
                });

            modelBuilder.Entity("SampleMvsExample.Models.TimeTracking", b =>
                {
                    b.HasOne("SampleMvsExample.Models.Issue", "Issue")
                        .WithMany("TimeTrackings")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Issue");
                });

            modelBuilder.Entity("SampleMvsExample.Models.User", b =>
                {
                    b.HasOne("SampleMvsExample.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");
                });

            modelBuilder.Entity("SampleMvsExample.Models.Issue", b =>
                {
                    b.Navigation("TimeTrackings");
                });
#pragma warning restore 612, 618
        }
    }
}
