namespace Entities.Exceptions;

public class RoleNotFoundException : NotFoundException
{
    public RoleNotFoundException(int id) : base($"Role with id: {id} does not exist.")
    {
    }
    
    public RoleNotFoundException(string name) : base($"Role with name: {name} does not exist.")
    {
    }
}