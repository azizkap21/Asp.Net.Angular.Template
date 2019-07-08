using System;
using Asp.Net.Angular.Template.Contract.Common;

namespace Asp.Net.Angular.Template.Contract.Base
{
    public class ApplicationError
    {


        public ApplicationError(string errorMessage) : this(Guid.NewGuid(), errorMessage)
        {

        }

        public ApplicationError(Guid errorId) : this(errorId, Errors.UnknownError, ErrorCode.UnknownError)
        {

        }

        public ApplicationError(Guid errorId, string errorMessage) : this(errorId)
        {
            UserError = errorMessage;
        }

        public ApplicationError(Guid errorId, string userError, ErrorCode errorCode) : this(errorId, userError,
            $"Unknown error. Check logs for more details, id: {errorId}, errorCode: {errorCode} "
            , errorCode, null)
        {

        }

        public ApplicationError(Guid errorId, string userError, string diagnosticError, ErrorCode errorCode, Exception exception = null)
        {
            ErrorId = errorId;
            UserError = userError;
            DiagnosticError = diagnosticError + Environment.NewLine + " " + (exception != null ? exception.StackTrace : string.Empty);
            ErrorCode = errorCode;
            Exception = exception;
        }

        public Guid ErrorId { get; }
        public ErrorCode ErrorCode { get; set; }
        public string UserError { get; }
        public string DiagnosticError { get; set; }
        public Exception Exception { get; set; }
    }
}
