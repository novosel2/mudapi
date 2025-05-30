﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mud.Infrastructure.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Mud.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250508182621_CombineIdAndAccountIdInCharacter")]
    partial class CombineIdAndAccountIdInCharacter
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Mud.Core.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Mud.Core.Entities.Character", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AccountUsername")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ClassId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("EquippedItemId")
                        .HasColumnType("uuid");

                    b.Property<int>("Experience")
                        .HasColumnType("integer");

                    b.Property<int>("Health")
                        .HasColumnType("integer");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("EquippedItemId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Mud.Core.Entities.CharacterInstanceState", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CharacterId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CurrentRoomId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("InstanceId")
                        .HasColumnType("uuid");

                    b.Property<int>("PosX")
                        .HasColumnType("integer");

                    b.Property<int>("PosY")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("CurrentRoomId");

                    b.HasIndex("InstanceId");

                    b.ToTable("CharacterInstanceStates");
                });

            modelBuilder.Entity("Mud.Core.Entities.Class", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Dexterity")
                        .HasColumnType("integer");

                    b.Property<int>("Intelligence")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Stamina")
                        .HasColumnType("integer");

                    b.Property<int>("Strength")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Mud.Core.Entities.Dungeon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Playtime")
                        .HasColumnType("double precision");

                    b.Property<int>("SuggestedLevel")
                        .HasColumnType("integer");

                    b.Property<int>("SuggestedPartySize")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Dungeons");
                });

            modelBuilder.Entity("Mud.Core.Entities.DungeonInstance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("DungeonId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PartyId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("StartedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DungeonId");

                    b.HasIndex("PartyId");

                    b.ToTable("DungeonInstances");
                });

            modelBuilder.Entity("Mud.Core.Entities.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Mud.Core.Entities.Party", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Parties");
                });

            modelBuilder.Entity("Mud.Core.Entities.PartyMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CharacterId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsLeader")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsReady")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("JoinedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PartyId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("PartyId");

                    b.ToTable("PartyMembers");
                });

            modelBuilder.Entity("Mud.Core.Entities.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("DungeonId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DungeonId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Mud.Core.Entities.Character", b =>
                {
                    b.HasOne("Mud.Core.Entities.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mud.Core.Entities.Item", "EquippedItem")
                        .WithMany()
                        .HasForeignKey("EquippedItemId");

                    b.Navigation("Class");

                    b.Navigation("EquippedItem");
                });

            modelBuilder.Entity("Mud.Core.Entities.CharacterInstanceState", b =>
                {
                    b.HasOne("Mud.Core.Entities.Character", "Character")
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mud.Core.Entities.Room", "CurrentRoom")
                        .WithMany()
                        .HasForeignKey("CurrentRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mud.Core.Entities.DungeonInstance", "Instance")
                        .WithMany()
                        .HasForeignKey("InstanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("CurrentRoom");

                    b.Navigation("Instance");
                });

            modelBuilder.Entity("Mud.Core.Entities.DungeonInstance", b =>
                {
                    b.HasOne("Mud.Core.Entities.Dungeon", "Dungeon")
                        .WithMany()
                        .HasForeignKey("DungeonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mud.Core.Entities.Party", "Party")
                        .WithMany()
                        .HasForeignKey("PartyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dungeon");

                    b.Navigation("Party");
                });

            modelBuilder.Entity("Mud.Core.Entities.PartyMember", b =>
                {
                    b.HasOne("Mud.Core.Entities.Character", "Character")
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mud.Core.Entities.Party", "Party")
                        .WithMany("Members")
                        .HasForeignKey("PartyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Party");
                });

            modelBuilder.Entity("Mud.Core.Entities.Room", b =>
                {
                    b.HasOne("Mud.Core.Entities.Dungeon", null)
                        .WithMany("Rooms")
                        .HasForeignKey("DungeonId");
                });

            modelBuilder.Entity("Mud.Core.Entities.Dungeon", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Mud.Core.Entities.Party", b =>
                {
                    b.Navigation("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
