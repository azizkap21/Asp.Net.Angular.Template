using Asp.Net.Angular.Template.Contract.Common;

namespace Asp.Net.Angular.Template.Contract.Base
{
    public class Result<TContent> : Result
    {
        public TContent Content { get; set; }

        public static new Result<TContent> Success(TContent content) => Success(content, Messages.Success);

        public static new Result<TContent> Success(TContent content, string message) => new Result<TContent>
        {
            Content = content,
            Succeeded = true,
            Message = message,
        };

        public static Result<TContent> Failure(ApplicationError error) => new Result<TContent> { ApplicationError = error };

        public static Result<TContent> FromOther(Result result)
        {
            Result<TContent> newResult = new Result<TContent>
            {
                Succeeded = result.Succeeded,
                ApplicationError = result.ApplicationError,
                Message = result.Message
            };

            return newResult;
        }
    }
}
