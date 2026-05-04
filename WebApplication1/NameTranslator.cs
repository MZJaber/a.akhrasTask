using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql;
using System.Linq.Expressions;

namespace WebApplication1
{
    public class NameTranslator<T> : ValueConverter<T, string> where T : struct, Enum
    {
        public NameTranslator(Expression<Func<T, string>> convertToProviderExpression, Expression<Func<string, T>> convertFromProviderExpression) 
            : base(convertToProviderExpression, convertFromProviderExpression, null)
        { }

        public NameTranslator() 
            : this (t => t.ToString().ToLower(), t => Enum.Parse<T>(t)) { }
    }
}
