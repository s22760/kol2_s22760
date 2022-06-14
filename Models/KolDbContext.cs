using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace kol2.Models
{
    public class KolDbContext : DbContext
    {
        public KolDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Musician> Musicians { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<MusicLabel> MusicLabels { get; set; }
        public virtual DbSet<MusicianTrack> MusicianTracks { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var musicians = new List<Musician>
            {
                 new Musician
                 {
                     IdMusician = 1,
                     FirstName = "Adam",
                     LastName = "Nowak",
                     Nickname = "Nickname_1"
                 },
                 new Musician
                 {
                     IdMusician = 2,
                     FirstName = "John",
                     LastName = "Smith",
                     Nickname = "Nickname_2"
                 }
            };

            var tracks = new List<Track>
            {
                 new Track
                 {
                     IdTrack = 1,
                     TrackName = "Track name 1",
                     Duration = (float)3.56,
                     IdMusicAlbum = 1
                 },
                 new Track
                 {
                     IdTrack = 2,
                     TrackName = "Track name 2",
                     Duration = (float)2.31,
                     IdMusicAlbum = 2
                 }
            };

            var albums = new List<Album>
            {
                 new Album
                 {
                     IdAlbum = 1,
                     AlbumName = "Album 11",
                     PublishDate = DateTime.Now,
                     IdMusicLabel = 1
                 },
                 new Album
                 {
                     IdAlbum = 2,
                     AlbumName = "Album 22",
                     PublishDate = DateTime.Now,
                     IdMusicLabel = 2
                 }
            };

            var musicLabels = new List<MusicLabel>
            {
                 new MusicLabel
                 {
                     IdMusicLabel = 1,
                     Name = "cool label 1"
                 },
                 new MusicLabel
                 {
                     IdMusicLabel = 2,
                     Name = "cool label 2"
                 }
            };

            var musicianTracks = new List<MusicianTrack>
            {
                 new MusicianTrack
                 {
                     IdMusician = 1,
                     IdTrack = 1
                 },
                 new MusicianTrack
                 {
                     IdMusician = 2,
                     IdTrack = 2
                 }
            };

            modelBuilder.Entity<Musician>(e =>
            {
                e.HasKey(e => e.IdMusician);
                e.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
                e.Property(e => e.LastName).HasMaxLength(50).IsRequired();
                e.Property(e => e.Nickname).HasMaxLength(20);

                e.HasData(musicians);

                e.ToTable("Musician");
            });

            modelBuilder.Entity<Track>(e =>
            {
                e.HasKey(e => e.IdTrack);
                e.Property(e => e.TrackName).HasMaxLength(20).IsRequired();
                e.Property(e => e.Duration).IsRequired();
                e.HasOne(e => e.Album)
                    .WithMany(e => e.Tracks)
                    .HasForeignKey(e => e.IdMusicAlbum);

                e.HasData(tracks);

                e.ToTable("Track");
            });
            
            modelBuilder.Entity<Album>(e =>
            {
                e.HasKey(e => e.IdAlbum);
                e.Property(e => e.AlbumName).HasMaxLength(30).IsRequired();
                e.Property(e => e.PublishDate).IsRequired();
                e.HasOne(e => e.MusicLabel)
                    .WithMany(e => e.Albums)
                    .HasForeignKey(e => e.IdMusicLabel);

                e.HasData(albums);

                e.ToTable("Album");
            });

            modelBuilder.Entity<MusicLabel>(e =>
            {
                e.HasKey(e => e.IdMusicLabel);
                e.Property(e => e.Name).HasMaxLength(50).IsRequired();

                e.HasData(musicLabels);

                e.ToTable("MusicLabel");
            });

            modelBuilder.Entity<MusicianTrack>(e =>
            {
                e.HasKey(e => e.IdTrack);
                e.HasKey(e => e.IdMusician);

                e.HasOne(e => e.Track)
                    .WithMany(e => e.Musicians)
                    .HasForeignKey(e => e.IdTrack);

                e.HasOne(e => e.Musician)
                    .WithMany(e => e.Tracks)
                    .HasForeignKey(e => e.IdMusician);

                
                e.HasData(musicianTracks);

                e.ToTable("Musician_Track");
            });
        }
    }
}
