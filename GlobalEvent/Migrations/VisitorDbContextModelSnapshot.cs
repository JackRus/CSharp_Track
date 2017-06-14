using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GlobalEvent.Data;

namespace GlobalEvent.Migrations
{
    [DbContext(typeof(VisitorDbContext))]
    partial class VisitorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.3");

            modelBuilder.Entity("GlobalEvent.Models.VisitorViewModels.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int>("CheckedIn");

                    b.Property<bool>("Full");

                    b.Property<int>("Number");

                    b.HasKey("ID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("GlobalEvent.Models.VisitorViewModels.Visitor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CheckIned");

                    b.Property<string>("Company");

                    b.Property<string>("Email");

                    b.Property<string>("Extention");

                    b.Property<bool>("GroupOwner");

                    b.Property<string>("Last");

                    b.Property<string>("Name");

                    b.Property<string>("Occupation");

                    b.Property<string>("OrderNumber");

                    b.Property<string>("Phone");

                    b.Property<bool>("Registered");

                    b.Property<string>("RegistrationNumber");

                    b.HasKey("ID");

                    b.ToTable("Visitors");
                });
        }
    }
}
