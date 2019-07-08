namespace Asp.Net.Angular.Template.Contract.Common
{    
    public class Errors
    {
        public const string AlreadyExist = "Already Exist";

        public const string UnknownError = "Unknown Error occured, please check logs for more details";

        public const string ServerTimeout = "Timeout expired before response received";

        public const string LoginExpired = "Login expired, please login again";

        public const string InvalidCredentials = "Invalid User Id or Password, Please try again";

        public const string LoginRetriesExceeded = "Login retries exceeded, please try later";

        public const string UserLocked = "This user id has been locked, please contact to administrator to reset it.";

        public const string DoesNotExist = " does not exist";
        public const string UnauthorizedOperation = "You are not authorized to perform this operation";
    }

    public class Warnings
    {
        public const string LoginRetriesRemaining = "Login failed, remaining retries ";

        public const string WeakPass = "Your password is weak";
        public const string MediumStrength = "Your password strength is medium";
        public const string StrongPass = "Your password is strong";

    }

    public class Confirmations
    {
        public const string DeleteConfirm = " will be deleted permanatly, do you want to proceed?";

    }

    public class Messages
    {
        public const string Successfully = "Successfully";

        public const string Success = "Success";
    }

}
