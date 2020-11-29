﻿// <auto-generated />
using System;
using A5WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace A5WebAPI.Migrations
{
    [DbContext(typeof(ChatContext))]
    [Migration("20201123123232_InitialCreate3")]
    partial class InitialCreate3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("A5WebAPI.Models.ChatMessages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ChatMessagesID")
                        .HasColumnType("int");

                    b.Property<int>("chatMemberID")
                        .HasColumnType("int");

                    b.Property<int>("chatRoomID")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("message")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ChatMessage");
                });

            modelBuilder.Entity("A5WebAPI.Models.ChatRoom", b =>
                {
                    b.Property<int>("chatRoomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("chatRoomOwner")
                        .HasColumnType("int");

                    b.Property<string>("roomName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("chatRoomID");

                    b.ToTable("ChatRoom");
                });

            modelBuilder.Entity("A5WebAPI.Models.ChatRoomMembers", b =>
                {
                    b.Property<int>("chatRoomMembersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("chatRoomID")
                        .HasColumnType("int");

                    b.Property<int>("chatUserID")
                        .HasColumnType("int");

                    b.HasKey("chatRoomMembersId");

                    b.ToTable("ChatRoomMember");
                });

            modelBuilder.Entity("A5WebAPI.Models.ChatUser", b =>
                {
                    b.Property<int>("chatUserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("chatUserID");

                    b.ToTable("ChatUserSelect");

                    b.HasData(
                        new
                        {
                            chatUserID = 1,
                            password = "assignment5",
                            username = "assignment5"
                        },
                        new
                        {
                            chatUserID = 2,
                            password = "assignment52",
                            username = "assignment52"
                        },
                        new
                        {
                            chatUserID = 3,
                            password = "assignment53",
                            username = "assignment53"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
