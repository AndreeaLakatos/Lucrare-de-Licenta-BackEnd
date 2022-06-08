using System;
using System.Runtime.Serialization;
using AnimalAdoption.BusinessLogic.Utils;

namespace AnimalAdoption.BusinessLogic.Exceptions
{
    [Serializable]
    public class AnnouncementValidationException : Exception
    {
        public AnnouncementValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public AnnouncementValidationException(ErrorCode errorCode, string message) : base(message)
        {
            Data[StringLiterals.Exceptions.ErrorCodeKey] = errorCode;
        }

        public ErrorCode errorCode;

        protected AnnouncementValidationException(SerializationInfo serializationInfo, StreamingContext streamingContext) :
            base(serializationInfo, streamingContext)
        {
        }

        public AnnouncementValidationException() : base()
        {
        }

        public AnnouncementValidationException(string message) : base(message)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext streamingContext)
        {
            base.GetObjectData(info, streamingContext);
        }
    }
}
