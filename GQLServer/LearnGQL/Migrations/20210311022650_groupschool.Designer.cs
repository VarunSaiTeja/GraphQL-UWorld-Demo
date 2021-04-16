﻿// <auto-generated />
using System;
using LearnGQL.GraphQL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LearnGQL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210311022650_groupschool")]
    partial class groupschool
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("LearnGQL.GraphQL.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CourseName")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<bool>("HasUnitTests")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("INTEGER");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("LearnGQL.GraphQL.Models.CourseImplementation", b =>
                {
                    b.Property<int>("CourseImplementationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<int>("ImplementationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("INTEGER");

                    b.HasKey("CourseImplementationId");

                    b.HasIndex("CourseId");

                    b.HasIndex("ImplementationId");

                    b.ToTable("CourseImplementations");
                });

            modelBuilder.Entity("LearnGQL.GraphQL.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseImplementationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("GroupName")
                        .HasColumnType("TEXT");

                    b.Property<int>("ImplementationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LeadFacultyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SchoolId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("INTEGER");

                    b.HasKey("GroupId");

                    b.HasIndex("CourseId");

                    b.HasIndex("CourseImplementationId");

                    b.HasIndex("ImplementationId");

                    b.HasIndex("LeadFacultyId");

                    b.HasIndex("SchoolId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("LearnGQL.GraphQL.Models.Implementation", b =>
                {
                    b.Property<int>("ImplementationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("SchoolId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("INTEGER");

                    b.HasKey("ImplementationId");

                    b.HasIndex("SchoolId");

                    b.ToTable("Implementations");
                });

            modelBuilder.Entity("LearnGQL.GraphQL.Models.School", b =>
                {
                    b.Property<int>("SchoolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ParentSchoolId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SchoolName")
                        .HasColumnType("TEXT");

                    b.HasKey("SchoolId");

                    b.HasIndex("ParentSchoolId");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("LearnGQL.GraphQL.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SchoolId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId");

                    b.HasIndex("SchoolId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LearnGQL.GraphQL.Models.UserGroup", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("UserGroup");
                });

            modelBuilder.Entity("LearnGQL.GraphQL.Models.CourseImplementation", b =>
                {
                    b.HasOne("LearnGQL.GraphQL.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearnGQL.GraphQL.Models.Implementation", "Implementation")
                        .WithMany()
                        .HasForeignKey("ImplementationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Implementation");
                });

            modelBuilder.Entity("LearnGQL.GraphQL.Models.Group", b =>
                {
                    b.HasOne("LearnGQL.GraphQL.Models.Course", "Course")
                        .WithMany("Groups")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearnGQL.GraphQL.Models.CourseImplementation", "CourseImplementation")
                        .WithMany("Groups")
                        .HasForeignKey("CourseImplementationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearnGQL.GraphQL.Models.Implementation", "Implementation")
                        .WithMany()
                        .HasForeignKey("ImplementationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearnGQL.GraphQL.Models.User", "LeadFaculty")
                        .WithMany()
                        .HasForeignKey("LeadFacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearnGQL.GraphQL.Models.School", "School")
                        .WithMany()
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("CourseImplementation");

                    b.Navigation("Implementation");

                    b.Navigation("LeadFaculty");

                    b.Navigation("School");
                });

            modelBuilder.Entity("LearnGQL.GraphQL.Models.Implementation", b =>
                {
                    b.HasOne("LearnGQL.GraphQL.Models.School", "School")
                        .WithMany("Implementations")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("LearnGQL.GraphQL.Models.School", b =>
                {
                    b.HasOne("LearnGQL.GraphQL.Models.School", "ParentSchool")
                        .WithMany()
                        .HasForeignKey("ParentSchoolId");

                    b.Navigation("ParentSchool");
                });

            modelBuilder.Entity("LearnGQL.GraphQL.Models.User", b =>
                {
                    b.HasOne("LearnGQL.GraphQL.Models.School", "School")
                        .WithMany()
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("LearnGQL.GraphQL.Models.UserGroup", b =>
                {
                    b.HasOne("LearnGQL.GraphQL.Models.Group", "Group")
                        .WithMany("Users")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearnGQL.GraphQL.Models.User", "User")
                        .WithMany("Groups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LearnGQL.GraphQL.Models.Course", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("LearnGQL.GraphQL.Models.CourseImplementation", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("LearnGQL.GraphQL.Models.Group", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("LearnGQL.GraphQL.Models.School", b =>
                {
                    b.Navigation("Implementations");
                });

            modelBuilder.Entity("LearnGQL.GraphQL.Models.User", b =>
                {
                    b.Navigation("Groups");
                });
#pragma warning restore 612, 618
        }
    }
}
