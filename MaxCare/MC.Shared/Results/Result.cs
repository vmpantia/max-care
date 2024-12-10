﻿using MC.Shared.Results.Errors;

namespace MC.Shared.Results
{
    public class Result<TData, TError>
        where TData : class
        where TError : Error
    {
        public TData? Data { get; init; }
        public TError? Error { get; init; }
        public bool IsSuccess { get; init; }

        private Result(TData data)
        {
            Data = data;
            Error = null;
            IsSuccess = true;
        }

        protected Result(TError error)
        {
            Data = default;
            Error = error;
            IsSuccess = false;
        }

        public static implicit operator Result<TData, TError>(TData data) => new (data);
        public static implicit operator Result<TData, TError>(TError error) => new (error);
    }
}