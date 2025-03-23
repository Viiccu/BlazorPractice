using Microsoft.AspNetCore.Routing.Constraints;

public class SuperHero
{
    public required int Id { get; set; }
    public required string HeroName { get; set; }
    public string? Name { get; set; }
    public string? City { get; set; }
    public DateTime DateOfBirth { get; set; }

    public SuperHero() { }
}