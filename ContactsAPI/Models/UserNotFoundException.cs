using System;

namespace ContactsAPI.Models
{
    public class UserNotFoundException : ApplicationException
    {
        public UserNotFoundException(string message) : base(message) { }
    }
}
