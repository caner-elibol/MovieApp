﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieApp.Web.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MovieApp.Web.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20211003184217_MtMRelation")]
    partial class MtMRelation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("MovieApp.Web.Entity.Cast", b =>
                {
                    b.Property<int>("CastId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("CastName")
                        .HasColumnType("text");

                    b.Property<string>("Character")
                        .HasColumnType("text");

                    b.Property<int>("MovieId")
                        .HasColumnType("integer");

                    b.Property<int>("PersonId")
                        .HasColumnType("integer");

                    b.HasKey("CastId");

                    b.HasIndex("MovieId");

                    b.HasIndex("PersonId");

                    b.ToTable("Casts");
                });

            modelBuilder.Entity("MovieApp.Web.Entity.Crew", b =>
                {
                    b.Property<int>("CrewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Job")
                        .HasColumnType("text");

                    b.Property<int>("MovieId")
                        .HasColumnType("integer");

                    b.Property<int>("PersonId")
                        .HasColumnType("integer");

                    b.HasKey("CrewId");

                    b.HasIndex("MovieId");

                    b.HasIndex("PersonId");

                    b.ToTable("Crews");
                });

            modelBuilder.Entity("MovieApp.Web.Entity.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("MovieApp.Web.Entity.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int?>("GenreId")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MovieId");

                    b.HasIndex("GenreId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MovieApp.Web.Entity.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Biography")
                        .HasColumnType("text");

                    b.Property<string>("HomePage")
                        .HasColumnType("text");

                    b.Property<string>("Imdb")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PlaceOfBirth")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("PersonId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("MovieApp.Web.Entity.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MovieApp.Web.Entity.Cast", b =>
                {
                    b.HasOne("MovieApp.Web.Entity.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieApp.Web.Entity.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MovieApp.Web.Entity.Crew", b =>
                {
                    b.HasOne("MovieApp.Web.Entity.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieApp.Web.Entity.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MovieApp.Web.Entity.Movie", b =>
                {
                    b.HasOne("MovieApp.Web.Entity.Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("MovieApp.Web.Entity.Person", b =>
                {
                    b.HasOne("MovieApp.Web.Entity.User", "User")
                        .WithOne("Person")
                        .HasForeignKey("MovieApp.Web.Entity.Person", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieApp.Web.Entity.Genre", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("MovieApp.Web.Entity.User", b =>
                {
                    b.Navigation("Person");
                });
#pragma warning restore 612, 618
        }
    }
}
