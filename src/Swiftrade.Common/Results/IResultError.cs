﻿namespace Swiftrade.Common.Results
{
    public interface IResultError
    {
        string Error { get; }
        string Code { get; }
    }
}