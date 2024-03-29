﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieApp.Web.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Data
{
    public class MovieContext:DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory
        = LoggerFactory.Create(builder => { builder.AddConsole(); });
        public MovieContext(DbContextOptions<MovieContext> options):base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Crew> Crews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .Property(b => b.Title).IsRequired();
            modelBuilder.Entity<Movie>()
                .Property(b => b.Title).HasMaxLength(500);
            modelBuilder.Entity<Genre>()
                .Property(b => b.Name).IsRequired();
            modelBuilder.Entity<Genre>()
                .Property(b => b.Name).HasMaxLength(50);

        }
    }
    
}
