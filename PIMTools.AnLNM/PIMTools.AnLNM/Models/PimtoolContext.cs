using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PIMTools.AnLNM.Models;

public partial class PimtoolContext : DbContext
{
    public PimtoolContext()
    {
    }

    public PimtoolContext(DbContextOptions<PimtoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Project> Projects { get; set; }    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EMPLOYEE__3214EC2738ECD5F2");

            entity.ToTable("EMPLOYEE");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(19, 0)")
                .HasColumnName("ID");
            entity.Property(e => e.BirthDate)
                .HasColumnType("date")
                .HasColumnName("BIRTH_DATE");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.Version)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("VERSION");
            entity.Property(e => e.Visa)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("VISA");
            entity.Property(e => e.IsExist)
                .HasColumnType("char(3)")
                .HasColumnName("ISEXIST");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GROUP__3214EC2723DFF6F0");

            entity.ToTable("GROUP");

            entity.Property(e => e.Id)
                .HasColumnType("numeric(19, 0)")
                .HasColumnName("ID");
            entity.Property(e => e.GroupLeaderId)
                .HasColumnType("numeric(19, 0)")
                .HasColumnName("GROUP_LEADER_ID");
            entity.Property(e => e.Version)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("VERSION");
            entity.Property(e => e.IsExist)
                .HasColumnType("char(3)")
                .HasColumnName("ISEXIST");
            entity.HasOne(d => d.GroupLeader).WithMany(p => p.Groups)
                .HasForeignKey(d => d.GroupLeaderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GROUP_LEADER_ID");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PROJECT__3214EC27878D6444");

            entity.ToTable("PROJECT");

            entity.Property(e => e.Id)
                .HasColumnType("numeric(19, 0)")
                .HasColumnName("ID");
            entity.Property(e => e.Customer)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CUSTOMER");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("END_DATE");
            entity.Property(e => e.GroupId)
                .HasColumnType("numeric(19, 0)")
                .HasColumnName("GROUP_ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.ProjectNumber)
                .HasColumnType("numeric(4, 0)")
                .HasColumnName("PROJECT_NUMBER");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("START_DATE");
            entity.Property(e => e.Status)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("STATUS");
            entity.Property(e => e.Version)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("VERSION");
            entity.Property(e => e.IsExist)
                .HasColumnType("char(3)")
                .HasColumnName("ISEXIST");

            entity.HasOne(d => d.Group).WithMany(p => p.Projects)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PROJECT_PROJECT_GROUP");

            entity.HasMany(d => d.Employees).WithMany(p => p.Projects)
                .UsingEntity<Dictionary<string, object>>(
                    "ProjectEmployee",
                    r => r.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PROJECT_EMPLOYEE_EMPLOYEE"),
                    l => l.HasOne<Project>().WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PROJECT_EMPLOYEE_PROJECT"),
                    j =>
                    {
                        j.HasKey("ProjectId", "EmployeeId");
                        j.ToTable("PROJECT_EMPLOYEE");
                        j.IndexerProperty<decimal>("ProjectId")
                            .HasColumnType("numeric(19, 0)")
                            .HasColumnName("PROJECT_ID");
                        j.IndexerProperty<decimal>("EmployeeId")
                            .HasColumnType("numeric(19, 0)")
                            .HasColumnName("EMPLOYEE_ID");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
