namespace Asp.Net.Angular.Template.Contract.Base
{

    public class Result
    {
        public bool Succeeded { get; protected set; }

        public string Message { get; set; }

        public ApplicationError ApplicationError { get; protected set; }
        
        public static Result Success 
            => new Result { Succeeded = true };
                
        public static Result Failed(ApplicationError error)
            => new Result { Succeeded = false,  ApplicationError = error};

        public static Result Failed(string errorMessage)
            => new Result { Succeeded = false, Message = errorMessage};
    }
}
