﻿// <auto-generated />
using System;
using HastaTakip.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HastaTakip.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230705114632_7thMigration")]
    partial class _7thMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HastaTakip.Models.Hasta", b =>
                {
                    b.Property<int>("hasta_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("hasta_id"));

                    b.Property<string>("dogum_tarihi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("hasta_ad_soyad")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("hasta_tc")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.HasKey("hasta_id");

                    b.ToTable("hastalar");
                });

            modelBuilder.Entity("HastaTakip.Models.Ziyaret", b =>
                {
                    b.Property<int>("ziyaret_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ziyaret_id"));

                    b.Property<string>("doktor_adi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("hasta_id")
                        .HasColumnType("integer");

                    b.Property<string>("sikayet")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("tedavi_sekli")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ziyaret_tarihi")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ziyaret_id");

                    b.ToTable("ziyaretler");
                });
#pragma warning restore 612, 618
        }
    }
}
