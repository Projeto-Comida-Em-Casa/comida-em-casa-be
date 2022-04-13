using ComidaEmCasa.Core.Exceptions;

namespace ComidaEmCasa.Core.Results
{
    public class ResultContent<T>
    {
        public T Value { get; private set; }
        public bool Success { get; private set; }
        public ExceptionCode ExCode { get; private set; }

        public ResultContent(T value, bool success)
        {
            Value = value;
            Success = success;
        }

        public ResultContent(T value, bool success, ExceptionTags exTag)
        {
            Value = value;
            Success = success;
            ExCode = new ExceptionCode(exTag);
        }
    }
}
