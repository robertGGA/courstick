﻿// <auto-generated />
using System;
using Courstick.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Courstick.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CourseUser", b =>
                {
                    b.Property<int>("AuthorOfCourseId")
                        .HasColumnType("integer");

                    b.Property<int>("AuthorUserId")
                        .HasColumnType("integer");

                    b.HasKey("AuthorOfCourseId", "AuthorUserId");

                    b.HasIndex("AuthorUserId");

                    b.ToTable("CourseUser");
                });

            modelBuilder.Entity("CourseUser1", b =>
                {
                    b.Property<int>("CoursesCourseId")
                        .HasColumnType("integer");

                    b.Property<int>("UsersUserId")
                        .HasColumnType("integer");

                    b.HasKey("CoursesCourseId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("CourseUser1");
                });

            modelBuilder.Entity("Courstick.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CommentId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("CommentId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Courstick.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CourseId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeOnly>("Passing_Time")
                        .HasColumnType("time without time zone");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<double>("Rating")
                        .HasColumnType("double precision");

                    b.Property<string>("SmallDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<int?>("SubTypeId")
                        .HasColumnType("integer");

                    b.HasKey("CourseId");

                    b.HasIndex("StatusId");

                    b.HasIndex("SubTypeId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Courstick.Models.Page", b =>
                {
                    b.Property<int>("PageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PageId"));

                    b.Property<int>("CommentId")
                        .HasColumnType("integer");

                    b.Property<int?>("CourseId")
                        .HasColumnType("integer");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Movie")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PageId");

                    b.HasIndex("CommentId");

                    b.HasIndex("CourseId");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("Courstick.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RoleId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Courstick.Models.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StatusId"));

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("Courstick.Models.Subscription", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SubscriptionId"));

                    b.Property<string>("SubscriptionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SubscriptionTypeSubTypeId")
                        .HasColumnType("integer");

                    b.HasKey("SubscriptionId");

                    b.HasIndex("SubscriptionTypeSubTypeId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("Courstick.Models.SubType", b =>
                {
                    b.Property<int>("SubTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SubTypeId"));

                    b.Property<string>("Criterion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SubTypeId");

                    b.ToTable("SubTypes");
                });

            modelBuilder.Entity("Courstick.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TagId"));

                    b.Property<int?>("CourseId")
                        .HasColumnType("integer");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TagId");

                    b.HasIndex("CourseId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Courstick.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<byte[]>("Avatar")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Phone")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserRoleRoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.HasIndex("UserRoleRoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SubscriptionUser", b =>
                {
                    b.Property<int>("SubscriptionsSubscriptionId")
                        .HasColumnType("integer");

                    b.Property<int>("UsersUserId")
                        .HasColumnType("integer");

                    b.HasKey("SubscriptionsSubscriptionId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("SubscriptionUser");
                });

            modelBuilder.Entity("CourseUser", b =>
                {
                    b.HasOne("Courstick.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("AuthorOfCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Courstick.Models.User", null)
                        .WithMany()
                        .HasForeignKey("AuthorUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseUser1", b =>
                {
                    b.HasOne("Courstick.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Courstick.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Courstick.Models.Comment", b =>
                {
                    b.HasOne("Courstick.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Courstick.Models.Course", b =>
                {
                    b.HasOne("Courstick.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Courstick.Models.SubType", null)
                        .WithMany("Courses")
                        .HasForeignKey("SubTypeId");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Courstick.Models.Page", b =>
                {
                    b.HasOne("Courstick.Models.Comment", "Comment")
                        .WithMany()
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Courstick.Models.Course", null)
                        .WithMany("Page")
                        .HasForeignKey("CourseId");

                    b.Navigation("Comment");
                });

            modelBuilder.Entity("Courstick.Models.Subscription", b =>
                {
                    b.HasOne("Courstick.Models.SubType", "SubscriptionType")
                        .WithMany()
                        .HasForeignKey("SubscriptionTypeSubTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubscriptionType");
                });

            modelBuilder.Entity("Courstick.Models.Tag", b =>
                {
                    b.HasOne("Courstick.Models.Course", null)
                        .WithMany("Tag")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("Courstick.Models.User", b =>
                {
                    b.HasOne("Courstick.Models.Role", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("SubscriptionUser", b =>
                {
                    b.HasOne("Courstick.Models.Subscription", null)
                        .WithMany()
                        .HasForeignKey("SubscriptionsSubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Courstick.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Courstick.Models.Course", b =>
                {
                    b.Navigation("Page");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Courstick.Models.SubType", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
