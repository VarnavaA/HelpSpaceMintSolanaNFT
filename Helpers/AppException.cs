using System;
using System.Globalization;
namespace HelpSpace.Helpers
{
    public class AppException : Exception
    {
        private int _errorCode;

        public int ErrorCode { get => _errorCode; }

        public AppException() : base() { }

        public AppException(string message) : base(message) { }

        public AppException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }

        public AppException(int errorCode) : base()
        {
            _errorCode = errorCode;
        }

        public AppException(string message, int errorCode) : base(message)
        {
            _errorCode = errorCode;
        }
    }
}

