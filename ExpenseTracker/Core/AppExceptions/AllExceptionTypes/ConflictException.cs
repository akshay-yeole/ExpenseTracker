namespace ExpenseTracker.Core.AppExceptions.ExceptionModels
{
    public class ConflictException : Exception
    {
        public ConflictException(string msg) : base(msg)
        {

        }
    }
}
