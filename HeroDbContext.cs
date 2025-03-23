using System.Net;
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

    // public void AddSuperHero(SuperHero hero)
    // {
    //     superHeroes.Add(hero);
    // }

    // public void ModifySuperHero(SuperHero updatedHero)
    // {
    //     var hero = superHeroes.FirstOrDefault(x => x.Id == updatedHero.Id);

    //     if(hero is null) return;

    //     hero.HeroName = updatedHero.HeroName;
    //     hero.Name = updatedHero.Name;
    //     hero.City = updatedHero.City;
    //     hero.DateOfBirth = updatedHero.DateOfBirth;

    //     this.SaveChanges();
    // }

    // public void DeleteHero(int Id)
    // {
    //     var hero = superHeroes.FirstOrDefault(x => x.Id == Id);
    //     if (hero is null) return;

    //     superHeroes.Remove(hero);
    // }
}