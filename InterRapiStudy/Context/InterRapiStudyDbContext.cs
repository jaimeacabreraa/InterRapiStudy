using System;
using System.Collections.Generic;
using InterRapiStudy.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace InterRapiStudy.Context;

public partial class InterRapiStudyDbContext : DbContext
{
    public InterRapiStudyDbContext()
    {
    }

    public InterRapiStudyDbContext(DbContextOptions<InterRapiStudyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<ProgramStudy> ProgramStudies { get; set; }

    public virtual DbSet<ProgramSubject> ProgramSubjects { get; set; }

    public virtual DbSet<Register> Registers { get; set; }

    public virtual DbSet<RegisterDetail> RegisterDetails { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=inter_rapi_study_db;user=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Efmigrationshistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity
                .ToTable("__efmigrationshistory")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<ProgramStudy>(entity =>
        {
            entity.HasKey(e => e.ProgramId).HasName("PRIMARY");

            entity.ToTable("program_study");

            entity.Property(e => e.ProgramId).HasColumnName("program_id");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ProgramSubject>(entity =>
        {
            entity.HasKey(e => e.ProgSubjId).HasName("PRIMARY");

            entity.ToTable("program_subject");

            entity.HasIndex(e => e.ProgramId, "fk_program_detail_program1_idx");

            entity.HasIndex(e => e.SubjectId, "fk_program_detail_subject1_idx");

            entity.HasIndex(e => e.TeacherId, "fk_program_detail_teacher1_idx");

            entity.Property(e => e.ProgSubjId).HasColumnName("prog_subj_id");
            entity.Property(e => e.ProgramId).HasColumnName("program_id");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

            entity.HasOne(d => d.Program).WithMany(p => p.ProgramSubjects)
                .HasForeignKey(d => d.ProgramId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_program_detail_program1");

            entity.HasOne(d => d.Subject).WithMany(p => p.ProgramSubjects)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_program_detail_subject1");

            entity.HasOne(d => d.Teacher).WithMany(p => p.ProgramSubjects)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_program_detail_teacher1");
        });

        modelBuilder.Entity<Register>(entity =>
        {
            entity.HasKey(e => e.RegId).HasName("PRIMARY");

            entity.ToTable("register");

            entity.HasIndex(e => e.SudentId, "fk_regiter_sudent1_idx");

            entity.Property(e => e.RegId).HasColumnName("reg_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.SudentId).HasColumnName("sudent_id");
            entity.Property(e => e.Uid)
                .HasMaxLength(100)
                .HasColumnName("uid");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Sudent).WithMany(p => p.Registers).HasForeignKey(d => d.SudentId);
        });

        modelBuilder.Entity<RegisterDetail>(entity =>
        {
            entity.HasKey(e => e.RegDetId).HasName("PRIMARY");

            entity.ToTable("register_detail");

            entity.HasIndex(e => e.ProgSubjId, "fk_register_detail_program_detail1_idx");

            entity.HasIndex(e => e.RegiterId, "fk_register_detail_regiter1_idx");

            entity.Property(e => e.RegDetId).HasColumnName("reg_det_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.ProgSubjId).HasColumnName("prog_subj_id");
            entity.Property(e => e.RegiterId).HasColumnName("regiter_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.ProgSubj).WithMany(p => p.RegisterDetails).HasForeignKey(d => d.ProgSubjId);

            entity.HasOne(d => d.Regiter).WithMany(p => p.RegisterDetails)
                .HasForeignKey(d => d.RegiterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_register_detail_regiter1");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PRIMARY");

            entity.ToTable("student");

            entity.HasIndex(e => e.ProgramId, "fk_student_program1_idx");

            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(45)
                .HasColumnName("gender");
            entity.Property(e => e.Names)
                .HasMaxLength(45)
                .HasColumnName("names");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("phone_number");
            entity.Property(e => e.ProgramId).HasColumnName("program_id");
            entity.Property(e => e.Surnames)
                .HasMaxLength(45)
                .HasColumnName("surnames");

            entity.HasOne(d => d.Program).WithMany(p => p.Students)
                .HasForeignKey(d => d.ProgramId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_student_program1");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PRIMARY");

            entity.ToTable("subject");

            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.Credits).HasColumnName("credits");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PRIMARY");

            entity.ToTable("teacher");

            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
            entity.Property(e => e.Email)
                .HasMaxLength(70)
                .HasColumnName("email");
            entity.Property(e => e.Names)
                .HasMaxLength(45)
                .HasColumnName("names");
            entity.Property(e => e.Surnames)
                .HasMaxLength(45)
                .HasColumnName("surnames");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
