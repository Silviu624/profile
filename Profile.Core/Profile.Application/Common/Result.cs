using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Application.Common
{
    public class Result<T>
    {
        public bool Succces { get; }
        public string? Error { get; }
        public T? Value { get; }

        private Result(bool success, T? value, string? error)
        {
            this.Succces = success;
            this.Error = error;
            this.Value = value;
        }

        public static Result<T> Ok(T value) => new (true, value, null);
        public static Result<T> Fail(string error) => new(false, default, error);
    }
}
