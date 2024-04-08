using System;

namespace permiakov_lab4.Models.Exceptions
{
    public class DateOfBirthInTheFutureException : Exception
    {
        public DateOfBirthInTheFutureException() : base("Date of birth cannot be in the future.") { }
    }

    public class DateOfBirthTooFarException : Exception
    {
        public DateOfBirthTooFarException() : base("Date of birth is too far in the past.") { }
    }

    public class InvalidEmailException : Exception
    {
        public InvalidEmailException() : base("Invalid email address format.") { }
    }

    public class EmptyFirstNameException : Exception
    {
        public EmptyFirstNameException() : base("First name cannot be empty.") { }
    }

    public class EmptyLastNameException : Exception
    {
        public EmptyLastNameException() : base("Last name cannot be empty.") { }
    }
}