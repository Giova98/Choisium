namespace Choisium.Application.Common
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public T? Value { get; }
        public string Error { get; }

        private Result(bool isSucess, T? value, string error)
        {
            IsSuccess = isSucess;
            Value = value;
            Error = error; 
        }

        public static Result<T> Success(T value) => new(true, value, string.Empty);
        public static Result<T> Failure(string error) => new(false, default, error);

    }
}