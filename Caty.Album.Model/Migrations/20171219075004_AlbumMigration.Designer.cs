﻿// <auto-generated />
using Caty.Album.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Caty.Album.Model.Migrations
{
    [DbContext(typeof(AlbumContext))]
    [Migration("20171219075004_AlbumMigration")]
    partial class AlbumMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Caty.Album.Model.Face", b =>
                {
                    b.Property<int>("FaceId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("FaceData");

                    b.Property<string>("FaceName");

                    b.Property<int>("PeopleId");

                    b.HasKey("FaceId");

                    b.ToTable("Faces");
                });

            modelBuilder.Entity("Caty.Album.Model.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GroupName");

                    b.Property<int>("UserId");

                    b.HasKey("GroupId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Caty.Album.Model.People", b =>
                {
                    b.Property<int>("PeopleId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GroupId");

                    b.Property<string>("PeopleName");

                    b.HasKey("PeopleId");

                    b.ToTable("Peoples");
                });

            modelBuilder.Entity("Caty.Album.Model.PeopleGroup", b =>
                {
                    b.Property<int>("PeopleGroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GroupId");

                    b.Property<int>("PeopleId");

                    b.HasKey("PeopleGroupId");

                    b.ToTable("PeopleGroups");
                });

            modelBuilder.Entity("Caty.Album.Model.Right", b =>
                {
                    b.Property<int>("RightId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RightCode");

                    b.Property<int>("RightName");

                    b.HasKey("RightId");

                    b.ToTable("Rights");
                });

            modelBuilder.Entity("Caty.Album.Model.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RoleName");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Caty.Album.Model.RoleRight", b =>
                {
                    b.Property<int>("RoleRightId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RightId");

                    b.Property<int>("RoleId");

                    b.HasKey("RoleRightId");

                    b.ToTable("RoleRights");
                });

            modelBuilder.Entity("Caty.Album.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserCode");

                    b.Property<string>("UserPwd");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Caty.Album.Model.UserRight", b =>
                {
                    b.Property<int>("UserRightId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RightId");

                    b.Property<int>("UserId");

                    b.HasKey("UserRightId");

                    b.ToTable("UserRights");
                });

            modelBuilder.Entity("Caty.Album.Model.UserRole", b =>
                {
                    b.Property<int>("UserRoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RoleId");

                    b.Property<int>("UserId");

                    b.HasKey("UserRoleId");

                    b.ToTable("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
