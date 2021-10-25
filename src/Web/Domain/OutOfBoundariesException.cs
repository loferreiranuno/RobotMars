using System;
using System.Runtime.Serialization;

namespace Web.Domain
{
    [Serializable]
    public class OutOfBoundariesException : Exception
    {
        public OutOfBoundariesException()
        {
        } 
    }
}