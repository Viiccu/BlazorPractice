using Microsoft.AspNetCore.Mvc;

public interface IUserService
{
    public bool ValidUser(UserLogin user);
    public bool ValidateCredentials(UserLogin user);
    public void AddUser(UserLogin user);
    public void Update(UserLogin user);
    public void DeleteUser(int id);
}