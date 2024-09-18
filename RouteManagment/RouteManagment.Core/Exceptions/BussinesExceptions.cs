using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteManagment.Core.Exceptions
{
    public class BussinesExceptions : Exception
    {
        public ErrorCode ErrorCode { get; }
        public string ErrorMessage { get; }

        public BussinesExceptions() { }
        public BussinesExceptions(ErrorCode errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
            ErrorMessage = message;
        }

    }

    public enum ErrorCode
    {
        NotFound,
        InvaliData,
        Unauthorized,
        Forbidden
    }
}
