using System.Collections.Generic;

namespace Swiftrade.Common.Results
{
    public interface IResult
    {
        IReadOnlyCollection<IResultError> Errors { get; }
        string Message { get; }

        bool IsSuccessful { get; }
    }

    public interface IResult<out T> : IResult
    {
        T Data { get; }
    }
}