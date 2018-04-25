﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WhiskyReviewer.Models;

namespace WhiskyReviewer.Migrations
{
    [DbContext(typeof(WhiskyReviewerContext))]
    [Migration("20180425181405_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WhiskyReviewer.Models.Distillery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Country");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Distilleries");
                });

            modelBuilder.Entity("WhiskyReviewer.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Grade");

                    b.Property<string>("Text");

                    b.Property<int>("WhiskyId");

                    b.HasKey("Id");

                    b.HasIndex("WhiskyId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("WhiskyReviewer.Models.Whisky", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.Property<int>("DistilleryId");

                    b.Property<string>("Name");

                    b.Property<int>("StatedAge");

                    b.HasKey("Id");

                    b.HasIndex("DistilleryId");

                    b.ToTable("Whisky");
                });

            modelBuilder.Entity("WhiskyReviewer.Models.Review", b =>
                {
                    b.HasOne("WhiskyReviewer.Models.Whisky", "Whisky")
                        .WithMany("Reviews")
                        .HasForeignKey("WhiskyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WhiskyReviewer.Models.Whisky", b =>
                {
                    b.HasOne("WhiskyReviewer.Models.Distillery", "Distillery")
                        .WithMany("Whiskies")
                        .HasForeignKey("DistilleryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
