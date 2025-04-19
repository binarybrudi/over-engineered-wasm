namespace Diamond.Logic.Domain.Renderer3D.Contract.Exceptions;

public class RendererNotInitializedException : Exception
{
    public RendererNotInitializedException()
    {
    }

    public RendererNotInitializedException(string? message) : base(message)
    {
    }

    public RendererNotInitializedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
