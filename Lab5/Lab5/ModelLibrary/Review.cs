using LiteDBService.DBProvider;
using LiteDBService.DBProvider.BaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class Review : RepositoryModelBase
    {
        public string Content { get; set; }
        public int Score { get; set; }
        public Person Author { get; set; }
        public int MovieId { get; set; }
    }
}
