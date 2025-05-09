using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;


public class UserLogin{

[Key]
public int Id { get; set; }

[Required]
[StringLength(15, MinimumLength = 4)]
public string Username { get; set; }

[Required]
[StringLength(15, MinimumLength = 6)]
public string Password { get; set; }

[Required]
[StringLength(10)]
public string Role { get; set; }

public UserLogin() { }

}