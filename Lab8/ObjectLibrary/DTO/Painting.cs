using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary.DTO
{
    public class Painting : DBObjectBase
    {
        public string Title { get; set; }

        public int Year { get; set; }
    }
}
