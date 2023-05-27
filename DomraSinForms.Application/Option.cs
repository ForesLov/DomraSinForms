using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.Application;
public class Option<T> where T : class
{
    private T? _value;
    public static Option<T> Some(T obj) => new() { _value = obj };
    public static Option<T> None() => new();
    public Option<TResult> Map<TResult>(Func<T, TResult> map) where TResult : class =>
        _value is null ? Option<TResult>.None() : Option<TResult>.Some(map(_value));
    public T Reduce(T defaultValue) => _value ?? defaultValue;
}
