using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Models;

public partial class SchoolManagementContext : DbContext
{
    public SchoolManagementContext()
    {
    }

    public SchoolManagementContext(DbContextOptions<SchoolManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<ClassRoom> ClassRooms { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudySlot> StudySlots { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Database=SchoolManagement;User Id=sa;Password=123;TrustServerCertificate=true;Trusted_Connection=SSPI;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Accounts__349DA58613A10C79");

            entity.HasIndex(e => e.Username, "UQ__Accounts__536C85E41DB21E03").IsUnique();

            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Classes__CB1927A0032CBC90");

            entity.HasIndex(e => e.ClassName, "UQ__Classes__F8BF561B4E8A6C0C").IsUnique();

            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.ClassName).HasMaxLength(100);
        });

        modelBuilder.Entity<ClassRoom>(entity =>
        {
            entity.HasKey(e => e.ClassRoomId).HasName("PK__ClassRoo__742E12B1A432E613");

            entity.HasIndex(e => e.RoomName, "UQ__ClassRoo__6B500B55016A316E").IsUnique();

            entity.Property(e => e.ClassRoomId).HasColumnName("ClassRoomID");
            entity.Property(e => e.RoomName).HasMaxLength(50);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52A79FD0C76F8");

            entity.HasIndex(e => e.AccountId, "UQ__Students__349DA5870153BD8D").IsUnique();

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.FullName).HasMaxLength(100);

            entity.HasOne(d => d.Account).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.AccountId)
                .HasConstraintName("FK__Students__Accoun__3C69FB99");
        });

        modelBuilder.Entity<StudySlot>(entity =>
        {
            entity.HasKey(e => e.StudySlotId).HasName("PK__StudySlo__FFD33CCF06281414");

            entity.Property(e => e.StudySlotId).HasColumnName("StudySlotID");
            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.ClassRoomId).HasColumnName("ClassRoomID");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

            entity.HasOne(d => d.Class).WithMany(p => p.StudySlots)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__StudySlot__Class__4D94879B");

            entity.HasOne(d => d.ClassRoom).WithMany(p => p.StudySlots)
                .HasForeignKey(d => d.ClassRoomId)
                .HasConstraintName("FK__StudySlot__Class__5070F446");

            entity.HasOne(d => d.Subject).WithMany(p => p.StudySlots)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__StudySlot__Subje__4E88ABD4");

            entity.HasOne(d => d.Teacher).WithMany(p => p.StudySlots)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__StudySlot__Teach__4F7CD00D");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__Subjects__AC1BA388D769245E");

            entity.HasIndex(e => e.SubjectName, "UQ__Subjects__4C5A7D55E726008A").IsUnique();

            entity.HasIndex(e => e.SubjectCode, "UQ__Subjects__9F7CE1A93349F0C7").IsUnique();

            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.SubjectCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SubjectName).HasMaxLength(100);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teachers__EDF2594416521546");

            entity.HasIndex(e => e.AccountId, "UQ__Teachers__349DA58786045A81").IsUnique();

            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Specialty).HasMaxLength(100);

            entity.HasOne(d => d.Account).WithOne(p => p.Teacher)
                .HasForeignKey<Teacher>(d => d.AccountId)
                .HasConstraintName("FK__Teachers__Accoun__403A8C7D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
