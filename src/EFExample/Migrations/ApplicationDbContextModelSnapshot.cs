using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using EFExample.Models;

namespace EFExample.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFExample.Models.School", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("EFExample.Models.Student", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<long>("TeacherID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("EFExample.Models.Teacher", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<long>("SchoolID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("EFExample.Models.Student", b =>
                {
                    b.HasOne("EFExample.Models.Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherID");
                });

            modelBuilder.Entity("EFExample.Models.Teacher", b =>
                {
                    b.HasOne("EFExample.Models.School")
                        .WithMany()
                        .HasForeignKey("SchoolID");
                });
        }
    }
}
