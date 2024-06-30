﻿// <auto-generated />
using System;
using InterRapiStudy.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InterRapiStudy.Migrations
{
    [DbContext(typeof(InterRapiStudyDbContext))]
    partial class InterRapiStudyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb3_general_ci")
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb3");
            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("InterRapiStudy.Models.Efmigrationshistory", b =>
                {
                    b.Property<string>("MigrationId")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("ProductVersion")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.HasKey("MigrationId")
                        .HasName("PRIMARY");

                    b.ToTable("__efmigrationshistory", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb4");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb4_0900_ai_ci");
                });

            modelBuilder.Entity("InterRapiStudy.Models.ProgramStudy", b =>
                {
                    b.Property<int>("ProgramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("program_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ProgramId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("name");

                    b.HasKey("ProgramId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Name" }, "program_study_unique")
                        .IsUnique();

                    b.ToTable("program_study", (string)null);
                });

            modelBuilder.Entity("InterRapiStudy.Models.ProgramSubject", b =>
                {
                    b.Property<int>("ProgSubjId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("prog_subj_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ProgSubjId"));

                    b.Property<int>("ProgramId")
                        .HasColumnType("int")
                        .HasColumnName("program_id");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int")
                        .HasColumnName("subject_id");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int")
                        .HasColumnName("teacher_id");

                    b.HasKey("ProgSubjId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ProgramId" }, "fk_program_detail_program1_idx");

                    b.HasIndex(new[] { "SubjectId" }, "fk_program_detail_subject1_idx");

                    b.HasIndex(new[] { "TeacherId" }, "fk_program_detail_teacher1_idx");

                    b.ToTable("program_subject", (string)null);
                });

            modelBuilder.Entity("InterRapiStudy.Models.Register", b =>
                {
                    b.Property<int>("RegId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("reg_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("RegId"));

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("student_id");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("uid");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("RegId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "StudentId" }, "fk_regiter_sudent1_idx");

                    b.HasIndex(new[] { "Uid" }, "register_unique")
                        .IsUnique();

                    b.ToTable("register", (string)null);
                });

            modelBuilder.Entity("InterRapiStudy.Models.RegisterDetail", b =>
                {
                    b.Property<int>("RegDetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("reg_det_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("RegDetId"));

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("ProgSubjId")
                        .HasColumnType("int")
                        .HasColumnName("prog_subj_id");

                    b.Property<int>("RegiterId")
                        .HasColumnType("int")
                        .HasColumnName("regiter_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("RegDetId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ProgSubjId" }, "fk_register_detail_program_detail1_idx");

                    b.HasIndex(new[] { "RegiterId" }, "fk_register_detail_regiter1_idx");

                    b.ToTable("register_detail", (string)null);
                });

            modelBuilder.Entity("InterRapiStudy.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("student_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<int>("Age")
                        .HasColumnType("int")
                        .HasColumnName("age");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("gender");

                    b.Property<string>("Names")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("names");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("password");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("phone_number");

                    b.Property<int>("ProgramId")
                        .HasColumnType("int")
                        .HasColumnName("program_id");

                    b.Property<string>("Surnames")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("surnames");

                    b.HasKey("StudentId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ProgramId" }, "fk_student_program1_idx");

                    b.HasIndex(new[] { "Email" }, "student_unique")
                        .IsUnique();

                    b.ToTable("student", (string)null);
                });

            modelBuilder.Entity("InterRapiStudy.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("subject_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("SubjectId"));

                    b.Property<int>("Credits")
                        .HasColumnType("int")
                        .HasColumnName("credits");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("name");

                    b.HasKey("SubjectId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Name" }, "subject_unique")
                        .IsUnique();

                    b.ToTable("subject", (string)null);
                });

            modelBuilder.Entity("InterRapiStudy.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("teacher_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)")
                        .HasColumnName("email");

                    b.Property<string>("Names")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("names");

                    b.Property<string>("Surnames")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("surnames");

                    b.HasKey("TeacherId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Email" }, "teacher_unique")
                        .IsUnique();

                    b.ToTable("teacher", (string)null);
                });

            modelBuilder.Entity("InterRapiStudy.Models.ProgramSubject", b =>
                {
                    b.HasOne("InterRapiStudy.Models.ProgramStudy", "Program")
                        .WithMany("ProgramSubjects")
                        .HasForeignKey("ProgramId")
                        .IsRequired()
                        .HasConstraintName("fk_program_detail_program1");

                    b.HasOne("InterRapiStudy.Models.Subject", "Subject")
                        .WithMany("ProgramSubjects")
                        .HasForeignKey("SubjectId")
                        .IsRequired()
                        .HasConstraintName("fk_program_detail_subject1");

                    b.HasOne("InterRapiStudy.Models.Teacher", "Teacher")
                        .WithMany("ProgramSubjects")
                        .HasForeignKey("TeacherId")
                        .IsRequired()
                        .HasConstraintName("fk_program_detail_teacher1");

                    b.Navigation("Program");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("InterRapiStudy.Models.Register", b =>
                {
                    b.HasOne("InterRapiStudy.Models.Student", "Student")
                        .WithMany("Registers")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_register_student_sudent_id");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("InterRapiStudy.Models.RegisterDetail", b =>
                {
                    b.HasOne("InterRapiStudy.Models.ProgramSubject", "ProgSubj")
                        .WithMany("RegisterDetails")
                        .HasForeignKey("ProgSubjId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_register_detail_program_subject_prog_subjl_id");

                    b.HasOne("InterRapiStudy.Models.Register", "Regiter")
                        .WithMany("RegisterDetails")
                        .HasForeignKey("RegiterId")
                        .IsRequired()
                        .HasConstraintName("fk_register_detail_regiter1");

                    b.Navigation("ProgSubj");

                    b.Navigation("Regiter");
                });

            modelBuilder.Entity("InterRapiStudy.Models.Student", b =>
                {
                    b.HasOne("InterRapiStudy.Models.ProgramStudy", "Program")
                        .WithMany("Students")
                        .HasForeignKey("ProgramId")
                        .IsRequired()
                        .HasConstraintName("fk_student_program1");

                    b.Navigation("Program");
                });

            modelBuilder.Entity("InterRapiStudy.Models.ProgramStudy", b =>
                {
                    b.Navigation("ProgramSubjects");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("InterRapiStudy.Models.ProgramSubject", b =>
                {
                    b.Navigation("RegisterDetails");
                });

            modelBuilder.Entity("InterRapiStudy.Models.Register", b =>
                {
                    b.Navigation("RegisterDetails");
                });

            modelBuilder.Entity("InterRapiStudy.Models.Student", b =>
                {
                    b.Navigation("Registers");
                });

            modelBuilder.Entity("InterRapiStudy.Models.Subject", b =>
                {
                    b.Navigation("ProgramSubjects");
                });

            modelBuilder.Entity("InterRapiStudy.Models.Teacher", b =>
                {
                    b.Navigation("ProgramSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
