using LiteDBService.DBProvider.BaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelLib
{
    public class Book : RepositoryModelBase
    {
        public string BookTitle { get; set; }
        public string ISBN { get; set; }
    }
}
