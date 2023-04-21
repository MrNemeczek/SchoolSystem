using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolSystem.Models
{
    public partial class school_systemContext : DbContext
    {
        public school_systemContext()
        {
        }

        public school_systemContext(DbContextOptions<school_systemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Notice> Notices { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("class");

                entity.HasIndex(e => e.IdTeacher, "id_teacher_class");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.IdTeacher)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_teacher")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdTeacherNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.IdTeacher)
                    .HasConstraintName("id_teacher_class");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("grade");

                entity.HasIndex(e => e.IdStudent, "id_student_grade");

                entity.HasIndex(e => e.IdSubject, "id_subject_grade");

                entity.HasIndex(e => e.IdTeacher, "id_teacher_grade");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date")
                    .HasComment("data wprowadzenia oceny");

                entity.Property(e => e.Grade1).HasColumnName("grade");

                entity.Property(e => e.IdStudent)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_student");

                entity.Property(e => e.IdSubject)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_subject");

                entity.Property(e => e.IdTeacher)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_teacher");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_student_grade");

                entity.HasOne(d => d.IdSubjectNavigation)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.IdSubject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_subject_grade");

                entity.HasOne(d => d.IdTeacherNavigation)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.IdTeacher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_teacher_grade");
            });

            modelBuilder.Entity<Notice>(entity =>
            {
                entity.ToTable("notice");

                entity.HasIndex(e => e.IdStudent, "id_student_notice");

                entity.HasIndex(e => e.IdTeacher, "id_teacher_notice");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Grade)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("grade")
                    .HasComment("1 - positive\n0 - negative");

                entity.Property(e => e.IdStudent)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_student");

                entity.Property(e => e.IdTeacher)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_teacher");

                entity.Property(e => e.Points)
                    .HasColumnType("int(11)")
                    .HasColumnName("points");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.Notices)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_student_notice");

                entity.HasOne(d => d.IdTeacherNavigation)
                    .WithMany(p => p.Notices)
                    .HasForeignKey(d => d.IdTeacher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_teacher_notice");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.HasIndex(e => e.IdClass, "id_class_student");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'")
                    .HasComment("1 - active\n0 - not active");

                entity.Property(e => e.AdmissionDate)
                    .HasColumnType("date")
                    .HasColumnName("admission_date");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("birthdate");

                entity.Property(e => e.IdClass)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_class")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(45)
                    .HasColumnName("lastname");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdClassNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.IdClass)
                    .HasConstraintName("id_class_student");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("subject");

                entity.HasIndex(e => e.IdTeacher, "id_teacher_subject");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.IdTeacher)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_teacher")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.Weight)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("weight");

                entity.HasOne(d => d.IdTeacherNavigation)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.IdTeacher)
                    .HasConstraintName("id_teacher_subject");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("teacher");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'")
                    .HasComment("1 - active\n0 - not active");

                entity.Property(e => e.AdmissionDate)
                    .HasColumnType("date")
                    .HasColumnName("admission_date");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("birthdate");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(45)
                    .HasColumnName("lastname");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
