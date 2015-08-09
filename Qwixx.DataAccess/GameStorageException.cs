namespace Qwixx.DataAccess
{
    using System;
    using System.Runtime.Serialization;

    public class GameStorageException : Exception
    {
        public GameStorageException() 
        {

        }

        public GameStorageException(string message) : base(message)
        {
            
        }

        public GameStorageException(string message, Exception innerException) : base(message, innerException)
        {
            
        }

        public GameStorageException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            
        }
    }
}
