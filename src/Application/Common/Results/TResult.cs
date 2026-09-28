using System;
using Application.Common.Results;

namespace Application.Common;

public class Result<Tvalue> : Result
{
    private readonly Tvalue _value;

    protected internal Result(Tvalue value, bool isSuccess, Error error) : base(isSuccess, error)
    {
        _value = value;
    }

    public Tvalue Value => IsSuccess ? _value : throw new InvalidOperationException("Cannot access the value of a failed result.");

}