using Microsoft.AspNetCore.Routing.Constraints;
using System.ComponentModel.DataAnnotations;

public class SuperHero
{
    public required int Id { get; set; }
    [StringLength(30)]
    public required string HeroName { get; set; }
    [StringLength(50)]
    public string? Name { get; set; }
    [StringLength(20)]
    public string? City { get; set; }
    [Required]
    public DateTime DateOfBirth { get; set; }

    public SuperHero() { }
}