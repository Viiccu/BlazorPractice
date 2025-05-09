using System.Net;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

public class HeroDbContext : DbContext
{
    public HeroDbContext() { }
    override protected void OnConfiguring(DbContextOptionsBuilder options) { }

    public HeroDbContext(DbContextOptions<HeroDbContext> options) : base(options) { }

    public DbSet<SuperHero> superHeroes { get; set; }

    public DbSet<UserLogin> userLogins { get; set; }
}