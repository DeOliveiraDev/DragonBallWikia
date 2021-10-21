using DragonBallApi.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.DAL
{
    public class DragonBallContext : DbContext
    {
        public DragonBallContext(DbContextOptions<DragonBallContext> options) : base(options)
        {
        }
        public virtual DbSet<Characters> Characters { get; set; }
        public virtual DbSet<OriginPlanet> OriginPlanet { get; set; }
        public virtual DbSet<CharacterSpecies> CharacterSpecies { get; set; }
        public virtual DbSet<Species> Species { get; set; }
        public virtual DbSet<CoverImage> CoverImage { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Characters>(entity =>
            {
                entity.Property(x => x.Name).IsUnicode(false);
                entity.Property(x => x.Status).IsUnicode(false);
                entity.Property(e => e.Gender).IsUnicode(false);
                entity.Property(e => e.ImagePerfil).IsUnicode(false);
                entity.Property(e => e.BirthDate).IsUnicode(false);
                entity.Property(e => e.DeathDate).IsUnicode(false);
                entity.HasOne(e => e.OriginPlanet)
                .WithMany(y => y.Characters)
                .HasForeignKey(e => e.OriginPlanetId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CharacterSpecies>(entity =>
            {
                entity.HasOne(e => e.Characters)
                .WithMany(y => y.CharacterSpecies)
                .HasForeignKey(e => e.CharacterId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Species)
                .WithMany(y => y.CharacterSpecies)
                .HasForeignKey(e => e.SpecieId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Species>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
                entity.Property(e => e.ImageUrl).IsUnicode(false);
            });

            modelBuilder.Entity<OriginPlanet>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
                entity.Property(e => e.ImageUrl).IsUnicode(false);
            });

            modelBuilder.Entity<CoverImage>(entity =>
            {
                entity.Property(e => e.ImageUrl).IsUnicode(false);
            });
        }
    }
}
