using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDF.Business.ViewModels
{
    public class QuoteViewModel
    {
        public string Text { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"Quote: {(Text.EndsWith(".") ? Text : Text.Insert(Text.Length, ".")) } Author: {Author}";
        }
    }
}
