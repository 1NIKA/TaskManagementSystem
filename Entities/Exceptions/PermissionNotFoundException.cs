namespace Entities.Exceptions;

public class PermissionNotFoundException : NotFoundException
{
    public PermissionNotFoundException(int id) : base($"Permission with id: {id} does not exist.")
    {
    }
}