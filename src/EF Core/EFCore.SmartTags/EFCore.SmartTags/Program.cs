using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFCore.SmartTags
{
    internal static class Program
    {
        private static void Main()
        {
            using var ctx = new FooDbContext();

            ctx.Database.EnsureCreated();

            //classic tag
            var fooIds1 = ctx.Foos
                .Where(f => f.Id > 10)
                .OrderBy(f => f.Text)
                .Select(f => f.Id)
                .TagWith("Query with tag")
                .ToList();

            //smart tag (with source code info)
            var fooIds2 = ctx.Foos
                .Where(f => f.Id > 10)
                .OrderBy(f => f.Text)
                .Select(f => f.Id)
                .SmartTagWith("Query with smart tag")
                .ToList();
        }
    }
}
