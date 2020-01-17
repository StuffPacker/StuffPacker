using Shared.Contract.Error;
using System;
using System.Net;
using System.Runtime.Serialization;

namespace Shared.Contract.Exceptions
{
    [Serializable]
    public class ApplicationHttpException : ApplicationException
    {
        public ApplicationHttpException(HttpStatusCode statusCode, ErrorViewModel content)
        {
            StatusCode = statusCode;
            Content = content;
        }

        public ApplicationHttpException(HttpStatusCode statusCode, string message, System.Exception innerException = null) :
            base(
                message, innerException)
        {
            StatusCode = statusCode;
        }

        protected ApplicationHttpException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.StatusCode = (HttpStatusCode)info.GetValue("StatusCode", typeof(HttpStatusCode));
            this.Content = (ErrorViewModel)info.GetValue("Content", typeof(ErrorViewModel));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("StatusCode", this.StatusCode);
            info.AddValue("Content", this.Content);
            base.GetObjectData(info, context);
        }

        public HttpStatusCode StatusCode { get; }
        public ErrorViewModel Content { get; }
    }
}
