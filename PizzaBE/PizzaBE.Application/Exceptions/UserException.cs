using System;

namespace PizzaBE.Application.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string ex = "User not found") : base() { }
    }

    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException(string ex = "User already exists!") : base() { }
    }
    public class UserCreationFailedException : Exception
    {
        public UserCreationFailedException(string ex = "User creation failed! Please check user details and try again.") : base() { }
    }
}
