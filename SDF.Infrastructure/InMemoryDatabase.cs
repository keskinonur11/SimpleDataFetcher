using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDF.Models.Models;

namespace SDF.Infrastructure
{
    public static class InMemoryDatabase
    {
        public static List<Quote> Quotes { get; set; } = new();
    }
}
