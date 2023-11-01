﻿using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace ProjectTemplate.Common.Helpers;

public class DynamicEqualityComparer<T> : IEqualityComparer<T>
{
    public bool Equals(T? x, T? y)
    {
        if (x is null || y is null)
            return false;

        var type = typeof(T);
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var property in properties)
        {
            var xValue = property.GetValue(x);
            var yValue = property.GetValue(y);

            if (xValue is null || yValue is null)
                return false;

            if (!xValue.Equals(yValue))
                return false;
        }
        return true;
    }

    public int GetHashCode([DisallowNull] T obj)
    {
        unchecked
        {
            var type = typeof(T);
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            int hash = 17;
            foreach (var property in properties)
            {
                var value = property.GetValue(obj);
                if (value is not null)
                    hash = (hash * 31) + (value.GetHashCode());
            }
            return hash;
        }
    }
}