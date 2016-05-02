using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary.DTO
{
    public class Artist : DBObjectBase
    {
        public string ArtistName { get; set; }

        public string ArtistSurname { get; set; }
    }
}
