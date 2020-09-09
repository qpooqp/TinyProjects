using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFCore.SmartTags
{
    public static class DbContextExtensions
    {
        public static IQueryable<T> SmartTagWith<T>(
            this IQueryable<T> queryable,
            string tag = "",
            [CallerMemberName] string methodName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int line = 0)
        {
            return queryable.TagWith(string.IsNullOrEmpty(tag)
                ? $"{methodName} - {sourceFilePath}:{line}"
                : $"{tag}{Environment.NewLine}{methodName}  - {sourceFilePath}:{line}");
        }
    }
}
