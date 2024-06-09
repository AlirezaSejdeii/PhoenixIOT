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

                    b.Property<TimeOnly>("EndWorkAtRelay1")
                        .HasColumnType("time")
                        .HasColumnName("relay_1_end_work_at");

                    b.Property<TimeOnly>("EndWorkAtRelay2")
                        .HasColumnType("time")
                        .HasColumnName("relay_2_end_work_at");

                    b.Property<TimeOnly>("EndWorkAtRelay3")
                        .HasColumnType("time")
                        .HasColumnName("relay_3_end_work_at");

                    b.Property<TimeOnly>("EndWorkAtRelay4")
                        .HasColumnType("time")
                        .HasColumnName("relay_4_end_work_at");

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("identifier");

                    b.Property<DateTime?>("LastSync")
                        .HasColumnType("datetime2")
                        .HasColumnName("last_sync");

                    b.Property<string>("LightBrightness")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("light_brightness");

                    b.Property<int>("LightBrightnessLimit")
                        .HasColumnType("int")
                        .HasColumnName("light_brightness_limit");

                    b.Property<int>("Setting")
                        .HasColumnType("int")
                        .HasColumnName("setting");

                    b.Property<string>("SoilHumidity")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("soil_humidity");

                    b.Property<int>("SoilHumidityLimit")
                        .HasColumnType("int")
                        .HasColumnName("soil_humidity_limit");

                    b.Property<TimeOnly>("StartWorkAtRelay1")
                        .HasColumnType("time")
                        .HasColumnName("relay_1_start_work_at");

                    b.Property<TimeOnly>("StartWorkAtRelay2")
                        .HasColumnType("time")
                        .HasColumnName("relay_2_start_work_at");

                    b.Property<TimeOnly>("StartWorkAtRelay3")
                        .HasColumnType("time")
                        .HasColumnName("relay_3_start_work_at");

                    b.Property<TimeOnly>("StartWorkAtRelay4")
                        .HasColumnType("time")
                        .HasColumnName("relay_4_start_work_at");

                    b.Property<bool>("Switch1")
                        .HasColumnType("bit")
                        .HasColumnName("switch_1");

                    b.Property<string>("Switch1Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("switch_1_name");

                    b.Property<bool>("Switch2")
                        .HasColumnType("bit")
                        .HasColumnName("switch_2");

                    b.Property<string>("Switch2Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("switch_2_name");

                    b.Property<bool>("Switch3")
                        .HasColumnType("bit")
                        .HasColumnName("switch_3");

                    b.Property<string>("Switch3Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("switch_3_name");

                    b.Property<bool>("Switch4")
                        .HasColumnType("bit")
                        .HasColumnName("switch_4");

                    b.Property<string>("Switch4Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("switch_4_name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Val1")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("val_1");

                    b.Property<string>("Val10")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("val_10");

                    b.Property<string>("Val11")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("val_11");

                    b.Property<string>("Val12")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("val_12");

                    b.Property<string>("Val13")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("val_13");

                    b.Property<string>("Val14")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("val_14");

                    b.Property<string>("Val15")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("val_15");

                    b.Property<string>("Val16")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("val_16");

                    b.Property<string>("Val17")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("val_17");

                    b.Property<string>("Val18")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("val_18");

                    b.Property<string>("Val19")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("val_19");

                    b.Property<string>("Val2")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("val_2");

                    b.Property<string>("Val20")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("val_20");

                    b.Property<string>("Val3")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("val_3");

                    b.Property<string>("Val4")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("val_4");

                    b.Property<string>("Val5")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("val_5");

                    b.Property<string>("Val6")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("val_6");

                    b.Property<string>("Val7")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("val_7");

                    b.Property<string>("Val8")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("val_8");

                    b.Property<string>("Val9")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("val_9");

                    b.Property<string>("WhetherHumidity")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("whether_humidity");

                    b.Property<int>("WhetherHumidityLimit")
                        .HasColumnType("int")
                        .HasColumnName("whether_humidity_limit");

                    b.Property<string>("WhetherTemperature")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("whether_temperature");

                    b.Property<int>("WhetherTemperatureLimit")
                        .HasColumnType("int")
                        .HasColumnName("whether_temperature_limit");

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

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("is_active");

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
