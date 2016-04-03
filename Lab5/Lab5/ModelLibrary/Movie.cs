using LiteDBService.DBProvider;
using LiteDBService.DBProvider.BaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class Movie : RepositoryModelBase
    {
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
    }
}
