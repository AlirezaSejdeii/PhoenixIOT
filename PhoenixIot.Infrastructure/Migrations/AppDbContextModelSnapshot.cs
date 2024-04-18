﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhoenixIot.Infrastructure;

#nullable disable

namespace PhoenixIot.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PhoenixIot.Core.Entities.Device", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<bool>("FanSwitch1")
                        .HasColumnType("bit")
                        .HasColumnName("fan_switch_1");

                    b.Property<bool>("FanSwitch2")
                        .HasColumnType("bit")
                        .HasColumnName("fan_switch_2");

                    b.Property<long?>("FanSwitchOnAt")
                        .HasColumnType("bigint")
                        .HasColumnName("water_switch_on_humidity");

                    b.Property<string>("Humidity")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("humidity");

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("identifier");

                    b.Property<DateTime?>("LastSync")
                        .HasColumnType("datetime2")
                        .HasColumnName("last_sync");

                    b.Property<int>("Setting")
                        .HasColumnType("int")
                        .HasColumnName("setting");

                    b.Property<string>("Temperature")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("temperature");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Val1")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("val_1");

                    b.Property<string>("Val10")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("val_10");

                    b.Property<string>("Val11")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("val_11");

                    b.Property<string>("Val12")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("val_12");

                    b.Property<string>("Val13")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("val_13");

                    b.Property<string>("Val14")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("val_14");

                    b.Property<string>("Val15")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("val_15");

                    b.Property<string>("Val16")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("val_16");

                    b.Property<string>("Val17")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("val_17");

                    b.Property<string>("Val18")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("val_18");

                    b.Property<string>("Val19")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("val_19");

                    b.Property<string>("Val2")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("val_2");

                    b.Property<string>("Val20")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("val_20");

                    b.Property<string>("Val3")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("val_3");

                    b.Property<string>("Val4")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("val_4");

                    b.Property<string>("Val5")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("val_5");

                    b.Property<string>("Val6")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("val_6");

                    b.Property<string>("Val7")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("val_7");

                    b.Property<string>("Val8")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("val_8");

                    b.Property<string>("Val9")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("val_9");

                    b.Property<bool>("WaterSwitch1")
                        .HasColumnType("bit")
                        .HasColumnName("water_switch_1");

                    b.Property<bool>("WaterSwitch2")
                        .HasColumnType("bit")
                        .HasColumnName("water_switch_2");

                    b.Property<long?>("WaterSwitchOnAt")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("PhoenixIot.Core.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("description");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("title");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("PhoenixIot.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("password");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<Guid>("RolesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("PhoenixIot.Core.Entities.Device", b =>
                {
                    b.HasOne("PhoenixIot.Core.Entities.User", "User")
                        .WithMany("Devices")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("PhoenixIot.Core.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PhoenixIot.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PhoenixIot.Core.Entities.User", b =>
                {
                    b.Navigation("Devices");
                });
#pragma warning restore 612, 618
        }
    }
}
