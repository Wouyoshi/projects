namespace Qwixx.DataAccess
{
    using System;
    using System.Runtime.Serialization;

    public class GameIntentionStorageException : Exception
    {
        public GameIntentionStorageException() 
        {

        }

        public GameIntentionStorageException(string message) : base(message)
        {
            
        }

        public GameIntentionStorageException(string message, Exception innerException) : base(message, innerException)
        {
            
        }

        public GameIntentionStorageException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            
        }
    }
}
