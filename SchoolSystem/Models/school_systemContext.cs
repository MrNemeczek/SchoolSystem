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

        public virtual DbSet<Class> Class { get; set; } = null!;
        public virtual DbSet<Classes> Classes { get; set; } = null!;
        public virtual DbSet<Grade> Grade { get; set; } = null!;
        public virtual DbSet<Notice> Notice { get; set; } = null!;
        public virtual DbSet<Student> Student { get; set; } = null!;
        public virtual DbSet<Subject> Subject { get; set; } = null!;
        public virtual DbSet<Teacher> Teacher { get; set; } = null!;
        public virtual DbSet<User> User { get; set; } = null!;

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

            modelBuilder.Entity<Classes>(entity =>
            {
                entity.ToTable("classes");

                entity.HasComment("zajęcia szkolne");

                entity.HasIndex(e => e.IdClass, "id_class_classes");

                entity.HasIndex(e => e.IdSubject, "id_subject_classes");

                entity.HasIndex(e => e.IdTeacher, "id_teacher_classes");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.IdClass)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_class");

                entity.Property(e => e.IdSubject)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_subject");

                entity.Property(e => e.IdTeacher)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_teacher");

                entity.HasOne(d => d.IdClassNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.IdClass)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_class_classes");

                entity.HasOne(d => d.IdSubjectNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.IdSubject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_subject_classes");

                entity.HasOne(d => d.IdTeacherNavigation)
                    .WithMany(p => p.InverseIdTeacherNavigation)
                    .HasForeignKey(d => d.IdTeacher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_teacher_classes");
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

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(45)
                    .HasColumnName("lastname")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.HasIndex(e => e.IdPerson, "id_person_student");

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

                entity.Property(e => e.IdPerson)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_person");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.IdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_person_student");
            });

            modelBuilder.Entity<StudentClass>(entity =>
            {
                entity.ToTable("student_class");

                entity.HasComment("tabela ktora zawiera studentow przypisanych do klasy i date od kiedy byli w tej klasie do kiedy i czy jest to aktywne");

                entity.HasIndex(e => e.IdClass, "id_class_student_class");

                entity.HasIndex(e => e.IdStudent, "id_student_student_class");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("date")
                    .HasColumnName("date_from")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DateTo)
                    .HasColumnType("date")
                    .HasColumnName("date_to")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdClass)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_class");

                entity.Property(e => e.IdStudent)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_student");

                entity.HasOne(d => d.IdClassNavigation)
                    .WithMany(p => p.StudentClasses)
                    .HasForeignKey(d => d.IdClass)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_class_student_class");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.StudentClasses)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_student_student_class");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("subject");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("teacher");

                entity.HasIndex(e => e.IdPerson, "id_person_teacher");

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

                entity.Property(e => e.IdPerson)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_person");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.IdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_person_teacher");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.IdPerson, "id_person_user");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.IdPerson)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_person")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Login)
                    .HasMaxLength(45)
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .HasColumnType("text")
                    .HasColumnName("password");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdPerson)
                    .HasConstraintName("id_person_user");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}