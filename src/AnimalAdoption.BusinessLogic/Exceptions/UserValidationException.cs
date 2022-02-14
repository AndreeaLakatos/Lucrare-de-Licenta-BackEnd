using System;
using System.Runtime.Serialization;
using AnimalAdoption.BusinessLogic.Utils;

namespace AnimalAdoption.BusinessLogic.Exceptions
{
    [Serializable]
    public class UserValidationException : Exception
    {
        public UserValidationException(string message, Exception innerException): base(message, innerException)
        {
        }

        public UserValidationException(ErrorCode errorCode, string message) : base(message)
        {
            Data[StringLiterals.Exceptions.ErrorCodeKey] = errorCode;
        }

        public ErrorCode errorCode;

        protected UserValidationException(SerializationInfo serializationInfo, StreamingContext streamingContext) :
            base(serializationInfo, streamingContext)
        {
        }

        public UserValidationException() : base()
        {
        }

        public UserValidationException(string message) : base(message)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext streamingContext)
        {
            base.GetObjectData(info, streamingContext);
        }
    }
}
