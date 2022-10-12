namespace Entities.Exceptions;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(string email) : base($"User with email: {email} does not exist.")
    {
    }
    
    public UserNotFoundException(int id) : base($"User with id: {id} does not exist.")
    {
    }
}