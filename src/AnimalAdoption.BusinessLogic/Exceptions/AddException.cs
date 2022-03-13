using System;
using System.Runtime.Serialization;
using AnimalAdoption.BusinessLogic.Utils;

namespace AnimalAdoption.BusinessLogic.Exceptions
{
    [Serializable]
    public class AddException : Exception
    {
        public AddException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public AddException(ErrorCode errorCode, string message) : base(message)
        {
            Data[StringLiterals.Exceptions.ErrorCodeKey] = errorCode;
        }

        public ErrorCode errorCode;

        protected AddException(SerializationInfo serializationInfo, StreamingContext streamingContext) :
            base(serializationInfo, streamingContext)
        {
        }

        public AddException() : base()
        {
        }

        public AddException(string message) : base(message)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext streamingContext)
        {
            base.GetObjectData(info, streamingContext);
        }
    }
}
