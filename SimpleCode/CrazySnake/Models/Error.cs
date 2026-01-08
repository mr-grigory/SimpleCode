namespace CrazySnake.Models;

public record Error
{
    private Error(ErrorsTypes errorType, string message)
    {
        Type = errorType;
        Message = message;
    }
    
    public ErrorsTypes Type { get; }
    public string Message { get; }
    
    
    public static Error Validation(ErrorsTypes errorType, string message) => 
        new(errorType, message);
}