public interface IHeroService
{
    public Task<List<SuperHero>> GetHeroes();
    public void AddHero(SuperHero hero);
    public void UpdateHero(SuperHero newHero);
    public void DeleteHero(int id);
}