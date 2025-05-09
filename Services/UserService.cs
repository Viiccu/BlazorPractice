using System.Numerics;
using Azure.Identity;
using System.Text.RegularExpressions;

public class UserService : IUserService
{
    HeroDbContext _context;

    public UserService(HeroDbContext context) => _context = context;

    public bool ValidateCredentials(UserLogin user)
    {
        return  user.Username.Length <= 15
                && user.Username.Length > 4
                && user.Password.Length <= 15
                && user.Password.Length > 4
                && Regex.IsMatch(user.Password, "\\d") 
                && Regex.IsMatch(user.Password, "[a-zA-Z]")
                && (string.Compare(user.Role, "User") == 0 || string.Compare(user.Role, "Admin") == 0);
    }

    public bool ValidUser(UserLogin user) { 
        var validUser = _context.userLogins.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);

        return validUser is not null; 
    }
    
    public void AddUser(UserLogin user) {
        _context.userLogins.Add(user);
        _context.SaveChanges();
    }
    
    public void Update(UserLogin user) { 

    }
    
    public void DeleteUser(int id) { 

    }
}