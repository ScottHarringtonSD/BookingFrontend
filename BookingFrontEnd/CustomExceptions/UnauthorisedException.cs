public class UnauthorisedException : Exception 
{
    
    public UnauthorisedException(){

    }

    public UnauthorisedException(string message)
        : base(message)
    {
    }

     public UnauthorisedException(string message, Exception inner)
        : base(message, inner)
    {
    }
}