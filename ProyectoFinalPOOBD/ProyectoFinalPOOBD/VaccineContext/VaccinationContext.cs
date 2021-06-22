using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProyectoFinalPOOBD.Models;

#nullable disable

namespace ProyectoFinalPOOBD.VaccineContext
{
    public partial class VaccinationContext : DbContext
    {
        public VaccinationContext()
        {
        }

        public VaccinationContext(DbContextOptions<VaccinationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Cabin> Cabins { get; set; }
        public virtual DbSet<Citizen> Citizens { get; set; }
        public virtual DbSet<Disease> Diseases { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeType> EmployeeTypes { get; set; }
        public virtual DbSet<Institution> Institutions { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<SideEffect> SideEffects { get; set; }
        public virtual DbSet<SideEffectXappointment> SideEffectXappointments { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost; Database = Vaccination; Trusted_Connection = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.IdAppointment)
                    .HasName("PK__Appointm__6ECCF90241BBC7EA");

                entity.ToTable("Appointment");

                entity.Property(e => e.IdAppointment).HasColumnName("Id_Appointment");

                entity.Property(e => e.AppointmentDate).HasColumnType("datetime");

                entity.Property(e => e.IdCitizen).HasColumnName("Id_Citizen");

                entity.Property(e => e.IdEmployee).HasColumnName("Id_Employee");

                entity.Property(e => e.IdPlace).HasColumnName("Id_Place");

                entity.Property(e => e.IdVaccination).HasColumnName("Id_Vaccination");

                entity.Property(e => e.VaccineDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.IdCitizenNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdCitizen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Appointme__Id_Ci__3E52440B");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("FK__Appointme__Id_Em__3F466844");

                entity.HasOne(d => d.IdPlaceNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdPlace)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Appointme__Id_Pl__403A8C7D");
            });

            modelBuilder.Entity<Cabin>(entity =>
            {
                entity.ToTable("Cabin");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Citizen>(entity =>
            {
                entity.ToTable("Citizen");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dui)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdInstitution).HasColumnName("Id_Institution");

                entity.Property(e => e.Mail)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdInstitutionNavigation)
                    .WithMany(p => p.Citizens)
                    .HasForeignKey(d => d.IdInstitution)
                    .HasConstraintName("FK__Citizen__Id_Inst__36B12243");
            });

            modelBuilder.Entity<Disease>(entity =>
            {
                entity.ToTable("Disease");

                entity.Property(e => e.IdCitizen).HasColumnName("Id_Citizen");

                entity.Property(e => e.Illness)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCitizenNavigation)
                    .WithMany(p => p.Diseases)
                    .HasForeignKey(d => d.IdCitizen)
                    .HasConstraintName("FK__Disease__Id_Citi__398D8EEE");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasIndex(e => e.IdCabin, "UQ__Employee__5C171949FFFAE471")
                    .IsUnique();

                entity.HasIndex(e => e.IdUser, "UQ__Employee__D03DEDCAFBE15F62")
                    .IsUnique();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdCabin).HasColumnName("Id_Cabin");

                entity.Property(e => e.IdEmployeeType).HasColumnName("Id_EmployeeType");

                entity.Property(e => e.IdUser).HasColumnName("Id_User");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCabinNavigation)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.IdCabin)
                    .HasConstraintName("FK__Employee__Id_Cab__2D27B809");

                entity.HasOne(d => d.IdEmployeeTypeNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdEmployeeType)
                    .HasConstraintName("FK__Employee__Id_Emp__2E1BDC42");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.IdUser)
                    .HasConstraintName("FK__Employee__Id_Use__2C3393D0");
            });

            modelBuilder.Entity<EmployeeType>(entity =>
            {
                entity.ToTable("EmployeeType");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Institution>(entity =>
            {
                entity.ToTable("Institution");

                entity.Property(e => e.InstitutionName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("Login");

                entity.Property(e => e.IdCabin).HasColumnName("Id_Cabin");

                entity.Property(e => e.IdEmployee).HasColumnName("Id_Employee");

                entity.Property(e => e.LoginDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdCabinNavigation)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.IdCabin)
                    .HasConstraintName("FK__Login__Id_Cabin__31EC6D26");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("FK__Login__Id_Employ__30F848ED");
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.ToTable("Place");

                entity.Property(e => e.PlaceName)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SideEffect>(entity =>
            {
                entity.ToTable("SideEffect");

                entity.Property(e => e.Effect)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SideEffectXappointment>(entity =>
            {
                entity.HasKey(e => new { e.IdAppointment, e.IdSideEffect });

                entity.ToTable("SideEffectXAppointment");

                entity.Property(e => e.IdAppointment).HasColumnName("Id_Appointment");

                entity.Property(e => e.IdSideEffect).HasColumnName("Id_SideEffect");

                entity.HasOne(d => d.IdAppointmentNavigation)
                    .WithMany(p => p.SideEffectXappointments)
                    .HasForeignKey(d => d.IdAppointment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SideEffec__Id_Ap__44FF419A");

                entity.HasOne(d => d.IdSideEffectNavigation)
                    .WithMany(p => p.SideEffectXappointments)
                    .HasForeignKey(d => d.IdSideEffect)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SideEffec__Id_Si__45F365D3");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
