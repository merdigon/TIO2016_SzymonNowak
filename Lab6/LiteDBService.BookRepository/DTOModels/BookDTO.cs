using LiteDBService.DBProvider;
using LiteDBService.DBProvider.BaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDBService.MovieRepository.DTOModels
{
    public class BookDTO : BaseDTO
    {
        public string BookTitle { get; set; }
        public string ISBN { get; set; }
    }
}
