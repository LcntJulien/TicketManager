using Microsoft.EntityFrameworkCore;
using TicketManager.Core.Entities;
using TicketManager.Core.Enums;
using System.Collections.Generic;

namespace TicketManager.Infrastructure.Data
{
    public class TicketManagerDbContext : DbContext
    {
        public TicketManagerDbContext(DbContextOptions<TicketManagerDbContext> options)
            : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- User
            // User <-> Role (many-to-many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity<Dictionary<string, object>>( // User <-> Role link seed (Admin <-> admin), (Manager & User <-> asmith) 
                    "UserRoles",
                    j => j.HasData(
                        new { RolesId = 1, UsersId = 1 },
                        new { RolesId = 2, UsersId = 3 },
                        new { RolesId = 3, UsersId = 3 }
                        )
                );

            // User <-> RefreshTokens (one-to-many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.RefreshTokens)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // IsActive default value
            modelBuilder.Entity<User>()
                .Property(u => u.IsActive)
                .HasDefaultValue(true);

            // --- Ticket
            // Ticket <-> User (relations)
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.CreatedBy)
                .WithMany(u => u.CreatedTickets)
                .HasForeignKey(t => t.CreatedById)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.AssignedUsers)
                .WithMany(u => u.AssignedTickets)
                .UsingEntity(j => j.ToTable("TicketAssignments"));

            // Ticket <-> Role (relation)
            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.AssignedRoles)
                .WithMany()
                .UsingEntity(j => j.ToTable("TicketRoleAssignments"));

            // Status default value
            modelBuilder.Entity<Ticket>()
                .Property(t => t.Status)
                .HasDefaultValue(TicketStatus.Backlog);

            // Enums conversion for readability (optional)
            modelBuilder.Entity<Ticket>()
                .Property(t => t.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Ticket>()
                .Property(t => t.Priority)
                .HasConversion<string>();

            // --- RefreshToken
            // IsRevoked default value
            modelBuilder.Entity<RefreshToken>()
                .Property(r => r.IsRevoked)
                .HasDefaultValue(false);

            // --- Seed data

            // Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "User" },
                new Role { Id = 3, Name = "Manager" }
            );

            // Users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Email = "admin@ticketmanager.local",
                    PasswordHash = "HASH_PLACEHOLDER"
                },
                new User
                {
                    Id = 2,
                    Username = "jdoe",
                    Email = "john.doe@ticketmanager.local",
                    PasswordHash = "HASH_PLACEHOLDER"
                },
                new User
                {
                    Id = 3,
                    Username = "asmith",
                    Email = "anna.smith@ticketmanager.local",
                    PasswordHash = "HASH_PLACEHOLDER"
                }
            );
            
            // Tickets
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket
                {
                    Id = 1,
                    Title = "Impossible d'accéder à l'application",
                    Description = "Erreur 500 sur la page d'accueil",
                    Status = TicketStatus.Open,
                    Priority = TicketPriority.High,
                    CreatedById = 2
                },
                new Ticket
                {
                    Id = 2,
                    Title = "Demande de fonctionnalité : export CSV",
                    Description = "Permettre l'export des tickets au format CSV",
                    Status = TicketStatus.InProgress,
                    Priority = TicketPriority.Medium,
                    CreatedById = 3
                }
            );
        }
    }
}