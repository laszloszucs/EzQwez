using System;

namespace EzQwez.Domain
{
    public class DomainException : Exception
    {
        public DomainException(string businessMessage) : base(businessMessage) { }
    }
}
