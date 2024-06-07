namespace MovieApi.Exceptions
{
    public class UserNotAuthenticatedException(string message) : Exception(message)
    {
    }
}