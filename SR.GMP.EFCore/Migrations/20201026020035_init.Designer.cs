﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SR.GMP.EFCore;

namespace SR.GMP.EFCore.Migrations
{
    [DbContext(typeof(GMPContext))]
    [Migration("20201026020035_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SR.GMP.DataEntity.Alarm.GMP_ALARM_ITEM", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CENT_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CREATE_AT")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CREATOR_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ITEM_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<Guid?>("MODIFIER_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("MODIFY_AT")
                        .HasColumnType("datetime2");

                    b.Property<int>("PRIORITY")
                        .HasColumnType("int");

                    b.Property<int>("STATE")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CENT_ID");

                    b.HasIndex("CREATOR_ID");

                    b.HasIndex("MODIFIER_ID");

                    b.ToTable("GMP_ALARM_ITEM");
                });

            modelBuilder.Entity("SR.GMP.DataEntity.Alarm.GMP_ALARM_ITEM_RULE", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CREATE_AT")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CREATOR_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EVENT_ITEM_CODE")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<Guid>("ITEM_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("LOGIC_TYPE")
                        .HasColumnType("int");

                    b.Property<Guid?>("MODIFIER_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("MODIFY_AT")
                        .HasColumnType("datetime2");

                    b.Property<string>("MONITOR_ITEM_CODE")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<int>("RULE_TYPE")
                        .HasColumnType("int");

                    b.Property<int>("SORT_NUM")
                        .HasColumnType("int");

                    b.Property<int>("STATE")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CREATOR_ID");

                    b.HasIndex("ITEM_ID");

                    b.HasIndex("MODIFIER_ID");

                    b.ToTable("GMP_ALARM_ITEM_RULE");
                });

            modelBuilder.Entity("SR.GMP.DataEntity.Alarm.GMP_ALARM_RECORD", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ALARM_INFO")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<Guid>("ALARM_ITEM_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ALARM_ITEM_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("BED_LABEL")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<Guid>("CENT_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CLASS_ID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CLASS_NAME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CREATE_AT")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DATA_RECORD_TIME")
                        .HasColumnType("datetime2");

                    b.Property<string>("DOCTOR_NAME")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<DateTime?>("HANDLE_TIME")
                        .HasColumnType("datetime2");

                    b.Property<string>("NURSE_NAME")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<int>("PATIENT_AGE")
                        .HasColumnType("int");

                    b.Property<string>("PATIENT_EXT_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("PATIENT_NAME")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("PATIENT_SEX")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<int>("PRIORITY")
                        .HasColumnType("int");

                    b.Property<int>("STATE")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("GMP_ALARM_RECORD");
                });

            modelBuilder.Entity("SR.GMP.DataEntity.Alarm.GMP_ALARM_RULE_CONFIG", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CREATE_AT")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CREATOR_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IS_CONTAINMAX")
                        .HasColumnType("bit");

                    b.Property<bool>("IS_CONTAINMIN")
                        .HasColumnType("bit");

                    b.Property<bool>("IS_DIFFVALUE")
                        .HasColumnType("bit");

                    b.Property<decimal?>("MAX_VALUE")
                        .HasColumnType("decimal(8, 2)");

                    b.Property<decimal?>("MIN_VALUE")
                        .HasColumnType("decimal(8, 2)");

                    b.Property<Guid?>("MODIFIER_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("MODIFY_AT")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RULE_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("STATE")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CREATOR_ID");

                    b.HasIndex("MODIFIER_ID");

                    b.HasIndex("RULE_ID");

                    b.ToTable("GMP_ALARM_RULE_CONFIG");
                });

            modelBuilder.Entity("SR.GMP.DataEntity.Dictionary.GMP_EVENT_ITEM", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ITEM_CODE")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("ITEM_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<int?>("SORT_CODE")
                        .HasColumnType("int");

                    b.Property<int>("STATE")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("GMP_EVENT_ITEM");
                });

            modelBuilder.Entity("SR.GMP.DataEntity.Dictionary.GMP_MONITOR_ITEM", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ITEM_CODE")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("ITEM_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<int?>("SORT_CODE")
                        .HasColumnType("int");

                    b.Property<int>("STATE")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("GMP_MONITOR_ITEM");
                });

            modelBuilder.Entity("SR.GMP.DataEntity.System.SYS_DICT_CATEGORY", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CODE")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<DateTime?>("CREATE_AT")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CREATOR_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MODIFIER_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("MODIFY_AT")
                        .HasColumnType("datetime2");

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<Guid?>("P_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SORT_CODE")
                        .HasColumnType("int");

                    b.Property<int>("STATE")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CREATOR_ID");

                    b.HasIndex("MODIFIER_ID");

                    b.ToTable("SYS_DICT_CATEGORY");
                });

            modelBuilder.Entity("SR.GMP.DataEntity.System.SYS_DICT_ITEM", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CATEGORY_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CODE")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<DateTime?>("CREATE_AT")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CREATOR_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DESC")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<Guid?>("MODIFIER_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("MODIFY_AT")
                        .HasColumnType("datetime2");

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("PY")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<Guid?>("P_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SORT_CODE")
                        .HasColumnType("int");

                    b.Property<int>("STATE")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CATEGORY_ID");

                    b.HasIndex("CREATOR_ID");

                    b.HasIndex("MODIFIER_ID");

                    b.ToTable("SYS_DICT_ITEM");
                });

            modelBuilder.Entity("SR.GMP.DataEntity.System.SYS_INST", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ADDRESS")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("CODE")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CREATE_AT")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CREATOR_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MODIFIER_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("MODIFY_AT")
                        .HasColumnType("datetime2");

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("STATE")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CREATOR_ID");

                    b.HasIndex("MODIFIER_ID");

                    b.ToTable("SYS_INST");
                });

            modelBuilder.Entity("SR.GMP.DataEntity.System.SYS_INST_CENTER", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CENT_DESC")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("CODE")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<DateTime?>("CREATE_AT")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CREATOR_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EXT_ID")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<Guid>("INST_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MODIFIER_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("MODIFY_AT")
                        .HasColumnType("datetime2");

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("PY")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("SORT_CODE")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<int>("STATE")
                        .HasColumnType("int");

                    b.Property<int>("TYPE_CODE")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CREATOR_ID");

                    b.HasIndex("INST_ID");

                    b.HasIndex("MODIFIER_ID");

                    b.ToTable("SYS_INST_CENTER");
                });

            modelBuilder.Entity("SR.GMP.DataEntity.System.SYS_USER", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ACCOUNT")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<DateTime?>("CREATE_AT")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CREATOR_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GENDER")
                        .HasColumnType("int");

                    b.Property<string>("JOB_NO")
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<Guid?>("MODIFIER_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("MODIFY_AT")
                        .HasColumnType("datetime2");

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("PWD")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<int>("STATE")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CREATOR_ID");

                    b.HasIndex("MODIFIER_ID");

                    b.ToTable("SYS_USER");
                });

            modelBuilder.Entity("SR.GMP.DataEntity.Alarm.GMP_ALARM_ITEM", b =>
                {
                    b.HasOne("SR.GMP.DataEntity.System.SYS_INST_CENTER", "CENTER")
                        .WithMany()
                        .HasForeignKey("CENT_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SR.GMP.DataEntity.System.SYS_USER", "CREATE_USER")
                        .WithMany()
                        .HasForeignKey("CREATOR_ID");

                    b.HasOne("SR.GMP.DataEntity.System.SYS_USER", "MODIFY_USER")
                        .WithMany()
                        .HasForeignKey("MODIFIER_ID");
                });

            modelBuilder.Entity("SR.GMP.DataEntity.Alarm.GMP_ALARM_ITEM_RULE", b =>
                {
                    b.HasOne("SR.GMP.DataEntity.System.SYS_USER", "CREATE_USER")
                        .WithMany()
                        .HasForeignKey("CREATOR_ID");

                    b.HasOne("SR.GMP.DataEntity.Alarm.GMP_ALARM_ITEM", "ALARM_ITEM")
                        .WithMany("ALARM_ITEM_RULE_LIST")
                        .HasForeignKey("ITEM_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SR.GMP.DataEntity.System.SYS_USER", "MODIFY_USER")
                        .WithMany()
                        .HasForeignKey("MODIFIER_ID");
                });

            modelBuilder.Entity("SR.GMP.DataEntity.Alarm.GMP_ALARM_RULE_CONFIG", b =>
                {
                    b.HasOne("SR.GMP.DataEntity.System.SYS_USER", "CREATE_USER")
                        .WithMany()
                        .HasForeignKey("CREATOR_ID");

                    b.HasOne("SR.GMP.DataEntity.System.SYS_USER", "MODIFY_USER")
                        .WithMany()
                        .HasForeignKey("MODIFIER_ID");

                    b.HasOne("SR.GMP.DataEntity.Alarm.GMP_ALARM_ITEM_RULE", "ALARM_ITEM_RULE")
                        .WithMany("ALARM_RULE_CONFIG_LIST")
                        .HasForeignKey("RULE_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SR.GMP.DataEntity.System.SYS_DICT_CATEGORY", b =>
                {
                    b.HasOne("SR.GMP.DataEntity.System.SYS_USER", "CREATE_USER")
                        .WithMany()
                        .HasForeignKey("CREATOR_ID");

                    b.HasOne("SR.GMP.DataEntity.System.SYS_USER", "MODIFY_USER")
                        .WithMany()
                        .HasForeignKey("MODIFIER_ID");
                });

            modelBuilder.Entity("SR.GMP.DataEntity.System.SYS_DICT_ITEM", b =>
                {
                    b.HasOne("SR.GMP.DataEntity.System.SYS_DICT_CATEGORY", "DICT_CATEGORY")
                        .WithMany("DICT_ITEM_LIST")
                        .HasForeignKey("CATEGORY_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SR.GMP.DataEntity.System.SYS_USER", "CREATE_USER")
                        .WithMany()
                        .HasForeignKey("CREATOR_ID");

                    b.HasOne("SR.GMP.DataEntity.System.SYS_USER", "MODIFY_USER")
                        .WithMany()
                        .HasForeignKey("MODIFIER_ID");
                });

            modelBuilder.Entity("SR.GMP.DataEntity.System.SYS_INST", b =>
                {
                    b.HasOne("SR.GMP.DataEntity.System.SYS_USER", "CREATE_USER")
                        .WithMany()
                        .HasForeignKey("CREATOR_ID");

                    b.HasOne("SR.GMP.DataEntity.System.SYS_USER", "MODIFY_USER")
                        .WithMany()
                        .HasForeignKey("MODIFIER_ID");
                });

            modelBuilder.Entity("SR.GMP.DataEntity.System.SYS_INST_CENTER", b =>
                {
                    b.HasOne("SR.GMP.DataEntity.System.SYS_USER", "CREATE_USER")
                        .WithMany()
                        .HasForeignKey("CREATOR_ID");

                    b.HasOne("SR.GMP.DataEntity.System.SYS_INST", "INST")
                        .WithMany()
                        .HasForeignKey("INST_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SR.GMP.DataEntity.System.SYS_USER", "MODIFY_USER")
                        .WithMany()
                        .HasForeignKey("MODIFIER_ID");
                });

            modelBuilder.Entity("SR.GMP.DataEntity.System.SYS_USER", b =>
                {
                    b.HasOne("SR.GMP.DataEntity.System.SYS_USER", "CREATE_USER")
                        .WithMany()
                        .HasForeignKey("CREATOR_ID");

                    b.HasOne("SR.GMP.DataEntity.System.SYS_USER", "MODIFY_USER")
                        .WithMany()
                        .HasForeignKey("MODIFIER_ID");
                });
#pragma warning restore 612, 618
        }
    }
}