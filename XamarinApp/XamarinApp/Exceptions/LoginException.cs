using System;

namespace XamarinApp.Exceptions
{
    public class LoginException : Exception
    {
        public LoginException(string messagem) : base(messagem)
        {

        }
    }
}
