namespace Mud.Core.Exceptions;

public class DbSavingFailedException : Exception
{
    public DbSavingFailedException(string? message) : base(message)
    {
    }
}