﻿// <auto-generated />
using System;
using LearnGQL.GraphQL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LearnGQL.Migrations.IdentityDb
{
    [DbContext(typeof(IdentityDbContext))]
    [Migration("20210318024626_Lockout")]
    partial class Lockout
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("LearnGQL.GraphQL.Models.Identity", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoStepVerificationEnabled")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
