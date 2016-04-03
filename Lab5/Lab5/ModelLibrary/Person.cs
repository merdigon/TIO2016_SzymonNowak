
using LiteDBService.DBProvider;
using LiteDBService.DBProvider.BaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class Person : RepositoryModelBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
