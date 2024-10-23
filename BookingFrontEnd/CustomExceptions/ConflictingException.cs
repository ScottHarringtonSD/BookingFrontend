public class ConflictingException : Exception 
{
    
    public ConflictingException(){

    }

    public ConflictingException(string message)
        : base(message)
    {
    }

     public ConflictingException(string message, Exception inner)
        : base(message, inner)
    {
    }
}