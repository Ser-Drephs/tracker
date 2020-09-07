﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tracker.Core.Persistence;

namespace Tracker.Core.Migrations
{
    [DbContext(typeof(TrackerDbContext))]
    [Migration("20201006213705_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("Tracker.Core.Entities.WorkItems.WorkItemEntity", b =>
                {
                    b.Property<Guid>("WorkItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("TaskId")
                        .HasColumnType("TEXT");

                    b.Property<int>("WorkItemType")
                        .HasColumnType("INTEGER");

                    b.HasKey("WorkItemId");

                    b.ToTable("WorkItems");
                });

            modelBuilder.Entity("Tracker.Core.Entities.WorkTasks.WorkTaskEntity", b =>
                {
                    b.Property<Guid>("WorkTaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Activity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("End")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Start")
                        .HasColumnType("TEXT");

                    b.Property<string>("TaskId")
                        .HasColumnType("TEXT");

                    b.Property<int>("WorkItemType")
                        .HasColumnType("INTEGER");

                    b.HasKey("WorkTaskId");

                    b.ToTable("WorkTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
