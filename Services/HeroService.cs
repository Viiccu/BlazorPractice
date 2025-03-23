using Microsoft.EntityFrameworkCore;

public class HeroService : IHeroService
{
    private readonly HeroDbContext _context;
    
    public HeroService(HeroDbContext context)
    {
        _context = context;
    }

    public async Task<List<SuperHero>> GetHeroes() 
    { 
        var heroes = await _context.superHeroes.ToListAsync(); 
        return heroes;
    }

    public void AddHero(SuperHero hero)
    {
        _context.superHeroes.Add(hero);
        _context.SaveChanges();
    }

    public void UpdateHero(SuperHero newHero)
    {
        var hero = _context.superHeroes.FirstOrDefault(x => x.Id == newHero.Id);

        if(hero is null) return;

        hero.HeroName = newHero.HeroName;
        hero.Name = newHero.Name;
        hero.City = newHero.City;
        hero.DateOfBirth = newHero.DateOfBirth;

        _context.SaveChanges();
    }

    public void DeleteHero(int id)
    {
        var hero = _context.superHeroes.FirstOrDefault(x => x.Id == id);

        if (hero is null) return;

        _context.superHeroes.Remove(hero);
        
        _context.SaveChanges();
    }
}
