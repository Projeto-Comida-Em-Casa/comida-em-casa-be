using AutoMapper;
using ComidaEmCasa.Core.Exceptions;

namespace ComidaEmCasa.Core.Results
{
    public class Result
    {
        public static ResultContent<T> Success<T>(T value)
        {
            return new ResultContent<T>(value, success: true);
        }

        public static ResultContent<T> Error<T>(ExceptionTags errorCode)
        {
            return new ResultContent<T>(value: default, success: false, exTag: errorCode);
        }

        /// <summary>
        /// Evaluates source result, converts the content and returns a new result content of the destination type
        /// </summary>
        /// <typeparam name="T">Destination type</typeparam>
        /// <typeparam name="T1">Source type</typeparam>
        /// <param name="result">Result to evaluate</param>
        /// <param name="mapper">Mapper instance</param>
        /// <returns></returns>
        public static ResultContent<T> Evaluate<T, T1>(ResultContent<T1> result, IMapper mapper)
        {
            var convert = mapper.Map<T>(result.Value);

            if (result.Success)
                return Success(convert);
            else
                return Error<T>(result.ExCode.Code);
        }
    }
}
