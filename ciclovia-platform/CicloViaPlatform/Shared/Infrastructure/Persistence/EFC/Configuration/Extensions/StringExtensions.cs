﻿using Humanizer;

namespace CicloViaPlatform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;


public static class StringExtensions
{
    /// <summary>
    ///     Converts a string to snake case.
    /// </summary>
    /// <param name="text">The string to convert</param>
    /// <returns>The string converted to snake case</returns>
    public static string ToSnakeCase(this string text)
    {
        return new string(Convert(text.GetEnumerator()).ToArray());

        static IEnumerable<char> Convert(CharEnumerator e)
        {
            if (!e.MoveNext()) yield break;
            yield return char.ToLower(e.Current);
            
            while(e.MoveNext())
                if (char.IsUpper(e.Current))
                {
                    yield return '-';
                    yield return char.ToLower(e.Current);
                }
                else
                {
                    yield return e.Current;
                }
        }
    }

    /// <summary>
    ///     Pluralizes a string
    /// </summary>
    /// <param name="text">The string to convert</param>
    /// <returns>The string converted to plural</returns>
    public static string toPlural(this string text)
    {
        return text.Pluralize(false);
    }
}