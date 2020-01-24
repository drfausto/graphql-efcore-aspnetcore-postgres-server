using Microsoft.EntityFrameworkCore;
using EFCourse.Models;

namespace EFCourse.Data {
	public class CourseContext : DbContext {
		public virtual DbSet<University> University { get; set; }
		public virtual DbSet<Department> Department { get; set; }
		public virtual DbSet<Course> Course	{ get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			if (!optionsBuilder.IsConfigured) {
				optionsBuilder.UseNpgsql(
					"Host=localhost;Database=coursedb;Username=postgres;Password=12345678"
				);
			}
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.Entity<University>(entity => {
				entity.Property(e => e.UniversityId).HasColumnName("UniversityId");
				entity.Property(e => e.Name)
					.IsRequired().HasMaxLength(64).IsUnicode(false);
				entity.Property(e => e.City)
					.IsRequired().HasMaxLength(32).IsUnicode(false);
				entity.Property(e => e.State)
					.HasMaxLength(32).IsUnicode(false);
				entity.Property(e => e.Country)
					.IsRequired().HasMaxLength(32).IsUnicode(false);
			});

			modelBuilder.Entity<Department>(entity => {
				entity.Property(e => e.DepartmentId).HasColumnName("DepartmentId");
				entity.Property(e => e.Name)
					.IsRequired().HasMaxLength(64).IsUnicode(false);
				entity.Property(e => e.UniversityId).HasColumnName("UniversityId");
				entity.HasOne(d => d.University)
				.WithMany(p => p.Department)
				.HasForeignKey(d => d.UniversityId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_University");
			});

			modelBuilder.Entity<Course>(entity => {
				entity.Property(e => e.CourseID).HasColumnName("CourseId");
				entity.Property(e => e.Name)
					.IsRequired().HasMaxLength(128).IsUnicode(false);
				entity.Property(e => e.Description)
					.IsRequired().IsUnicode(false);
				entity.Property(e => e.DepartmentId).HasColumnName("DepartmentId");
				entity.HasOne(d => d.Department)
				.WithMany(p => p.Course)
				.HasForeignKey(d => d.DepartmentId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Department");
			});
		}
	}
}
