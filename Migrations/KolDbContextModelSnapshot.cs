// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kol2.Models;

namespace kol2.Migrations
{
    [DbContext(typeof(KolDbContext))]
    partial class KolDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("kol2.Models.Album", b =>
                {
                    b.Property<int>("IdAlbum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("IdMusicLabel")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdAlbum");

                    b.HasIndex("IdMusicLabel");

                    b.ToTable("Album");

                    b.HasData(
                        new
                        {
                            IdAlbum = 1,
                            AlbumName = "Album 11",
                            IdMusicLabel = 1,
                            PublishDate = new DateTime(2022, 6, 14, 14, 39, 41, 816, DateTimeKind.Local).AddTicks(8623)
                        },
                        new
                        {
                            IdAlbum = 2,
                            AlbumName = "Album 22",
                            IdMusicLabel = 2,
                            PublishDate = new DateTime(2022, 6, 14, 14, 39, 41, 818, DateTimeKind.Local).AddTicks(8070)
                        });
                });

            modelBuilder.Entity("kol2.Models.MusicLabel", b =>
                {
                    b.Property<int>("IdMusicLabel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdMusicLabel");

                    b.ToTable("MusicLabel");

                    b.HasData(
                        new
                        {
                            IdMusicLabel = 1,
                            Name = "cool label 1"
                        },
                        new
                        {
                            IdMusicLabel = 2,
                            Name = "cool label 2"
                        });
                });

            modelBuilder.Entity("kol2.Models.Musician", b =>
                {
                    b.Property<int>("IdMusician")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nickname")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdMusician");

                    b.ToTable("Musician");

                    b.HasData(
                        new
                        {
                            IdMusician = 1,
                            FirstName = "Adam",
                            LastName = "Nowak",
                            Nickname = "Nickname_1"
                        },
                        new
                        {
                            IdMusician = 2,
                            FirstName = "John",
                            LastName = "Smith",
                            Nickname = "Nickname_2"
                        });
                });

            modelBuilder.Entity("kol2.Models.MusicianTrack", b =>
                {
                    b.Property<int>("IdMusician")
                        .HasColumnType("int");

                    b.Property<int>("IdTrack")
                        .HasColumnType("int");

                    b.HasKey("IdMusician");

                    b.HasIndex("IdTrack");

                    b.ToTable("Musician_Track");

                    b.HasData(
                        new
                        {
                            IdMusician = 1,
                            IdTrack = 1
                        },
                        new
                        {
                            IdMusician = 2,
                            IdTrack = 2
                        });
                });

            modelBuilder.Entity("kol2.Models.Track", b =>
                {
                    b.Property<int>("IdTrack")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Duration")
                        .HasColumnType("real");

                    b.Property<int>("IdMusicAlbum")
                        .HasColumnType("int");

                    b.Property<string>("TrackName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdTrack");

                    b.HasIndex("IdMusicAlbum");

                    b.ToTable("Track");

                    b.HasData(
                        new
                        {
                            IdTrack = 1,
                            Duration = 3.56f,
                            IdMusicAlbum = 1,
                            TrackName = "Track name 1"
                        },
                        new
                        {
                            IdTrack = 2,
                            Duration = 2.31f,
                            IdMusicAlbum = 2,
                            TrackName = "Track name 2"
                        });
                });

            modelBuilder.Entity("kol2.Models.Album", b =>
                {
                    b.HasOne("kol2.Models.MusicLabel", "MusicLabel")
                        .WithMany("Albums")
                        .HasForeignKey("IdMusicLabel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MusicLabel");
                });

            modelBuilder.Entity("kol2.Models.MusicianTrack", b =>
                {
                    b.HasOne("kol2.Models.Musician", "Musician")
                        .WithMany("Tracks")
                        .HasForeignKey("IdMusician")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("kol2.Models.Track", "Track")
                        .WithMany("Musicians")
                        .HasForeignKey("IdTrack")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Musician");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("kol2.Models.Track", b =>
                {
                    b.HasOne("kol2.Models.Album", "Album")
                        .WithMany("Tracks")
                        .HasForeignKey("IdMusicAlbum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("kol2.Models.Album", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("kol2.Models.MusicLabel", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("kol2.Models.Musician", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("kol2.Models.Track", b =>
                {
                    b.Navigation("Musicians");
                });
#pragma warning restore 612, 618
        }
    }
}
