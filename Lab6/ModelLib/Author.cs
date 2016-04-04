using LiteDBService.DBProvider.BaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelLib
{
    public class Author : RepositoryModelBase
    {
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
    }
}
